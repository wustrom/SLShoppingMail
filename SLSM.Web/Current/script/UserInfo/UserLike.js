/// <reference path="../ajax.js" />

$(function () {
    getPage();
})

// #region 获得页面
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
    obj.PageSize = 5;
    jQuery.axpost('../../Api/UserLike/UserLikeByPage', JSON.stringify(obj), function (data) {
        var List = data.Model1;
        var OutString = "";
        for (var i = 0; i < List.length; i++) {
            
            OutString = OutString + ' <li>\
            <div class="imgbox">\
                <a>\
                    <img src="' + List[i].Image + '" alt="" />\
                </a>\
            </div>\
            <div class="des">\
                <div class="tt">\
                    <a href="#">'+ List[i].Name + '</a>\
                </div>\
                <div class="word2">'+ List[i].Introduce + '</div>\
            </div>\
            <div class="pri">\
                最低￥'+ List[i].minPrice + '起\
                    </div>\
            <div class="erih">\
                <a onclick="DelLike('+ List[i].Id + ')">\
                <img src="../../base/images/del.png" alt="" />\
                </a>\
                <a href="../../../diy/index?Commodityid='+ List[i].CommodityId + '">查看详情</a>\
            </div>\
        </li>\
                ';
        }
        $('.somecontet .sclist ul').html(OutString);
        if (page == null || page == undefined) {
            getPageCount(1);
        }
        else {
            getPageCount(parseInt($(page).children('a')[0].innerText));
        }
    });
}
// #endregion

// #region 删除
function DelLike(Id) {
    var datas = { Id: Id }
    jQuery.axpost('../../Api/UserLike/DeleteLike', JSON.stringify(datas), function (data) {
        layer.msg(data.Message);

        window.location.replace("../../UserInfo/UserLike");
    });
}
// #endregion


// #region 如果没有数据
$(function () {
    var count = parseInt($('#hiddPageCount').val());
    if (count == 0) {
        $('.propj .pagesize1').hide();
        $('.somecontet .sclist').append('<div style="font-size:18px;color:#808080;padding-top:50px;padding-left:35%;">您暂时没有收藏商品！</div>')
    }
})
// #endregion