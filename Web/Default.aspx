<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="css/login.css" />
    <script type="text/javascript" src="js/jquery-1.11.0.js"></script>
    <script src="js/public.js" type="text/javascript"></script>
    <title>山东省热电设计院</title>
</head>
<body style="margin:0px">
    <form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1"  runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<center>
    <div class="login-box" style="height: 100px">
        <div class="login-top">
            <span style="width: 80%; float: left;"></span><span class="login-bx" onclick="window.external.close()"
                title="关闭"></span><span class="login-gb" onclick="window.external.min()" title="最小化">
                </span>
        </div>
        <div class="login-login">
            <p style="margin-left: 65px; width: 365px;">
                <span>用户名：</span><input style="width: 220px; height: 42px; line-height: 35px" type="text"
                    id="UserName" runat="server"/></p>
            <p style="margin-left: 65px; width: 365px">
                <span>密&nbsp;&nbsp;码：</span><asp:TextBox ID="UserPwd" TextMode="Password" runat="server" style="width: 220px; height: 42px;line-height: 35px"></asp:TextBox></p>
            <div class="login-chk" style="margin-left: 112px;padding-top:5px">
                <div class="login-jm">
                    <input id="ckPwd" type="checkbox" value="记住密码" runat="server" />记住密码</div>
                <div class="login-zd">
                    <input id="autologin" name="autologin" type="checkbox" value="自动登陆" />自动登陆</div>
            </div>
            <div class="login-btn" style="margin-left: 46px;margin-top:5px">
            <asp:Button ID="Button1" runat="server" style="width: 241px"  Text="登陆" onclick="Unnamed1_Click" EnableViewState="False"/></asp>
            </div>
        </div>
    </div>
</center>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
