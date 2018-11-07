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
        url: '../../../APi/Table/GetStorageBuyerInfo', //数据源地址
        pageSize: 18,//页大小
        params: {//额外的请求参数
            t: new Date().getTime()
        },
        columns: [
            { //配置数据列
                fieldName: 'SKU#', //显示名称
                field: 'SKU', //字段名
                sortable: true,//是否显示排序
                width: "100px",
                format: function (val, obj) {
                    if (obj.stock <= obj.MinStockNum) {
                        var html = '<a herf="javascript:;" title="库存量不足"><img src="/current/Icon/RedDanger.png" style="width: 18px;margin-top: -1px;float:left;"></a>' + obj.SKU + '';
                    } else {
                        var html = '<label>' + obj.SKU + '</label>';
                    }
                    return html;
                }
            }, {
                fieldName: '产品货号',
                field: 'ProductNo',
                sortable: true,
                width: "170px"
            },
            {
                fieldName: '中文品名',
                field: 'ChinaProductName',
                sortable: true,
                width: "170px"
            },

            {
                fieldName: '颜色',
                field: 'Color',
                sortable: true,
                width: "170px"
            },
            {
                fieldName: '中文单位',
                field: 'ChinaUnit',
                width: "170px"
            },
            {
                fieldName: '总库存',
                field: 'stock',
                width: "40px"
            },
            {
                fieldName: '冻结库存',
                field: 'freeze_stock',
                width: "40px"
            },
            {
                fieldName: '最小库存',
                field: 'MinStockNum',
                width: "40px"
            },
            {
                fieldName: '详细信息',
                field: 'Raw_materialsId',
                format: function (val, obj) {
                    var html = '<button type="button" data-action="Detailed" data-material="' + obj.MaterialId + '" data-id="' + obj.Raw_materialsId + '" class="layui-btn layui-btn-small"" style="background-color:white"> <img src="../Current/Icon/GreenDetail.png" /></button>';
                    return html;
                },
                width: "100px"
            },
            {
                fieldName: '操作',
                field: 'Id',
                format: function (val, obj) {
                    var html = '<a type="button" value="" data-action="AddCart" data-id="' + val + '" class="layui-btn layui-btn-mini" >\
                                   <img src="../Current/Icon/GreenShopCart.jpg" style="width:13px;margin-top: -2px;"/>&nbsp;加入采购列表\
                                </a>';
                    return html;
                },
                width: "100px"
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
                // #region 最后一列
                $(this).children('td:last-child').children('a').each(function () {
                    var $that = $(this);
                    var action = $that.data('action');
                    var id = $that.data('id');
                    $that.on('click', function () {
                        var Id = $that.data('id');
                        if (BoxIndex !== -1) {
                            layer.msg("已有一个弹出窗口！");
                            return;
                        }
                        var obj = new Object();
                        obj.Id = Id;
                        switch (action) {
                            // #region 查看按钮
                            case 'AddCart':
                                //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
                                $.get('../../Material/BuyMaterial', obj, function (form) {
                                    BoxIndex = layer.open({
                                        type: 1,
                                        title: '<img src="/Current/Icon/Cart.png">加入采购列表',
                                        content: form,
                                        btn: ['加入采购列表'],
                                        shade: false,
                                        offset: ['100px', '15%'],
                                        area: ['857px', '500px'],
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
                                                btable.ajaxPost('../../api/Material/BuyMaterial', JSON.stringify(data.field), function (dataInfo) {
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
                            // #endregion
                        }
                    });
                });
                // #endregion

                // #region 倒数第二列
                $(this).children('td:nth-last-child(2)').children('button').each(function () {
                    var $that = $(this);
                    var action = $that.data('action');
                    var id = $that.data('id');
                    
                    
                    $that.on('click', function () {
                        var MaterialId = $that.data('material');
                        if (BoxIndex !== -1) {
                            layer.msg("已有一个弹出窗口！");
                            return;
                        }
                        var obj = new Object();
                        obj.Id = MaterialId;
                        switch (action) {
                            // #region 查看按钮
                            case 'Detailed':
                                //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
                                var index = layer.load(1);
                                //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
                                $.get('../../Material/MaterialDetail', obj, function (form) {
                                    layer.close(index);
                                    BoxIndex = layer.open({
                                        type: 1,
                                        title: '<img src="/Current/Icon/search.png" style="height:20px;margin-top: -5px;">详细信息',
                                        content: form,
                                        shade: false,
                                        offset: ['100px', '15%'],
                                        area: ['920px', '500px'],
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
                            // #endregion
                        }
                    });
                });
                // #endregion
            });
        },
        dbclicktext: "AddCart"
    });
    btable.render();

    form.on('select(Produter)', function (data) {
        var obj = new Object();
        obj.ProduterId = $('#ProduterId').val();
        obj.t = new Date().getTime();
        btable.get(obj);
    });
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
