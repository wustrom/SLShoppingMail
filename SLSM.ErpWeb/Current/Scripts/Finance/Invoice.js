layui.config({
    base: '../../../Base/js/',
    v: new Date().getTime()+"123",
    //checkbox: true
}).use(['btable', 'form'], function () {
    var btable = layui.btable(),
        $ = layui.jquery,
        layerTips = parent.layer === undefined ? layui.layer : parent.layer, //获取父窗口的layer对象
        layer = layui.layer,//获取当前窗口的layer对象;
        form = layui.form();
    var ProduterSelectId = $('input[name="ProduterSelectId"]').val();
    var BoxIndex = -1;
    btable.set({
        openWait: true,//开启等待框
        elem: '#content',
        url: '../../../APi/Table/GetInvoice?ProduterSelectId=' + ProduterSelectId, //数据源地址
        pageSize: 14,//页大小
        params: {//额外的请求参数
            t: new Date().getTime()
        },
        columns: [
            {
                fieldName: '发票号码',
                field: 'InvoiceNumber',
                sortable: true,
                width: "13%"
            },
            {
                fieldName: '开票时间',
                field: 'InvoiceTime',
                sortable: true,
                width: "13%"
            },
            {
                fieldName: '单位名称',
                field: 'CompanyName',
                width: "10%"
            },
            {
                fieldName: '联系电话',
                field: 'InvoicePhone',
                width: "12%"

            },
            {
                fieldName: '地址',
                field: 'InvoiceAddress',
                width: "17%"

            },
            {
                fieldName: '开户银行',
                field: 'InvoiceBank',
                width: "15%"
            },
            {
                fieldName: '金额',
                field: 'InvoiceMoney',
                sortable: true,
                width: "10%"
            },
            {
                fieldName: '所属供应商',
                field: 'Name',
                width: "11%"
            },
            {
                fieldName: '备注',
                field: 'InvoiceContext',
                width: "10%"
            },
            {
                fieldName: '操作',
                field: 'Ids',
                format: function (val, obj) {
                    var html = '<button type="button" data-action="Detailed" data-id="' + val + '" class="layui-btn layui-btn-small" style="background-color:white"><img src="../Current/Icon/GreenDetail.png" />&nbsp;</button><button style="background-color:white" type="button" data-action="Delete" data-id="' + val + '" class="layui-btn layui-btn-small"><img src="../Current/Icon/GreenDustBin.png" />&nbsp;</button>';
                    return html;
                },
                width: "10%"
            }],
        even: false,//隔行变色
        field: 'Id', //主键ID
        //skin: 'row',
        checkbox: false,//是否显示多选框
        paged: true, //是否显示分页
        singleSelect: false, //只允许选择一行，checkbox为true生效
        SerialNumber: true,//是否有序号
        onSuccess: function ($elem) { //$elem当前窗口的jq对象
            $elem.children('tr').each(function () {
                $(this).children('td').children('button').each(function () {
                    var $that = $(this);
                    var action = $that.data('action');
                    var id = $that.data('id');
                    $that.on('click', function () {
                        var Id = $that.parent().parent().find('input[name="id"]').val();
                        if (BoxIndex !== -1) {
                            layer.msg("已有一个弹出窗口！");
                            return;
                        }
                        switch (action) {
                            //#region 修改发票
                            case 'Detailed':
                                var index = layer.load(1);
                                var obj = new Object();
                                obj.Id = Id;
                                $.get('../../Finance/EditEntryInvoice', obj, function (form) {
                                    layer.close(index);
                                    BoxIndex = layer.open({
                                        type: 1,
                                        title: '<img src="../Current/Icon/BlackCash.png" />&nbsp;修改发票',
                                        content: form,
                                        btn: ['确定'],
                                        shade: false,
                                        offset: ['120px', '20%'],
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
                                                elem.children('div.layui-layer-content').height($this.height() - 80);
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
                                                return false; 
                                            });
                                        },
                                        end: function () {
                                            BoxIndex = -1;
                                        }
                                    });
                                });
                                break;
                            //#endregion

                            // #region 删除
                            case 'Delete':
                                layer.confirm('确定删除发票记录？', null, function (index) {
                                    var obj = new Object();
                                    obj.Id = Id;
                                    btable.ajaxPost('../../api/Finance/DelInvoice', JSON.stringify(obj), function (dataInfo) {
                                        layer.close(index);
                                        btable.get();
                                        layer.msg(dataInfo.Message);
                                    });
                                    layer.close(index);
                                });
                                break;
                            //#endregion
                        }
                    })
                });
            });
        },
        dbclicktext: "Detailed"
    });

    btable.render();

    //监听搜索表单的提交事件
    form.on('submit(search)', function (data) {
        btable.get(data.field);
        return false;
    });
    form.on('select(StatusType)', function (data) {
        $("#submit_btn").trigger('click');
    });

    $(window).on('resize', function (e) {
        var $that = $(this);
        $('#content').height($that.height() - 92);
    }).resize();
});





