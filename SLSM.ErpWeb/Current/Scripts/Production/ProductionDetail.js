var BoxIndex = -1;
var pagingFunc;
var obj = new Object();
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
    })
})
//#region退回设计,待生产确认,二次修改待确认
function ReturnDesign(Id) {
    if (BoxIndex !== -1) {
        layer.msg("已有一个弹出窗口！");
        return;
    }
    obj.Id = Id;
    $.get('../Designer/ReturnServiceInfo', obj, function (form) {
        $(".hidden-div #BoxIndex").val("0");
        BoxIndex = layer.open({
            type: 1,
            title: '<img src="../Current/Icon/ReturnCustomer.png" />&nbsp;退回设计',
            content: form,
            btn: ['确定'],
            shade: false,
            offset: ['100px', '30%'],
            area: ['350px', '300px'],
            zIndex: 19891013,
            maxmin: true,
            yes: function (index) {
                //触发表单的提交事件

                $('form.layui-form').find('button[lay-filter=edit]').click();
            },
            full: function (elem) {
                var win = window.top === window.self ? window : parent.window;
                $(win).on('resize', function () {
                    $('.layui-layer-max').css('display', 'none');
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
                    jQuery.axpost('../../api/Designer/ReturnService', JSON.stringify(data.field), function (dataInfo) {
                        layer.close(index);
                        layer.msg(dataInfo.Message);
                        var tab = parent.tab;
                        tab.deleteTab(tab.getCurrentTabId());
                    });
                    return false;
                });
                //console.log(layero, index);
            },
            end: function () {
                BoxIndex = -1;
            }
        });
    });
}
//#endregion

// #region 退回客服,生产退回待处理,待生产,设计未处理
function ReturnService(Id) {
    if (BoxIndex !== -1) {
        layer.msg("已有一个弹出窗口！");
        return;
    }
    obj.Id = Id;
    $.get('../Designer/ReturnServiceInfo', obj, function (form) {
        $(".hidden-div #BoxIndex").val("0");
        BoxIndex = layer.open({
            type: 1,
            title: '退回客服',
            content: form,
            btn: ['确定'],
            shade: false,
            offset: ['100px', '30%'],
            area: ['350px', '300px'],
            zIndex: 19891013,
            maxmin: true,
            yes: function (index) {
                //触发表单的提交事件

                $('form.layui-form').find('button[lay-filter=edit]').click();
            },
            full: function (elem) {
                var win = window.top === window.self ? window : parent.window;
                $(win).on('resize', function () {
                    $('.layui-layer-max').css('display', 'none');
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
                    jQuery.axpost('../../api/Designer/ReturnService', JSON.stringify(data.field), function (dataInfo) {
                        layer.close(index);
                        layer.msg(dataInfo.Message);
                        // pagingFunc.reload();
                        var tab = parent.tab;
                        tab.deleteTab(tab.getCurrentTabId());
                    });
                    return false;
                });
                //console.log(layero, index);
            },
            end: function () {
                BoxIndex = -1;
            }
        });
    });
}
// #endregion

//#region 处理完成再次提交
function AgainSubmission(Id) {
    if (BoxIndex !== -1) {
        layer.msg("已有一个弹出窗口！");
        return;
    }
    obj.Id = Id;
    $.get('../Designer/ReturnServiceInfo', obj, function (form) {
        $(".hidden-div #BoxIndex").val("0");
        BoxIndex = layer.open({
            type: 1,
            title: '<img src="../Current/Icon/BlackOK.png" />&nbsp;处理完成再次提交',
            content: form,
            btn: ['确定'],
            shade: false,
            offset: ['100px', '30%'],
            area: ['350px', '300px'],
            zIndex: 19891013,
            maxmin: true,
            yes: function (index) {
                //触发表单的提交事件
                $('form.layui-form').find('button[lay-filter=edit]').click();
            },
            full: function (elem) {
                var win = window.top === window.self ? window : parent.window;
                $(win).on('resize', function () {
                    $('.layui-layer-max').css('display', 'none');
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
                    jQuery.axpost('../../api/Designer/StartProduction', JSON.stringify(data.field), function (dataInfo) {
                        layer.close(index);
                        layer.msg(dataInfo.Message);
                        var tab = parent.tab;
                        tab.deleteTab(tab.getCurrentTabId());
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
//#endregion 

//#region 提交生产,生产退回待处理
function SubmissionOrder(Id) {
    obj.Id = Id;
    obj.InspectionContext = $('#InspectionContext').val();
    if (obj.InspectionContext == "") {
        layer.msg("设计师备注为空!");
        return false;
    }
    layer.confirm('确认转客户确认吗？', null, function (index) {
        jQuery.axpost('../../api/Designer/StartProduction', JSON.stringify(obj), function (data) {
            layer.close(index);
            //btable.get();
            layer.msg(data.Message);
            var tab = parent.tab;
            tab.deleteTab(tab.getCurrentTabId());
        });
    })
}
//#endregion

//#region 确认准备生产
function ConfirmProduction(Id) {
    obj.Id = Id;
    obj.PrintParm = $("#PrintParm").val();
    if (obj.PrintParm == undefined || obj.PrintParm == "" ) {
        layer.msg("请填写印刷参数！");
        return;
    }
    layer.confirm('确认准备生产吗？', null, function (index) {
        jQuery.axpost('../../api/Designer/StartProduction', JSON.stringify(obj), function (data) {
            layer.close(index);
            //btable.get();
            layer.msg(data.Message);
            var tab = parent.tab;
            tab.deleteTab(tab.getCurrentTabId());
        });
    })
}
//#endregion

// #region 开始生产,待生产
function StartProduction(Id) {
    obj.Id = Id;
    layer.confirm('确认生产吗？', null, function (index) {
        jQuery.axpost('../../api/Designer/StartProduction', JSON.stringify(obj), function (data) {
            layer.close(index);
            layer.msg(data.Message);
            var tab = parent.tab;
            tab.deleteTab(tab.getCurrentTabId());
        });
    })
}
//#endregion

//#region 生产结束
function ProductionEnd(Id) {
    obj.Id = Id;
    layer.confirm('确认生产结束吗？', null, function (index) {
        jQuery.axpost('../../api/Designer/StartProduction', JSON.stringify(obj), function (data) {
            layer.close(index);
            //btable.get();
            layer.msg(dataInfo.Message);
            var tab = parent.tab;
            tab.deleteTab(tab.getCurrentTabId());
        });
    })
}
//#endregion

//#region 确认结束生产,生产中
function ProductionEnd(Id) {
    obj.Id = Id;
    layer.confirm('确认生产结束吗?', null, function (index) {
        jQuery.axpost('../../api/Designer/StartProduction', JSON.stringify(obj), function (data) {
            layer.close(index);
            //btable.get();
            layer.msg(data.Message);
            var tab = parent.tab;
            tab.deleteTab(tab.getCurrentTabId());
        });
    })
}
//#endregion

//#region 取消订单
function CancelOrder(Id) {
    obj.Id = Id;
    layer.confirm('确认取消订单吗?', null, function (index) {
        jQuery.axpost('../../api/Designer/ReturnService', JSON.stringify(obj), function (data) {
            layer.close(index);
            //btable.get();
            layer.msg(data.Message);
            var tab = parent.tab;
            tab.deleteTab(tab.getCurrentTabId());
        });
    })
}
//#endregion 

//#region生产领料单,待生产
function GenerateDeliver(Id) {
    parent.tab.tabAdd({
        href: '../Warehouses/ReceiveDetailed?Id=' + Id + "&Text=1",
        title: '领料单',
        Closeabled: true
    });
}
//#endregion

//#region查看领料单
function SeeDeliver(Id, see) {
    
    if (see != null && see != undefined) {
        parent.tab.tabAdd({
            href: '../Warehouses/ReceiveDetailed?Id=' + Id + "&Text=1",
            title: '领料单',
            Closeabled: true
        });
    }
    else {
        parent.tab.tabAdd({
            href: '../Warehouses/ReceiveDetailed?Id=' + Id + "&Text=1&See=1",
            title: '领料单',
            Closeabled: true
        });
    }

}
//#endregion

//#region 保存,生产退回待处理
function Preservation(Id) {
    obj.Id = Id;
    obj.InspectionContext = $('#InspectionContext').val();
    if (obj.InspectionContext == null || obj.InspectionContext == "" || obj.InspectionContext == undefined) {
        layer.msg('请输入备注，再进行保存');
        return;
    }
    layer.confirm('确认保存吗?', null, function (index) {
        jQuery.axpost('../../api/Designer/KeepProduction', JSON.stringify(obj), function (data) {
            layer.close(index);
            layer.msg(data.Message);
        });
    })
}
//#endregion

//#region 上传设计师信息
function UpdesignZip(Id) {
    obj.Id = Id;
    var index = layer.load(1);
    setTimeout(function () {
        layer.close(index);
    }, 5000);
    //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
    $.get('../../Designer/DesignerUpLoadDetail', obj, function (form) {
        layer.close(index);
        BoxIndex = layer.open({
            type: 1,
            title: '上传设计文件',
            content: form,
            btn: ['确定'],
            shade: false,
            offset: ['100px', '15%'],
            area: ['600px', '400px'],
            zIndex: 19891013,
            maxmin: false,
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
                    jQuery.axpost('../../api/Designer/DesignUpLoadFile', JSON.stringify(data.field), function (dataInfo) {
                        layer.msg(dataInfo.Message);
                        setTimeout(function () {
                            location.reload();
                        }, 2000);
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

//#region 生产计划分配
function PlannedDistribution(Id) {
    parent.tab.tabAdd({
        href: '../Designer/PlannedDistribution?Id=' + Id,
        title: '进度安排',
        Closeabled: true
    });
}
//#endregion 

//#region成品品检
//不合格
function ProductNoQualified(Id) {
    if (BoxIndex !== -1) {
        layer.msg("已有一个弹出窗口！");
        return;
    }
    obj.Id = Id;
    $.get('../Inspection/Raw_InspectionNoQualified', obj, function (form) {
        $(".hidden-div #BoxIndex").val("0");
        BoxIndex = layer.open({
            type: 1,
            title: '成品品检不合格',
            content: form,
            btn: ['确定'],
            shade: false,
            offset: ['100px', '30%'],
            area: ['350px', '300px'],
            zIndex: 19891013,
            maxmin: true,
            yes: function (index) {
                //触发表单的提交事件
                $('form.layui-form').find('button[lay-filter=edit]').click();
            },
            full: function (elem) {
                var win = window.top === window.self ? window : parent.window;
                $(win).on('resize', function () {
                    $('.layui-layer-max').css('display', 'none');
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
                    jQuery.axpost('../../api/Inspection/ProductQualified', JSON.stringify(data.field), function (dataInfo) {
                        layer.close(index);
                        layer.msg(dataInfo.Message);
                        // pagingFunc.reload();
                    });

                    //这里可以写ajax方法提交表单
                    return false; //阻止表单跳转。如果需要表单跳转，去掉这段即可。
                });
                //console.log(layero, index);
            }
        });
    });
}
//合格
function ProductQualified(Id) {
    layer.confirm('确定为合格？', {
        btn: ['确定']
    }, function (index) {
        var obj = new Object();
        obj.Id = Id;
        jQuery.axpost('../../api/Inspection/ProductQualified', JSON.stringify(obj), function (dataInfo) {
            layer.close(index);
            layer.msg(dataInfo.Message);
            var tab = parent.tab;
            tab.deleteTab(tab.getCurrentTabId());
        });
        layer.close(index);
    });
}
//#endregion

//#region 立即发货
function ConsignmentInfo(Id) {
    var index = layer.load(1);
    obj.Id = Id;
    $.get('../../Consignment/ConsigneeInfo', obj, function (form) {
        layer.close(index);
        BoxIndex = layer.open({
            type: 1,
            title: '<i class="layui-icon">&#xe642;</i>&nbsp;填写收件人信息',
            content: form,
            btn: ['发货', '关闭'],
            shade: false,
            offset: ['100px', '30%'],
            area: ['440px', '520px'],
            zIndex: 19891013,
            maxmin: false,
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
                    jQuery.axpost('../../api/Consignment/ExpressInfo', JSON.stringify(data.field), function (data) {
                        layer.close(index);
                        layer.msg(data.Message);
                        var tab = parent.tab;
                        tab.deleteTab(tab.getCurrentTabId());
                    });
                    return false;
                });
            },
            end: function () {
                BoxIndex = -1;
            }
        });
    });
}
//#endregion

//#region 打印快递单
function PrintExpress() {
    layer.confirm('确认打印快递单吗？', null, function (index) {
        var countstr = document.getElementById("Div1").innerHTML;
        var newstr = document.getElementById("PrintDiv").innerHTML;
        var oldstr = document.body.innerHTML;
        document.body.innerHTML = newstr;
        var tata = document.execCommand("print");/* window.print(); 调用打印的功能*/
        if (tata) {  //点击取消后执行的操作
            document.body.innerHTML = countstr;
            window.location.reload();
        }
    })
}
//#endregion

//#region 关闭
function CloseBtn() {
    var tab = parent.tab;
    tab.deleteTab(tab.getCurrentTabId());
}
//#endregion
