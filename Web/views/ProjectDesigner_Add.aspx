<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectDesigner_Add.aspx.cs"
    Inherits="Web.views.ProjectDesigner_Add" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>确认主设</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/Calendar.js" type="text/javascript"></script>
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <style type="text/css">
        .divScrollBar { background-color: #ddd; position: absolute; opacity: 0.5; filter: Alpha(opacity=50); }
        .divScrollBar:hover { opacity: 1; filter: Alpha(opacity=100); }
        .divScrollBar div { background-color: #333; position: absolute; left: 0px; top: 0px; }
        .inputx { width: 30px; }
        .inputy { width: 50px; }
        input { width: 65px; }
    </style>
    <script type="text/javascript" src="../js/jsScroll.js"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="False">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" align="center" style="line-height: 24px;">
                <tr>
                    <td align="right">
                        项目名称：
                    </td>
                    <td>
                        <input class="input1" runat="server" id="ProjectName" readonly="readonly" type="text"
                            check="必,空,0,100" size="22" style="border: 1px solid #CCCCCC;width:200px" />
                    </td>
                    <td style="text-align: right">
                        项目编号：
                    </td>
                    <td>
                        <input class="input1" runat="server" id="ProjectNo" readonly="readonly" type="text"
                            check="必,空,0,100" size="22" style="border: 1px solid #CCCCCC;" />
                    </td>
                </tr>
            </table>
            <div id="div1" style="width: 500px; overflow: hidden; height: 400px; border: solid 1px gray;">
                <table width="100%" border="0" cellpadding="0" cellspacing="1" style="background: #f0f0f0">
                    <tr id="titlediv" class="td1">
                        <td align="center">
                            专业
                        </td>
                        <td align="center">
                            主设
                        </td>
                        <td align="center">
                            级别
                        </td>
                        <td align="center">
                            操作
                        </td>
                    </tr>
                    <tr class="tr1">
                        <td>
                            <asp:DropDownList AutoPostBack=true ID="ClassName" check="必,空,0,100" runat="server" onselectedindexchanged="ClassName_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="UserName" check="必,空,0,100" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList check="必,空,0,100" ID="DesignerType" runat="server">
                                <asp:ListItem>一号主设</asp:ListItem>
                                <asp:ListItem>二号主设</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="center">
                            <input id="btn_submit" type="button" class="aler-btn" runat="server" value="新增" onclick="if(checkform(document.forms[0]))"
                                onserverclick="btn_submit_Click" />
                        </td>
                    </tr>
                    <asp:Repeater ID="TaskList" runat="server">
                        <ItemTemplate>
                            <tr class="tr1">
                                <td style="padding: 3px 0" align="center" height="25">
                                    <%#Eval("ClassName")%>
                                </td>
                                <td align="center">
                                    <%#Eval("UserName")%>
                                </td>
                                <td>
                                    <%#Eval("DesignerType")%>
                                </td>
                                <td align="center">
                                    <a href="#" onclick="location.href='?limit=del&id=<%#Eval("ID")%>'" style="text-decoration: underline;">
                                        删除</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <table id="Table1" border="0" cellspacing="0" cellpadding="5" align="center" style="line-height: 24px;">
                <tr>
                    <td><br>
                        <input id="Button1" type="button" class="aler-btn" runat="server" value="确定提交"
                            onserverclick="Button1_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="button" class="aler-btn" onclick="window.external.close()" value="关闭窗口" /><br><br>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script type="text/javascript">
        jsScroll(document.getElementById('div1'), 10, 'divScrollBar');
    </script>
</body>
</html>
