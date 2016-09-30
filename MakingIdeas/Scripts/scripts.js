
$(document).ready(function () {
    //getfrontpageContent();

 

});

function getfrontpageContent() {
    $.ajax({
        url: "https://jsonplaceholder.typicode.com/posts",
        context: document.body,
        success: OnSuccess
    });
}

function OnSuccess(response) {
    var items = response;
    var fragment = "<ul>";
    $.each(items, function (index, val) {
        var name = val.title;
        fragment += "<li> " + name + "</li>";
    });
    fragment += "</ul>";
    $("#contentholder").append(fragment);
}


function PublishPost() {
    $.ajax({
            method: "POST",
            url: "Post.html",
            data: {
                data: tinyMCE.get('postbody').getContent()
            }
        })
        .done(function(msg) {
            alert("Data Saved: " + msg);
        });
}
