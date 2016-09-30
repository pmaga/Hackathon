
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
    var post = {
        title: $("#heading").val(),
        body: tinyMCE.get('postbody').getContent()
    };


    $.ajax({
            method: "POST",
            url: "Post.html",
            data: {
                data: JSON.stringify(post)
            }
        })
        .done(function(msg) {
            alert("Data Saved: " + msg);
        });
}
