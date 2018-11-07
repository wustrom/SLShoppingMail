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
// #region 不合格
function NoQualified(Id) {
    if (BoxIndex !== -1) {
        layer.msg("已有一个弹出窗口！");
        return;
    }
    obj.Id = Id;
    var DeliverCompany = $('#DeliverCompany').html().trim();
    if (DeliverCompany == null || DeliverCompany == "" || DeliverCompany == undefined) {
        layer.msg("物流公司不能为空！");
    }
    var DeeliverExpressNo = $('#DeeliverExpressNo').html().trim();
    if (DeeliverExpressNo == null || DeeliverExpressNo == "" || DeeliverExpressNo == undefined) {
        layer.msg("快递单号不能为空！");
    }
    //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
    $.get('../Inspection/Raw_InspectionNoQualified', obj, function (form) {
        $(".hidden-div #BoxIndex").val("0");
        BoxIndex = layer.open({
            type: 1,
            title: '<img src="/Current/Icon/ReturnCustomer.png" style="margin-top: -3px;margin-right: 5px;">品检不合格',
            content: form,
            btn: ['确定'],
            shade: false,
            offset: ['200px', '30%'],
            area: ['400px', '250px'],
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
                    jQuery.axpost('../../api/Inspection/InspectionQualified', JSON.stringify(data.field), function (dataInfo) {
                        layer.close(index);
                        layer.msg(dataInfo.Message);
                        location.reload();
                        //#region 样式
                        if (dataInfo.HttpCode = 200) {
                            $('#qualified').attr('disabled', true);
                            $('#qualified').css('display', 'none');
                            $('#NoQualified').attr('disabled', true);
                            $('#NoQualified').css('display', 'none');
                            $('#checkStatus').html("品检不合格");
                            $('#buyerStatus').html("待退货");
                            $('.layui-textarea').val('' + data.field.buyerContext + '');
                        }
                        //#endregion

                        // pagingFunc.reload();
                    });

                    //这里可以写ajax方法提交表单
                    return false; //阻止表单跳转。如果需要表单跳转，去掉这段即可。
                });
                console.log(layero, index);
            },
            end: function () {
                BoxIndex = -1;
            }
        });
    });
}
// #endregion

//#region 合格
function qualified(Id) {
    obj.Id = Id;
    layer.confirm('确认合格吗？', null, function (index) {
        jQuery.axpost('../../api/Inspection/InspectionQualified', JSON.stringify(obj), function (data) {
            layer.msg(data.Message);
            location.reload();
            //#region 样式
            if (data.HttpCode = 200) {
                $('#qualified').attr('disabled', true);
                $('#qualified').css('display', 'none');
                $('#NoQualified').attr('disabled', true);
                $('#NoQualified').css('display', 'none');
                $('#checkStatus').html("品检合格");
                $('#buyerStatus').html("待入库");
                location.reload();
            }
            //#endregion

            //  pagingFunc.reload();
            layer.close(index);
        });
    })
}
//#endregion

//#region 打印送货单
function PrintDeliver(Id) {
    obj.Id = Id;
    obj.DeliverSinglePerson = $('#DeliverSinglePerson').html();
    obj.DeliverCompany = $('#DeliverCompany').val();
    if (obj.DeliverCompany == "" || obj.DeliverCompany == null || obj.DeliverCompany == undefined) {
        layer.msg("请先填写快递公司！");
        return;
    }
    obj.DeeliverExpressNo = $('#DeeliverExpressNo').val();
    if (obj.DeliverCompany == "" || obj.DeliverCompany == null || obj.DeliverCompany == undefined) {
        layer.msg("请先填写快递单号！");
        return;
    }
    $('input').css("width", "125px");
    
    layer.confirm('确认打印送货单吗？', null, function (index) {
        var IsDeliverCompany = $('#IsDeliverCompany').val();
        if (IsDeliverCompany == "" || IsDeliverCompany == null) {
            jQuery.axpost('../../api/Material/PrintDeliver', JSON.stringify(obj), function (data) {
                //layer.msg(data.Message);

            })
        }
        //打印
        var countstr = document.getElementById("Div1").innerHTML;
        var newstr = document.getElementById("TableDiv").innerHTML;
        var oldstr = document.body.innerHTML;
        document.body.innerHTML = newstr;
        $('#DeliverCompany').val(obj.DeliverCompany);
        $('#DeeliverExpressNo').val(obj.DeeliverExpressNo);
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