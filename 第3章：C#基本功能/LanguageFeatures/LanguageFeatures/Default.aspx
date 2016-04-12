<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LanguageFeatures.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>LanguageFeatures</title>
</head>
<body>
    <h2>Language Features</h2>
    <p><%=GetMessage() %><!--要先运行一次，才会出来=   GetMessage()--></p>
    <p><%=GetMessage_init() %></p>
    <p><%=GetMessage_initSetAndArray() %></p>
    <p><%=GetMessage_Prices() %></p>
    <p><%=GetMessage_IEnum() %></p>
    <p><%=GetMessage_Filter() %></p>
    <p><%=GetMessage_FilterFun() %></p>
    <p><%=GetMessage_FilterLambda() %></p>
    <p><%=GetMessage_FilterLambdaPlus() %></p>
    <p><%=InterfaceFunc() %></p>
    <p><%=NonLinq() %></p>
    <p><% =UseLinqDot()%></p>
</body>
</html>
