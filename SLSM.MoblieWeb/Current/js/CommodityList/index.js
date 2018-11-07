var commIds = new Array();
var sales = 0;
var gradeId;
var isSearch = false;
var index = 0;
var size = 3;
var order = 'salesDesc'

$(document).ready(function () {
    //$('.btn-select').click(function () {
    //    slideout.toggle();
    //    $('')
    //})
    GetList();

    $('.sel_op select').change(function () {
        order = $(this).val();
        GetList();
    })

    $('body').delegate('.ddPrice', 'click', function () {
        if ($(this).hasClass('ddPrice1')) {
            $(this).removeClass('ddPrice1')
        }
        else {
            $('.ddPrice').removeClass('ddPrice1')
            $(this).addClass('ddPrice1')
        }
        GetList()
    })

    $('body').delegate('.aColor', 'click', function () {
        if ($(this).hasClass('aColor1'))
            $(this).removeClass('aColor1')
        else {
            $('.aColor').removeClass('aColor1')
            $(this).addClass('aColor1')
        }
        GetList()
    })
    $('body').delegate('.ddStars', 'click', function () {
        if ($(this).find('en').hasClass('en-tick'))
            $(this).find('en').removeClass('en-tick')
        else {
            $('en').removeClass('en-tick')
            $(this).find('en').addClass('en-tick')
        }
        GetList()
    })
    $('body').delegate('.ddXL', 'click', function () {
        if ($(this).hasClass('xl1')) {
            //$(this).removeClass('xl1')
        }
        else {
            $('.ddXL').removeClass('xl1')
            $(this).addClass('xl1')
        }

        $('.input-xl').val('')
        GetList()
    })
    //$('.input-xl').keyup(function () {
    //    $('.ddxl input:radio').attr('checked', false)
    //})
    $('.input-xl').bind('input propertychange', function () {
        $('.ddXL input:radio').attr('checked', false)
        GetList()
    });

})

function GetList() {
    sales = 0;
    sales = $('.input-xl').val();
    var ids1 = $('.ddPrice1 .commIds').val()
    var ids2 = $('.aColor1 .commIds').val()
    var ids3 = $('.en-tick').parent().find('.commIds').val();
    var ids4 = $('.xl1').find('.commIds').val();
    commIds = new Array();
    if (ids1 != null)
        AddCommId(ids1)
    if (ids2 != null)
        AddCommId(ids2)
    if (ids3 != null)
        AddCommId(ids3)
    if (ids4 != null)
        AddCommId(ids4)
    if ($('.ddPrice1 .commIds').length == 0 && $('.aColor1 .commIds').length == 0 && $('.en-tick').parent().find('.commIds').length == 0 && $('.xl1').find('.commIds').length == 0 && sales == 0)
        isSearch = false;
    else
        isSearch = true;
    var data = {
        gradeId: gradeId,
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
        url: '/api/commodity/getlist',
        success: function (res) {
            var r = res.ListData;
            var pages = r[0].pages;
            var index2 = parseInt(r[0].index);
            var listData = r[0].ListData;
            if (listData.length == 0) {
                $('.product-list ul li').remove();
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
                //    if (stars == 5)
                //        starsStr = '<img src="/base/images/s1.png" alt="" />'
                //    else if (stars == 4)
                //        starsStr = '<img src="/base/images/s2.png" alt="" />'
                //    else
                //        starsStr = '<img src="/base/images/s3.png" alt="" />'
                h += '<li><div class="img"><a href="../../Commodity/index?Commodityid=' + comm.id + '"><img src="' + image + '" alt=""></a></div><div class="info"><h6>' + name + '</h6><p>' + price + '</p></div></li>';

                //    h += '<li><div class="imgbox"><a href="#"><img src="' + image + '" alt="" /></a></div><div class="content"><h2 class="h2tit"><div class="s1"><a href="#">' + name + '</a></div><div class="s2">' + starsStr + '</div><div class="s3">' + price + '</div></h2><div class="dewc"><div class="de1">' + intro + '</div><div class="de2">最小数量 ' + minAmount + '</div></div></div></li>'
                //}
            }
            var e = $('.product-list ul')
            e.children().remove();
            e.append(h);

            h = GetPageHtml(pages, index2 + 1);
            $('.plfy ul li').remove();
            $('.plfy ul').append(h)
            //$('.pagesize1 ul li').remove();
            //$('.pagesize1 ul').append(h);
        },
        error: function () {
            layer.msg("程序出错")
        }
    })
    //alert(ids4)
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


//添加商品id到数组中
function AddCommId(str) {
    if (str == '')
        commIds = new Array();
    else {
        var ids = str.split(',');
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


    }
}

//获取页码的所有li标签
function GetPageHtml(pages, thePage) {
    if (pages <= 5) {
        h = ''
        if (thePage == 1)
            h += '<li class="disabled"><a >< 上一页 </a></li>'
        else
            h += '<li onclick="getPrePage()"><a >< 上一页 </a></li>'

        for (var i = 1; i < pages + 1; i++) {
            if (i == thePage) {
                h += '<li class="active"><a >' + i + '</a></li>'
            }
            else
                h += '<li onclick="getPage(this)"><a >' + i + '</a></li>'
        }
        if (pages == thePage)
            h += '<li class="disabled" ><a >下一页 ></a></li>'
        else
            h += '<li onclick="getNextPage()" ><a>下一页 ></a></li>'

    } else {
        if (thePage <= 2) {
            h = ''
            if (thePage == 1)
                h += '<li class="disabled"><a >< 上一页 </a></li>'
            else
                h += '<li onclick="getPrePage()"><a >< 上一页 </a></li>'

            for (var i = 1; i < pages + 1; i++) {
                if (i == pages) {
                    h += '<li onclick=""><a>...</a></li>'
                }
                if (i <= thePage + 2 || i == pages) {
                    if (i == thePage)
                        h += '<li class="active"><a >' + i + '</a></li>'
                    else
                        h += '<li onclick="getPage(this)"><a >' + i + '</a></li>'
                }
            }

            if (pages == thePage) {

                h += '<li class="disabled" ><a >下一页 ></a></li>'
            }
            else {

                h += '<li onclick="getNextPage()" ><a>下一页 ></a></li>'
            }

        } else {
            if (thePage < 4) {
                h = ''
                if (thePage == 1)
                    h += '<li class="disabled"><a>< 上一页 </a></li>'
                else
                    h += '<li onclick="getPrePage()"><a >< 上一页 </a></li>'

                for (var i = 1; i < pages + 1; i++) {
                    if (i == pages && thePage < pages - 3) {
                        h += '<li onclick=""><a>...</a></li>'
                    }
                    if (i <= thePage + 2 && i >= thePage - 2 || i == pages) {
                        if (i == thePage)
                            h += '<li class="active"><a >' + i + '</a></li>'
                        else
                            h += '<li onclick="getPage(this)"><a >' + i + '</a></li>'
                    }
                }

                if (pages == thePage) {

                    h += '<li class="disabled" ><a >下一页 ></a></li>'
                }
                else {

                    h += '<li onclick="getNextPage()" ><a>下一页 ></a></li>'
                }

            } else {
                h = ''
                if (thePage == 1)
                    h += '<li class="disabled"><a >< 上一页 </a></li>'
                else
                    h += '<li onclick="getPrePage()"><a >< 上一页 </a></li>'

                for (var i = 1; i < pages + 1; i++) {
                    if (i == pages && thePage < pages - 3) {
                        h += '<li onclick=""><a>...</a></li>'
                    }
                    if (i <= thePage + 2 && i >= thePage - 2 || i == pages || i == 1) {
                        if (i == thePage)
                            h += '<li class="active"><a >' + i + '</a></li>'
                        else
                            h += '<li onclick="getPage(this)"><a >' + i + '</a></li>'
                    }
                    if (i == 1 && thePage > 4) {
                        h += '<li onclick=""><a>...</a></li>'
                    }
                }

                if (pages == thePage) {

                    h += '<li class="disabled" ><a >下一页 ></a></li>'
                }
                else {

                    h += '<li onclick="getNextPage()" ><a>下一页 ></a></li>'
                }

            }
        }
    }
    if (pages < 1) {
        return "";
    }
    return h;
}

//跳转到某一页
function getPage(node) {
    var thePage = node.innerText;
    index = thePage - 1;
    GetList();
}
//跳转到下一页
function getNextPage() {
    $('.plfy li').each(function () {
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
    $('.plfy li').each(function () {
        if ($(this).attr('class') == 'active') {
            var a = $(this).children('a').text();
            var next = parseInt(a) - 1;
            index = next - 1;
            GetList();
        }
    })
}
