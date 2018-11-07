/// <reference path="../ajax.js" />

//$(function () {
//    GetHotGrade();
//});

//function onload() {
//    GetGrade1();
//    GetHotGrade();

//}

function test3() {
    GetList();
}

$(document).ready(function () {
    UpdateSearchHistory();
    $('.basehead .navlist .slidedown .down .list .sli').hover(function () {
        $(this).find('.sibox').stop()
        $(this).find('.sibox').fadeToggle(200)
    })

    //产品定制的一级标签鼠标悬浮效果
    $('body').delegate('.basehead .navlist .slidedown .down .list .sli', 'mouseenter mouseleave', function () {
        $(this).find('.sibox').stop()
        $(this).find('.sibox').fadeToggle(200)
    })

    $('.top-part .second-line .right-part img').click(function () {
        var str = $('.top-part .second-line .right-part .search-input').val();
        if (str == null || str == "") {
            return;
        }
        AddSearchHistory(str);
        location.href = '/commoditylist/search?stext=' + str;
    })
    $('body').delegate('.top-part .second-line .right-part .search-input', 'keyup', function (e) {
        if (e.keyCode == 13)
            $('.top-part .second-line .right-part img').click();
    })

    $('#ExitH2').click(function () {
        
        jQuery.axpost('../../api/Home/ExitUserLogin', '{}', function (data) {
            
            window.event.returnValue = false;
            if (window.event.preventDefault)
                window.event.preventDefault();
            window.location.href = "../../Main/Index";
        });
    })


})

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

//更新搜索历史
function UpdateSearchHistory() {

    var str = getCookie('searchHistory')
    if (str != '') {
        var arr = JSON.parse(str);
        var h = ''
        for (var i = 0; i < arr.length; i++) {
            h += '<option value="' + arr[i] + '"></option >'
        }
        $('#history').children().remove();
        $('#history').append(h)
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
        document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString();
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

function SendPhoneCode() {
    var obj = new Object();
    obj.UserPhone = $('#PhoneNumber').val();
    obj.ImageCode = $('#ImageCode').val();
    if (obj.ImageCode == null || obj.ImageCode == "" || obj.ImageCode == undefined) {
        layer.msg("请填写图片验证码！");
    }
    jQuery.axpost('../../api/Home/SendPhoneCode', JSON.stringify(obj), function (data) {
        layer.msg(data.Message);
    });
}

function SendRegPhoneCode() {
    var obj = new Object();
    obj.UserPhone = $('#RegPhoneNumber').val();
    obj.IsThild = true;
    jQuery.axpost('../../api/Home/SendPhoneCode', JSON.stringify(obj), function (data) {
        layer.msg(data.Message);
    });
}

function LoginByPhone() {
    var obj = new Object();
    obj.UserPhone = $('#PhoneNumber').val();
    obj.PhoneCode = $('#PhoneCode').val();
    obj.Password = $('#Password').val();
    obj.ImageCode = $('#ImageCode').val();
    if ((obj.PhoneCode == null || obj.PhoneCode == "" || obj.PhoneCode == undefined) && (obj.Password == null || obj.Password == "" || obj.Password == undefined)) {
        layer.msg("请填写密码或手机验证码！");
        return;
    }
    jQuery.axpost('../../api/Home/LoginByPhone', JSON.stringify(obj), function (data) {
        layer.msg(data.Message);
        $('.loginalert').hide();
        window.location.reload();
    });
}

function LoginByWechat() {
    var obj = new Object();
    obj.UserPhone = $('#RegPhoneNumber').val();
    obj.PhoneCode = $('#RegPhoneCode').val();
    obj.IsThild = true;
    obj.openWechatid = $('#openWechatid').val();
    obj.accessToken = $('#accessToken').val();
    if ((obj.PhoneCode == null || obj.PhoneCode == "" || obj.PhoneCode == undefined)) {
        layer.msg("请填写手机验证码！");
        return;
    }
    jQuery.axpost('../../api/Home/LoginByPhone', JSON.stringify(obj), function (data) {
        layer.msg(data.Message);
        $('.loginalert').hide();
        window.location.reload();
    });
}

function AccountExist() {
    var obj = new Object();
    obj.UserPhone = $('#PhoneNumber').val();
    jQuery.axpost('../../api/Home/GetUserAccount', JSON.stringify(obj), function (data) {
        if (data.Message == "没有此用户请验证码登入！") {
            layer.msg("没有此用户请验证码登入！");
            $('input[name="LoginType"]').eq(1).attr("disabled", true);
            $('input[name="LoginType"]:first').get(0).checked = true;
            $('#Password').val("");
            $('#PhoneCode').attr('disabled', false);
            $('.loginalert  .box .model .s2 .s3').attr('disabled', false);
            $('#Password').attr('disabled', true);

        }
    });
}

$(function () {
    $('input[name="LoginType"]').click(function () {
        if ($('input[name="LoginType"]:checked').val() == "password") {
            if ($('#PhoneNumber').val() == null || $('#PhoneNumber').val() == "" || $('#PhoneNumber').val().length != 11) {
                layer.msg("请输入正确手机号码！");
                
                $('input[name="LoginType"]:first').get(0).checked = true;
                $('#Password').val("");
                $('#PhoneCode').attr('disabled', false);
                $('.loginalert  .box .model .s2 .s3').attr('disabled', false);
                $('#Password').attr('disabled', true);
                return;
            }
            $('#PhoneCode').val("");
            $('#PhoneCode').attr('disabled', true);
            $('.loginalert .box .model .s2 .s3').attr('disabled', true);
            $('#Password').attr('disabled', false);
            AccountExist();
        }
        else if ($('input[name="LoginType"]:checked').val() == "phone") {
            $('#Password').val("");
            $('#PhoneCode').attr('disabled', false);
            $('.loginalert  .box .model .s2 .s3').attr('disabled', false);
            $('#Password').attr('disabled', true);

        }
    });

    $('#PhoneNumber').change(function () {
        $('input[name="LoginType"]').eq(1).attr("disabled", false);
        if ($('input[name="LoginType"]:checked').val() == "password") {
            $('input[name="LoginType"]').eq(1).trigger('click');
        }
    })
})


// #region 隐藏购物车
function HiddenCart() {
    $('.basehead .head .search .shopbtn .slidedownlist').css("display", "none");
}
// #endregion