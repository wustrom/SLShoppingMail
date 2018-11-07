var BoxIndex = -1;
var pagingFunc;
var obj = new Object();
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
    })
})

//#region 关闭
function CloseBtn() {
    var tab = parent.tab;
    tab.deleteTab(tab.getCurrentTabId());
}
//#endregion

//#region 添加信息
function AddDistribution() {
    var count = 0;
    for (var i = 2; i < 11; i++) {
        if ($('table tr').eq(i).find('td').eq(1).html() != "&nbsp;") {
            count += 1;
        }
    }
    var str = '<td><img src="../../Current/Icon/DeleteBox.png" style="padding-right: 10px;margin-top: -4px;cursor:pointer;" class="DeleteBox" /><input type="text" id="procedure" style="height:35px" /></td>\
                    <td><input type="text" id="productionTime" style="width:65px;height:35px;text-align:right" />&nbsp;&nbsp;天</td>\
                    <td><input type="text" id="productionMan" style="width:300px;height:35px" />&nbsp;</td>';
    $('table tr').eq(count + 2).empty();
    $('table tr').eq(count + 2).append(str);
    DeleteBoxReBind();
}
//#endregion

//#region 保存
function Preservation(Id) {
    obj.ProductionPerson= $('#ProductionPerson').html();
    obj.ProductionId = Id;
    obj.Listprocedure = "";
    obj.ListproductionTime = "";
    obj.ListproductionMan = "";
    var array = new Array();
    for (var i = 2; i < 11; i++) {
        if ($('table tr').eq(i).find('td').eq(1).html() != "&nbsp;" && $('table tr').eq(i).find('td:first').find('input').html() != undefined) {
            var procedure = $('table tr').eq(i).find('td').eq(0).find('input').val();
            var productionTime = $('table tr').eq(i).find('td').eq(1).find('input').val();
            var productionMan = $('table tr').eq(i).find('td').eq(2).find('input').val();
            if (isNaN(parseInt(productionTime))) {
                layer.msg('请填写正确生产时间！');
                return;
            }

            if (procedure == "" || procedure == undefined || productionTime == "" || productionTime == undefined || productionMan == "" || productionMan == undefined) {
                layer.msg('请填写完整信息！');
                return;
            }
            array.push({ procedure: procedure, productionTime: productionTime, productionMan: productionMan });
        }
    }
    obj.ProInfo = array;
    layer.confirm('确认保存吗？', null, function (index) {
        jQuery.axpost('../../api/Designer/GetDistribution', JSON.stringify(obj), function (data) {
            layer.close(index);
            layer.msg(data.Message);
            location.reload();
        });
    })
}
//#endregion

$(function () {
    DeleteBoxReBind();
})

function DeleteBoxReBind() {
    $('.DeteteBox').unbind();
    $('.DeleteBox').click(function () {
        $(this).parent().parent().remove();
        var count = 0;
        for (var i = 2; i < 11; i++) {
            if ($('table tr').eq(i).find('td').eq(1).html() != "&nbsp;") {
                count += 1;
            }
        }
        var str = '<tr><td>&nbsp;</td>\
                    <td>&nbsp;</td>\
                    <td>&nbsp;</td></tr>';
        $('table tr').eq(count + 2).after(str);
    })
}