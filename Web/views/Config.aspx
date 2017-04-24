<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Config.aspx.cs" Inherits="Web.views.Config" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<%@ OutputCache Location="None" VaryByParam="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>系统参数</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" runat="server" >
    <div id="div1" style="width: 520px; overflow: auto; height: 600px; border: solid 1px gray;">
    <br>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="False">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="500" align="center"
                style="line-height: 24px">
                <tr>
                    <td align="right">
                        项目图档审核管理人：
                    </td>
                    <td>
                        <asp:ListBox ID="C_Set1" runat="server" SelectionMode="Multiple" Width="150" Rows="4">
                        </asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        新闻公告审核管理人：
                    </td>
                    <td>
                        <asp:ListBox ID="C_Set2" runat="server" SelectionMode="Multiple" Width="150" Rows="4">
                        </asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        未读消息提醒间隔：
                    </td>
                    <td>
                        <asp:TextBox ID="C_Set3" runat="server" check="选,空,0,100" style="width:130px" CssClass="input"></asp:TextBox>秒
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        设定院长：
                    </td>
                    <td>
                        <asp:ListBox ID="C_Set4" runat="server" SelectionMode="Multiple" Width="150" Rows="4">
                        </asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        设定技术副院长：
                    </td>
                    <td>
                        <asp:ListBox ID="C_Set5" runat="server" SelectionMode="Multiple" Width="150" Rows="4">
                        </asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        预留6：
                    </td>
                    <td>
                        <asp:ListBox ID="C_Set6" runat="server" SelectionMode="Multiple" Width="150" Rows="4">
                        </asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        设计管理部经理：
                    </td>
                    <td>
                        <asp:ListBox ID="C_Set7" runat="server" SelectionMode="Multiple" Width="150" Rows="4">
                        </asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        预留8：
                    </td>
                    <td>
                        <asp:ListBox ID="C_Set8" runat="server" SelectionMode="Multiple" Width="150" Rows="4">
                        </asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        部门主管（目前用在新闻审核）：
                    </td>
                    <td>
                        <asp:ListBox ID="C_Set9" runat="server" SelectionMode="Multiple" Width="150" Rows="4">
                        </asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        部门经理（目前用在新闻审核）：
                    </td>
                    <td>
                        <asp:ListBox ID="C_Set10" runat="server" SelectionMode="Multiple" Width="150" Rows="4">
                        </asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        预留11：
                    </td>
                    <td>
                        <asp:TextBox ID="C_Set11" runat="server" check="选,空,0,100" style="width:130px" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        预留12：
                    </td>
                    <td>
                        <asp:TextBox ID="C_Set12" runat="server" check="选,空,0,100" style="width:130px" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        预留13：
                    </td>
                    <td>
                        <asp:TextBox ID="C_Set13" runat="server" check="选,空,0,100" style="width:130px" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        预留14：
                    </td>
                    <td>
                        <asp:TextBox ID="C_Set14" runat="server" check="选,空,0,100" style="width:130px" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        预留15：
                    </td>
                    <td>
                        <asp:TextBox ID="C_Set15" runat="server" check="选,空,0,100" style="width:130px" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="60" align="center" colspan="2">
                        <input id="btn_submit" type="button" class="aler-btn" runat="server" value="确定提交"
                            onclick="if(checkform(document.forms[0]))" onserverclick="btn_submit_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input id="Button1" runat="server" name="" type="button" class="aler-btn" onclick="window.external.close()"
                            value="关闭" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    </div>
    </form>
</body>
</html>
