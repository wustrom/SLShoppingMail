var BoxIndex = -1;
var pagingFunc;
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
        paging.init({
            openWait: true,
            url: '../../../APi/Table/GetTechnologyInfo?v=' + new Date().getTime(), //地址
            elem: '#content', //内容容器
            params: { //发送到服务端的参数
            },
            type: 'POST',
            tempElem: '#tpl', //模块容器
            pageConfig: { //分页参数配置
                elem: '#paged', //分页容器
                pageSize: 22 //分页大小
            },
            success: function () { //渲染成功的回调
                //alert('渲染成功');
            },
            fail: function (msg) { //获取数据失败的回调
                alert('获取数据失败')
            },
            complate: function () { //完成的回调
                //alert('处理完成');
                pagingFunc = paging;
                //重新渲染复选框
                form.render('checkbox');
                form.on('checkbox(allselector)', function (data) {
                    var elem = data.elem;

                    $('#content').children('tr').each(function () {
                        var $that = $(this);
                        //全选或反选
                        $that.children('td').eq(0).children('input[type=checkbox]')[0].checked = elem.checked;
                        form.render('checkbox');
                    });
                });
                //绑定所有编辑按钮事件
                $('#content').children('tr').each(function () {
                    var $that = $(this);
                    $that.children('td:last-child').children('a[data-opt=edit]').on('click', function () {
                        layer.msg($(this).data('name'));
                    });
                });
            },
        });
        // #region 获取所有选择的列
        //$('#getSelected').on('click', function () {
        //    var names = '';
        //    $('#content').children('tr').each(function () {
        //        var $that = $(this);
        //        var $cbx = $that.children('td').eq(0).children('input[type=checkbox]')[0].checked;
        //        if ($cbx) {
        //            var n = $that.children('td:last-child').children('a[data-opt=edit]').data('name');
        //            names += n + ',';
        //        }
        //    });
        //    layer.msg('你选择的名称有：' + names);
        //});
        //#endregion

        //搜索
        $('#search').on('click', function () {
            paging.reload();
        });

        //#region添加
        $('#add').on('click', function () {
            if (BoxIndex !== -1) {
                layer.msg("已有一个弹出窗口！");
                return;
            }
            //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
            $.get('../Equipment/EditTechnologyInfo', null, function (form) {
                $(".hidden-div #BoxIndex").val("0");
                BoxIndex = layer.open({
                    type: 1,
                    title: '添加工艺名称',
                    content: form,
                    btn: ['确定', '取消'],
                    shade: false,
                    offset: ['100px', '30%'],
                    area: ['350px', '180px'],
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
                            jQuery.axpost('../../api/Equipment/EditEchnologyInfo', JSON.stringify(data.field), function (dataInfo) {
                                layer.close(index);
                                layer.msg(dataInfo.Message);
                                paging.reload();
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
        });
        //#endregion
    });
});

//#region 修改
function EditInfo(Id) {
    if (BoxIndex !== -1) {
        layer.msg("已有一个弹出窗口！");
        return;
    }
    var obj = new Object();
    obj.Id = Id;
    //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
    $.get('../Equipment/EditTechnologyInfo', obj, function (form) {
        $(".hidden-div #BoxIndex").val("0");
        BoxIndex = layer.open({
            type: 1,
            title: '修改工艺名称',
            content: form,
            btn: ['保存', '取消'],
            shade: false,
            offset: ['100px', '30%'],
            area: ['350px', '190px'],
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
                    jQuery.axpost('../../api/Equipment/EditEchnologyInfo', JSON.stringify(data.field), function (dataInfo) {
                        layer.close(index);
                        layer.msg(dataInfo.Message);
                        pagingFunc.reload();
                    });

                    //这里可以写ajax方法提交表单
                    return false; //阻止表单跳转。如果需要表单跳转，去掉这段即可。
                });
            },
            end: function () {
                BoxIndex = -1;
            }
        });
    });
}
//#endregion

//#region 删除
function DeleteInfo(Id) {
    if (BoxIndex !== -1) {
        layer.msg("已有一个弹出窗口！");
        return;
    }
    var obj = new Object();
    obj.Ids = 0;
    if (Id.length == undefined) {
        obj.Ids = obj.Ids + "," + Id;
    }
    else {
        for (var i = 0; i < Id.length; ++i) {
            var Ids = Id[i];
            obj.Ids = obj.Ids + "," + Ids;
        }
    }
    //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
    layer.confirm('确认删除此工艺吗？', null, function (index) {
        jQuery.axpost('../../api/Equipment/DelEchnologyInfo', JSON.stringify(obj), function (data) {
            layer.msg(data.Message);
            pagingFunc.reload();
            layer.close(index);
        });
    });
}

//  批量删除仓库信息
function ListDel() {
    var ary = new Array();
    $('.layui-form-checked').each(
        function (item) {
            ary.push($(this).parent().parent().find('input').val());
            DeleteInfo(ary);
        })
}
//#endregion

