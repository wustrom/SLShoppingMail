/// <reference path="../diy.js" />
/// <reference path="../ajax.js" />

$(function () {
    $('.none .conbox .h2tit i').click(function () {
        $('.none').fadeOut(200)
    })
    $('.none .conbox .sendbxh .fs').click(function () {

        $('.none').fadeOut(200)
    })
    //读取数据
    getPage();

    // #region 定制效果点击
    $('#tong .designContainer .skuimgs .designImg').click(function () {
        $('#tong .designContainer .skuimgs .designImg img').each(function () {
            $(this).removeClass('sku_img_checked');
        })
        $(this).find('.itemImg').addClass('sku_img_checked');
        var src = $(this).find('.itemImg').attr('src');
        $('#tong .designContainer .imgbox img').attr('src', src);
    });
    // #endregion

})

// #region 定制效果
function designImg(that) {
    $('#tong .designContainer .skuimgs .designImg img').eq(0).attr('src', $("#HiddenAdminUrl").val() + $(that).parent().find('.hidBackView').val())
    $('#tong .designContainer .skuimgs .designImg img').eq(1).attr('src', $("#HiddenAdminUrl").val() + $(that).parent().find('.hidForntView').val())
    $('#tong .designContainer .skuimgs .designImg img').eq(0).trigger('click');
    //页面层
    layer.open({
        type: 1,
        title: "定制效果",
        closeBtn: 1,
        area: ['650px', '550px'],
        skin: 'layui-layer-nobg', //没有背景色
        shadeClose: false,
        content: $('#tong')
    });
}
// #endregion

//#region 退货
//退货页面
function TuiOrder(DetailId, item) {
    $('.none').fadeIn(200);
    $(".HiddenInfo #DetailId").val(DetailId);
    var div = $(item).parent().parent();
    var OrderNo = div.parent().find('.ztitem .s1 .OrderNo').html().trim();
    var OrderTime = div.parent().find('.ztitem .s1 .OrderTime').html().trim();
    var Name = div.find('.content .h2tit a').html().trim();
    var Color = div.find('.type label').html().trim();
    var TotalPrice = div.find('.price .mu').html().trim();
    var Amount = div.find('.num').html().trim();
    $('.conbox .desc .TuiNo').html(OrderNo);
    $('.none .conbox .desc .TuiTime').html(OrderTime);
    $('.none .conbox .store .content .h3tit a').html(Name);
    $('.none .conbox .store .content .desc .TuiColor').html(Color);
    $('.none .conbox .store .content .desc .TuiAmount').html(Amount);
    $('.none .conbox .store .content .desc .TuiTotalPrice').html(TotalPrice);
    $('.myorder.ricont.model.price a:last - child')
}
//退货信息确认
$(function () {
    $('.none .conbox .sendbxh .fs').click(function () {
        var ReturnText = $('.none .conbox .bd textarea').val();
        var DetailId = $(".HiddenInfo #DetailId").val();
        var Status = 7;
        var OrderId = $('.OrderList .ztitem .s2 #Id').val();
        var datas = { DetailId: DetailId, ReturnText: ReturnText, OrderId: OrderId, Status: Status };
        jQuery.axpost('../../Api/Order/ReturnInfo', JSON.stringify(datas), function (data) {
            layer.msg(data.Message);
        })
    });
})
// #endregion

// #region 其他
/////删除订单
//function DelEvaluate(Id) {

//    var datas = { Id: Id }
//    jQuery.axpost('../../Api/Order/DelateEvaluate', JSON.stringify(datas), function (data) {
//        layer.msg(data.Message);
//    });
//}
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

//function ListDeRead() {
//    layer.confirm('确认送达吗？', {
//        btn: ['确定', '取消']
//    }, function (index) {
//        layer.close(index);
//        $(".s1 input[type='checkbox']").each(
//            function (i, item) {
//                if (i != 0) {
//                    if ($(this).is(':checked')) {
//                        ToConfirm($(this).parent().parent().find('.s2 input[name="Id"]').val());
//                    }
//                }
//            })
//    }, null);




// #endregion

//Completed
// #region 请求数据
//全部
function AllOrder(page, obj) {
    jQuery.axpost('../../Api/Order/OrderCountByPage', JSON.stringify(obj), function (data) {
        $('#PageCountType').val("OrderCount");
        SetMessHtml(data.Model1, page);
    })
}
//待付款
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
//待发货
function DeliveryOrder(page, obj) {
    jQuery.axpost('../../Api/Order/OrderCountByPage', JSON.stringify(obj), function (data) {
        $('#PageCountType').val("DeliveryOrderCount");
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
//已完成
function CompletedOrder(page, obj) {
    jQuery.axpost('../../Api/Order/OrderCountByPage', JSON.stringify(obj), function (data) {
        $('#PageCountType').val("CompletedOrderCount");
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
    obj.PageSize = 50;
    var PageCountType = $('#PageCountType').val();
    if (PageCountType == "OrderCount") {
        AllOrder(page, obj);
    }
    else if (PageCountType == "PendingOrderCount") {
        obj.Name = "待付款";
        PendingOrder(page, obj);

    }
    else if (PageCountType == "DeliveryOrderCount") {
        obj.Name = "待发货";
        ReceivedOrder(page, obj);
    }
    else if (PageCountType == "ReceivedOrderCount") {
        obj.Name = "待收货";
        ReceivedOrder(page, obj);
    }
    else if (PageCountType == "EvaluatedOrderCount") {
        obj.Name = "待评价";
        EvaluatedOrder(page, obj);
    }
    else if (PageCountType == "CompletedOrderCount") {
        obj.Name = "已完成";
        CompletedOrder(page, obj);
    }
    else if (PageCountType == "RefundOrderCount") {
        obj.Name = "退货中";
        RefundOrder(page, obj);
    }
}
// #endregion

//#region 分页
//获得后一页
function getNextPage() {

    var CurrentPage = parseInt($('.propj .pagesize1 ul .active a')[0].innerText);
    var count = 0;
    var PageCountType = $('#PageCountType').val();
    if (PageCountType == "OrderCount") {
        count = parseInt($('#hiddOrderCount').val());
    }
    else if (PageCountType == "PendingOrderCount") {
        count = parseInt($('#hiddPendingOrderCount').val());
    }
    else if (PageCountType == "DeliveryOrderCount") {
        count = parseInt($('#hiddDeliveryOrderCount').val());
    }
    else if (PageCountType == "ReceivedOrderCount") {
        count = parseInt($('#hiddReceivedOrderCount').val());
    }
    else if (PageCountType == "EvaluatedOrderCount") {
        count = parseInt($('#hiddEvaluatedOrderCount').val());
    }
    else if (PageCountType == "CompletedOrderCount") {
        count = parseInt($('#hiddCompletedOrderCount').val());
    }
    else if (PageCountType == "RefundOrderCount") {
        count = parseInt($('#hiddRefundOrderCount').val());
    }
    if (CurrentPage < count) {
        getPage(CurrentPage + 1);
        getPageCount(CurrentPage + 1);
    }
}

//获得前一页
function getPrePage() {
    var CurrentPage = parseInt($('.propj .pagesize1 ul .active a')[0].innerText);
    if (CurrentPage > 1) {
        getPage(CurrentPage - 1);
        getPageCount(CurrentPage - 1);
    }
}
//设置当前页
function getPageCount(NowPage) {
    var count = 0;
    var PageCountType = $('#PageCountType').val();
    if (PageCountType == "OrderCount") {
        count = parseInt($('#hiddOrderCount').val());
    }
    else if (PageCountType == "PendingOrderCount") {
        count = parseInt($('#hiddPendingOrderCount').val());
    }
    else if (PageCountType == "DeliveryOrderCount") {
        count = parseInt($('#hiddDeliveryOrderCount').val());
    }
    else if (PageCountType == "ReceivedOrderCount") {
        count = parseInt($('#hiddReceivedOrderCount').val());
    }
    else if (PageCountType == "EvaluatedOrderCount") {
        count = parseInt($('#hiddEvaluatedOrderCount').val());

    }
    else if (PageCountType == "CompletedOrderCount") {
        count = parseInt($('#hiddCompletedOrderCount').val());
    }
    else if (PageCountType == "RefundOrderCount") {
        count = parseInt($('#hiddRefundOrderCount').val());
    }
    if (count == 0) {
        $('.propj .pagesize1').hide();
        $('.NoOrder').show();
    }
    else if (count == 1) {
        $('.propj .pagesize1').hide();
        $('.NoOrder').hide();
    }
    else {
        $('.NoOrder').hide();
        $('.propj .pagesize1').show();
    }
    $('.propj .pagesize1 ul').html(GetPageHtml(count, NowPage));
}
// #endregion

// #region 显示数据
function SetMessHtml(ListData, page) {
    var OutString = "";
    for (var i = 0; i < ListData.length; i++) {
        OutString = OutString + '<div class="OrderList">\
                    <div class="ztitem">\
                        <div class="s1">订单编号：<a href="../../userInfo/OrderDetail?OrderId=' + ListData[i].Id + '"><label class="OrderNo">' + ListData[i].OrderNo + '</label></a>  &nbsp;&nbsp;<label class="OrderTime"> ' + ListData[i].OrderTime + '</label></div>\
                        <div class="s2">\
                            <input type="hidden" value="'+ ListData[i].Id + '" Id="Id" />';
        if (ListData[i].Status == "待付款") {
            OutString = OutString + '<div class="color1" style="color:#ff0000">' + ListData[i].Status + '</div>';
        } else if (ListData[i].Status == "待评价") {
            OutString = OutString + '<div class="color1" style="color:#fbc400">' + ListData[i].Status + '</div>';
        } else if (ListData[i].Status == "待收货") {
            OutString = OutString + '<div class="color1" style="color:#669933">' + ListData[i].Status + '</div>';
        } else if (ListData[i].Status == "退款成功") {
            OutString = OutString + '<div class="color1" style="color:#7d6666">' + ListData[i].Status + '</div>';
        } else if (ListData[i].Status == "评价成功") {
            OutString = OutString + '<div class="color1" style="color:#adedf1">' + ListData[i].Status + '</div>';
        } else if (ListData[i].Status == "退款成功") {
            OutString = OutString + '<div class="color1" style="color:black">' + ListData[i].Status + '</div>';
        } else {
            OutString = OutString + '<div class="color1" style="color:red">' + ListData[i].Status + '</div>';
        }
        OutString = OutString + '</div>\
                    </div>';

        for (var j = 0; j < ListData[i].ListDetail.length; j++) {
            OutString = OutString + '<div class="model">\
                            <div class="imgbox">\
                                <a href="../../diy/index?Commodityid=' + ListData[i].ListDetail[j].CommodityId + '">\
                                    <img src="'+ $('#HiddenAdminUrl').val() + ListData[i].ListDetail[j].Image + '" alt="" />\
                                </a\>\
                            </div>\
                            <div class="content">\
                                <h2 class="h2tit">\
                                    <a href="../../diy/index?Commodityid=' + ListData[i].ListDetail[j].CommodityId + '">' + ListData[i].ListDetail[j].Name + '</a>\
                                </h2>\
                                <div class="type">\
                                    <label>'+ ListData[i].ListDetail[j].Color + '</label>/' + ListData[i].ListDetail[j].Attribute + '\
                            </div>\
                                <a onclick="designImg(this)" class="pen">定制效果</a>\
                                <input type="hidden" class="hidBackView" value="'+ ListData[i].ListDetail[j].BackImage + '"/>\
                                <input type="hidden" class="hidForntView" value="'+ ListData[i].ListDetail[j].FrontImage + '"/>\
                            </div>'
            if (ListData[i].Status == "待付款" || ListData[i].Status == "待发货") {
                OutString = OutString + '<div class="design">\
                                            <a onclick="StartDesign(this)" herf="javasript:;">自助设计</a>\
                                            <img src="../base/images/cuu.png" onclick="layer.tips(\''+ "您可以在商品上自助设计您的图案和文字，也可以联系我们的客服，让我们的设计师为您设计。" + '\', this);">\
                                            <input type="hidden" class="DetailId" value="' + ListData[i].ListDetail[j].Id + '">\
                                        </div>';
            }
            OutString = OutString + '<div class="num">' + ListData[i].ListDetail[j].Amount + '</div>\
                            <div class="price">\
                                <div class="mu">￥'+ ListData[i].TotalPrice + '</div>\
                      <a class="d1" href = "../../diy/index?Commodityid=' + ListData[i].ListDetail[j].CommodityId + '" > 商品详情</a >';
            if (ListData[i].Status == "待评价") {
                OutString = OutString + '<a class="d3" href = "../../userInfo/Evaluate?OrderId=' + ListData[i].Id + '" >去评价</a>';
                OutString = OutString + '<a class="d2" onclick="TuiOrder(' + ListData[i].Id + ',this)">退货申请</a>';
            }
            if (ListData[i].Status == "待付款") {
                OutString = OutString + '<a class="d3" onclick="ToPay(' + ListData[i].Id + ')" >去付款</a>';
            }
            if (ListData[i].Status == "待收货") {
                OutString = OutString + '<a class="d3" onclick="ToConfirm(' + ListData[i].Id + ')" >确认收货</a>';
            }
            OutString = OutString + '</div></div></div>';
        }
    }
    $('.ricont .OrderContent').html(OutString);
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

// #region 样式处理
//全部信息样式处理
function SetAllOrder(value) {
    $('#PageCountType').val("OrderCount");
    $(value).parent().parent().find('li').removeClass('current');
    $(value).parent().addClass('current');
    getPage(1);
}

//待付款样式处理
function SetPendingOrder(value) {
    $('#PageCountType').val("PendingOrderCount");
    $(value).parent().parent().find('li').removeClass('current');
    $(value).parent().addClass('current');
    getPage(1);
}
//待发货样式处理
function SetDeliveryOrder(value) {
    $('#PageCountType').val("DeliveryOrderCount");
    $(value).parent().parent().find('li').removeClass('current');
    $(value).parent().addClass('current');
    getPage(1);
}
//待收货样式处理
function SetReceivedOrder(value) {
    $('#PageCountType').val("ReceivedOrderCount");
    $(value).parent().parent().find('li').removeClass('current');
    $(value).parent().addClass('current');
    getPage(1);
}
//待评价样式处理
function SetEvaluatedOrder(value) {
    $('#PageCountType').val("EvaluatedOrderCount");
    $(value).parent().parent().find('li').removeClass('current');
    $(value).parent().addClass('current');
    getPage(1);
}
//已完成样式处理
function SetCompletedOrder(value) {
    $('#PageCountType').val("CompletedOrderCount");
    $(value).parent().parent().find('li').removeClass('current');
    $(value).parent().addClass('current');
    getPage(1);
}
//退货样式处理
function SetRefundOrder(value) {
    $('#PageCountType').val("RefundOrderCount");
    $(value).parent().parent().find('li').removeClass('current');
    $(value).parent().addClass('current');
    getPage(1);
}
// #endregion

// #region 去付款
function ToPay(ID) {
    var data = new Object();
    data.Id = ID;
    layer.confirm('选择支付类型', {
        btn: ['支付宝', '微信', '线下支付'],//按钮
        title: '支付类型',
        closeBtn: 1,
        btn1: function () {//支付宝
            data.PayType = 2;
            jQuery.axpost("../../api/Order/ChangeOrderPayType", JSON.stringify(data), function (datas) {
                getPage();
                $('body').html(datas.Message);
            });
        },
        btn2: function () {//微信
            data.PayType = 3;
            jQuery.axpost("../../api/Order/ChangeOrderPayType", JSON.stringify(data), function (datas) {
                getPage();
                $('.dealert.wechatpay').css('display', 'block');
                $('.dealert.wechatpay .detailcontent .content img').attr('src', "../../../Api/Home/GetQrCode?data=" + datas.Message + "&OrderNo=" + datas.Model1);
                setInterval(function () {
                    jQuery.axget("../../api/order/WeiChatOrder?OrderNo=" + datas.Model1, function (dataInfo) {
                        if (dataInfo.Message == "该订单支付成功！") {
                            getPage();
                            $('.dealert.wechatpay').css('display', 'none');
                        }
                    });
                }, 5000);
            });
        },
        btn3: function () {//线下支付
            data.PayType = 1;
            jQuery.axpost("../../api/Order/ChangeOrderPayType", JSON.stringify(data), function () {
                getPage();
                layer.msg('已转为线下支付');
            });
        },
    }
    );
}
// #endregion

function StartDesign(that, Id) {

    var AdminUrl = $('#HiddenAdminUrl').val();
    var obj = new Object();
    obj.Id = Id;
    $('#hiddDetailId').val(obj.Id);
    jQuery.axpost('../../Api/Order/DetailDesign', JSON.stringify(obj), function (data) {
        //移除原有图片框
        $('.orderalert .conbox .rightbox .bd .model.model1 .left .imgbox').remove();
        //移除原有背景框
        $('.orderalert .conbox .leftbox .bjgbox').remove();
        for (var i = 0; i < data.ListData.length; i++) {
            // #region 添加图片框
            var ImageUrl = "";
            if (data.ListData[i].Image != null) {
                ImageUrl = AdminUrl + data.ListData[i].Image
            }
            else {
                ImageUrl = AdminUrl + data.ListData[i].MainImage
            }
            $('.orderalert .conbox .rightbox .bd .model.model1 .left').append('<div class="imgbox">\
                                                                                <img src= "'+ ImageUrl + '" onclick="ShowBjgBox(' + i + ')" >\
                                                                                    <span>\
                                                                                        '+ data.ListData[i].PrintingPosition + '\
                                                                                    </span>\
                                                               </div>');
            // #endregion

            // #region 添加背景框
            var active = "";
            if (i == 0) {
                active = "active";
            }
            var str = '<div class="bjgbox ' + active + '">\
                            <div class="imgbox" >\
                                <i></i>\
                                <img src="'+ AdminUrl + data.ListData[i].MainImage + '" alt="">\
                                <input type="hidden" value="'+ data.ListData[i].Id + '" class="designId" >\
                            </div>\
                            <div style="">\
                                <div class="twowords">\
                                    ';
            if (data.ListData[i].Content != null) {
                str = str + data.ListData[i].Content;
            }
            else {
                str = str + '<div class="pic1">\
                             </div>\
                             <div class="picbox" id="draggable">\
                             </div>\
                             <div class="bx">\
                             </div>';
            }
            str = str + "</div>\
                        </div>\
                    </div>";
            $('.orderalert .conbox .leftbox').append(str);
            // #endregion

            $('.bjgbox img').each(function () {
                ConvertImg(this);
            });
            AddMove();
            $('.orderalert').show();
        }
    })
}

function ShowBjgBox(num) {
    layer.load(1);
    CreateImage(num);
}

// #region 图片方法
//创建图片
function CreateImage(num, hidden) {
    var width = '480';
    var height = '480';
    $('.mydiv').each(function () {
        $(this).children('div').eq(1).hide();
    });
    html2canvas(document.querySelector(".bjgbox.active")).then(function (canvas) {
        var a = Canvas2Image.convertToPNG(canvas, width, height);
        $('.bjgbox img').each(function () {
            ConvertBackImg(this);
        });
        var datas = new Object();
        // #region 初始参数
        datas.DesignId = $(".bjgbox.active .imgbox input").val();
        datas.OrderDetailId = $('#hiddDetailId').val();
        datas.Image = a.src;
        for (var i = 0; i < $(".bjgbox").length; i++) {
            if ($(".bjgbox").eq(i).hasClass('active')) {
                datas.PrintingPosition = $(".orderalert .conbox .rightbox .bd .model.model1 .left .imgbox").eq(i).find("span").html().trim();
                datas.Content = repalceKey($('.orderalert .conbox .leftbox .bjgbox').eq(i).find('.twowords').html());
                while (datas.Content.indexOf("data:image") != -1) {
                    datas.Content = repalceKey($('.orderalert .conbox .leftbox .bjgbox').eq(i).find('.twowords').html());
                }
                $(".orderalert .conbox .rightbox .bd .model.model1 .left .imgbox").eq(i).find("img").attr('src', a.src);
            }
        }
        var input = $(".bjgbox.active .imgbox input");
        // #endregion
        jQuery.axpost('../../Api/Order/DetailPositionDesign', JSON.stringify(datas), function (data) {
            $(input).val(data.Message);
            layer.closeAll('loading');
        })

        $('.orderalert .conbox .leftbox .bjgbox.active').removeClass('active');
        $('.orderalert .conbox .leftbox .bjgbox:eq(' + num + ')').addClass('active');
        $('.leftbox .bjgbox i').each(function () {
            $(this).show();
        });
        if (hidden == true) {
            $('.orderalert').hide();
        }
        $('.bjgbox img').each(function () {
            ConvertImg(this);
        });
    });
}


//替换所有html的特殊符号
function repalceKey(str) {
    str = str.replace(/'/g, "Single_quotation&marks");
    str = str.replace(/\"/g, 'Double_quotation&marks');
    str = str.replace(/\\/g, 'BackSlash&marks');
    return str;
}
// #endregion