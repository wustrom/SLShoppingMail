
// #region 退货申请
  $(function () {
   // 
    $('.evaluate-btn-box .btn-primary').click(function () {
        var ReturnText = $('.comment-box .text .text-input').val();
        var DetailId = $('.evaluate-list .item #DetailId').val();
        var OrderId = $('.evaluate-list .item #OrderId').val();
        var Status = 7;
        var datas = { DetailId: DetailId, ReturnText: ReturnText, OrderId: OrderId, Status: Status };
        jQuery.axpost('../../Api/Order/ReturnInfo', JSON.stringify(datas), function (data) {
            layer.msg(data.Message);
            window.location.replace("../../UserInfo/MyOrderList");
        })
    });
})
// #endregion

// #region 页面
  $(function () {
        var slideout = new Slideout({
            'panel': document.getElementById('panel'),
            'menu': document.getElementById('menu'),
            'padding': 256,
            'tolerance': 70
        });
        /*Toggle button*/
        document.querySelector('.toggle-button').addEventListener('click', function () {
            slideout.toggle();
        });
    })


$(function () {
    var swiper = new Swiper('.swiper-container', {
        loop: true,
        speed: 1000,
        autoplay: true
    });
})
// #endregion