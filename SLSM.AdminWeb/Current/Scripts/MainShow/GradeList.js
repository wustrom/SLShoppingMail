var layer;
$(document).ready(function () {
    layui.config({
        base: '../../../Base/js/'
    });
    layui.use(['paging', 'form'], function () {
        var $ = layui.jquery,
            paging = layui.paging(),
            layerTips = parent.layer === undefined ? layui.layer : parent.layer, //获取父窗口的layer对象
            layer = layui.layer, //获取当前窗口的layer对象
            form = layui.form();
    });
});



var BoxIndex = -1;
function EditImage(ImageId) {
    if (BoxIndex !== -1) {
        layer.msg("已有一个弹出窗口！");
        return;
    }
    var obj = new Object();
    obj.CarouselId = ImageId;
    //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
    $.get('../MainShow/DetailCarousel', obj, function (form) {
        $(".hidden-div #BoxIndex").val("0");
        BoxIndex = layer.open({
            type: 1,
            title: '添加表单',
            content: form,
            btn: ['保存', '取消'],
            shade: false,
            offset: ['100px', '30%'],
            area: ['600px', '400px'],
            zIndex: 19891013,
            maxmin: true,
            yes: function (index) {
                //触发表单的提交事件
                $('form.layui-form').find('button[lay-filter=edit]').click();
            },
            full: function (elem) {
                var win = window.top === window.self ? window : parent.window;
                $(win).on('resize', function () {
                    var $this = $(this);
                    elem.width($this.width()).height($this.height()).css({
                        top: 0,
                        left: 0
                    });
                    elem.children('div.layui-layer-content').height($this.height() - 95);
                });
            },
            success: function (layero, index) {
                //弹出窗口成功后渲染表单
                var form = layui.form();
                form.render();
                form.on('submit(edit)', function (data) {
                    jQuery.axpost('../../api/MainShow/ChangeCarousel', JSON.stringify(data.field), function (dataInfo) {
                        layer.close(index);
                        layer.msg(dataInfo.Message);
                        location.reload();
                    });

                    //这里可以写ajax方法提交表单
                    return false; //阻止表单跳转。如果需要表单跳转，去掉这段即可。
                });
                //console.log(layero, index);
            },
            end: function () {
                BoxIndex = -1;
            }
        });
    });
}

function AddImage(num) {

    if (BoxIndex !== -1) {
        layer.msg("已有一个弹出窗口！");
        return;
    }
    var obj = new Object();
    obj.Num = num;
    //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
    $.get('../MainShow/DetailCarousel', obj, function (form) {
        $(".hidden-div #BoxIndex").val("0");
        BoxIndex = layer.open({
            type: 1,
            title: '添加表单',
            content: form,
            btn: ['保存', '取消'],
            shade: false,
            offset: ['100px', '30%'],
            area: ['600px', '400px'],
            zIndex: 19891013,
            maxmin: true,
            yes: function (index) {
                //触发表单的提交事件
                $('form.layui-form').find('button[lay-filter=edit]').click();
            },
            full: function (elem) {
                var win = window.top === window.self ? window : parent.window;
                $(win).on('resize', function () {
                    var $this = $(this);
                    elem.width($this.width()).height($this.height()).css({
                        top: 0,
                        left: 0
                    });
                    elem.children('div.layui-layer-content').height($this.height() - 95);
                });
            },
            success: function (layero, index) {
                //弹出窗口成功后渲染表单
                var form = layui.form();
                form.render();
                form.on('submit(edit)', function (data) {
                    jQuery.axpost('../../api/MainShow/ChangeCarousel', JSON.stringify(data.field), function (dataInfo) {
                        layer.close(index);
                        layer.msg(dataInfo.Message);
                        location.reload();
                    });

                    //这里可以写ajax方法提交表单
                    return false; //阻止表单跳转。如果需要表单跳转，去掉这段即可。
                });
                //console.log(layero, index);
            },
            end: function () {
                BoxIndex = -1;
            }
        });
    });
}

function DeleteImage(ImageId) {
    layer.confirm('您确定要删除轮播图吗？', {
        btn: ['确定', '取消'] //按钮
    }, function (index) {
        var obj = new Object();
        obj.CarouselId = ImageId;
        jQuery.axpost('../../api/MainShow/DeleteImage', JSON.stringify(obj), function (dataInfo) {
            layer.close(index);
            layer.msg(dataInfo.Message);
            location.reload();
        });
    }, null);
}