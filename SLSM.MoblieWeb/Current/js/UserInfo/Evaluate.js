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

$(function () {
    $(".star-icon i").click(function () {
        var i = $(this).index();
        $(this).siblings("i").removeClass("on");
        $(this).addClass("on");
        $(this).siblings("i:lt(" + i + ")").addClass("on");
    });
});
// #endregion

// #region 提交评价
$('.evaluate-btn-box .btn-primary').click(function () {
    // var numArr = [];
    // var numStart = [];
     for (var i = 0; i < $('.evaluate-list .item').length; i++) {
        var CommodityId = $('.evaluate-list').find('input[name="CommodityId"]').eq(i).val();
      //  numArr.push(CommodityId);
        //星级
        var Start = $('.evaluate-list .item').eq(i).find('.star-item .star-icon .on').size();
      //  numStart.push(Start);   
        //图片
        var Images = $('.myorder .ricont .model .imgbox img').attr("src");
        //评价
        var Content = $('.comment-box .text .text-input').val()
       
        var OrderId = $('.evaluate-big-box  #OrderId').val();
         var Status = 6;
         
    var datas = { CommodityId: CommodityId, ImageList: Images,Content: Content, Start: Start, OrderId: OrderId, Status: Status }
    jQuery.axpost('../../Api/Evaluate/SubmitEvaluate', JSON.stringify(datas), function (data) {
         // layer.msg(data.Message);
          window.location.replace("../../UserInfo/MyOrderList");
        })
    }
})
// #endregion
   