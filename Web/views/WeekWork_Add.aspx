<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeekWork_Add.aspx.cs" Inherits="Web.views.WeekWork_Add" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>添加工作计划</title>
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
    <script>
        KindEditor.ready(function (K) {
            var editor1 = K.create('#I_Content', {
                cssPath: '/kindeditor/plugins/code/prettify.css',
                uploadJson: '/kindeditor/asp.net/upload_json.ashx',
                fileManagerJson: '/kindeditor/asp.net/file_manager_json.ashx',
                allowFileManager: true,
                filterMode: false,
                afterBlur: function () { this.sync(); },
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });
    </script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br>
    <asp:ScriptManager ID="ScriptManager1"  runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="800" align="center"
                style="line-height: 24px">
                <tr>
                    <td class="tdbg" width="120" align="right">
                        分 类：
                    </td>
                    <td class="tdbg">
                        <asp:DropDownList ID="ClassID" runat="server" class="select" check="必,空,0,20">
                        </asp:DropDownList>
                </tr>
                <tr class="tdbg">
                    <td align="right">
                        标 题：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="I_Title" class="input2" check="必,空,0,20"></asp:TextBox>
                    </td>
                </tr>
                <tr class="tdbg" style="display: none">
                    <td align="right">
                        关键词：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="I_Keyword" class="input2" check="选,空,0,20"></asp:TextBox>
                    </td>
                </tr>
                <tr class="tdbg" style="display: none">
                    <td align="right">
                        图 片：
                    </td>
                    <td>
                        <asp:FileUpload ID="I_Pic" runat="server" class="input2" check="选,空,0,500" />
                    </td>
                </tr>
                <tr class="tdbg" style="display: none">
                    <td align="right">
                        缩略图：
                    </td>
                    <td>
                        <asp:TextBox ID="PicWidth" class="input2" Style="width: 40px" check="选,数,1,4" runat="server"></asp:TextBox>*<asp:TextBox
                            ID="PicHeight" class="input2" Style="width: 40px" check="选,数,1,4" runat="server"></asp:TextBox><span>
                                宽*高 (默认为空不生成缩略图)</span>
                    </td>
                </tr>
                <tr class="tdbg" style="display: none">
                    <td align="right">
                        附 件：
                    </td>
                    <td>
                        <asp:FileUpload ID="I_File" runat="server" class="input2" check="选,空,0,500" />
                    </td>
                </tr>
                <tr class="tdbg" style="display: none">
                    <td align="right">
                        排 序：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="OrderNum" Text="0" class="input2" check="必,数,0,20"></asp:TextBox>
                    </td>
                </tr>
                <tr class="tdbg" style="display: none">
                    <td align="right">
                        状 态：
                    </td>
                    <td>
                        <asp:CheckBoxList ID="Status" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True">普通</asp:ListItem>
                            <asp:ListItem>重要</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr class="tdbg">
                    <td align="right">
                        日 期：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="AddDate" class="input2" check="必,空,0,50" onclick="calendar.setHook(this)"></asp:TextBox>
                    </td>
                </tr>
                <tr class="tdbg" style="display: none">
                    <td align="right">
                        概 述：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="I_Description" class="input2" check="选,空,0,200"></asp:TextBox>
                    </td>
                </tr>
                <tr class="tdbg">
                    <td align="right">
                        内 容：
                    </td>
                    <td>
                        <textarea id="I_Content" style="width: 100%; height: 200px; visibility: hidden;"
                            runat="server"></textarea>
                    </td>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <br />
    </form>
</body>
</html>
