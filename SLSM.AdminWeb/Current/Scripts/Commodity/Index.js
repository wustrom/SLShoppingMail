var BoxIndex = -1;
layui.config({
    base: '../../../Base/js/',
    v: new Date().getTime()
}).use(['btable', 'form'], function () {
    var btable = layui.btable(),
        $ = layui.jquery,
        layerTips = parent.layer === undefined ? layui.layer : parent.layer, //获取父窗口的layer对象
        layer = layui.layer,//获取当前窗口的layer对象;
        layedit = layui.layedit,
        form = layui.form();
    btable.set({
        openWait: true,//开启等待框
        elem: '#content',
        url: '../../../APi/Table/GetCommodityList', //数据源地址
        pageSize: 18,//页大小
        params: {//额外的请求参数
            t: new Date().getTime()
        },
        columns: [
            {
                fieldName: '产品货号', //显示名称
                field: 'ProductNo', //字段名
                sortable: true //是否显示排序
            },
            { //配置数据列
                fieldName: '商品名称', //显示名称
                field: 'Name', //字段名
                sortable: true //是否显示排序
            }, {
                fieldName: '商品销售量',
                field: 'Sales',
                sortable: true
            }, {
                fieldName: '商品创建时间',
                field: 'CreateTime',
                sortable: true
            }, {
                fieldName: '商品访问量',
                field: 'ClickCount',
                sortable: true
            }, {
                fieldName: '商品介绍',
                field: 'Introduce'
            }, {
                fieldName: '是否发布',
                field: 'IsRelease',
            }, {
                fieldName: '操作',
                field: 'Id',
                format: function (val, obj) {
                    var html = '<input type="button" value="编辑" data-action="edit" data-id="' + val + '" class="layui-btn layui-btn-mini" /> ' +
                        '<input type="button" value="删除" data-action="del" data-id="' + val + '" class="layui-btn layui-btn-mini layui-btn-danger" />';
                    return html;
                }
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
                    var id = $that.data('Id');
                    $that.on('click', function () {
                        switch (action) {
                            case 'edit':
                                var Id = $that.parent().parent().find('input[name="id"]').val();
                                if (BoxIndex !== -1) {
                                    layer.msg("已有一个弹出窗口！");
                                    return;
                                }
                                //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
                                $.get('../../Commodity/Detail?Id=' + Id, null, function (form) {
                                    BoxIndex = layer.open({
                                        type: 1,
                                        title: '修改商品',
                                        content: form,
                                        btn: ['保存', '取消'],
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
                                                $.ajax({
                                                    type: "post",
                                                    data: JSON.stringify(data.field),
                                                    url: '../../api/Commodity/UpdateComm',
                                                    dataType: "json",
                                                    contentType: "application/json; charset=utf-8",
                                                    success: function (data) {
                                                        if (data.HttpCode !== 200) {
                                                            if (data.Message === null || data.Message === "") {
                                                                layer.msg("程序出现问题！");
                                                            }
                                                            else {
                                                                layer.msg(data.Message);
                                                            }
                                                        }
                                                        else {
                                                            layer.close(index);
                                                            btable.get();
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
                            // #region 删除
                            case 'del': //删除
                                var Id = $that.parent().parent().find('input[name="id"]').val();
                                layer.confirm('确认删除?', { icon: 2, title: '提示' }, function (index) {
                                    var obj = new Object();
                                    obj.Id = Id;
                                    // #region Ajax提交
                                    $.ajax({
                                        type: "post",
                                        data: JSON.stringify(obj),
                                        url: '/../../Api/Commodity/DeleteComm',
                                        dataType: "json",
                                        contentType: "application/json; charset=utf-8",
                                        success: function (data) {
                                          //  
                                            if (data.HttpCode !== 200) {

                                                if (data.Message === null || data.Message === "") {
                                                    layer.msg("程序出现问题！");
                                                }
                                                else {
                                                    layer.msg(data.Message);
                                                }
                                            }
                                            else {
                                                layer.msg(data.Message);
                                                btable.get();
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
    //添加
    $('#add').on('click', function () {
        if (BoxIndex !== -1) {
            layer.msg("已有一个弹出窗口！");
            return;
        }
        //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
        $.get('../../Commodity/Detail', null, function (form) {
            BoxIndex = layer.open({
                type: 1,
                title: '添加商品',
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
                            url: '../../api/Commodity/UpdateComm',
                            dataType: "json",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                if (data.HttpCode !== 200) {
                                    if (data.Message === null || data.Message === "") {
                                        layer.msg("程序出现问题！");
                                    }
                                    else {
                                        layer.msg(data.Message);
                                    }
                                }
                                else {
                                    layer.close(index);
                                    btable.get();
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
    });
});
