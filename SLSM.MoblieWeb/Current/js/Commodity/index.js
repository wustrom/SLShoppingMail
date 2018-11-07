$(function () {
    $('.customized-body img').each(function () {
        ConvertImg(this);
    });
});

var swiper = new Swiper('.swiper-container2', {
    pagination: {
        el: '.swiper-pagination',
        clickable: true,
        renderBullet: function (index, className) {
            return '<li class="' + className + '"><button>' + (index + 1) + '</button></li>';
        },
    },
});


$(function () {
    $('.liucheng .d1 dd a').click(function () {
        $(this).addClass('on').siblings().removeClass('on');
    });
    $('.liucheng .d3 a').click(function () {
        $(this).addClass('on').siblings().removeClass('on');
    });
    $('.shuliang li').click(function () {
        $(this).addClass('on').siblings().removeClass('on');
    });
});

$(function () {
    //阶梯价
    $('.variant__col-2___yF1uV .words').change(function () {
        StagePrice();
        var nowNum = parseInt($(this).val());
        if (nowNum == NaN || nowNum < 1) {
            layer.msg('请输入大于0的整数！');
            $(this).val(1);
        }
        var nowprice = $('#NowPrice').html();
        $(".shuliang li").each(function () {
            var titleNum = parseInt($(this).children('h5')[0].innerText);
            if (titleNum == NaN) {
                titleNum = 0;
            }
            var titlePrice = $(this).find('p label')[0].innerHTML;
            if (parseFloat(titlePrice) == parseFloat(nowprice) && nowNum >= titleNum) {
                $('.shuliang li').removeClass('on');
                $(this).addClass('on');
            }
        });
    })

    $('.shuliang li').click(function () {
        var text = $(this).children('h5')[0].innerText;
        $('.shuliang li').removeClass('on');
        if (!isNaN(text)) {
            $('.variant__col-2___yF1uV .words').val(parseInt(text));
        }
        else {
            $('.variant__col-2___yF1uV .words').val(1);
        }
        $(this).addClass('on');
        StagePrice();
    })
    //阶梯价
    function StagePrice() {
        var num = $('.variant__col-2___yF1uV .words').val();
        var titleNum = 0;
        var titleNumPrice = 0;
        if (isNaN(num)) {
            layer.msg("请输入数字！");
        }
        else {
            var IntNum = parseInt(num);
            $(".shuliang li").each(function () {
                var titleMoney = $(this).children('h5')[0].innerText;
                var titlePrice = $(this).find('p label')[0].innerHTML;
                if (!isNaN(titleMoney) && parseInt(titleMoney) < IntNum + 1) {
                    if (titleNum < parseInt(titleMoney)) {
                        titleNum = parseInt(titleMoney);
                        titleNumPrice = parseFloat(titlePrice);
                    }
                }
                else if (isNaN(titleMoney)) {
                    if (titleNum == 0) {
                        titleNum = 0;
                        titleNumPrice = parseFloat(titlePrice);
                    }
                }
            });
        }
        if (titleNumPrice != 0 && titleNumPrice != undefined) {
            var IntNum = parseInt(num);
            $('#NowPrice').html(titleNumPrice);
            if (discount != null && discount != undefined && discount != "") {
                var discount = parseFloat($('#discount').val());
                $('#MemPrice').val((titleNumPrice * discount).toFixed(2));
                $('#TotalPrice').html((titleNumPrice * IntNum * discount).toFixed(2));
            }
            else {
                $('#MemPrice').val((titleNumPrice).toFixed(2));
                $('#TotalPrice').html((titleNumPrice * IntNum).toFixed(2));
            }
        }
    }
    getPageCount(1);
    getPage();
    $('.variant__col-2___yF1uV .words').trigger('change');
})

//省份开始
$(function () {
    GetData($("#province"), 'province', '');
    province();
    $("#province").bind("change", function () {
        $('#area').find("option:gt(0)").remove();
        $('#city').find("option:gt(0)").remove();
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
        url: "../../Api/Address/GetProvinceInfo",
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

function ToProductInfo() {
    $("html, body").animate({
        scrollTop: $(".cptwxq").offset().top
    }, { duration: 500, easing: "swing" });
    return false;
}

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
    obj.OrderBy = "EvaluateId";
    obj.Desc = false;
    var adminurl = $("#HiddenAdminUrl").val();
    obj.PageSize = 5;
    obj.CommodityId = $('#hidCommodityId').val();
    jQuery.axpost('../../Api/Evaluate/EvaluateByPage', JSON.stringify(obj), function (data) {
        var List = data.ListData;
        var OutString = "";
        for (var i = 0; i < List.length; i++) {
            OutString = OutString + '<li>\
                                        <h3><span>'+ List[i].Name + '</span> <i>' + List[i].CreateTime + '</i></h3 >\
                                        <div class="pl">'+ List[i].Content + '</div>\
                                        <div class="clearfix img">';
            if (List[i].ImageList != null && List[i].ImageList != undefined) {
                var arryList = List[i].ImageList.split('|');
                for (var j = 0; j < arryList.length; j++) {
                    OutString = OutString + '\
                                                <img src="'+ adminurl + arryList[j] + '" alt="" />\
                                            ';
                }
            }
            OutString = OutString + '</div>\
                                   </li >\
                                    ';
        }
        $('.yhpl ul').html(OutString);
        if (page == null || page == undefined) {
            getPageCount(1);
        }
        else {
            getPageCount(parseInt($(page).children('a')[0].innerText));
        }
    });
}

//获得后一页
function getNextPage() {
    var CurrentPage = parseInt($('.plfy .fr .active a')[0].innerText);
    var count = parseInt($('#hiddPageCount').val());
    if (CurrentPage < 10) {
        getPageCount(CurrentPage + 1);
        getPage(CurrentPage + 1);
    }
}

//获得前一页
function getPrePage() {
    var CurrentPage = parseInt($('.plfy .fr .active a')[0].innerText);
    if (CurrentPage > 1) {
        getPageCount(CurrentPage - 1);
        getPage(CurrentPage - 1);
    }
}

//设置当前页
function getPageCount(NowPage) {
    //设置页码
    var count = parseInt($('#hiddPageCount').val());
    $('.plfy .fr').html(GetPageHtml(count, NowPage));
}


// #region 购物车方法

function ShopCartFunc() {

    var datas = new Object();
    datas.CommodityId = $('#hidCommodityId').val();
    var num = $(".variant__col-2___yF1uV .words").val();
    if (isNaN(num) || num == "") {
        layer.msg("请输入购买数量，不能含字母！");
        return;
    }
    datas.Amount = num;
    $('ul.variant__list-inline___2xLNP li').each(function () {
        if ($(this).hasClass('variant__active___pNFYa')) {
            datas.Color = $(this).find('i').html().trim();
        }
    })
    datas.ShopCartId = $("#hidShopCartId").val();
    datas.PayType = "moblie";
    datas.PrintingMethod = $(".variant__col-2___yF1uV .radio input[type='radio']:checked").val();
    debugger;
    jQuery.axadminpost('../../Api/UpImg/AddCartFunc', datas, function (data) {
        //layer.confirm('是否前往购物车页面？', {
        //    closeBtn: 0,
        //    btn: ['是', '否'] //按钮
        //}, function () {
        window.location.href = "/../../ShopCart/Index";
        //}, function () {
        //    window.location.reload();
        //});

    });
}

function BuyImmediately() {

    var datas = new Object();
    datas.CommodityId = $('#hidCommodityId').val();
    var num = $(".variant__col-2___yF1uV .words").val();
    if (isNaN(num) || num == "") {
        layer.msg("请输入购买数量，不能含字母！");
        return;
    }
    datas.Amount = num;
    $('ul.variant__list-inline___2xLNP li').each(function () {
        if ($(this).hasClass('variant__active___pNFYa')) {
            datas.Color = $(this).find('i').html().trim();
        }
    })
    datas.ShopCartId = $("#hidShopCartId").val();
    datas.PayType = "moblie";
    datas.PrintingMethod = $(".variant__col-2___yF1uV .radio input[type='radio']:checked").val();
    //layer.confirm('是否立即购买？', {
    //    closeBtn: 0,
    //    btn: ['是', '否'] //按钮
    //}, function () {
    debugger;
    jQuery.axadminpost('../../Api/UpImg/AddCartFunc', datas, function (data) {
        window.location.href = "/../../PayPage/Index?ShopCartId=" + data.Message;
    });
    //}, function () {

    //});

}

//替换所有html的特殊符号
function repalceKey(str) {
    str = str.replace(/'/g, "Single_quotation&marks");
    str = str.replace(/\"/g, 'Double_quotation&marks');
    str = str.replace(/\\/g, 'BackSlash&marks');
    return str;
}
// #endregion

// #region 页面切换
function StartDiy() {
    $('.DiyProduct').hide();
    $('.DiyConetnt').show();

}

function OpenMain() {
    $('.DiyProduct').show();
    $('.DiyConetnt').hide();
    $('.DiyAddWord').hide();
    $('.DiyImageList').hide();
    $('.DiyAddImage').hide();
    $('.DiyMain').show();

}

function bodyScroll(event) {
    event.preventDefault();
};

function AddWord() {
    $('.DiyAddWord').show();
    $('.DiyImageList').hide();
    $('.DiyAddImage').hide();
    $('.DiyMain').hide();
}

function UpdateImage() {
    $('.DiyAddWord').hide();
    $('.DiyImageList').hide();
    $('.DiyAddImage').show();
    $('.DiyMain').hide();
}

function OnLineImage() {
    $('.DiyAddWord').hide();
    $('.DiyImageList').show();
    $('.DiyAddImage').hide();
    $('.DiyMain').hide();
}

function DiyClick() {
    $('.DiyAddWord').hide();
    $('.DiyImageList').hide();
    $('.DiyAddImage').hide();
    $('.DiyMain').show();

}
// #endregion

// #region 定制
$(function () {
    $('.customized-option .btn').eq(0).click(function () {
        CreateImage(0);
    });
    $('.customized-option .btn').eq(1).click(function () {
        CreateImage(1);
    });
})
// #endregion

// #region 定制内按钮
var buttonContent = '<em class="fangda">\
    <svg class="icon" viewBox= "0 0 1024 1024" version= "1.1" xmlns= "http://www.w3.org/2000/svg" p- id="4300" > <path d="M79.069 65.734c-3.917 0.044-7.835 1.532-10.81 4.552-2.998 2.976-4.486 6.914-4.486 10.853l0.152 318.693a5.164 5.164 0 0 0 3.152 4.727c1.97 0.788 4.158 0.306 5.58-1.138L180.39 296.198l144.44 143.81c2.756 2.757 6.608 4.464 10.853 4.464 4.2 0 8.052-1.707 10.81-4.464l98.08-97.638c2.8-2.757 4.507-6.609 4.507-10.898 0-4.244-1.707-8.096-4.508-10.897l-144.34-143.723L404.919 72.605c1.444-1.4 1.926-3.59 1.094-5.602-0.788-1.969-2.714-3.15-4.726-3.15L79.069 65.733z m0.11 894.414c-3.94 0.044-7.878-1.488-10.877-4.464a15.359 15.359 0 0 1-4.529-10.896l0.152-321.363c0-2.013 1.182-3.939 3.152-4.726 1.97-0.832 4.158-0.307 5.58 1.094L180.39 727.059l144.44-143.853c2.756-2.757 6.608-4.464 10.853-4.464 4.2 0 8.052 1.707 10.81 4.464l98.08 97.637c2.8 2.801 4.507 6.653 4.507 10.898s-1.707 8.14-4.508 10.897L300.231 846.36l104.776 104.334a5.181 5.181 0 0 1 1.138 5.603c-0.832 1.969-2.714 3.15-4.726 3.195l-322.24 0.656zM944.906 65.734c3.94 0.044 7.834 1.532 10.81 4.552 3.02 2.976 4.508 6.914 4.508 10.853l-0.175 318.693a5.164 5.164 0 0 1-3.152 4.727c-1.969 0.788-4.158 0.306-5.558-1.138L843.59 296.197l-144.43 143.81c-2.8 2.757-6.608 4.464-10.853 4.464s-8.053-1.707-10.854-4.464l-98.036-97.638c-2.801-2.757-4.508-6.609-4.508-10.898 0-4.244 1.707-8.096 4.508-10.853L723.8 176.852 619.068 72.605c-1.445-1.4-1.926-3.59-1.094-5.602 0.788-1.969 2.713-3.15 4.727-3.15l322.206 1.881z m-0.088 894.414c3.94 0.044 7.878-1.488 10.854-4.464 3.02-3.019 4.552-6.958 4.552-10.896l-0.175-321.363c0-2.013-1.182-3.939-3.152-4.726-1.969-0.832-4.158-0.307-5.558 1.094L843.59 727.058l-144.43-143.853c-2.8-2.757-6.608-4.464-10.853-4.464s-8.053 1.707-10.854 4.464l-98.036 97.637c-2.801 2.801-4.508 6.653-4.508 10.898s1.707 8.14 4.508 10.897L723.8 846.359 618.98 950.694a5.183 5.183 0 0 0-1.139 5.603c0.832 1.969 2.714 3.15 4.727 3.195l322.25 0.656z" p-id="4301"></path></svg >\
                        </em >\
    <em class="delete">\
        <svg class="icon" viewBox="0 0 1024 1024" version="1.1" xmlns="http://www.w3.org/2000/svg" p-id="2477"><path d="M512.625752 61.5928c-247.332085 0-447.833585 200.502523-447.833585 447.833585 0 247.331062 200.502523 447.832562 447.833585 447.832562 247.331062 0 447.832562-200.5015 447.832562-447.832562S759.956813 61.5928 512.625752 61.5928zM356.794637 742.478232l-72.894194-72.454172 159.40143-160.369477L282.932396 350.253152l72.454172-72.894194 160.370501 159.40143 159.40143-160.369477 72.894194 72.455195L588.651262 509.214561l160.370501 159.402453-72.455195 72.895217L516.19709 582.110801 356.794637 742.478232z" p-id="2478"></path></svg>\
    </em>\
    <em class="rotate">\
        <svg class="icon" viewBox="0 0 1024 1024" version="1.1" xmlns="http://www.w3.org/2000/svg" p-id="2941"><path d="M941.728 137.152C941.728 122.304 932.576 109.152 919.456 103.424 905.728 97.728 889.728 100.576 879.456 111.424L805.152 185.152C724.576 109.152 615.456 64 502.88 64 261.152 64 64 261.152 64 502.88 64 744.576 261.152 941.728 502.88 941.728 633.728 941.728 757.152 884 840.576 783.424 846.304 776 846.304 765.152 839.456 758.88L761.152 680C757.152 676.576 752 674.88 746.88 674.88 741.728 675.424 736.576 677.728 733.728 681.728 677.728 754.304 593.728 795.424 502.88 795.424 341.728 795.424 210.304 664 210.304 502.88 210.304 341.728 341.728 210.304 502.88 210.304 577.728 210.304 648.576 238.88 702.304 288.576L623.456 367.424C612.576 377.728 609.728 393.728 615.456 406.88 621.152 420.576 634.304 429.728 649.152 429.728L905.152 429.728C925.152 429.728 941.728 413.152 941.728 393.152L941.728 137.152Z" p-id="2942"></path></svg>\
    </em>';
function BindAll() {
    $(".customized-body").unbind();
    DropFunction();
    FangdaFunction();
    RotateFunction();
    $('.page-class-box .list-box dt').unbind();
    $('.page-class-box .list-box dt').click(function () {
        $(this).parent().find('dd').toggle();
    });
    $(".kedingzhi .delete").unbind();
    $(".kedingzhi .delete").click(function () {
        $(this).parent("div").parent('section').remove();
    });
    $(".kedingzhi .delete").on('touchstart', function (e) {
        var _touch = e.originalEvent.targetTouches[0];
        $(this).parent("div").parent('section').remove();
    });
}

function DropFunction() {
    var oldX = null;
    var oldY = null;
    var w = null;
    var h = null;
    var isdown = false;
    $(".kedingzhi span,.kedingzhi img").unbind();
    $(".kedingzhi span,.kedingzhi img").on('touchstart', function (e) {
        var _touch = e.originalEvent.targetTouches[0];
        isdown = true;
        _this = $(this).parents("section.xuanzhuan");
        w = _this.width();
        h = _this.height();

    });
    $(".customized-body").on('touchmove', function (e) {
        e.preventDefault();
        var _touch = e.originalEvent.targetTouches[0];
        var newX = _touch.pageX - w / 2;
        var newY = _touch.pageY - h / 2;
        if (isdown) {
            _this.css({ "position": "fixed", "left": newX, "top": newY });
        }
    });
    $(".customized-body").on('touchend', function (e) {
        isdown = false;
    });
}

function FangdaFunction() {
    var isdown = false;
    var isfirst = true;
    var oldX = null;
    var oldY = null;
    var w = null;
    var h = null;
    var w_b = null;
    var h_b = null;
    var _this = null;
    $(".kedingzhi .fangda").unbind();
    $(".kedingzhi .fangda").on('touchstart', function (e) {
        var _touch = e.originalEvent.targetTouches[0];
        isdown = true;
        _this = $(this).parents("section.xuanzhuan");
        if (isfirst) {
            w = _this.width();
            h = _this.height();
            console.log(w, h);
            oldX = _touch.pageX + w / 2;
        }
        oldY = _touch.pageY + h / 2;
        w_b = _this.width();
        h_b = _this.height();
        if (w == null || h == null) {
            isfirst = true;
        } else {
            isfirst = false;
        };
        console.log(oldX, oldY);
    });
    $(".customized-body").on('touchmove', function (e) {
        e.preventDefault();
        var _touch = e.originalEvent.targetTouches[0];
        var newX = _touch.pageX;
        var newY = _touch.pageY;
        var a = newX - oldX;
        var b = newY - oldY;
        var cx = Math.sqrt(a * a + b * b);
        var dx = Math.sqrt(w * w + h * h) / 2;
        //			console.log(cx,dx);
        var j = Math.sin(b / dx) * 100;
        j = parseInt(j);
        //			console.log(j);
        var b = cx / dx;
        //			console.log(oldX,oldY,newX,newY);
        //			console.log(b);
        var y = _touch.pageY - oldY;
        if (b < 0.8) {
            b = 0.8;
        };
        if (isdown) {
            _this.css({ "transform": "scale(" + b + "," + b + ")" });
        };
    });
    $(".customized-body").on('touchend', function (e) {
        isdown = false;
    });
}

function RotateFunction() {
    var isdown = false;
    var isfirst = true;
    var oldX = null;
    var oldY = null;
    var w = null;
    var h = null;
    var w_b = null;
    var h_b = null;
    var _this = null;
    $(".kedingzhi .rotate").unbind();
    $(".kedingzhi .rotate").on('touchstart', function (e) {
        var _touch = e.originalEvent.targetTouches[0];
        isdown = true;
        _this = $(this).parent("div");
        if (isfirst) {
            w = _this.width();
            h = _this.height();
            //  			console.log(w,h);
            oldX = _touch.pageX - w / 2;
        }
        oldY = _touch.pageY - h / 2;
        w_b = _this.width();
        h_b = _this.height();
        if (w == null || h == null) {
            isfirst = true;
        } else {
            isfirst = false;
        };
        //  		console.log(oldX,oldY);
    });
    $(".customized-body").on('touchmove', function (e) {
        e.preventDefault();
        var _touch = e.originalEvent.targetTouches[0];
        var newX = _touch.pageX;
        var newY = _touch.pageY;
        var a = newX - oldX;
        var b = newY - oldY;
        var cx = Math.sqrt(a * a + b * b);
        var dx = Math.sqrt(w * w + h * h) / 2;
        //			console.log(cx,dx);
        var j = Math.sin(b / dx) * 100;
        j = parseInt(j);
        //			console.log(j);
        var b = cx / dx;
        //			console.log(oldX,oldY,newX,newY);
        //			console.log(b);
        var y = _touch.pageY - oldY;
        if (b < 0.8) {
            b = 0.8;
        };
        if (isdown) {
            _this.css({ "transform": "rotate(" + y + "deg)" });
        };
    });
    $(".customized-body").on('touchend', function (e) {
        isdown = false;
    });
}

$(function () {
    BindAll();
});

// #endregion

// #region 定制添加
//文字添加
function AddFullWord() {
    var text = $('.customized-text textarea').val();
    if (text == null || text == "" || text == undefined) {
        layer.msg("请输入定制文字");
        return;
    }
    $('.customized-body.active .kedingzhi .wordBox').append('<section class="xuanzhuan text">\
        <div class= "big_box" >\
            <span style="font-size:'+ $('select[name="font_size"] option:selected').html() + 'px;font-family:' +
        $('select[name="font_style"] option:selected').html() + ';color:' + $('select[name="font_color"] option:selected').val() + '">' +
        text + '</span>' + buttonContent + '</div >\
       </section > ');
    BindAll();
    DiyClick();
}

$(function () {

    $('.my_custom li').click(function () {
        $(this).find("em").toggleClass('on');
    });

    //在线图库添加
    $('.bc_yl.fudong-foot').click(function () {
        var i = $('.DiyImageList .my_custom em.on').length;
        if (i == 0) {
            $('.tsk_bg').show();
            $('.tsk_bg').click(function () {
                $(this).hide();
            });
        } else {
            $('.customized-body.active img').each(function () {
                ConvertBackImg(this);
            });
            $('.DiyImageList .my_custom ul li em.on').each(function () {
                $(this).parent().find('img').attr('src');
                $('.customized-body.active .kedingzhi .ImageList').append('<section class="xuanzhuan image">\
                <div class="big_box">\
                    <img src="'+ $(this).parent().find('img').attr('src') + '" alt="" />' + buttonContent + '</div >\
            </section > ');
            })
            BindAll();
            DiyClick();
            $('.customized-body.active img').each(function () {
                ConvertImg(this);
            });
        }

    })
    //上传图片添加
    $('.bcbyl').click(function () {
        var i = $('.DiyAddImage .my_custom em.on').length;
        if (i == 0) {
            $('.tsk_bg').show();
            $('.tsk_bg').click(function () {
                $(this).hide();
            });
        }
        else {
            $('.customized-body.active img').each(function () {
                ConvertBackImg(this);
            });
            $('.DiyAddImage .my_custom ul li em.on').each(function () {
                $(this).parent().find('img').attr('src');
                $('.customized-body.active .kedingzhi .UpImage').append('<section class="xuanzhuan image">\
                <div class="big_box">\
                    <img src="'+ $(this).parent().find('img').attr('src') + '" alt="" />' + buttonContent + '</div >\
            </section > ');
            })
            BindAll();
            DiyClick();
            $('.customized-body.active img').each(function () {
                ConvertImg(this);
            });
        }
    });

    //图片上传
    $('.sctp.fl').change(function () {
        var file = this.files[0];
        var that = this;
        if (file.size > (2048 * 1024)) {
            layer.msg("图片不能大于2M!");
            return;
        }
        if (window.FileReader) {
            var reader = new FileReader();
            reader.readAsDataURL(file);
            //监听文件读取结束后事件    
            reader.onloadend = function (e) {
                var datas = new Object();
                var thissrc = e.target.result;
                datas.pic = thissrc;
                datas.CommodityId = $("#hidCommodityId").val();
                datas.ShopCartId = $("#hidShopCartId").val();
                //加载层-风格3
                layer.load(2);
                //此处演示关闭
                setTimeout(function () {
                    layer.closeAll('loading');
                }, 5000);
                jQuery.axadminpost('../../Api/UpImg/UpdateOrderCross', datas, function (data) {
                    $('.DiyAddImage .my_custom ul').append('<li>\
                        <em></em>\
                        <img src="'+ data.Message + '" alt="">\
                    </li>');
                    that.value = "";
                    $('.my_custom li').unbind();
                    $('.my_custom li').click(function () {
                        $(this).find("em").toggleClass('on');
                    });
                    layer.closeAll('loading');
                })
            };
        }
    })
});

function SuccessEdit() {
    if ($('.customized-body.active').eq(0).hasClass('active')) {
        CreateImage(0, true);
    }
    else {
        CreateImage(1, true);

    }
}
// #endregion

// #region 图片方法
//创建图片
function CreateImage(num, hidden) {
    //加载层-风格3
    layer.load(2);
    //此处演示关闭
    setTimeout(function () {
        layer.closeAll('loading');
    }, 5000)
    var width = $('.customized-body.active .Image')[0].width;
    var height = $('.customized-body.active .Image')[0].height;
    $('.kedingzhi section em').each(function () {
        $(this).hide();
    });
    $('.big_box').each(function () {
        $(this).css("border", "none");
    })
    html2canvas(document.querySelector(".customized-body.active")).then(function (canvas) {
        var a = Canvas2Image.convertToPNG(canvas, width, height);
        var datas = new Object();
        datas.pic = a.src;
        datas.CommodityId = $("#hidCommodityId").val();
        datas.ShopCartId = $("#hidShopCartId").val();
        $('.big_box').each(function () {
            $(this).css("border", "#000000 1px solid");
        })
        $('.customized-body.active img').each(function () {
            ConvertBackImg(this);
        });
        if ($('.customized-body').eq(0).hasClass('active')) {
            datas.div = repalceKey($('.customized-body').eq(0).find('.kedingzhi').html());
            jQuery.axadminpost('../../Api/UpImg/UpdateForntView', datas, function (data) {
                layer.closeAll('loading');
            })

        }
        else {
            datas.div = repalceKey($('.customized-body').eq(1).find('.kedingzhi').html());
            jQuery.axadminpost('../../Api/UpImg/UpdateBackView', datas, function (data) {
                layer.closeAll('loading');
            })
        }
        $('.kedingzhi section em').each(function () {
            $(this).show();
        });
        if (num == 0) {
            $('.customized-option .btn').eq(1).removeClass('active');
            $('.customized-body').eq(0).addClass('active');
            $('.customized-body').eq(1).removeClass('active');
            $('.customized-option .btn').eq(0).addClass('active');
        }
        else {
            $('.customized-option .btn').eq(0).removeClass('active');
            $('.customized-body').eq(1).addClass('active');
            $('.customized-body').eq(0).removeClass('active');
            $('.customized-option .btn').eq(1).addClass('active');
        }
        if (hidden == true) {
            OpenMain();
        }
        $('.customized-body.active img').each(function () {
            ConvertImg(this);
        });
    });
}
//转换图片成base64
function ConvertImg(img) {
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
//把图片转换回来
function ConvertBackImg(img) {
    var src = $(img).val();
    $(img).attr("src", src);
}
//替换所有html的特殊符号
function repalceKey(str) {
    str = str.replace(/'/g, "Single_quotation&marks");
    str = str.replace(/\"/g, 'Double_quotation&marks');
    str = str.replace(/\\/g, 'BackSlash&marks');
    return str;
}
// #endregion