
/// <reference path="../../plugins/layui/layui.js" />
var tab;

layui.config({
    base: '/Base/js/',
    version: new Date().getTime()
}).use(['element', 'layer', 'navbar', 'tab'], function () {
    var element = layui.element(),
        $ = layui.jquery,
        layer = layui.layer,
        navbar = layui.navbar();
    tab = layui.tab({
        elem: '.admin-nav-card' //设置选项卡容器
        ,
        //maxSetting: {
        //	max: 5,
        //	tipMsg: '只能开5个哇，不能再开了。真的。'
        //},
        contextMenu: true,
        onSwitch: function (data) {
        },
        closeBefore: function (obj) { //tab 关闭之前触发的事件
            console.log(obj);
            //obj.title  -- 标题
            //obj.url    -- 链接地址
            //obj.id     -- id
            //obj.tabId  -- lay-id
            if (obj.title === 'BTable') {
                layer.confirm('确定要关闭' + obj.title + '吗?', { icon: 3, title: '系统提示' }, function (index) {
                    //因为confirm是非阻塞的，所以这里关闭当前tab需要调用一下deleteTab方法
                    tab.deleteTab(obj.tabId);
                    layer.close(index);
                });
                //返回true会直接关闭当前tab
                return false;
            } else if (obj.title === '表单') {
                layer.confirm('未保存的数据可能会丢失哦，确定要关闭吗?', { icon: 3, title: '系统提示' }, function (index) {
                    tab.deleteTab(obj.tabId);
                    layer.close(index);
                });
                return false;
            }
            return true;
        }
    });
    //iframe自适应
    $(window).on('resize', function () {
        var $content = $('.admin-nav-card .layui-tab-content');
        $content.height($(this).height() - 147);
        $content.find('iframe').each(function () {
            $(this).height($content.height());
        });
    }).resize();

    $(function () {
        var obj = new Object();
        var str = $('#ERProlePower').val();

        var array = new Array();
        var arrayChildren1 = new Array();
        var arrayChildren2 = new Array();
        var arrayChildren3 = new Array();
        var arrayChildren4 = new Array();
        var arrayChildren5 = new Array();
        var arrayChildren6 = new Array();

        //#region 
        if (str.indexOf('DesignerInfo,') != -1) {
            array.push({
                title: "设计师管理",
                icon: "&#xe613;",
                spread: false,
                href: "../../Designer/DesignerInfo",
                value: "DesignerInfo"
            });
        }
        if (str.indexOf('ManufactureInfo,') != -1) {
            array.push({
                "title": "生产管理",
                "icon": "&#xe613;",
                "spread": false,
                "href": "../../Designer/ManufactureInfo?OrderText=1",
                "value": "ManufactureInfo"
            });
        }
        if (str.indexOf('OrderInfo,') != -1) {
            array.push({
                "title": "客服管理",
                "icon": "fa-shopping-cart",
                "spread": false,
                "children": [
                    {
                        "title": "订单管理",
                        "icon": "&#xe60a;",
                        "href": "../../Service/OrderInfo?ReturnText=1",
                        "value": "OrderInfo"
                    }
                ]
            });
        }

        //#region产品原材料
        if (str.indexOf('MaterialManger,') != -1) {
            arrayChildren1.push({
                "title": "产品资料管理",
                "icon": "&#xe60a;",
                "href": "../../Material/MaterialManger",
                "value": "MaterialManger"
            });
        }
         if (true) {
             arrayChildren1.push({
                "title": "产品采购",
                "icon": "fa-gift",
                "href": "../../Material/ProPurchase",
                "value": "ProducerInfo"
            });
        }
        if (str.indexOf('WaitBuyerInfo,') != -1) {
            arrayChildren1.push({
                "title": "待采购列表",
                "icon": "&#xe60a;",
                "href": "../../Material/WaitBuyerInfo",
                "value": "WaitBuyerInfo"
            });
        }
        if (str.indexOf('BuyerInfo,') != -1) {
            arrayChildren1.push({
                "title": "采购单管理",
                "icon": "&#xe620;",
                "href": "../../Material/BuyerInfo?PrintText=1",
                "value": "BuyerInfo"
            });
        }
        if (str.indexOf('ProducerInfo,') != -1) {
            arrayChildren1.push({
                "title": "供应商管理",
                "icon": "fa-gift",
                "href": "../../Material/ProducerInfo",
                "value": "ProducerInfo"
            });
        }
       
        if (arrayChildren1.length != 0) {
            array.push({
                "title": "产品资料管理",
                "icon": "fa-list",
                "spread": false,
                "children": arrayChildren1
            });
        }
        //#endregion

        //#region品检
        if (str.indexOf('Raw_InspectionInfo,') != -1) {
            arrayChildren2.push({
                "title": "原材料品检",
                "icon": "&#xe612;",
                "href": "../../Inspection/Raw_InspectionInfo",
                "value": "Raw_InspectionInfo"
            });
        }
        if (str.indexOf('Product_InspectionInfo,') != -1) {
            arrayChildren2.push({
                "title": "成品品检",
                "icon": "fa-comment",
                "href": '../../Inspection/Product_InspectionInfo?Text=1',
                "value": "Product_InspectionInfo"
            });
        }
        if (arrayChildren2.length != 0) {
            array.push({
                "title": "品检管理",
                "icon": "fa-comments",
                "spread": false,
                "children": arrayChildren2
            })
        }
        // #endregion

        //#region仓库管理
        if (str.indexOf('StorageInfo,') != -1) {
            arrayChildren3.push({
                "title": "库存管理",
                "icon": "fa-comment-o",
                "href": "../../Warehouses/StorageInfo",
                "value": "StorageInfo"
            });
        }
        if (str.indexOf('BuyerInfo,') != -1) {
            arrayChildren3.push({
                "title": "采购入库",
                "icon": "fa-comment-o",
                "href": "../../Warehouses/BuyerInfo",
                "value": "BuyerInfo"
            });
        }
        if (str.indexOf('ReceiveInfo,') != -1) {
            arrayChildren3.push({
                "title": "生产领料",
                "icon": "fa-comment-o",
                "href": "../../Warehouses/ReceiveInfo",
                "value": "ReceiveInfo"
            });
        }
        if (str.indexOf('WarehouseInfo,') != -1) {
            arrayChildren3.push({
                "title": "仓库分类",
                "icon": "fa-comment-o",
                "href": "../../Warehouses/WarehouseInfo",
                "value": "WarehouseInfo"
            });
        }
        if (arrayChildren3.length != 0) {
            if (str.indexOf('MaterialManger,') != -1) {
                array.push({
                    "title": "仓库管理",
                    "icon": "fa-comments-o",
                    "spread": false,
                    "children": arrayChildren3
                });
            }
        }
        //#endregion

        //#region财务
        if (str.indexOf('WantFinance,') != -1) {
            arrayChildren4.push({
                "title": "应付账款",
                "icon": "fa-comment",
                "href": "../../Finance/WantFinance",
                "value": "WantFinance"
            });
        }
        if (str.indexOf('InvoiceInfo,') != -1) {
            arrayChildren4.push({
                "title": "发票记录",
                "icon": "fa-comment",
                "href": "../../Finance/InvoiceInfo",
                "value": "InvoiceInfo"
            });
        }
        if (arrayChildren4.length != 0) {
            array.push({
                "title": "财务管理",
                "icon": " fa-comments",
                "spread": false,
                "children": arrayChildren4
            })
        }
        // #endregion

        if (str.indexOf('ConsignmentInfo,') != -1) {
            array.push({
                "title": "发货管理",
                "icon": "fa-calculator",
                "spread": false,
                "href": '../../Consignment/ConsignmentInfo?Consignment=1',
                "value": "ConsignmentInfo"
            });
        }

        //#region工艺设备
        if (str.indexOf('TechnologyInfo,') != -1) {
            arrayChildren5.push({
                "title": "定制工艺管理",
                "icon": "&#xe60a;",
                "href": "../../Equipment/TechnologyInfo",
                "value": "TechnologyInfo"
            });
        }
        if (str.indexOf('ColorInfo,') != -1) {
            arrayChildren5.push({
                "title": "颜色管理",
                "icon": "&#xe60a;",
                "href": "../../Equipment/ColorInfo",
                "value": "ColorInfo"
            });
        }
        if (arrayChildren5.length != 0) {
            array.push({
                "title": "工艺设备管理",
                "icon": "fa-calculator",
                "spread": false,
                "children": arrayChildren5
            })
        }
        // #endregion

        //#region权限
        if (str.indexOf('JurisdictionInfo,') != -1) {
            arrayChildren6.push({
                "title": "管理平台帐号权限",
                "icon": "fa-user",
                "href": "../../Jurisdiction/JurisdictionInfo",
                "value": "JurisdictionInfo"
            });
        }
        if (str.indexOf('ErpLoginUser,') != -1) {
            arrayChildren6.push({
                "title": "用户登录管理",
                "icon": "fa-user",
                "href": "../../Jurisdiction/ErpLoginUser",
                "value": "ErpLoginUser"
            });
        }
        if (arrayChildren6.length != 0) {
            array.push({
                "title": "帐号权限设置",
                "icon": "fa-users",
                "spread": false,
                "children": arrayChildren6
            })
        }
        // #endregion

        //#endregion

        navbar.set({
            spreadOne: true,
            elem: '#admin-navbar-side',
            cached: true,
            data: array
        })

    })



    //渲染navbar
    navbar.render();

    //监听点击事件
    navbar.on('click(side)', function (data) {
        tab.tabAdd(data.field);
    });
    //清除缓存
    $('#clearCached').on('click', function () {
        navbar.cleanCached();
        layer.alert('清除完成!', { icon: 1, title: '系统提示' }, function () {
            location.reload();//刷新
        });
    });

    $('.admin-side-toggle').on('click', function () {
        var sideWidth = $('#admin-side').width();
        if (sideWidth === 200) {
            $('#admin-body').animate({
                left: '0'
            }); //admin-footer
            $('#admin-footer').animate({
                left: '0'
            });
            $('#admin-side').animate({
                width: '0'
            });
        } else {
            $('#admin-body').animate({
                left: '200px'
            });
            $('#admin-footer').animate({
                left: '200px'
            });
            $('#admin-side').animate({
                width: '200px'
            });
        }
    });
    $('.admin-side-full').on('click', function () {
        var docElm = document.documentElement;
        //W3C  
        if (docElm.requestFullscreen) {
            docElm.requestFullscreen();
        }
        //FireFox  
        else if (docElm.mozRequestFullScreen) {
            docElm.mozRequestFullScreen();
        }
        //Chrome等  
        else if (docElm.webkitRequestFullScreen) {
            docElm.webkitRequestFullScreen();
        }
        //IE11
        else if (elem.msRequestFullscreen) {
            elem.msRequestFullscreen();
        }
        layer.msg('按Esc即可退出全屏');
    });

    $('#setting').on('click', function () {
        tab.tabAdd({
            href: '/Manage/Account/Setting/',
            icon: 'fa-gear',
            title: '设置'
        });
    });

    //锁屏
    $(document).on('keydown', function () {
        var e = window.event;
        if (e.keyCode === 76 && e.altKey) {
            //alert("你按下了alt+l");
            lock($, layer);
        }
    });
    $('#lock').on('click', function () {
        lock($, layer);
    });

    //手机设备的简单适配
    var treeMobile = $('.site-tree-mobile'),
        shadeMobile = $('.site-mobile-shade');
    treeMobile.on('click', function () {
        $('body').addClass('site-mobile');
    });
    shadeMobile.on('click', function () {
        $('body').removeClass('site-mobile');
    });
});

var isShowLock = false;
function lock($, layer) {
    if (isShowLock)
        return;
    //自定页
    layer.open({
        title: false,
        type: 1,
        closeBtn: 0,
        anim: 6,
        content: $('#lock-temp').html(),
        shade: [0.9, '#393D49'],
        success: function (layero, lockIndex) {
            isShowLock = true;
            //给显示用户名赋值
            //layero.find('div#lockUserName').text('admin');
            //layero.find('input[name=username]').val('admin');
            layero.find('input[name=password]').on('focus', function () {
                var $this = $(this);
                if ($this.val() === '输入密码解锁..') {
                    $this.val('').attr('type', 'password');
                }
            })
                .on('blur', function () {
                    var $this = $(this);
                    if ($this.val() === '' || $this.length === 0) {
                        $this.attr('type', 'text').val('输入密码解锁..');
                    }
                });
            //在此处可以写一个请求到服务端删除相关身份认证，因为考虑到如果浏览器被强制刷新的时候，身份验证还存在的情况			
            //do something...
            //e.g. 

            $.getJSON('/Account/Logout', null, function (res) {
                if (!res.rel) {
                    layer.msg(res.msg);
                }
            }, 'json');

            //绑定解锁按钮的点击事件
            layero.find('button#unlock').on('click', function () {
                var $lockBox = $('div#lock-box');

                var userName = $lockBox.find('input[name=username]').val();
                var pwd = $lockBox.find('input[name=password]').val();
                if (pwd === '输入密码解锁..' || pwd.length === 0) {
                    layer.msg('请输入密码..', {
                        icon: 2,
                        time: 1000
                    });
                    return;
                }
                unlock(userName, pwd);
            });
			/**
			 * 解锁操作方法
			 * @param {String} 用户名
			 * @param {String} 密码
			 */
            var unlock = function (un, pwd) {
                console.log(un, pwd);
                //这里可以使用ajax方法解锁
                $.post('/Account/UnLock', { userName: un, password: pwd }, function (res) {
                    //验证成功
                    if (res.rel) {
                        //关闭锁屏层
                        layer.close(lockIndex);
                        isShowLock = false;
                    } else {
                        layer.msg(res.msg, { icon: 2, time: 1000 });
                    }
                }, 'json');
                //isShowLock = false;
                //演示：默认输入密码都算成功
                //关闭锁屏层
                //layer.close(lockIndex);
            };
        }
    });
};