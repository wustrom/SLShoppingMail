$(document).ready(function () {
    $('#btn-img').click(function () {
        $('#upImg').val('');
        $('#upImg').click();
    })

    $('.btn-save').click(function () {
        Save();
    })
})

function filechange(event) {
    var obj = document.getElementById("upImg");
    var length = obj.files.length;
    var isPic = true;
    for (var i = 0; i < obj.files.length; i++) {
        var temp = obj.files[i].name;
        var fileTarr = temp.split('.');
        var filetype = fileTarr[fileTarr.length - 1];
        if (filetype != 'png' && filetype != 'jpg' && filetype != 'jpeg') {
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

    $("#formid").ajaxSubmit(function (res) {
        $('#btn-img').attr('src', res);
        $('#Image').val(res)
    });
}