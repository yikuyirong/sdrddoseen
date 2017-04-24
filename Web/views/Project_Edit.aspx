<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Project_Edit.aspx.cs" Inherits="Web.views.Project_Edit" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看项目</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <script src="../js/Calendar.js" type="text/javascript"></script>
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
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="440" align="center">
                <tr>
                    <td align="right">
                        项目类别：
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ProjectTypes" CssClass="select" check="必,空,0,100">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        管理级别：
                    </td>
                    <td>
                        <asp:DropDownList ID="ProjectLevel" runat="server" CssClass="select" check="必,空,0,100">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="140" align="right">
                        项目名称：
                    </td>
                    <td width="280">
                        <input class="input" id="ProjectName" type="text" runat="server" check="必,空,0,100"
                            size="22" />
                    </td>
                </tr>
                <tr>
                    <td width="140" align="right">
                        项目编号：
                    </td>
                    <td width="280">
                        <input class="input" id="ProjectNo" type="text" runat="server" check="必,空,0,100"
                            size="22" />
                    </td>
                </tr>
                <tr>
                    <td width="140" align="right">
                        项目规模：
                    </td>
                    <td width="280">
                        <asp:RadioButtonList ID="ProjectMW" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Text="25MW" Value="25MW"></asp:ListItem>
                            <asp:ListItem Text="50MW" Value="50MW"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        经理：
                    </td>
                    <td>
                        <asp:DropDownList Visible="false" ID="Depart" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Depart_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ProjectManager" runat="server" check="必,空,0,100" AutoPostBack="true">
                        </asp:DropDownList>
                    </td> 
                </tr>
                <tr>
                    <td align="right">
                        客户名称：
                    </td>
                    <td>
                        <input class="input" id="ProjectCustom" type="text" runat="server" check="必,空,0,100"
                            size="22" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        客户联系人：
                    </td>
                    <td>
                        <input class="input1" id="ProjectCustomContact" type="text" runat="server" check="必,空,0,100"
                            size="22" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        客户联系电话：
                    </td>
                    <td>
                        <input class="input1" id="ProjectCustomPhone" type="text" runat="server" check="必,空,0,100"
                            size="22" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        项目地区：
                    </td>
                    <td>
                        <input class="input1" type="text" id="ProjectCity" runat="server" check="必,空,0,100"
                            size="22" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        项目简介：
                    </td>
                    <td>
                        <textarea class="area" cols="35" id="ProjectInfo" runat="server" rows="5" name="k_content"
                            check="必,空,0,200"></textarea>
                    </td>
                </tr>
                <tr>
                    <td height="60" align="center" colspan="2">
                        <input id="btn_submit" type="button" class="aler-btn" runat="server" value="确定提交"
                            onclick="if(checkform(document.forms[0]))" onserverclick="btn_submit_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="button" class="aler-btn" onclick="window.external.close()" value="关闭窗口" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    </form>
</body>
</html>
