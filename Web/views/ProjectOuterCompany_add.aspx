<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectOuterCompany_Add.aspx.cs"
    Inherits="Web.views.ProjectOuterCompany_add" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=6" />
    <title>新增单位</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br>
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="400" align="center"
                style="line-height: 24px">
                <tr>
                    <td width="120" align="right">
                        单位类型：
                    </td>
                    <td width="280">
                        <asp:DropDownList runat="server" ID="POC_Type1" check="必,空,0,100" Enabled="false">
                        </asp:DropDownList>
                        <asp:DropDownList runat="server" ID="POC_Type2" check="必,空,0,100">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        单位名称：
                    </td>
                    <td width="280">
                        <input runat="server" type="text" id="POC_Name" check="必,空,0,100" size="22" class="input" />
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        联系人：
                    </td>
                    <td width="280">
                        <input runat="server" type="text" id="POC_LinkMan" check="必,空,0,100" size="22" class="input" />
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        联系电话：
                    </td>
                    <td width="280">
                        <input runat="server" id="POC_LinkPhone" type="text" class="input" check="必,电,0,100"
                            size="22" />
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        联系地址：
                    </td>
                    <td width="280">
                        <input runat="server" id="POC_Address" type="text" class="input"  size="22" />
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        邮箱：
                    </td>
                    <td width="280">
                        <input runat="server" type="text" id="POC_Email" check="选,空,0,100" size="22" class="input" />
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        备注：
                    </td>
                    <td width="280">
                        <textarea cols="35" rows="5" id="Remark" runat="server" check="选,空,0,200" class="area"></textarea>
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
    <br>
    </form>
</body>
</html>
