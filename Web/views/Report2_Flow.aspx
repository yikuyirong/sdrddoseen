<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report2_Flow_Flow.aspx.cs" Inherits="Web.views.Report2_Flow" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ OutputCache Location="None" VaryByParam="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=6" />
    <title>生产汇总</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
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
            if (Radio1.checked) whereStr += " and status='进行中'";
            if (Radio2.checked) whereStr += " and status='已结束'";
            location.href = "?where=" + whereStr;
        }
    </script>
    <div id="msgdiv" class="none">
    <div style="margin:15px;width:270px;font-size:12px;">
         项目状态：<input name="type1" id="Radio1" type="radio" value="进行中" />在办项目<input name="type1" id="Radio2" type="radio" value="结束" />已完项目
    </div>
    </div>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="background: url(../images/list-title-bg.png) repeat-x;">
        <tr>
            <td class="sousuo">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="20%" height="36">
                            <span style="font-weight: bold; margin-left: 10px;">经营管理 <span style="font-family: SimSun">
                                >> </span>统计报表 </span>
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
                                        <input runat="server" type="text" style="color:#ccc;height: 20px; width: 145px; border: 1px solid #8a8a8a;line-height: 20px;font-size:12px" value="项目流程" id="keywords" name="keywords"   onfocus="this.value=''"/>
                                    </td>
                                    <td width="48">
                                        <a style="display: block; width: 40px; padding: 2px 0; background: #93bc12; border: 1px solid #7b9e0d;
                                            color: #fff; text-align: center;cursor:pointer" onclick="scan('WorkName',keywords.value)">
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
                    项目流程
                </td>
                <td align="center">
                    任务情况
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
                        <td height="100" align="center">
                            <input class="sel" id="CheckBoxAll" type="checkbox" />
                        </td>
                        <td>                           
                                    <b><%#Eval("WorkName") %><%#Eval("ProjectID") %></b><br>
                                    <%#Eval("Status")%><br>
                                    当前节点编号：<%#Eval("NodeNo")%><br>
                                    当前节点用户：<%#Eval("NodeUser")%><br>
                                    当前节点状态：<%#Eval("NodeStatus")%>
                        </td>
                        <td style="text-align:left">
                            <asp:Repeater ID="DesginTask" runat="server">
                                <ItemTemplate>
                                    <%#Eval("ClassName1")%> - <%#Eval("DesignManager")%> - <%#Eval("DesignMain")%> - <%#Eval("DT_SheJiRen")%>（<%#Eval("DT_GuGong")%>天） - <%#Convert.ToDateTime(Eval("DT_SheJiTime")).ToString("yyyy-MM-dd")%> <br>
                                </ItemTemplate>
                            </asp:Repeater>
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
        <input id="Button1" runat="server" class="none delete" onclick="if(confirm('您确定要删除吗?')){if(typeof(sel)!='undefined')checkall(sel,0,'?del=1')}"
            type="button" />
    </div>
</form>
</body>
</html>
