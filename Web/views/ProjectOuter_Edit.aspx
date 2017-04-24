<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectOuter_Edit.aspx.cs"
    Inherits="Web.views.ProjectOuter_Edit" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看<%=Server.UrlDecode(Title)%></title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/Calendar.js" type="text/javascript"></script>
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form method="post" runat="server" id="form1" onsubmit="return checkform(document.forms[0])">
    <br>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="400" align="center"
                style="line-height: 24px">
                <tr>
                    <td align="right">
                        合作时间：
                    </td>
                    <td>
                        <input id="PO_StartTime" type="text" runat="server" check="必,空,0,100" size="22" class="input1"
                            onclick="calendar.setHook(this)" />
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        要求完成时间：
                    </td>
                    <td>
                        <input id="PO_Time1" type="text" runat="server" check="必,空,0,100" size="22" class="input1"
                            onclick="calendar.setHook(this)" />
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        实际完成时间：
                    </td>
                    <td>
                        <input id="PO_Time2" type="text" runat="server" check="必,空,0,100" size="22" class="input1"
                            onclick="calendar.setHook(this)" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        对方联系人：
                    </td>
                    <td>
                        <input runat="server" type="text" id="PO_Link" check="必,空,0,100"  size="22" class="input1" />
                        <input runat="server" type="text" id="PO_LinkPhone" check="必,空,0,100"  size="22" class="input1" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        合同名称：
                    </td>
                    <td>
                        <input runat="server" type="text" id="PO_Name" check="必,空,0,100"  size="22" class="input1" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <%=Title%>内容：
                    </td>
                    <td>
                        <textarea cols="35" rows="5" id="PO_Content" runat="server" check="必,空,8,200" class="area"></textarea>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <%=Title%>合同：
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file" />*文件多请RAR
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        合同金额：
                    </td>
                    <td>
                        <input runat="server" type="text" id="PO_Price" check="必,空,0,100" size="22"
                            class="input1" />
                     </td>
                </tr>
                <tr>
                    <td align="right">
                        已付款金额：
                    </td>
                    <td>
                        <input runat="server" type="text" id="PO_PricePay" check="必,空,0,100" size="22"
                            class="input1" />
                     </td>
                </tr>
                <tr>
                    <td align="right">
                        已开票金额：
                    </td>
                    <td>
                        <input runat="server" type="text" id="PO_PriceBill" check="必,空,0,100" size="22"
                            class="input1" />
                     </td>
                </tr>
                <tr>
                    <td align="right">
                        付款方式：
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="PO_FeeType" runat="server" RepeatDirection="Horizontal"
                            check="必,空,0,80">
                            <asp:ListItem Selected=True Value="现金" Text="现金"></asp:ListItem>
                            <asp:ListItem Value="承兑" Text="承兑"></asp:ListItem>
                            <asp:ListItem Value="支票" Text="支票"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        备注：
                    </td>
                    <td>
                        <textarea cols="35" rows="5" id="Remark" runat="server" check="选,空,2,200" class="area"></textarea>
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
    <br>
    </form>
</body>
</html>
