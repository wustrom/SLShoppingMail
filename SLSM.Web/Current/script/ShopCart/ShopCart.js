$(function () {
    PriceSum();
    // #region 删除购物车数据
    $('.ShopCartMain .main .container .shop_table.cart td.cart-actions .removeInfo').click(function () {
        var data = new Object();
        var that = this;
        data.ShopCartId = $(that).parent().parent().find('.hidShopCartId').val();
        jQuery.axadminpost("../../Api/UpImg/DeleteShopCart", data, function () {
            layer.msg("删除购物车记录成功！");
            $(that).parent().parent().remove();
            PriceSum();
        });
    });
    // #endregion

    // #region 更改购物数目
    $('.ShopCartMain .main .container .shop_table.cart .quantity .qty').change(function () {
        var data = new Object();
        var that = this;
        data.ShopCartId = $(that).parent().parent().parent().find('.hidShopCartId').val();
        data.Amount = $(that).val();
        var Amount = parseInt(data.Amount);
        if (Amount == NaN || Amount <= 0) {
            layer.msg("请输入大于0的整数");
            var sumprice = $(that).parent().parent().parent().find('.sumPrice').html();
            var onePrice = $(that).parent().parent().parent().find('.onePrice').html();
            $(that).val(parseInt(sumprice / onePrice));
            return;
        }
        jQuery.axpost("../../Api/ShopCart/ChangeAmount", JSON.stringify(data), function (dataInfo) {
            $(that).parent().parent().find('.w4 span').html(dataInfo.Message);
            PriceSum();
        });
    });

    $('.ShopCartMain .main .container .shop_table.cart .quantity .qty').change(function () {
        var data = new Object();
        var that = this;
        data.ShopCartId = $(that).parent().parent().parent().find('.hidShopCartId').val();
        data.Amount = $(that).val();
        var Amount = parseInt(data.Amount);
        if (Amount == NaN || Amount <= 0) {
            layer.msg("必须为大于0的整数");
            var sumprice = $(that).parent().parent().parent().find('.sumPrice').html();
            var onePrice = $(that).parent().parent().parent().find('.onePrice').html();
            $(that).val(parseInt(sumprice / onePrice));
            return;
        }
        jQuery.axpost("../../Api/ShopCart/ChangeAmount", JSON.stringify(data), function (dataInfo) {
            var sumprice = $(that).parent().parent().parent().find('.sumPrice').html((dataInfo.Message * Amount).toFixed(2));
            var onePrice = $(that).parent().parent().parent().find('.onePrice').html((dataInfo.Message * 1).toFixed(2));
            PriceSum();
        });
    });

    $('.ShopCartMain .main .container .shop_table.cart .quantity .minus').click(function () {
        var Amount = parseInt($(this).parent().find('.qty').val());
        if (Amount == 0) {
            return;
        }
        Amount--;
        $(this).parent().find('.qty').val(Amount);
        $('.ShopCartMain .main .container .shop_table.cart .quantity .qty').trigger('change');
    });

    $('.ShopCartMain .main .container .shop_table.cart .quantity .plus').click(function () {
        var Amount = parseInt($(this).parent().find('.qty').val());
        Amount++;
        $(this).parent().find('.qty').val(Amount);
        $('.ShopCartMain .main .container .shop_table.cart .quantity .qty').trigger('change');
    });
    // #endregion

    // #region 结算
    $('.ShopCartMain .main .container .shop_table.cart .actions-continue .btn-primary-lg').click(function () {
        var ShopCart = "";
        $('.ShopCartMain .main .container .shop_table.cart .product-thumbnail .hidShopCartId').each(function () {
            if ($(this).parent().find('.checkboxInfo')[0].checked) {
                ShopCart = ShopCart + $(this).val() + ",";
            }

        })
        if (ShopCart.length == 0) {
            layer.msg('请至少选择一件商品进行结算！');
        }
        else {
            ShopCart = ShopCart.substr(0, ShopCart.length - 1);
            window.location.href = '../../PayPage/Index?ShopCartId=' + ShopCart;
        }
    });
    // #endregion

    $(".AllcheckboxInfo").click(function () {
        if ($(this)[0].checked == false) {
            $(".checkboxInfo").each(function () {
                $(this)[0].checked = false
            })
        }
        else {
            $(".checkboxInfo").each(function () {
                $(this)[0].checked = true
            })
        }
        PriceSum();
    })

    $(".checkboxInfo").click(function () {
        PriceSum();
    })
})

// #region 计算购物车价格
function PriceSum() {
    var floatPrice = 0;
    $('.ShopCartMain .main .container .shop_table.cart td .sumPrice').each(function () {
        var check = $(this).parent().parent().parent().find(".checkboxInfo")[0].checked;
        if (!isNaN($(this).html()) && check) {
            var Price = parseFloat($(this).html());
            floatPrice = floatPrice + Price;
        }
    });
    $('.sumAllPrice').html(floatPrice.toFixed(2));
}

function PriceOneSum(that) {
    var floatPrice = 0;
    $('.ShopCartMain .main .container .shop_table.cart td .sumPrice').each(function () {
        var check = $(this).parent().parent().parent().find(".checkboxInfo")[0].checked;
        if (!isNaN($(this).html()) && check) {
            var Price = parseFloat($(this).html());
            floatPrice = floatPrice + Price;
        }
    });
    $('.sumAllPrice').html(floatPrice.toFixed(2));
}
// #endregion
