$(document).ready(function () {
  //  
    $('#btn-img').click(function () {
        $(this).parent().parent().find('#upImg').val('');
        $(this).parent().parent().find('#upImg').click();
    })
})

function filechange(event) {
    var that = this;
    var obj = $(this);
    var length = obj.files.length;
    var isPic = true;
    for (var i = 0; i < obj.files.length; i++) {
        var temp = obj.files[i].name;
        var fileTarr = temp.split('.');
        var filetype = fileTarr[fileTarr.length - 1];
        if (filetype !== 'png' && filetype !== 'jpg' && filetype !== 'jpeg') {
            layer.msg('上传文件必须为图片(后缀名为png,jpg,jpeg)');
            isPic = false;
        } else {
            var size = obj.files[i].size / 1024;
            if (parseInt(size) > 2048) {
                layer.msg("图片大小不能超过2MB");
                isPic = false;
            }
        }
        if (!isPic)
            break;
    }
    if (!isPic)
        return;

    $(that).parent().ajaxSubmit(function (res) {
        $(that).parent().parent().find('#btn-img').attr('src', res);
    });
}