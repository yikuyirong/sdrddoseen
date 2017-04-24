<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserName_Edit.aspx.cs" Inherits="Web.views.UserName_Edit" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑签名</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
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
                        用户名：
                    </td>
                    <td width="280">
                       <asp:TextBox ID="username" ReadOnly=true runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                  <tr>
                    <td width="120" align="right">
                        姓名：
                    </td>
                    <td width="280">
                       <asp:TextBox ID="u_name" ReadOnly=true runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        JPG签名：
                    </td>
                    <td width="280">
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file" />
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        CAD签名：
                    </td>
                    <td width="280">
                        <asp:FileUpload ID="FileUpload2" runat="server" CssClass="file" />
                    </td>
                </tr>
                <tr>
                    <td height="60" align="center" colspan="2">
                        <input id="btn_submit" type="button" class="aler-btn" runat="server" value="确定提交"
                            onclick="if(checkform(document.forms[0]))" onserverclick="btn_submit_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input runat="server" name="" type="button" class="aler-btn" onclick="window.external.close()"
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
