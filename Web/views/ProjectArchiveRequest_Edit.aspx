<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectArchiveRequest_Edit.aspx.cs"
    Inherits="Web.views.ProjectArchiveRequest_Edit" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看<%=Server.UrlDecode(Title)%></title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="400" align="center"
                style="line-height: 24px">
                <tr>
                    <td width="120" align="right">
                        申请类型：
                    </td>
                    <td width="280">
                        <asp:RadioButtonList ID="RequestType" runat="server" Enabled="false" RepeatDirection="Horizontal"
                            check="必,空,0,100">
                            <asp:ListItem Text="借阅申请" Value="借阅申请"></asp:ListItem>
                            <asp:ListItem Text="出版申请" Value="出版申请"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        选择项目：
                    </td>
                    <td width="280">
                        <asp:DropDownList ID="ProjectID" runat="server" Enabled="false" check="必,空,0,100">
                        </asp:DropDownList>
                    </td>
                </tr>
                <%-- <tr>
                    <td align="right">
                        选择专业：
                    </td>
                    <td>
                        <input type="text" runat="server" readonly=readonly id="ClassName2" check="必,空,0,100" size="22" class="input" />
                    </td>
                </tr>               
                <tr>
                    <td width="120" align="right">
                        选择卷册：
                    </td>
                    <td width="280">
                        <input type="text" runat="server"  readonly=readonly id="ProjectArchiveID" check="必,空,0,100" size="22" class="input" />
                    </td>
                </tr>--%>
                <tr>
                    <td align="right">
                        档案名称：
                    </td>
                    <td>
                        <asp:DropDownList ID="PA_Name" runat="server" Enabled="false" check="必,空,0,100">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        申请用途：
                    </td>
                    <td width="280">
                        <textarea class="area" cols="35" id="Remark" runat="server" rows="5" check="必,空,0,200"></textarea>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        状态：
                    </td>
                    <td width="280">
                        <asp:RadioButtonList ID="Status" runat="server" RepeatDirection="Horizontal" check="必,空,0,100">
                            <asp:ListItem Text="未审" Value="未审"></asp:ListItem>
                            <asp:ListItem Text="同意" Value="同意"></asp:ListItem>
                            <asp:ListItem Text="拒绝" Value="拒绝"></asp:ListItem>
                        </asp:RadioButtonList>
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
