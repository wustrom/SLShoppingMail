$(function () {

    $('.panel_panel .payType span').click(function () {
        $('.panel_panel .payType span').removeClass('active');
        $(this).addClass('active');
    })

    // #region 输入框特效
    $(".InputDiv input[type='text']").focus(function () {
        $(this).parent().find('.nexthr').addClass("Select");
        $(this).parent().find('label').addClass("Show");
    })

    $(".InputDiv input[type='text']").blur(function () {
        var value = $(this).val();
        if (value == "" || value == undefined) {
            $(this).parent().find('.nexthr').addClass("error");
            $(this).parent().find('.error-text').show();
            $(this).parent().find('label').removeClass("Show");
        }
        else {
            $(this).parent().find('.nexthr').removeClass("error");
            $(this).parent().find('.nexthr').removeClass("Select");
            $(this).parent().find('.error-text').hide();
            $(this).parent().find('label').addClass("Show");
        }
    })
    // #endregion

    // #region 发票信息
    $(".panel_panel .panel-context ul.Invoice span").click(function () {
        $(".panel_panel .panel-context ul.Invoice span").removeClass('active');
        $(this).addClass('active');
        if ($(this).is($(".panel_panel .panel-context ul.Invoice span").eq(1))) {
            $(".detailBtn").show();
        }
        else {
            $(".detailBtn").hide();
        }
    })

    $(".panel_panel .panel-context .detailBtn .detailUl span").click(function () {
        $(".panel_panel .panel-context .detailBtn .detailUl span").removeClass('active');
        $(this).addClass('active');
        if ($(this).is($(".panel_panel .panel-context .detailBtn .detailUl span").eq(1))) {
            $(".detailInfo").show();
        }
        else {
            $(".detailInfo").hide();
        }
    })
    // #endregion

    // #region 地址详情
    $(".china-city .toggle-icon").click(function () {
        if ($(this).hasClass('fa-angle-down')) {
            $(this).parent().parent().find('.overlay').show();
            $(this).removeClass('fa-angle-down');
            $(this).addClass('fa-angle-up');
        }
        else {
            $(this).parent().parent().find('.overlay').hide();
            $(this).addClass('fa-angle-down');
            $(this).removeClass('fa-angle-up');
        }
    })

    $(".china-city .input .state").click(function () {
        if ($(this).parent().find('.toggle-icon').hasClass('fa-angle-down')) {
            $(this).parent().parent().find('.overlay').show();
            $(this).parent().find('.toggle-icon').removeClass('fa-angle-down');
            $(this).parent().find('.toggle-icon').addClass('fa-angle-up');
            $(this).parent().parent().find('.overlay .wrap.province').show();
            $(this).parent().parent().find('.overlay .wrap.city').hide();
            $(this).parent().parent().find('.overlay .wrap.district').hide();
        }
        else {
            $(this).parent().parent().find('.overlay .wrap.province').show();
            $(this).parent().parent().find('.overlay .wrap.city').hide();
            $(this).parent().parent().find('.overlay .wrap.district').hide();
        }
    })

    $(".china-city .input .city").click(function () {
        if ($(this).html().trim() == "城市") {
            return;
        }
        if ($(this).parent().find('.toggle-icon').hasClass('fa-angle-down')) {
            $(this).parent().parent().find('.overlay').show();
            $(this).parent().find('.toggle-icon').removeClass('fa-angle-down');
            $(this).parent().find('.toggle-icon').addClass('fa-angle-up');
            $(this).parent().parent().find('.overlay .wrap.province').hide();
            $(this).parent().parent().find('.overlay .wrap.city').show();
            $(this).parent().parent().find('.overlay .wrap.district').hide();
        }
        else {
            $(this).parent().parent().find('.overlay .wrap.province').hide();
            $(this).parent().parent().find('.overlay .wrap.city').show();
            $(this).parent().parent().find('.overlay .wrap.district').hide();
        }
    })

    $(".china-city .input .district").click(function () {
        if ($(this).html().trim() == "区/县") {
            return;
        }
        if ($(this).parent().find('.toggle-icon').hasClass('fa-angle-down')) {
            $(this).parent().parent().find('.overlay').show();
            $(this).parent().find('.toggle-icon').removeClass('fa-angle-down');
            $(this).parent().find('.toggle-icon').addClass('fa-angle-up');
            $(this).parent().parent().find('.overlay .wrap.province').hide();
            $(this).parent().parent().find('.overlay .wrap.city').hide();
            $(this).parent().parent().find('.overlay .wrap.district').show();
        }
        else {
            $(this).parent().parent().find('.overlay .wrap.province').hide();
            $(this).parent().parent().find('.overlay .wrap.city').hide();
            $(this).parent().parent().find('.overlay .wrap.district').show();
        }
    })

    $(".addressItemBase").click(function () {
        $(".addressItemBase").removeClass('active');
        $(this).addClass('active');
    })

    // #endregion

    // #region 地址按钮绑定

    bindDefaultAddr();
    // #endregion

    // #region 发票按钮绑定
    function bindDefaultInvoice() {

        // #region 设置为默认发票
        $('.shopmain .credit .Invoice .RightPart a.default').unbind('click');
        $('.shopmain .credit .Invoice .RightPart a.default').click(function () {
            var data = new Object();
            var that = this;
            data.Id = $(that).parent().find('.InvoiceId').val();
            jQuery.axpost("../../api/user/UpInvoiceTime", JSON.stringify(data), function (datas) {
                $('.shopmain .credit .Invoice .LeftPart .default').each(function () {
                    $(this).css('display', 'none');
                })
                $('.shopmain .credit .Invoice .RightPart a:nth-child(3n+2)').each(function () {
                    $(this).css('display', 'block');
                })
                $(that).css('display', 'none');
                var div = $(that).parent().parent();
                div.find('.LeftPart i').trigger('click');
                div.find('.LeftPart .default').css('display', 'block');
            });
        });
        // #endregion

        // #region 选中项
        $('.shopmain .credit .Invoice .LeftPart i').unbind('click');
        $('.shopmain .credit .Invoice .LeftPart i').click(function () {
            $('.shopmain .credit .Invoice .LeftPart i').removeClass('current')
            $(this).addClass('current')
        })
        // #endregion

        // #region 修改收货地址
        $('.shopmain .credit .Invoice .RightPart a.edit').unbind('click');
        $('.shopmain .credit .Invoice .RightPart a.edit').click(function () {
            $('.addaddress.Invoice').show();
            $('.addaddress.Invoice .mainbox .h2tit .s1').html('修改发票');
            // #region 输入信息
            var item = $(this).parent().parent();
            $('input[name="TypeInvoice"]').each(function () {
                if ($(this).val() == item.find('.LeftPart .s3 span').html().trim()) {
                    $(this).trigger('click');
                }
            });
            $('.addaddress.Invoice .mainbox .model .s2 .words.Title').val(item.find('.LeftPart .s1 span').html().trim());
            $('.addaddress.Invoice .mainbox .model .s2 .words.DutyParagraph').val(item.find('.LeftPart .s2 span').html().trim());
            $('.addaddress.Invoice .mainbox .model .s2 .words.MobiePhone').val(item.find('.LeftPart .MobliePhone').val());
            $('.addaddress.Invoice .mainbox .model .s2 .words.OpeningBank').val(item.find('.LeftPart .OpeningBank').val());
            $('.addaddress.Invoice .mainbox .model .s2 .words.BankAccount').val(item.find('.LeftPart .BankAccount').val());


            // #endregion
            var itemArry = item.find('.LeftPart .Address').val().split(' ');
            $('.addaddress.Invoice .mainbox .model .s2 textarea').val(itemArry[3].trim());
            $('.addaddress.Invoice .mainbox .model .s2 select option').each(function () {
                $(this).removeAttr("selected");
                $(this)[0].selected = false;
            })
            $("#province1").find("option[value='" + itemArry[0].trim() + "']").attr("selected", true);
            $("#province1").find("option[value='" + itemArry[0].trim() + "']")[0].selected = true;
            $("#province1").trigger("change");
            $("#city1").find("option[value='" + itemArry[1].trim() + "']").attr("selected", true);
            $("#city1").find("option[value='" + itemArry[1].trim() + "']")[0].selected = true;
            $("#city1").trigger("change");
            $("#area1").find("option[value='" + itemArry[2].trim() + "']").attr("selected", true);
            $("#area1").find("option[value='" + itemArry[2].trim() + "']")[0].selected = true;
            $('#hiddenInvoiceId').val(item.find('.RightPart .InvoiceId').val());
        });
        // #endregion

        // #region 删除发票
        $('.shopmain .credit .Invoice .RightPart a.del').unbind('click');
        $('.shopmain .credit .Invoice .RightPart a.del').click(function () {
            var item = $(this).parent().parent();
            var data = new Object();
            data.Id = $(item).find('.InvoiceId').val();
            jQuery.axpost("../../api/user/DeleteInvoice", JSON.stringify(data), function (datas) {
                layer.msg('删除成功！');
                $(item).remove();
            });
        });
        // #endregion
    }
    bindDefaultInvoice();

    // #region 新增发票
    $('#addInvoice').click(function () {
        $('.addaddress.Invoice').show();
        $('.addaddress.Invoice .mainbox .h2tit .s1').html('新增发票');
        $('.addaddress.Invoice .mainbox .model .s2 .words.Title').val('');
        $('.addaddress.Invoice .mainbox .model .s2 .words.DutyParagraph').val('');
        $('.addaddress.Invoice .mainbox .model .s2 .words.MobiePhone').val('');
        $('.addaddress.Invoice .mainbox .model .s2 .words.OpeningBank').val('');
        $('.addaddress.Invoice .mainbox .model .s2 .words.BankAccount').val('');
        $('.addaddress.Invoice .mainbox .model .s2 textarea').val('');
        $('input[name="TypeInvoice"]:eq(0)').trigger('click')
        $("input[name=jizai]:eq(0)").attr("checked", 'checked');
        $('.addaddress.Invoice .mainbox .model .s2 select option').each(function () {
            $(this).removeAttr("selected");
            $(this)[0].selected = false;
        })
        $('#area').find("option:gt(0)").remove();
        $('#city').find("option:gt(0)").remove();
    });

    // #endregion

    $('input[name="TypeInvoice"]').change(function () {
        var typeInvoice = $('input[name="TypeInvoice"]:checked').val();
        if (typeInvoice != "专用发票") {
            $('.addaddress.Invoice .model .s2 .OpeningBank').attr('disabled', true);
            $('.addaddress.Invoice .model .s2 .BankAccount').attr('disabled', true);
            $('#province1').attr('disabled', true);
            $('#city1').attr('disabled', true);
            $('#area1').attr('disabled', true);
            $('.addaddress.Invoice .model .s2 textarea').attr('disabled', true);
            $('.addaddress.Invoice .model .s2 .MobiePhone').attr('disabled', true);
        }
        else {
            $('.addaddress.Invoice .model .s2 .OpeningBank').attr('disabled', false);
            $('.addaddress.Invoice .model .s2 .BankAccount').attr('disabled', false);
            $('#province1').attr('disabled', false);
            $('#city1').attr('disabled', false);
            $('#area1').attr('disabled', false);
            $('.addaddress.Invoice .model .s2 textarea').attr('disabled', false);
            $('.addaddress.Invoice .model .s2 .MobiePhone').attr('disabled', false);
        }
    });

    // #endregion

    // #region 新增收货地址
    $('#addaddress').click(function () {
        $('.addaddress.address .mainbox .h2tit .s1').html('新增收货地址');
        $('.addaddress.address .mainbox .model .s2 .words.name').val('');
        $('.addaddress.address .mainbox .model .s2 .words.phone').val('');
        $('.addaddress.address .mainbox .model .s2 textarea').val('');
        $('.addaddress.address .mainbox .model .s2 select option').each(function () {
            $(this).removeAttr("selected");
            $(this)[0].selected = false;
        })
        $('#area').find("option:gt(0)").remove();
        $('#city').find("option:gt(0)").remove();

    });

    // #endregion

    // #region 保存按钮
    // #region 地址
    $('.addaddress.address .mainbox .keep').unbind();
    $('.addaddress.address .mainbox .keep').click(function () {
        var data = new Object();
        data.ContactName = $('.addaddress.address .mainbox .model .s2 .words.name').val();
        data.ContactPhone = $('.addaddress.address .mainbox .model .s2 .words.phone').val();
        if (!(/^1[3|4|5|8][0-9]\d{4,8}$/.test(data.ContactPhone))) {
            layer.msg("不是完整的11位手机号或者正确的手机号前七位");
            return false;
        }
        if (IsNullOrEmpty2($('#province').find("option:selected").val()) ||
            IsNullOrEmpty2($('#city').find("option:selected").val()) ||
            IsNullOrEmpty2($('#area').find("option:selected").val()) ||
            IsNullOrEmpty($('.addaddress.address .mainbox .model .s2 textarea').val())) {
            layer.msg('请填写完整的收货地址！');
            return;
        }
        data.AddrArea = $('#province').find("option:selected").text() + ',' + $('#city').find("option:selected").text() + ',' + $('#area').find("option:selected").text();
        data.AddrDetail = $('.addaddress.address .mainbox .model .s2 textarea').val();
        if ($('.addaddress.address .mainbox .h2tit .s1').html().trim() == '新增收货地址') {
            jQuery.axpost("../../api/user/AddressAdd", JSON.stringify(data), function (datas) {
                //  
                var item = datas.Model1;
                var AddrAreaArry = item.AddrArea.split(',');
                var AddrArea = AddrAreaArry[0] + " " + AddrAreaArry[1] + " " + AddrAreaArry[2] + " " + item.AddrDetail;
                var str = '<li>\
                            <div class="leftitrm" >\
                                <i></i>\
                                <div class="mr mr1">'+ item.ContactName + '</div>\
                                <div class="mr mr2">\
                                    '+ AddrArea + '\
                                </div>\
                                <div class="mr mr3">\
                                    '+ item.ContactPhone + '\
                                </div>\
                                <div class="default" style="display:none">默认地址</div>\
                            </div >\
                            <div class="rightitem">\
                                <div class="cobox">\
                                    <a href="javascript:;">\
                                        设为默认\
                                    </a>\
                                    <input type="hidden" class="AddressId" value="'+ item.Id + '" />\
                                </div>\
                                <a href="javascript:;">\
                                    修改\
                                </a>\
                                <a href="javascript:;">\
                                    删除\
                                </a>\
                            </div>\
                           </li>'
                $('.shopmain .w1242 .inforlist ul').append(str);
                bindDefaultAddr();
                $('.addaddress.address').fadeOut(200);
            });
        }
        else {
            data.Id = $('#hiddenAddressId').val();
            var that = this;
            jQuery.axpost("../../api/user/UpdateAddr", JSON.stringify(data), function (datas) {
                var model = datas.Model1;
                $('.AddressId').each(function () {
                    if ($(this).val() == $('#hiddenAddressId').val()) {
                        var AddrAreaArry = model.AddrArea.split(',');
                        var AddrArea = AddrAreaArry[0] + " " + AddrAreaArry[1] + " " + AddrAreaArry[2] + " " + model.AddrDetail;
                        var item = $(this).parent().parent().parent();
                        item.find('.leftitrm .mr1').html(model.ContactName);
                        item.find('.leftitrm .mr2').html(AddrArea);
                        item.find('.leftitrm .mr3').html(model.ContactPhone);
                    }
                });
                $('.addaddress.address').fadeOut(200);
            });

        }


    })
    // #endregion

    // #region 发票
    $('.addaddress.Invoice .mainbox .keep').unbind();
    $('.addaddress.Invoice .mainbox .keep').click(function () {
        var data = new Object();
        // #region 参数
        data.Title = $('.addaddress.Invoice .mainbox .model .s2 .words.Title').val();
        if (IsNullOrEmpty(data.Title)) {
            layer.msg("请填写抬头！");
            return false;
        }
        data.DutyParagraph = $('.addaddress.Invoice .mainbox .model .s2 .words.DutyParagraph').val();
        if (IsNullOrEmpty(data.DutyParagraph)) {
            layer.msg("请填写税号！");
            return false;
        }
        data.TypeInvoice = $('input[name="TypeInvoice"]:checked').val();
        if (data.TypeInvoice == "专用发票") {
            data.MobiePhone = $('.addaddress.Invoice .mainbox .model .s2 .words.MobiePhone').val();
            if (IsNullOrEmpty(data.MobiePhone)) {
                layer.msg("请填写电话！");
                return false;
            }
            data.OpeningBank = $('.addaddress.Invoice .mainbox .model .s2 .words.OpeningBank').val();
            if (IsNullOrEmpty(data.OpeningBank)) {
                layer.msg("请填写开户行！");
                return false;
            }
            data.BankAccount = $('.addaddress.Invoice .mainbox .model .s2 .words.BankAccount').val();
            if (IsNullOrEmpty(data.BankAccount)) {
                layer.msg("请填写银行账户！");
                return false;
            }
            if (IsNullOrEmpty2($('#province1').find("option:selected").val()) ||
                IsNullOrEmpty2($('#city1').find("option:selected").val()) ||
                IsNullOrEmpty2($('#area1').find("option:selected").val()) ||
                IsNullOrEmpty($('.addaddress.Invoice .mainbox .model .s2 textarea').val())) {
                layer.msg('请填写完整的收货地址！');
                return;
            }
            data.Address = $('#province1').find("option:selected").text() + ' ' + $('#city1').find("option:selected").text() + ' ' + $('#area1').find("option:selected").text() + " " + $('.addaddress.Invoice .mainbox .model .s2 textarea').val();
        }
        else {
            data.MobiePhone = " ";
            data.OpeningBank = " ";
            data.BankAccount = " ";
            data.Address = " ";
        }
        // #endregion
        if ($('.addaddress.Invoice .mainbox .h2tit .s1').html().trim() == '新增发票') {
            jQuery.axpost("../../api/user/InvoiceAdd", JSON.stringify(data), function (datas) {
                // #region 网页添加代码
                var item = datas.Model1;
                var str = '<div class="Invoice">\
                            <div class="LeftPart" >\
                                <i></i>\
                                <div class="s1">\
                                    抬头：<span>'+ item.Title + '</span>\
                                </div>\
                                <div class="s2">\
                                    税号：<span>'+ item.DutyParagraph + '</span>\
                                </div>\
                                <div class="s3">\
                                    发票类型：<span>'+ item.TypeInvoice + '</span>\
                                </div>\
                                <div class="default" style="display:none;">默认发票</div>\
                                <input type="hidden" class="MobliePhone" value="'+ item.MobliePhone + '" />\
                                <input type="hidden" class="OpeningBank" value="'+ item.OpeningBank + '" />\
                                <input type="hidden" class="BankAccount" value="'+ item.BankAccount + '" />\
                                <input type="hidden" class="Address" value="'+ item.Address + '" />\
                            </div >\
                            <div class="RightPart">\
                                <input type="hidden" class="InvoiceId" value="'+ item.Id + '" />\
                                <a href="javascript:;" class="default">设为默认</a>\
                                <a href="javascript:;" class="edit">修改</a>\
                                <a href="javascript:;" class="del">删除</a>\
                            </div>\
                        </div>'
                $('.shopmain .credit').append(str);
                bindDefaultInvoice();
                $('.addaddress.Invoice').fadeOut(200);
                // #endregion
            });
        }
        else {
            data.Id = $('#hiddenInvoiceId').val();
            jQuery.axpost("../../api/user/InvoiceEdit", JSON.stringify(data), function (datas) {
                var model = datas.Model1;
                $('.InvoiceId').each(function () {
                    if ($(this).val() == $('#hiddenInvoiceId').val()) {
                        var item = $(this).parent().parent();
                        item.find('.LeftPart .s1 span').html(model.Title);
                        item.find('.LeftPart .s2 span').html(model.DutyParagraph);
                        item.find('.LeftPart .s3 span').html(model.TypeInvoice);
                        item.find('.LeftPart .MobliePhone').val(model.MobliePhone);
                        item.find('.LeftPart .OpeningBank').val(model.OpeningBank);
                        item.find('.LeftPart .BankAccount').val(model.BankAccount);
                        item.find('.LeftPart .Address').val(model.Address);
                    }
                });
                $('.addaddress.Invoice').fadeOut(200);
            });
        }
    })
    // #endregion
    // #endregion


})

function bindDefaultAddr() {

    // #region 设置为默认地址
    $('.shopmain .w1242 .inforlist ul li .rightitem .cobox a').unbind('click');
    $('.shopmain .w1242 .inforlist ul li .rightitem .cobox a').click(function () {
        var data = new Object();
        var that = this;
        data.Id = $(that).parent().find('.AddressId').val();
        jQuery.axpost("../../api/user/UpAddrTime", JSON.stringify(data), function (datas) {
            $('.shopmain .w1242 .inforlist ul li .rightitem .cobox a').each(function () {
                $(this).css('display', 'block');
            })
            $('.shopmain .w1242 .inforlist ul li .leftitrm .default').each(function () {
                $(this).css('display', 'none');
            })
            $(that).css('display', 'none');
            var li = $(that).parent().parent().parent();
            li.find('.leftitrm i').trigger('click');
            li.find('.leftitrm .default').css('display', 'block');
        });
    });
    // #endregion

    // #region 选中项
    $('.shopmain .inforlist li .leftitrm i').unbind('click');
    $('.shopmain .inforlist li .leftitrm i').click(function () {
        $('.shopmain .inforlist li .leftitrm i').removeClass('current')
        $(this).addClass('current')
    })
    // #endregion

    // #region 修改收货地址
    $('.shopmain .inforlist ul li .rightitem a.edit').unbind('click');
    $('.shopmain .inforlist ul li .rightitem a.edit').click(function () {
        $('.addaddress.address').show();
        $('.addaddress.address .mainbox .h2tit .s1').html('修改收货地址');
        var item = $(this).parent().parent();
        var itemArry = item.find('.leftitrm .mr2').html().trim().split(' ');
        $('.addaddress.address .mainbox .model .s2 .words.name').val(item.find('.leftitrm .mr1').html().trim());
        $('.addaddress.address .mainbox .model .s2 .words.phone').val(item.find('.leftitrm .mr3').html().trim());
        $('.addaddress.address .mainbox .model .s2 textarea').val(itemArry[3].trim());
        $('.addaddress.address .mainbox .model .s2 select option').each(function () {
            $(this).removeAttr("selected");
            $(this)[0].selected = false;
        })
        $("#province").find("option[value='" + itemArry[0].trim() + "']").attr("selected", true);
        $("#province").find("option[value='" + itemArry[0].trim() + "']")[0].selected = true;
        $("#province").trigger("change");
        $("#city").find("option[value='" + itemArry[1].trim() + "']").attr("selected", true);
        $("#city").find("option[value='" + itemArry[1].trim() + "']")[0].selected = true;
        $("#city").trigger("change");
        $("#area").find("option[value='" + itemArry[2].trim() + "']").attr("selected", true);
        $("#area").find("option[value='" + itemArry[2].trim() + "']")[0].selected = true;
        $('#hiddenAddressId').val(item.find('.rightitem .cobox .AddressId').val());
    });
    // #endregion

    // #region 删除收货地址
    $('.shopmain .inforlist ul li .rightitem a.del').unbind('click');
    $('.shopmain .inforlist ul li .rightitem a.del').click(function () {
        var item = $(this).parent().parent();
        var data = new Object();
        data.Id = $(item).find('.AddressId').val();
        jQuery.axpost("../../api/user/DeleteAddr", JSON.stringify(data), function (datas) {
            layer.msg('删除成功！');
            $(item).remove();
        });
    });
    // #endregion

    // #region 选中项
    $(".addressItemBase").click(function () {
        $(".addressItemBase").removeClass('active');
        $(this).addClass('active');
    })
    // #endregion

    $('.container-fluid .rightpart').click(function () {
        $('.container-fluid .rightpart').removeClass("active");
        $(this).addClass("active");
        $('.container-fluid .rightpart input[name="addressInfo"]').each(function () {
            $(this)[0].checked = false;
        })
        $(this).find('input[name="addressInfo"]')[0].checked = true;
    })
}

// #region 省份方法

//省份开始
$(function () {
    GetData($(".wrap.province"), 'province', '');
    ReBind();
});
function ReBind() {
    $(".wrap.province .line .item").bind("click", function () {
        var city = $(this).parent().parent().parent().find('.wrap.city');
        city.find(".line").remove();
        $(this).parent().parent().parent().parent().find('.input .state').html($(this).html().trim());
        $(this).parent().parent().parent().parent().find('.input .city').html('城市');
        $(this).parent().parent().parent().parent().find('.input .district').html('区/县');
        $(this).parent().parent().parent().parent().find('.input .state').addClass('active');
        $(this).parent().parent().parent().parent().find('.input .city').removeClass('active');
        $(this).parent().parent().parent().parent().find('.input .district').removeClass('active');
        GetData(city, "city", $(this).html().trim());
        $('.wrap.province').hide();
        $('.wrap.district').hide();
        $('.wrap.city').show();

    });

    $('.wrap.city .line .item').bind("click", function () {
        var district = $(this).parent().parent().parent().find('.wrap.district');
        district.find(".line").remove();
        $(this).parent().parent().parent().parent().find('.input .city').html($(this).html().trim());
        $(this).parent().parent().parent().parent().find('.input .district').html('区/县');
        $(this).parent().parent().parent().parent().find('.input .state').addClass('active');
        $(this).parent().parent().parent().parent().find('.input .city').addClass('active');
        $(this).parent().parent().parent().parent().find('.input .district').removeClass('active');
        GetData(district, "area", $(this).html().trim());
        $('.wrap.province').hide();
        $('.wrap.city').hide();
        $('.wrap.district').show();
    });

    $('.wrap.district .line .item').bind("click", function () {
        $(this).parent().parent().parent().hide();
        $(this).parent().parent().parent().parent().find('.input .district').html($(this).html().trim());
        $(this).parent().parent().parent().parent().find('.toggle-icon').removeClass('fa-angle-down');
        $(this).parent().parent().parent().parent().find('.toggle-icon').addClass('fa-angle-down');
        $(this).parent().parent().parent().parent().find('.input .state').addClass('active');
        $(this).parent().parent().parent().parent().find('.input .city').addClass('active');
        $(this).parent().parent().parent().parent().find('.input .district').addClass('active');
    });
}

function GetData(sel, Level, Name) {
    sel.find(".line").remove();
    $.ajax({
        type: "post",
        url: "../../Api/Home/GetProvinceInfo",
        contentType: "application/x-www-form-urlencoded;charset=UTF-8",
        data: "Level=" + Level + "&AreaName=" + Name,
        datatype: "json",
        async: false,
        success: function (data) {
            var childSel;
            var json = eval(data);
            if (!json) return;
            $.each(json, function (i, n) {
                if (i % 6 == 0) {
                    sel.append($('<div class="line"></div>'));
                    childSel = sel.find('.line:last-child');
                }
                childSel.append($('<span class="item">' + n.name + '</span>'));
            });
            ReBind();
        },
        error: function (e, x) {
            alert(e.responseText);
        }
    });
}

function GetFullInfo(sel, arry) {
    GetData(sel.find(".wrap.province"), 'province', '');
    GetData(sel.find(".wrap.city"), "city", arry[0]);
    GetData(sel.find(".wrap.district"), "area", arry[1]);
    sel.find(".input .state").html(arry[0]);
    sel.find(".input .city").html(arry[1]);
    sel.find(".input .district").html(arry[2]);
    sel.find(".input .state").addClass('active');
    sel.find(".input .city").addClass('active');
    sel.find(".input .district").addClass('active');
}
//省份结束

function ToProductInfo() {
    $("html, body").animate({
        scrollTop: $(".proinfor").offset().top
    }, { duration: 500, easing: "swing" });
    return false;
}

// #endregion

// #region 是否为空
function IsNullOrEmpty(value) {
    if (value == null || value == undefined || value == "") {
        return true;
    }
    else {
        return false;
    }
}

function IsNullOrEmpty2(value) {
    if (value == null || value == undefined || value == "" || value == -1 || value == "-1") {
        return true;
    }
    else {
        return false;
    }
}
// #endregion

function EditAddr(that) {
    $('#HiddenAddressId').val($(that).parent().find('.HiddenAddressId').val());
    var item = $(that).parent().parent().parent();
    $('.detailcontent .modal-content .modal-body .address-form h4').html('修改地址');
    $('.dealert.Address').show();
    var address_form = $('.detailcontent .modal-content .modal-body .address-form');
    var arry = item.find('.address-full').html().trim().split(' ');
    address_form.find('#NameInput').val(item.find('.address-name').html().trim());
    address_form.find('#NameInput').trigger('blur');
    address_form.find('#MoblieInput').val(item.find('.address-phone').html().trim());
    address_form.find('#MoblieInput').trigger('blur');
    address_form.find('#FullAddress').val(arry[3]);
    address_form.find('#FullAddress').trigger('blur');
    GetFullInfo(address_form, arry);
    stopBubbling(that);
}


function DeleteAddr(that) {
    $('#HiddenAddressId').val($(that).parent().find('.HiddenAddressId').val());
    $('.dealert.Deletions').show();
    stopBubbling(that);
}

function DeleteAddress() {
    // #region 删除收货地址
    var data = new Object();
    data.Id = $('#HiddenAddressId').val();
    jQuery.axpost("../../api/user/DeleteAddr", JSON.stringify(data), function (datas) {
        layer.msg('删除成功！');
        $('.HiddenAddressId').each(function () {
            if ($(this).val() == $('#HiddenAddressId').val()) {
                if ($(this).parent().hasClass("active")) {
                    $(this).parent().remove();
                    if ($('.HiddenAddressId').length == 0) {
                        $('.panel_panel.noAddress').show();
                        $('.panel_panel.haveAddress').hide();
                    }
                    else {
                        $('.HiddenAddressId').eq(0).parent().addClass('active');
                    }
                }
                else {
                    $(this).parent().remove();
                }
            }
        });
    });
    $('.dealert.Deletions').hide();
    // #endregion
}

function stopBubbling(e) {
    e = window.event || e;
    if (e.stopPropagation) {
        e.stopPropagation();      //阻止事件 冒泡传播
    } else {
        e.cancelBubble = true;   //ie兼容
    }
}

function AddAndUse(that) {
    var address_form = $(that).parent().parent().parent();
    var data = new Object();
    data.ContactName = address_form.find('#NameInput').val();
    data.ContactPhone = address_form.find('#MoblieInput').val();
    if (!(/^1[3|4|5|8][0-9]\d{4,8}$/.test(data.ContactPhone))) {
        layer.msg("不是完整的11位手机号或者正确的手机号前七位");
        return false;
    }
    var province = address_form.find(".china-city .input .state").html().trim();
    var city = address_form.find(".china-city .input .city").html().trim();
    var area = address_form.find(".china-city .input .district").html().trim();
    var detail = address_form.find('#FullAddress').val();
    if (province == "省份" || city == "城市" || area == "区/县" || IsNullOrEmpty2(detail)) {
        layer.msg('请填写完整的收货地址！');
        return;
    }
    data.AddrArea = province + ',' + city + ',' + area;
    data.AddrDetail = detail;
    debugger;
    if ($('.detailcontent .modal-content .modal-body .address-form h4').html().trim() == '添加并使用新地址') {
        jQuery.axpost("../../api/user/AddressAdd", JSON.stringify(data), function (datas) {
            var item = datas.Model1;
            var AddrAreaArry = item.AddrArea.split(',');
            var AddrArea = AddrAreaArry[0] + AddrAreaArry[1] + AddrAreaArry[2] + ' ' + item.AddrDetail;
            var str = '<div class="rightpart">\
                            <input type= "radio" name= "addressInfo" />\
                            <label>\
                                <label class="address-full">'+ AddrArea + '</label>（<label class="address-name">' + item.ContactName + '</label> 收） <label class="address-phone">' + item.ContactPhone + '</label>\
                            </label >\
                            <span onclick="EditAddr(this)">修改本地址</span>\
                            <span style="color:#ff6a00" onclick="DeleteAddr(this)">删除地址</span>\
                            <input type="hidden" class="HiddenAddressId" value="'+ item.Id + '" />\
                        </div >';
            $('.panel_panel.haveAddress .panel-context .container-fluid').prepend(str);
            $('.panel_panel.noAddress').hide();
            $('.panel_panel.haveAddress').show();
            $('.dealert.Address').hide();
            debugger
            bindDefaultAddr();
            $('.dealert.Address').hide();
        });
    }
    else {
        data.Id = $('#HiddenAddressId').val();
        var that = this;
        jQuery.axpost("../../api/user/UpdateAddr", JSON.stringify(data), function (datas) {
            var model = datas.Model1;
            $('.HiddenAddressId').each(function () {
                if ($(this).val() == $('#HiddenAddressId').val()) {
                    var AddrAreaArry = model.AddrArea.split(',');
                    var AddrArea = AddrAreaArry[0] + ' ' + AddrAreaArry[1] + ' ' + AddrAreaArry[2] + ' ' + model.AddrDetail;
                    var item = $(this).parent().parent().parent();
                    item.find('.address-name').html(model.ContactName);
                    item.find('.address-phone').html(model.ContactPhone);
                    item.find('.address-full').html(AddrArea);
                    item.find('.address-full').attr("title", AddrArea);
                }
            });
            $('.dealert.Address').hide();
            bindDefaultAddr();
        });
    }
}

// #region 提交订单
function submitTopay() {
    var data = new Object();
    debugger;
    if ($('.HiddenAddressId').length == 0) {
        layer.msg('请添加地址！');
        return;
    }
    else {
        // #region 已登入地址
        if ($('.rightpart.active').length == 0) {
            layer.msg('请选择地址！');
            return;
        }
        else {
            data.Name = $('.rightpart.active').find('.address-name').html().trim();
            data.Phone = $('.rightpart.active').find('.address-phone').html().trim();
            data.Address = $('.rightpart.active').find('.address-full').html().trim();
        }
        // #endregion
        var item = $('.Invoice .btn.active');
        if (item.length == 0) {
            layer.msg('请选择开具发票！');
            return;
        }
        data.Invoice = item.parent().parent().find('.InvoiceId').val();
    }
    var count = 0;
    data.ShopCartIds = $('#ShopCartId').val();
    data.Invoice = $("#InvoiceInput").val() + "," + $("#DutyParaInput").val();
    data.UserPhone = $(".InputText.MoblieInput").val();
    data.UserPhoneCode = $(".InputText.VaildInput").val();
    jQuery.axpost("../../api/order/AddOrder", JSON.stringify(data), function (datas) {
        window.location.href = '../../../PayPage/OrderPayPage?OrderInfoId=' + datas.Message;
    });
}
// #endregion

function SendPhoneCode() {
    var obj = new Object();
    obj.UserPhone = $('.InputText.MoblieInput').val();
    obj.IsThild = true;
    if (obj.UserPhone == "" || obj.UserPhone == undefined) {
        return;
    }
    jQuery.axpost('../../api/Home/SendPhoneCode', JSON.stringify(obj), function (data) {
        layer.msg(data.Message);
    });
}