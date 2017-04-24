<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DesignCorrect_Edit.aspx.cs"
    Inherits="Web.views.DesignCorrect_Edit" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看电子校审</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
</head>
<body >
    <uc2:wintop ID="wintop1" runat="server" EnablePartialRendering="False"/>
    <form id="form1" name="form1" runat="server">
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="False">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="400" align="center"
                style="line-height: 24px;overflow:scroll">
                <tr>
                    <td width="120" align="right">
                        您修改后的文件：
                    </td>
                    <td width="280">
                        <asp:FileUpload check="必,空,0,200" ID="DC_File" runat="server" CssClass="file" />
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        自动校审结果DWG：
                    </td>
                    <td width="280">
                        <asp:FileUpload check="必,空,0,200" ID="DC_FileCorrect" runat="server" CssClass="file" />
                    </td>
                </tr>
                <tr>
                    <td width="120" align="right">
                        自动校审结果TXT：
                    </td>
                    <td width="280">
                        <asp:FileUpload check="必,空,0,200" ID="CorrectTxt" runat="server" CssClass="file" />
                        <asp:Button CssClass="none" ID="Button1"
                                runat="server" Text="提取到结果说明" onclick="Button1_Click" />
&nbsp;</td>
                </tr>
                <tr class="none">
                    <td width="120" align="right">
                       比较结果说明：
                    </td>
                    <td width="280">
                    <textarea cols="35" rows="5" id="DC_FileCorrectInfo" runat="server" check="选,空,0,200" class="area"></textarea>
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
