var BoxIndex = -1;
var pagingFunc;
var OutPaging
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
        OutPaging = paging;
        paging.init({
            openWait: true,
            url: '../../../APi/Table/GetListDeliver?v=' + new Date().getTime(), //地址
            elem: '#content', //内容容器
            params: { //发送到服务端的参数
            },
            type: 'POST',
            tempElem: '#tpl', //模块容器
            pageConfig: { //分页参数配置
                elem: '#paged', //分页容器
                pageSize: 18 //分页大小
            },
            success: function () { //渲染成功的回调
                //alert('渲染成功');
            },
            fail: function (msg) { //获取数据失败的回调

                //alert('获取数据失败')
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
        //搜索
        $('#search').on('click', function () {
            paging.reload();
        });
    });
});

//#region 批量生成采购单
function ListBuyer() {
    var ary = new Array();
    $('.layui-form-checked').each(
        function (item) {
            ary.push($(this).parent().parent().find('input').val());
        })
    if (BoxIndex !== -1) {
        layer.msg("已有一个弹出窗口！");
        return;
    }
    
    var obj = new Object();
    obj.Ids = 0;
    var count = 0;
    if (ary.length == undefined) {
        obj.Ids = obj.Ids + "," + ary;
    }
    else {
        for (var i = 0; i < ary.length; ++i) {
            var Ids = ary[i];
            if (Ids != "on") {
                obj.Ids = obj.Ids + "," + Ids;
                count++;
            }

        }
    }
    if (ary.length == 0) {
        layer.msg("暂未选择采购物品！");
        return
    }
    count = count;
    //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
    layer.confirm('确认生成采购单吗？', null, function (index) {
        //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
        layer.confirm('确认把这' + count + '条添加进采购单吗？', null, function (index) {
            jQuery.axpost('../../api/Material/ListBuyerInfo', JSON.stringify(obj), function (data) {
                layer.msg(data.Message);

                layer.close(index);
                window.location.reload();
            });
        })
    });

}
//#endregion

//#region 删除

function DeleteById(Id) {
    if (BoxIndex !== -1) {
        layer.msg("已有一个弹出窗口！");
        return;
    }
    var obj = new Object();
    obj.Id = Id;
    layer.confirm('确认删除吗？', null, function (index) {
        jQuery.axpost('../../api/Material/DeleteDeliverInfo', JSON.stringify(obj), function (data) {
            layer.close(index);
            layer.msg(data.Message);
            window.location.reload();
        });
    });
}

//删除全部
function ListDel() {
    if (BoxIndex !== -1) {
        layer.msg("已有一个弹出窗口！");
        return;
    }
    var obj = new Object();
    layer.confirm('确认删除全部吗？', null, function (index) {
        jQuery.axpost('../../api/Material/DeleteDeliverInfo', JSON.stringify(obj), function (data) {
            layer.close(index);
            layer.msg(data.Message);
            window.location.reload();
        });
    });
}
//#endregion

