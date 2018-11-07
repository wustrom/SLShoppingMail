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
        url: '../../../APi/Table/GetReceivesInfo', //数据源地址
        pageSize: 18,//页大小
        params: {//额外的请求参数     
            t: new Date().getTime()
        },
        columns: [
            {
                fieldName: '订单编号',
                field: 'OrderNo',
                sortable: true,//是否显示排序
                width: "15%"

            },
            {
                fieldName: '订单数量',
                field: 'Amount',
                sortable: true,//是否显示排序
                width: "15%"

            },
            {
                fieldName: '申领时间',
                field: 'receiveTime',
                sortable: true,//是否显示排序
                width: "15%"
            },
            {
                fieldName: '订单状态',
                field: 'receiveStatus',
                width: "13%",
                sortable: true,//是否显示排序
                format: function (val, obj) {
                    if (obj.receiveStatus == "待出库") {
                        var html = '<label style="color:#49acff;">' + obj.receiveStatus + '</label>';
                    }
                    else {
                        var html = '<label style="color:#179186;">' + obj.receiveStatus + '</label>';
                    }
                    return html;
                }
            },
            {
                fieldName: '操作',
                field: 'Ids',
                format: function (val, obj) {
                    var html = '<button type="button"  data-action="Detailed" data-id="' + obj.Id + '" class="layui-btn layui-btn-mini"><img src="../Current/Icon/DetailBcakGreen.png" />&nbsp;查看详情</button>';
                    return html;
                },
                width: "15%"
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
                            // #region 生产领料管理,详细信息
                            case 'Detailed':
                                parent.tab.tabAdd({
                                    href: '../Warehouses/ReceiveDetailed?Id=' + Id, //地址
                                    title: '领料详情',
                                    Closeabled: true
                                });
                                break;
                            // #endregion
                        }

                    })
                });
            });
        },
        dbclicktext: "edit"
    });

    //#region 出库
    $('#Outwarehouse').click(function (index) {
        var obj = new Object();
        //获得生产领料表Id
        var ReceiveId = $('#ReceiveId').val();
        obj.ReceiveId = ReceiveId;
        layer.confirm('确定出库吗？', null, function (index) {
            jQuery.axpost('../../api/Warehouse/DeceiveDetailedInfo', JSON.stringify(obj), function (dataInfo) {
                layer.close(index);
                layer.msg(dataInfo.Message);
                if (dataInfo.HttpCode == 200) {
                    $('#Outwarehouse').css('display', 'none');
                }
                var tab = parent.tab;
                tab.deleteTab(tab.getCurrentTabId());
            })
        })
    })
    //#endregion

    //#region 关闭
    $('#CloseBtn').on('click', function () {
        var tab = parent.tab;
        tab.deleteTab(tab.getCurrentTabId());
    });
    //#endregion

    $('#AddMaterInfo').click(function () {
        var index = layer.load(1);
        $.get('../../Warehouses/AddReciveInfo', null, function (form) {
            layer.close(index);
            BoxIndex = layer.open({
                type: 1,
                title: '添加额外领料',
                content: form,
                btn: ['添加', '取消'],
                shade: false,
                offset: ['100px', '20%'],
                area: ['400px', '300px'],
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
                        var count = 0;
                        $('tbody tr').each(function () {
                            if ($(this).find('td').eq(0).html().trim() == "&nbsp;") {
                                return;
                            }
                            count++;
                        });
                        
                        if (count < 10) {
                            $('tbody tr').eq(count - 1).empty().append('<td>\
                                <button class="layui-btn layui-btn-mini" style= "background-color:white" onclick="removeTd(this)" >\
                                    <i class="layui-icon" style= "color:black;" >&#xe640;</i>\
                                </button>\
                                    <label >'+ data.field.ProducerNo + '</label >\
                                    <input type="hidden" value="'+ data.field.MaterialId + '" class="MaterInfoId" /> <input type="hidden" value="' + data.field.SKU + '" class="SKU" />\
                            </td >\
                            <td>'+ '<label >' + data.field.SKU + '</label >' + '</td>\
                            <td>'+ data.field.ChinaProductName + '</td>\
                            <td>'+ data.field.MatAndPro + '</td>\
                            <td>'+ data.field.Unit + '</td>\
                            <td>0<input type="hidden" class="layui-input AmountCount" value="0" /><input type="hidden" class="layui-input Isadditional" value="true" /></td>\
                            <td><input type="text" class="layui-input additionalCount" value="'+ data.field.AddNumber + '" /></td>\
                            <td>&nbsp;</td><td>&nbsp;</td>');
                        }
                        else {
                            $('tbody tr').eq(count - 2).after('<tr>\
                                <td>\
                                <button class="layui-btn layui-btn-mini" style= "background-color:white" onclick="removeTd(this)" >\
                                    <i class="layui-icon" style= "color:black;" >&#xe640;</i>\
                                </button>\
                                    <label >'+ data.field.ProducerNo + '</label >\
                                    <input type="hidden" value="'+ data.field.MaterialId + '" class="MaterInfoId" /> <input type="hidden" value="' + data.field.SKU + '" class="SKU" />\
                            </td >\
                            <td>'+ '<label >' + data.field.SKU + '</label >' + '</td>\
                                <td>'+ data.field.ChinaProductName + '</td>\
                                <td>'+ data.field.MatAndPro + '</td>\
                                <td>'+ data.field.Unit + '</td>\
                                <td>0<input type="hidden" class="layui-input AmountCount" value="0" /><input type="hidden" class="layui-input Isadditional" value="true" /></td>\
                                <td><input type="text" class="layui-input additionalCount" value="'+ data.field.AddNumber + '" /></td>\
                                <td>&nbsp;</td><td>&nbsp;</td>\
                                </tr > ');
                        }
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

        setTimeout(function () {
            layer.close(index);
        }, 300)
    })

    //#region 申请
    $('#Applywarehouse').click(function () {
        var obj = new Object();
        //获得生产领料表Id
        obj.ProductionId = $('#ProductionId').val();
        obj.receiveSinglePerson = $('#receiveSinglePerson').html();
        var ArrayList = new Array();
        $('.MaterInfoId').each(function () {
            ArrayList.push({ MaterInfoId: $(this).val(), additionalCount: $(this).parent().parent().find('.additionalCount').val(), BaseCount: $(this).parent().parent().find('.AmountCount').val(), Isadditional: $(this).parent().parent().find('.Isadditional').val(), sku: $(this).parent().parent().find('.SKU').val() });
        })
        obj.MaterList = ArrayList;
        layer.confirm('确定申请吗？', null, function (index) {
            btable.ajaxPost('../../api/Warehouse/Applywarehouse', JSON.stringify(obj), function (dataInfo) {
                layer.close(index);
                layer.msg(dataInfo.Message);
                if (dataInfo.HttpCode == 200) {
                    $('#Applywarehouse').css('display', 'none');
                }
                var tab = parent.tab;
                tab.deleteTab(tab.getCurrentTabId());
            })
        })
    })
    //#endregion

    //#region 修改申请
    $('#ApplyResetwarehouse').click(function () {
        var obj = new Object();
        //获得生产领料表Id
        obj.ProductionId = $('#ProductionId').val();
        obj.receiveSinglePerson = $('#receiveSinglePerson').html();
        obj.receiveSingleTime = $('#receiveSingleTime').html();
        var ArrayList = new Array();
        $('.MaterInfoId').each(function () {
            ArrayList.push({ MaterInfoId: $(this).val(), additionalCount: $(this).parent().parent().find('.additionalCount').val(), BaseCount: $(this).parent().parent().find('.AmountCount').val(), Isadditional: $(this).parent().parent().find('.Isadditional').val(), sku: $(this).parent().parent().find('.SKU').val() });
        })
        obj.MaterList = ArrayList;
        layer.confirm('确定修改申请吗？', null, function (index) {
            btable.ajaxPost('../../api/Warehouse/Applywarehouse', JSON.stringify(obj), function (dataInfo) {
                layer.close(index);
                layer.msg(dataInfo.Message);
                if (dataInfo.HttpCode == 200) {
                    $('#Applywarehouse').css('display', 'none');
                }
                var tab = parent.tab;
                tab.deleteTab(tab.getCurrentTabId());
            })
        })
    })
    //#endregion

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
})

function removeTd(that) {
    $(that).parent().parent().remove();
    var count = 0;
    $('tbody tr').each(function () {
        if ($(this).find('td').eq(0).html().trim() == "&nbsp;") {
            return;
        }
        count++;
    });
    $('tbody tr').eq(count).after('<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>')
}
