$(document).ready(function () {
    $('#btn-Smallimg').click(function () {
        $('#upSmallImg').val('');
        $('#upSmallImg').click();
    })

    $('#btn-Bigimg').click(function () {
        $('#upBigImg').val('');
        $('#upBigImg').click();
    })

    $('.btn-save').click(function () {
        Save();
    })
    $('body').delegate('.btn-delAttr', 'click', function () {
        $(this).parent().remove();
    })
    $('.btn-addAttr').click(function () {
        var str = $(this).prev().find('input').val();
        if (str.trim() != '') {
            var h = '<div class="layui-form-selected layui-form-checkbox layui-form-checked attr" lay-skin=""><span>' + str.trim() + '</span><i class="layui-icon btn-delAttr">&#x1006;</i></div>'
            $('.checkbox-add').before(h);
        }
    })
})

function filechange(event) {
    var obj = document.getElementById("upBigImg");
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
    $("#formid2").ajaxSubmit(function (res) {
        $('#btn-Bigimg').attr('src', res);
    });
}

function fileSmallchange(event) {
    var obj = document.getElementById("upSmallImg");
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
            if (parseInt(size) > 512) {
                layer.msg("图片大小不能超过512Kb");
                isPic = false;
            }
        }
        if (!isPic)
            break;
    }
    if (!isPic)
        return;
    $("#formid1").ajaxSubmit(function (res) {
        $('#btn-Smallimg').attr('src', res);
    });
}

function Save() {
    var gradeId = $('.grade').data('id')
    var img = $('#btn-Smallimg').attr('src');
    img = img == '/Image/Grade/noImg.svg' ? '' : img;
    var Bigimg = $('#btn-Bigimg').attr('src');
    Bigimg = Bigimg == '/Image/Grade/noImg.svg' ? '' : Bigimg;
    var gradeName = $('.grade').val();
    var IsScence = $('#IsScence').val();
    var CommdityList = $('#CommdityList').val();
    if (gradeName == '') {
        layer.msg('名称不能为空');

        return;
    }
    var fatherId = $('.gradeFather').data('id');
    var attrs = new Array();
    $('.attr').each(function () {
        attrs.push($(this).find('span').html());
    })

    if (gradeId == '') {
        var data = {
            gradeImg: img,
            gradeName: gradeName,
            fatherId: fatherId,
            gradeBigImg: Bigimg,
            IsScence: IsScence,
            CommdityList: CommdityList
        }
        jQuery.axpost2('../../Api/grade/add', data, function (data) {
            $('.layui-layer-close1').click()
            layer.msg('添加成功')
            reload();
        })
    }
    //更新
    else {
        var data = {
            gradeId: gradeId,
            gradeImg: img,
            gradeName: gradeName,
            fatherId: fatherId,
            gradeBigImg: Bigimg,
            IsScence: IsScence,
            CommdityList: CommdityList
        }
        jQuery.axpost2('../../Api/grade/update', data, function (data) {
            $('.layui-layer-close1').click()
            layer.msg('更新成功')
            reload();
        })
    }

}