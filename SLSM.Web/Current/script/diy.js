/// <reference path="home/layout.js" />
/// <reference path="ajax.js" />
/// <reference path="../../plugins/layer/layer.js" />
import { debug } from "util";


$(document).ready(function () {

    // #region 图片定制
    $('.ntab .allbox .left .imgbox img').eq(0).click(function () {
        CreateImage(0);
        layer.msg('正面定制');

    })

    $('.ntab .allbox .left .imgbox img').eq(1).click(function () {
        CreateImage(1);
        layer.msg('背面定制');

    })

    $('.ntab .allbox .rightbox1 .v2').click(function () {
        if ($('.orderalert .conbox .leftbox .bjgbox').eq(0).hasClass('active')) {
            CreateImage(0, true);
        }
        else {
            CreateImage(1, true);
        }

    })

    $('.orderalert .conbox .rightbox .bd .model.model1 .rightbox1 a').eq(0).click(function () {
        $('.orderalert').hide();
    })
    // #endregion



    //读取页面数据
    getPage();
    $('.leftbox .bjgbox i').each(function () {
        $(this).show();
    });
    $('.bjgbox img').each(function () {
        ConvertImg(this);
    });
});

// #region 图片方法
//创建图片
function CreateImage(num, hidden) {

    var width = '480';
    var height = '480';
    $('.mydiv').each(function () {
        $(this).children('div').eq(1).hide();
    });
    html2canvas(document.querySelector(".bjgbox.active")).then(function (canvas) {
        var a = Canvas2Image.convertToPNG(canvas, width, height);
        var datas = new Object();
        datas.pic = a.src;
        datas.CommodityId = $("#hidCommodityId").val();
        datas.ShopCartId = $("#hidShopCartId").val();
        $('.bjgbox img').each(function () {
            ConvertBackImg(this);
        });
        if ($('.orderalert .conbox .leftbox .bjgbox').eq(0).hasClass('active')) {
            $('.ntab .allbox .left .imgbox img').eq(0).attr('src', a.src);
            datas.div = repalceKey($('.orderalert .conbox .leftbox .bjgbox').eq(0).find('.twowords').html());
            jQuery.axadminpost('../../Api/UpImg/UpdateForntView', datas, function (data) {
                $('.ntab .allbox .left .imgbox img').eq(0).val(data.Message);
            })
        }
        else {
            $('.ntab .allbox .left .imgbox img').eq(1).attr('src', a.src);
            datas.div = repalceKey($('.orderalert .conbox .leftbox .bjgbox').eq(1).find('.twowords').html());
            jQuery.axadminpost('../../Api/UpImg/UpdateBackView', datas, function (data) {
                $('.ntab .allbox .left .imgbox img').eq(1).val(data.Message);
            })
        }
        if (num == 0) {
            $('.orderalert .conbox .leftbox .bjgbox').eq(0).addClass('active');
            $('.orderalert .conbox .leftbox .bjgbox').eq(1).removeClass('active');
        }
        else if (num == 1) {
            $('.orderalert .conbox .leftbox .bjgbox').eq(1).addClass('active');
            $('.orderalert .conbox .leftbox .bjgbox').eq(0).removeClass('active');
        }

        $('.leftbox .bjgbox i').each(function () {
            $(this).show();
        });
        if (hidden == true) {
            $('.orderalert').hide();
        }
        $('.bjgbox img').each(function () {
            ConvertImg(this);
        });
    });
}
//转换图片成base64
function ConvertImg(img) {
    if ($(img).val() != null && $(img).val() != undefined && $(img).val() != "" && $(img).val().indexOf("data:image") != -1) {
        var data = $(img).val();
        $(img).val($(img).attr("src"));
        $(img).attr("src", data);
    }
    else {
        var image = new Image();
        image.crossOrigin = 'Anonymous';
        image.src = $(img).attr("src");
        image.onload = function () {
            var canvas = document.createElement("canvas");
            canvas.width = image.width;
            canvas.height = image.height;
            var ctx = canvas.getContext("2d");
            ctx.drawImage(image, 0, 0, image.width, image.height);
            var ext = image.src.substring(image.src.lastIndexOf(".") + 1).toLowerCase();
            var dataURL = canvas.toDataURL("image/" + ext);
            $(img).attr("src", dataURL);
            $(img).val(image.src);
        }
        $(img).load();
    }
}
//把图片转换回来
function ConvertBackImg(img) {
    var src = $(img).val();
    $(img).val($(img).attr("src"));
    $(img).attr("src", src);
}
// #endregion

// #region 省份方法

//省份开始
$(function () {
    GetData($("#province"), 'province', '');
    province();
    $("#province").bind("change", function () {
        $('#area').find("option:gt(0)").remove();
        if ($("#province").val() != '-1') {
            GetData($("#city"), "city", $("#province").val());
        }
    });

    $("#city").bind("change", function () {
        if ($("#city").val() != '-1') {
            GetData($("#area"), "area", $("#city").val());
        }
    });

    $("#div1 select").change(function () {
        $(this).next('input[type=hidden]').val($(this).val());
    });

});

function GetData(sel, Level, Name) {
    sel.find("option:gt(0)").remove();
    $.ajax({
        type: "post",
        url: "../../Api/Home/GetProvinceInfo",
        contentType: "application/x-www-form-urlencoded;charset=UTF-8",
        data: "Level=" + Level + "&AreaName=" + Name,
        datatype: "json",
        async: false,
        success: function (data) {
            var json = eval(data);
            if (!json) return;
            $.each(json, function (i, n) {
                sel.append($("<option value='" + n.name + "'>" + n.name + "</option>"));
            });
        },
        error: function (e, x) {
            alert(e.responseText);
        }
    });
}

var province = function () {
    if ($("#hidProvince").val() != '') {
        setTimeout(function () { $("#province").val($("#hidProvince").val()); }, 1);
        setTimeout(function () { $("#province").change(); }, 1);
    }
    if ($("#hidCity").val() != '' && $("#city").val() == '-1') {
        setTimeout(function () { $("#city").val($("#hidCity").val()); }, 1);
        setTimeout(function () { $("#city").change(); }, 1);
    }

    if ($("#hidArea").val() != '' && $("#area").val() == '-1') {
        setTimeout(function () { $("#area").val($("#hidArea").val()); }, 1);
        setTimeout(function () { $("#area").change(); }, 1);
    }

};
//省份结束

function ToProductInfo() {
    $("html, body").animate({
        scrollTop: $(".proinfor").offset().top
    }, { duration: 500, easing: "swing" });
    return false;
}

// #endregion

// #region 分页方法
//获得页面
function getPage(page) {
    var obj = new Object();
    if (page == null || page == undefined) {
        obj.PageNo = 1;
    }
    else if (!isNaN(page)) {
        obj.PageNo = page;
    }
    else {
        obj.PageNo = $(page).children('a')[0].innerText;
    }
    var select = $("#OrderBySelect").val();
    if (select == "EvaluateId" || select == "" || select == undefined) {
        obj.OrderBy = "EvaluateId";
        obj.Desc = false;
    }
    else if (select == "CreateTime") {
        obj.OrderBy = "CreateTime";
        obj.Desc = true;
    }
    else if (select == "Start") {
        obj.OrderBy = "Start";
        obj.Desc = true;
    }
    var adminurl = $("#HiddenAdminUrl").val();
    obj.PageSize = 5;
    obj.CommodityId = $('#hidCommodityId').val();
    jQuery.axpost('../../Api/Evaluate/EvaluateByPage', JSON.stringify(obj), function (data) {
        var List = data.ListData;
        var OutString = "";
        for (var i = 0; i < List.length; i++) {
            OutString = OutString + '<li>\
                            <div class="s1">\
                                <div class="name">\
                                    '+ List[i].Name + '\
                                </div >\
                                <div class="time">\
                                    '+ List[i].CreateTime + '\
                                </div>\
                            </div >\
                            <div class="s2">\
                                <div class="words">\
                                    '+ List[i].Content + '\
                                </div>\
                            <div class="imglist">\
                                <dl>';
            if (List[i].ImageList != null && List[i].ImageList != undefined) {
                var arryList = List[i].ImageList.split('|');
                for (var j = 0; j < arryList.length; j++) {
                    OutString = OutString + '\
                                    <dd>\
                                        <img src="'+ adminurl + arryList[j] + '" alt="" />\
                                    </dd>\
                                    ';
                }
            }
            OutString = OutString + '\
                                    </dl >\
                                </div >\
                            </div >\
                        </li >\
                        ';
        }
        $('.propj .pllist ul').html(OutString);
        if (page == null || page == undefined) {
            getPageCount(1);
        }
        else if (!isNaN(page)) {
            getPageCount(page);
        }
        else {
            getPageCount(parseInt($(page).children('a')[0].innerText));
        }

    });
}
//获得后一页
function getNextPage() {
    var CurrentPage = parseInt($('.propj .pagesize1 ul .active a')[0].innerText);
    var count = parseInt($('#hiddPageCount').val());
    if (CurrentPage < count) {
        getPageCount(CurrentPage + 1);
        getPage(CurrentPage + 1);
    }
}
//获得前一页
function getPrePage() {
    var CurrentPage = parseInt($('.propj .pagesize1 ul .active a')[0].innerText);
    if (CurrentPage > 1) {
        getPageCount(CurrentPage - 1);
        getPage(CurrentPage - 1);
    }
}
//设置当前页
function getPageCount(NowPage) {
    //设置页码
    var count = parseInt($('#hiddPageCount').val());
    $('.propj .pagesize1 ul').html(GetPageHtml(count, NowPage));
}
//如果改变排序方式回到第一页
function selectChange() {
    getPage(1);
}
//分页结束
// #endregion

//用户是否收藏
function UserLikeFunc() {
    if ($('#hidIsLike').val() == null || $('#hidIsLike').val() == undefined || $('#hidIsLike').val() == "") {
        layer.msg("请用户先登入！");
    }
    else {
        var obj = new Object();
        obj.CommodityId = $('#hidCommodityId').val();
        obj.IsLike = $('#hidIsLike').val() == "true" ? false : true;
        jQuery.axpost('../../Api/User/UserLike', JSON.stringify(obj), function (data) {
            $('#hidIsLike').val(obj.IsLike);
            if (obj.IsLike) {
                $('.sc a img').attr('src', '../../../../base/images/heat2.png')
            }
            else {
                $('.sc a img').attr('src', '../../../../base/images/heat.png')
            }
            layer.msg(data.Message);
        });
    }

}
