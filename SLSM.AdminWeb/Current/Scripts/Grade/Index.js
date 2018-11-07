var addBoxIndex = -1;
var gradeId;
var fatherId;
var fatherName;
var ids = new Array();
var title;
//ids.push(1)
$(document).ready(function () {
    layui.config({
        base: '../../../Base/js/'
    });

    layui.use(['paging', 'form'], function () {

        var $ = layui.jquery,
            paging = layui.paging(),
            layerTips = parent.layer === undefined ? layui.layer : parent.layer, //获取父窗口的layer对象
            layer = layui.layer, //获取当前窗口的layer对象
            form = layui.form();
        //
        paging.init({
            openWait: true,
            url: '../../Api/grade/GetGrade', //地址
            elem: '#content', //内容容器
            params: { //发送到服务端的参数
                ids: ids
            },
            type: 'POST',
            tempElem: '#tpl', //模块容器
            pageConfig: { //分页参数配置
                elem: '#paged', //分页容器
                pageSize: 999, //分页大小

            },
            success: function () { //渲染成功的回调
                //alert('渲染成功');
            },
            fail: function (msg) { //获取数据失败的回调
                alert('获取数据失败')
            },
            complate: function () { //完成的回调
                //alert('处理完成');
                //重新渲染复选框
                form.render('checkbox');
                form.on('checkbox(allselector)', function (data) {
                    var elem = data.elem;

                    $('#content').children('tr').each(function () {
                        var $that = $(this);
                        //全选或反选
                        $that.children('td').eq(0).children('input[type=checkbox]')[0].checked = elem.checked;
                        form.render('checkbox');
                    });
                });
                //绑定所有编辑按钮事件
                $('#content').children('tr').each(function () {
                    var $that = $(this);
                    $that.children('td:last-child').children('a[data-opt=edit]').on('click', function () {
                        layer.msg($(this).data('name'));
                    });
                });

            },
        });
        //获取所有选择的列
        $('#getSelected').on('click', function () {
            //
            var names = '';
            $('#content').children('tr').each(function () {
                var $that = $(this);
                var $cbx = $that.children('td').eq(0).children('input[type=checkbox]')[0].checked;
                if ($cbx) {
                    var n = $that.children('td:last-child').children('a[data-opt=edit]').data('name');
                    names += n + ',';
                }
            });
            layer.msg('你选择的名称有：' + names);
        });

        //搜索
        $('#search').on('click', function () {
            parent.layer.alert('你点击了搜索按钮')
        });

        //var addBoxIndex = -1;
        //添加
        $('#add').on('click', function () {
            if (addBoxIndex !== -1)
                return;
            //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取

            //GetEditBox()

        });



        //导出
        $('#import').on('click', function () {
            var that = this;
            var index = layer.tips('只想提示地精准些', that, { tips: [1, 'white'] });
            $('#layui-layer' + index).children('div.layui-layer-content').css('color', '#000000');
        });
    });

    $('body').delegate('.layui-colla-title', 'click', function () {
        var e = $(this)
        refreshI(e)
    })


    $('body').delegate('.btn-add', 'click', function () {
        if (addBoxIndex !== -1)
            return;
        gradeId = null;

        fatherId = $(this).data('id');
        fatherName = $(this).data('name');
        title = '添加分类'
        GetEditBox()
    })

    $('body').delegate('.btn-del', 'click', function () {

    })

    $('body').keydown(function (e) {
        if (e.keyCode == 13)
            $('.btn-save').trigger("click");
        if (e.keyCode == 27)
            $('.layui-layer-close1').trigger("click");
    })

});

function GradeDel(event) {
    layer.confirm('确认删除吗？', {
        btn: ['确定', '取消']
    }, function () {
        gradeId = event.dataset.id
        Delete(gradeId)
        layer.closeAll('dialog');
    }, function () {
        layer.closeAll('dialog');
    })
    stopBubbling(event)
}

function GradeEdit(event) {
    if (addBoxIndex !== -1)
        return;
    gradeId = event.dataset.id
    title = "编辑分类"
    GetEditBox()
    stopBubbling(event)
}

function GradeShow(event) {
    layer.confirm('是否前往设置' + event.dataset.opt + '展示商品页面？', {
        btn: ['确定', '取消']
    }, function () {
        gradeId = event.dataset.id
        window.location.href = "../../../Grade/GradeShow?GradeId=" + gradeId;
    }, function (index) {
        layer.close(index);
    })
    stopBubbling(event)
}

function Delete(id) {
    var data = {
        gradeId: id
    }
    jQuery.axpost2('../../Api/grade/delete', data, function (data) {
        $('.layui-layer-close1').click()
        layer.msg('删除成功')
        reload();
    })
}

function GetEditBox() {
    var data = {
        gradeId: gradeId,
        fatherId: fatherId,
        fatherName: fatherName
    }
    $.get('../grade/detail', data, function (form) {
        addBoxIndex = layer.open({
            type: 1,
            title: title,
            content: form,
            //btn: ['保存', '取消'],
            shade: false,
            offset: ['100px', '30%'],
            area: ['600px', '400px'],
            zIndex: 19860924,
            maxmin: true,
            yes: function (index) {
                //触发表单的提交事件
                $('form.layui-form').find('button[lay-filter=edit]').click();
            },
            full: function (elem) {
                var win = window.top === window.self ? window : parent.window;
                $(win).on('resize', function () {
                    var $this = $(this);
                    elem.width($this.width()).height($this.height()).css({
                        top: 0,
                        left: 0
                    });
                    elem.children('div.layui-layer-content').height($this.height() - 95);
                });
            },
            success: function (layero, index) {
                //弹出窗口成功后渲染表单
                var form = layui.form();
                form.render();
                form.on('submit(edit)', function (data) {
                    console.log(data.elem) //被执行事件的元素DOM对象，一般为button对象
                    console.log(data.form) //被执行提交的form对象，一般在存在form标签时才会返回
                    console.log(data.field) //当前容器的全部表单字段，名值对形式：{name: value}
                    //调用父窗口的layer对象
                    layerTips.open({
                        title: '这里面是表单的信息',
                        type: 1,
                        content: JSON.stringify(data.field),
                        area: ['500px', '300px'],
                        btn: ['关闭并刷新', '关闭'],
                        yes: function (index, layero) {
                            layerTips.msg('你点击了关闭并刷新');
                            layerTips.close(index);
                            location.reload(); //刷新
                        }

                    });
                    //这里可以写ajax方法提交表单
                    return false; //阻止表单跳转。如果需要表单跳转，去掉这段即可。
                });
                //console.log(layero, index);
            },
            end: function () {
                addBoxIndex = -1;
            }
        });
    });

    //$('.btn-save').one(function () {
    //    Save();
    //})
}


function showContent(ele) {
    var e = ele.parent().find('.layui-colla-content').first();
    if (e.hasClass('layui-show'))
        e.removeClass('layui-show')
    else
        e.addClass('layui-show');
}

function refreshI(ele) {
    ele.find('i').remove();
    var e = ele.parent().find('.layui-colla-content').first();
    if (e.hasClass('layui-show')) {
        ele.append('<i class="layui-icon layui-colla-icon">&#xe602;</i>')
        e.removeClass('layui-show')
    }
    else {
        ele.append('<i class="layui-icon layui-colla-icon">&#xe61a;</i>')
        e.addClass('layui-show');
    }
    GetShowIds()
    //e.append('<i class="layui-icon layui-colla-icon">&#xe61a;</i>')
}

function GetShowIds() {
    ids = new Array();
    $('.layui-show').prev().find('font').each(function () {
        ids.push($(this).find('a').eq(0).data('id'));
    })
}

function edit() {

}


function collapse() {
    layui.use(['element', 'layer'], function () {
        var element = layui.element;
        element = layui.element();
        var layer = layui.layer;

        //监听折叠
        element.on('collapse(test)', function (data) {
            layer.msg('展开状态：' + data.show);
        });
    });

}


//var clickIndex = 1;
//function clickOrDblClick(n) {
//    clickIndex = n;
//    var val = setTimeout("call();", 250);
//    if (clickIndex == 2) {
//        clearTimeout(val);
//    }
//}
//function call() {
//    if (clickIndex == 1) {
//        layer.msg('click');
//    } else if (clickIndex == 2) {
//        layer.msg('dblclick');
//    }
//} 

function layermsg(e) {
    layer.msg(e)
}

function stopBubbling(e) {
    e = window.event || e;
    if (e.stopPropagation) {
        e.stopPropagation();      //阻止事件 冒泡传播
    } else {
        e.cancelBubble = true;   //ie兼容
    }
}


function reload() {
    layui.use(['paging', 'form'], function () {

        var $ = layui.jquery,
            paging = layui.paging(),
            layerTips = parent.layer === undefined ? layui.layer : parent.layer, //获取父窗口的layer对象
            layer = layui.layer, //获取当前窗口的layer对象
            form = layui.form();
        //
        paging.init({
            openWait: true,
            url: '../../Api/grade/GetGrade', //地址
            elem: '#content', //内容容器
            params: { //发送到服务端的参数
                ids: ids
            },
            type: 'POST',
            tempElem: '#tpl', //模块容器
            pageConfig: { //分页参数配置
                elem: '#paged', //分页容器
                pageSize: 999, //分页大小

            },
            success: function () { //渲染成功的回调
                //alert('渲染成功');
            },
            fail: function (msg) { //获取数据失败的回调
                alert('获取数据失败')
            },
            complate: function () { //完成的回调
                //alert('处理完成');
                //重新渲染复选框
                form.render('checkbox');
                form.on('checkbox(allselector)', function (data) {
                    var elem = data.elem;

                    $('#content').children('tr').each(function () {
                        var $that = $(this);
                        //全选或反选
                        $that.children('td').eq(0).children('input[type=checkbox]')[0].checked = elem.checked;
                        form.render('checkbox');
                    });
                });
                //绑定所有编辑按钮事件
                $('#content').children('tr').each(function () {
                    var $that = $(this);
                    $that.children('td:last-child').children('a[data-opt=edit]').on('click', function () {
                        layer.msg($(this).data('name'));
                    });
                });

            },
        });
        //获取所有选择的列
        $('#getSelected').on('click', function () {
            
            var names = '';
            $('#content').children('tr').each(function () {
                var $that = $(this);
                var $cbx = $that.children('td').eq(0).children('input[type=checkbox]')[0].checked;
                if ($cbx) {
                    var n = $that.children('td:last-child').children('a[data-opt=edit]').data('name');
                    names += n + ',';
                }
            });
            layer.msg('你选择的名称有：' + names);
        });

        //搜索
        $('#search').on('click', function () {
            parent.layer.alert('你点击了搜索按钮')
        });

        //var addBoxIndex = -1;
        //添加
        $('#add').on('click', function () {
            if (addBoxIndex !== -1)
                return;
            //本表单通过ajax加载 --以模板的形式，当然你也可以直接写在页面上读取

            GetEditBox()

        });



        //导出
        $('#import').on('click', function () {
            var that = this;
            var index = layer.tips('只想提示地精准些', that, { tips: [1, 'white'] });
            $('#layui-layer' + index).children('div.layui-layer-content').css('color', '#000000');
        });
    });
}