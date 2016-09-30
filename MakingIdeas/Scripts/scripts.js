
$(document).ready(function () {
    getfrontpageContent();
});

function getfrontpageContent() {
    $.ajax({
        url: "/api/ideas",
        context: document.body,
        success: OnSuccess
    });
}

function OnSuccess(response) {
    var items = response;
    var fragment = "<ul>";
    $.each(items, function (index, val) {
        var title = val.Title;
        var body = val.Body;
        fragment += "<li> " + title + "<br><br>" + body + "<br><hr>" + "</li>";
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
