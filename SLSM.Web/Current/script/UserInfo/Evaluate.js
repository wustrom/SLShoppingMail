
/// <reference path="../ajax.js" />
// #region 提交评价
    function Evaluate() {
    for (var i = 0; i < $('.chat .model').length; i++) {
        var CommodityId = $('.chat').find('input[name="CommodityId"]').eq(i).val()
        //图片
        var Images = $('.myorder .ricont .model .imgbox img').attr("src").substring(6);
        //评价
        var Content = $('.myorder .ricont .chawords .modelbx .s2 textarea').val();
        //星级
        var Start = $('.myorder .ricont .chat .model .pf input').val();
        var OrderId = $('.ricont .ztitem #Id').val();
        //状态
        var Status = 6;
        var datas = { CommodityId: CommodityId, ImageList: Images, Content: Content, Start: Start, OrderId: OrderId, Status: Status }
        jQuery.axpost('../../Api/Evaluate/SubmitEvaluate', JSON.stringify(datas), function (data) {
            // layer.msg(data.Message);
            window.location.replace("../../UserInfo/MyOrderList");
        })
    }
}
// #endregion
