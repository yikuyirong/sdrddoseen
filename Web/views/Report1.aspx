<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report1.aspx.cs" Inherits="Web.views.Report1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ OutputCache Location="None" VaryByParam="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=6" />
    <title>统计报表</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <script src="../js/Calendar.js" type="text/javascript"></script>
    <style media=print type="text/css">.noprint{visibility:hidden}</style>
</head>
<body style="position: relative">
    <form id="form1" runat="server">
    <script type="text/javascript">
        var msgdiv = "";
        function search() {
            if ($("#msgdiv").html() != "") {
                msgdiv = $("#msgdiv").html();
                $("#msgdiv").html("");
            }
            var htmlStr = msgdiv;
            $$.MsgBox("", htmlStr, "确定:submit()", "取消");
        }
        function submit() {
            var whereStr = "1=1";
            if (ProjectTypes.value != "") whereStr += " and ProjectTypes='" + ProjectTypes.value + "'";
            if (ProjectLevel.value != "") whereStr += " and ProjectLevel='" + ProjectLevel.value + "'";
            if (time1.value != "" && time2.value != "") whereStr += " and Tbl_Project.adddate>='" + time1.value + "' and Tbl_Project.adddate<='" + time2.value + "'";
            location.href = "?where=" + whereStr;
            //alert(whereStr);
        }
    </script>
    <div class="noprint">
        <div id="msgdiv" class="none">
            <div style="margin: 15px; width: 270px; font-size: 12px;">
                项目类型：<asp:DropDownList ID="ProjectTypes" runat="server" CssClass="select">
                </asp:DropDownList>
                <div style="height: 10px">
                </div>
                项目级别：<asp:DropDownList ID="ProjectLevel" runat="server" CssClass="select">
                </asp:DropDownList>
                <div style="height: 10px">
                </div>
                时间：<input id="time1" type="text" value="" class="input1" onfocus="calendar.setHook(this)" />～<input id="time2" type="text" value="" class="input1" onfocus="calendar.setHook(this)" />
            </div>
        </div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="background: url(../images/list-title-bg.png) repeat-x;">
            <tr>
                <td class="sousuo">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="20%" height="36">
                                <span style="font-weight: bold; margin-left: 10px;">经营管理 <span style="font-family: SimSun">
                                    >> </span>统计报表 </span>
                            </td>
                            <td align="right">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="20">
                                            <img src="../images/application_form_add.png" alt="打印" />
                                        </td>
                                        <td width="36">
                                            <span onclick="window.print()" style="cursor: pointer;">打印</span>
                                        </td>
                                        <td width="20">
                                            <img src="../images/application_form_add.png" alt="筛选" />
                                        </td>
                                        <td width="36">
                                            <span onclick="search()" style="cursor: pointer;">筛选</span>
                                        </td>
                                        <td width="20" style="cursor: pointer">
                                            <img src="../images/refresh-icon.png" alt="刷新" />
                                        </td>
                                        <td width="36" style="cursor: pointer" onclick="location.reload()">
                                            刷新
                                        </td>
                                        <td width="147">
                                            <input runat="server" type="text" style="color: #ccc; height: 20px; width: 145px;
                                                border: 1px solid #8a8a8a; line-height: 20px; font-size: 12px" value="项目名称" onfocus="this.value=''"
                                                id="keywords" name="keywords" />
                                        </td>
                                        <td width="48">
                                            <a style="display: block; width: 40px; padding: 2px 0; background: #93bc12; border: 1px solid #7b9e0d;
                                                color: #fff; text-align: center; cursor: pointer" onclick="scan('ProjectName',keywords.value)">
                                                搜索</a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div id="maindiv" onscroll="mymove()">
        <table width="100%" border="0" cellpadding="0" cellspacing="1" style="background: #f0f0f0">
            <tr>
                <td colspan="5" height="28">
                </td>
            </tr>
            <tr id="titlediv" class="td1" style="position: absolute">
                <td align="center">
                    项目信息
                </td>
                <td align="center">
                    合同信息
                </td>
                <td align="center">
                    收费信息
                </td>
                <td align="center">
                    外包信息
                </td>
            </tr>
            <script type="text/javascript">
                function mymove() {
                    var isIE = !!window.ActiveXObject;
                    var isIE6 = isIE && !window.XMLHttpRequest;
                    var titlediv = document.getElementById("titlediv");
                    var maindiv = document.getElementById("maindiv");
                    if (isIE6) {
                        titlediv.style.top = maindiv.scrollTop;
                    }
                    else {
                        titlediv.style.top = maindiv.scrollTop;
                    }
                }
                mymove();
            </script>
            <asp:Repeater ID="ProjectList" runat="server" OnItemDataBound="ProjectList_ItemDataBound">
                <ItemTemplate>
                    <tr class="tr1">
                        <td>
                            <b>
                                <%#Eval("ProjectName") %></b><br>
                            <%#Eval("ProjectNo") %><br>
                            <%#Eval("ProjectTypes")%><br>
                            <%#Eval("ProjectLevel")%><br>
                            <%#Eval("ProjectManager")%>
                        </td>
                        <td style="text-align: left">
                            <%#Eval("PC_Name") %><br>
                            金额：<%#Eval("PC_Price") %><br>
                            付款方式：<%#Eval("PC_FeeType") %><br>
                            状态：<%#Eval("Status") %>
                        </td>
                        <td style="text-align: left">
                            <asp:Repeater ID="ContractPay" runat="server">
                                <ItemTemplate>
                                    第<%#Eval("PCP_MoneyTime") %>次 -
                                    <%#Eval("pcp_money") %>元 -
                                    <%//Convert.ToDateTime(Eval("pcp_moneytime")).ToString("yyyy-MM-dd")%>
                                    -
                                    <%#Eval("Status") %><br>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                        <td style="text-align: left">
                            <asp:Repeater ID="Outer" runat="server">
                                <ItemTemplate>
                                    <%#Eval("PO_Name")%>
                                    -
                                    <%#Eval("PO_Price") %>元 -
                                    <%#Convert.ToDateTime(Eval("PO_StartTime")).ToString("yyyy-MM-dd")%>
                                    -
                                    <%#Eval("Status") %><br>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div class="noprint">
        <webdiyer:AspNetPager ID="AspNetPager1" UrlPaging="true" runat="server" ShowFirstLast="true"
            LayoutType="Div" CssClass="pager" PageIndexBoxClass="PageSelect" CurrentPageButtonClass="PageSel"
            OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
        <div class="btmdo">
        </div>
    </div>
    </form>
</body>
</html>
