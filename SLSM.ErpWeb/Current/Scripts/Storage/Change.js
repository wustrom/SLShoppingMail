layui.config({
    base: '../../../Base/js/',
    v: new Date().getTime()+"123",
}).use(['btable', 'form'], function () {
    var btable = layui.btable(),
        $ = layui.jquery,
        layerTips = parent.layer === undefined ? layui.layer : parent.layer, //获取父窗口的layer对象
        layer = layui.layer,//获取当前窗口的layer对象;
        form = layui.form();
    var BoxIndex = -1;
    btable.set({
        openWait: true,//开启等待框
        elem: '#content',
        url: '../../../APi/Table/GetChangeStorageInfo', //数据源地址
        pageSize: 18,//页大小
        params: {//额外的请求参数
            t: new Date().getTime()
        },
        columns: [
            { //配置数据列
                fieldName: '时间', //显示名称
                field: 'ChangeTime', //字段名
                width: "15%"
            }, {
                fieldName: '类型',
                field: 'ChangeType',
                width: "15%"
            },
            {
                fieldName: '调整数量',
                field: 'ChangeCount',
                width: "10%"
            },
            {
                fieldName: '调整后库存',
                field: 'ChangeAfterCount',
                width: "10%"
            },
            {
                fieldName: '原因',
                field: 'ChangeContext',
                width: "50%"
            }],
        even: false,//隔行变色
        field: 'Id', //主键ID
        //skin: 'row',
        checkbox: false,//是否显示多选框
        paged: true, //是否显示分页
        singleSelect: false, //只允许选择一行，checkbox为true生效
        SerialNumber: true,//是否有序号
        onSuccess: function ($elem) { //$elem当前窗口的jq对象
            $elem.children('tr').each(function () {
                $(this).children('td').children('button').each(function () {
                    var $that = $(this);
                    var action = $that.data('action');
                    var id = $that.data('id');
                    $that.on('click', function () {
                        var Id = $that.parent().parent().find('input[name="id"]').val();
                        if (BoxIndex !== -1) {
                            layer.msg("已有一个弹出窗口！");
                            return;
                        }
                        switch (action) {
                        }
                    })
                });
            });
        },
        dbclicktext: "Detailed"
    });
    btable.render();
    //监听搜索表单的提交事件
    form.on('submit(search)', function (data) {
        btable.get(data.field);
        return false;
    });
    form.on('select(StatusType)', function (data) {
        $("#submit_btn").trigger('click');
    });

    $(window).on('resize', function (e) {
        var $that = $(this);
        $('#content').height($that.height() - 92);
    }).resize();

    var Id = $('input[name="storageId"]').val();
    if (Id != null && Id != "") {
        var obj = new Object();
        obj.storageId = Id;
        btable.get(obj);
        return false;
    }
});
