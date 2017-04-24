<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DesignTask_Edit.aspx.cs"
    Inherits="Web.views.DesignTask_Edit" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>修改卷册任务</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/Calendar.js" type="text/javascript"></script>
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="False">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="400" align="center"
                style="line-height: 24px">
                <tr>
                    <td width="110" align="right">
                        序号：
                    </td>
                    <td>
                        <asp:TextBox CssClass="input" ID="DT_XuHao" check="必,空,0,100" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        图号：
                    </td>
                    <td>
                        <asp:TextBox CssClass="input" ID="DT_TuHao" check="必,空,0,100" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        卷册：
                    </td>
                    <td>
                        <asp:TextBox CssClass="input" ID="ClassName3" check="必,空,0,100" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        估工：
                    </td>
                    <td>
                        <asp:TextBox CssClass="input" ID="DT_GuGong" check="必,空,0,100" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        设计人：
                    </td>
                    <td>
                        <asp:DropDownList CssClass="select" ID="DT_SheJiRen" check="必,空,0,100" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        设计时间：
                    </td>
                    <td>
                        <asp:TextBox ID="DT_SheJiTime" CssClass="input" runat="server" check="必,空,0,100"
                            onclick="calendar.setHook(this)"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        校对人：
                    </td>
                    <td>
                        <asp:DropDownList CssClass="select" check="必,空,0,100" ID="DT_JiaoDuiRen" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        校对时间：
                    </td>
                    <td>
                        <asp:TextBox ID="DT_JiaoDuiTime" check="必,空,0,100" CssClass="input" runat="server"
                            onclick="calendar.setHook(this)"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        审核人：
                    </td>
                    <td>
                        <asp:DropDownList CssClass="select" check="必,空,0,100" ID="DT_ShenHeRen" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        审核时间：
                    </td>
                    <td>
                        <asp:TextBox ID="DT_ShenHeTime" CssClass="input" check="必,空,0,100" runat="server"
                            onclick="calendar.setHook(this)"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        审定人：
                    </td>
                    <td>
                        <asp:DropDownList CssClass="select" check="选,空,0,100" ID="DT_ShenDingRen" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        审定时间：
                    </td>
                    <td>
                        <asp:TextBox ID="DT_ShenDingTime" CssClass="input" check="选,空,0,100" runat="server"
                            onclick="calendar.setHook(this)"></asp:TextBox>
                    </td>
                </tr>
               <%-- <tr>
                    <td align="right">
                        核准人：
                    </td>
                    <td>
                        <asp:DropDownList CssClass="select" check="必,空,0,100" ID="DT_HeZhunRen" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        核准时间：
                    </td>
                    <td>
                        <asp:TextBox ID="DT_HeZhunTime" CssClass="input" check="选,空,0,100" runat="server"
                            onclick="calendar.setHook(this)"></asp:TextBox>
                    </td>
                </tr>--%>
                <tr>
                    <td align="right">
                        出版时间：
                    </td>
                    <td>
                        <asp:TextBox ID="DT_PublishTime" CssClass="input" check="选,空,0,100" runat="server"
                            onclick="calendar.setHook(this)"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        备注：
                    </td>
                    <td>
                        <asp:TextBox ID="Remark" CssClass="input" check="选,空,0,100" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="60" align="center" colspan="2">
                        <input id="btn_submit" type="button" class="aler-btn" runat="server" value="确定提交"
                            onclick="if(checkform(document.forms[0]))" onserverclick="btn_submit_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input id="Button1" runat="server" name="" type="button" class="aler-btn" onclick="window.external.close()"
                            value="关闭窗口" /><br><br><br><br><br><br><br>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    </form>
</body>
</html>
