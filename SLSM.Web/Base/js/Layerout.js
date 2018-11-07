//  #region 判断是否手机
var browser = {
    versions: function () {
        var u = navigator.userAgent, app = navigator.appVersion;
        return {//移动终端浏览器版本信息
            trident: u.indexOf('Trident') > -1, //IE内核
            presto: u.indexOf('Presto') > -1, //opera内核
            webKit: u.indexOf('AppleWebKit') > -1, //苹果、谷歌内核
            gecko: u.indexOf('Gecko') > -1 && u.indexOf('KHTML') == -1, //火狐内核
            mobile: !!u.match(/AppleWebKit.*Mobile.*/), //是否为移动终端
            ios: !!u.match(/\(i[^;]+;( U;)? CPU.+Mac OS X/), //ios终端
            android: u.indexOf('Android') > -1 || u.indexOf('Linux') > -1, //android终端或者uc浏览器
            iPhone: u.indexOf('iPhone') > -1, //是否为iPhone或者QQHD浏览器
            iPad: u.indexOf('iPad') > -1, //是否iPad
            webApp: u.indexOf('Safari') == -1 //是否web应该程序，没有头部与底部
        };
    }(),
    language: (navigator.browserLanguage || navigator.language).toLowerCase()
};
/**
 * 判断浏客户端是否为移动端
 */
function isMobile() {
    if (browser.versions.mobile || browser.versions.ios || browser.versions.android ||
        browser.versions.iPhone || browser.versions.iPad) {
        window.location.href = "http://mobile.syloon.cn";
    }
    return false;
}
isMobile();
//  #endregion
$(function () {
    //  #region 购物车显示与隐藏
    $('.top-part .first-line .right-part ul.first_ul li:first-child,.top-part .first-line .right-part .dropdown_cart').hover(function () {
        $('.top-part .first-line .right-part .dropdown_cart').stop()
        $('.top-part .first-line .right-part .dropdown_cart').toggle()
    })
    //  #endregion

    //  #region 登入信息
    $('.top-part .first-line .right-part ul.first_ul li:eq(1),.top-part .first-line .right-part .LoginInfo ul').hover(function () {
        $('.top-part .first-line .right-part .LoginInfo').stop()
        $('.top-part .first-line .right-part .LoginInfo').toggle()
    })
    //  #endregion

    //  #region 商品分类显示与隐藏
    $('.top-part .second-line .left-part ul li.commdity_type,.slidedown_list.commdity_type').hover(function () {
        var scencenum = $(".slidedown_list.commdity_type img").length;
        var scenceimg = $(".slidedown_list.commdity_type img");
        var count = 0; //存储图片加载到的位置，避免每次都从第一张图片开始遍历
        for (var i = count; i < scencenum; i++) {
            if (scenceimg[i].getAttribute("lazy_src") != "" && scenceimg[i].getAttribute("lazy_src") != undefined && (scenceimg[i].src == "" || scenceimg[i].src == undefined || scenceimg[i].src == null)) {
                scenceimg[i].src = scenceimg[i].getAttribute("lazy_src");
            }
            count = i + 1;
        }
        $('.slidedown_list.commdity_type').stop()
        $('.slidedown_list.commdity_type').show()
    })

    $('.top-part .second-line .left-part ul li.commdity_type').mouseleave(function () {
        bodyScroll();
        $(".slidedown_list.commdity_type .content .menu_list .left-part ul li a").each(function () {
            if ($(this).is($(".slidedown_list.commdity_type .content .menu_list .left-part ul li a").eq(0))) {
                $(this).addClass("active");
            }
            else {
                $(this).removeClass("active");
            }
        })
        $('.slidedown_list.commdity_type').stop()
        $('.slidedown_list.commdity_type').hide()
    })

    $('.slidedown_list.commdity_type').mouseleave(function () {
        $(".slidedown_list.commdity_type .content .menu_list .left-part ul li a").each(function () {
            if ($(this).is($(".slidedown_list.commdity_type .content .menu_list .left-part ul li a").eq(0))) {
                $(this).addClass("active");
            }
            else {
                $(this).removeClass("active");
            }
        })
        $('.slidedown_list.commdity_type').stop();
        $('.slidedown_list.commdity_type').hide();
    })
    //  #endregion

    //  #region 场景显示与隐藏
    $('.top-part .second-line .left-part ul li.scence_type,.slidedown_list.scence_type').hover(function () {
        var scencenum = $(".slidedown_list.scence_type img").length;
        var scenceimg = $(".slidedown_list.scence_type img");
        var count = 0; //存储图片加载到的位置，避免每次都从第一张图片开始遍历
        for (var i = count; i < scencenum; i++) {
            if (scenceimg[i].getAttribute("lazy_src") != "" && scenceimg[i].getAttribute("lazy_src") != undefined && (scenceimg[i].src == "" || scenceimg[i].src == undefined || scenceimg[i].src == null)) {
                scenceimg[i].src = scenceimg[i].getAttribute("lazy_src");
            }
            count = i + 1;
        }
        $('.slidedown_list.scence_type').stop()
        $('.slidedown_list.scence_type').show()
    })

    $('.top-part .second-line .left-part ul li.scence_type').mouseleave(function () {
        bodyScroll();
        $(".slidedown_list.scence_type .content .menu_list .left-part ul li a").each(function () {
            if ($(this).is($(".slidedown_list.scence_type .content .menu_list .left-part ul li a").eq(0))) {
                $(this).addClass("active");
            }
            else {
                $(this).removeClass("active");
            }
        })
        $('.slidedown_list.scence_type').stop()
        $('.slidedown_list.scence_type').hide()
    })

    $('.slidedown_list.scence_type').mouseleave(function () {
        $(".slidedown_list.scence_type .content .menu_list .left-part ul li a").each(function () {
            if ($(this).is($(".slidedown_list.scence_type .content .menu_list .left-part ul li a").eq(0))) {
                $(this).addClass("active");
            }
            else {
                $(this).removeClass("active");
            }
        })
        $('.slidedown_list.scence_type').stop();
        $('.slidedown_list.scence_type').hide();
    })
    //  #endregion

    //  #region 关于我们
    $('.top-part .second-line .left-part ul li.adoutus,.slidedown_list.adoutus').hover(function () {
        $('.slidedown_list.adoutus').stop()
        $('.slidedown_list.adoutus').show()
    })

    $('.top-part .second-line .left-part ul li.adoutus').mouseleave(function () {
        $('.slidedown_list.adoutus').stop()
        $('.slidedown_list.adoutus').hide()
    })

    $('.slidedown_list.adoutus').mouseleave(function () {
        $('.slidedown_list.adoutus').stop();
        $('.slidedown_list.adoutus').hide();
    })
    //  #endregion

    // #region显示分类
    $('.slidedown_list .content .menu_list .left-part ul li a').hover(function () {
        $(".slidedown_list .content .menu_list .left-part ul li a").each(function () {
            $(this).removeClass("active");
        })
        $(this).addClass("active");
        var gradeInfo_Id = $(this).find('.gradeInfo_Id').val();
        $('.type_part').hide();
        $('.type_part').each(function () {
            if ($(this).find('.gradeInfo_Id').val() == gradeInfo_Id) {
                $(this).show();
            }
        });
    })
    // #endregion

    // #region搜索框焦点事件
    $(".top-part .second-line .right-part .search-input").focus(function () {
        $(".top-part .second-line .right-part").addClass("active");
    });

    $(".top-part .second-line .right-part .search-input").blur(function () {
        $(".top-part .second-line .right-part").removeClass("active");
    });
    // #endregion
    // #region登入按钮
    $(".top-part .first-line .right-part ul.first_ul li a.login_on").click(function () {
        $("#Login_Form").show();
        $("#login_container").hide();
        $("#Register").hide();
        $(".loginalert").show();
    });
    // #endregion


    // #region搜索框焦点事件
    $('header.header .site-header .site-header-container .nav-bar-wrap .navbar-right .nav-user').hover(function () {
        $(this).addClass('active');
    })

    $('header.header .site-header .site-header-container .nav-bar-wrap .navbar-right .nav-user').mouseleave(function () {
        $(this).removeClass('active');
    })
    // #endregion

})

function bodyScroll() {
    var top = document.documentElement.scrollTop + document.body.scrollTop;
    if (top > 500) {
        $("#return").show();
    }
    else {
        $("#return").hide();
    }
}