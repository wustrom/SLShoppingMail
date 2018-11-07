var addBoxIndex = -1;
var ColorId;
var fatherId;
var fatherName;
var ids = new Array();
var title;
$(document).ready(function () {
    layui.config({
        base: '../../../Base/js/'
    });

    reload();

    $('body').delegate('.layui-colla-title', 'click', function () {
        var e = $(this)
        refreshI(e)
    })


    $('body').delegate('.btn-add', 'click', function () {
        if (addBoxIndex !== -1)
            return;
        ColorId = null;
        fatherId = $(this).data('id');
        fatherName = $(this).data('name');
        title = '添加分类'
        GetEditBox()
    })

    $('body').delegate('.btn-del', 'click', function () {

    })

    $('body').keydown(function (e) {
        if (e.keyCode == 13)
            $('.btn-save').trigger("click");
        if (e.keyCode == 27)
            $('.layui-layer-close1').trigger("click");
    })

});

function GradeDel(event) {
    layer.confirm('删除颜色有可能会影响原材料信息，请确认是否删除？', {
        btn: ['确定', '取消']
    }, function () {
        ColorId = event.dataset.id
        Delete(ColorId)
        layer.closeAll('dialog');
    }, function () {
        layer.closeAll('dialog');
    })
    stopBubbling(event)
}

function GradeEdit(event) {
    if (addBoxIndex !== -1)
        return;
    ColorId = event.dataset.id
    title = "编辑分类"
    GetEditBox()
    stopBubbling(event)
}

function Delete(id) {
    var data = {
        ColorId: id
    }
    jQuery.axpost('../../Api/Equipment/DelColorInfo', JSON.stringify(data), function (data) {
        $('.layui-layer-close1').click()
        layer.msg('删除成功')
        reload();
    })
}

function GetEditBox() {
    var data = {
        ColorId: ColorId,
        fatherId: fatherId,
        fatherName: fatherName
    }
    $.get('../Equipment/EditColorInfo', data, function (form) {
        addBoxIndex = layer.open({
            type: 1,
            title: title,
            content: form,
            btn: ['保存', '取消'],
            shade: false,
            offset: ['100px', '30%'],
            area: ['600px', '400px'],
            zIndex: 19860924,
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
                    layui.paging().ajaxPost('../../api/Equipment/EditColorInfo', JSON.stringify(data.field), function (dataInfo) {
                        layer.close(index);
                        layui.paging().get();
                        layer.msg(dataInfo.Message);
                    });
                    //这里可以写ajax方法提交表单
                    return false; //阻止表单跳转。如果需要表单跳转，去掉这段即可。
                });
            },
            end: function () {
                addBoxIndex = -1;
            }
        });
    });
}


function showContent(ele) {
    var e = ele.parent().find('.layui-colla-content').first();
    if (e.hasClass('layui-show'))
        e.removeClass('layui-show')
    else
        e.addClass('layui-show');
}

function refreshI(ele) {
    ele.find('i').remove();
    var e = ele.parent().find('.layui-colla-content').first();
    if (e.hasClass('layui-show')) {
        ele.append('<i class="layui-icon layui-colla-icon">&#xe602;</i>')
        e.removeClass('layui-show')
    }
    else {
        ele.append('<i class="layui-icon layui-colla-icon">&#xe61a;</i>')
        e.addClass('layui-show');
    }
    GetShowIds()
}

function GetShowIds() {
    ids = new Array();
    $('.layui-show').prev().find('font').each(function () {
        ids.push($(this).find('a').eq(0).data('id'));
    })
}

function edit() {

}


function collapse() {
    layui.use(['element', 'layer'], function () {
        var element = layui.element;
        element = layui.element();
        var layer = layui.layer;

        //监听折叠
        element.on('collapse(test)', function (data) {
            layer.msg('展开状态：' + data.show);
        });
    });

}


function layermsg(e) {
    layer.msg(e)
}

function stopBubbling(e) {
    e = window.event || e;
    if (e.stopPropagation) {
        e.stopPropagation();      //阻止事件 冒泡传播
    } else {
        e.cancelBubble = true;   //ie兼容
    }
}


function reload() {
    layui.use(['paging', 'form'], function () {
        var $ = layui.jquery,
            paging = layui.paging(),
            layerTips = parent.layer === undefined ? layui.layer : parent.layer, //获取父窗口的layer对象
            layer = layui.layer, //获取当前窗口的layer对象
            form = layui.form();
        paging.init({
            openWait: true,
            url: '../../Api/Table/GetColorList', //地址
            elem: '#content', //内容容器
            params: { //发送到服务端的参数
                ids: ids
            },
            type: 'POST',
            tempElem: '#tpl', //模块容器
            pageConfig: { //分页参数配置
                elem: '#paged', //分页容器
                pageSize: 999, //分页大小

            },
            success: function () { //渲染成功的回调
                //alert('渲染成功');
            },
            fail: function (msg) { //获取数据失败的回调
                alert('获取数据失败')
            },
            complate: function () { //完成的回调
                //alert('处理完成');
                //重新渲染复选框
                form.render('checkbox');
                form.on('checkbox(allselector)', function (data) {
                    var elem = data.elem;
                });

            },
        });
    });
}