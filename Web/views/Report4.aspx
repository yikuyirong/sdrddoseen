<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report4.aspx.cs"
    Inherits="Web.views.Report4" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ OutputCache Location="None" VaryByParam="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=6" />
    <title>工作量统计</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <script src="../js/Calendar.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
    <script type="text/javascript">
        var msgdiv = "";
        function search() {
            if ($("#msgdiv").html() != "") {
                msgdiv = $("#msgdiv").html();
                $("#msgdiv").html("");
            }
            var htmlStr = msgdiv;
            $$.MsgBox("筛选", htmlStr, "确定:submit()", "取消");
        }
        function submit() {
            //if (project.value == "") { alert("请填写项目名称关键词"); return; }
            var whereStr = "1=1";
            if (time1.value != "" && time2.value != "") whereStr += " and DealTime>='" + time1.value + "' and DealTime<='" + time2.value + "'";
            if (username.value != "") whereStr += " and (DT_SheJiRen='" + username.value + "' or DT_JiaoDuiRen='" + username.value + "' or DT_ShenHeRen='" + username.value + "' or DT_ShenDingRen='" + username.value + "')";
            if (project.value != "") {
                whereStr += " and projectname like '%" + project.value + "%'";
                location.href = "Report4_Info.aspx?user=" + username.value + "&project=" + project.value + "&where=" + whereStr;
            }
            else {
                location.href = "Report4_Info.aspx?user=" + username.value + "&where=" + whereStr;
            }
        }
    </script>
    <div id="msgdiv" class="none">
    <div style="margin:15px;width:320px;font-size:12px;padding-left:20px">
         统计人员：<input id="username" type="text" value="" class="input1" /><br>
         项目名称：<input id="project" type="text" value="" class="input1" style="width:210px" /><br>
         统计时间：<input id="time1" type="text" value="" class="input1" onfocus="calendar.setHook(this)" />～<input id="time2" type="text" value="" class="input1" onfocus="calendar.setHook(this)" /><br>
    </div>
    </div>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="background: url(../images/list-title-bg.png) repeat-x;">
        <tr>
            <td class="sousuo">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="20%" height="36">
                            <span style="font-weight: bold; margin-left: 10px;">生产管理 <span style="font-family: SimSun">
                                >> </span>工作量统计</span>
                        </td>
                        <td align="right">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="20">
                                        <img src="../images/application_form_add.png" alt="筛选" />
                                    </td>
                                    <td width="36">
                                        <span onclick="search()" style="cursor: pointer;">
                                            筛选</span>
                                    </td>
                                    <td width="22" style="cursor: pointer">
                                        <img src="../images/refresh-icon.png" alt="刷新" />
                                    </td>
                                    <td width="36" style="cursor: pointer" onclick="location.reload()">
                                        刷新
                                    </td>
                                   <td width="147">
                                        <input type="text" style="color:#ccc;height: 20px; width: 145px; border: 1px solid #8a8a8a;line-height: 20px;font-size:12px"
                                            id="keywords" value="项目名称/项目编号/设计人" onfocus="this.value=''" name="keywords" />
                                    </td>
                                    <td width="48">
                                        <a style="display: block; width: 40px; padding: 2px 0; background: #93bc12; border: 1px solid #7b9e0d;
                                            color: #fff; text-align: center;cursor:pointer" onclick="scan('DT_SheJiRen,ProjectName,ProjectNo',keywords.value)">
                                            搜索</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="maindiv" onscroll="mymove()">
        <table width="100%" border="0" cellpadding="0" cellspacing="1" style="background: #f0f0f0">
            <tr>
                <td colspan="6" height="28">
                </td>
            </tr>
            <tr id="titlediv" class="td1" style="position: absolute">
                <td width="50" align="center">
                    选择
                </td>
                <td align="center">
                    项目名称
                </td>
                <td  align="center">
                    专业卷册
                </td>
                <td align="center">
                    设总
                </td>
                <td align="center">
                    主设
                </td>
                <td align="center">
                    参与人
                </td>
                <td align="center">
                    评级
                </td>
                <td align="center">
                    自然张<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </td>
                <td align="center">
                    折合张<asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                </td>
                <td align="center">
                    工日数<asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                </td>
                <td align="center">
                    完成时间
                </td>
            </tr>
            <script type="text/javascript">
                function mymove() {
                    var isIE = !!window.ActiveXObject;
                    var isIE6 = isIE && !window.XMLHttpRequest;
                    var titlediv = document.getElementById("titlediv");
                    var maindiv = document.getElementById("maindiv");
                    if (isIE6) {
                        titlediv.style.top = maindiv.scrollTop;
                    }
                    else {
                        titlediv.style.top = maindiv.scrollTop;
                    }
                }
                mymove();
            </script>
            <asp:Repeater ID="ProjectList" runat="server" OnItemDataBound="ProjectList_ItemDataBound">
                <ItemTemplate>
                    <tr class="tr1">
                        <td style="padding: 3px 0" align="center">
                            <input class="sel" type="checkbox" />
                        </td>
                        <td width="110" align="center">
                            <%#Eval("ProjectNo")%><br><%#Eval("ProjectName")%>
                        </td>
                        <td width="180">
                            <%#Eval("ClassName1")%><br>
                            <%#Eval("DT_TuHao")%> <%#Eval("ClassName2")%><br>
                            <%#Eval("ClassName3")%>(核定<%#Eval("DT_GuGong")%>工日)
                        </td>
                        <td>
                            <%#Eval("DesignManager")%>
                        </td>
                        <td>
                            <%#Eval("DesignMain")%>
                        </td>
                        <td style="text-align:left">
                            设计人：<%#Eval("DT_SheJiRen")%>(<asp:Label ID="Label4" runat="server" Text=""></asp:Label>工日)<br>
                            校对人：<%#Eval("DT_JiaoDuiRen")%>(<asp:Label ID="Label5" runat="server" Text=""></asp:Label>工日)<br>
                            审核人：<%#Eval("DT_ShenHeRen")%>(<asp:Label ID="Label6" runat="server" Text=""></asp:Label>工日)<br>
                            审定人：<%#Eval("DT_ShenDingRen")%>(<asp:Label ID="Label7" runat="server" Text=""></asp:Label>工日)<br>
                        </td>
                        <td>
                            <%#Eval("PaperNum3")%>
                        </td>
                        <td>
                            <%#Eval("PaperNum1")%>张
                        </td>
                        <td>
                            <%#Math.Round(Convert.ToDouble(Eval("PaperNum2")), 2).ToString()%>张
                        </td>
                        <td>
                            <%#Convert.ToDouble(Eval("DT_GuGong"))%>工日
                        </td>
                        <td>
                            <%#Convert.ToDateTime(Eval("DealTime")).ToString("yyy-MM-dd")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <webdiyer:AspNetPager ID="AspNetPager1" UrlPaging="true" runat="server" ShowFirstLast="true"
        LayoutType="Div" CssClass="pager" PageIndexBoxClass="PageSelect" CurrentPageButtonClass="PageSel"
        OnPageChanged="AspNetPager1_PageChanged">
    </webdiyer:AspNetPager>
    <div class="btmdo">
        <input id="Checkbox1" runat="server" class="selectAll" name="checkbox" type="checkbox"
            onclick="if(this.checked){$('.sel').attr('checked','checked')}else{$('.sel').removeAttr('checked')}" />
        <span>全选</span>
        <input id="Button1" runat="server" class="none delete" onclick="if(confirm('您确定要删除吗?')){if(typeof(sel)!='undefined')checkall(sel,0,'?del=1')}" type="button" />
    </div>
</form>
</body>
</html>
