<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Password.aspx.cs" Inherits="Web.views.Password" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>修改密码</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" runat="server">
    <br>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="False">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="400" align="center"
                style="line-height: 24px">
                  <tr>
                    <td width="120" align="right">
                        原始密码：
                    </td>
                    <td width="280">
                       <asp:TextBox TextMode="Password" ID="password" runat="server" check="必,空,6,20" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                  <tr>
                    <td width="120" align="right">
                        新密码：
                    </td>
                    <td width="280">
                       <asp:TextBox TextMode="Password" ID="newspass" runat="server" check="必,空,6,20" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                       确认密码：
                    </td>
                    <td width="280">
                       <asp:TextBox TextMode="Password" ID="newspass2" runat="server" check="必,空,6,20" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="60" align="center" colspan="2">
                        <input id="btn_submit" type="button" class="aler-btn" runat="server" value="确定提交"
                            onclick="if(checkform(document.forms[0]))" onserverclick="btn_submit_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input id="Button1" runat="server" name="" type="button" class="aler-btn" onclick="window.external.close()"
                            value="关闭窗口" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    </form>
</body>
</html>
