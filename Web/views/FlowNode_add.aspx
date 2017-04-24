<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowNode_Add.aspx.cs" Inherits="Web.views.FlowNode_add" ValidateRequest="false" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>节点管理</title>
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
            example2: '高级控件'
        });
        KindEditor.plugin('example2', function (K) {
            var self = this, name = 'example2';
            self.clickToolbar(name, function () {
                var menu = self.createMenu({
                    name: name,
                    width: 130
                });
                menu.addItem({
                    title: '插入授权',
                    click: function () {
                        var cmd = self.cmd;
                        self.hideMenu()
                        var selectHtml = cmd.range.html();
                        if (selectHtml == "") {
                            alert("请选中需要授权的控件");
                            return;
                        };
                        if (selectHtml.indexOf("data-node") > 0) {
                            alert("该控件已经存在授权节点");
                        }
                        else {
                            selectHtml = selectHtml.replace(" ", " data-node='" + $("#NodeNo").val() + "' ");
                            self.insertHtml(selectHtml); ;
                            alert("授权操作成功");
                        }
                    }
                });
                menu.addItem({
                    title: '取消授权',
                    click: function () {
                        var cmd = self.cmd;
                        self.hideMenu();
                        var selectHtml = cmd.range.html();
                        if (selectHtml == "") {
                            alert("请选中需要授权的控件");
                            return;
                        };
                        if (selectHtml.indexOf("data-node") < 0) {
                            alert("该控件没有授权信息");
                        }
                        else {
                            selectHtml = selectHtml.replace(" data-node=", "data-del=");
                            self.insertHtml(selectHtml);
                            alert("取消授权操作成功");
                        }
                    }
                });
            });
        });
        KindEditor.ready(function (K) {
            K.create('#NodeFormArea', {
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
                items: ['source', '|', 'example2']
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
    <br />
            <table border="0" cellspacing="0" cellpadding="5" width="820" align="center" style="line-height: 24px">
                <tr>
                    <td width="120" align="right">
                        所属流程：
                    </td>
                    <td>
                        <asp:DropDownList ID="FlowID" runat="server" check="必,空,0,100" AutoPostBack="true"
                            OnSelectedIndexChanged="FlowID_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="FlowName" runat="server" check="必,空,0,100" AutoPostBack="true"
                            OnSelectedIndexChanged="FlowName_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        节点编号：
                    </td>
                    <td>
                        <input type="text" readonly="readonly" id="NodeNo" class="input2" runat="server"
                            value="1" check="必,空,0,100" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        节点名称：
                    </td>
                    <td>
                        <input type="text" id="NodeName" class="input2" runat="server" check="必,空,0,100" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        节点阶段：
                    </td>
                    <td>
                        <asp:RadioButtonList ID="NodeStage" runat="server" RepeatDirection="Horizontal" check="必,空,0,100">
                            <asp:ListItem Text="开始" Value="开始"></asp:ListItem>
                            <asp:ListItem Text="中间" Value="中间"></asp:ListItem>
                            <asp:ListItem Text="结束" Value="结束"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        执行类型：
                    </td>
                    <td>
                        <asp:RadioButtonList ID="NodeType" runat="server" RepeatDirection="Horizontal" check="必,空,0,100">
                            <asp:ListItem Text="单人节点" Value="单人节点"></asp:ListItem>
                            <asp:ListItem Text="多人节点单通" Value="多人节点单通"></asp:ListItem>
                            <asp:ListItem Text="多人节点并通" Value="多人节点并通"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        执行人：
                    </td>
                    <td>
                        <asp:ListBox ID="NodeUser" runat="server" SelectionMode="Multiple" Width="300" Rows="5" check="必,空,0,100">
                        </asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        执行权限：
                    </td>
                    <td>
                        <asp:CheckBoxList ID="NodeUserLimit" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="允许驳回" Value="允许驳回"></asp:ListItem>
                            <asp:ListItem Text="允许跳过" Value="允许跳过"></asp:ListItem>
                            <asp:ListItem Text="允许终止" Value="允许终止"></asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        授权表单域：
                    </td>
                    <td>
                        <textarea id="NodeFormArea" style="width: 700px; height: 300px; visibility: hidden;"
                            runat="server"></textarea>
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
    <br />
    </form>
</body>
</html>
