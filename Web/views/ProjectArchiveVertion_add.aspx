<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectArchiveVertion_Add.aspx.cs"
    Inherits="Web.views.ProjectArchiveVertion_add" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增版本管理</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" target="_hidden" runat="server">
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="400" align="center"
                style="line-height: 24px">
                <tr>
                    <td width="120" align="right">
                        项目名称：
                    </td>
                    <td width="280">
                        <input runat="server" type="text" class="input1" check="必,电,8,40" size="22" />
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        档案名称：
                    </td>
                    <td width="280">
                        <input runat="server" type="text" class="input1" check="必,电,8,40" size="22" />
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        新版附件：
                    </td>
                    <td width="280">
                        <input runat="server" type="file" name="file" check="必,电,8,40" class="file" size="22" />
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        新版概述：
                    </td>
                    <td width="280">
                        <input runat="server" type="text" class="input1" check="必,电,8,40" size="22" />
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
