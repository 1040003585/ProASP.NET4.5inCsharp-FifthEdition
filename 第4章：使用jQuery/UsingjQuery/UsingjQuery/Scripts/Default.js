/// <reference path="jquery-1.8.2.js />
/*上面第一行代码不是有效的JavaScript代码，Visual Studio会找到并处理*/

/*
$('*')选择文档中所有的元素
$('.myclass')选择文档中所有该类
$('element')选择文档中所有该元素
$('#myid')选择文档中id为myid的元素
*/
$(document).ready(function () {
    /*结合选择器*/
    //tr td，td-table,
    $('td+td').addClass('highlight');
    /*特殊选择器*/
    ///////$('[type][value="Delete"]').addClass("highlight");
    /*过滤选择器*/
    //:eq[n]第n个，:even:odd 编号偶or奇
    //:first:last 第一or最后一个
    //：gt(n):lt(n)索引相对于其同级大于或小于n的所有元素
    //:not(selector)
    //header 即h1,h2...
    $('tr:first').addClass("highlight");
    /**内容过滤器*/
    // :first-child ,last-child,:parent,:nth-child(n),:only-child
    //////$('tr:has(td:contains("Kili"))').addClass("highlight");
    /*表单过滤器*/
    //:checkbox,:checke,:input,:disable:enable,:password,:raio,:reset,:selected,:submit,:text
    $(':button').addClass("highlight");

    /*使用jQuery函数*/
    //addClass('myClass'),hasClass('myClass'),removeClass('myClass')
    //toggleClass('myClass')该类不存则添加，否则删除该类
    //css('property','value')指定的属性和值添加到所选元素的样式特性中
    //css('property')从第一个匹配的元素返回特定属性的值
    ////$('td').addClass('highlight').css('color', 'blue');
    /*使用DOM导航函数*/
    $('table').find('td[class]').parent().filter(":odd").addClass("highlight");

    /*使用DOM操作函数*/
    $('tr').append("<td></td>");
    $('<input name="delete" type="radio"/>').appendTo('tbody td:last-child')
        .first().attr("checked", true);

    /*使用jQuery事件*/
    //click,dbclick,mouseenter,mouseleave,change,select,submit
    //$(':button').bind("click", function (e) {
    $(':button').click(function(e){
        $(":radio:checked").closest("tr").remove();
        $(":radio").first().attr("checked", true);
    });





});