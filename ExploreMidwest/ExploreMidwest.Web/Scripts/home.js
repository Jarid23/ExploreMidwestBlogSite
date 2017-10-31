﻿var num = 5;
var set = 0;

$(document).ready(function () {
    $('#details').hide();
    set = 0;
    loadData();
});

function loadData() {
    getNumber(num, set);
    getPages();
}

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
                    output += '<div class="col-xs-9 blogDiv"><div class="col-xs-3 innerDiv"><h3>'
                    output += blogs[i].Title + '</h3><br /><h4>'
                    output += blogs[i].Category.CategoryType + '</h4><br />'
                    output += blogs[i].Date + '</div>'
                    output += '<div class="col-xs-9 innerDiv">'
                    output += blogs[i].Body
                    output += '<div style="text-align:end"><button type="button" class="btn btn-default" onclick="FullArticle(' + blogs[i].BlogId + ')">Read full article</button></div></div></div>'
                }
            }
            $('#BlogsArea').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {

        }
    })
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
                    output += '<div class="col-xs-9 blogDiv"><div class="col-xs-3 innerDiv"><h3>'
                    output += blogs[i].Title + '</h3><br /><h4>'
                    output += blogs[i].Category.CategoryType + '</h4><br />'
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
    $('#details').show();
    $('#BlogsArea').hide();
    $.ajax({
        url: 'http://localhost:8080/blog/' + id,
        type: 'GET',
        success: function (blog) {
            var output = "";
            var i = 0;
            output += '<div class="col-xs-offset-2 col-xs-8 detailDiv"><h2>' + blog.Title
            output += '</h2 ><h4>' + blog.Category.CategoryType
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