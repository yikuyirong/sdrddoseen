<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DesignVolume_Add.aspx.cs"
    Inherits="Web.views.DesignVolume_add" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增卷册</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/Calendar.js" type="text/javascript"></script>
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <style type="text/css">
        .divScrollBar
        {
            background-color: #ddd;
            position: absolute;
            opacity: 0.5;
            filter: Alpha(opacity=50);
        }
        .divScrollBar:hover
        {
            opacity: 1;
            filter: Alpha(opacity=100);
        }
        .divScrollBar div
        {
            background-color: #333;
            position: absolute;
            left: 0px;
            top: 0px;
        }
        .inputx
        {
            width: 30px;
        }
        .inputy
        {
            width: 50px;
        }
        input
        {
            width: 65px;
        }
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
                        专业名称：
                    </td>
                    <td>
                        <asp:DropDownList runat="server" CssClass="select" ID="ClassName1" check="必,空,0,100" 
                            AutoPostBack="true" onselectedindexchanged="ClassName1_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        卷册名称：
                    </td>
                    <td>
                        <asp:DropDownList ID="ClassName2" CssClass="select" runat="server" AutoPostBack="true" 
                            check="必,空,0,100" onselectedindexchanged="ClassName2_SelectedIndexChanged" >
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
               <%-- <tr>
                    <td align="right">
                        专业卷序：
                    </td>
                    <td>
                        <asp:DropDownList ID="ClassName3" runat="server" CssClass="select" check="必,空,0,100" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>--%>
            </table>
            <br />
            <div id="div1" style="width: 800px; overflow: hidden; height: 400px; border: solid 1px gray;">
                <table width="100%" border="0" cellpadding="0" cellspacing="1" style="background: #f0f0f0">
                    <tr id="titlediv" class="td1">
                        <td align="center">
                            编号
                        </td>
                        <td align="center">
                            卷册名称
                        </td>
                        <td align="center">
                            25MW机组工日
                        </td>
                        <td align="center">
                            50MW机组工日
                        </td>
                        <td align="center">
                            卷册级别
                        </td>
                        <td align="center">
                            备注
                        </td>
                        <td width="100" align="center">
                            操作
                        </td>
                    </tr>
                    <tr class="tr1">
                        <td >
                            <asp:TextBox CssClass="input1" ID="VolumeNo" check="必,空,0,100" runat="server"></asp:TextBox>
                        </td>
                        <td align="center">
                            <asp:TextBox CssClass="input1" ID="VolumeName" check="必,空,0,100" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox CssClass="input1" ID="Volume25MW" check="必,数,0,100" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox CssClass="input1" ID="Volume50MW" check="必,数,0,100" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList ID="VolumeLevel" runat="server">
                            <asp:ListItem>一级</asp:ListItem>
                            <asp:ListItem>二级</asp:ListItem>
                            <asp:ListItem>三级</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox CssClass="input1" ID="Remark" check="选,空,0,500" runat="server"></asp:TextBox>
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
                                    <%#Eval("VolumeNo") %>
                                </td>
                                <td align="center">
                                    <%#Eval("VolumeName")%>
                                </td>
                                <td>
                                    <%#Eval("Volume25MW")%>
                                </td>
                                <td>
                                    <%#Eval("Volume50MW")%>
                                </td>
                                <td>
                                    <%#Eval("VolumeLevel")%>
                                </td>
                                <td>
                                    <%#Eval("Remark")%>
                                </td>
                                <td align="center">
                                    <a limit="DesignVolume_Add.del" onclick="location.href='?limit=del&id=<%#Eval("ID")%>'" style="text-decoration: underline;">
                                        删除</a> <a limit="DesignVolume_Edit" onclick="parent.window.open('../views/DesignVolume_Edit.aspx?id=<%#Eval("ID") %>')"
                                            target="_blank" style="text-decoration: underline;">编辑</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <table id="Table1" border="0" cellspacing="0" cellpadding="5" align="center" style="line-height: 24px;">
                <tr>
                    <td>
                        <input id="Button1" type="button" class="aler-btn none" runat="server" value="确认提交" onclick="if(checkform(document.forms[0]))"
                            onserverclick="btn_submit_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="button" class="aler-btn" onclick="window.external.close()" value="关闭窗口" />
                    </td>
                </tr>
            </table>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script type="text/javascript">
        jsScroll(document.getElementById('div1'), 10, 'divScrollBar');
        $(function () {
            //按钮权限验证
            CheckLimit("<%=WebCommon.Public.GetUserLimit().ToLower()%>");
        });
    </script>
</body>
</html>
