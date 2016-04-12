<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UsingjQuery.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="Styles.css" />
    <script src="/Scripts/jquery-1.8.2.js"></script>
    <script src="/Scripts/Default.js"></script>
    <!--第一个script元素导入jQuery库，另一个元素定义或导入利用的jQuery的代码-->
    <!--Default.js要调用jQuery定义的函数，必须放在之后-->
</head>
<body>
    <input type="button" value="Delete" />
    <h2>Summits</h2>
    <table id="peaksTable">
        <caption>提交信息表</caption>
        <thead>
            <!--tr><th>提交信息表</th></!--tr-->
            <tr>
                <th class="name">Name</th>
                <th>Height(m)</th>
            </tr>
        </thead>
        <tbody id="tableBody">
            <tr>
                <td class="name">0Everest</td>
                <td class="height">8848</td>
            </tr>
            <tr>
                <td class="name">1Aconcagua</td>
                <td class="height">6962</td>
            </tr>
            <tr>
                <td class="name">2McKinley</td>
                <td class="height">6194</td>
            </tr>
            <tr>
                <td class="name">3Kilimanjaro</td>
                <td class="height">5895</td>
            </tr>
            <tr>
                <td class="name">4K2</td>
                <td class="height">8611</td>
            </tr>
        </tbody>
    </table>
    
</body>
</html>
