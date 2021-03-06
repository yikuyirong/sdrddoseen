<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Flow_Add.aspx.cs" Inherits="Web.views.Flow_add" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增流程</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="420" align="center"
                style="line-height: 24px">
                <tr>
                    <td align="right">
                        流程类型：
                    </td>
                    <td>
                        <asp:RadioButtonList ID="FlowType" check="必,空,0,100" runat="server" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        所属表单：
                    </td>
                    <td>
                        <asp:DropDownList ID="FormType" runat="server" CssClass="select" OnSelectedIndexChanged="FormType_SelectedIndexChanged"
                        check="必,空,0,100"    AutoPostBack="true">
                        </asp:DropDownList><br>
                        <asp:DropDownList ID="FormID" runat="server" CssClass="select" size="4" AutoPostBack="true" 
                            onselectedindexchanged="FormID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        流程名称：
                    </td>
                    <td>
                        <input runat="server" type="text" id="FlowName" check="必,空,0,100" class="input" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        流程说明：
                    </td>
                    <td>
                        <textarea class="area" cols="35" id="Remark" runat="server" rows="5" name="k_content"
                            check="选,空,8,200"></textarea>
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
</body>
</html>
