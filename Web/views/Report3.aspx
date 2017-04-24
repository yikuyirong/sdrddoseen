<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report3.aspx.cs" Inherits="Web.views.Report3" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ OutputCache Location="None" VaryByParam="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=6" />
    <title>设计质量分析</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <script src="../js/Calendar.js" type="text/javascript"></script>
</head>
<body style="position:relative">
<form id="form1" runat="server" style="height:100%">
    <script type="text/javascript">
        var msgdiv = "";
        function search() {
            if ($("#msgdiv").html() != "") {
                msgdiv = $("#msgdiv").html();
                $("#msgdiv").html("");
            }
            var htmlStr = msgdiv;
            $$.MsgBox("", htmlStr, "确定:submit()", "取消");
        }
        function submit() {
            var whereStr = "1=1";
            if (time1.value != "" && time2.value != "") whereStr += " and dc_filetime>='" + time1.value + "' and dc_filetime<='" + time2.value + "'";
            if (username.value != "") whereStr += " and username='" + username.value + "'";
            if (project.value != "") whereStr += " and DesignTaskID in(select id from tbl_designtask where projectname like '%" + project.value + "%')";
            location.href = "?where=" + whereStr;
        }
    </script>
    <div id="msgdiv" class="none">
    <div style="margin:15px;width:310px;font-size:12px;padding-left:20px">
         设计人员：<input id="username" type="text" value="" class="input1" /><br>
         项目名称：<input id="project" type="text" value="" class="input1" style="width:210px" /><br>
         完成时间：<input id="time1" type="text" value="" class="input1" onfocus="calendar.setHook(this)" />～<input id="time2" type="text" value="" class="input1" onfocus="calendar.setHook(this)" />
    </div>
    </div>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="background: url(../images/list-title-bg.png) repeat-x;">
        <tr>
            <td class="sousuo">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="36">
                            <span style="font-weight: bold; margin-left: 10px;">质量管理 <span style="font-family: SimSun">
                                >> </span>设计质量分析 </span>
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
                                    <td width="20" style="cursor: pointer">
                                        <img src="../images/refresh-icon.png" alt="刷新" />
                                    </td>
                                    <td width="36" style="cursor: pointer" onclick="location.reload()">
                                        刷新
                                    </td>
                                    <td width="147">
                                        <input runat="server" type="text" style="color:#ccc;height: 20px; width: 145px; border: 1px solid #8a8a8a;line-height: 20px;font-size:12px" value="设计人姓名" id="keywords" name="keywords"   onfocus="this.value=''"/>
                                    </td>
                                    <td width="48">
                                        <a style="display: block; width: 40px; padding: 2px 0; background: #93bc12; border: 1px solid #7b9e0d;
                                            color: #fff; text-align: center;cursor:pointer" onclick="scan('UserName',keywords.value)">
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
                <td colspan="5" height="28">
                </td>
            </tr>
            <tr id="titlediv" class="td1" style="position: absolute">
                <td width="50" align="center">
                    选择
                </td>
                <td align="center">
                    设计人
                </td>
                <td align="center">
                    项目信息
                </td>
                <td align="center">
                    一般性错误
                </td>
                <td align="center">
                    技术性错误
                </td>
                <td align="center">
                    原则性错误
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
            <asp:Repeater ID="ProjectList" runat="server">
                <ItemTemplate>
                    <tr class="tr1">
                        <td align="center">
                            <input class="sel" id="CheckBoxAll" type="checkbox" />
                        </td>
                        <td><%#Eval("UserName")%></td>
                        <td style="text-align:left" class="underline" onclick="parent.window.open('views/DesignTask_Correct.aspx?type=read&taskid=<%#Eval("DesignTaskID") %>')"><%#Eval("ProjectNo")%>  <%#Eval("ProjectName")%>   <%#Eval("DT_TuHao")%></td>
                        <td><%#Eval("ErrorNum1")%></td>
                        <td><%#Eval("ErrorNum2")%></td>
                        <td><%#Eval("ErrorNum3")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr class="tr1">
            <td></td><td><b>合计</b></td><td></td>
            <td><asp:Label ID="Label1" runat="server" Font-Bold=true Text=""></asp:Label></td>
            <td><asp:Label ID="Label2" runat="server" Font-Bold=true Text=""></asp:Label></td>
            <td><asp:Label ID="Label3" runat="server" Font-Bold=true Text=""></asp:Label></td>
            </tr>
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
        <input id="Button1" runat="server" class="none delete" onclick="if(confirm('您确定要删除吗?')){if(typeof(sel)!='undefined')checkall(sel,0,'?del=1')}"
            type="button" />
    </div>
</form>
</body>
</html>
