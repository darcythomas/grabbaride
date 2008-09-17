
var map = null;
var geocoder = null;
var startMkr = null;
var endMkr = null;
var startpoly = null;
var endpoly = null;

function doPageLoad() {
  if (GBrowserIsCompatible()) {
    if (document.getElementById("searchmap")) {
      map = new GMap2(document.getElementById("searchmap"));
      geocoder = new GClientGeocoder();
      
      map.setCenter(new GLatLng(-40.364988693138365, 175.60242176055908), 15);
      GEvent.addListener(map, "click", MapHandler);
      map.addControl(new GSmallMapControl());
      map.addControl(new GMapTypeControl());
    }
  }
}

function SetStart(lat, lng) {
  var hfstart = document.getElementById("ctl00_MainContentPlaceHolder_hfstart");
  hfstart.value = lat + "," + lng;
  if (!startMkr) {
    startMkr = new GMarker(new GLatLng(lat, lng));
    map.addOverlay(startMkr);
  } else {
    startMkr.setLatLng(new GLatLng(lat, lng));
  }
  
  var Offset = 0.005;
  if (startpoly)
    map.removeOverlay(startpoly);
  startpoly = new GPolygon([
    new GLatLng(lat, lng - Offset),
    new GLatLng(lat + Offset, lng),
    new GLatLng(lat, lng + Offset),
    new GLatLng(lat - Offset, lng),
    new GLatLng(lat, lng - Offset)
  ], "#f33f00", 5, 1, "#ff0000", 0.2);
  map.addOverlay(startpoly);
}

function SetEnd(lat, lng) {
  var hfend = document.getElementById("ctl00_MainContentPlaceHolder_hfend");
  hfend.value = lat + "," + lng;
  if (!endMkr) {
    endMkr = new GMarker(new GLatLng(lat, lng));
    map.addOverlay(endMkr);
  } else {
    endMkr.setLatLng(new GLatLng(lat, lng));
  }
  var Offset = 0.005;
  if (endpoly)
    map.removeOverlay(endpoly);
  endpoly = new GPolygon([
    new GLatLng(lat, lng - Offset),
    new GLatLng(lat + Offset, lng),
    new GLatLng(lat, lng + Offset),
    new GLatLng(lat - Offset, lng),
    new GLatLng(lat, lng - Offset)
  ], "#f33f00", 5, 1, "#ff0000", 0.2);
  map.addOverlay(endpoly);
}

function MapHandler(overlay, latlng) {
  if (latlng) { 
    var myHtml = "<a onclick='SetStart(" + latlng.lat() + ", " + latlng.lng() + ");'>Set Start</a><br><a onclick='SetEnd(" + latlng.lat() + ", " + latlng.lng() + ");'>Set End</a>";
    map.openInfoWindow(latlng, myHtml);
  }
}

//code pinched from http://code.google.com/apis/maps/documentation/examples/geocoding-simple.html
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