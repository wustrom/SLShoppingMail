// #region 设置为默认地址
  function Default(Id) {
    var datas = { Id: Id};
    jQuery.axpost('../../Api/User/UpAddrTime', JSON.stringify(datas), function (data) {
        layer.msg(data.Message);
        window.location.href="../../UserInfo/Address";
    })
}
// #endregion

// #region 删除收货人信息
  function DeAddr(Id) {
    var datas = { Id: Id }
    jQuery.axpost('../../Api/User/DeleteAddr', JSON.stringify(datas), function (data) {
        layer.msg(data.Message);
        window.location.href="../../UserInfo/Address";
    });
}
// #endregion

// #region 新增或者修改地址
 $(function () {   
    var Id = $('.bgfff #Id').val();
    if (Id != "0") {
        $('#Address .clear li:last-child a').html("修改");
    }
     $('.add-people-info .action-btn').click(function () {
        var Name = $('.bgfff #Name').val();
        var phone = $('.bgfff #Phone').val();
        var province = $('.bgfff .s2 #province option:selected').val();
        var city = $('.bgfff .s2 #city option:selected').val();
        var area = $('.bgfff .s2 #area option:selected').val();
        var AddrDetail = $('.add-people-info .cennter-box textarea').val();
         var AddrArea = province + ',' + city + ',' + area;
         var Id = $('.bgfff #Id').val();
         if (Id !="0") {
            //修改            
            var datas = { Id:Id, ContactName: Name, ContactPhone: phone, AddrArea: AddrArea, AddrDetail: AddrDetail }
            jQuery.axpost('../../Api/User/UpdateAddrr', JSON.stringify(datas), function (data) {
                layer.msg(data.Message);
            })
         } else {
             //添加
            var datas = { ContactName: Name, ContactPhone: phone, AddrArea: AddrArea, AddrDetail: AddrDetail }
            jQuery.axpost('../../Api/User/AddressAdd', JSON.stringify(datas), function (data) {
                layer.msg(data.Message);
            })
         }
         window.location.href='../../UserInfo/Address';
    })
})
//#endregion

// #region 省份
//省份1开始
$(function () {
    $(".bgfff .s2 #province").bind("change", function () {
        $('.bgfff .s2 #area').find("option:gt(0)").remove();
        if ($(".bgfff .s2 #province").val() != '-1') {
            GetData($(".bgfff .s2 #city"), "city", $(".bgfff .s2 #province").val());
        }
    });

    $(".bgfff .s2 #city").bind("change", function () {
        if ($("#city").val() != '-1') {
            GetData($(".bgfff .s2 #area"), "area", $(".bgfff .s2 #city").val());
        }
    });

    $(".bgfff .s2 #div1 select").change(function () {
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
    if ($("#hidProvince").val() != '') {
        setTimeout(function () {
            $(".bgfff .s2 #province option").each(function () {
                if ($(this).val() == $(".bgfff .s2 #hidProvince").val()) {
                    $(this).attr('selected');
                }
            });
        }, 1);
        setTimeout(function () { $(".bgfff .s2 #province").change(); }, 1);
    }
    if ($("#hidCity").val() != '' && $(".bgfff .s2 #city").val() == '-1') {
        setTimeout(function () {
            $(".bgfff .s2 #city option").each(function () {
                if ($(this).val() == $(".bgfff .s2 #hidCity").val()) {
                    $(this).attr('selected');
                }
            });
        }, 1);
        setTimeout(function () {
            $(".bgfff .s2 #city").change();
        }, 1);
    }
    if ($("#hidArea").val() != '' && $(".bgfff .s2 #area").val() == '-1') {
        setTimeout(function () {
            $(".bgfff .s2 #city area").each(function () {
                if ($(this).val() == $(".bgfff .s2 #hidArea").val()) {
                    $(this).attr('selected');
                }
            });
        }, 1);
        setTimeout(function () {
            $(".bgfff .s2 #area").change();
        }, 1);
    }
};
//省份1结束
// #endregion

// #region 没有数据
  $(function () {
      var count = parseInt($('#hiddPageCount').val());
    if (count == 0) {
        $('.public-content-box .my_address ul').append('<div style="font-size:18px;color:#808080;padding-top:35px;padding-left:30%;">您暂时没有添加新地址！</div>')
    }
})
// #endregion