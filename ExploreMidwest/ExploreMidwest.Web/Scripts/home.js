var num = 5;
var set = 0;

$(document).ready(function () {
    $('#details').hide();
    set = 0;
    loadData();
});

function loadData() {
    getNumber(num, set);
    $('#newCategory').hide();
    newCategory();
    getPages();
}

$('#navigation').click(function () {
    var paramChangeBoxes = $('input:checkbox.change');
    if ($(this).is(':checked')) {
        paramChangeBoxes.attr('disabled', 'disabled');
        $('#finished').attr('disabled', 'disabled');
    }
    else {
        paramChangeBoxes.removeAttr('disabled');
        $('#finished').removeAttr('disabled');
    }
});

function getNumber(number, sets) {
    $.ajax({
        url: 'http://localhost:8080/blogs/' + number + '/' + sets,
        type: 'GET',
        success: function (blogs) {
            var output = "";
            var i = 0;

            for (i; i < blogs.length; i++) {
                if (blogs[i].IsFinished) {
                    output += '<div class="col-xs-3 blogDiv">Image</div>'
                    output += '<div class="col-xs-9 blogDiv"><div class="col-xs-3 titleDiv"><h4>'
                    output += blogs[i].Title + '</h4><br /><h5>'
                    output += blogs[i].Category.CategoryType + '</h5><br />'
                    output += blogs[i].Date.slice(0,10) + '</div>'
                    output += '<div class="col-xs-9 innerDiv">'
                    output += blogs[i].Body
                    output += '</div><div style="text-align:end"><button type="button" class="btn btn-default" onclick="FullArticle(' + blogs[i].BlogId + ')">Read full article</button></div></div>'
                }
            }
            $('#BlogsArea').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {

        }
    })
}

function newCategory() {
    $('#searchCategory').on('change', function () {
        if ($(this).val() == "new") {
            $('#newCategory').show();
        }
        else {
            $('#newCategory').hide();
        }
    });

    //$('#newCategory').hide();
}

function getPages() {
    $.ajax({
        url: 'http://localhost:8080/pages',
        type: 'GET',
        success: function (pages) {
            var output = "";
            var i = 0;

            for (i; i < pages.length; i++) {
                if (pages[i].IsInNavigation) {
                    output += '<li><a href="http://localhost:8080/Home/page/' + pages[i].PageId + '">'
                    output += pages[i].Title
                    output += '</a></li>'
                }
            }
            $('#staticpages').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {

        }
    })
}

function search() {
    var para = $('#searchTerm').val();
    var type = $('#searchCategory').val();
    $.ajax({
        url: 'http://localhost:8080/blog/' + type + '/' + para,
        type: 'GET',
        success: function (blogs) {
            var output = "";
            var i = 0;

            for (i; i < blogs.length; i++) {
                if (blogs[i].IsFinished) {
                    output += '<div class="col-xs-3 blogDiv">Image</div>'
                    output += '<div class="col-xs-9 blogDiv"><div class="col-xs-3 titleDiv"><h4>'
                    output += blogs[i].Title + '</h4><br /><h5>'
                    output += blogs[i].Category.CategoryType + '</h5>'
                    output += blogs[i].Date + '</div>'
                    output += '<div class="col-xs-9 innerDiv">'
                    output += blogs[i].Body
                    output += '<div style="text-align:end"><button type="button" class="btn btn-default" id="det' + blogs[i].BlogId + '">Read full article</button></div></div></div>'
                }
            }
            $('#BlogsArea').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {

        }
    })
}
function FullArticle(id) {
    $('#details').show("slow");
    $('#BlogsArea').hide();
    $('.next').hide();
    $.ajax({
        url: 'http://localhost:8080/blog/' + id,
        type: 'GET',
        success: function (blog) {
            var output = "";
            var i = 0;
            output += '<div class="col-xs-offset-2 col-xs-8 detailDiv"><h3>' + blog.Title
            output += '</h3 ><h4>' + blog.Category.CategoryType
            output += '</h4 ><h4>' + blog.Date
            output += '</h4 ></div><div class="col-xs-offset-2 col-xs-8 detailDiv"><p>' + blog.Body
            output += '</p ></div><div class="col-xs-offset-2 col-xs-8 detailDiv"><p>'
            for (i; i < blog.Tags.length; i++){
                output += blog.Tags[i].TagName + ', '
            }
            output = output.slice(0, -2)
            output += '</p ></div>'
            $('#details').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {

        }
    })
}