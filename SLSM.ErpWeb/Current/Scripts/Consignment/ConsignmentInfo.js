layui.config({
    base: '../../../Base/js/',
    v: new Date().getTime()+"123",
    checkbox: true
}).use(['btable', 'form'], function () {
    var btable = layui.btable(),
        $ = layui.jquery,
        layerTips = parent.layer === undefined ? layui.layer : parent.layer, //获取父窗口的layer对象
        layer = layui.layer,//获取当前窗口的layer对象;
        form = layui.form();
    var BoxIndex = -1;
    btable.set({
        openWait: true,//开启等待框
        elem: '#content',
        url: '../../../APi/Table/GetConsignmentInfo', //数据源地址
        pageSize: 12,//页大小
        params: {//额外的请求参数
            t: new Date().getTime()
        },
        columns: [ //列名
            { //配置数据列
                fieldName: '订单编号', //显示名称
                field: 'OrderNo', //字段名
                sortable: true,//是否显示排序
                width: "12%",
                 format: function (val, obj) {
                     if (obj.OrderStatus == "品检合格待发货") {
                         var html = '<img src="../Current/Icon/BlueList.png" />&nbsp;' + obj.OrderNo + '';
                    }
                    else {
                         var html = '<img src="../Current/Icon/WhiteList.png" />&nbsp;' + obj.OrderNo + '';
                    }
                    return html;
                }
            },
            {
                fieldName: '时间',
                field: 'OrderTime',
                sortable: true,
                width: "18%"
            },
            {
                fieldName: '状态',
                field: 'Status',
                sortable: true,
                width: "13%",
                format: function (val, obj) {
                    if (obj.OrderStatus == "品检合格待发货") {
                        var html = '<label style="color:#31a7fe;">' + obj.OrderStatus + '</label>';
                    }
                     else {
                        var html = '<label>' + obj.OrderStatus + '</label>';
                    }
                    return html;
                }
            },
            {
                fieldName: '用户姓名',
                field: 'userName',
                width: "12%"
            },
            {
                fieldName: '电话',
                field: 'Phone',
                width: "14%"
            },
            {
                fieldName: '产品名称',
                field: 'commodityName',
                sortable: true,
                width: "16%"
            },
            {
                fieldName: '产品编号',
                field: 'commodityId',
                sortable: true,
                width: "12%"
            },
            {
                fieldName: '订单数量',
                field: 'Amount',
                sortable: true,
                width: "13%"
            },
            {
                fieldName: '交货日期',
                field: 'deliveryTime',
                sortable: true,
                width: "16%"
            },
            
            {
                fieldName: '操作',
                field: 'Ids',
                format: function (val, obj) {     
                    if (obj.OrderStatus == "品检合格待发货") {
                        var html = '<button type="button" data-action="detailed" data-id="' + val + '" class="layui-btn layui-btn-mini"><img src="../Current/Icon/DetailBcakGreen.png" />&nbsp; 发货</button>'
                    } else {
                        var html = '<button type="button" data-action="LookDetailed" data-id="' + val + '" class="layui-btn layui-btn-mini"><img src="../Current/Icon/DetailBcakGreen.png" />&nbsp; 查看详情</button>';
                    }
                    return html;
                                                                     
                },
                width: "10%"
            }
        ],
        even: false,//隔行变色
        field: 'Id', //主键ID
        // skin: 'row',
        checkbox: false,//是否显示多选框
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
                        var Id = $that.parent().parent().find('input[name="id"]').val();
                        if (BoxIndex !== -1) {
                            layer.msg("已有一个弹出窗口！");
                            return;
                        }
                        switch (action) {
                            //#region 立即发货
                            case 'detailed':
                                var index = layer.load(1);
                                var obj = new Object();
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
                                        area: ['500px', '570px'],
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
                                                btable.ajaxPost('../../api/Consignment/ExpressInfo', JSON.stringify(data.field), function (data) {
                                                    layer.close(index);
                                                    layer.msg(data.Message);
                                                    location.reload();
                                                });
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
                            case 'LookDetailed':
                                var index = layer.load(1);
                                var obj = new Object();
                                obj.Id = Id;
                                $.get('../../Consignment/ConsigneeInfo', obj, function (form) {
                                    layer.close(index);
                                    BoxIndex = layer.open({
                                        type: 1,
                                        title: '<i class="layui-icon">&#xe642;</i>&nbsp;查看收件人信息',
                                        content: form,
                                        btn: ['关闭'],
                                        shade: false,
                                        offset: ['100px', '30%'],
                                        area: ['500px', '570px'],
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
                                        end: function () {
                                            BoxIndex = -1;
                                        }
                                    });
                                });
                                break;
                        }
                    });
                });
            });
        },
        dbclicktext: "LookDetailed"
    });


    form.on('select', function (data) {
        var obj = new Object();
        obj.Production = $("select[name='Production']").val();
        btable.get(obj);
        return false;
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
