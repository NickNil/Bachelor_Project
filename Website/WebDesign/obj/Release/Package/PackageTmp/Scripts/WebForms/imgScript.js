$("document").ready(function () {
    var ratio = $("#logo").width() / $("#logo").height();
    $("#logo").css("width", "90%");
    $("#logo").css("height", $("#logo").width() / ratio + "px");
});