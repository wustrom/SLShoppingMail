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
    var ProduterId = $('#ProduterId').val();
    var BoxIndex = -1;
    btable.set({
        openWait: true,//开启等待框
        elem: '#content',
        url: '../../../APi/Table/GetMaterialManger', //数据源地址
        pageSize: 18,//页大小
        params: {//额外的请求参数
            t: new Date().getTime()
        },
        columns: [
            { //配置数据列
                fieldName: '产品货号', //显示名称
                field: 'No', //字段名
                //sortable: true,//是否显示排序
                width: "100px",
                format: function (val, obj) {
                    var html = '<label>' + obj.No + '</label>';
                    return html;
                }
            }, {
                fieldName: '中文品名',
                field: 'Name',
                sortable: true,
                width: "170px"
            }, {
                fieldName: '规格型号',
                field: 'Specification',
                sortable: true,
                width: "170px"
            },
            {
                fieldName: '产品属性',
                field: 'Attributes',
                width: "120px"
            },
            {
                fieldName: '中文单位',
                field: 'Unit',
                sortable: false,//是否显示排序
                width: "40px"
            },
            {
                fieldName: '材料及工艺',
                field: 'MatAndPro',
                width: "100px"
            },
            {
                fieldName: '详细信息',
                field: 'Ids',
                format: function (val, obj) {
                    var html = '<input type="button" value="&#xe642;" data-action="edit" data-id="' + val + '" class="layui-btn layui-btn-mini layui-icon" style="color:green;" /> ';
                    var html = html + '<input type="button" value="&#xe640;" data-action="delete" data-id="' + val + '" class="layui-btn layui-btn-mini layui-icon" />';
                    return html;
                },
                width: "60px",
            }],
        even: false,//隔行变色
        field: 'Id', //主键ID
        //skin: 'row',
        checkbox: false,//是否显示多选框
        paged: true, //是否显示分页
        singleSelect: false, //只允许选择一行，checkbox为true生效
        SerialNumber: false,//是否有序号
        onSuccess: function ($elem) { //$elem当前窗口的jq对象
            $elem.children('tr').each(function () {
                // #region 最后一列
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
                        var obj = new Object();
                        obj.Id = Id;
                        switch (action) {
                            // #region 查看按钮
                            case 'edit':
                                var index = layer.load(1);
                                //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
                                $.get('../../Material/MaterialDetail', obj, function (form) {
                                    layer.close(index);
                                    BoxIndex = layer.open({
                                        type: 1,
                                        title: '<img src="/Current/Icon/search.png">修改商品',
                                        content: form,
                                        btn: ['修改'],
                                        shade: false,
                                        offset: ['0px', '15%'],
                                        area: ['875px', '98%'],
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
                                                btable.ajaxPost('../../api/Material/EditMaterialInfo', JSON.stringify(data.field), function (dataInfo) {
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

                            // #region 删除按钮
                            case 'delete':
                                //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
                                layer.confirm('确定删除原材料信息？', {
                                    btn: ['确定', '取消'] //按钮
                                }, function (index) {
                                    btable.ajaxPost('../../api/Material/DeleteMaterial', JSON.stringify(obj), function (dataInfo) {
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
                // #endregion
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

    form.on('select(Produter)', function (data) {
        var obj = new Object();
        obj.ProduterId = $('#ProduterId').val();
        obj.t = new Date().getTime();
        btable.get(obj);
    });

    //添加
    $('#add').on('click', function () {
        if (BoxIndex !== -1) {
            layer.msg("已有一个弹出窗口！");
            return;
        }
        //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取
        var index = layer.load(1);
        $.get('../../Material/MaterialDetail', null, function (form) {
            layer.close(index);
            BoxIndex = layer.open({
                type: 1,
                title: '<img src="/Current/Icon/Add.png">添加商品',
                content: form,
                btn: ['新建'],
                shade: false,
                offset: ['0px', '15%'],
                area: ['875px', '95%'],
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
                        btable.ajaxPost('../../api/Material/EditMaterialInfo', JSON.stringify(data.field), function (dataInfo) {
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
    });

    //重设Data的内容
    function ResetData(data) {
        var array = new Array();

        // #region 产品列表
        var lstproducermodel = new Array();
        $(data.elem.parentNode).find("input[name^='producerList_']").each(function () {

            var Index = $(this)[0].name.split('_')[1];
            if (array.indexOf(Index) == -1) {
                array.push(Index);
            }
        });
        array.forEach(function (item) {
            var _ProdecerCode = $(data.elem.parentNode).find("input[name^='producerList_" + item + "_ProdecerCode']").val();
            var _ProdecerName = $(data.elem.parentNode).find("select[name^='producerList_" + item + "_ProdecerName']").val();
            var _FactoryNumber = $(data.elem.parentNode).find("input[name^='producerList_" + item + "_FactoryNumber']").val();
            var _PurchasePrice = $(data.elem.parentNode).find("input[name^='producerList_" + item + "_PurchasePrice']").val();
            var _QuotationDate = $(data.elem.parentNode).find("input[name^='producerList_" + item + "_QuotationDate']").val();
            var _ProCycle = $(data.elem.parentNode).find("input[name^='producerList_" + item + "_ProCycle']").val();
            var _MinQuantity = $(data.elem.parentNode).find("input[name^='producerList_" + item + "_MinQuantity']").val();
            var _PriceTag = $(data.elem.parentNode).find("input[name^='producerList_" + item + "_PriceTag']").val();
            lstproducermodel.push({ ProdecerCode: _ProdecerCode, ProdecerName: _ProdecerName, FactoryNumber: _FactoryNumber, PurchasePrice: _PurchasePrice, QuotationDate: _QuotationDate, ProCycle: _ProCycle, MinQuantity: _MinQuantity, PriceTag: _PriceTag });
        })
        data.field.producer = lstproducermodel;
        // #endregion

        // #region 颜色列表
        array.splice(0, array.length);
        var lstColorInfomodel = new Array();
        $(data.elem.parentNode).find("input[name^='ColorInfo_']").each(function () {
            var Index = $(this)[0].name.split('_')[1];
            if (array.indexOf(Index) == -1 && Index != "") {
                array.push(Index);
            }
        });
        array.forEach(function (item) {
            var SKU = $(data.elem.parentNode).find("input[name^='ColorInfo_" + item + "_SKU']").val();
            var ColorID = $(data.elem.parentNode).find("select[name^='ColorInfo_" + item + "_StanColorNum']").val();
            var StanColorNum = $(data.elem.parentNode).find("Select[name^='ColorInfo_" + item + "_StanColorNum'] option:selected").html();
            var ColorSystem = $(data.elem.parentNode).find("Select[name^='ColorInfo_" + item + "_ColorSystem']").val();
            var ColorDesc = $(data.elem.parentNode).find("input[name^='ColorInfo_" + item + "_ColorDesc']").val();
            var EngColorDesc = $(data.elem.parentNode).find("input[name^='ColorInfo_" + item + "_EngColorDesc']").val();
            var MinStock = $(data.elem.parentNode).find("input[name^='ColorInfo_" + item + "_MinStock']").val();
            var SKUImage = $(data.elem.parentNode).find("input[name^='ColorInfo_" + item + "_SKUImage']").val();
            var PantongColor = $(data.elem.parentNode).find("input[name^='ColorInfo_" + item + "_PantongColor']").val();
            var HtmlCode = $(data.elem.parentNode).find("input[name^='ColorInfo_" + item + "_HtmlCode']").val();
            var ParentDiv = $(data.elem.parentNode).find("input[name^='ColorInfo_" + item + "_SKUImage']").parent().parent();
            var lstprintInfomodel = new Array();
            $(ParentDiv).find('.ColorPrint').each(function () {
                var Print = $(this).find("Select[name='ColorInfo__Print']").val();
                var PositionDescrip = $(this).find("input[name='ColorInfo__PositionDescrip']").val();
                var ColorInfo_Diagram = $(this).find("input[name='ColorInfo__Diagram']").val();
                lstprintInfomodel.push({ Print: Print, PositionDescrip: PositionDescrip, ColorInfo_Diagram: ColorInfo_Diagram });
            });
            lstColorInfomodel.push({ SKU: SKU, ColorID: ColorID, StanColorNum: StanColorNum, ColorSystem: ColorSystem, ColorSystem: ColorSystem, ColorDesc: ColorDesc, EngColorDesc: EngColorDesc, MinStock: MinStock, SKUImage: SKUImage, Print: lstprintInfomodel, HtmlCode: HtmlCode, PantongColor: PantongColor });
        })
        data.field.ColorList = lstColorInfomodel;
        // #endregion

        // #region 销售信息列表
        array.splice(0, array.length);
        var lstSalesInfomodel = new Array();
        $(data.elem.parentNode).find("input[name^='SalesInfo_']").each(function () {

            var Index = $(this)[0].name.split('_')[1];
            if (array.indexOf(Index) == -1) {
                array.push(Index);
            }
        });
        array.forEach(function (item) {
            var ShopQuantity = $(data.elem.parentNode).find("input[name^='SalesInfo_" + item + "_ShopQuantity']").val();
            var ChinaPrice = $(data.elem.parentNode).find("input[name^='SalesInfo_" + item + "_ChinaPrice']").val();
            var ChinaDiscountRate = $(data.elem.parentNode).find("input[name^='SalesInfo_" + item + "_ChinaDiscountRate']").val();
            var DollarPrice = $(data.elem.parentNode).find("input[name^='SalesInfo_" + item + "_DollarPrice']").val();
            var DollarDiscountRate = $(data.elem.parentNode).find("input[name^='SalesInfo_" + item + "_DollarDiscountRate']").val();
            lstSalesInfomodel.push({ ShopQuantity: ShopQuantity, ChinaPrice: ChinaPrice, ChinaDiscountRate: ChinaDiscountRate, DollarPrice: DollarPrice, DollarDiscountRate: DollarDiscountRate });
        })
        data.field.SalesList = lstSalesInfomodel;
        // #endregion

        // #region 印刷信息列表
        var lstPrintInfomodel = new Array();
        for (var i = 1; i <= 3; i++) {
            for (var j = 0; j < 3; j++) {
                var _PrintingProcess = $(data.elem.parentNode).find("select[name='PrintFunc" + i + "_PrintingProcess" + j + "']").val();
                var _PrintingPosition = $(data.elem.parentNode).find("input[name='PrintFunc" + i + "_PrintingPosition" + j + "']").val();
                var _PositionDescription = $(data.elem.parentNode).find("input[name='PrintFunc" + i + "_PositionDescription" + j + "']").val();
                var _MaximumArea = $(data.elem.parentNode).find("input[name='PrintFunc" + i + "_MaximumArea" + j + "']").val();
                var _PrintableColor = $(data.elem.parentNode).find("input[name='PrintFunc" + i + "_PrintableColor" + j + "']").val();
                lstPrintInfomodel.push({ PrintFunc: "PrintFunc" + i, PrintingProcess: _PrintingProcess, PrintingPosition: _PrintingPosition, PositionDescription: _PositionDescription, MaximumArea: _MaximumArea, PrintableColor: _PrintableColor });
            }
        }
        data.field.PrintList = lstPrintInfomodel;
        // #endregion
        return data;
    }
});
