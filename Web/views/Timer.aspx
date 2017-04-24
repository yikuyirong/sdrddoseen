<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Timer.aspx.cs" Inherits="Web.views.Timer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" Interval="10000" ontick="Timer1_Tick">
    </asp:Timer>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table width="100%" height="29" border="0" cellpadding="0" cellspacing="0" style="background: #02a1e8">
        <tr>
            <td style="text-align: right; padding-right: 10px; color: #fff">
                典讯软件-版权所有&copy;2014
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
