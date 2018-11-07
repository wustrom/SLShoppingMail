$(document).ready(function () {
    $('.basehead .navlist .slidedown .down .list .sli').hover(function () {
        $(this).find('.sibox').stop()
        $(this).find('.sibox').fadeToggle(200)
    })


    $('.basehead .navlist .slidedown').hover(function () {
        $(this).find('.down').stop()
        $(this).find('.down').slideToggle(200)
    })

    $('.listcontainer .sidebar .list li').hover(function () {
        $(this).find('dl').stop()
        $(this).find('dl').slideToggle(200)
    })

    $('.listcontainer .modebox .titlemode ').click(function () {
        $(this).toggleClass('current')
        $(this).siblings('.sli').stop()
        $(this).siblings('.sli').slideToggle(200)
    })

    $('.listcontainer .righmain .check .liststyle .s1 .slikc').click(function () {
        $(this).find('dl').stop()
        $(this).find('dl').slideToggle(200)
    })
    $('.basehead .head .search .shopbtn').hover(function () {
        $(this).find('.slidedownlist').stop()
        $(this).find('.slidedownlist').slideToggle(200)
    })

    $('.listcontainer .righmain .check .liststyle .s1 .slikc dl dd').click(function () {
        var thiswords = $(this).text();
        $('.listcontainer .righmain .check .liststyle .s1 .slikc .h2tit').html(thiswords)
    })

    $('.listcontainer .righmain .check .liststyle .s2 .i1').click(function () {
        $(this).addClass('current');
        $('.listcontainer .righmain .check .liststyle .s2 .i2').removeClass('current');
        $('.listcontainer .righmain .prolist').removeClass('style2')
    })
    $('.listcontainer .righmain .check .liststyle .s2 .i2').click(function () {
        $(this).addClass('current');
        $('.listcontainer .righmain .check .liststyle .s2 .i1').removeClass('current');
        $('.listcontainer .righmain .prolist').addClass('style2')
    })

    $('.shopmain .paytype li').click(function () {
        $('.shopmain .paytype li').removeClass('cur');
        $(this).addClass('cur')
    })

    $('.shopmain .endb .s1 span').click(function () {
        $(this).toggleClass('current')
    })

    $('.shopmain .inforlist li .leftitrm i').click(function () {
        $('.shopmain .inforlist li .leftitrm i').removeClass('current')
        $(this).addClass('current')
    })

    $('#addaddress').click(function () {
        $('.addaddress.address').fadeIn(200)
    })

    $('.addaddress.address .mainbox .h2tit i').click(function () {
        $('.addaddress.address').fadeOut(200)
    })
    $('.addaddress.address .mainbox .keep').click(function () {
        $('.addaddress.address').fadeOut(200)
    })

    $('.addaddress .mainbox .model2 .s2 #list li').click(function () {
        $('.addaddress .mainbox .model2 .s2 #list li').removeClass('current');
        $(this).addClass('current')
    })


    $('.addaddress.fpxx .mainbox .h2tit i').click(function () {
        $('.addaddress.fpxx').fadeOut(200)
    })
    $('.addaddress .mainbox .keep2 *').click(function () {
        $('.addaddress.fpxx').fadeOut(200)
    })


    $('.myorder .ricont .model .price a.a2').click(function () {
        $('.none').fadeIn(200)
    })
    $('.none .conbox .h2tit i').click(function () {
        $('.none').fadeOut(200)
    })
    $('.none .conbox .sendbxh .fs').click(function () {

        $('.none').fadeOut(200)
    })

    // 条件筛选
    $(document).on('click', '.listcontainer .righmain .check .oncheck ul li i', function (e) {
        $(this).parent('.listcontainer .righmain .check .oncheck ul li').remove()
    })
    $('.listcontainer .modebox .price li').click(function () {
        var thisw = $(this).text();
        $('#price').remove();
        var newsobj = $("<li id='price'><span></span><i></i></li>").html("<span>" + thisw + "</span><i></i>");
        $(".listcontainer .righmain .check .oncheck ul").prepend(newsobj);
    })
    $('.listcontainer .modebox .colorlist li').click(function () {
        var thisw = $(this).get(0).title;
        $('#color').remove();
        var newsobj = $("<li id='color'><span></span><i></i></li>").html("<span>" + thisw + "</span><i></i>");
        $(".listcontainer .righmain .check .oncheck ul").prepend(newsobj);
    })

    jQuery(".txtScroll-top").slide({ titCell: ".hd ul", mainCell: ".bd ul", autoPage: true, effect: "top", autoPlay: true });

    $("#return").bind("click", function () {
        $('html, body').animate({ scrollTop: 0 }, 300);
        return false;
    })

    $('.channellist .list .model ul li').hover(function () {
        $(this).find('dl').stop();
        $(this).find('dl').slideToggle(200)
    })

    $('.basehead .top .link li').hover(function () {
        $(this).find('dl').stop();
        $(this).find('dl').slideToggle(200)
    })

    $('#login').click(function () {
        $('.loginalert').fadeIn(200);
    })
    $('.loginalert  .mainbx i').click(function () {
        $('.loginalert').fadeOut(200);
    })

    //$('.shoporder .prodetail .rightde .list .model .right .colorlist li i').eq(0).show();
    $('.shoporder .prodetail .rightde .list .model .right .colorlist li').click(function () {
        $('.shoporder .prodetail .rightde .list .model .right .colorlist li i').hide();
        $(this).find('i').show()
    })
    //$('.shoporder .prodetail .rightde .list .model .right .waylist ul li').eq(0).addClass('current');
    $('.shoporder .prodetail .rightde .list .model .right .waylist ul li').click(function () {
        $('.shoporder .prodetail .rightde .list .model .right .waylist ul li').removeClass('current');
        $(this).addClass('current')
    })


    $('.shoporder .prodetail .rightde .ordersom li').click(function () {
        $('.shoporder .prodetail .rightde .ordersom li').removeClass('current');
        $(this).addClass('current')
    })

    $('.orderalert .conbox .rightbox .hd li').eq(0).addClass('current');
    $('.orderalert .conbox .rightbox .bd .model .sombox').hide()
    $('.orderalert .conbox .rightbox .bd .model .sombox').eq(0).show()
    $('.orderalert .conbox .rightbox .hd li').click(function () {
        var thisa = $('.orderalert .conbox .rightbox .hd li').index(this);
        $('.orderalert .conbox .rightbox .hd li').removeClass('current');
        $(this).addClass('current');
        $('.orderalert .conbox .rightbox .bd .model .sombox').hide()
        $('.orderalert .conbox .rightbox .bd .model .sombox').eq(thisa).show()
    })


    $('.orderalert .conbox .rightbox .bd .model.model1 .link .check .box .s2 .colorse h4').click(function () {
        $(this).siblings('.sel').toggle()
    })
    $('.orderalert .conbox .rightbox .bd .model.model1 .link .check .box .s2 .colorse .sel .list li').click(function () {
        var a = $(this).css("backgroundColor")
        $('.orderalert .conbox .rightbox .bd .model.model1 .link .check .box .s2 .colorse h4 span').get(0).className = ''
        $('.orderalert .conbox .rightbox .bd .model.model1 .link .check .box .s2 .colorse h4 span').css({
            'backgroundColor': a
        })
        $('.orderalert .conbox .leftbox .bjgbox.active .bx .s1.current').css({
            'color': a
        })

        $(this).parents('.sel').hide()
    })

    $('.orderalert .conbox .rightbox .bd .model.model1 .link .check .box .s2 .colorse .sel .word .dm .words').blur(function () {
        var thiswa = '#' + $(this).val()
        $('.orderalert .conbox .rightbox .bd .model.model1 .link .check .box .s2 .colorse .sel .word .resu').get(0).classname = ''
        $('.orderalert .conbox .rightbox .bd .model.model1 .link .check .box .s2 .colorse .sel .word .resu').css({
            'background': thiswa
        })
        $('.orderalert .conbox .leftbox .bjgbox.active .bx .s1.current').css({
            'color': thiswa
        })

    })

    $('.orderalert .conbox .rightbox .bd .model.model1 .allbox .s3 a').eq(0).click(function () {
        var zindex = "auto";
        $('.orderalert .conbox .leftbox .bjgbox.active .mydiv .NodeContent').each(function () {
            if ($(this).css('display') == "block") {
                zindex = $(this).parent().css('z-index');
            }
        });
        var maxZindex = getMaxZindex();
        if (zindex == undefined || zindex == "auto") {
            $('.orderalert .conbox .leftbox .bjgbox.active .current').css('z-index', 3);
            layer.msg('图层已上升');
        }
        else {
            zindex = parseInt(zindex);
            if (zindex >= maxZindex) {
                layer.msg('您当前的图层已经最高');
            }
            else {
                $('.orderalert .conbox .leftbox .bjgbox.active .mydiv .NodeContent').each(function () {
                    if ($(this).css('display') == "block") {
                        zindex = $(this).parent().css('z-index', zindex + 1);
                    }
                });
                layer.msg('图层已上升');
            }
        }

    })

    //获得最高图层的Zindex
    function getMaxZindex() {
        var maxZindex = 1;
        $('.orderalert .conbox .leftbox .bjgbox.active .pic1 div').each(function () {
            var zindex2 = $(this).css('z-index');
            if (zindex2 != "auto") {
                var zindex2 = parseInt(zindex2);
                if (zindex2 > maxZindex) {
                    maxZindex = zindex2;
                }
                else if (zindex2 == maxZindex) {
                    maxZindex++;
                }
            }
        });
        $('.orderalert .conbox .leftbox .bjgbox.active .picbox div').each(function () {
            var zindex3 = $(this).css('z-index');
            if (zindex3 != "auto") {
                var zindex3 = parseInt(zindex3);
                if (zindex3 > maxZindex) {
                    maxZindex = zindex3;
                }
                else if (zindex3 == maxZindex) {
                    maxZindex++;
                }
            }

        });
        $('.orderalert .conbox .leftbox .bjgbox.active .bx div').each(function () {
            var zindex4 = $(this).css('z-index');
            if (zindex4 != "auto") {
                var zindex4 = parseInt(zindex4);
                if (zindex4 > maxZindex) {
                    maxZindex = zindex4;
                }
                else if (zindex4 == maxZindex) {
                    maxZindex++;
                }
            }
        });
        if (maxZindex == 1) {
            maxZindex = 2;
        }
        return maxZindex;
    }

    //获得最低图层的Zindex
    function getMinZindex() {
        var maxZindex = 1000;
        $('.orderalert .conbox .leftbox .bjgbox.active .pic1 div').each(function () {
            var zindex2 = $(this).css('z-index');
            if (zindex2 != "auto") {
                var zindex2 = parseInt(zindex2);
                if (zindex2 < maxZindex) {
                    maxZindex = zindex2;
                }
                else if (zindex2 == maxZindex) {
                    maxZindex--;
                }
            }
        });
        $('.orderalert .conbox .leftbox .bjgbox.active .picbox div').each(function () {
            var zindex3 = $(this).css('z-index');
            if (zindex3 != "auto") {
                var zindex3 = parseInt(zindex3);
                if (zindex3 < maxZindex) {
                    maxZindex = zindex3;
                }
                else if (zindex3 == maxZindex) {
                    maxZindex--;
                }
            }

        });
        $('.orderalert .conbox .leftbox .bjgbox.active .bx div').each(function () {
            var zindex4 = $(this).css('z-index');
            if (zindex4 != "auto") {
                var zindex4 = parseInt(zindex4);
                if (zindex4 < maxZindex) {
                    maxZindex = zindex4;
                }
                else if (zindex4 == maxZindex) {
                    maxZindex--;
                }
            }
        });
        return maxZindex;
    }

    $('.orderalert .conbox .rightbox .bd .model.model1 .allbox .s3 a').eq(1).click(function () {
        var zindex = "auto";
        $('.orderalert .conbox .leftbox .bjgbox.active .mydiv .NodeContent').each(function () {
            if ($(this).css('display') == "block") {
                zindex = $(this).parent().css('z-index');
            }
        });
        var minZindex = getMinZindex();
        zindex = parseInt(zindex);
        if (zindex == 1 || zindex == undefined || zindex == "auto" || zindex <= minZindex) {
            if (zindex <= minZindex) {
                layer.msg('已是最低图层');
            }
            else {
                $('.orderalert .conbox .leftbox .bjgbox.active .mydiv .NodeContent').each(function () {
                    if ($(this).css('display') == "block") {
                        zindex = $(this).parent().css('z-index', zindex - 1);
                    }
                });
            }

        }
        else {
            zindex = parseInt(zindex);
            $('.orderalert .conbox .leftbox .bjgbox.active .mydiv .NodeContent').each(function () {
                if ($(this).css('display') == "block") {
                    zindex = $(this).parent().css('z-index', zindex - 1);
                }
            });
            layer.msg('图层已下降');
        }

    })

    $('.orderalert .conbox .rightbox .bd .model.model1 .link .check .box .s2 .colorse .sel .word .resu').click(function () {
        var thiswa1 = '#' + $('.orderalert .conbox .rightbox .bd .model.model1 .link .check .box .s2 .colorse .sel .word .dm .words').val()
        $('.orderalert .conbox .rightbox .bd .model.model1 .link .check .box .s2 .colorse h4 span').css({
            'background': thiswa1
        })
        $(this).parents('.sel').hide()
    })

    $(document).on('click', '.orderalert .conbox .leftbox .bjgbox.active .twowords div i', function (e) {
        $(this).parent('.s1').remove()
    })

    var numbox = 0;
    //购物车页面重新加载之后的场景结束

    $('.orderalert .conbox .rightbox .bd .model.model1 .link .wordsend button').click(function () {
        numbox += 1;
        var thisw = $('.orderalert .conbox .rightbox .bd .model.model1 .link .wordsend .words').val();
        var a = $('.orderalert .conbox .rightbox .bd .model.model1 .link .check .box .s2 .colorse h4 span').css("backgroundColor");
        a = colorTo16(a);
        var fontfa = $('#fontf').val();
        var fontfz = $('#fontsz').val() + 'px';
        var bog = '<div class="mydiv" move="mydiv" style="z-index:50;height:32px;">\
                    <div class="MyContent" move= "MyContent" style="width:100%;height:100%;">\
                        <span style="font-family:'+ fontfa + ';font-size:' + fontfz + ';color:' + a + ';">' + thisw + '</span>\
                    </div >'+ NodeContent + '\
                   </div>';
        $(".orderalert .conbox .leftbox .bjgbox.active .bx").prepend(bog);
        AddMove();
    })

    function colorTo16(color) {
        if (color.indexOf('rgb') != -1) {
            var array = color.split('(')[1].split(')')[0].split(',');
            var color = "#" + stringToHex(array[0].trim()) + stringToHex(array[1].trim()) + stringToHex(array[2].trim());
        }
        return color;
    }

    function stringToHex(str) {
        var val = "";
        var value = parseInt(str);
        if (value != NaN) {
            val = value.toString(16);
            if (val.length < 2) {
                return "0" + val;
            }
            else {
                return val;
            }
        }
        else {
            return "00";
        }
        
    }
    

    $('.orderalert .conbox .rightbox .bd .model.model1 .loca .s1 a').eq(0).click(function () {
        var thihr = Number($('.orderalert .conbox .leftbox .bjgbox.active .current').eq(0).attr('hf'))
        var aaa = thihr + 0.1;
        $('.orderalert .conbox .leftbox .bjgbox.active .current').eq(0).attr('hf', aaa);
        var bbb = "scale(" + aaa + "," + aaa + ")"
        $('.orderalert .conbox .leftbox .bjgbox.active .current').eq(0).css({
            'transform': bbb
        })
    })

    $('.orderalert .conbox .rightbox .bd .model.model1 .loca .s1 a').eq(1).click(function () {
        var thihr = Number($('.orderalert .conbox .leftbox .bjgbox.active .current').eq(0).attr('hf'))
        var aaa = thihr - 0.1;
        $('.orderalert .conbox .leftbox .bjgbox.active .current').eq(0).attr('hf', aaa);
        var bbb = "scale(" + aaa + "," + aaa + ")"
        $('.orderalert .conbox .leftbox .bjgbox.active .current').eq(0).css({
            'transform': bbb
        })
    })

    var imgnum = 0;
    $('.orderalert .conbox .rightbox .bd .imglist ul li img').click(function () {
        imgnum += 1;
        var thissrc = this.src;
        var thiid = "f" + imgnum;
        var thiidbox = "#" + thiid
        var bog = '<div id="' + thiid + '" class="mydiv" move="mydiv" style="z-index:50">\
                                <div class="MyContent" move= "MyContent" style="width:100%;height:100%;">\
                                    <img ondragstart="return false;" src="'+ this.src + '" />\
                                </div >'+ NodeContent + '\
                              </div>';
        $(".orderalert .conbox .leftbox .bjgbox.active .picbox").prepend(bog);
        ConvertImg($(thiidbox).find('img'));
        AddMove();
    })

    $('.orderalert .conbox .rightbox .bd .model.model1 .loca .s2 .bn1').click(function () {
        var thiswop = Number($('.orderalert .conbox .leftbox .bjgbox.active .current').eq(0).css('top').split('px')[0]) - 10;
        var aaa = thiswop + 'px'
        $('.orderalert .conbox .leftbox .bjgbox.active .current').eq(0).css({
            'top': aaa
        })


    })

    $('.orderalert .conbox .rightbox .bd .model.model1 .loca .s2 .bn4').click(function () {
        var thiswop = Number($('.orderalert .conbox .leftbox .bjgbox.active .current').eq(0).css('top').split('px')[0]) + 10;
        var aaa = thiswop + 'px'
        $('.orderalert .conbox .leftbox .bjgbox.active .current').eq(0).css({
            'top': aaa
        })
    })

    $('.orderalert .conbox .rightbox .bd .model.model1 .loca .s2 .bn2').click(function () {
        var thiswop = Number($('.orderalert .conbox .leftbox .bjgbox.active .current').eq(0).css('left').split('px')[0]) - 10;
        var aaa = thiswop + 'px'
        $('.orderalert .conbox .leftbox .bjgbox.active .current').eq(0).css({
            'left': aaa
        })
    })

    $('.orderalert .conbox .rightbox .bd .model.model1 .loca .s2 .bn3').click(function () {
        var thiswop = Number($('.orderalert .conbox .leftbox .bjgbox.active .current').eq(0).css('left').split('px')[0]) + 10;
        var aaa = thiswop + 'px'
        $('.orderalert .conbox .leftbox .bjgbox.active .current').eq(0).css({
            'left': aaa
        })
    })

    $('.orderalert .conbox .rightbox .bd .model.model1 .loca .s4 .che .words').change(function () {
        var rotate = "rotate" + "(" + $(this).val() + "deg" + ")"
        $('.orderalert .conbox .leftbox .bjgbox.active .current').css({
            'transform': rotate
        })
    })

    $('.orderalert .conbox .rightbox .bd .model.model1 .loca .s4 .che .b1').click(function () {
        var thiva = Number($('.orderalert .conbox .rightbox .bd .model.model1 .loca .s4 .che .words').val())
        thiva -= 1;
        $('.orderalert .conbox .rightbox .bd .model.model1 .loca .s4 .che .words').val(thiva)
        var rotate = "rotate" + "(" + thiva + "deg" + ")"
        $('.orderalert .conbox .leftbox .bjgbox.active .current').css({
            'transform': rotate
        })
    })

    $('.orderalert .conbox .rightbox .bd .model.model1 .loca .s4 .che .b2').click(function () {
        var thiva = Number($('.orderalert .conbox .rightbox .bd .model.model1 .loca .s4 .che .words').val())
        thiva += 1;
        $('.orderalert .conbox .rightbox .bd .model.model1 .loca .s4 .che .words').val(thiva)
        var rotate = "rotate" + "(" + thiva + "deg" + ")"
        $('.orderalert .conbox .leftbox .bjgbox.active .current').css({
            'transform': rotate
        })
    })

    var NodeContent = '<div class="NodeContent">\
                            <div move="topleft" class="nodebo node_top_left"></div>\
                            <div move="topcenter" class="nodebo node_top_center"></div>\
                            <div move="topright" class="nodebo node_top_right"></div>\
                            <div move="centerleft" class="nodebo node_center_left"></div>\
                            <div move="centerright" class="nodebo node_center_right"></div>\
                            <div move="bottomleft" class="nodebo node_bottom_left"></div>\
                            <div move="bottomcenter" class="nodebo node_bottom_center"></div>\
                            <div move="bottomright" class="nodebo node_bottom_right"></div>\
                            <div move="delete"  class="node_delete"></div>\
                            <div class="node_scale"></div>\
                            <div class="node_shu"></div>\
                        </div>';

    $('.orderalert .conbox .rightbox .bd .model .sendwords .send .file').change(function () {
        var file = this.files[0];
        var that = this;
        if (window.FileReader) {
            var reader = new FileReader();
            reader.readAsDataURL(file);
            //监听文件读取结束后事件    
            reader.onloadend = function (e) {
                var datas = new Object();
                var thissrc = e.target.result;
                datas.pic = thissrc;
                datas.ShopCartId = $("#hiddDetailId").val();
                jQuery.axadminpost('../../Api/UpImg/UpdateOrderCross', datas, function (data) {
                    imgnum += 1;
                    var thiid = "u" + imgnum;
                    var thiidbox = "#" + thiid
                    var bog = '<div id="' + thiid + '" class="mydiv" move="mydiv" style="z-index:50">\
                                <div class="MyContent" move= "MyContent" style="width:100%;height:100%;" >\
                                    <img ondragstart="return false;" src="'+ data.Message + '" />\
                                </div >'+ NodeContent + '\
                              </div>';
                    $(".orderalert .conbox .leftbox .bjgbox.active .pic1").prepend(bog);
                    ConvertImg($(thiidbox).find('img'));
                    that.value = "";
                    AddMove();
                })
            };
        }

    })
    AddMove();



    function RemoveCurrent() {
        $('.orderalert .conbox .leftbox .bjgbox.active .pic1 div').each(function () {
            $(this).removeClass('current');
        });
        $('.orderalert .conbox .leftbox .bjgbox.active .picbox div').each(function () {
            $(this).removeClass('current');
        });
        $('.orderalert .conbox .leftbox .bjgbox.active .bx div').each(function () {
            $(this).removeClass('current');
        });
    }





    $(document).on('click', '.orderalert .conbox .leftbox .bjgbox.active .pic1 i', function (e) {
        $(this).parent('div').remove()
    })

    $(document).on('click', '.orderalert .conbox .leftbox .bjgbox.active .picbox div i', function (e) {
        $(this).parent('div').remove()
    })

    $('#fontf').change(function () {
        var fontfa = $('#fontf').val();
        $('.orderalert .conbox .leftbox .bjgbox.active .bx .s1.current').css({
            'fontFamily': fontfa
        })
    })

    $('#fontsz').change(function () {
        var fontfz = $('#fontsz').val() + 'px';
        $('.orderalert .conbox .leftbox .bjgbox.active .bx .s1.current').css({
            'fontSize': fontfz
        })
    })

    $('.shoporder .prodetail .rightde .list .model .right .click').click(function () {
        $('.orderalert').show()
    })


    $('.myinforbox .mycontent .somecontet .baseinfor .upload .rightsome2 p .s2 .name i').click(function () {
        $('.alertname.al2').show()
    })




    $('.myinforbox .mycontent .somecontet .baseinfor .upload .rightsome2 p .s2 .num a').eq(0).click(function () {
        $('.alertname.al1').show()
    })

    $('.alertname .detailcontent .box2 .xg').click(function () {
        $('.alertname.al1').hide();
        $('.alertname.al3').hide();
    })

    $('.alertname .detailcontent .h2tit i').click(function () {
        $('.alertname').hide()
    })

    $('.myinforbox .mycontent .somecontet .baseinfor .upload .rightsome2 p .s2 .num a').eq(1).click(function () {
        $('.alertname.al3').show()
    })
    //$('.myinforbox .mycontent .somecontet .inforlisty .titbox .s1 input').click(function () {
    //    //alert(this.checked);  
    //    if ($(this).is(':checked')) {
    //        $('.myinforbox .mycontent .somecontet .inforlisty .list li .s1 input').each(function () {
    //            //此处如果用attr，会出现第三次失效的情况  
    //            $(this).prop("checked", true);
    //        });
    //    } else {
    //        $('.myinforbox .mycontent .somecontet .inforlisty .list li .s1 input').each(function () {
    //            $(this).removeAttr("checked", false);
    //        });
    //        //$(this).removeAttr("checked");  
    //    }
    //});

    $('.shopmain .listmain .titkbox .check input').click(function () {
        //alert(this.checked);  
        if ($(this).is(':checked')) {
            $('.shopmain .listmain .list li .check input').each(function () {
                //此处如果用attr，会出现第三次失效的情况  
                $(this).prop("checked", true);
                PriceSum();
            });
        } else {
            $('.shopmain .listmain .list li .check input').each(function () {
                $(this).removeAttr("checked", false);
                PriceSum();
            });
            //$(this).removeAttr("checked");  
        }

    });



    //$('.myinforbox .mycontent .somecontet .inforlisty .list li .s2').click(function () {
    //    $('.dealert').show()
    //})

    //$('.dealert .detailcontent .h2tit i').click(function () {
    //    $('.dealert').hide()
    //})
    //$('.dealert .detailcontent .content .del').click(function () {
    //    $('.dealert').hide()
    //})
})

$(document).on('mouseover', '.orderalert .conbox .leftbox .bjgbox.active div span', function (e) {

    $(this).attr('contenteditable', true)

})

//转换图片成base64
function ConvertImg(img) {
    if ($(img).val() != null && $(img).val() != undefined && $(img).val() != "" && $(img).val().indexOf("data:image") != -1) {
        var data = $(img).val();
        $(img).val($(img).attr("src"));
        $(img).attr("src", data);
    }
    else {
        var index = layer.load(1);
        var image = new Image();
        image.crossOrigin = 'Anonymous';
        image.src = $(img).attr("src");
        image.onload = function () {
            var canvas = document.createElement("canvas");
            canvas.width = image.width;
            canvas.height = image.height;
            var ctx = canvas.getContext("2d");
            ctx.drawImage(image, 0, 0, image.width, image.height);
            var ext = image.src.substring(image.src.lastIndexOf(".") + 1).toLowerCase();
            var dataURL = canvas.toDataURL("image/" + ext);
            $(img).attr("src", dataURL);
            $(img).val(image.src);
            layer.close(index);
        }
        $(img).load();
    }
}
//把图片转换回来
function ConvertBackImg(img) {
    var src = $(img).val();
    $(img).val($(img).attr("src"));
    $(img).attr("src", src);
}
// #endregion

var isMouseDown = false; //鼠标是否按下 
var isRotateMouseDown = false;
var mouseDownPosiY;
var mouseDownPosiX;
var InitPositionY;
var InitPositionX;
var InitHeight;
var InitWidth;
var mousedownid; //按下的元素
var that;
var that2;
// #region 让图片开始移动
function AddMove() {

    $(".MyContent").unbind();
    $(".MyContent").mousedown(function (e) { //鼠标按下
        mouseDownPosiY = e.pageY;
        mouseDownPosiX = e.pageX;
        isMouseDown = true;
        that = $(this).parent();
        mousedownid = $(this).attr("move");
        InitPositionY = $(that).css("top").replace("px", "");
        InitPositionX = $(that).css("left").replace("px", "");
        InitHeight = $(that).height();
        InitWidth = $(that).width();
    });
    $(".mydiv").unbind();
    $(".mydiv").mousedown(function () {
        $(".mydiv").each(function () {
            $(this).children('div').eq(1).hide();
        });
        $(this).children('div').eq(1).show();
    })
    $(".nodebo").unbind();
    $(".nodebo").mousedown(function (e) { //鼠标按下
        mouseDownPosiY = e.pageY;
        mouseDownPosiX = e.pageX;
        isMouseDown = true;
        that = $(this).parent().parent();
        mousedownid = $(this).attr("move");
        InitPositionY = $(that).css("top").replace("px", "");
        InitPositionX = $(that).css("left").replace("px", "");
        InitHeight = $(that).height();
        InitWidth = $(that).width();
        $("#txtdownstate").val(isMouseDown);
    });
    $(".node_delete").unbind();
    $(".node_delete").mousedown(function (e) { //鼠标按下
        layer.confirm('您确定要删除该元素？', {
            btn: ['确定', '取消'] //按钮
        }, function (index) {
            layer.close(index);
            $(that).remove();
        });
    });
    $(document).unbind();
    $(document).mousemove(function (e) { //鼠标移动
        if (isMouseDown) {
            var hh = parseInt(e.pageY) - parseInt(mouseDownPosiY);
            var ww = parseInt(e.pageX) - parseInt(mouseDownPosiX);
            var tempY = hh + parseInt(InitPositionY);
            var tempX = ww + parseInt(InitPositionX);
            switch (mousedownid) //修改元素属性
            {
                case "topleft":
                    if ($(that).find('.MyContent span').length == 0) {
                        $(that).css({ "top": tempY + "px", "height": parseInt(InitHeight) - hh + "px", "left": tempX + "px", "width": parseInt(InitWidth) - ww + "px" });
                    }
                    else {
                        var scale = InitHeight / 30;
                        $(that).css('transform', 'scale(' + scale + ',' + scale + ')');
                    }
                    break;
                case "topcenter":
                    if ($(that).find('.MyContent span').length == 0) {
                        $(that).css({ "top": tempY + "px", "height": parseInt(InitHeight) - hh + "px" });
                    }
                    else {
                        var scale = InitHeight / 30;
                        $(that).css('transform', 'scale(' + scale + ',' + scale + ')');
                    }
                    break;
                case "topright":
                    if ($(that).find('.MyContent span').length == 0) {
                        $(that).css({ "top": tempY + "px", "height": parseInt(InitHeight) - hh + "px", "width": parseInt(InitWidth) + ww + "px" });
                    }
                    else {
                        var scale = InitHeight / 30;
                        $(that).css('transform', 'scale(' + scale + ',' + scale + ')');
                    }

                    break;
                case "centerleft":
                    $(that).css({ "left": tempX + "px", "width": parseInt(InitWidth) - ww + "px" });
                    break;
                case "centerright":
                    $(that).css({ "width": parseInt(InitWidth) + ww + "px" });
                    break;
                case "bottomleft":
                    if ($(that).find('.MyContent span').length == 0) {
                        $(that).css({ "height": parseInt(InitHeight) + hh + "px", "left": tempX + "px", "width": parseInt(InitWidth) - ww + "px" });
                    }
                    else {
                        var scale = InitHeight / 30;
                        $(that).css('transform', 'scale(' + scale + ',' + scale + ')');
                    }

                    break;
                case "bottomcenter":
                    if ($(that).find('.MyContent span').length == 0) {
                        $(that).css("height", parseInt(InitHeight) + hh + "px");
                    }
                    else {
                        var scale = InitHeight / 30;
                        $(that).css('transform', 'scale(' + scale + ',' + scale + ')');
                    }

                    break;
                case "bottomright":
                    if ($(that).find('.MyContent span').length == 0) {
                        $(that).css({ "height": parseInt(InitHeight) + hh + "px", "width": parseInt(InitWidth) + ww + "px" });
                    }
                    else {
                        var scale = InitHeight / 30;
                        $(that).css('transform', 'scale(' + scale + ',' + scale + ')');
                    }
                    break;
                case "MyContent":
                    $(that).css("left", tempX + "px").css("top", tempY + "px");
                    break;
            }
        }
        //旋转
        else if (isRotateMouseDown) {
            var ox = parseInt(e.pageX) - parseInt(offsetX);//计算出鼠标相对于画布中心的位置  
            var oy = parseInt(e.pageY) - parseInt(offsetY);
            var to = Math.abs(ox / oy);
            var angle = Math.atan(to) / (2 * Math.PI) * 360;//鼠标相对于旋转中心的角度  
            if (ox < 0 && oy < 0) {
                angle = -angle;
            } else if (ox < 0 && oy > 0) {
                angle = -(180 - angle)
            } else if (ox > 0 && oy < 0) {
                angle = angle;
            } else if (ox > 0 && oy > 0) {
                angle = 180 - angle;
            }
            $("#txtxz").val(angle);
            $(that2).css("transform", "rotate(" + angle + "deg)");
        }

    }).mouseup(function () {
        mousedownid = "";
        isMouseDown = false;
        isRotateMouseDown = false;
        $("#txtdownstate").val(isMouseDown); //显示状态
    }).mouseleave(function () {
        mousedownid = "";
        isMouseDown = false;

        $("#txtdownstate").val(isMouseDown); //显示状态
    });
    $(".node_scale").unbind();
    $(".node_scale").mousedown(function (e) { //鼠标按下      
        var parentdiv = $(this).parent().parent();
        offsetX = parseInt($(parentdiv)[0].getBoundingClientRect().left + document.body.scrollLeft) + parseInt($(parentdiv)[0].getBoundingClientRect().width) / 2;
        offsetY = parseInt($(parentdiv)[0].getBoundingClientRect().top + document.body.scrollTop) + parseInt($(parentdiv)[0].getBoundingClientRect().height) / 2;
        isRotateMouseDown = true;

        that2 = $(this).parent().parent();
    });
}

    // #endregion