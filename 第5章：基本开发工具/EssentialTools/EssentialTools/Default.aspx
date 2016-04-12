<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EssentialTools.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="Styles.css" />
</head>
<body>
    <!--ie f12,ff firebug,GoogleChrome 
        ：解决方案aspx右击出Page Inspcetor
        
        jQuerify 小书签 www.learningjquery.com/2009/04/......
        ie f12网络：Fiddler、、www.fiddler2.com
        javescript profiler 探查器
        /*提高js的性能*/ 
        1、简化和重新格式化数据（json数据生成html）
        2、重组客户端设计（向客户端发数据和标记，js处理；对于复杂数据，划分多个部分给Ajax处理）
        3、避免以js实现本机函数

    -->
    <form id="form1" runat="server">
        <div>
            <label>Name:</label>
            <input id="name" runat="server" />
        </div>
        <div>
            <label>City:</label>
            <input id="city" runat="server" />
        </div>
        <button type="submit">Submit</button>
    </form>
    <p id="target" runat="server"></p>
</body>
</html>
