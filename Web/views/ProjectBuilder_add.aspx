<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectBuilder_Add.aspx.cs"
    Inherits="Web.views.ProjectBuilder_add" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增施工单位</title>
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
                        项目名称：
                    </td>
                    <td width="280">
                        <asp:DropDownList ID="ProjectID" runat="server" CssClass="select" check="必,空,0,100">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        单位名称：
                    </td>
                    <td>
                        <input runat="server" type="text" class="input1" check="必,空,0,100" size="22" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        施工合同：
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        联系人：
                    </td>
                    <td>
                        <input runat="server" type="text" class="input1" check="必,空,0,100" size="22" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        联系电话：
                    </td>
                    <td>
                        <input runat="server" type="text" class="input1" check="必,电,8,40" size="22" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        邮箱：
                    </td>
                    <td>
                        <input runat="server" type="text" class="input1" check="必,空,0,100" size="22" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        备注：
                    </td>
                    <td>
                        <input runat="server" type="text" class="input1" check="必,空,8,200" size="22" />
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
