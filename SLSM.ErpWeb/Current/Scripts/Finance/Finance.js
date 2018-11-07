var btable;
layui.config({
    base: '../../../Base/js/',
    v: new Date().getTime()+"123",
    //checkbox: true
}).use(['btable', 'form'], function () {
    var $ = layui.jquery,
        layerTips = parent.layer === undefined ? layui.layer : parent.layer, //获取父窗口的layer对象
        layer = layui.layer,//获取当前窗口的layer对象;
        form = layui.form();
    btable = layui.btable();
    BoxIndex = -1;
    btable.set({
        openWait: true,//开启等待框
        elem: '#content',
        url: '../../../APi/Table/GetFinance', //数据源地址
        pageSize: 13,//页大小
        params: {//额外的请求参数
            t: new Date().getTime()
        },
        columns: [
            { //配置数据列
                fieldName: '订单编号', //显示名称
                field: 'BuyerNo', //字段名
                sortable: true,//是否显示排序              
                width: "10%"
            },
            {
                fieldName: '供应商',
                field: 'Name',
                sortable: true,
                width: "15%"
            },
            {
                fieldName: '采购周期',
                field: 'AccountPeriod',
                sortable: true,
                width: "10%"
            },
            {
                fieldName: '采购日期',
                field: 'buyerTime',
                sortable: true,
                width: "10%"

            },
            {
                fieldName: '应付日期',
                field: 'wantTime',
                sortable: true,
                width: "10%"

            },
            {
                fieldName: '合同账款',
                field: 'buyerMoney',
                sortable: true,
                width: "10%"
            },
            {
                fieldName: '入库账款',
                field: 'AmountOfWare',
                sortable: true,
                width: "12%"
            },
            {
                fieldName: '已付账款',
                field: 'wantmoney',
                sortable: true,
                width: "12%"
            },
            {
                fieldName: '操作',
                field: 'Ids',
                format: function (val, obj) {
                    if (obj.wantmoney < obj.buyerMoney) {
                        var html = '<button type="button" data-action="Finance" data-id="' + val + '" class="layui-btn layui-btn-mini"><img src="../Current/Icon/CashBackGreen.png" />&nbsp;付款</button>';
                    } else {
                        html = "";
                    }
                    if (obj.wantTime == "暂无时间") {
                        var html1 = '<button type="button" class="layui-btn layui-btn-mini" data-action="InvoiceAdd" style="background-color:#393D49;"><img src="../Current/Icon/CashIn.png" />&nbsp; 发票录入</button>';
                    } else {
                        html1 = "";
                    }

                    return html + html1;
                },
                width: "14%"
            }
        ],
        even: false,//隔行变色
        field: 'Id', //主键ID
        //skin: 'row',
        checkbox: true,//是否显示多选框
        paged: true, //是否显示分页
        singleSelect: false, //只允许选择一行，checkbox为true生效
        SerialNumber: false,//是否有序号
        onSuccess: function ($elem) { //$elem当前窗口的jq对象
            $elem.children('tr').each(function () {
                $(this).children('td').children('button').each(function () {
                    var $that = $(this);
                    var action = $that.data('action');
                    var id = $that.data('id');
                    $that.on('click', function () {
                        var Id = $that.parent().parent().find('input').data('id');
                        if (BoxIndex !== -1) {
                            layer.msg("已有一个弹出窗口！");
                            return;
                        }
                        switch (action) {

                            //#region 付款
                            case 'Finance':
                                var index = layer.load(1);
                                var obj = new Object();
                                obj.Id = Id;
                                $.get('../../Finance/FinanceInfo', obj, function (form) {
                                    layer.close(index);
                                    BoxIndex = layer.open({
                                        type: 1,
                                        title: '<img src="../Current/Icon/BlackCash.png" />&nbsp;付款',
                                        content: form,
                                        btn: ['确定'],
                                        shade: false,
                                        offset: ['150px', '40%'],
                                        area: ['300px', '180px'],
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
                                                var ss = data.field.WantMoney;
                                                btable.ajaxPost('../../api/Finance/FinanceMoney', JSON.stringify(data.field), function (data) {
                                                    layer.close(index);
                                                    btable.get();
                                                    layer.msg(data.Message);
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
                                break;
                            //#endregion

                            //#region 发票录入
                            case 'InvoiceAdd':
                                var index = layer.load(1);
                                var obj = new Object();
                                obj.OrderId = Id;
                                $.get('../../Finance/EntryInvoice', obj, function (form) {
                                    layer.close(index);
                                    BoxIndex = layer.open({
                                        type: 1,
                                        title: '<img src="../Current/Icon/BlackPan.png" />发票录入',
                                        content: form,
                                        btn: ['录入'],
                                        shade: false,
                                        offset: ['100px', '15%'],
                                        area: ['870px', '530px'],
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
                                                data.field.province = $('div [name="province"]').parent().find('input').val();
                                                data.field.city = $('div [name="city"]').parent().find('input').val();
                                                data.field.area = $('div [name="area"]').parent().find('input').val();
                                                btable.ajaxPost('../../api/Finance/UpDateInvoice', JSON.stringify(data.field), function (dataInfo) {
                                                    layer.close(index);
                                                    btable.get();
                                                    layer.msg(dataInfo.Message);
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
                                break;
                            //#endregion
                        }
                    })
                });
            });
        },
        dbclicktext: "Finance"
    });

    btable.render();

    //#region 筛选
    //供应商选择
    form.on('select', function (data) {
        getInfo();
        RefashCash();
        return false;
    });
    //采购日期显示
    layui.use(['form', 'layedit', 'laydate'], function () {
        var form = layui.form(),
            layer = layui.layer,
            layedit = layui.layedit,
            laydate = layui.laydate;
    });
    //采购日期
    $("#Time1 input,#Time2 input").click(function () {
        layui.laydate({
            elem: this,
            choose: function (datas) {
                getInfo();

            }
        })

    })
    //选择显示
    function getInfo() {
        var obj = new Object();
        obj.StartTime = $("#Time1 input").val();
        obj.EndTime = $("#Time2 input").val();
        obj.ProduterId = $("select[name='ProduterId']").val();
        obj.CheckStatus = "";
        $(".aaa input[type='checkbox']").each(function () {
            if ($(this)[0].checked) {
                obj.CheckStatus += $(this).val() + "|";
            }
        })
        if (obj.StartTime != "" && obj.EndTime != "") {
            if (obj.EndTime <= obj.StartTime) {
                layer.msg("时间选择错误!");
                return;
            }
        }
        btable.get(obj);
        RefashCash()
    }
    //#endregion

    //监听搜索表单的提交事件
    form.on('submit(search)', function (data) {
        btable.get(data.field);
        RefashCash()
        return false;
    });
    form.on('select(StatusType)', function (data) {
        $("#submit_btn").trigger('click');

    });
    //账款
    function RefashCash() {
        setTimeout(function () {
            
        }, 2000)
    }
    $(window).on('resize', function (e) {
        var $that = $(this);
        $('#content').height($that.height() - 92);
    }).resize();
});

function Rebind() {
    //付款
    $("#InvoicePay").unbind();
    $("#InvoicePay").click(function () {
        Rebind();
        var index = layer.load(1);
        var obj = new Object();
        var OrderID = "";
        $("input[type='checkbox']").each(function () {
            var check = $(this)[0].checked;
            var Id = $(this).attr('data-id');
            if (Id != undefined && check == true) {
                OrderID = OrderID + Id + ",";
            }
        })
        obj.Id = OrderID;
        if (OrderID == "") {
            layer.msg("请选择订单");
            layer.close(index);
            return;
        }
        $.get('../../Finance/FinanceInfo', obj, function (form) {
            layer.close(index);
            BoxIndex = layer.open({
                type: 1,
                title: '<img src="../Current/Icon/BlackCash.png" />&nbsp;付款',
                content: form,
                btn: ['确定'],
                shade: false,
                offset: ['150px', '40%'],
                area: ['300px', '180px'],
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
                        var ss = data.field.WantMoney;
                        jQuery.axpost('../../api/Finance/FinanceMoney', JSON.stringify(data.field), function (data) {
                            layer.close(index);
                            btable.reload();
                            layer.msg(data.Message);
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
    })

    //发票录入
    $("#InvoiceAdd").unbind();
    $("#InvoiceAdd").click(function () {
        Rebind();
        var index = layer.load(1);
        var obj = new Object();
        var OrderID = "";
        $("input[type='checkbox']").each(function () {
            var check = $(this)[0].checked;
            var Id = $(this).attr('data-id');
            if (Id != undefined && check == true) {
                OrderID = OrderID + Id + ",";
            }
        })
        obj.OrderId = OrderID;
        $.get('../../Finance/EntryInvoice', obj, function (form) {
            layer.close(index);
            if (form.length < 30) {
                layer.msg(form);
                return;
            }
            BoxIndex = layer.open({
                type: 1,
                title: '<img src="../Current/Icon/BlackPan.png" />发票录入',
                content: form,
                btn: ['录入'],
                shade: false,
                offset: ['100px', '15%'],
                area: ['870px', '530px'],
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
                        data.field.province = $('div [name="province"]').parent().find('input').val();
                        data.field.city = $('div [name="city"]').parent().find('input').val();
                        data.field.area = $('div [name="area"]').parent().find('input').val();
                        jQuery.axpost('../../api/Finance/UpDateInvoice', JSON.stringify(data.field), function (dataInfo) {
                            layer.close(index);
                            btable.reload();
                            layer.msg(dataInfo.Message);
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
    })
}
Rebind();