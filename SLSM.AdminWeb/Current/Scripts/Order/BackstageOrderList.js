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
        url: '../../../APi/Table/GetAdminOrderList', //数据源地址
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
                    if (obj.Status === '待付款') {
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
                    var html = '';
                    if (obj.UserSure === false) {
                        html = html + '<input type="button" value="上传Logo" data-action="UpLogo" data-id="' + val + '" class="layui-btn layui-btn-mini" />';
                    }
                    if (obj.DesignCommit === true) {
                        html = html + '<input type="button" value="产品效果图" data-action="SureDesign" data-id="' + val + '" class="layui-btn layui-btn-mini layui-btn-normal" />';
                    }
                    if (obj.Status === '待收货') {
                        html = html + '<input type="button" value="确认收货" data-action="ToConfirm" data-id="' + val + '" class="layui-btn layui-btn-mini layui-btn-normal" />';
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
                            // #region 上传Logo
                            case 'UpLogo':
                                //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
                                $.get('../../Order/UpLoadLogo?Id=' + Id, null, function (form) {
                                    BoxIndex = layer.open({
                                        type: 1,
                                        title: '上传Logo',
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

                            // #region 产品效果图
                            case 'SureDesign':
                                //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
                                $.get('../../Order/SureDesign?Id=' + Id, null, function (form) {
                                    BoxIndex = layer.open({
                                        type: 1,
                                        title: '产品效果图',
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

                            // #region 确认收货
                            case 'ToConfirm':
                                layer.confirm('是否确认收货?', { icon: 1, title: '提示' }, function (index) {
                                    var obj = new Object();
                                    obj.Id = Id;
                                    btable.ajaxPost('../../Api/Order/EnterThing', JSON.stringify(obj), function (dataInfo) {
                                        layer.close(index);
                                        btable.get();
                                        layer.msg(dataInfo.Message);
                                    });
                                    layer.close(index);
                                });
                                break;
                            // #endregion
                        }
                    });
                });
            });
        },
        dbclicktext: "edit"
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
