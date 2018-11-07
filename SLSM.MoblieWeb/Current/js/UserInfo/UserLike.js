

// #region 取消收藏
  function DelLike(Id) {
    var datas = { Id: Id }
    jQuery.axpost('../../Api/UserLike/DeleteLike', JSON.stringify(datas), function (data) {
        layer.msg(data.Message);
        window.location.replace("../../UserInfo/UserLike");
    });
}
// #endregion

// #region 如果没有数据
$(function () {
    var count = parseInt($('#hiddPageCount').val());
    if (count == 0) {
        $('.public-content-box .my_sc').append('<div style="font-size:18px;color:#808080;padding-top:30px;padding-left:28%;">您暂时没有收藏商品！</div>')
    }
})
// #endregion