<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Flow_show.aspx.cs" Inherits="Web.views.Flow_show" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>流程图</title>
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
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="400" align="center"
                style="line-height: 24px">
                <tr>
                  <td style="text-align: center">
                      <asp:Repeater ID="Repeater1" runat="server">
                      <ItemTemplate>
                      <input title="节点编号：<%#Eval("NodeNo")%>
节点名称：<%#Eval("NodeName")%>
节点阶段：<%#Eval("NodeStage")%>
节点类型：<%#Eval("NodeType")%>
节点权限：<%#Eval("NodeUserLimit")%>
节点用户：<%#Eval("NodeUser")%>" id="Node<%#Eval("ID")%>" type="button" runat="server" value="<%#Eval("NodeName")%>" />
                      <div class="arrow" style="line-height:12px">↓</div>
                      </ItemTemplate>
                      </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td height="60" align="center" colspan="2">                     
                        <input id="Button1" runat="server" name="" type="button" class="aler-btn" onclick="window.external.close()"
                            value="关闭窗口" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
<script type="text/javascript">
    $(function () {
        $(".arrow:last").hide();
        $("#Node" + $$.Request("nodeid")).css("background", "green").css("color", "white");
    });
</script>
</body>
</html>
