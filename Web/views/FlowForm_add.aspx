<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowForm_Add.aspx.cs" Inherits="Web.views.FlowForm_add"
    ValidateRequest="false" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>表单管理</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/kindeditor/themes/default/default.css" />
    <link rel="stylesheet" href="/kindeditor/plugins/code/prettify.css" />
    <script charset="utf-8" src="/kindeditor/kindeditor.js"></script>
    <script charset="utf-8" src="/kindeditor/lang/zh_CN.js"></script>
    <script>
        // 自定义插件 #1
        KindEditor.lang({
            example1: '标准控件'
        });
        KindEditor.plugin('example1', function (K) {
            var self = this, name = 'example1';
            function click(value) {
                var cmd = self.cmd;
                cmd.wrap(value);
                //cmd.select();
                self.hideMenu();
            }
            self.clickToolbar(name, function () {
                var menu = self.createMenu({
                    name: name,
                    width: 130
                });
                menu.addItem({
                    title: '单行输入框',
                    click: function () {
                        click('<input class="formctrl" type="text" name="textfield" />');
                    }
                });
                menu.addItem({
                    title: '多行输入框',
                    click: function () {
                        click('<textarea class="formctrl" name="textarea"></textarea>');
                    }
                });
                menu.addItem({
                    title: '日期输入框',
                    click: function () {
                        click('<input class="formctrl" type="text" name="textfield" onclick="calendar.setHook(this)" style="background:url(/images/date.jpg) no-repeat right" />');
                    }
                });
                menu.addItem({
                    title: '单选框',
                    click: function () {
                        click('<input class="formctrl" type="radio" name="radiobutton" value="radiobutton" />');
                    }
                });
                menu.addItem({
                    title: '复选框',
                    click: function () {
                        click('<input class="formctrl" type="checkbox" name="checkbox" value="checkbox" />');
                    }
                });
                menu.addItem({
                    title: '按钮',
                    click: function () {
                        click('<input class="formctrl" type="Submit" name="Submit" value="提交" />');
                    }
                });
                menu.addItem({
                    title: '电子签名',
                    click: function () {
                        click('<input class="formctrl" type="button" name="button" value="电子签名" />');
                    }
                });
            });
        });
        KindEditor.ready(function (K) {
            K.create('#IF_Content', {
                cssPath: 'kindeditor/plugins/code/prettify.css',
                uploadJson: 'kindeditor/asp.net/upload_json.ashx',
                fileManagerJson: 'kindeditor/asp.net/file_manager_json.ashx',
                filterMode: false,
                afterBlur: function () { this.sync(); },
                allowFileManager: true,
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
                },
                items: ['source', '|', 'undo', 'redo', '|', 'cut', 'copy', 'paste',
		'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent', 'subscript',
		'superscript', 'clearhtml', 'quickformat', '/',
		'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
		'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image', 'table', 'wordpaste', 'hr', '|', 'example1']
            });
        });
    </script>
    <style>
        .ke-icon-example1
        {
            background-image: url(/images/ctrl1.jpg);
            width: 63px;
            height: 16px;
        }
        .ke-icon-example2
        {
            background-image: url(/images/ctrl2.jpg);
            width: 63px;
            height: 16px;
        }
        .ke-icon-example3
        {
            background-image: url(/images/ctrl3.jpg);
            width: 50px;
            height: 16px;
        }
    </style>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" align="center" style="line-height: 24px"
                width="820">
                <tr>
                    <td align="right">
                        表单类型：
                    </td>
                    <td>
                        <asp:RadioButtonList runat="server" ID="IF_Type" RepeatDirection="Horizontal" check="必,空,0,100">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td width="200" align="right">
                        表单名称：
                    </td>
                    <td>
                        <input runat="server" type="text" id="IF_Name" check="必,空,0,100" size="22" class="input" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        表单内容：
                    </td>
                    <td>
                        <textarea id="IF_Content" name="IF_Content" cols="100" rows="8" style="width: 700px; height: 400px;
                            visibility: hidden;" runat="server"></textarea>
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
    </form>
    <br />
    <br />
</body>
</html>
