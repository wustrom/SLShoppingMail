// #region 地址联系人删除
function DeleteAddr(Id, that) {
    var datas = { Id: Id }
    jQuery.axpost('../../Api/User/DeleteAddr', JSON.stringify(datas), function (data) {
        var item = $(that).parent().parent().remove();
        if ($('.table tbody tr').length == 0) {
            $('.alert.alert-warning').hide();
            $('.alert.alert-info').show();
            $('.table ').hide();
        }
    });
}
// #endregion