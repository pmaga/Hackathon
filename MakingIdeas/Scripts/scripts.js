
$(document).ready(function () {
    getfrontpageContent();

    $('#the-basics .typeahead').typeahead({
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
        fragment += "<div class='col-md-4'><h2>" + title + "</h2><p>" + body + "</p><p><a class='btn btn-default' href='#' role='button'>View details &raquo;</a></p></div>";

    });
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


