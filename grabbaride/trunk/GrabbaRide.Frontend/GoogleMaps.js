
var map = null;
var geocoder = null;
var startMkr = null;
var endMkr = null;
var startpoly = null;
var endpoly = null;
var line = null;

//init stuff
function doPageLoad() {
  if (GBrowserIsCompatible()) {
    if (document.getElementById("searchmap")) {
      map = new GMap2(document.getElementById("searchmap"));
      geocoder = new GClientGeocoder();
      
      map.setCenter(new GLatLng(-40.356233600914656,175.61113357543945), 13);
      GEvent.addListener(map, "click", MapHandler);
      map.addControl(new GSmallMapControl());
      map.addControl(new GMapTypeControl());
      var hfstart = document.getElementById("ctl00_MainContentPlaceHolder_hfstart");
      var hfend = document.getElementById("ctl00_MainContentPlaceHolder_hfend");
      if (hfstart.value != "") {
        var temp = hfstart.value.split(',');
        SetStart(temp[0],temp[1]);
      }
      if (hfend.value != "") {
        var temp = hfend.value.split(',');
        SetEnd(temp[0],temp[1]);
      }
    }
  }
}

//Set the start location by transferring the lat,long to a hidden field
function SetStart(lat, lng) {
  lat = parseFloat(lat);
  lng = parseFloat(lng);
  var hfstart = document.getElementById("ctl00_MainContentPlaceHolder_hfstart");
  hfstart.value = lat + "," + lng;
  if (!startMkr) {
    var starticon = new GIcon(G_DEFAULT_ICON);
    starticon.image = "Images/starticon.png";

    startMkr = new GMarker(new GLatLng(lat, lng), { icon:starticon, draggable: true });
    GEvent.addListener(startMkr, "click", StartHandler);
    GEvent.addListener(startMkr, "dragstart", BeginDrag);
    GEvent.addListener(startMkr, "dragend", EndDrag);
    map.addOverlay(startMkr);
  } else {
    startMkr.setLatLng(new GLatLng(lat, lng));
  }
  
  if (endMkr && startMkr)
  {
    DrawBoundingBoxes();
  }
}

//marker dragstart hanlder
function BeginDrag() {
    //remove everything except the markers from the map
    map.closeInfoWindow();
    map.removeOverlay(line);
    map.removeOverlay(startpoly);
    map.removeOverlay(endpoly);
    line = null;
    startpoly = null;
    endpoly = null;
}

//marker dragend handler
function EndDrag() {
    //update the hidden fields in case our marker positions have changed
    var temp = startMkr.getLatLng();
    var hftemp = document.getElementById("ctl00_MainContentPlaceHolder_hfstart");
    hftemp.value = temp.lat() + "," + temp.lng();
    temp = endMkr.getLatLng();
    hftemp = document.getElementById("ctl00_MainContentPlaceHolder_hfend");
    hftemp.value = temp.lat() + "," + temp.lng();
    //redraw the bounding boxes and lines
    if (endMkr && startMkr)
    {
        DrawBoundingBoxes();
    }
}

//Set the end location by transferring the lat,long to a hidden field
function SetEnd(lat, lng) {
  lat = parseFloat(lat);
  lng = parseFloat(lng);
  var hfend = document.getElementById("ctl00_MainContentPlaceHolder_hfend");
  hfend.value = lat + "," + lng;
  if (!endMkr) {
    var endicon = new GIcon(G_DEFAULT_ICON);
    endicon.image = "Images/endicon.png";
    
    endMkr = new GMarker(new GLatLng(lat, lng), { icon:endicon, draggable: true });
    GEvent.addListener(endMkr, "click", EndHandler);
    GEvent.addListener(endMkr, "dragstart", BeginDrag);
    GEvent.addListener(endMkr, "dragend", EndDrag);
    map.addOverlay(endMkr);
  } else {
    endMkr.setLatLng(new GLatLng(lat, lng));
  }
  
  //if only one point is defined, don't draw a bounding box. Otherwise, draw a bounding box that is
  //+- 10% of the distance between the points, as well as a line to join the two
  if (endMkr && startMkr)
  {
    DrawBoundingBoxes();
  }
  
}

function DrawBoundingBoxes() {
    var xlatlng = startMkr.getLatLng();
    var xlat = xlatlng.lat();
    var xlng = xlatlng.lng();
    var latlng = endMkr.getLatLng();
    var lat = latlng.lat();
    var lng = latlng.lng();
    var lineardistance = Math.sqrt(Math.pow(lat - xlat,2) + Math.pow(lng - xlng,2));
    var Offset = lineardistance * 0.1; //sets offset to be 10% of linear distance between points
    if (startpoly)
        map.removeOverlay(startpoly);
    startpoly = new GPolygon([
    new GLatLng(xlat + Offset, xlng - Offset),
    new GLatLng(xlat + Offset, xlng + Offset),
    new GLatLng(xlat - Offset, xlng + Offset),
    new GLatLng(xlat - Offset, xlng - Offset),
    new GLatLng(xlat + Offset, xlng - Offset)
    ], "#507cd1", 5, 1, "#e2f3ec", 0.2);
    if (endpoly)
        map.removeOverlay(endpoly);
    endpoly = new GPolygon([
    new GLatLng(lat + Offset, lng - Offset),
    new GLatLng(lat + Offset, lng + Offset),
    new GLatLng(lat - Offset, lng + Offset),
    new GLatLng(lat - Offset, lng - Offset),
    new GLatLng(lat + Offset, lng - Offset)
    ], "#507cd1", 5, 1, "#e2f3ec", 0.2);
    if (line)
        map.removeOverlay(line);
    line = new GPolyline([xlatlng,latlng], "#507cd1", 4, 1);
    map.addOverlay(line);
    map.addOverlay(startpoly);
    map.addOverlay(endpoly);
    GEvent.addListener(startpoly, "click", PolyHandler);
    GEvent.addListener(endpoly, "click", PolyHandler);
}

//onclick handler for map
function MapHandler(overlay, latlng) {
  if (latlng) { 
    var myHtml = "<a onclick='SetStart(" + latlng.lat() + ", " + latlng.lng() + ");'>Set Start</a><br><a onclick='SetEnd(" + latlng.lat() + ", " + latlng.lng() + ");'>Set End</a>";
    map.openInfoWindow(latlng, myHtml);
  }
}

//onclick handler for  polygons
function PolyHandler(latlng) {
  if (latlng) { 
    var myHtml = "<a onclick='SetStart(" + latlng.lat() + ", " + latlng.lng() + ");'>Set Start</a><br><a onclick='SetEnd(" + latlng.lat() + ", " + latlng.lng() + ");'>Set End</a>";
    map.openInfoWindow(latlng, myHtml);
  }
}

//onclick handler for Start Marker
function StartHandler(latlng) { 
  if (latlng) { 
    var myHtml = "This is your set<br>start location";
    map.openInfoWindow(latlng, myHtml);
  } 
}

//onclick handler for End Marker
function EndHandler(latlng) { 
  if (latlng) { 
    var myHtml = "This is your set<br>end location";
    map.openInfoWindow(latlng, myHtml);
  } 
}

//code pinched from http://code.google.com/apis/maps/documentation/examples/geocoding-simple.html
//executed when someone uses the geocoder search
function showAddress(address) {
  if (geocoder) {
    geocoder.getLatLng(
      address,
      function(point) {
        if (!point) {
          alert(address + " not found");
        } else {
          map.setCenter(point, 13);
        }
      }
    );
  }
}

window.onload = doPageLoad;
