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
        url: '../../../APi/Table/GetBuyerInfo', //数据源地址
        pageSize: 14,//页大小
        params: {//额外的请求参数
            t: new Date().getTime()
        },
        columns: [ //列名
            { //配置数据列
                fieldName: '采购单编号', //显示名称
                field: 'BuyerNo', //字段名
                sortable: true,//是否显示排序
                width: "10%"
            }, {
                fieldName: '供应商',
                field: 'Name',
                sortable: true,
                width: "18%"
            },
            {
                fieldName: '采购日期',
                field: 'buyerTime',
                sortable: true,//是否显示排序
                width: "15%"
            },
            {
                fieldName: '状态',
                field: 'buyerStatus',
                sortable: true,//是否显示排序
                width: "12%",
                format: function (val, obj) {
                    if (obj.buyerStatus == "待入库") {
                        var html = '<label style="color:#49acff;">' + obj.buyerStatus + '</label>';
                    }
                    else {
                        var html = '<label style="color:#179186;">' + obj.buyerStatus + '</label>';
                    }
                    return html;
                }
            },
            {
                fieldName: '操作',
                field: 'Ids',
                format: function (val, obj) {
                    var html = '<button type="button" data-action="detailed" data-id="' + val + '" class="layui-btn layui-btn-small"><img src="../Current/Icon/DetailBcakGreen.png" />&nbsp;查看详情</button>';
                    return html;
                },
                width: "15%"
            }
        ],
        even: false,//隔行变色
        field: 'Id', //主键ID
        // skin: 'row',
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
                            // #region 查看详情
                            case 'detailed':
                                parent.tab.tabAdd({
                                    href: '../Warehouses/BuyerDetailed?Id=' + Id, //地址
                                    title: '入库详情',
                                    Closeabled: true
                                });
                                break;
                            // #endregion
                        }
                    });
                });
            });
        },
        dbclicktext: "detailed"
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
