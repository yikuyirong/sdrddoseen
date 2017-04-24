<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBack.aspx.cs" Inherits="Web.views.databack" %>
<%@ Register src="../inc/wintop.ascx" tagname="wintop" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>数据备份</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" runat="server">
    <br />
    <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="400" align="center" style="line-height: 24px">
        <tr>
            <td align=center>数据库备份本件将保存在服务器上，如需还原请与数据管理员联络！</td>
        </tr>
        <tr>
            <td height="60" align="center">
                <input runat="server" type="submit" class="aler-btn" value="确定备份" onserverclick="Button1_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input runat="server" name="" type="button" class="aler-btn" onclick="window.external.close()"
                    value="关闭窗口" />
            </td>
        </tr>
    </table>
    <br />
    </form>
</body>
</html>
