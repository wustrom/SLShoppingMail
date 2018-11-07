layui.config({
    base: '../../../Base/js/',
    v: new Date().getTime()+"123",
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
        url: '../../../APi/Table/GetErpLoginInfo', //数据源地址
        pageSize: 14,//页大小
        params: {//额外的请求参数
            t: new Date().getTime()
        },
        columns: [
            { //配置数据列
                fieldName: '账号', //显示名称
                field: 'erpLoginName', //字段名
                width: "15%"
            }, {
                fieldName: '密码',
                field: 'erpLoginPwd',
                width: "15%"
            },
            {
                fieldName: '角色',
                field: 'ErproleName',
                width: "10%"
            }, {
                fieldName: '操作',
                field: 'Ids',
                format: function (val, obj) {
                    var html = '<button type="button" value="修改" data-action="edit" data-id="' + val + '" class="layui-btn layui-btn-small"><img src="../Current/Icon/GreenPan.png" style="width: 15px; height: 15px;" />&nbsp; 修改</button><button type="button" value="删除" data-action="Delete" data-id="' + val + '" class="layui-btn layui-btn-small"><img src="../Current/Icon/Delete.png" style="width: 13px; height: 13px;" />&nbsp; 删除</button>';
                    return html;
                },
                width: "10%"
            }],
        even: false,//隔行变色
        field: 'erpLoginId', //主键ID
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
                            //#region 修改
                            case 'edit':
                                //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
                                $.get('../Jurisdiction/UpdateLoginUser?erpLoginId=' + Id, null, function (form) {
                                    $(".hidden-div #BoxIndex").val("0");
                                    BoxIndex = layer.open({
                                        type: 1,
                                        title: '<img src="../Current/Icon/StockBackBlcak.png" />&nbsp; 修改信息',
                                        content: form,
                                        btn: ['确定'],
                                        shade: false,
                                        offset: ['100px', '30%'],
                                        area: ['450px', '300px'],
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
                                                    url: '../../api/Jurisdiction/UpdateLoginUser',
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
                            //#endregion

                            //#region 删除
                            case 'Delete':
                                layer.confirm('确定删除用户？', null, function (index) {
                                    var obj = new Object();
                                    obj.erpLoginId = Id;
                                    btable.ajaxPost('../../api/Jurisdiction/DeleteLoginUser', JSON.stringify(obj), function (dataInfo) {
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

    //#region 添加
    $(function () {
        $('#AddLoginUser').click(function () {
            if (BoxIndex !== -1) {
                layer.msg("已有一个弹出窗口！");
                return;
            }
            //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
            $.get('../Jurisdiction/UpdateLoginUser', null, function (form) {
                $(".hidden-div #BoxIndex").val("0");
                BoxIndex = layer.open({
                    type: 1,
                    title: '<img src="../Current/Icon/StockBackBlcak.png" />&nbsp;添加信息',
                    content: form,
                    btn: ['确定'],
                    shade: false,
                    offset: ['100px', '30%'],
                    area: ['450px', '300px'],
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
                                url: '../../api/Jurisdiction/UpdateLoginUser',
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
        })
    })
    //#endregion

});


