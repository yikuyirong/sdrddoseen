<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectBuyContract_Add.aspx.cs"
    Inherits="Web.views.ProjectBuyContract_add" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增合同管理</title>
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
            <br>
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="400" align="center"
                style="line-height: 24px">
                <tr>
                    <td width="120" align="right">
                        项目编号：
                    </td>
                    <td width="280">
                        <asp:DropDownList ID="ProjectID" runat="server" CssClass="select" check="必,空,0,100">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        供应单位：
                    </td>
                    <td>
                        <asp:DropDownList ID="POC_Name" runat="server" CssClass="select" check="必,空,0,100">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        合同附件：
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        合同费用：
                    </td>
                    <td>
                        <input id="PBC_Price" runat="server" type="text" value="0" check="必,空,0,100" size="22"
                            class="input1" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        付款方式：
                    </td>
                    <td>
                        <asp:RadioButtonList ID="PO_FeeType" runat="server" RepeatDirection="Horizontal"
                            check="必,空,0,100">
                            <asp:ListItem Value="现金" Text="现金"></asp:ListItem>
                            <asp:ListItem Value="转账" Text="转账"></asp:ListItem>
                            <asp:ListItem Value="支票" Text="支票"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        状态：
                    </td>
                    <td>
                        <asp:RadioButtonList runat="server" ID="Stauts" RepeatDirection="Horizontal">
                            <asp:ListItem Value="未付" Text="未付" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="已付" Text="已付"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td height="60" align="center" colspan="2">
                        <input id="btn_submit" type="button" class="aler-btn" runat="server" value="确定提交"
                            onclick="if(checkform(document.forms[0]))" onclick="btn_submit_Click1" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input id="Button1" runat="server" name="" type="button" class="aler-btn" onclick="window.external.close()"
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
