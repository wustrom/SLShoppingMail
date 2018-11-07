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
        url: '../../../APi/Table/GetProducer', //数据源地址
        pageSize: 18,//页大小
        params: {//额外的请求参数
            t: new Date().getTime()
        },
        columns: [
            {
                fieldName: '供应商名称',
                field: 'ProducerCode',
                sortable: true,
                width: "10%"
            },
            {
                fieldName: '供应商名称',
                field: 'Name',
                sortable: true,
                width: "10%"
            },
            {
                fieldName: '地址',
                field: 'Address',
                width: "13%"
            },
            {
                fieldName: '联系人',
                field: 'EnterLegPerson',
                width: "9%"
            },
            {
                fieldName: '账期',
                field: 'AccountPeriod',
                sortable: true,
                width: "6%"

            },
            {
                fieldName: '主营产品',
                field: 'SupplyProducts',
                width: "15%"

            },
            {
                fieldName: '操作',
                field: 'Ids',
                format: function (val, obj) {
                    var html = '<button type="button" data-action="BuyerInfo" data-id="' + val + '" class="layui-btn layui-btn-small"" style="background-color:transparent;margin-left:0;"><a href="javascript:;" title="该供应商的采购订单"><img src="/current/Icon/GreenList.png" style="height: 24px;"></a></button>';
                    html += '<button type="button" data-action="BillInfo" data-id="' + val + '" class="layui-btn layui-btn-small"" style="background-color:transparent;margin-left:0;"><a href="javascript:;" title="该供应商的开票详情"><img src="/current/Icon/GreenPay.png" style="height: 24px;"></a></button>';
                    html += '<button type="button" data-action="Edit" data-id="' + val + '" class="layui-btn layui-btn-small"" style="background-color:transparent;margin-left:0;"><a href="javascript:;" title="修改供应商信息"><img src="/current/Icon/GreenPan.png" style="height: 22px;"></a></button>';
                    html += '<button type="button" onclick="DeleteProdecer(' + val + ')"  data-action="DeleteProdecer" data-id="' + val + '" class="layui-btn layui-btn-small"" style="background-color:transparent;margin-left:0;"><a href="javascript:;" title="删除供应商信息"><img src="/current/Icon/Delete.png" style="height: 22px;"></a></button>';
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

                            //#region 采购记录
                            case 'BuyerInfo':
                                parent.tab.tabAdd({
                                    href: '../Material/BuyerInfo?Id=' + Id,
                                    title: '采购详情',
                                    Closeabled: true
                                });
                                break;
                            //#endregion

                            //#region 开票记录
                            case 'BillInfo':
                                parent.tab.tabAdd({
                                    href: '../Finance/InvoiceInfo?Id=' + Id,
                                    title: '开票详情',
                                    Closeabled: true
                                });
                                break;
                            //#endregion

                            // #region 修改供应商
                            case 'Edit':
                                //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
                                var index = layer.load(1);
                                $.get('../Material/ProducerDetail?Id=' + Id, function (form) {
                                    layer.close(index);
                                    BoxIndex = layer.open({
                                        type: 1,
                                        title: '<i class="layui-icon">&#xe642;</i>&nbsp; 修改信息',
                                        content: form,
                                        btn: ['确定'],
                                        closeBtn: 2,
                                        shade: false,
                                        offset: ['80px', '15%'],
                                        area: ['920px', '570px'],
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
                                                data = ResetData(data);
                                                btable.ajaxPost('../../api/Material/EditProducter', JSON.stringify(data.field), function (data) {
                                                    btable.get();
                                                    layer.close(index);
                                                    layer.msg(data.Message);
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

                            // #region 删除
                            case 'DeleteProdecer':
                                var obj = new Object();
                                obj.Id = Id;
                                layer.confirm('确认删除此供应商吗？', {
                                    btn: ['确定', '取消'] //按钮
                                }, function (index) {
                                    btable.ajaxPost('../../api/Material/DeleteProducter', JSON.stringify(obj), function (dataInfo) {
                                        layer.close(index);
                                        btable.get();
                                        layer.msg(dataInfo.Message);
                                    });
                                    layer.close(index);
                                });
                                break;
                            // #endregion
                        }

                    })
                });
            });
        },
        dbclicktext: "Edit"

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
    $('#addProducer').on('click', function () {
        if (BoxIndex !== -1) {
            layer.msg("已有一个弹出窗口！");
            return;
        }
        //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
        var index = layer.load(1);
        $.get('../../Material/ProducerDetail', function (form) {
            layer.close(index);
            BoxIndex = layer.open({
                type: 1,
                title: '<i class="layui-icon">&#xe642;</i>&nbsp; 添加信息',
                content: form,
                btn: ['确定'],
                closeBtn: 2,
                shade: false,
                offset: ['80px', '15%'],
                area: ['920px', '570px'],
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
                        data = ResetData(data);
                        btable.ajaxPost('../../api/Material/EditProducter', JSON.stringify(data.field), function (data) {
                            btable.get();
                            layer.close(index);
                            layer.msg(data.Message);
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
    })
    //获得地址
    form.on('select', function (data) {
        var s1 = $('div[data-action="province"] input').val()
        var s2 = $('div[data-action="city"] input').val()
        var s3 = $('div[data-action="area"] input').val()
        Address = s1 + "," + s2 + "," + s3;
        $('#Address').val(Address);
    });

    //删除
    function DeleteProdecer() {
        var obj = new Object();
        obj.Id = Id;
        layer.confirm('确认删除此供应商吗？', null, function (index) {
            btable.axpost('../../api/Material/DeleteProducter', obj, function (data) {
                layer.msg(data.Message);
                pagingFunc.reload();
                layer.close(index);
            });
        });
    }

    //重设Data的内容
    function ResetData(data) {
        var array = new Array();
        // #region 销售信息列表
        array.splice(0, array.length);
        var listProducer = new Array();
        $(data.elem.parentNode).find("input[name^='ProducerConect_']").each(function () {

            var Index = $(this)[0].name.split('_')[1];
            if (array.indexOf(Index) == -1) {
                array.push(Index);
            }
        });
        array.forEach(function (item) {
            
            var ConectName = $(data.elem.parentNode).find("input[name^='ProducerConect_" + item + "_ConectName']").val();
            var Position = $(data.elem.parentNode).find("input[name^='ProducerConect_" + item + "_Position']").val();
            var ConectSex = $(data.elem.parentNode).find("select[name^='ProducerConect_" + item + "_ConectSex']").val();
            var Telephone = $(data.elem.parentNode).find("input[name^='ProducerConect_" + item + "_Telephone']").val();
            var Phone = $(data.elem.parentNode).find("input[name^='ProducerConect_" + item + "_Phone']").val();
            var Email = $(data.elem.parentNode).find("input[name^='ProducerConect_" + item + "_Email']").val();
            listProducer.push({ ConectName: ConectName, Position: Position, ConectSex: ConectSex, Telephone: Telephone, Phone: Phone, Email: Email });
        })
        data.field.listProducer = listProducer;
        // #endregion
        return data;
    }
});