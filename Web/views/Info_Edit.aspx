<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info_Edit.aspx.cs" Inherits="Web.views.Info_Edit" ValidateRequest="false" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看新闻公告</title>
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
        .inputi{width:670px;height:20px;border:1px solid #ccc}
    </style>
    <script type="text/javascript" src="../js/jsScroll.js"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server" style="width: 800px">
        <br />
        <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="False" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="820" align="center"
                    style="line-height: 24px">
                    <tr>
                        <td width="80" class="tdbg" align="right">
                            分 类：                        </td>
                        <td class="tdbg">
                            <asp:DropDownList ID="ClassID" runat="server" class="select1" check="必,空,0,100">                            </asp:DropDownList>                        </td>
                        <td rowspan="4" align="right">
                            消息发送：                        </td>
                        <td width="280" rowspan="4">
                            <asp:ListBox ID="UserNameTo" runat="server" SelectionMode="Multiple" Width="200"
                                Rows="10"></asp:ListBox>                                                                                                                                                                                   </td>
                    </tr>
                    <tr class="tdbg">
                        <td align="right">
                            标 题：                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="I_Title" class="input2" check="必,空,0,100"></asp:TextBox>                        </td>
                        </tr>
                    <tr class="tdbg">
                        <td align="right">
                            关键词：                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="I_Keyword" class="input2" check="选,空,0,80"></asp:TextBox>                        </td>
                        </tr>
                    <tr class="tdbg">
                        <td align="right">
                            图 片：                        </td>
                        <td>
                            <asp:FileUpload ID="I_Pic" runat="server" class="input2" check="选,空,0,500" />                        </td>
                        </tr>
                    <tr class="tdbg">
                        <td align="right">
                            缩略图：                        </td>
                        <td>
                            <asp:TextBox ID="PicWidth" class="input2" Style="width: 40px" check="选,数,1,4" runat="server"></asp:TextBox>*<asp:TextBox
                                ID="PicHeight" class="input2" Style="width: 40px" check="选,数,1,4" runat="server"></asp:TextBox><span>
                                    宽*高 (默认为空不生成缩略图)</span>                        </td>
                        <td align="right">重要性：</td>
                        <td>     <asp:RadioButtonList runat="server" ID="I_Type" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True">一般信息</asp:ListItem>
                                <asp:ListItem>重要信息</asp:ListItem>
                            </asp:RadioButtonList>                      </td>
                    </tr>
                    <tr class="tdbg">
                        <td align="right">
                            附 件：                        </td>
                        <td>
                            <asp:FileUpload ID="I_File" runat="server" class="input2" check="选,空,0,500" />                        </td>
                        <td align="right">状 态：</td>
                        <td><asp:RadioButtonList ID="Status" runat="server" Enabled="false" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True">未审核</asp:ListItem>
                                <asp:ListItem>已审核</asp:ListItem>
                            </asp:RadioButtonList> </td>
                    </tr>
                    <tr class="tdbg">
                      <td align="right">排 序：</td>
                      <td><asp:TextBox runat="server" ID="OrderNum" Text="0" class="input2" check="必,数,0,20"></asp:TextBox></td>
                      <td align="right">日 期：</td>
                      <td><asp:TextBox runat="server" ID="AddDate" class="input2" check="必,空,0,50" onclick="calendar.setHook(this)"></asp:TextBox></td>
                    </tr>
                    <tr class="tdbg">
                        <td align="right">概 述：                                                    </td>
                        <td colspan="3"> <asp:TextBox runat="server" ID="I_Description" class="inputi" check="选,空,0,200"></asp:TextBox>                                                   </td>
                        </tr>
                    <tr class="tdbg">
                        <td align="right">
                            内 容：                        </td>
                        <td colspan="3"><textarea name="textarea" id="I_Content" style="width: 670px; height: 200px; visibility: hidden;"
                                runat="server"></textarea></td>
                    </tr>
                    <tr class="tdbg">
                        <td height="60" align="center" colspan="4">
                            <input id="btnSave" type="button" class="aler-btn" runat="server" value="确定提交" onclick="if(checkform(document.forms[0]))"
                                onserverclick="btnSave_Click" />
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
    <script type="text/javascript">
        jsScroll(document.getElementById('div1'), 10, 'divScrollBar');
    </script>
</body>
</html>
