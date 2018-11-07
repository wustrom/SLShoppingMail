/// <reference path="../ajax.js" />

$(function () {
    // #region 个人资料修改
    $('.personal-row #Xiu').click(function () {
        var Name = $('.name-row2 #Name span').html();
        var Sex = $('.personal-row #Sex span').html();
        var CompanyName = $('.personal-row #CompanyName span').html();
        var CompanyPhone = $('.personal-row #CompanyPhone span').html();
        var CompanyAddr = $('.personal-row #CompanyAddr span').html();
        var CompanyDetail = $('.personal-row #CompanyDetail').html();
        var ZipCode = $('.personal-row #ZipCode span').html();
        var CompanyAddr = $('.personal-row #CompanyAddr span').html();

        $('.name-row2 #Name #HName').show();
        $('.name-row2 #Name span').hide();
        $('.personal-row #Sex #HSex').show();
        $('.personal-row #Sex span').hide();
        $('.personal-row #CompanyName #HCompanyName').show();
        $('.personal-row #CompanyName span').hide();

        $('.HiddenInput').show();
        $('.personal-row #ConmanyType span').hide();
        $('.personal-row #CompanyPhone #HCompanyPhone').show();
        $('.personal-row #CompanyPhone span').hide();
        $('.personal-row #CompanyAddr #HCompanyAddr').show();
        $('.personal-row #CompanyAddr span').hide();
        $('.personal-row #HCompanyDetail').show();
        $('.personal-row #CompanyDetail').hide();
        $('.personal-row #ZipCode #HZipCode').show();
        $('.personal-row #ZipCode span').hide();
        $('.personal-row #Xiu').hide();
        $('.personal-row #Baocun').show();

        var Addrs = CompanyAddr.split(' ');
        var province = Addrs[0];
        var city = Addrs[1];
        var area = Addrs[2];
        $("#province").find("option[value='" + province + "']").attr("selected", true);
        $(" #province").trigger("change");
        $("#city").find("option[value='" + city + "']").attr("selected", true);
        $(" #city").trigger("change");
        $("#area").find("option[value='" + area + "']").attr("selected", true);
    });
    // #endregion

    // #region 个人资料修改保存
    $('.personal-row #Baocun').click(function () {
        $('.name-row2 #Name #HName').hide();
        $('.name-row2 #Name span').show();
        $('.personal-row #Sex #HSex').hide();
        $('.personal-row #Sex span').show();

        $('.personal-row #CompanyName #HCompanyName').hide();
        $('.personal-row #CompanyName span').show();

        $('.HiddenInput').hide();
        $('.personal-row #ConmanyType span').show();
        $('.personal-row #CompanyPhone #HCompanyPhone').hide();
        $('.personal-row #CompanyPhone span').show();
        $('.personal-row #CompanyAddr #HCompanyAddr').hide();
        $('.personal-row #CompanyAddr span').show();
        $('.personal-row #HCompanyDetail').hide();
        $('.personal-row #CompanyDetail').show();
        $('.personal-row #ZipCode #HZipCode').hide();
        $('.personal-row #ZipCode span').show();
        $('.personal-row #Xiu').show();
        $('.personal-row #Baocun').hide();


        var name = $('.name-row2 #Name #HName').val();
        var Sex = $('.personal-row #Sex #HSex option:selected').val();
        var CompanyName = $('.personal-row #CompanyName #HCompanyName').val();
        var ConmanyType = $('#HConmpanyType option:selected').val();
        var CompanyPhone = $('.personal-row #CompanyPhone #HCompanyPhone').val();
        var ZipCode = $('.personal-row #ZipCode #HZipCode').val();
        var province = $('#province option:selected').val();
        if (area == undefined) {
            layer.msg("请选择省份！");
            return;
        }
        var city = $('#city option:selected').val();
        if (city == undefined) {
            layer.msg("请选择城市！");
            return;
        }
        var area = $('#area option:selected').val();
        if (area == undefined) {
            layer.msg("请选择地区！");
            return;
        }
        var detail = $('.personal-row #HCompanyDetail').val();
        var CompanyAddr = province + ',' + city + ',' + area + ',' + detail;
        var datas = { Sex: Sex, Name: name, CompanyName: CompanyName, ConmanyType: ConmanyType, CompanyPhone: CompanyPhone, CompanyAddr: CompanyAddr, ZipCode: ZipCode };
        jQuery.axpost('../../Api/User/UpdateUserInfo', JSON.stringify(datas), function (data) {
            layer.msg(data.Message);
            window.location.replace("../../UserInfo/Info");
        })
    })
    // #endregion

    //#region 隐藏文本框
    $('.name-row2 #Name #HName').hide();
    $('.personal-row #CompanyName #HCompanyName').hide();
    $('.personal-row #CompanyAddr #HCompanyAddr').hide();
    $('.personal-row #HCompanyDetail').hide();
    $('.personal-row #CompanyPhone #HCompanyPhone').hide();
    $('.personal-row #ZipCode #HZipCode').hide();
    $('.personal-row #Sex #HSex').hide();
    $('.personal-row #Baocun').hide();
    $('.HiddenInput').hide();
    //#endregion
});

// #region 省份
//省份1开始
$(function () {
    GetData($("#CompanyAddr #province"), 'province', '');
    province1();
    $("#CompanyAddr #province").bind("change", function () {
        $('#CompanyAddr #area').find("option:gt(0)").remove();
        if ($("#CompanyAddr #province").val() != '-1') {
            GetData($("#CompanyAddr #city"), "city", $("#CompanyAddr #province").val());
        }
    });

    $("#CompanyAddr #city").bind("change", function () {
        if ($("#city").val() != '-1') {
            GetData($("#CompanyAddr #area"), "area", $("#CompanyAddr #city").val());
        }
    });

    $("#CompanyAddr #div1 select").change(function () {
        $(this).next('input[type=hidden]').val($(this).val());
    });
});
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
var province1 = function () {
    if ($("#CompanyAddr #hidProvince").val() != '') {
        setTimeout(function () { $("#CompanyAddr #province").val($("#CompanyAddr #hidProvince").val()); }, 1);
        setTimeout(function () { $("#CompanyAddr #province").change(); }, 1);
    }
    if ($("#CompanyAddr #hidCity").val() != '' && $("#CompanyAddr #city").val() == '-1') {
        setTimeout(function () { $("#CompanyAddr #city").val($("#CompanyAddr #hidCity").val()); }, 1);
        setTimeout(function () { $("#CompanyAddr #city").change(); }, 1);
    }
    if ($("#CompanyAddr #hidArea").val() != '' && $("#CompanyAddr #area").val() == '-1') {
        setTimeout(function () { $("#CompanyAddr #area").val($("#CompanyAddr #hidArea").val()); }, 1);
        setTimeout(function () { $("#CompanyAddr #area").change(); }, 1);
    }
};
//省份1结束
// #endregion