var BoxIndex = -1;
var pagingFunc;
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
        paging.init({
            openWait: true,
            url: '../../../APi/Table/GetUserInfo?v=' + new Date().getTime(), //地址
            elem: '#content', //内容容器
            params: { //发送到服务端的参数
            },
            type: 'POST',
            tempElem: '#tpl', //模块容器
            pageConfig: { //分页参数配置
                elem: '#paged', //分页容器
                pageSize: 10 //分页大小
            },
            success: function () { //渲染成功的回调
                //alert('渲染成功');
            },
            fail: function (msg) { //获取数据失败的回调
                alert('获取数据失败')
            },
            complate: function () { //完成的回调
                //alert('处理完成');
                pagingFunc = paging;
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
            },
        });
        //获取所有选择的列
        $('#getSelected').on('click', function () {
            var names = '';
            $('#content').children('tr').each(function () {
                var $that = $(this);
                var $cbx = $that.children('td').eq(0).children('input[type=checkbox]')[0].checked;
                if ($cbx) {
                    var n = $that.find('input[name="Id"]').val();
                    names += n + ',';
                }
            });
            if (names !== '') {
                SendMessage(names);
            }

        });

        //搜索
        $('#search').on('click', function () {
            paging.reload();
        });

        //导出
        //$('#import').on('click', function () {

        //    var that = this;
        //    var index = layer.tips('只想提示地精准些', that, { tips: [1, 'white'] });
        //    $('#layui-layer' + index).children('div.layui-layer-content').css('color', '#000000');
        //});
    });
});

function SendMessage(UserIds) {
    var obj = new Object();
    obj.UserIds = UserIds;
    obj.Id = $('#MessageId').val();
    layer.confirm('是否通知用户？', {
        closeBtn: 0,
        btn: ['是', '否'] //按钮
    }, function () {
        jQuery.axpost('../../api/Message/SendMessage', JSON.stringify(obj), function (dataInfo) {
            layer.msg(dataInfo.Message);
        });
    }, function () {

    });

}