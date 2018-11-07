/// <reference path="../ajax.js" />

// #region 显示全部数据
$(function () {
    $('#MessageInfo').hide();
    var count = parseInt($('#hiddPageCount').val());
    if (count == 0) {
        $('.public-content-box .my-news-list ul').append('<div style="font-size:18px;color:#808080;padding-top:50px;padding-left:30%;">您暂时没有新消息！</div>')
    }
})
// #endregion

// #region 删除
  function DeMess(Id) {
    var datas = { Id: Id }
    jQuery.axpost('../../Api/Message/DelateMessInfo', JSON.stringify(datas), function (data) {
        layer.msg(data.Message);
        window.location.replace("../../UserInfo/Message");
    });

}
// #endregion

// #region 返回
  function retern(Id) {
    var datas = { Id: Id };
    jQuery.axpost('../../Api/Message/UpdateRead', JSON.stringify(datas), function (data) {
        if (!isNaN(data.Message)) {
            var count = parseInt(data.Message);
        }
        window.location.replace("../../UserInfo/Message");
    })
}
// #endregion

// #region 详细信息
  function LookMess(Id) {
    $('#MessageInfo').show();
    $('.my-news-list').hide();
    var datas = { Id: Id };
    jQuery.axpost('../../Api/Message/SelectMessageInfo', JSON.stringify(datas), function (data) {
        var div = '<div class="tz_sj">\
                         <strong>'+ data.Model1.Title + '</strong>\
                          <p>'+ data.Model1.MessageTime + '</p>\
	               </div >\
                <div class="my_info">'+ data.Model1.Content + '</div>\
                <div class="xz_btn">\
                    <a href="#" class="del" Onclick="DeMess('+ data.Model1.Id + ')">删除</a>\
                    <a href="#" class="retern" Onclick="retern('+ data.Model1.Id + ')">返回</a>\
                </div>\
                    ';
        $("#MessageInfo").html(div);
    })
}
// #endregion

// #region 滑动
        $(function () {
            var swiper = new Swiper('.swiper-container', {
                loop: true,
                speed: 1000,
                autoplay: true
            });
        })

    // 滑动
$(function () {
    $(".my-news-list li").swiper({
            swipeLeft: function () {
                // 向左滑动执行
                var _this = $(this);
                this.find("a").css({
                    "transform": "translate(-2.2rem,0)"
                });
                this.find(".clear-btn").stop().animate({
                    right: 0
                });
            },
            swipeRight: function () {
                // 向右滑动执行
                var _this = $(this);
                _this.find("a").css({
                    "transform": "translate(0,0)"
                });
                _this.find(".clear-btn").stop().animate({
                    right: "-2rem"
                });
            }
        });
    })
    $(function(){
        $(".my-news-list li .clear-btn").click(function () {
            $(this).parent("li").remove();
        })
    })
// #endregion
