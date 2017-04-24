<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectArchive_Search.aspx.cs"
    Inherits="Web.views.ProjectArchive_Search" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>档案查询</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
</head>
<body>
<uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="False" >
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="400" align="center"
                style="line-height: 24px">
                <tr>
                    <td width="120" align="right">
                        选择项目：
                    </td>
                    <td width="280">
                        <asp:DropDownList ID="ProjectType" runat="server" check="选,空,0,100" onselectedindexchanged="ProjectType_SelectedIndexChanged"  AutoPostBack="true"                         >
                        </asp:DropDownList>
                        <asp:DropDownList CssClass="pro_name" ID="ProjectID" runat="server" check="选,空,0,100">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        选择专业：
                    </td>
                    <td>
                        <asp:DropDownList ID="ClassName1" runat="server" check="选,空,0,100" AutoPostBack="true"
                            onselectedindexchanged="ClassName1_SelectedIndexChanged" >
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        选择卷册：
                    </td>
                    <td>
                        <asp:DropDownList ID="ClassName2" runat="server" check="选,空,0,100">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        操作类型：
                    </td>
                    <td>
                        <asp:RadioButtonList ID="PA_Type1" runat="server" check="必,空,0,100" 
                            RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Text="项目档案" Value="项目档案"></asp:ListItem>
                            <asp:ListItem Text="公共档案" Value="公共档案"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr id="lishitizi" runat="server">
                    <td align="right">
                        历史档案：
                    </td>
                    <td>
                        <asp:DropDownList ID="ParentID" runat="server" check="选,空,0,100" 
                            onselectedindexchanged="ParentID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        档案名称：
                    </td>
                    <td width="280">
                        <input type="text" runat="server" id="PA_Name" check="选,空,0,100" size="22" class="input1" />
                    </td>
                </tr>
                
                <tr>
                    <td align="right">
                        版本编号：
                    </td>
                    <td>
                        <input runat="server" type="text" id="PA_FileNo" check="选,空,0,100" size="22" class="input" />
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        档案简介：
                    </td>
                    <td width="280">
                        <textarea class="area" cols="35" id="PA_Info" runat="server" rows="5" name="k_content"
                            check="选,空,0,200"></textarea>
                    </td>
                </tr>
                <tr>
                    <td height="60" align="center" colspan="2">
                     <input id="btn_submit" type="button" class="aler-btn" runat="server" value="确定查询" onserverclick="btn_submit_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input name="" type="button" class="aler-btn" onclick="window.external.close();" value="关闭窗口" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    </form>
</body>
</html>
