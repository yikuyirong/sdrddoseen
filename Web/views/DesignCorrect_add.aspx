<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DesignCorrect_Add.aspx.cs"
    Inherits="Web.views.DesignCorrect_add" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增电子校审</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="False">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="400" align="center"
                style="line-height: 24px">
                <tr>
                    <td width="120" align="right">
                        选择项目：
                    </td>
                    <td width="280">
                        <asp:DropDownList ID="ProjectType" runat="server" AutoPostBack="true"
                            onselectedindexchanged="ProjectType_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ProjectID" runat="server" check="必,空,0,100">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        选择专业：
                    </td>
                    <td width="280">
                        <asp:DropDownList ID="ClassName" runat="server" check="必,空,0,100" AutoPostBack="true"
                            OnSelectedIndexChanged="ClassName_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        选择任务：
                    </td>
                    <td width="280">
                        <asp:DropDownList ID="DesignTaskID" runat="server" check="必,空,0,100">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="none">
                    <td width="120" align="right">
                        文件标题：
                    </td>
                    <td width="280">
                     <input class="input" runat="server" id="DC_Name" type="text" check="选,空,0,100" /> </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        设计文件：
                    </td>
                    <td width="280">
                        <asp:FileUpload ID="DC_File" runat="server" CssClass="file" />
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        设计说明：
                    </td>
                    <td width="280">
                    <textarea cols="35" rows="5" id="DC_FileInfo" runat="server" check="选,空,0,200" class="area"></textarea>
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
