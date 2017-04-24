<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectBid_Add.aspx.cs"
    Inherits="Web.views.ProjectBid_add" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增客户</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br>
            <table border="0" cellspacing="0" cellpadding="5" width="400" align="center" style="line-height: 24px">
               <tr class="none">
                    <td width="120" align="right">
                        项目名称：
                    </td>
                    <td width="280">
                        <asp:DropDownList ID="ProjectTypes" runat="server" check="必,空,0,100" AutoPostBack="true" OnSelectedIndexChanged="ProjectTypes_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ProjectID" runat="server" AutoPostBack="true"  check="必,空,0,100"
                            onselectedindexchanged="ProjectID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        客户项目：
                    </td>
                    <td>
                        <asp:TextBox ID="PB_Name" runat="server" CssClass="input" check="必,空,0,100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        客户内容：
                    </td>
                    <td>
                        <textarea  id="PB_Info" runat="server"  class="area" check="选,空,0,200"></textarea>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        客户状态：
                    </td>
                    <td>
                        <asp:RadioButtonList runat="server" ID="Stauts" RepeatDirection="Horizontal" check="选,空,0,40">
                            <asp:ListItem Value="意向客户" Selected=True Text="意向客户"></asp:ListItem>
                            <asp:ListItem Value="中标" Text="中标" ></asp:ListItem>
                            <asp:ListItem Value="未中标" Text="未中标"></asp:ListItem>                            
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        备注信息：
                    </td>
                    <td>
                        <textarea  id="Remark" runat="server"  class="area" check="选,空,0,200"></textarea>
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
