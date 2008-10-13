
var map = null;
var geocoder = null;
var startMkr = null;
var endMkr = null;
var startpoly = null;
var endpoly = null;
var line = null;
var hfstart = null;
var hfend = null;

//init stuff
function doPageLoad() {
  if (GBrowserIsCompatible()) {
    var maptype = null;
    //determine the map type based on the div present
    if (document.getElementById("searchmap")) {
        maptype = "normal";
    } else if (document.getElementById("searchmapread")) {
        maptype = "readonly";
    }
      
    if (maptype) {
      if (maptype == "normal")
        map = new GMap2(document.getElementById("searchmap"));
      else if (maptype == "readonly")
        map = new GMap2(document.getElementById("searchmapread"));
      geocoder = new GClientGeocoder();
      geocoder.setBaseCountryCode("nz");
      map.setCenter(new GLatLng(-40.356233600914656,175.61113357543945), 13);
      if (maptype == "normal")
        GEvent.addListener(map, "click", MapHandler);
      map.addControl(new GSmallMapControl());
      map.addControl(new GMapTypeControl());
      //if the hidden fields have values, display them on the map
      hfstart = document.getElementById("ctl00_MainContentPlaceHolder_hfstart");
      hfend = document.getElementById("ctl00_MainContentPlaceHolder_hfend");
      if (hfstart.value != "") {
        var temp = hfstart.value.split(',');
        map.setCenter(new GLatLng(parseFloat(temp[0]),parseFloat(temp[1])), 13);
        SetStart(temp[0],temp[1], maptype);
      }
      if (hfend.value != "") {
        var temp = hfend.value.split(',');
        SetEnd(temp[0],temp[1], maptype);
      }
    }
  }
}

//Set the start location by transferring the lat,long to a hidden field and making a marker on the map
function SetStart(lat, lng, maptype) {
  lat = parseFloat(lat);
  lng = parseFloat(lng);
  hfstart.value = lat + "," + lng;
  if (!startMkr) {
    var starticon = new GIcon(G_DEFAULT_ICON);
    starticon.image = "Images/starticon.png"; //custom icon

    if (maptype == "normal") {
        startMkr = new GMarker(new GLatLng(lat, lng), { icon:starticon, draggable: true });
        GEvent.addListener(startMkr, "click", StartHandler);
        GEvent.addListener(startMkr, "dragstart", BeginDrag);
        GEvent.addListener(startMkr, "dragend", EndDrag);
    } else {
        startMkr = new GMarker(new GLatLng(lat, lng), { icon:starticon, draggable: false });
        GEvent.addListener(startMkr, "click", StartHandler);
    }
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
    var temp;
    if (startMkr) {
        temp = startMkr.getLatLng();
        hfstart.value = temp.lat() + "," + temp.lng();
    }
    if (endMkr) {
        temp = endMkr.getLatLng();
        hfend.value = temp.lat() + "," + temp.lng();
    }
    //redraw the bounding boxes and lines
    if (endMkr && startMkr)
    {
        DrawBoundingBoxes();
        valGMapLocations();
    }
}

//Set the end location by transferring the lat,long to a hidden field and making a marker on the map
function SetEnd(lat, lng, maptype) {
  lat = parseFloat(lat);
  lng = parseFloat(lng);
  hfend.value = lat + "," + lng;
  if (!endMkr) {
    var endicon = new GIcon(G_DEFAULT_ICON);
    endicon.image = "Images/endicon.png"; //custom icon
    
    if (maptype == "normal") {
        endMkr = new GMarker(new GLatLng(lat, lng), { icon:endicon, draggable: true });
        GEvent.addListener(endMkr, "click", EndHandler);
        GEvent.addListener(endMkr, "dragstart", BeginDrag);
        GEvent.addListener(endMkr, "dragend", EndDrag);
    } else {
        endMkr = new GMarker(new GLatLng(lat, lng), { icon:endicon, draggable: false });
        GEvent.addListener(endMkr, "click", EndHandler);
    }
    map.addOverlay(endMkr);
  } else {
    endMkr.setLatLng(new GLatLng(lat, lng));
  }
  
  //if only one point is defined, don't draw a bounding box. Otherwise, draw a bounding box that is
  //+- 10% of the distance between the points, as well as a line to join the two
  if (endMkr && startMkr)
  {
    DrawBoundingBoxes();
    valGMapLocations();
  }
  
}

//draws the bounding boxes around the start and end points, as well as a line between them
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
    //allow click events on the polys to flow through to the map.
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

//onclick handler for polygons, needed because polys fire different event arguments to the map
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
function setAddress(address, marker) {
  if (geocoder) {
    if (marker == "start") {
        geocoder.getLatLng(
          address,
          function(point) {
            if (!point) {
              alert(address + " not found");
            } else {
              map.setCenter(point, 13);
              SetStart(point.lat(), point.lng(), "normal");
            }
          }
        );
    } else if (marker == "end") {
        geocoder.getLatLng(
          address,
          function(point) {
            if (!point) {
              alert(address + " not found");
            } else {
              map.setCenter(point, 13);
              SetEnd(point.lat(), point.lng(), "normal");
            }
          }
        );
    } else {
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
}

//sets init to occur on page load
window.onload = doPageLoad;
