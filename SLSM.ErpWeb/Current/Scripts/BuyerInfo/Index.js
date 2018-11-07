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
    var ProduterSelectId = $('input[name="ProduterSelectId"]').val();
    var BoxIndex = -1;
    btable.set({
        openWait: true,//开启等待框
        elem: '#content',
        url: '../../../APi/Table/GetAllBuyerInfo?ProducerText=' + ProduterSelectId, //数据源地址
        pageSize: 14,//页大小
        params: {//额外的请求参数
            t: new Date().getTime()
        },
        columns: [
            { //配置数据列
                fieldName: '采购单编号', //显示名称
                field: 'BuyerNo', //字段名
                sortable: true,//是否显示排序
                width: "11%"
            },
            {
                fieldName: '供应商',
                field: 'Name',
                width: "11%"
            },
            {
                fieldName: '采购时间',
                field: 'buyerTime',
                sortable: true,
                width: "9%"
            },
            {
                fieldName: '金额',
                field: 'buyerMoney',
                sortable: true,//是否显示排序
                width: "8%"
            },
            {
                fieldName: '已付账款',
                field: 'wantmoney',
                sortable: true,//是否显示排序
                width: "8%"
            },
            {
                fieldName: '应付日期',
                field: 'wantTime',
                sortable: true,//是否显示排序
                width: "9%"
            },
            {
                fieldName: '已付日期',
                field: 'paidTime',
                sortable: true,//是否显示排序
                width: "9%"
            },
            {
                fieldName: '状态',
                field: 'buyerStatus',
                sortable: true,
                format: function (val, obj) {
                    if (obj.buyerStatus == "待下单") {
                        var html = '<label style="color:#7cc0ff;">' + obj.buyerStatus + '</label>';
                    }
                    else if (obj.buyerStatus == "待送货品检") {
                        var html = '<label style="color:#ff663a;">' + obj.buyerStatus + '</label>';
                    }
                    else if (obj.buyerStatus == "待入库") {
                        var html = '<label style="color:#f7be39;">' + obj.buyerStatus + '</label>';
                    }
                    else if (obj.buyerStatus == "已入库") {
                        var html = '<label style="color:#1ca093;">' + obj.buyerStatus + '</label>';
                    }
                    else if (obj.buyerStatus == "待退货") {
                        var html = '<label style="color:red;">' + obj.buyerStatus + '</label>';
                    }
                    else if (obj.buyerStatus == "已退货") {
                        var html = '<label style="color:#7d47d0;">' + obj.buyerStatus + '</label>';
                    }
                    else {
                        var html = '<label style="color:black;">' + obj.buyerStatus + '</label>';
                    }
                    return html;
                },
                width: "9%"

            },
            {
                fieldName: '操作',
                field: 'Ids',
                format: function (val, obj) {
                    var html1 = '<button type="button" value="查看详情" data-action="Detailed" data-id="' + val + '" class="layui-btn layui-btn-small"><i class="layui-icon">&#xe63c;</i>查看详情</button>';
                    if (obj.buyerStatus != "待下单" && obj.buyerStatus != "已取消" && obj.buyerStatus != "待退货") {
                        var html2 = '<button type = "button" value = "查看电子合同" data-action="Contract" data - id="' + val + '" class="layui-btn layui-btn-small" > <i class="layui-icon">&#xe63c;</i>查看电子合同</button> ';
                    } else {
                        var html2 = "";
                    }
                    return html1 + html2;
                },
                width: "13%"
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

                $(this).children('td').children('button').each(function () {
                    var $that = $(this);
                    var action = $that.data('action');
                    var id = $that.data('id');
                    $that.on('click', function () {
                        var Id = $that.parent().parent().find('input').data('id')
                        if (BoxIndex !== -1) {
                            layer.msg("已有一个弹出窗口！");
                            return;
                        }
                        switch (action) {

                            // #region 查看详情
                            case 'Detailed':
                                var PrintText = $('#PrintText').val();
                                parent.tab.tabAdd({
                                    href: '../Material/BuyerDetailInfo?Id=' + Id + "&PrintText=" + PrintText,
                                    title: '采购详情',
                                    Closeabled: true
                                });
                                break;
                            // #endregion

                            // #region 查看电子合同
                            case 'Contract':
                                parent.tab.tabAdd({
                                    href: '../Material/Contract?Id=' + Id,
                                    title: '合同详情',
                                    Closeabled: true
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

    //#region 状态显示
    //采购单状态选择
    form.on('checkbox', function (data) {
        getInfo();
        return false;
    })
    //供应商选择
    form.on('select', function (data) {
        getInfo();
        return false;
    });
    //采购日期显示
    layui.use(['form', 'layedit', 'laydate'], function () {
        var form = layui.form(),
            layer = layui.layer,
            layedit = layui.layedit,
            laydate = layui.laydate;
    });
    //采购日期
    $("#Time1 input,#Time2 input").click(function () {
        layui.laydate({
            elem: this,
            choose: function (datas) {
                getInfo();
            }
        })
    })
    //选择显示
    function getInfo() {
        var obj = new Object();
        obj.StartTime = $("#Time1 input").val();
        obj.EndTime = $("#Time2 input").val();
        obj.ProduterId = $("select[name='ProduterId']").val();
        obj.CheckStatus = "";
        $(".aaa input[type='checkbox']").each(function () {
            if ($(this)[0].checked) {
                obj.CheckStatus += $(this).val() + "|";
            }
        })
        if (obj.StartTime != "" && obj.EndTime != "") {
            if (obj.EndTime <= obj.StartTime) {
                layer.msg("时间选择错误!");
                return false;
            }
        }
        btable.get(obj);
    }
    //#endregion


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

        //供应商管理跳转
        if (ProduterSelectId != "") {
            $('.Producer').css('display', 'none')
        }


    }).resize();
});

$(function () {
    ////得到大写金额
    var buyerMoney = $('#buyerMoney').html().trim();
    $('#ChangebuyerMoney').html(change(buyerMoney));
})

//#region 得到大写金额 
function change(str) {
    var je = "零壹贰叁肆伍陆柒捌玖";
    cdw = "仟佰拾億仟佰拾萬仟佰拾元角分";
    var newstring = (str * 100).toString(),
        newstringlog = newstring.length,
        newdw = cdw.substr(cdw.length - newstringlog),
        num0 = 0,//记录0的个数
        wan = 0, //记录万的个数
        dxje = ""; //记录大写金额
    for (var m = 1; m < newstringlog + 1; m++) {
        var xzf = newstring.substr(m - 1, 1),
            dzf = je.substr(xzf, 1),
            dw = newdw.substr(m - 1, 1);

        if (dzf == "零") {
            dzf = ""
            if (dw == "億") {
            } else if (dw == "萬") {
                dzf = "";
                wan++;
            } else if (dw == "元") {

            } else {
                dw = "";
            }
            num0 = num0 + 1;
        } else {
            if (num0 - wan > 0) {
                if (dw != "角") {
                    dzf = "零" + dzf;
                }
            }
            num0 = 0;
        }
        dxje = dxje + dzf + dw
    }
    if (newstring.length != 1) {
        if (newstring.substr(newstring.length - 2) == "00") {
            dxje = dxje + "整";
        } else {
            dxje = dxje;
        }
    }
    return dxje;
}
//#endregion

//#region 待下单中删除
function DeleteById(Id) {
    var obj = new Object();
    obj.Id = Id;
    layer.confirm('确认删除吗？', null, function (index) {
        jQuery.axpost('../../api/Material/DeleteDeliverById', JSON.stringify(obj), function (data) {
            layer.close(index);

            window.location.reload();

        });
    });
}

//#endregion

//#region通知下单
//下单 
var SinglePerson = "";
var SingleTime = "";
function WantBuyer(Id) {
    //parent.tab.tabAdd({
    //    href: '../Material/Contract?Id=' + Id,
    //    title: '下单详情',
    //    Closeabled: true
    //});
    location.href = '../Material/Contract?Id=' + Id;
}

//取消订单
function CancelOrder(Id) {
    var obj = new Object();
    obj.Id = Id;
    obj.Status = "已取消";
    obj.CheckStatus = "已取消"
    layer.confirm('确认取消订单吗？', null, function (index) {
        jQuery.axpost('../../api/Material/PrintContract', JSON.stringify(obj), function (data) {
            layer.close(index);
            window.location.reload();
            layer.msg(dataInfo.Message);
        });
    });
}
//#endregion 

//#region 打印合同,退货单
function Print(Id) {
    var obj = new Object();
    obj.Id = Id;
    obj.Status = "待送货品检";
    obj.CheckStatus = "待品检";
    obj.ContractNumber = $('#ContractNumber').val();
    obj.SinglePerson = $('#SinglePerson').val();
    obj.SignedTime = $('#SignedTime').val();
    obj.SLSMContacts = $('#SLSMContacts').val();
    obj.SLSMPhone = $('#SLSMPhone').val();
    obj.SLSMFaxNumber = $('#SLSMFaxNumber').val();
    obj.SLSMEmail = $('#SLSMEmail').val();
    obj.ContractContext = $('#ContractContext').val();
    var buyerStatus = $('#buyerStatus').val();
    var DeliverCountext = document.getElementsByName("DeliverCountext");
    var listCountext = new Array();
    for (var i = 0; i < DeliverCountext.length; i++) {
        listCountext += DeliverCountext[i].value + ",";
    }
    obj.DeliverCountext = listCountext;
    if (obj.SignedTime == "") {
        layer.msg("请选择签订时间!");
        return;
    }
    layer.confirm('确认打印合同吗？', null, function (index) {
        if (buyerStatus == "待下单") {
            jQuery.axpost('../../api/Material/PrintContract', JSON.stringify(obj), function (data) {
                //layer.Message(data.Message);
            })
        }
        //打印
        var countstr = document.getElementById("Div1").innerHTML;
        var newstr = document.getElementById("PrintDiv").innerHTML;
        var oldstr = document.body.innerHTML;
        document.body.innerHTML = newstr;
        $('#ContractNumber').val(obj.ContractNumber);
        $('#SignedTime').val(obj.SignedTime);
        var tata = document.execCommand("print");/* window.print(); 调用打印的功能*/
        if (tata) {  //点击取消后执行的操作
            document.body.innerHTML = countstr;
            window.location.reload();
        }

    })
}
//打印退货单
function PrintReturnDeliver(Id) {
    var countstr = $("body").children("div").innerHTML;;
    var newstr = document.getElementById("TableDiv").innerHTML;
    var oldstr = document.body.innerHTML;
    document.body.innerHTML = newstr;
    var tata = document.execCommand("print");/* window.print(); 调用打印的功能*/
    if (tata) {  //点击取消后执行的操作
        document.body.innerHTML = countstr;
        window.location.reload();
    }
}
//送货单
//#endregion

//#region 退货
function Return(Id) {
    var obj = new Object();
    obj.Id = Id;
    layer.confirm('确认退货吗？', null, function (index) {
        jQuery.axpost('../../api/Material/Return', JSON.stringify(obj), function (data) {
            layer.close(index);

            layer.msg(data.Message);
            setTimeout(function () { location.reload(); }, 1000)
        });
    });
}
//#endregion

//#region 限制textarea行数
$(function () {
    $('textarea').on('input propertychange', function () {
        
        var InputTextheight = $('textarea[name="DeliverCountext"]').height();
        var TextHeight = $('#DeliverCountext')[0].scrollHeight;
        if (InputTextheight < TextHeight) {
            layer.msg("输入行数不可以大过五行,否则打印无效!");
        }
    })
})
//#endregion

//#region 关闭
function CloseBtn() {
    var tab = parent.tab;
    tab.deleteTab(tab.getCurrentTabId());

}
//#endregion


