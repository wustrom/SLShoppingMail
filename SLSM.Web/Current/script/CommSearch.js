var text;//关键词
var sales = 0;//自己输入的销量
var isSearch = false;
var commIds = new Array();

var index = 0;//当前页数，展示从1开始，传数据从0开始
var size = 9;//每页9条数据
var order = 'salesDesc';
$(document).ready(function () {

    GetList();

    //价格筛选
    $('.listcontainer .modebox .price li').click(function () {

        var ids = $(this).find('.commIds').val();
        var thisw = $(this).text();
        thisw = thisw.substring(0, thisw.length - 4)
        $('#price').remove();
        var newsobj = $("<li id='price'><span></span><i></i></li>").html('<input type="hidden" class="commIds" value="' + ids + '" /><span>' + thisw + '</span><i></i>');
        $(".listcontainer .righmain .check .oncheck ul").prepend(newsobj);
        index = 0;
        GetList();
    })
    //颜色筛选
    $('.listcontainer .modebox .colorlist li').click(function () {
        //var colorId = $(this).find('input').val();
        var ids = $(this).find('.commIds').val();
        var thisw = $(this).get(0).title;
        $('#color').remove();
        var newsobj = $("<li id='color'><span></span><i></i></li>").html('<input type="hidden" class="commIds" value="' + ids + '" /><span>' + thisw + '</span><i></i>');
        $(".listcontainer .righmain .check .oncheck ul").prepend(newsobj);
        index = 0;
        GetList();
    })

    //选择评价星级
    $('body').delegate('.stars ul li', 'click', function () {
        var stars = $(this).find('.input-stars').val();
        var ids = $(this).find('.input-stars').prev().val();
        var h = '<li id="stars"><input type="hidden" class="commIds" value="' + ids + '" /><span> ' + stars + '星 </span><i></i></li>'
        $('.check .oncheck ul #stars').remove();
        $('.check .oncheck ul').prepend(h);
        //AddCommId(ids);
        index = 0;
        GetList();
    })

    //选择销量
    $('body').delegate('.numlist li input:radio', 'click', function () {
        $('.numlist .title .words').val('');

        var ids = $(this).prev().val();
        var thisw = $(this).next().html();
        thisw = thisw.substring(0, thisw.length - 4)
        var h = '<li id="li-sales"><input type="hidden" class="commIds" value="' + ids + '" /><span> 销量:' + thisw + ' </span><i></i></li>'
        $('.check .oncheck ul #li-sales').remove();
        $('.check .oncheck ul').prepend(h);
        index = 0;
        GetList();
    })

    //自己输入销量
    //$('body').delegate('.numlist .title input', 'keyup', function () {
    //    var a = $(this).val();
    //    var h = '<li id="li-sales" class="own-sales"><input type="hidden" value="' + a +'" /><span> 销量:' + a + ' </span><i></i></li>'
    //    $('.check .oncheck ul #li-sales').remove();
    //    $('.check .oncheck ul').prepend(h);
    //    GetList();
    //})

    //条件行“x”点击事件
    $('body').delegate('.oncheck ul li i', 'mouseup', function () {
        $(this).parent('.listcontainer .righmain .check .oncheck ul li').remove()
        commIds = new Array();
        //如果是关闭销量的条件，清空radio等
        if ($(this).parent().attr('id') == 'li-sales') {
            $('.numlist li input:radio').attr('checked', false)
            $('.numlist .title input').val('');
        }
        index = 0;
        GetList();
    })

    //销售量输入回车事件
    $('.numlist .title input').bind('keydown', function (event) {
        var a = $(this).val();
        if (event.keyCode == "13") {
            $('.numlist li input:radio').attr('checked', false)
            var h = '<li id="li-sales" class="own-sales"><input type="hidden" value="' + a + '" /><span> 销量:' + a + ' </span><i></i></li>'
            $('.check .oncheck ul #li-sales').remove();
            $('.check .oncheck ul').prepend(h);
            index = 0;
            GetList();
        }
    });

    //排序方法选择
    $('.slikc dl dd').click(function () {
        index = 0;
        order = $(this).find('input').val();
        GetList();
    })

})

//获取列表。局部刷新
function GetList() {
    if ($('.oncheck ul li .commIds').length == 0)
        isSearch = false;
    else
        isSearch = true;

    //
    GetOnCheck();
    //layer.msg(commIds.toString())

    var data = {
        text: text,
        sales: sales,
        order: order,
        commIds: commIds,
        isSearch: isSearch,
        index: index,
        size: size
    }

    $.ajax({
        type: 'post',
        data: data,
        dataType: 'json',
        cache: false,
        url: '/api/commodity/getlistBysearch',
        success: function (res) {
            var r = res.ListData;
            var pages = r[0].pages;
            var index2 = parseInt(r[0].index);
            var listData = r[0].ListData;
            //
            if (listData.length == 0) {
                $('.prolist ul li').remove();
                return;
            }
            var h = '';
            for (var i = 0; i < listData.length; i++) {
                var comm = listData[i];
                var image = comm.image;
                var name = comm.name;
                var price = comm.price;
                var intro = comm.intro;
                var minAmount = comm.minAmount;
                var stars = comm.stars;
                var starsStr;
                if (stars == 5)
                    starsStr = '<img src="/base/images/s1.png" alt="" />'
                else if (stars == 4)
                    starsStr = '<img src="/base/images/s2.png" alt="" />'
                else
                    starsStr = '<img src="/base/images/s3.png" alt="" />'
                h += '<li><div class="imgbox"><a href="#"><img src="' + image + '" alt="" /></a></div><div class="content"><h2 class="h2tit"><div class="s1"><a href="#">' + name + '</a></div><div class="s2">' + starsStr + '</div><div class="s3">' + price + '</div></h2><div class="dewc"><div class="de1">' + intro + '</div><div class="de2">最小数量 ' + minAmount + '</div></div></div></li>'
            }
            var e = $('.prolist ul')
            e.children().remove();
            e.append(h);

            h = GetPageHtml(pages, index2 + 1);

            $('.pagesize1 ul li').remove();
            $('.pagesize1 ul').append(h);
        },
        error: function () {
            layer.msg("程序出错")
        }
    })

}

//添加商品id到数组中
function AddCommId(str) {
    if (str == '')
        commIds = new Array();
    else {
        var ids = str.split(',');
        //
        if (commIds.length > 0) {
            commIds = arrayGetSame(commIds, ids)
            if (commIds.length == 0)
                commIds = new Array('999999');//如果之前的2个条件已经将commIds清空了，后面的条件会直接加上去，所以设置一个假的id
        }
        else {
            for (var i = 0; i < ids.length; i++) {
                commIds.push(ids[i])
            }
        }
        //


    }
}

//获取oncheck标签中所有的筛选条件
function GetOnCheck() {
    commIds = new Array();
    //
    $('.oncheck .commIds').each(function () {
        var ids = $(this).val();
        if (ids == '') {
            commIds = new Array();
            return false;
        }
        AddCommId(ids);
    })
    //layer.msg(commIds.toString());
    //if (commIds.length > 0) {
    //colorId = 0;
    sales = 0;
    //colorId = $('.oncheck .colorId').val();

    sales = $('.oncheck .own-sales input').val();

    //}
}

//两个数组取相同部分
function arrayGetSame(arry1, arry2) {

    var arry3 = new Array();

    var j = 0;

    for (var i = 0; i < arry1.length; i++) {

        for (var k = 0; k < arry2.length; k++) {

            if (arry1[i] == arry2[k]) {

                arry3[j] = arry1[i];

                ++j;
            }

        }

    }

    //array3中存放的就是['b','c']

    return arry3;
}

//跳转到某一页
function getPage(node) {
    var thePage = node.innerText;
    index = thePage - 1;
    GetList();
}
//跳转到下一页
function getNextPage() {
    $('.pagesize1 li').each(function () {
        if ($(this).attr('class') == 'active') {
            var a = $(this).children('a').text();
            var next = parseInt(a) + 1;
            index = next - 1;
            GetList();
        }
    })
}
//跳转到上一页
function getPrePage() {
    $('.pagesize1 li').each(function () {
        if ($(this).attr('class') == 'active') {
            var a = $(this).children('a').text();
            var next = parseInt(a) - 1;
            index = next - 1;
            GetList();
        }
    })
}

