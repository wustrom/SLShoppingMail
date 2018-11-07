/// <reference path="../ajax.js" />



$(function () {
    // #region 用户信息更新
    $('.alertname .detailcontent .box1 .xg').click(function () {
        var val = $('.alertname .detailcontent .box1 .model .s2 .words').val();
        var sex = $('.alertname .detailcontent .box1 .model .s2 select').val();
        $('.myinforbox .mycontent .somecontet .baseinfor .upload .rightsome2 p .s2 .name .words').html(val);
        $('#Sex').text(sex)
        $('.alertname.al2').hide()
        var Id = $('input[name="Id"]').val();
        var Name = $('input[name="Name"]').val();
        var Sex = $('#select1 option:selected').val();
        var datas = { Id: Id, Name: Name, Sex: Sex };

        jQuery.axpost('../../Api/User/UpdateUserName', JSON.stringify(datas), function (data) {
            layer.msg(data.Message);
        })
    })
    // #endregion

    // #region 省份
    //省份1开始
    $(function () {
        GetData($(".address1 #province"), 'province', '');
        province1();
        $(".address1 #province").bind("change", function () {
            $('.address1 #area').find("option:gt(0)").remove();
            if ($(".address1 #province").val() != '-1') {
                GetData($(".address1 #city"), "city", $(".address1 #province").val());
            }
        });

        $(".address1 #city").bind("change", function () {
            if ($("#city").val() != '-1') {
                GetData($(".address1 #area"), "area", $(".address1 #city").val());
            }
        });

        $(".address1 #div1 select").change(function () {
            $(this).next('input[type=hidden]').val($(this).val());
        });
    });

    var province1 = function () {
        if ($(".address1 #hidProvince").val() != '') {
            setTimeout(function () { $(".address1 #province").val($(".address1 #hidProvince").val()); }, 1);
            setTimeout(function () { $(".address1 #province").change(); }, 1);
        }
        if ($(".address1 #hidCity").val() != '' && $(".address1 #city").val() == '-1') {
            setTimeout(function () { $(".address1 #city").val($(".address1 #hidCity").val()); }, 1);
            setTimeout(function () { $(".address1 #city").change(); }, 1);
        }

        if ($(".address1 #hidArea").val() != '' && $(".address1 #area").val() == '-1') {
            setTimeout(function () { $(".address1 #area").val($(".address1 #hidArea").val()); }, 1);
            setTimeout(function () { $(".address1 #area").change(); }, 1);
        }

    };
    //省份1结束
    //省份2开始
    $(function () {
        GetData($(".address #province"), 'province', '');
        province2();
        $(".address #province").bind("change", function () {
            $('.address #city').find("option:gt(0)").remove();
            $('.address #area').find("option:gt(0)").remove();
            if ($(".address #province").val() != '-1') {
                GetData($(".address #city"), "city", $(".address #province").val());
            }
        });

        $(".address #city").bind("change", function () {
            if ($(".address #city").val() != '-1') {
                GetData($(".address #area"), "area", $(".address #city").val());
            }
        });
        $(".address #div1 select").change(function () {
            $(this).next('input[type=hidden]').val($(this).val());
        });
    });
    var province2 = function () {
        if ($("#hidProvince").val() != '') {
            setTimeout(function () { $(".address #province").val($(".address #hidProvince").val()); }, 1);
            setTimeout(function () { $(".address #province").change(); }, 1);
        }
        if ($(".address #hidCity").val() != '' && $(".address #city").val() == '-1') {
            setTimeout(function () { $(".address #city").val($(".address #hidCity").val()); }, 1);
            setTimeout(function () { $(".address #city").change(); }, 1);
        }

        if ($(".address #hidArea").val() != '' && $(".address #area").val() == '-1') {
            setTimeout(function () { $(".address #area").val($(".address #hidArea").val()); }, 1);
            setTimeout(function () { $(".address #area").change(); }, 1);
        }
    };
    //省份2结束
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
})

// #region 公司信息可编辑
$(function () {
    $('.myinforbox .mycontent .somecontet .baseinfor .changelist .send a:first-child').click(function () {
        $('.myinforbox .mycontent .somecontet .baseinfor .changelist .model .s2 .ShowText').css("display", "none");
        $('.myinforbox .mycontent .somecontet .baseinfor .changelist .model .s2 .HiddenInput').each(function () {
            $(this).removeClass('HiddenInput');
        });
        layer.msg("用户可以进行修改.");
    })
})
// #endregion

// #region 公司信息更新
$(function () {
    $('.myinforbox .mycontent .somecontet .baseinfor .changelist .send a:last-child').click(function () {

        var Id = $('input[name="Id"]').val();
        var CompanyName = $('input[name="CompanyName"]').val();
        var ConmpanyType = $('#ConmpanyType option:selected').val();
        var CompanyPhone = $('input[name="CompanyPhone"]').val();
        var CompanyAddr = document.getElementById("CompanyAddr").value;
        var Email = $('input[name="Email"]').val();
        var ZipCode = $('input[name="ZipCode"]').val();
        var datas = { CompanyName: CompanyName, ConmpanyType: ConmpanyType, CompanyPhone: CompanyPhone, CompanyAddr: CompanyAddr, Email: Email, ZipCode: ZipCode };
        var select = $('.s2 .select').val();
        var datas = { CompanyName: CompanyName, CompanyPhone: CompanyPhone, CompanyAddr: CompanyAddr, Email: Email, ZipCode: ZipCode, CompanyType: select };
        jQuery.axpost('../../Api/User/UpdateCompany', JSON.stringify(datas), function (data) {
            layer.msg(data.Message);
            $('.myinforbox .mycontent .somecontet .baseinfor .changelist .model .s2 .words').attr("disabled", true);
            $('.myinforbox .mycontent .somecontet .baseinfor .changelist .model .s2 textarea').attr("disabled", true);
            window.location.replace("../../UserInfo/Info");
        })
    })
})
// #endregion

// #region 地址联系人添加
$(function () {
    $('.addaddress.address .mainbox .keep').unbind();
    $('.addaddress.address .mainbox .keep').click(function () {
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

// #region 地址联系人修改
//地址联系人修改页面
function UpdateAddr(Id, item) {
    $('.addaddress.address1').fadeIn(200);

    $('.addaddress.address1 .mainbox .h2tit i').click(function () {
        $('.addaddress.address1').fadeOut(200)
    })
    $('.addaddress.address1 .mainbox .keep').click(function () {
        $('.addaddress.address1').fadeOut(200)
    })

    $('.addaddress .mainbox .model2 .s2 #list li').click(function () {
        $('.addaddress .mainbox .model2 .s2 #list li').removeClass('current');
        $(this).addClass('current')
    })

    $('.shopmain .credit a').click(function () {
        $('.addaddress.fpxx').fadeIn(200)
    })
    $('.addaddress.fpxx .mainbox .h2tit i').click(function () {
        $('.addaddress.fpxx').fadeOut(200)
    })
    $('.addaddress .mainbox .keep2 *').click(function () {
        $('.addaddress.fpxx').fadeOut(200)
    })
    var li = $(item).parent().parent().parent();
    var Id = li.find('.left #Id').val();
    var ContactName = li.find('.left .ContactName').html().trim();
    var ContactPhone = li.find('.left .ContactPhone').html().trim();
    var AddrDetail = li.find('.left .AddrDetail').html().trim();
    var AddrArea = li.find('.left .AddrArea').html().trim();
    var Addrs = AddrArea.split(' ');
    var province = Addrs[0];
    var city = Addrs[1];
    var area = Addrs[2];
    $("#province").find("option[value='" + province + "']").attr("selected", true);
    $("#province").trigger("change");
    $("#city").find("option[value='" + city + "']").attr("selected", true);
    $("#city").trigger("change");
    $("#area").find("option[value='" + area + "']").attr("selected", true);
    $('input[name="ContactNameEdit"]').val(ContactName);
    $('input[name="Id"]').val(Id);
    $('input[name="ContactPhoneEdit"]').val(ContactPhone);
    $('textarea[id="AddrDetailEdit"]').val(AddrDetail);
}

//地址联系人信息确认修改
$(function () {
    $('.addaddress.address1 .mainbox .keep').click(function () {
        var Id = $('input[name="Id"]').val();
        var ContactName = $('input[name="ContactNameEdit"]').val();
        var ContactPhone = $('input[name="ContactPhoneEdit"]').val();
        var province = $('#province option:selected').val();
        var city = $('#city option:selected').val();
        var area = $('#area option:selected').val();
        var AddrArea = province + ',' + city + ',' + area;
        var AddrDetail = document.getElementById("AddrDetailEdit").value;

        var datas = { Id: Id, ContactName: ContactName, ContactPhone: ContactPhone, AddrArea: AddrArea, AddrDetail: AddrDetail };
        jQuery.axpost('../../Api/User/UpdateAddr', JSON.stringify(datas), function (data) {
            layer.msg(data.Message);
            $('.lacagl .list ul li').each(function () {
                var IdInfo = $(this).find('.left #Id').val();
                if (IdInfo == Id) {
                    $(this).find('.left .ContactName').html(ContactName);
                    $(this).find('.left .AddrArea').html(province + ' ' + city + ' ' + area);
                    $(this).find('.left .AddrDetail').html(AddrDetail);
                    $(this).find('.left .ContactPhone').html(ContactPhone);
                }
            });
        })
    });
})
// #endregion

// #region 地址联系人删除
function Deleteaddr(Id, that) {
    var datas = { Id: Id }
    jQuery.axpost('../../Api/User/DeleteAddr', JSON.stringify(datas), function (data) {
        layer.msg(data.Message);
        var display = $(that).parent().parent().find('.bt span').css("display");
        $(that).parent().parent().parent().remove();
        if (display === "block") {
            var first = $('.lacagl .list ul li:first');
            if (first.length == 0) {
                $('.myinforbox .mycontent .somecontet .lacagl .list').append('<div style="font-size:18px;color:#808080;padding-top:50px;padding-left:35%;">您暂时没有收货地址！</div>')
            }
            $(first).find('.rightbox .bt span').css("display", "block");
            $(first).find('.rightbox .link a:last').css("display", "none");
        }
    });
}
// #endregion

// #region 设置为默认地址
function Default(Id, that) {
    var datas = { Id: Id };
    jQuery.axpost('../../Api/User/UpAddrTime', JSON.stringify(datas), function (data) {
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
        $('.myinforbox .mycontent .somecontet .lacagl .list').append('<div style="font-size:18px;color:#808080;padding-top:50px;padding-left:35%;">您暂时没有收货地址！</div>')
    }
})
// #endregion