
$(document).ready(function () {
    UpdateSearchHistory();

    document.querySelector('.toggle-button').addEventListener('click', function () {
        ToggleSide()
        $('')
    });
    $('body').delegate('.btn-searchInfo', 'click', function () {
        var str = $(this).prev().val();
        if (str == null || str.trim() == '') {

            return;
        }
        AddSearchHistory(str);
        Search(str);
    })
    $('.input__form___1xihR').keypress(function (e) {
        if (e.keyCode == 13)
            $('.btn-searchInfo').click();
    })
    $('.logo').click(function () {
        location.href = '/'
    })
    $('.help-close a').click(function () {
        jQuery.axpost('../../api/Home/ExitUserLogin', '{}', function (data) {
            layer.load(1);
            window.location.href = "../../Main/Index";
        });
    });

})

function ToggleSide() {
    if ($('.public-side').css('display') == 'none') {
        $('.side1').css('display', 'block')
        $('.side2').css('display', 'none')
        $('.side3').css('display', 'none')
    } else {
        $('.side1').css('display', 'none')
        $('.side2').css('display', 'block')
        $('.side3').css('display', 'none')
    }
}

function SelectComm() {
    $('.side1').css('display', 'none')
    $('.side2').css('display', 'none')
    $('.side3').css('display', 'block')
}

function Search(str) {
    location.href = '../../commoditylist/search?stext=' + str;
}



//更新搜索历史
function UpdateSearchHistory() {

    var str = getCookie('searchHistory')
    if (str != '') {
        var arr = JSON.parse(str);
        var h = ''
        for (var i = 0; i < arr.length; i++) {
            h += '<option value="' + arr[i] + '">' + arr[i] + '</option >'
        }
        $('#history select').children().remove();
        $('#history select').append(h)
    }
    return
}

//增加搜索历史
function AddSearchHistory(str) {
    var h = getCookie('searchHistory')

    if (h == '') {
        var arr = new Array();
        arr.push(str);
        setCookie('searchHistory', JSON.stringify(arr), 365);
    }
    else {
        var arr = JSON.parse(h);
        arr = arr.reverse();
        arr.push(str);
        arr = unique1(arr);
        arr = arr.reverse();
        setCookie('searchHistory', JSON.stringify(arr), 365);
    }
}

//获取页码的所有li标签
function GetPageHtml(pages, thePage) {
    if (pages <= 5) {
        h = ''
        if (thePage == 1)
            h += '<li class="disabled"><a >< 上一页 </a></li>'
        else
            h += '<li onclick="getPrePage()"><a >< 上一页 </a></li>'

        for (var i = 1; i < pages + 1; i++) {
            if (i == thePage) {
                h += '<li class="active"><a >' + i + '</a></li>'
            }
            else
                h += '<li onclick="getPage(this)"><a >' + i + '</a></li>'
        }
        if (pages == thePage)
            h += '<li class="disabled" ><a >下一页 ></a></li>'
        else
            h += '<li onclick="getNextPage()" ><a>下一页 ></a></li>'

    } else {
        if (thePage <= 2) {
            h = ''
            if (thePage == 1)
                h += '<li class="disabled"><a >< 上一页 </a></li>'
            else
                h += '<li onclick="getPrePage()"><a >< 上一页 </a></li>'

            for (var i = 1; i < pages + 1; i++) {
                if (i == pages) {
                    h += '<li onclick=""><a>...</a></li>'
                }
                if (i <= thePage + 2 || i == pages) {
                    if (i == thePage)
                        h += '<li class="active"><a >' + i + '</a></li>'
                    else
                        h += '<li onclick="getPage(this)"><a >' + i + '</a></li>'
                }
            }

            if (pages == thePage) {

                h += '<li class="disabled" ><a >下一页 ></a></li>'
            }
            else {

                h += '<li onclick="getNextPage()" ><a>下一页 ></a></li>'
            }

        } else {
            if (thePage < 4) {
                h = ''
                if (thePage == 1)
                    h += '<li class="disabled"><a>< 上一页 </a></li>'
                else
                    h += '<li onclick="getPrePage()"><a >< 上一页 </a></li>'

                for (var i = 1; i < pages + 1; i++) {
                    if (i == pages && thePage < pages - 3) {
                        h += '<li onclick=""><a>...</a></li>'
                    }
                    if (i <= thePage + 2 && i >= thePage - 2 || i == pages) {
                        if (i == thePage)
                            h += '<li class="active"><a >' + i + '</a></li>'
                        else
                            h += '<li onclick="getPage(this)"><a >' + i + '</a></li>'
                    }
                }

                if (pages == thePage) {

                    h += '<li class="disabled" ><a >下一页 ></a></li>'
                }
                else {

                    h += '<li onclick="getNextPage()" ><a>下一页 ></a></li>'
                }

            } else {
                h = ''
                if (thePage == 1)
                    h += '<li class="disabled"><a >< 上一页 </a></li>'
                else
                    h += '<li onclick="getPrePage()"><a >< 上一页 </a></li>'

                for (var i = 1; i < pages + 1; i++) {
                    if (i == pages && thePage < pages - 3) {
                        h += '<li onclick=""><a>...</a></li>'
                    }
                    if (i <= thePage + 2 && i >= thePage - 2 || i == pages || i == 1) {
                        if (i == thePage)
                            h += '<li class="active"><a >' + i + '</a></li>'
                        else
                            h += '<li onclick="getPage(this)"><a >' + i + '</a></li>'
                    }
                    if (i == 1 && thePage > 4) {
                        h += '<li onclick=""><a>...</a></li>'
                    }
                }

                if (pages == thePage) {

                    h += '<li class="disabled" ><a >下一页 ></a></li>'
                }
                else {

                    h += '<li onclick="getNextPage()" ><a>下一页 ></a></li>'
                }

            }
        }
    }
    if (pages < 1) {
        return "";
    }
    return h;
}

function setCookie(c_name, value, expiredays) {
    var exdate = new Date()
    exdate.setDate(exdate.getDate() + expiredays)
    document.cookie = c_name + "=" + escape(value) +
        ((expiredays == null) ? "" : "; expires=" + exdate.toGMTString()) + "; path=/;"
}

function getCookie(c_name) {
    if (document.cookie.length > 0) {
        c_start = document.cookie.indexOf(c_name + "=")

        if (c_start != -1) {
            c_start = c_start + c_name.length + 1
            c_end = document.cookie.indexOf(";", c_start)
            if (c_end == -1) c_end = document.cookie.length
            return unescape(document.cookie.substring(c_start, c_end))
        }
    }
    return ""
}

function delCookie(name) {
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval = getCookie(name);
    if (cval != null)
        document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString() + "; path=/;";
}

// 最简单数组去重法 
function unique1(array) {
    var n = []; //一个新的临时数组 
    //遍历当前数组 
    for (var i = 0; i < array.length; i++) {
        //如果当前数组的第i已经保存进了临时数组，那么跳过， 
        //否则把当前项push到临时数组里面 
        if (n.indexOf(array[i]) == -1) n.push(array[i]);
    }
    return n;
}

$(function () {
    $('.public-text-left p').click(function () {
    })
})