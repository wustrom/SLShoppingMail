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
    var BoxIndex = -1;
    btable.set({
        openWait: true,//开启等待框
        elem: '#content',
        url: '../../../APi/Table/GetProduction', //数据源地址
        pageSize: 18,//页大小
        params: {//额外的请求参数
            t: new Date().getTime()
        },
        columns: [
            { //配置数据列
                fieldName: '订单编号', //显示名称
                field: 'OrderNo', //字段名
                sortable: true,//是否显示排序
                format: function (val, obj) {
                    if (obj.ProductionStatus == "待生产确认") {
                        var html = '<label><img src="/current/Icon/BlueList.png" style="width: 18px;margin-top: -1px;float: left;">&nbsp;' + obj.OrderNo + '</label>';
                    }
                    else if (obj.ProductionStatus == "待生产") {
                        var html = '<label><img src="/current/Icon/ReadList.png" style="width: 18px;margin-top: -1px;float: left;">&nbsp;' + obj.OrderNo + '</label>';
                    } else if (obj.ProductionStatus == "生产中") {
                        var html = '<label><img src="/current/Icon/GreenList2.png" style="width: 18px;margin-top: -1px;float: left;">&nbsp;' + obj.OrderNo + '</label>';
                    }
                    else {
                        var html = '<label><img src="/current/Icon/whiteList.png" style="width: 18px;margin-top: -1px;float: left;  ">&nbsp;' + obj.OrderNo + '</label>';
                    }
                    return html;
                },
                width: "13%"
            }, {
                fieldName: '时间',
                field: 'OrderTime',
                sortable: true,
                width: "11%"
            }, {
                fieldName: '状态',
                field: 'ProductionStatus',
                sortable: true,
                format: function (val, obj) {
                    if (obj.ProductionStatus == "待生产确认") {
                        var html = '<label style="color:#7cc0ff;">' + obj.ProductionStatus + '</label>';
                    }
                    else if (obj.ProductionStatus == "待生产") {
                        var html = '<label style="color:#ff663a;">' + obj.ProductionStatus + '</label>';
                    } else if (obj.ProductionStatus == "生产中")
                    {
                        var html = '<label style="color:#1aa193;">' + obj.ProductionStatus + '</label>';
                    }
                    else {
                        var html = '<label style="color:black;">' + obj.ProductionStatus + '</label>';
                    }
                    return html;
                },
                width: "13%"
            },
            {
                fieldName: '订单类型',
                field: 'OrderType',
                sortable: true,
                width: "10%"
            },
            {
                fieldName: '用户姓名',
                field: 'userName',
                sortable: true,
                width: "10%"

            },
            {
                fieldName: '电话',
                field: 'Phone',
                sortable: true,
                width: "12%"

            },
            {
                fieldName: '商品名称',
                field: 'commodityName',
                sortable: true,
                width: "12%"
            },
            {
                fieldName: '产品货号',
                field: 'commodityId',
                sortable: true,
                width: "10%"
            },
            {
                fieldName: '订单数量',
                field: 'Amount',
                sortable: true,
                width: "9%"
            },
            {
                fieldName: '交货日期',
                field: 'deliveryTime',
                sortable: true,
                width: "11%"
            },
            {
                fieldName: '操作',
                field: 'Ids',
                format: function (val, obj) {
                    var html = '<button type="button" data-action="Detailed" data-id="' + val + '" class="layui-btn layui-btn-mini">查看详情</button>';
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
                            //#region 查看详情
                            case 'Detailed':
                                var OrderText = $('#OrderText').val();
                                parent.tab.tabAdd({
                                    href: '../Designer/ProductionInfo?Id=' + Id + '&OrderText=' + OrderText,
                                    title: '生产详情',
                                    Closeabled: true
                                });
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


    form.on('select', function (data) {
        var obj = new Object();
        obj.Production = $("select[name='Production']").val();
        btable.get(obj);
        return false;
    });
});