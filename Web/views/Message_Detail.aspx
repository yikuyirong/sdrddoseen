<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message_Detail.aspx.cs" Inherits="Web.views.Message_Detail" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=6" />
    <title >消息详情</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery-1.11.0.js"></script>
    <script src="../js/public.js" type="text/javascript"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <table width="600" height="400" style="background-color:White" border="0" cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td valign="top">
                <p>&nbsp;</p>             
                <br />
                <p style="text-align:center;font-size:18px"><%=MessageInfo%></p>
                    <p style="text-align:center;font-size:12px">来自：<%=UserNameFrom%>&emsp;&emsp;<%=AddDate%></p><br />
                     <p style="text-align:center" class="<%=MessageFile==""?"none":""%>">附件：<a target="_blank" href="<%=MessageFile%>" >查看</a> </p>
            </td>
        </tr>
    </table>
</body>
</html>
