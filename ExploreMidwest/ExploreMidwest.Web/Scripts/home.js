var num = 5;
var set = 0;

$(document).ready(function () {
    $('.detailDiv').hide();
    set = 0;
    loadData();
});

function loadData() {
    getNumber(num, set);
}

function getNumber(number, sets){
    $.ajax({
        url: 'http://localhost:8080/blogs/' + number + '/' + sets,
        type: 'GET',
        success: function (blogs) {
            var output = "";
            var i = 0;

            for (i; i < blogs.length; i++) {
                if (blogs[i].IsFinished) {
                    output += '<div class="col-xs-9 blogDiv"><div class="col-xs-3 innerDiv"><h3>'
                    output += blogs[i].Title + '</h3><br /><h4>'
                    output += blogs[i].Category.CategoryType + '</h4><br />'
                    output += blogs[i].Date + '</div>'
                    output += '<div class="col-xs-9 innerDiv">'
                    output += blogs[i].Body
                    output += '<div style="text-align:end"><a href="#" id="det1">Read full article</a></div></div></div>'
                }
            }
            $('#BlogsArea').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {
            $('#outputMessage').val("Error no products found!");
        }
    })
}