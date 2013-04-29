$("document").ready(function () {
    var ratio = $("#logo").width() / $("#MyPic").height();
    $("#logo").css("width", "100%");
    $("#logo").css("height", $("#logo").width() / ratio + "px");
});