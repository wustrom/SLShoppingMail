//import { fail } from "assert";

// #region 消息显示
function MessShow(Id) {
    $('.dealert.Info').show()
    var datas = { Id: Id };
    jQuery.axpost('../../Api/Message/SelectMessageInfo', JSON.stringify(datas), function (data) {
        var div = '  <h2 class="h2tit">\
                         消息\
                           <i onclick="UpRead('+ data.Model1.Id + ')"></i>\
                      </h2 >\
               <div class="content">\
                    <h3 class="h3tit">\
                        <label class="title1">' + data.Model1.Title + '</label>\
                    </h3 >\
                    <div class="time">\
                        <label class="time1">' + data.Model1.MessageTime + '</label>\
                    </div>\
                    <div class="desc">\
                        ' + data.Model1.Content + '\
                    </div>\
                    <div class="del" >\
                        <a onclick = "Delete( ' + data.Model1.Id + ')" > 删除消息</a>\
                    </div >\
            </div>\
                    ';
        $(".detailcontent").html(div);
    })
}
// #endregion

// #region 未读改为已读
function UpRead(Id) {
    $('.dealert').hide();
    var datas = { Id: Id }
    jQuery.axpost('../../Api/Message/UpdateRead', JSON.stringify(datas), function (data) {
        if (!isNaN(data.Message)) {
            var count = parseInt(data.Message);
            $('.titbox .s2 span').html(data.Message);
        }
        getPage();
    })
}
// 未读修改为已读样式
$('.myinforbox .mycontent .somecontet .inforlisty .titbox .s1 input').click(function () {
    //alert(this.checked);  
    if ($(this).is(':checked')) {
        $('.myinforbox .mycontent .somecontet .inforlisty .list li .s1 input').each(function () {
            //此处如果用attr，会出现第三次失效的情况  
            $(this).prop("checked", true);
        });
    } else {
        $('.myinforbox .mycontent .somecontet .inforlisty .list li .s1 input').each(function () {
            $(this).removeAttr("checked", false);
        });
    }
});
// #endregion

// #region 删除
function Delete(Id) {

    var datas = { Id: Id }
    jQuery.axpost('../../Api/Message/DelateMessInfo', JSON.stringify(datas), function (data) {
        getPage();
        var count = parseInt(data.Message);
        $('.titbox .s2 span').html(data.Message);
    });
}

// 批量删除信息
function ListDeRead() {
    layer.confirm('确认删除吗？', {
        btn: ['确定', '取消']
    }, function (index) {
        layer.close(index);
        $(".s1 input[type='checkbox']").each(
            function (i, item) {
                if (i != 0) {
                    if ($(this).is(':checked')) {
                        Delete($(this).parent().parent().find('.s2 input[name="Id"]').val());
                    }
                }
            })
    }, null);
}
// #endregion

// #region 读取信息
//未读
function UnreadMess(page, obj) {
    jQuery.axpost('../../Api/Message/MessagePage', JSON.stringify(obj), function (data) {
        $('#PageCountType').val("NoReadPageCount");
        $('#hiddNoReadPageCount').val(data.Model2);
        SetMessHtml(data.Model1, page);
    });
}
//全部信息
function AllMess(page, obj) {
    jQuery.axpost('../../Api/Message/MessagePage', JSON.stringify(obj), function (data) {
        $('#PageCountType').val("PageCount");
        $('#hiddPageCount').val(data.Model2);
        SetMessHtml(data.Model1, page);

    });
}

//已读信息
function ReadMess(page, obj) {
    jQuery.axpost('../../Api/Message/MessagePage', JSON.stringify(obj), function (data) {
        $('#PageCountType').val("ReadPageCount");
        $('#hiddReadPageCount').val(data.Model2);
        SetMessHtml(data.Model1, page);
    });
}
// #endregion

//#region 样式处理
//未读信息样式处理
function SetUnReadMess() {
    $('#PageCountType').val("NoReadPageCount");
    $('.myinforbox .mycontent .somecontet .inforlisty .titbox .s1').css('color', '#666666');
    $('.myinforbox .mycontent .somecontet .inforlisty .titbox .s2').css('color', '#008374');
    $('.myinforbox .mycontent .somecontet .inforlisty .titbox .s3').css('color', '#666666');
    getPage(1);
}

// 全部信息样式处理
function SetAllMess() {
    $('#PageCountType').val("PageCount");
    $('.myinforbox .mycontent .somecontet .inforlisty .titbox .s1').css('color', '#008374');
    $('.myinforbox .mycontent .somecontet .inforlisty .titbox .s2').css('color', '#666666');
    $('.myinforbox .mycontent .somecontet .inforlisty .titbox .s3').css('color', '#666666');
    getPage(1);
}

// 已读信息样式处理
function SetReadMess() {
    $('#PageCountType').val("ReadPageCount");
    $('.myinforbox .mycontent .somecontet .inforlisty .titbox .s1').css('color', '#666666');
    $('.myinforbox .mycontent .somecontet .inforlisty .titbox .s2').css('color', '#666666');
    $('.myinforbox .mycontent .somecontet .inforlisty .titbox .s3').css('color', '#008374');
    getPage(1);
}
//#endregion

// #region 加载数据
function SetMessHtml(ListData, page) {
    var OutString = "";
    for (var i = 0; i < ListData.length; i++) {
        if (ListData[i].IsWatch == false) {
            OutString = OutString + '<li class="no">\
                <div class="s1" >\
                    <input type="checkbox" />\
                        </div>\
                <div class="s2">\
                    <a onclick="MessShow('+ ListData[i].Id + ')">\
                        <span class="time">'+ ListData[i].MessageTime + '</span>\
                        <span class="title">'+ ListData[i].MainTitle + '</span>\
                    </a>\
                    <input type="hidden" name="Id" value="'+ ListData[i].Id + '" />\
                </div>\
                    </li >\
                        ';
        } else if (ListData[i].IsWatch == true) {
            OutString = OutString + ' <li class="">\
                <div class="s1" >\
                    <input type="checkbox" />\
                        </div>\
                <div class="s2">\
                    <a onclick="MessShow('+ ListData[i].Id + ')">\
                        <span class="time">'+ ListData[i].MessageTime + '</span>\
                        <span class="title">'+ ListData[i].MainTitle + '</span>\
                    </a>\
                    <input type="hidden" name="Id" value="'+ ListData[i].Id + '" />\
                </div>\
                    </li >\
                        ';
        }

    }
    $('.inforlisty .list ul').html(OutString);
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

//#region分页
//获得全部数据页面
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
    obj.PageSize = 7;
    var PageCountType = $('#PageCountType').val();
    if (PageCountType == "PageCount") {
        AllMess(page, obj);
    }
    else if (PageCountType == "NoReadPageCount") {
        obj.IsWatch = false;
        UnreadMess(page, obj);
    }
    else if (PageCountType == "ReadPageCount") {
        obj.IsWatch = true;
        ReadMess(page, obj);
    }
}
//获得后一页
function getNextPage() {
    var CurrentPage = parseInt($('.propj .pagesize1 ul .active a')[0].innerText);
    var count = 0;
    var PageCountType = $('#PageCountType').val();
    if (PageCountType == "PageCount") {
        count = parseInt($('#hiddPageCount').val());
    }
    else if (PageCountType == "NoReadPageCount") {
        count = parseInt($('#hiddNoReadPageCount').val());
    }
    else if (PageCountType == "ReadPageCount") {
        count = parseInt($('#hiddReadPageCount').val());
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
    //设置页码
    var count = 0;
    var PageCountType = $('#PageCountType').val();
    if (PageCountType == "PageCount") {
        count = parseInt($('#hiddPageCount').val());
    }
    else if (PageCountType == "NoReadPageCount") {
        count = parseInt($('#hiddNoReadPageCount').val());
    }
    else if (PageCountType == "ReadPageCount") {
        count = parseInt($('#hiddReadPageCount').val());
    }
    $('.inforlisty .list').children('div').hide();
    if (count == 0) {
        $('.propj .pagesize1').hide();
        $('.inforlisty .list').children('div').show();
    }
    else {
        $('.propj .pagesize1').show();
    }
    $('.propj .pagesize1 ul').html(GetPageHtml(count, NowPage));
}

//读取页面数据
$(function () {
    getPage();
})
// #endregion

// #region 批量未读改已读
function ListUpRead() {
    $(".s1 input[type='checkbox']").each(
        function (i, item) {
            if (i != 0) {
                if ($(this).is(':checked')) {
                    UpRead($(this).parent().parent().find('.s2 input[name="Id"]').val());
                }
            }
        })
}
// #endregion



//#region 全选/取消全部  
$(function () {
    $(".s1 input").click(function () {
        if (this.checked == true) {
            $('.titbox input').parent().parent().parent().find('.list ul li input').each(function () {
                this.checked = true;
            });
        } else {
            $('.titbox input').parent().parent().parent().find('.list ul li input').each(function () {
                this.checked = false;
            });
        }
    });
})
//#endregion
