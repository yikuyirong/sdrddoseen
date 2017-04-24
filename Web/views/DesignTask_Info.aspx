<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DesignTask_Info.aspx.cs"
    Inherits="Web.views.DesignTask_Info" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>卷册任务审批</title>
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
                        <asp:DropDownList ID="DesignMain" check="必,空,0,100" runat="server" AutoPostBack="true" 
                            onselectedindexchanged="DesignMain_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        专业卷册：
                    </td>
                    <td>
                        <asp:DropDownList ID="ClassName" runat="server" check="必,空,0,100" AutoPostBack="true"
                            OnSelectedIndexChanged="ClassName_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ClassName1" runat="server" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <br />
            <div id="div1" style="width:1275px;overflow-y:scroll;overflow-x: hidden; height: 400px; border: solid 1px gray;">
                <table width="100%" border="0" cellpadding="0" cellspacing="1" style="background: #f0f0f0">
                    <tr id="titlediv" class="td1">
                        <td align="center">
                            序号
                        </td>
                        <td align="center">
                            图号
                        </td>
                        <td align="center">
                            卷册
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
                        <td align="center">
                            核准人
                        </td>
                        <td align="center">
                            核准时间
                        </td>
                        <td align="center">
                            出版时间
                        </td>
                        <td align="center">
                            评级
                        </td>
                        <td align="center">
                            操作
                        </td>
                        <td align="center">
                            预
                        </td>
                    </tr>
                    <asp:Repeater ID="TaskList" runat="server">
                        <ItemTemplate>
                            <tr class="tr1 taskrow">
                                <td style="padding: 3px 0" align="center" height="25">
                                    <%#Eval("DT_XuHao") %>
                                </td>
                                <td align="center">
                                    <%#Eval("DT_TuHao")%>
                                </td>
                                <td>
                                    <%#Eval("ClassName3")%>
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
                                <td>
                                    <%#Convert.ToDateTime(Eval("DT_ShenDingTime")).ToString("yyyy-MM-dd")%>
                                </td>
                                <td>
                                    <%#Eval("DT_HeZhunRen")%>
                                </td>
                                <td>
                                    <%#Convert.ToDateTime(Eval("DT_HeZhunTime")).ToString("yyyy-MM-dd")%>
                                </td>
                                <td>
                                   <%#Convert.ToDateTime(Eval("DT_PublishTime")).ToString("yyyy-MM-dd")%>
                                </td>
                                <td>
                                <select onchange="location.href='?type=read&ClassName1=<%#Server.UrlEncode(Eval("ClassName1").ToString())%>&ProjectID=<%#Eval("ProjectID")%>&TaskID=<%#Eval("ID")%>&pingji='+this.value">
                                <option value="<%#Eval("PaperNum3")%>"><%#Eval("PaperNum3")%></option>
                                <option value="1">1</option>
                                <option value="0.8">0.8</option>
                                <option value="0.9">0.9</option>
                                <option value="1">1</option>
                                <option value="1.1">1.1</option>
                                <option value="1.2">1.2</option>
                                </select>
                                </td>
                                <td>
                                <a href="?type=read&ClassName1=<%#Server.UrlEncode(Eval("ClassName1").ToString())%>&ProjectID=<%#Eval("ProjectID")%>&TaskID=<%#Eval("ID")%>&chongzhi=1" target="_blank" style="text-decoration: underline;">重置卷册</a>
                                </td>
                                <td></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
    </div><br />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
