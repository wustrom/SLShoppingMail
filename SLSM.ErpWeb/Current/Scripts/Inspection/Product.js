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
        url: '../../../APi/Table/GetProductInfo', //数据源地址
        pageSize: 18,//页大小
        params: {//额外的请求参数
            t: new Date().getTime()
        },
        columns: [ //列名
            { //配置数据列
                fieldName: '订单编号', //显示名称
                field: 'OrderNo', //字段名
                sortable: true,//是否显示排序
                width: "10%"
            }, {
                fieldName: '时间',
                field: 'OrderTime',
                sortable: true,
                width: "18%"
            },
            {
                fieldName: '状态',
                field: 'InspectionStatus',
                sortable: true,
                width: "13%",
                format: function (val, obj) {
                    if (obj.InspectionStatus == "生产完成待品检") {
                        var html = '<label style="color:#31a7fe;">' + obj.InspectionStatus + '</label>';
                    }
                    else if (obj.InspectionStatus == "成品品检合格") {
                        var html = '<label style="color:#179186;">' + obj.InspectionStatus + '</label>';
                    } else {
                        var html = '<label style="color:red">' + obj.InspectionStatus + '</label>';
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
                    var html = '<button type="button" data-action="detailed" data-id="' + val + '" class="layui-btn layui-btn-mini"><i class="layui-icon">&#xe60a;</i>查看详情</button>';
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
                            // #region 查看详情
                            case 'detailed':
                                var Text = $('#ProductText').val();
                                parent.tab.tabAdd({
                                    href: '../Designer/ProductionInfo?Id=' + Id + '&text=' + Text + '&FinishedProduct=1',
                                    title: '品检详情',
                                    Closeabled: true
                                });
                                // #endregion
                                break;
                        }
                    });
                });
            });
        },
        dbclicktext: "detailed"

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
