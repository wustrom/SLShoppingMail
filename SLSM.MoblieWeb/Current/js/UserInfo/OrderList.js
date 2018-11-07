

$(function () {
    getPage();
})


// #region 请求数据

//全部
function AllOrder(page, obj) {
    jQuery.axpost('../../Api/Order/OrderCountByPage', JSON.stringify(obj), function (data) {
        $('#PageCountType').val("OrderCount");
        SetMessHtml(data.Model1, page);
    })
}
// 待付款
function PendingOrder(page, obj) {
    jQuery.axpost('../../Api/Order/OrderCountByPage', JSON.stringify(obj), function (data) {
        $('#PageCountType').val("PendingOrderCount");
        SetMessHtml(data.Model1, page);
    });
}
//待收货
function ReceivedOrder(page, obj) {
    jQuery.axpost('../../Api/Order/OrderCountByPage', JSON.stringify(obj), function (data) {
        $('#PageCountType').val("ReceivedOrderCount");
        SetMessHtml(data.Model1, page);
    });
}
//待评价
function EvaluatedOrder(page, obj) {
    jQuery.axpost('../../Api/Order/OrderCountByPage', JSON.stringify(obj), function (data) {
        $('#PageCountType').val("EvaluatedOrderCount");
        SetMessHtml(data.Model1, page);
    });
}
//退货
function RefundOrder(page, obj) {
    jQuery.axpost('../../Api/Order/OrderCountByPage', JSON.stringify(obj), function (data) {
        $('#PageCountType').val("RefundOrderCount");
        SetMessHtml(data.Model1, page);
    });
}
// #endregion

// #region 获得全部数据页面
function getPage(page) {
    var obj = new Object();
    if (page == null || page == undefined) {
        obj.PageNo = 1;
    }
    else if (!isNaN(page)) {
        obj.PageNo = page;
    }
    else {
        obj.PageNo = $(page).children('a')[0].innerText;
    }
    obj.PageSize = 999;
    var PageCountType = $('#PageCountType').val();
    if (PageCountType == "OrderCount") {
        AllOrder(page, obj);
    }
    else if (PageCountType == "PendingOrderCount") {
        obj.Name = "待付款";
        PendingOrder(page, obj);

    }
    else if (PageCountType == "ReceivedOrderCount") {
        obj.Name = "待收货";
        ReceivedOrder(page, obj);
    }
    else if (PageCountType == "EvaluatedOrderCount") {
        obj.Name = "待评价";
        EvaluatedOrder(page, obj);
    }
    else if (PageCountType == "RefundOrderCount") {
        obj.Name = "退货中";
        RefundOrder(page, obj);
    }
}
// #endregion

//确认收货
function ToConfirm(Id) {
    var datas = { Id: Id }
    layer.confirm('是否确认收货！？', {
        closeBtn: 0,
        btn: ['是', '否'] //按钮
    }, function (index) {
        jQuery.axpost('../../Api/Order/EnterThing', JSON.stringify(datas), function (data) {
            layer.close(index);
            layer.msg(data.Message);
            getPage();
        });
    }, function (index) {
        layer.close(index);
    });
}


// #region 取消订单
function ToCancel(Id) {
    var datas = { Id: Id }
    layer.confirm('是否确认取消订单！？', {
        closeBtn: 0,
        btn: ['是', '否'] //按钮
    }, function (index) {
        jQuery.axpost('../../Api/Order/CancelOrder', JSON.stringify(datas), function (data) {
            layer.close(index);
            layer.msg(data.Message);
            window.location.reload();
        });
    }, function (index) {
        layer.close(index);
    });
}
// #endregion

// #region 样式处理
//全部信息样式处理
function SetAllOrder(value) {
    $('#PageCountType').val("OrderCount");
    $(value).parent().parent().find('li').removeClass('active');
    $(value).parent().addClass('active');
    getPage(1);
}
//待付款样式处理
function SetPendingOrder(value) {
    $('#PageCountType').val("PendingOrderCount");
    $(value).parent().parent().find('li').removeClass('active');
    $(value).parent().addClass('active');
    getPage(1);
}
//待收货样式处理
function SetReceivedOrder(value) {
    $('#PageCountType').val("ReceivedOrderCount");
    $(value).parent().parent().find('li').removeClass('active');
    $(value).parent().addClass('active');
    getPage(1);
}
//待评价样式处理
function SetEvaluatedOrder(value) {
    $('#PageCountType').val("EvaluatedOrderCount");
    $(value).parent().parent().find('li').removeClass('active');
    $(value).parent().addClass('active');
    getPage(1);
}
//退货样式处理
function SetRefundOrder(value) {
    $('#PageCountType').val("RefundOrderCount");
    $(value).parent().parent().find('li').removeClass('active');
    $(value).parent().addClass('active');
    getPage(1);
}
// #endregion

// #region 显示数据
function SetMessHtml(ListData, page) {
    var OutString = "";
    for (var i = 0; i < ListData.length; i++) {
        OutString = OutString + '  <div class="item">\
            <div class="clearfix hd" >\
                <div class="fl">\
                    <p>订单编号：'+ ListData[i].OrderNo + '</p>\
                </div>\
                <div class="fr">';
        if (ListData[i].Status == "待付款") {
            OutString = OutString + '<p class="notice" style="color:#ff0000">' + ListData[i].Status + '</p>';
        } else if (ListData[i].Status == "待评价") {
            OutString = OutString + '<p class="notice" style="color:#fbc400">' + ListData[i].Status + '</p>';
        } else if (ListData[i].Status == "待收货") {
            OutString = OutString + '<p class="notice" style="color:#669933">' + ListData[i].Status + '</p>';
        } else if (ListData[i].Status == "退款成功") {
            OutString = OutString + '<p class="notice" style="color:#7d6666">' + ListData[i].Status + '</p>';
        } else if (ListData[i].Status == "评价成功") {
            OutString = OutString + '<p class="notice" style="color:#adedf1">' + ListData[i].Status + '</p>';
        }
        else {
            OutString = OutString + '<p class="notice" style="color:red">' + ListData[i].Status + '</p>';
        }
        OutString = OutString + ' </div>\
                    </div >';
        for (var j = 0; j < ListData[i].ListDetail.length; j++) {
            OutString = OutString + '<div class="bd">\
                <ul>\
                    <li>\
                        <div class="img">\
                            <img src="'+ $('#HiddenAdminUrl').val() + ListData[i].ListDetail[j].FrontImage + '" alt="">\
                                </div>\
                            <div class="lis-info">\
                                <h4>'+ ListData[i].ListDetail[j].Name + '</h4>\
                                <p><lable>'+ ListData[i].ListDetail[j].Color + '</lable>/' + ListData[i].ListDetail[j].Attribute + '</p>\
                                <p onclick="designImg(this)" class="dz">定制效果</p>\
                                <input type="hidden" class="hidBackView" value="'+ ListData[i].ListDetail[j].BackImage + '"/>\
                                <input type="hidden" class="hidForntView" value="'+ ListData[i].ListDetail[j].FrontImage + '"/>\
                            </div>\
                            <div class="money">\
                                <p>￥'+ ListData[i].TotalPrice + '</p>\
                                <p>'+ ListData[i].ListDetail[j].Amount + '</p>\
                            </div>\
                            </li>\
                        </ul>\
                    </div>\
                    <div class="clearfix item-info">';
        }
        OutString = OutString + ' <div class="fl">\
                            <p>'+ ListData[i].OrderTime + '</p>\
                        </div>\
                        <div class="fr">';
        OutString = OutString + '<a  class="btn" href = "../../userInfo/OrderDetail?OrderId=' + ListData[i].Id + '" >查看详情</a>';
        if (ListData[i].Status == "待评价") {
            OutString = OutString + '<a  class="btn" href = "../../userInfo/ReturnGood?OrderId=' + ListData[i].Id + '" >退货申请</a>';
            OutString = OutString + '<a  class="btn" href = "../../userInfo/Evaluate?OrderId=' + ListData[i].Id + '">去评价</a>';
        }
        if (ListData[i].Status == "待付款") {
            OutString = OutString + '<a class="btn" onclick="ToPay(' + ListData[i].Id + ')" >去付款</a>';
        }
        if (ListData[i].Status == "待收货") {
            OutString = OutString + '<a class="btn" onclick="ToConfirm(' + ListData[i].Id + ')" >确认收货</a>';
        }
        OutString = OutString + '</div>\
                    </div>\
                </div> ';
    }
    $('.my-order-bd .item').html(OutString);
    if (page == null || page == undefined) {
        getPageCount(1);
    }
    else if (!isNaN(page)) {
        getPageCount(parseInt(page));
    }
    else {
        getPageCount(parseInt($(page).children('a')[0].innerText));
    }
}
// #endregion

// #region 设置当前页
function getPageCount(NowPage) {
    var count = 0;
    var PageCountType = $('#PageCountType').val();
    if (PageCountType == "OrderCount") {
        count = parseInt($('#hiddOrderCount').val());
    }
    else if (PageCountType == "PendingOrderCount") {
        count = parseInt($('#hiddPendingOrderCount').val());
    }
    else if (PageCountType == "ReceivedOrderCount") {
        count = parseInt($('#hiddReceivedOrderCount').val());
    }
    else if (PageCountType == "EvaluatedOrderCount") {
        count = parseInt($('#hiddEvaluatedOrderCount').val());

    }
    else if (PageCountType == "RefundOrderCount") {
        count = parseInt($('#hiddRefundOrderCount').val());
    }
    if (count == 0) {
        $('.NoOrder').show();
    }
    else {
        $('.NoOrder').hide();

    }
    $('.propj .pagesize1 ul').html(GetPageHtml(count, NowPage));

}
// #endregion

// #region 去付款
function ToPay(ID) {
    window.location.href = '../../../PayPage/OrderPayPage?OrderId=' + ID;
    //layer.confirm('选择支付类型', {
    //    btn: ['微信', '线下支付'],//按钮
    //    title: '支付类型',
    //    closeBtn: 0,
    //    btn1: function () {//支付宝
    //        data.PayType = 2;
    //        jQuery.axpost("../../api/Order/ChangeOrderPayType", JSON.stringify(data), function (datas) {
    //            $('body').html(datas.Message);
    //        });
    //    },
    //    btn1: function () {//微信
    //        data.PayType = 3;
    //        jQuery.axpost("../../api/Order/ChangeOrderPayType", JSON.stringify(data), function (datas) {
    //            getPage();
    //            fCharge(datas.Model1);
    //        });
    //    },
    //    btn2: function () {//线下支付
    //        data.PayType = 1;
    //        jQuery.axpost("../../api/Order/ChangeOrderPayType", JSON.stringify(data), function () {
    //            getPage();
    //            layer.msg('已转为线下支付');
    //        });
    //    },
    //});
}
// #endregion

// #region 微信支付模块
//初始化微信支付环境
function fCharge(Model) {
    if (typeof WeixinJSBridge == "undefined") {
        if (document.addEventListener) {
            document.addEventListener('WeixinJSBridgeReady', onBridgeReady, false);
        } else if (document.attachEvent) {
            document.attachEvent('WeixinJSBridgeReady', onBridgeReady);
            document.attachEvent('onWeixinJSBridgeReady', onBridgeReady);
        }
    } else {
        fPostCharge(Model);
    }
}
//提交订单数据
function fPostCharge(Model) {
    var index = layer.load(1);
    $.ajax({
        type: "post",
        data: "totalfee=" + Model.TotalPrice + "&out_trade_no=" + Model.OrderNo,
        url: "/Home/MeterRecharge",
        success: function (json) {
            layer.close(index);
            onBridgeReady(json);
        },
        error: function () {
            layer.close(index);
            layer.msg('调用微信支付模块失败，请稍后再试。');
        }
    })
}
//调用微信支付模块
function onBridgeReady(json) {
    WeixinJSBridge.invoke(
        'getBrandWCPayRequest', {
            "appId": json.appId,     //公众号名称，由商户传入
            "timeStamp": json.timeStamp,         //时间戳，自1970年以来的秒数
            "nonceStr": json.nonceStr, //随机串
            "package": json.packageValue,
            "signType": "MD5",         //微信签名方式:
            "paySign": json.paySign //微信签名
        },
        function (res) {
            if (res.err_msg == "get_brand_wcpay_request:ok") {
                //alert("支付成功,请稍后查询余额,如有疑问,请联系管理员.");
                location.href = "../../UserInfo/MyOrderList";
            }
            else {
                location.href = "../../UserInfo/MyOrderList";
            }
        }
    );
}
// #endregion