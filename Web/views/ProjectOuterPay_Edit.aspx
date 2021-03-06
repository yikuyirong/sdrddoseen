<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectOuterPay_Edit.aspx.cs"
    Inherits="Web.views.ProjectOuterPay_Edit" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看收费</title>
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
                    <td align="right">
                        项目合同：
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ContractID" check="必,空,0,100" AutoPostBack="true"
                            Enabled="false">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        付款次数：
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="POP_Num" Enabled="false" check="必,空,0,100">
                            <asp:ListItem Value="1" Selected="True" Text="1"></asp:ListItem>
                            <asp:ListItem Value="2" Text="2"></asp:ListItem>
                            <asp:ListItem Value="3" Text="3"></asp:ListItem>
                            <asp:ListItem Value="4" Text="4"></asp:ListItem>
                            <asp:ListItem Value="5" Text="5"></asp:ListItem>
                            <asp:ListItem Value="6" Text="6"></asp:ListItem>
                            <asp:ListItem Value="7" Text="7"></asp:ListItem>
                            <asp:ListItem Value="8" Text="8"></asp:ListItem>
                            <asp:ListItem Value="9" Text="9"></asp:ListItem>
                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        应付节点：
                    </td>
                    <td>
                        <input readonly="readonly" type="text" id="POP_MoneyTime" runat="server" check="必,空,0,100"
                            size="22" class="input1" onclick="calendar.setHook(this)" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        应付款项：
                    </td>
                    <td>
                        <input type="text" id="POP_Money" value="0" runat="server" check="必,数,0,100" size="22"
                            class="input1" />
                    </td>
                </tr>
              <%--  <tr>
                    <td align="right">
                        实付款项：
                    </td>
                    <td>
                        <input type="text" runat="server" value="0" id="POP_Price" check="必,数,0,100" size="22"
                            class="input1" />
                    </td>
                </tr>--%>
                <tr>
                    <td align="right">
                        付款状态：
                    </td>
                    <td>
                        <asp:RadioButtonList ID="Status" runat="server" RepeatDirection="Horizontal" check="必,空,0,100">
                            <asp:ListItem Selected="True" Text="未付" Value="未付"></asp:ListItem>
                            <asp:ListItem Text="已付未票" Value="已付未票"></asp:ListItem>
                            <asp:ListItem Text="已付已票" Value="已付已票"></asp:ListItem>
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
