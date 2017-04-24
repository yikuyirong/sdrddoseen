<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowNodeTask_Edit.aspx.cs"
    Inherits="Web.views.FlowNodeTask_Edit" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看任务</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <script src="../js/Calendar.js" type="text/javascript"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br/>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="400" align="center"
                style="line-height: 24px">
                <tr>
                    <td width="120" align="right">
                        项目名称：
                    </td>
                    <td width="280">                        
                         <asp:DropDownList runat="server" Enabled="false" ID="ProjectName" check="必,空,0,100">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        流程节点：
                    </td>
                    <td width="280">
                        <asp:DropDownList ID="FlowNodeID" Enabled="false" runat="server" check="必,空,0,100">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        节点用户：
                    </td>
                    <td width="280">
                       <asp:ListBox ID="UserName" runat="server" SelectionMode="Multiple" Width="200" Rows="10">
                        </asp:ListBox>
                    </td>
                </tr>
                 <tr>
                    <td width="120" align="right">
                        完成日期：
                    </td>
                    <td width="280">
                        <input runat="server" type="text" id="EndTime" check="必,空,0,100" size="22" class="input1"  onclick="calendar.setHook(this)"  />
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        任务内容：
                    </td>
                    <td width="280">
                        <textarea class="area" id="FNT_Info" runat="server" name="k_content"
                            check="必,空,0,200"></textarea>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        任务状态：
                    </td>
                    <td width="280">
                        <asp:RadioButtonList runat="server" ID="Status" RepeatDirection="Horizontal">
                            <asp:ListItem Text="未完成" Value="未完成" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="已完成" Value="已完成"></asp:ListItem>
                            <asp:ListItem Text="进行中" Value="进行中" ></asp:ListItem>
                        </asp:RadioButtonList>
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
    <br />
    </form>
</body>
</html>
