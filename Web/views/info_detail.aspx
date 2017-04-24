<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info_Detail.aspx.cs" Inherits="Web.views.info_detail" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=6" />
    <title>信息详情</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery-1.11.0.js"></script>
    <script src="../js/public.js" type="text/javascript"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <table width="600" height="400" style="background-color: White" border="0" cellpadding="0"
        cellspacing="0" align="center">
        <tr>
            <td valign="top">
                <p>
                    &nbsp;</p>
                <center>
                    <asp:Button ID="btn_tg" class="aler-btn" runat="server" Text="审核通过" OnClick="btn_tg_Click" />
                    &nbsp; &nbsp;
                    <asp:Button ID="btn_btg" class="aler-btn" runat="server" Text="审核不通过" OnClick="btn_btg_Click" />&nbsp;
                    &nbsp;
                    <asp:Button ID="btn_fb" class="aler-btn" runat="server" Text="信息发布" OnClick="btn_fb_Click" /></center>
                <p align="center" style="line-height: 18px;font-size:14px;">
                    <strong>
                        <%=I_Title%></strong><br>
                    <%=AddDate%><br />
                </p>
                <div style="padding:0 18px;font-size:13px;line-height:20px;height:600px;overflow-y:scroll"><%=I_Content%>
                <br />
                <p align="left" style="line-height: 20px; padding: 10px" class="<%=I_File==""?"none":""%>">
                    附件：<span class="underline" onclick="window.external.download('<%=I_File%>','<%=I_File%>',true)">查看</span>
                </p></div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>