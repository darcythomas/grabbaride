//This file is in the GrabbaRide Namespace
if (!GrabbaRide) { var GrabbaRide = new Object(); }


/**
* AJAXRequest - fires a standard POST message to the page specified by url, sending it content.
* When the response is recieved, the data is passed to function specified by callback.
* TODO: Needs type checking, make sure callback is a function, check whether we want 
* to pass the responsetext or xml data.
* Constructed from code on the page http://en.wikipedia.org/wiki/XMLHttpRequest
**/
GrabbaRide.AJAXRequest = function(url, content, callback)
{
    if( typeof XMLHttpRequest == "undefined" )
        alert("Your browser doesn't support the scripting neccesary to run this website properly");
    var request =  new XMLHttpRequest();
    request.open("POST", url, true);
    request.setRequestHeader("Content-Type",
                           "application/x-javascript;");
 
    if (callback) {
        request.onreadystatechange = function() {
            if (request.readyState == 4 && request.status == 200) {
                if (request.responseText) {
                    callback(request.responseXML);
                }
            }
        }  
    }
    request.send(content);
}

/**
* setEventListener - sets an event listener defined by the "event" parameter to a function specified by "call", 
* and binds it to the object specified by the "source" parameter. Valid events are:
* - mousedown
* - mouseup
* - keydown
* - keyup
* - click
* - dblclick
* - mouseover
* - mousemove
* - mouseout
* - keypress
* These are just the keyboard and mouse events, for more events related to the page,
* browser, or other elements; refer to http://en.wikipedia.org/wiki/DOM_events
**/

GrabbaRide.setEventListener = function(source, event, call) 
{
    if (typeof source == "string")
        source = document.getElementById(source);
    if (source)
        source.addEventListener(event, call, false);
}