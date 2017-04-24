<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Project_Edit33.aspx.cs" Inherits="Web.views.Project_Edit3" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设总人员审批</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <script src="../js/Calendar.js" type="text/javascript"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br><br>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="440" align="center">
                <tr>
                    <td width="140" align="right">
                        项目名称：
                    </td>
                    <td width="280">
                        <input class="input" id="ProjectName" readonly="readonly" type="text" runat="server" size="22" />
                    </td>
                </tr>
                <tr>
                    <td width="140" align="right">
                        项目编号：
                    </td>
                    <td width="280">
                        <input class="input" id="ProjectNo" readonly="readonly" type="text" runat="server" size="22" />
                    </td>
                </tr>
                <tr>
                    <td width="140" align="right">
                        选择设总：
                    </td>
                    <td width="280">
                        <input class="input" id="UserNameTo" readonly="readonly" type="text" runat="server" size="22" />
                    </td>
                </tr>
                <tr>
                    <td height="60" align="center" colspan="2">
                        <input id="btn_submit" type="button" class="aler-btn" runat="server" value="同意" onserverclick="btn_submit_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_submit2" runat="server" CssClass="aler-btn" Text="不同意" OnClick="btn_submit2_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    </form>
</body>
</html>
