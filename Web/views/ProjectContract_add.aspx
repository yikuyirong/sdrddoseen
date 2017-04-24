<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectContract_Add.aspx.cs"
    Inherits="Web.views.ProjectContract_add" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增合同</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form runat="server" id="form1">
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="False">
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
                        <asp:DropDownList ID="ProjectTypes" runat="server" check="必,空,0,100" AutoPostBack="true"
                            OnSelectedIndexChanged="ProjectTypes_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ProjectID" runat="server" AutoPostBack="true" check="必,空,0,100"
                            OnSelectedIndexChanged="ProjectID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        合同编号：
                    </td>
                    <td>
                        <input id="ProjectNo" class="input" type="text" runat="server" check="必,空,0,100" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        合同附件：
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file" check="必,空,0,100" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        合同金额：
                    </td>
                    <td>
                        <input id="PC_Price" class="input1" type="text" value="0" runat="server" check="必,数,0,100" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        已收款金额：
                    </td>
                    <td>
                        <input id="PC_MoneyReceive" class="input1" type="text" value="0" runat="server" check="必,数,0,100" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        已开票金额：
                    </td>
                    <td>
                        <input id="PC_MoneyBill" class="input1" type="text" value="0" runat="server" check="必,数,0,100" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        付款方式：
                    </td>
                    <td>
                        <asp:RadioButtonList runat="server" ID="PC_FeeType" RepeatDirection="Horizontal"
                            check="必,空,0,100">
                            <asp:ListItem Value="现金" Text="现金 "></asp:ListItem>
                            <asp:ListItem Value="转账" Text="转账 "></asp:ListItem>
                            <asp:ListItem Value="支票" Text="支票 "></asp:ListItem>
                            <asp:ListItem Value="混用" Text="混用 " Selected="True"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td height="60" align="center" colspan="2">
                        <input id="btn_submit" type="button" class="aler-btn" runat="server" value="确定提交"
                            onclick="if(checkform(document.forms[0]))" onserverclick="btn_submit_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input name="" type="button" class="aler-btn" onclick="window.external.close()" value="关闭窗口" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    </form>
</body>
</html>
