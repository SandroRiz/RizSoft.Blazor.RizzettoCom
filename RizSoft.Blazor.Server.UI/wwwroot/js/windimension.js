
window.getDimensions = function () {
    return {
        width: window.innerWidth,
        height: window.innerHeight
    };
};



// Defining event listener function
function displayWindowSize() {
    // Get width and height of the window excluding scrollbars
    var w = document.documentElement.clientWidth;
    var h = document.documentElement.clientHeight;

    // Display result inside a div element
    document.getElementById("winDimension").innerHTML = "Window Size: Width: " + w + "px - " + "Height: " + h + "px";
}

// Attaching the event listener function to window's resize event
window.addEventListener("resize", displayWindowSize);

// Calling the function for the first time
displayWindowSize();


//window.browserResize = {
//    getInnerHeight: function () {
//        return window.innerHeight;
//    },
//    getInnerWidth: function () {
//        return window.innerWidth;
//    },
//    registerResizeCallback: function () {
//        window.addEventListener("resize", browserResize.resized);
//    },
//    resized: function () {
//        //DotNet.invokeMethod("BrowserResize", 'OnBrowserResize');
//        DotNet.invokeMethodAsync("RizSoft.GeoItaly.UI", 'OnBrowserResize').then(data => data);
//    }
//}