<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectBuilderContractPay_Add.aspx.cs"
    Inherits="Web.views.ProjectBuilderContractPay_add" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增施工收费</title>
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
                         <asp:DropDownList runat="server" ID="ProjectType" check="必,空,0,100" AutoPostBack="true" 
                            onselectedindexchanged="ProjectType_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList runat="server" ID="ProjectID" check="必,空,0,100"  AutoPostBack="true"
                            onselectedindexchanged="ProjectID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        施工合同：
                    </td>
                    <td>
                       <asp:DropDownList runat="server" ID="ContractID" check="必,空,0,100" AutoPostBack="true" onselectedindexchanged="ContractID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        付款次数：
                    </td>
                    <td>
                        <input readonly="readonly" type="text" value="1" id="PCP_Num" runat="server" check="必,数,0,100" size="22" class="input1" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        应付款项：
                    </td>
                    <td>
                        <input type="text" id="PCP_Money" value="0" runat="server" check="必,数,0,100" size="22" class="input1" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        实付款项：
                    </td>
                    <td>
                         <input type="text" runat="server" value="0" id="PCP_Price" check="必,数,0,100" size="22" class="input1" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        状态：
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
