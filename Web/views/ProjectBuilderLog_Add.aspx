<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectBuilderLog_Add.aspx.cs" Inherits="Web.views.ProjectBuilderLog_Add" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新增施工日志</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <script src="../js/Calendar.js" type="text/javascript"></script>
    <style type="text/css">
    .inputi{border:1px solid #bbb;height:18px;width:201px}
    </style>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" runat="server">
    <br /><br />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="False">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="440" align="center">
                <tr>
                    <td align="right">
                        项目名称：
                    </td>
                    <td>
                        <asp:DropDownList ID="ProjectTypes" runat="server" check="必,空,0,100" AutoPostBack="true" OnSelectedIndexChanged="ProjectTypes_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList CssClass="pro_name" ID="ProjectID" runat="server" AutoPostBack="true"  check="必,空,0,100">
                        </asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    <td align="right">
                        日期：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="PBL_Time" class="inputi" check="必,空,0,50" onclick="calendar.setHook(this)"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td width="140" align="right">
                        天气：
                    </td>
                    <td width="280">
                        <input class="input" id="PBL_Whether" type="text" runat="server" check="必,空,0,100"
                            size="22" />
                        </td>
                </tr>
                <tr>
                    <td align="right">
                        温度：
                    </td>
                    <td>
                        <input class="input" id="PBL_Temperature" type="text" runat="server" check="必,空,0,100"
                            size="22" />
                        </td>
                </tr>
                <tr>
                    <td align="right">
                        风力：
                    </td>
                    <td>
                        <input class="input" id="PBL_Wind" type="text" runat="server" check="必,空,0,100"
                            size="22" />
                        </td>
                </tr>
                <tr>
                    <td align="right">
                        组织安排：
                    </td>
                    <td>
                        <textarea class="area" cols="35" id="PBL_Info1" runat="server" rows="5" name="k_content"
                            check="选,空,0,200"></textarea><br>
                        <asp:FileUpload ID="PBL_Info1File" runat="server" CssClass="file" />
                        </td>
                </tr>
                <tr>
                    <td align="right">
                        施工情况：
                    </td>
                    <td>
                        <textarea class="area" cols="35" id="PBL_Info2" runat="server" rows="5" name="k_content"
                            check="选,空,0,200"></textarea><br>
                        <asp:FileUpload ID="PBL_Info2File" runat="server" CssClass="file" />
                        </td>
                </tr>
                <tr>
                    <td align="right">
                        上报协助：
                    </td>
                    <td>
                        <textarea class="area" cols="35" id="PBL_Info3" runat="server" rows="5" name="k_content"
                            check="选,空,0,200"></textarea><br>
                        <asp:FileUpload ID="PBL_Info3File" runat="server" CssClass="file" />
                        </td>
                </tr>
                <tr>
                    <td height="60" align="center" colspan="2">
                        <input id="btn_submit" type="button" class="aler-btn" runat="server" value="确定提交"
                           onclick="if(checkform(document.forms[0]))" onserverclick="btn_submit_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="button" class="aler-btn" onclick="window.external.close()" value="关闭窗口" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    </form>
</body>
</html>
