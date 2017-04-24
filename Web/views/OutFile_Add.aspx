﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OutFile_Add.aspx.cs" Inherits="Web.views.OutFile_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>添加外来资料</title>
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
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br>
            <br />
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="470" align="center"
                style="line-height: 24px">
                <tr>
                <td class="tdbg" width="120" align="right">所属项目： </td>
                <td class="tdbg"><asp:DropDownList runat='server' ID='ProjectID' class='select' check='必,空,0,100'></asp:DropDownList></td>
            </tr>
			<tr>
                <td class="tdbg" width="120" align="right">所属专业： </td>
                <td class="tdbg"><asp:DropDownList runat='server' ID='ClassName' class='select' check='必,空,0,100'></asp:DropDownList></td>
            </tr>
			<tr>
                <td class="tdbg" width="120" align="right">资料名称： </td>
                <td class="tdbg"><asp:TextBox runat='server' ID='FileName' class='input' check='必,空,0,150' ></asp:TextBox></td>
            </tr>
			<tr>
                <td class="tdbg" width="120" align="right">资料附件： </td>
                <td class="tdbg"><asp:FileUpload runat='server' ID='FileUrl' class='input' check='必,空,0,100' /></td>
            </tr>
			<tr>
                <td class="tdbg" width="120" align="right">资料概述： </td>
                <td class="tdbg"><asp:TextBox runat='server' ID='FileInfo' class='input' check='必,空,0,200' TextMode='MultiLine' Width='300px' Height='100px'></asp:TextBox></td>
            </tr>
                <tr class="tdbg">
                    <td height="60" align="center" colspan="2">
                        <input id="btn_submit" type="button" class="aler-btn" runat="server" value="确定提交"
                            onclick="if(checkform(document.forms[0]))" onserverclick="btnSave_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input name="" type="button" class="aler-btn" onclick="window.external.close()" value="关闭窗口" />
                    </td>
                </tr>
            </table>
    <br />
    <br />
    <br />
    </form>
</body>
</html>
