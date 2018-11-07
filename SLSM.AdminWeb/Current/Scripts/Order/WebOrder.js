layui.config({
    base: '../../../Base/js/',
    v: new Date().getTime(),

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
        url: '../../../APi/Table/GetWebOrderList', //数据源地址
        pageSize: 18,//页大小
        params: {//额外的请求参数
            t: new Date().getTime()
        },
        columns: [
            { //配置数据列
                fieldName: '订单编号', //显示名称
                field: 'OrderNo', //字段名
                sortable: true,//是否显示排序
                width: '72px'
            }, {
                fieldName: '货号',
                field: 'MaterName',
                sortable: false,
                width: '85px'
            }, {
                fieldName: '数量',
                field: 'ProductNum',
                sortable: false,
                width: '60px'
            }, {
                fieldName: '金额',
                field: 'TotalPrice',
                sortable: false,
                width: '60px'
            }, {
                fieldName: '支付方式',
                field: 'PayType',
                width: '60px',
                format: function (val, obj) {
                    if (obj.Status == '待付款') {
                        html = "-";
                    }
                    else {
                        return obj.PayType;
                    }
                }
            }, {
                fieldName: '订单状态',
                field: 'Status',
                width: '60px'
            },
            {
                fieldName: '下单时间',
                field: 'OrderTime',
                sortable: true,//是否显示排序
                width: '111px'
            },
            {
                fieldName: '用户名',
                field: 'Name',
                width: '80px'
            },
            {
                fieldName: '收件人',
                field: 'BuyName',
                width: '80px'
            },
            {
                fieldName: '地址',
                field: 'AddrArea',
                width: '220px'
            },
            {
                fieldName: '操作',
                field: 'id',
                format: function (val, obj) {
                    var html = '<input type="button" value="查看订单" data-action="edit" data-id="' + val + '" class="layui-btn layui-btn-mini" /> ';
                    if (obj.Status == '待付款') {
                        html = html + '<input type="button" value="修改价格" data-action="ChangePrice" data-id="' + val + '" class="layui-btn layui-btn-mini layui-btn-normal" />';
                    }
                    if ((obj.Status == '待付款' || obj.Status == '未发货') && obj.ToErp != true) {
                        html = html + '<input type="button" value="转到Erp" data-action="ConvertErp" data-id="' + val + '" class="layui-btn layui-btn-mini layui-btn-normal" />';
                    }
                    if (obj.Status == '待付款' && obj.PayType == '线下支付') {
                        html = html + '<input type="button" value="确认支付" data-action="SurePay" data-id="' + val + '" class="layui-btn layui-btn-mini layui-btn-normal" />';
                    }
                    else if (obj.Status == '未发货') {
                        html = html + '<input type="button" value="确认发货" data-action="SendThing" data-id="' + val + '" class="layui-btn layui-btn-mini layui-btn-normal" />';
                    }
                    else if (obj.Status == '待收货' && obj.ToErp != true) {
                        html = html + '<input type="button" value="快递信息" data-action="ExPresss" data-id="' + val + '" class="layui-btn layui-btn-mini layui-btn-normal" />';
                    }
                    else if (obj.Status == '退货中') {
                        html = html + '<input type="button" value="退货成功" data-action="ReturnSuccess" data-id="' + val + '" class="layui-btn layui-btn-mini layui-btn-normal" />';
                        html = html + '<input type="button" value="退货失败" data-action="ReturnFail" data-id="' + val + '" class="layui-btn layui-btn-mini layui-btn-normal" />';
                    }
                    else if (obj.Status == '评价成功' && obj.ToErp != true) {
                        html = html + '<input type="button" value="快递信息" data-action="ExPresss" data-id="' + val + '" class="layui-btn layui-btn-mini layui-btn-normal" />';
                    }
                    else if (obj.Status == '待评价' && obj.ToErp != true) {
                        html = html + '<input type="button" value="快递信息" data-action="ExPresss" data-id="' + val + '" class="layui-btn layui-btn-mini layui-btn-normal" />';
                    }
                    return html;
                }, width: '220px'
            }],
        even: true,//隔行变色
        field: 'Id', //主键ID
        //skin: 'row',
        checkbox: false,//是否显示多选框
        paged: true, //是否显示分页
        singleSelect: false, //只允许选择一行，checkbox为true生效
        onSuccess: function ($elem) { //$elem当前窗口的jq对象
            $elem.children('tr').each(function () {
                $(this).children('td:last-child').children('input').each(function () {
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
                            // #region 查看按钮
                            case 'edit':
                                //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
                                $.get('../../Order/OrderDetail?Id=' + Id, null, function (form) {
                                    BoxIndex = layer.open({
                                        type: 1,
                                        title: '订单详情',
                                        content: form,
                                        btn: ['关闭'],
                                        shade: false,
                                        offset: ['100px', '30%'],
                                        area: ['900px', '600px'],
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
                                                layer.close(index);
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

                            // #region 确认支付按钮
                            case 'SurePay':
                                layer.confirm('确认订单支付?', { icon: 1, title: '提示' }, function (index) {
                                    var obj = new Object();
                                    obj.Id = Id;

                                    // #region Ajax提交
                                    $.ajax({
                                        type: "post",
                                        data: JSON.stringify(obj),
                                        url: '/../../Api/Order/SurePay',
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
                                                layer.msg(data.Message);
                                                $("#submit_btn").trigger('click');
                                            }
                                        },
                                        error: function (e) {
                                            layer.msg('请求处理出错!');
                                        }
                                    });
                                    // #endregion

                                    layer.close(index);
                                });
                                break;
                            // #endregion

                            // #region 确认订单转至Erp
                            case 'ConvertErp':
                                layer.confirm('确认订单转至Erp?', { icon: 1, title: '提示' }, function (index) {
                                    var obj = new Object();
                                    obj.Id = Id;

                                    // #region Ajax提交
                                    $.ajax({
                                        type: "post",
                                        data: JSON.stringify(obj),
                                        url: '/../../Api/Order/ConvertErp',
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
                                                layer.msg(data.Message);
                                                $("#submit_btn").trigger('click');
                                            }
                                        },
                                        error: function (e) {
                                            layer.msg('请求处理出错!');
                                        }
                                    });
                                    // #endregion

                                    layer.close(index);
                                });
                                break;
                            // #endregion

                            // #region 快递信息按钮
                            case 'ExPresss':
                                //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
                                $.get('../../Order/SendThing?Id=' + Id, null, function (form) {
                                    BoxIndex = layer.open({
                                        type: 1,
                                        title: '快递信息',
                                        content: form,
                                        btn: ['保存', '取消'],
                                        shade: false,
                                        offset: ['100px', '30%'],
                                        area: ['700px', '400px'],
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
                                                    url: '../../api/Order/UpdateExpress',
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

                            // #region 发货按钮
                            case 'SendThing':
                                layer.confirm('确认发货?', { icon: 1, title: '提示' }, function (index) {
                                    var obj = new Object();
                                    obj.Id = Id;

                                    // #region Ajax提交
                                    $.ajax({
                                        type: "post",
                                        data: JSON.stringify(obj),
                                        url: '/../../Api/Order/SendThing',
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
                                                layer.msg(data.Message);
                                                $("#submit_btn").trigger('click');
                                            }
                                        },
                                        error: function (e) {
                                            layer.msg('请求处理出错!');
                                        }
                                    });
                                    // #endregion

                                    layer.close(index);
                                });
                                break;
                            // #endregion

                            // #region 确认收货按钮
                            case 'EnterThing':
                                layer.confirm('确认收货?', { icon: 1, title: '提示' }, function (index) {
                                    var obj = new Object();
                                    obj.Id = Id;

                                    // #region Ajax提交
                                    $.ajax({
                                        type: "post",
                                        data: JSON.stringify(obj),
                                        url: '/../../Api/Order/EnterThing',
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
                                                layer.msg(data.Message);
                                                $("#submit_btn").trigger('click');
                                            }
                                        },
                                        error: function (e) {
                                            layer.msg('请求处理出错!');
                                        }
                                    });
                                    // #endregion

                                    layer.close(index);
                                });
                                break;
                            // #endregion

                            // #region 退货成功按钮
                            case 'ReturnSuccess':
                                layer.confirm('确认退货成功?', { icon: 1, title: '提示' }, function (index) {
                                    var obj = new Object();
                                    obj.Id = Id;

                                    // #region Ajax提交
                                    $.ajax({
                                        type: "post",
                                        data: JSON.stringify(obj),
                                        url: '/../../Api/Order/ReturnSuccess',
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
                                                layer.msg(data.Message);
                                                $("#submit_btn").trigger('click');
                                            }
                                        },
                                        error: function (e) {
                                            layer.msg('请求处理出错!');
                                        }
                                    });
                                    // #endregion

                                    layer.close(index);
                                });
                                break;
                            // #endregion

                            // #region 退货失败按钮
                            case 'ReturnFail':
                                layer.confirm('确认退货失败?', { icon: 1, title: '提示' }, function (index) {
                                    var obj = new Object();
                                    obj.Id = Id;

                                    // #region Ajax提交
                                    $.ajax({
                                        type: "post",
                                        data: JSON.stringify(obj),
                                        url: '/../../Api/Order/ReturnFail',
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
                                                layer.msg(data.Message);
                                                $("#submit_btn").trigger('click');
                                            }
                                        },
                                        error: function (e) {
                                            layer.msg('请求处理出错!');
                                        }
                                    });
                                    // #endregion

                                    layer.close(index);
                                });
                                break;
                            // #endregion

                            // #region 价格转变
                            case 'ChangePrice':
                                layer.prompt({
                                    formType: 2,
                                    placeholder: '改变价格',
                                    title: '请输入值',
                                }, function (value, index, elem) {
                                    debugger;
                                    if (value === "") {
                                        layer.msg("请填写改变价格的原因")
                                        return;
                                    }
                                    if ($('#discountprice').val() === "") {
                                        layer.tips("请输入价格", $('#discountprice'));
                                        return;
                                    }
                                    var obj = new Object();
                                    obj.Id = Id;
                                    obj.ChangePrice = $('#discountprice').val();
                                    obj.ChangePriceResult = value;
                                    // #region Ajax提交
                                    $.ajax({
                                        type: "post",
                                        data: JSON.stringify(obj),
                                        url: '/../../Api/Order/ChangePrice',
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
                                                layer.msg(data.Message);
                                                layer.close(index);
                                            }
                                        },
                                        error: function (e) {
                                            layer.msg('请求处理出错!');
                                        }
                                    });
                                    // #endregion

                                });

                                $(".layui-layer-content").append("<br/><input type=\"text\" id= \"discountprice\" class=\"layui-input\" placeholder=\"输入价格\"/>")
                                break;
                            // #endregion
                        }
                    });
                });
            });
        },
        dbclicktext: "edit",
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
