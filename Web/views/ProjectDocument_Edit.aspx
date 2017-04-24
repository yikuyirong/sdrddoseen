<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectDocument_Edit.aspx.cs"
    Inherits="Web.views.ProjectDocument_Edit" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看网上提资</title>
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
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="450" align="center"
                style="line-height: 24px">
                <tr>
                    <td width="120" align="right">
                        选择项目：
                    </td>
                    <td width="330">
                        <asp:DropDownList ID="ProjectID" Enabled="false" runat="server" check="必,空,0,100">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        选择专业：
                    </td>
                    <td>
                        <asp:DropDownList ID="ClassName"  Enabled="false" runat="server" check="必,空,0,100">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        提资类型：
                    </td>
                    <td>
                        <asp:RadioButtonList ID="PD_Type" runat="server" check="必,空,0,100" 
                            RepeatDirection="Horizontal" AutoPostBack="true"
                            onselectedindexchanged="PD_Type_SelectedIndexChanged">
                            <asp:ListItem Text="新增提资" Value="新增提资"></asp:ListItem>
                            <asp:ListItem Selected="True" Text="问题修改" Value="问题修改"></asp:ListItem>
                            <asp:ListItem Text="问题重提" Value="问题重提"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr id="lishitizi" runat="server">
                    <td align="right">
                        历史提资：
                    </td>
                    <td>
                        <asp:DropDownList ID="ParentID" runat="server" check="必,空,0,100"  AutoPostBack="true"
                            onselectedindexchanged="ParentID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="120">
                        提资名称：
                    </td>
                    <td>
                        <input runat="server" type="text" id="PD_Name" check="必,空,0,100" size="22" class="input" />
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        提资文件：
                    </td>
                    <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file" />
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        版本编号：
                    </td>
                    <td>
                        <input runat="server" type="text" id="PD_FileNo" check="必,空,0,100" size="22" class="input" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        备注：
                    </td>
                    <td>
                        <textarea cols="35" rows="5" id="Remark" runat="server" class="area"></textarea>
                    </td>
                </tr>
                <tr class="none">
                    <td align="right">
                        状态：
                    </td>
                    <td>
                        <asp:RadioButtonList runat="server" ID="Status" RepeatDirection="Horizontal" check="必,空,0,100">
                            <asp:ListItem Value="提资主设审核" Text="提资主设审核" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="受资主设审核" Text="受资主设审核"></asp:ListItem>
                            <asp:ListItem Value="异议返回" Text="异议返回"></asp:ListItem>
                            <asp:ListItem Value="已审核" Text="已审核"></asp:ListItem>
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
    <br>
    </form>
</body>
</html>
