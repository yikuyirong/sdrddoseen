<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DesignVolume_Edit.aspx.cs"
    Inherits="Web.views.DesignVolume_Edit" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>修改卷册</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/Calendar.js" type="text/javascript"></script>
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <style type="text/css">
        .divScrollBar
        {
            background-color: #ddd;
            position: absolute;
            opacity: 0.5;
            filter: Alpha(opacity=50);
        }
        .divScrollBar:hover
        {
            opacity: 1;
            filter: Alpha(opacity=100);
        }
        .divScrollBar div
        {
            background-color: #333;
            position: absolute;
            left: 0px;
            top: 0px;
        }
        .inputx
        {
            width: 30px;
        }
        .inputy
        {
            width: 50px;
        }
        input
        {
            width: 65px;
        }
    </style>
    <script type="text/javascript" src="../js/jsScroll.js"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="False">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="400" align="center"
                style="line-height: 24px">
                <tr>
                    <td width="110" align="right">
                        专业：
                    </td>
                    <td>
                        <asp:TextBox CssClass="input" Enabled="false" ID="ClassName1" ReadOnly="true" check="必,空,0,100" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        卷册：
                    </td>
                    <td>
                        <asp:TextBox CssClass="input" Enabled="false" ID="ClassName2" ReadOnly="true" check="必,空,0,100" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        序号：
                    </td>
                    <td>
                        <asp:TextBox CssClass="input" ID="VolumeNo" check="必,空,0,100" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        卷册名称：
                    </td>
                    <td>
                        <asp:TextBox CssClass="input" ID="ClassName3" check="必,空,0,100" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        25MW工日：
                    </td>
                    <td>
                        <asp:TextBox CssClass="input" ID="Volume25MW" check="必,数,0,100" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        50MW工日：
                    </td>
                    <td>
                        <asp:TextBox CssClass="input" ID="Volume50MW" check="必,数,0,100" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        卷册级别：
                    </td>
                    <td>
                        <asp:DropDownList ID="VolumeLevel" runat="server">
                            <asp:ListItem>一级</asp:ListItem>
                            <asp:ListItem>二级</asp:ListItem>
                            <asp:ListItem>三级</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        备注：
                    </td>
                    <td>
                        <asp:TextBox ID="Remark" CssClass="input" check="选,空,0,100" runat="server"></asp:TextBox>
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
    <br />
    </form>
</body>
</html>
