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
        url: '../../../APi/Table/GetStorageInfo', //数据源地址
        pageSize: 14,//页大小
        params: {//额外的请求参数
            t: new Date().getTime()
        },
        columns: [
            {
                fieldName: 'SKU#',
                field: 'Color',
                sortable: true,
                width: "7%"
            },
            {
                fieldName: '名称',
                field: 'ChinaProductName',
                sortable: true,
                width: "13%"
            },
            {
                fieldName: '规格型号',
                field: 'Specification',
                sortable: true,
                width: "13%"
            },
            
            {
                fieldName: '单位',
                field: 'ChinaUnit',
                width: "7%"
            },
            {
                fieldName: '详细信息',
                field: 'Raw_materialsId',
                format: function (val, obj) {
                    var html = '<button type="button" data-action="Detailed" data-id="' + obj.Raw_materialsId + '" class="layui-btn layui-btn-small"" style="background-color:white"> <img src="../Current/Icon/GreenDetail.png" /></button>';
                    return html;
                },
                width: "7%"
            },
            {
                fieldName: '库存',
                field: 'stock',
                sortable: true,//是否显示排序
                width: "9%"

            },
            {
                fieldName: '冻结库存',
                field: 'freeze_stock',
                sortable: true,//是否显示排序
                width: "9%"

            },
            {
                fieldName: '所属仓库',
                field: 'WarehouseName',
                sortable: true,
                width: "9%"

            }, {
                fieldName: '变动统计',
                field: 'Idcount',
                format: function (val, obj) {
                    var html = '<button type="button" data-action="Changes" data-id="' + val + '" class="layui-btn layui-btn-small"" style="background-color:white;color:#179186;font-size:15px">变动统计</button>';
                    return html;
                },
                width: "8%"
            },
            {
                fieldName: '操作',
                field: 'Ids',
                format: function (val, obj) {
                    var html = '<button type="button" value="调整库存" data-action="edit" data-id="' + val + '" class="layui-btn layui-btn-small"><img src="../Current/Icon/StockbackGreen.png" />&nbsp; 调整库存</button>';
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
                            case 'Changes':
                                parent.tab.tabAdd({
                                    href: '../Warehouses/ChangesCount?Id=' + Id, //地址
                                    title: '变动统计',
                                    Closeabled: true
                                });
                                break;

                            // #region 库存管理,调整库存
                            case 'edit':
                                //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
                                $.get('../Warehouses/StorageEditInfo?Id=' + Id, null, function (form) {
                                    $(".hidden-div #BoxIndex").val("0");
                                    BoxIndex = layer.open({
                                        type: 1,
                                        title: '<img src="../Current/Icon/StockBackBlcak.png" />&nbsp; 调整库存',
                                        content: form,
                                        btn: ['确定'],
                                        shade: false,
                                        offset: ['100px', '30%'],
                                        area: ['560px', '430px'],
                                        zIndex: 19891013,
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
                                                $.ajax({
                                                    type: "post",
                                                    data: JSON.stringify(data.field),
                                                    url: '../../api/Warehouse/AddChangeInfo',
                                                    dataType: "json",
                                                    contentType: "application/json; charset=utf-8",
                                                    success: function (data) {
                                                        if (data.HttpCode != 200) {
                                                            if (data.Message == null || data.Message == "") {
                                                                layer.msg("程序出现问题！");
                                                            }
                                                            else {
                                                                layer.msg(data.Message);
                                                            }
                                                        }
                                                        else {
                                                            btable.get();
                                                            layer.close(index);
                                                            layer.msg(data.Message);
                                                        }
                                                    },
                                                    error: function (e) {
                                                        layer.msg('请求处理出错!');
                                                    }
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
                                break;
                            // #endregion

                            // #region 库存管理,详细信息
                            case 'Detailed':
                                var obj = new Object();
                                obj.Id = $that.data('id');
                                
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
