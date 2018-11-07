$(function () {
    // #region 省份
    //省份开始
    $(function () {
        GetData($("#province"), 'province', '');
        $("#province").bind("change", function () {
            $('#city').find("option:gt(0)").remove();
            $('#area').find("option:gt(0)").remove();
            if ($("#province").val() != '-1') {
                GetData($("#city"), "city", $("#province").val());
            }
        });

        $("#city").bind("change", function () {
            if ($("#city").val() != '-1') {
                GetData($("#area"), "area", $("#city").val());
            }
        });
    });
    //省份结束
    function GetData(sel, Level, Name) {
        sel.find("option:gt(0)").remove();
        $.ajax({
            type: "post",
            url: "../../Api/Home/GetProvinceInfo",
            contentType: "application/x-www-form-urlencoded;charset=UTF-8",
            data: "Level=" + Level + "&AreaName=" + Name,
            datatype: "json",
            async: false,
            success: function (data) {
                if (data != "]") {
                    var json = eval(data);
                    if (!json) return;
                    $.each(json, function (i, n) {
                        sel.append($("<option value='" + n.name + "'>" + n.name + "</option>"));
                    });
                }
            },
            error: function (e, x) {
                alert(e.responseText);
            }
        });
    }
    // #endregion

    // #region 添加发票信息
    $('#addInvoice').click(function () {
        $('.addaddress.Invoice').show();
        $('.addaddress.Invoice .mainbox .h2tit .s1').html('新增发票');
        $('.addaddress.Invoice .model .s2 .Title').val('');
        $('.addaddress.Invoice .model .s2 .DutyParagraph').val('');
        $('.addaddress.Invoice .model .s2 .OpeningBank').val('');
        $('.addaddress.Invoice .model .s2 .BankAccount').val('');
        $('#province').find("option[value='-1']").attr("selected", true)
        $('#province').trigger('change');
        $('.addaddress.Invoice .model .s2 textarea').val('');
        $('.addaddress.Invoice .model .s2 .MobiePhone').val('');
        $('input[name="TypeInvoice"]:eq(0)').trigger('click');
    })

    $('input[name="TypeInvoice"]').change(function () {
        var typeInvoice = $('input[name="TypeInvoice"]:checked').val();
        if (typeInvoice != "专用发票") {
            $('.addaddress.Invoice .model .s2 .OpeningBank').attr('disabled', true);
            $('.addaddress.Invoice .model .s2 .BankAccount').attr('disabled', true);
            $('#province').attr('disabled', true);
            $('#city').attr('disabled', true);
            $('#area').attr('disabled', true);
            $('.addaddress.Invoice .model .s2 textarea').attr('disabled', true);
            $('.addaddress.Invoice .model .s2 .MobiePhone').attr('disabled', true);
        }
        else {
            $('.addaddress.Invoice .model .s2 .OpeningBank').attr('disabled', false);
            $('.addaddress.Invoice .model .s2 .BankAccount').attr('disabled', false);
            $('#province').attr('disabled', false);
            $('#city').attr('disabled', false);
            $('#area').attr('disabled', false);
            $('.addaddress.Invoice .model .s2 textarea').attr('disabled', false);
            $('.addaddress.Invoice .model .s2 .MobiePhone').attr('disabled', false);
        }
    });
    // #endregion
})

// #region 发票添加
$(function () {
    $('.addaddress.Invoice .mainbox .keep').unbind();
    $('.addaddress.Invoice .mainbox .keep').click(function () {
        var ContactName = $('input[name="ContactName"]').val();
        $('input[name="ContactName"]').val('');
        var ContactPhone = $('input[name="ContactPhone"]').val();
        $('input[name="ContactPhone"]').val('');
        var province = $('.addaddress.address .mainbox .model .s2 #province option:selected').val();
        var city = $('.addaddress.address .mainbox .model .s2 #city option:selected').val();
        var area = $('.addaddress.address .mainbox .model .s2 #area option:selected').val();
        $(".addaddress.address .mainbox .model .s2 #province option").each(function () {
            if ($(this)[0].value == "-1") {
                $(this)[0].selected = true;
            }
            else {
                $(this)[0].selected = false;
            }
        })
        $(".addaddress.address .mainbox .model .s2 #province").trigger('change');
        var AddrArea = province + ',' + city + ',' + area;
        var AddrDetail = document.getElementById("AddrDetail").value;
        document.getElementById("AddrDetail").value = '';
        var datas = { ContactName: ContactName, ContactPhone: ContactPhone, AddrArea: AddrArea, AddrDetail: AddrDetail }
        jQuery.axpost('../../Api/User/AddressAdd', JSON.stringify(datas), function (data) {
            
            layer.msg(data.Message);
            var areaName = "";
            if (data.Model1.AddrArea != null && data.Model1.AddrArea != undefined) {
                var area = data.Model1.AddrArea.split(',');
                if (area.length == 3) {
                    areaName = area[0] + " " + area[1] + " " + area[2];
                }
            }
            // #region 若是没有一条数据时
            if ($('.myinforbox .mycontent .somecontet .lacagl .list').children('div').length != 0) {
                $('.lacagl .list ul').append('<li>\
                                                <div class="left" >\
                                                    <input type="hidden" class="words" value="@item.Id" id="Id" />\
                                                    <input type="hidden" class="words" value="@item.UserId" id="UserId" />\
                                                    <p class="ContactName">\
                                                        '+ data.Model1.ContactName + '\
                                                    </p>\
                                                    <p class="AddrArea">\
                                                        '+ areaName + '\
                                                    </p>\
                                                    <p class="AddrDetail">\
                                                        '+ data.Model1.AddrDetail + '\
                                                    </p>\
                                                    <p>\
                                                        电话：<label class="ContactPhone">'+ data.Model1.ContactPhone + '</label>\
                                                    </p>\
                                                </div >\
                                                <div class="rightbox">\
                                                    <div class="bt">\
                                                            <span style="display:block;">\
                                                                默认地址\
                                                            </span>\
                                                    </div>\
                                                    <div class="link">\
                                                        <a href="javascript:;" onclick="Deleteaddr('+ data.Model1.Id + ',this)">删除</a>\
                                                        <a href="javascript:;" onclick="UpdateAddr('+ data.Model1.Id + ',this)" id="UpAddr">修改</a>\
                                                        <a href="javascript:;" onclick="Default('+ data.Model1.Id + ',this)" style="display:none;">设为默认</a>\
                                                    </div>\
                                                </div>\
                                            </li>');
                $('.myinforbox .mycontent .somecontet .lacagl .list').children('div').remove();
            }
            // #endregion
            // #region 若是至少有一条数据时
            else {
                $('.lacagl .list ul').append('<li>\
                                                <div class="left" >\
                                                    <input type="hidden" class="words" value="@item.Id" id="Id" />\
                                                    <input type="hidden" class="words" value="@item.UserId" id="UserId" />\
                                                    <p class="ContactName">\
                                                        '+ data.Model1.ContactName + '\
                                                    </p>\
                                                    <p class="AddrArea">\
                                                        '+ areaName + '\
                                                    </p>\
                                                    <p class="AddrDetail">\
                                                        '+ data.Model1.AddrDetail + '\
                                                    </p>\
                                                    <p>\
                                                        电话：<label class="ContactPhone">'+ data.Model1.ContactPhone + '</label>\
                                                    </p>\
                                                </div >\
                                                <div class="rightbox">\
                                                    <div class="bt">\
                                                            <span style="display:none;">\
                                                                默认地址\
                                                            </span>\
                                                    </div>\
                                                    <div class="link">\
                                                        <a href="javascript:;" onclick="Deleteaddr('+ data.Model1.Id + ',this)">删除</a>\
                                                        <a href="javascript:;" onclick="UpdateAddr('+ data.Model1.Id + ',this)" id="UpAddr">修改</a>\
                                                        <a href="javascript:;" onclick="Default('+ data.Model1.Id + ',this)">设为默认</a>\
                                                    </div>\
                                                </div>\
                                            </li>');
            }
            // #endregion
            $('.addaddress.address').hide();
        })
    })
})
// #endregion

// #region 发票修改
function UpdateAddr(Id, item) {
    $('.addaddress.Invoice').show();
    $('.addaddress.Invoice .mainbox .h2tit .s1').html('修改发票');
    var li = $(item).parent().parent().parent();
    $('#hiddenInvoiceId').val($(li).find('.left .Id').val());
    $('.addaddress.Invoice .mainbox .model .s2 .words.Title').val(li.find('.left .Title span').html().trim());
    $('.addaddress.Invoice .mainbox .model .s2 .words.DutyParagraph').val(li.find('.left .DutyParagraph span').html().trim());
    $('input[name="TypeInvoice"]').each(function () {
        if ($(this).val() == $(li).find('.left .TypeInvoice').html().trim()) {
            $(this).trigger('click');
        }
    });
    var Id = li.find('.left .Id').val();
    var Addrs = li.find('.left .Address').val().split(' ');
    
    $("#province").find("option[value='" + Addrs[0] + "']").attr("selected", true);
    $("#province").trigger("change");
    $("#city").find("option[value='" + Addrs[1] + "']").attr("selected", true);
    $("#city").trigger("change");
    $("#area").find("option[value='" + Addrs[2] + "']").attr("selected", true);

    $('.addaddress.Invoice .mainbox .model .s2 .words.MobiePhone').val(li.find('.left .MobliePhone').val());
    $('.addaddress.Invoice .mainbox .model .s2 .words.OpeningBank').val(li.find('.left .OpeningBank').val());
    $('.addaddress.Invoice .mainbox .model .s2 .words.BankAccount').val(li.find('.left .BankAccount').val());
    $('.addaddress.Invoice .mainbox .model .s2 textarea').val(Addrs[3]);
}
// #endregion

// #region 发票提交
$(function () {
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
            if (IsNullOrEmpty2($('#province').find("option:selected").val()) ||
                IsNullOrEmpty2($('#city').find("option:selected").val()) ||
                IsNullOrEmpty2($('#area').find("option:selected").val()) ||
                IsNullOrEmpty($('.addaddress.Invoice .mainbox .model .s2 textarea').val())) {
                layer.msg('请填写完整的收货地址！');
                return;
            }
            data.Address = $('#province').find("option:selected").text() + ' ' + $('#city').find("option:selected").text() + ' ' + $('#area').find("option:selected").text() + " " + $('.addaddress.Invoice .mainbox .model .s2 textarea').val();
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
                layer.msg(datas.Message);
                // #region 网页添加代码
                var item = datas.Model1;
                var str = '<li>\
                            <div class="left" >\
                                <input type="hidden" class="words Id" value="'+ item.Id + '" />\
                                <input type="hidden" class="words UserId" value="'+ item.UserId + '" />\
                                <input type="hidden" class="words MobliePhone" value="'+ item.MobliePhone + '" />\
                                <input type="hidden" class="words OpeningBank" value="'+ item.OpeningBank + '" />\
                                <input type="hidden" class="words BankAccount" value="'+ item.BankAccount + '" />\
                                <input type="hidden" class="words Address" value="'+ item.Address + '" />\
                                <p class="Title">\
                                    抬头：<span>'+ item.Title + '</span>\
                                </p>\
                                <p class="DutyParagraph">\
                                    税号：<span>'+ item.DutyParagraph + '</span>\
                                </p>\
                                <p>\
                                    类型：<label class="TypeInvoice">'+ item.TypeInvoice + '</label>\
                                </p>\
                            </div >\
                            <div class="rightbox">\
                                <div class="bt">\
                                    <span style="display:none;">\
                                        默认发票\
                                    </span>\
                                </div>\
                            <div class="link">\
                                <a href="javascript:;" onclick="Deleteaddr('+ item.Id + ',this)">删除</a>\
                                <a href="javascript:;" onclick="UpdateAddr('+ item.Id + ',this)" id="UpAddr">修改</a>\
                                <a href="javascript:;" onclick="Default('+ item.Id + ',this)">设为默认</a>\
                            </div>\
                        </div>\
                    </li>'
                $('.myinforbox .mycontent .somecontet .lacagl .list ul').append(str);
                $('.addaddress.Invoice').fadeOut(200);
                // #endregion
            });
        }
        else {
            data.Id = $('#hiddenInvoiceId').val();
            jQuery.axpost("../../api/user/InvoiceEdit", JSON.stringify(data), function (datas) {
                var model = datas.Model1;
                layer.msg(datas.Message);
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
})
// #endregion

// #region 发票删除
function Deleteaddr(Id, that) {
    var datas = { Id: Id }
    jQuery.axpost('../../Api/User/DeleteInvoice', JSON.stringify(datas), function (data) {
        layer.msg(data.Message);
        var display = $(that).parent().parent().find('.bt span').css("display");
        $(that).parent().parent().parent().remove();
        if (display === "block") {
            var first = $('.lacagl .list ul li:first');
            if (first.length == 0) {
                $('.myinforbox .mycontent .somecontet .lacagl .list').append('<div style="font-size:18px;color:#808080;padding-top:50px;padding-left:35%;">您暂时没有发票！</div>')
            }
            $(first).find('.rightbox .bt span').css("display", "block");
            $(first).find('.rightbox .link a:last').css("display", "none");
        }
    });
}
// #endregion

// #region 设置为默认发票
function Default(Id, that) {
    var datas = { Id: Id };
    jQuery.axpost('../../Api/User/UpInvoiceTime', JSON.stringify(datas), function (data) {
        layer.msg(data.Message);
        $('.lacagl .list ul li').each(function () {
            $(this).find('.rightbox .bt span').css("display", "none");
            $(this).find('.rightbox .link a:last').css("display", "block");
        })
        $(that).css("display", "none");
        $(that).parent().parent().find('.bt span').css("display", "block");
    })
}
// #endregion}

// #region 如果没有数据
$(function () {
    var count = parseInt($('#hiddPageCount').val());
    if (count == 0) {
        $('.propj .pagesize1').hide();
        $('.myinforbox .mycontent .somecontet .lacagl .list').append('<div style="font-size:18px;color:#808080;padding-top:50px;padding-left:35%;">您暂时没有发票！</div>')
    }
})
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