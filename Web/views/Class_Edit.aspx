<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Class_Edit.aspx.cs" Inherits="Web.views.Class_Edit" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看分类</title>
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
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="400" align="center"
                style="line-height: 24px">
                <tr>
                    <td width="120" align="right">
                        分 类：
                    </td>
                    <td width="280">
                        <asp:DropDownList ID="ParentID" Width="200" runat="server" size="10" class="select" check="必,空,0,100">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        名 称：
                    </td>
                    <td width="280">
                        <asp:TextBox runat="server" ID="ClassName" class="input" check="必,空,0,500"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        排 序：
                    </td>
                    <td width="280">
                        <asp:TextBox runat="server" ID="OrderNum" Text="0" class="input" check="必,数,0,20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        状 态：
                    </td>
                    <td width="280">
                        <asp:TextBox runat="server" ID="Status" class="input" check="选,空,0,20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        备 注：
                    </td>
                    <td width="280">
                        <asp:TextBox runat="server" ID="Remark" class="input" check="选,空,0,200"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="60" align="center" colspan="2">
                        <input id="btn_submit" type="button" class="aler-btn" runat="server" value="确定提交"
                            onclick="if(checkform(document.forms[0]))" onserverclick="btn_submit_Click" />
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
