
$(document).ready(function () {
    getfrontpageContent();

    $('#topics .typeahead').typeahead({
        hint: true,
        highlight: true,
        minLength: 1
    },
{
    name: 'topics',
    source: substringMatcher(topics)
});

});

function getfrontpageContent() {
    $.ajax({
        url: "/api/ideas/getNewest/3",
        context: document.body,
        success: OnSuccess
    });
}

function OnSuccess(response) {
    var items = response;
    var fragment = "";
    $.each(items, function (index, val) {
        var title = val.Title;
        var body = val.Body;
        var topics = "design"; val.Topics;

        fragment += "<div class='col-sm-12 col-md-4 clearfix'><div class='meta'><small>Topic: " + topics + "</small></div>" +
            "<a href='' title=''>" +
            "<figure>" +
            "<img src='img/img-01.jpg' />" +
            "</figure>" +
            "<h3>" + title + "</h3>" +
            "<p>" + body + "</p>" +
            "<p>" +
            "<a href=''><small class='right'>Read more &rarr;</small></a>" +
            "</p>" +
            "</a>" +
            "</div>";

    });
    $("#contentholder").append(fragment);
}


function PublishPost() {

    var tags = [];
    tags.push($("#topic1").val());
    tags.push($("#topic2").val());

    var post = {
        Title: $("#heading").val(),
        thumbnailurl: $("#thumbnailurl").val(),
        Project: $("#projectref").val(),
        Body: tinyMCE.get('postbody').getContent()
    };


    $.ajax({
            method: "POST",
            url: "/api/ideas",
            dataType: "application/json",
            data: { Title: post.Title, body: post.Body, Tags: tags, Project: post.Project, Thumbnailurl: post.Thumbnailurl }
    })
        .error(function (err) {
        })
        .done(function(msg) {
        });
}

var substringMatcher = function (strs) {
    return function findMatches(q, cb) {
        var matches, substringRegex;

        // an array that will be populated with substring matches
        matches = [];

        // regex used to determine if a string contains the substring `q`
        substrRegex = new RegExp(q, 'i');

        // iterate through the pool of strings and for any string that
        // contains the substring `q`, add it to the `matches` array
        $.each(strs, function (i, str) {
            if (substrRegex.test(str)) {
                matches.push(str);
            }
        });

        cb(matches);
    };
};

var topics = ['Design', 'Backend', 'Frontend', 'UX'];


