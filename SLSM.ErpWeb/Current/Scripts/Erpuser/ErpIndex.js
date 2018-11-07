var addBoxIndex = -1;
var ColorId;
var fatherId;
var fatherName;
var ids = new Array();
var obj = new Object();
var title;
$(document).ready(function () {
    layui.config({
        base: '../../../Base/js/',
    });

    layui.use(['paging', 'form'], function () {
        var $ = layui.jquery,
            paging = layui.paging(),
            layerTips = parent.layer === undefined ? layui.layer : parent.layer, //获取父窗口的layer对象
            layer = layui.layer, //获取当前窗口的layer对象
            form = layui.form();
        paging.init({
            openWait: true,
            url: '../../Api/Table/GetErpUserInfo', //地址
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
                $('.layui-colla-item').eq(0).click();
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



    //#region 添加角色名
    $('body').delegate('.btn-add', 'click', function () {
        if (addBoxIndex !== -1)
            return;
        // ColorId = null;
        ErproleId = $(this).data('id');
        fatherName = $(this).data('name');
        title = '添加分类'
        GetEditBox()
    })
    //#endregion
});
//#region 删除角色名
function GradeDel(event) {
    layer.confirm('确定删除信息?', {
        btn: ['确定', '取消']
    }, function () {
        obj.ErproleId = event.dataset.id;
        jQuery.axpost('../../Api/Jurisdiction/DelEchnologyInfo', JSON.stringify(obj), function (data) {
            $('.layui-layer-close1').click()
            layer.msg('删除成功')
            reload();
        })

        Delete(ColorId)
        layer.closeAll('dialog');
    }, function () {
        layer.closeAll('dialog');
    })
    stopBubbling(event)
}

function Delete(id) {

}
//#endregion

//#region 修改
function GradeEdit(event) {
    if (addBoxIndex !== -1)
        return;
    ErproleId = event.dataset.id
    title = "编辑分类"
    GetEditBox()
    stopBubbling(event)
}
//#endregion

function GetEditBox() {
    var data = {
        ErproleId: ErproleId,
        fatherName: fatherName
    }
    $.get('../Jurisdiction/UpdateInfo', data, function (form) {
        addBoxIndex = layer.open({
            type: 1,
            title: title,
            content: form,
            btn: ['保存', '取消'],
            shade: false,
            offset: ['100px', '30%'],
            area: ['400px', '250px'],
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
                    layui.paging().ajaxPost('../../api/Jurisdiction/EditJurisdictionInfo', JSON.stringify(data.field), function (dataInfo) {
                        layer.close(index);
                        window.location.reload();
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

//#region 
function showContent(ele) {
    var e = ele.parent().find('.layui-colla-content').first();
    if (e.hasClass('layui-show'))
        e.removeClass('layui-show')
    else
        e.addClass('layui-show');
}

function GetShowIds() {
    ids = new Array();
    $('.layui-show').prev().find('font').each(function () {
        ids.push($(this).find('a').eq(0).data('id'));
    })
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
//$('body').keydown(function (e) {
//    if (e.keyCode == 13)
//        $('.btn-save').trigger("click");
//    if (e.keyCode == 27)
//        $('.layui-layer-close1').trigger("click");
//})

//function layermsg(e) {
//    layer.msg(e)
//}
//#endregion

function stopBubbling(e) {
    e = window.event || e;
    if (e.stopPropagation) {
        e.stopPropagation();      //阻止事件 冒泡传播
    } else {
        e.cancelBubble = true;   //ie兼容
    }
}

//#region 添加权限
function AddJurisdiction() {
    //角色
    obj.ErproleId = $('.RadioShow').val();
    //页面
    var arr = new Array;
    $('#xtree1 .layui-form-checked').each(function () {
        arr.push($(this).parent().find('input').val());
    })
    obj.ERProlePower = "";
    for (i = 0; i < arr.length; i++) {
        if (arr[i] != "客服管理" && arr[i] != "产品原材料管理" && arr[i] != "品检管理" && arr[i] != "品检管理" && arr[i] != "仓库管理" && arr[i] != "财务管理" && arr[i] != "工艺设备管理" && arr[i] != "账号权限设置" && arr[i] != "on") {
            obj.ERProlePower += arr[i] + ',';
        }
    }
    jQuery.axpost('../../Api/Jurisdiction/AddJurisdiction', JSON.stringify(obj), function (dataInfo) {
        layer.close();
        layer.msg(dataInfo.Message);
        //layer.reload();
    })
}
//#endregion

//点击角色列表
function Show(e) {
    var obj = new Object();
    var str = "";
    $('#content input').each(function () {
        $("#content input").removeClass("RadioShow");
    })
    //样式
    $(e).find('input').prop("checked", true);
    $(e).find("input").addClass("RadioShow")

    obj.ErproleId = $(e).find('input').val();
    jQuery.axpost('../../Api/Jurisdiction/ERpUserInfo', JSON.stringify(obj), function (data) {
        str = data.Message == null ? "" : data.Message;
        //#region 右边树形图
        layui.use(['form'], function () {
            var $ = layui.jquery,
                layerTips = parent.layer === undefined ? layui.layer : parent.layer, //获取父窗口的layer对象
                layer = layui.layer, //获取当前窗口的layer对象
                form = layui.form();
            $('#xtree1').empty();//清除
            var json = [
                {
                    title: "设计师管理", value: "DesignerInfo", checked: str.indexOf('DesignerInfo,') != -1 ? true : false, data: []
                },
                {
                    title: "生产管理", value: "ManufactureInfo", checked: str.indexOf('ManufactureInfo,') != -1 ? true : false, data: []
                },
                {
                    title: "客服管理", value: "客服管理", data: [{ title: "订单管理", value: "OrderInfo", checked: str.indexOf('OrderInfo,') != -1 ? true : false, data: [] }]
                },
                {
                    title: "产品原材料管理", value: "产品原材料管理", data: [
                        { title: "原材料管理", value: "MaterialManger", checked: str.indexOf('MaterialManger,') != -1 ? true : false, data: [] }
                        , { title: "待采购管理", value: "WaitBuyerInfo", checked: str.indexOf('WaitBuyerInfo,') != -1 ? true : false, data: [] }
                        , { title: "采购单管理", value: "BuyerInfo", checked: str.indexOf('BuyerInfo,') != -1 ? true : false, data: [] }
                        , { title: "供应商管理", value: "ProducerInfo", checked: str.indexOf('ProducerInfo,') != -1 ? true : false, data: [] }
                    ]
                }
                , {
                    title: "品检管理", value: "品检管理", data: [
                        { title: "原材料品检", value: "Raw_InspectionInfo", checked: str.indexOf('Raw_InspectionInfo,') != -1 ? true : false, data: [] }
                        , { title: "产品品检", value: "Product_InspectionInfo", checked: str.indexOf('Product_InspectionInfo,') != -1 ? true : false, data: [] }
                    ]
                }, {
                    title: "仓库管理", value: "仓库管理", data: [
                        { title: "库存管理", value: "StorageInfo", checked: str.indexOf('StorageInfo,') != -1 ? true : false, data: [] }
                        , { title: "采购入库", value: "BuyerInfo", checked: str.indexOf('BuyerInfo,') != -1 ? true : false, data: [] }
                        , { title: "生产领料", value: "ReceiveInfo", checked: str.indexOf('ReceiveInfo,') != -1 ? true : false, data: [] }
                        , { title: "仓库分类", value: "WarehouseInfo", checked: str.indexOf('WarehouseInfo,') != -1 ? true : false, data: [] }
                    ]
                }, {
                    title: "财务管理", value: "财务管理", data: [
                        { title: "应付账款", value: "WantFinance", checked: str.indexOf('WantFinance,') != -1 ? true : false, data: [] }
                        , { title: "发票记录", value: "InvoiceInfo", checked: str.indexOf('InvoiceInfo,') != -1 ? true : false, data: [] }
                    ]
                }
                , { title: "发货管理", value: "ConsignmentInfo", checked: str.indexOf('ConsignmentInfo,') != -1 ? true : false, data: [] }
                , {
                    title: "工艺设备管理", value: "工艺设备管理", data: [
                        { title: "定制工艺管理", value: "TechnologyInfo", checked: str.indexOf('TechnologyInfo,') != -1 ? true : false, data: [] }
                        , { title: "颜色管理", value: "ColorInfo", checked: str.indexOf('ColorInfo,') != -1 ? true : false, data: [] }]
                },
                {
                    title: "账号权限设置", value: "账号权限设置", data: [
                        { title: "管理平台账号权限", value: "JurisdictionInfo", checked: str.indexOf('JurisdictionInfo,') != -1 ? true : false, data: [] }
                        , { title: "用户登录", value: "ErpLoginUser", checked: str.indexOf('ErpLoginUser,') != -1 ? true : false, data: [] }
                    ]
                }
            ];
            var xtree3 = new layuiXtree({
                elem: 'xtree1'                  //必填三兄弟之老大
                , form: form                    //必填三兄弟之这才是真老大
                , data: json //必填三兄弟之这也算是老大
                , isopen: false  //加载完毕后的展开状态，默认值：true
                , ckall: true    //启用全选功能，默认值：false
                , ckallback: function () { } //全选框状态改变后执行的回调函数
                , icon: {        //三种图标样式，更改几个都可以，用的是layui的图标
                    open: "&#xe622;"       //节点打开的图标
                    , close: "&#xe622;"    //节点关闭的图标
                    , end: "&#xe621;"      //末尾节点的图标
                }
                , color: {       //三种图标颜色，独立配色，更改几个都可以
                    open: "#EE9A00"        //节点图标打开的颜色
                    , close: "#EEC591"     //节点图标关闭的颜色
                    , end: "#828282"       //末级节点图标的颜色
                }
                , click: function (data) {  //节点选中状态改变事件监听，全选框有自己的监听事件
                    console.log(data.elem); //得到checkbox原始DOM对象
                    console.log(data.elem.checked); //开关是否开启，true或者false
                    console.log(data.value); //开关value值，也可以通过data.elem.value得到
                    console.log(data.othis); //得到美化后的DOM对象
                }
            });

        })
        //#endregion
    })

}
