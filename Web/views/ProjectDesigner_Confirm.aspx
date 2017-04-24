<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectDesigner_Confirm.aspx.cs"
    Inherits="Web.views.ProjectDesigner_Confirm" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>主设人员信息</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <script src="../js/Calendar.js" type="text/javascript"></script>
    <style type="text/css">
        .divScrollBar
        {
            background-color: #ddd;
            position: absolute;
            opacity: 0.5;
            filter: Alpha(opacity=50);
        }
        .divScrollBar:hover
        {
            opacity: 1;
            filter: Alpha(opacity=100);
        }
        .divScrollBar div
        {
            background-color: #333;
            position: absolute;
            left: 0px;
            top: 0px;
        }
    </style>
    <script type="text/javascript" src="../js/jsScroll.js"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br>
    <br>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" align="center" style="line-height: 24px;">
                <tr>
                    <td align="right" class="style6">
                        项目名称：
                    </td>
                    <td>
                        <input class="input1" runat="server" id="ProjectName" readonly="readonly" type="text"
                            check="必,空,0,100" size="22" style="border: 1px solid #CCCCCC;width:200px" />
                    </td>
                    <td style="text-align: right">
                        项目编号：
                    </td>
                    <td class="style4">
                        <input class="input1" runat="server" id="ProjectNo" readonly="readonly" type="text"
                            check="必,空,0,100" size="22" style="border: 1px solid #CCCCCC;" />
                    </td>
                </tr>
            </table>
            <div id="div1" style="width: 500px; overflow-y:scroll ;overflow-x:hidden ; height: 400px; border: solid 1px gray;">
                <table width="100%" border="0" cellpadding="0" cellspacing="1" style="background: #f0f0f0">
                    <tr id="titlediv" class="td1">
                        <td align="center">
                            专业
                        </td>
                        <td align="center">
                            主设
                        </td>
                        <td align="center">
                            级别
                        </td>
                        <td align="center">
                            状态
                        </td>
                    </tr>
                    <asp:Repeater ID="TaskList" runat="server">
                        <ItemTemplate>
                            <tr class="tr1">
                                <td style="padding: 3px 0" align="center" height="25">
                                    <%#Eval("ClassName")%>
                                </td>
                                <td align="center">
                                    <%#Eval("UserName")%>
                                </td>
                                <td>
                                    <%#Eval("DesignerType")%>
                                </td>
                                <td>
                                    <%#CheckMainDesigner(Eval("ClassName").ToString()) ? "未录入卷册" : "正常"%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <table id="Table1" runat="server" border="0" cellspacing="0" cellpadding="5" align="center" style="line-height: 24px;">
                <tr>
                    <td style="padding-top:20px">
                        <input id="btn_submit" type="button" class="aler-btn" runat="server" value="同意" onserverclick="btn_submit1_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_submit2" runat="server" CssClass="aler-btn" Text="不同意" OnClick="btn_submit2_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    </form>
    <script type="text/javascript">
        //jsScroll(document.getElementById('div1'), 10, 'divScrollBar');
    </script>
</body>
</html>
