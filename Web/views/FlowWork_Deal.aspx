<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowWork_Deal.aspx.cs" Inherits="Web.views.FlowWork_Deal" ValidateRequest="false" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>办理工作</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/jquery.md5.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <script src="../js/Calendar.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jsScroll.js"></script>
    <style type="text/css">
    .divScrollBar{background-color:#ddd;position:absolute;opacity:0.5; filter:Alpha(opacity=50);}
    .divScrollBar:hover{opacity:1; filter:Alpha(opacity=100);}
    .divScrollBar div{background-color:#333; position:absolute; left:0px; top:0px;}
    </style>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br />
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="800" align="center"
                style="line-height: 24px">
                <tr>
                    <td width="300" align="right">
                        工作名称：
                    </td>
                    <td width="500" align="left">
                        <input runat="server" type="text" readonly="readonly" id="WorkName" check="必,空,0,100" class="input" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        工作流程：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="FlowName" Enabled="false" runat="server" check="必,空,0,100">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="300" align="right">
                        自动流转：
                    </td>
                    <td width="500" align="left">
                        <asp:RadioButtonList ID="AutoNext" runat="server" RepeatDirection="Horizontal" 
                            onselectedindexchanged="AutoNext_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="自动流转" Value="自动流转" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="手动跳转" Value="手动跳转"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td width="300" align="right">
                        当前节点：
                    </td>
                    <td width="500" align="left">
                        <input runat="server" type="text" readonly="readonly" id="NodeLocal" class="input" />
                        <asp:HiddenField ID="FlowWorkID" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td width="300" align="right">
                        下一节点：
                    </td>
                    <td width="500" align="left">
                        <asp:DropDownList ID="NodeID" runat="server" check="必,空,0,100">
                        </asp:DropDownList>
                        <input id="FormContentSet" type="text" class="none" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" width="800" height="400" valign="top">
                        <div id="FormContent" onmouseout="$('#FormContentSet').val($('#FormContent').html());" runat="server" style="width:auto; overflow:hidden; height:400px; border:solid 1px gray;background:#fff"></div>
                    </td>
                </tr>
                <tr>
                    <td height="60" align="center" colspan="2">
                    <input id="Button4" type="button" class="aler-btn" runat="server" value="同步保存"/>
                        <input id="btn_submit" type="button" class="aler-btn" runat="server" value="确认流转"
                            onclick="if(checkform(document.forms[0]))" onserverclick="btn_submit_Click" />
                        <input id="Button1" type="button" class="aler-btn" runat="server" value="节点驳回"
                            onclick="if(checkform(document.forms[0]))" onserverclick="btn_submit_Click1" />
                        <input id="Button2" type="button" class="aler-btn" runat="server" value="节点跳过"
                            onclick="if(checkform(document.forms[0]))" onserverclick="btn_submit_Click2" />
                        <input id="Button3" type="button" class="aler-btn" runat="server" value="流程终止"
                            onclick="if(checkform(document.forms[0]))" onserverclick="btn_submit_Click3" />
                        <input runat="server" name="" type="button" class="aler-btn" onclick="window.external.close()"
                            value="关闭窗口" />
                    </td>
                </tr>
            </table>
    <br>
    <br>
    </form>
<script type="text/javascript">
    $(function () {
        //加载短语

        //虚拟滚动框
        jsScroll(document.getElementById('FormContent'), 10, 'divScrollBar');
    });
</script>
</body>
</html>
