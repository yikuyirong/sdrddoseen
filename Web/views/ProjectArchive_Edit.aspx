<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectArchive_Edit.aspx.cs"
    Inherits="Web.views.ProjectArchive_Edit" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看项目存档</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br>
    <asp:ScriptManager ID="ScriptManager1" runat="server"  EnablePartialRendering="False">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="400" align="center"
                style="line-height: 24px">
                <tr>
                    <td align="right">
                        档案类型：
                    </td>
                    <td>
                        <asp:RadioButtonList ID="PA_Type1" runat="server" check="必,空,0,100" 
                            RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Text="公共档案" Value="公共档案"></asp:ListItem>
                            <asp:ListItem Text="项目档案" Value="项目档案"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        档案类型：
                    </td>
                    <td>
                        <asp:RadioButtonList ID="PA_Type2" runat="server" check="必,空,0,100" 
                            RepeatDirection="Horizontal" AutoPostBack="true">
                            <asp:ListItem Selected="True" Text="电子版" Value="电子版"></asp:ListItem>
                            <asp:ListItem Text="纸质版" Value="纸质版"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        选择项目：
                    </td>
                    <td width="280">
                        <asp:DropDownList ID="ProjectID" AutoPostBack="false" Enabled="false" runat="server" check="必,空,0,100">
                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        选择专业：
                    </td>
                    <td>
                        <input type="text" runat="server" id="ClassName1" readonly="readonly" check="必,空,0,100" size="22" class="input1" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        选择卷：
                    </td>
                    <td>
                        <input type="text" runat="server" id="ClassName2" readonly="readonly" check="必,空,0,100" size="22" class="input1" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        选择册：
                    </td>
                    <td>
                        <input type="text" runat="server" id="ClassName3" readonly="readonly" check="必,空,0,100" size="22" class="input1" />
                    </td>
                </tr>
                <tr class="none">
                    <td align="right">
                        历史档案：
                    </td>
                    <td>
                        <asp:DropDownList ID="ParentID"  AutoPostBack="false" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        档案密级：
                    </td>
                    <td>
                        <asp:RadioButtonList ID="PA_Limit" runat="server" check="必,空,0,100" 
                            RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Text="普通" Value="普通"></asp:ListItem>
                            <asp:ListItem Text="秘密" Value="秘密"></asp:ListItem>
                            <asp:ListItem Text="机密" Value="机密"></asp:ListItem>
                            <asp:ListItem Text="绝密" Value="绝密"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        档案名称：
                    </td>
                    <td width="280">
                        <input type="text" runat="server" id="PA_Name" check="必,空,0,100" size="22" class="input1" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        档案文件：
                    </td>
                    <td>
                    <asp:FileUpload ID="PA_File" runat="server" CssClass="file" /><a class="underline" onclick="window.external.download('<%=PA_FilePath%>','<%=PA_FilePath%>',true)">查看</a>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        版本编号：
                    </td>
                    <td>
                        <input runat="server" type="text" id="PA_FileNo" check="必,空,0,100" size="22" class="input" />
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        档案简介：
                    </td>
                    <td width="280">
                        <textarea class="area" cols="35" id="PA_Info" runat="server" rows="5" name="k_content"></textarea>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        状态：
                    </td>
                    <td width="280">
                        <asp:RadioButtonList ID="Status" runat="server" RepeatDirection="Horizontal" check="必,空,0,100">
                            <asp:ListItem Text="未审核" Value="未审核" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="已审核" Value="已审核"></asp:ListItem>
                            <asp:ListItem Text="审核拒绝" Value="审核拒绝"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td height="60" align="center" colspan="2">
                        <input id="btn_submit" type="button" class="aler-btn" runat="server" value="确定提交"
                            onclick="if(checkform(document.forms[0]))" onserverclick="btn_submit_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input name="" type="button" class="aler-btn" onclick="window.external.close()" value="关闭窗口" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    </form>
</body>
</html>
