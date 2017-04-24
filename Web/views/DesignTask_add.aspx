<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DesignTask_Add.aspx.cs"
    Inherits="Web.views.DesignTask_add" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增卷册任务</title>
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
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" align="center" style="line-height: 24px">
                <tr>
                    <td align="right">
                        项目名称：
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ProjectID" check="必,空,0,100" AutoPostBack="true"
                            OnSelectedIndexChanged="ProjectID_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList runat="server" ID="ProjectName" check="必,空,0,100" AutoPostBack="true"
                            OnSelectedIndexChanged="ProjectName_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right">
                        项目编号：
                    </td>
                    <td>
                        <input class="input1" runat="server" id="ProjectNo" type="text" check="必,空,0,100"
                            size="22" style="border: 1px solid #CCCCCC;" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        设总：
                    </td>
                    <td>
                        <asp:DropDownList ID="DesignManager" check="必,空,0,100" runat="server">
                        </asp:DropDownList>
                        &nbsp;&nbsp;
                    </td>
                    <td style="text-align: right">
                        主设：
                    </td>
                    <td>
                        <asp:DropDownList ID="DesignMain" check="必,空,0,100" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        专业卷册：
                    </td>
                    <td>
                        <asp:DropDownList ID="ClassName1" runat="server" check="必,空,0,100" AutoPostBack="true"
                            OnSelectedIndexChanged="ClassName1_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ClassName2" runat="server" AutoPostBack="true" check="必,空,0,100"
                            OnSelectedIndexChanged="ClassName2_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList di="ClassName3" ID="ClassName3" AutoPostBack="true"
                                check="必,空,0,100" runat="server" OnDataBound="ClassName3_DataBound" OnSelectedIndexChanged="ClassName3_SelectedIndexChanged">
                            </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td><asp:Button ID="Button3" runat="server" Text="刷新" CssClass="aler-btn" 
                            onclick="Button3_Click" /></td>
                </tr>
            </table>
            <br />
            <div id="div1" style="width: 1350px;overflow-y:scroll;overflow-x: hidden; height: 500px; border: solid 1px gray">
                <table width="100%" border="0" cellpadding="0" cellspacing="1" style="background: #f0f0f0">
                    <tr id="titlediv" class="td1">
                        <td align="center">
                            序号
                        </td>
                        <td align="center">
                            卷册
                        </td>
                        <td align="center">
                            图号
                        </td>
                        <td align="center">
                            估工
                        </td>
                        <td align="center">
                            设计人
                        </td>
                        <td align="center">
                            设计时间
                        </td>
                        <td align="center">
                            校对人
                        </td>
                        <td align="center">
                            校对时间
                        </td>
                        <td align="center">
                            审核人
                        </td>
                        <td align="center">
                            审核时间
                        </td>
                        <td align="center">
                            审定人
                        </td>
                        <td align="center">
                            审定时间
                        </td>
                        <%-- <td align="center">
                            核准人
                        </td>
                        <td align="center">
                            核准时间
                        </td>--%>
                        <td align="center">
                            出版时间
                        </td>
                        <td align="center">
                            备注
                        </td>
                        <td width="100" align="center">
                            操作
                        </td>
                    </tr>
                    <tr class="tr1">
                        <td style="padding: 3px 0" align="center" height="25">
                            <asp:TextBox CssClass="inputx" style="text-align:center" ID="DT_XuHao" check="必,空,0,100" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:HiddenField ID="VolumeLevel" runat="server" />
                            <asp:TextBox CssClass="inputx" ID="ClassName3Value" Width="100" check="必,空,0,100" runat="server"></asp:TextBox>
                        </td>
                        <td align="center">
                            <asp:TextBox CssClass="inputx" ID="DT_TuHao" Width="38" check="必,空,0,100" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox CssClass="inputx" ID="DT_GuGong" check="必,空,0,100" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList CssClass="inputy" ID="DT_SheJiRen" Width="80px" check="必,空,0,100"
                                runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="DT_SheJiTime" runat="server" check="选,空,0,100" onclick="calendar.setHook(this)"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList CssClass="inputy" check="必,空,0,100" Width="80px" ID="DT_JiaoDuiRen"
                                runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="DT_JiaoDuiTime" check="选,空,0,100" runat="server" onclick="calendar.setHook(this)"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList CssClass="inputy" check="选,空,0,100" Width="80px" ID="DT_ShenHeRen"
                                runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="DT_ShenHeTime" check="选,空,0,100" runat="server" onclick="calendar.setHook(this)"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList CssClass="inputy" check="选,空,0,100" Width="80px" ID="DT_ShenDingRen"
                                runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="DT_ShenDingTime" check="选,空,0,100" runat="server" onclick="calendar.setHook(this)"></asp:TextBox>
                        </td>
                        <%-- <td>
                            <asp:DropDownList CssClass="inputy" check="必,空,0,100" ID="DT_HeZhunRen" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="DT_HeZhunTime" check="必,空,0,100" runat="server" onclick="calendar.setHook(this)"></asp:TextBox>
                        </td>--%>
                        <td>
                            <asp:TextBox ID="DT_PublishTime" check="选,空,0,100" runat="server" onclick="calendar.setHook(this)"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="Remark" check="选,空,0,100" runat="server"></asp:TextBox>
                        </td>
                        <td align="center">
                            <input id="btn_submit" type="button" class="aler-btn" runat="server" value="新增" onclick="if(checkform(document.forms[0]))"
                                onserverclick="btn_submit_Click" />
                        </td>
                    </tr>
                    <asp:Repeater ID="TaskList" runat="server">
                        <ItemTemplate>
                            <tr class="tr1 taskrow">
                                <td style="padding: 3px 0" align="center" height="25">
                                    <%#Eval("DT_XuHao") %>
                                </td>
                                <td>
                                    <%#Eval("ClassName3")%>
                                </td>
                                <td align="center">
                                    <%#Eval("DT_TuHao")%>
                                </td>
                                <td>
                                    <%#Eval("DT_GuGong")%>
                                </td>
                                <td>
                                    <%#Eval("DT_SheJiRen")%>
                                </td>
                                <td>
                                    <%#Convert.ToDateTime(Eval("DT_SheJiTime")).ToString("yyyy-MM-dd")%>
                                </td>
                                <td>
                                    <%#Eval("DT_JiaoDuiRen")%>
                                </td>
                                <td>
                                    <%#Convert.ToDateTime(Eval("DT_JiaoDuiTime")).ToString("yyyy-MM-dd")%>
                                </td>
                                <td>
                                    <%#Eval("DT_ShenHeRen")%>
                                </td>
                                <td>
                                    <%#Convert.ToDateTime(Eval("DT_ShenHeTime")).ToString("yyyy-MM-dd")%>
                                </td>
                                <td>
                                    <%#Eval("DT_ShenDingRen")%>
                                </td>
                                <td class="dateFilter">
                                    <%#Convert.ToDateTime(Eval("DT_ShenDingTime")).ToString("yyyy-MM-dd")%>
                                </td>
                                <%-- <td>
                                    <%#Eval("DT_HeZhunRen")%>
                                </td>
                                <td>
                                    <%#Convert.ToDateTime(Eval("DT_HeZhunTime")).ToString("yyyy-MM-dd")%>
                                </td>--%>
                                <td>
                                    <%#Convert.ToDateTime(Eval("DT_PublishTime")).ToString("yyyy-MM-dd")%>
                                </td>
                                <td>
                                    <%#Eval("Remark")%>
                                </td>
                                <td align="center">
                                    <a href="#" onclick="location.href='?limit=del&id=<%#Eval("ID")%>'" style="text-decoration: underline;">
                                        删除</a> <a onclick="parent.window.open('../views/DesignTask_Edit.aspx?id=<%#Eval("ID") %>')"
                                            target="_blank" style="text-decoration: underline;">编辑</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <table id="Table1" border="0" cellspacing="0" cellpadding="5" align="center" style="line-height: 24px">
                <tr>
                    <td>
                        <input id="Button2" type="button" class="aler-btn" runat="server" value="确认提交" onserverclick="Button2_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="button" class="aler-btn" onclick="window.external.close()" value="关闭窗口" />
                    </td>
                </tr>
            </table>
            <br />
    </form>
    <script type="text/javascript">
        //jsScroll(document.getElementById('div1'), 10, 'divScrollBar');
        $(function () {
            $("#DT_XuHao").val($(".taskrow").length + 1);

            if ($(".taskrow").length == 0) {
                $("#Button2").hide();
            }
            else {
                $("#Button2").show();
            }
            $(".dateFilter:contains('1900')").html("");
        });
    </script>
</body>
</html>
