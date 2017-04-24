<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanManage_Add.aspx.cs" Inherits="Web.views.PlanManage_Add" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>进度管理表</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/kindeditor/themes/default/default.css" />
    <link rel="stylesheet" href="/kindeditor/plugins/code/prettify.css" />
    <script charset="utf-8" src="/kindeditor/kindeditor.js"></script>
    <script charset="utf-8" src="/kindeditor/lang/zh_CN.js"></script>
    <script charset="utf-8" src="/kindeditor/plugins/code/prettify.js"></script>
    <script src="../js/Calendar.js" type="text/javascript"></script>
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            var editor1 = K.create('#PlanContent', {
                cssPath: '/kindeditor/plugins/code/prettify.css',
                uploadJson: '/kindeditor/asp.net/upload_json.ashx',
                fileManagerJson: '/kindeditor/asp.net/file_manager_json.ashx',
                allowFileManager: true,
                designMode: true,
                afterBlur: function () { this.sync(); },
                afterCreate: function () { }
            });
            prettyPrint();
        });
    </script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br>
            <br />
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="1000" align="center"
                style="line-height: 24px">
            <tr>
                <td class="tdbg">计划月份：<asp:TextBox ID="PlanDate" runat="server"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" class="aler-btn" onclick="Button2_Click" style="margin-left:50px" Text="上月数据" />
                    <input id="btn_submit" type="button" class="aler-btn" runat="server" value="确定提交"
                            onclick="if(checkform(document.forms[0]))" onserverclick="btnSave_Click" style="margin-left:50px" /></td>
            </tr>
			<tr>
                <td class="tdbg"><asp:TextBox ID="PlanContent" runat="server" Width="300%" Height="500"></asp:TextBox></td>
            </tr>
            </table>
    <br />
    <br />
    <br />
    </form>
</body>
</html>
