<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowWork_List.aspx.cs"
    Inherits="Web.views.FlowWork_list" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ OutputCache Location="None" VaryByParam="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=6" />
    <title>工作管理</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".结束").text("查看");
        });
    </script>
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
            $$.MsgBox("", htmlStr, "确定:submit()", "取消");
        }
        function submit() {
            var whereStr = "1=1";
            if (Radio1.checked) whereStr += " and ProjectID<>0";
            if (Radio2.checked) whereStr += " and ProjectID=0";
            if (Radio3.checked) whereStr += " and status='进行中'";
            if (Radio4.checked) whereStr += " and status='已结束'";
            location.href = "?where=" + whereStr;
        }
    </script>
    <div id="msgdiv" class="none">
    <div style="margin:15px;width:270px;font-size:12px;padding-left:20px">
         项目类型：<input name="type1" id="Radio1" type="radio" value="1" />项目工作<input name="type1" id="Radio2" type="radio" value="0" />普通工作
         <div style="height:10px"></div>
         项目状态：<input name="type2" id="Radio3" type="radio" value="1" />进行中<input name="type2" id="Radio4" type="radio" value="0" />已结束
    </div>
    </div>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="background: url(../images/list-title-bg.png) repeat-x;">
        <tr>
            <td class="sousuo">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="20%" height="36">
                            <span style="font-weight: bold; margin-left: 10px;">生产管理 <span style="font-family: SimSun">
                                >> </span>工作管理 </span>
                        </td>
                        <td align="right">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="20" limit="FlowWork_add">
                                        <img src="../images/application_form_add.png" alt="新增" />
                                    </td>
                                    <td width="60" limit="FlowWork_add">
                                        <span onclick="parent.window.open('../views/FlowWork_add.aspx')" style="cursor: pointer;">
                                            新增工作</span>
                                    </td>
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
                                        <input runat="server" type="text" style="color:#ccc;height: 20px; width: 145px; border: 1px solid #8a8a8a;line-height: 20px;font-size:12px"
                                            id="keywords" value="工作名称/节点编号" onfocus="this.value=''" name="keywords" />
                                    </td>
                                    <td width="48">
                                        <a style="display: block; width: 40px; padding: 2px 0; background: #93bc12; border: 1px solid #7b9e0d;
                                            color: #fff; text-align: center;cursor:pointer" onclick="scan('WorkName,NodeNo',keywords.value)">
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
                <td width="50">
                    选择
                </td>
                <td width="80" align="center">
                    项目名称
                </td>
                <td align="center">
                    工作名称
                </td>
                <td align="center">
                    工作流程
                </td>
                <td  align="center">
                    节点名称
                </td>
                <td width="50" align="center">
                    节点编号
                </td>
                <td align="center">
                    节点用户
                </td>
                <td width="50" align="center">
                    节点状态
                </td>
                <td width="50" align="center">
                    工作状态
                </td>
                <td width="80" align="center">
                    发起时间
                </td>
                <td width="80">
                    操作
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
            <asp:Repeater ID="Rep_List" runat="server">
                <ItemTemplate>
                    <tr class="tr1">
                        <td height="25" align="center">
                            <input class="sel" id="CheckBoxAll" type="checkbox" />
                        </td>
                        <td>
                            <%#Eval("ProjectName")%>
                        </td>
                        <td align="center">
                            <%#Eval("WorkName") %>
                        </td>
                        <td>
                            <%#Eval("FlowName")%>
                        </td>
                        <td align="center">
                            <%#Eval("NodeName")%>
                        </td>
                        <td>
                            <%#Eval("NodeNo") %>
                        </td>
                        <td title="<%#Eval("NodeUser") %>">
                            <%#WebCommon.Public.CutStr(Eval("NodeUser").ToString(),6) %>
                        </td>
                        <td>
                            <%#Eval("NodeStatus") %>
                        </td>
                        <td>
                            <%#Eval("Status") %>
                        </td>
                        <td>
                            <%#Convert.ToDateTime(Eval("AddDate")).ToString("yyyy-MM-dd") %>
                        </td>
                        <td align="center">
                            <a href="#" onclick="parent.window.open('../views/Flow_Show.aspx?flowid=<%#Eval("FlowID")%>&nodeid=<%#Eval("NodeID")%>')"  style="text-decoration: underline;">流程图</a> 
                            <a limit="FlowWork_Edit" href="#" onclick="parent.window.open('../views/FlowWork_Edit.aspx?id=<%#Eval("ID")%>')" target="_blank" style="text-decoration: underline;display:none">修改</a> 
                            <a limit="FlowWork_Deal" href="#" onclick="parent.window.open('../views/FlowWork_Deal.aspx?id=<%#Eval("ID")%>')" class="<%#Eval("Status")%>" style="text-decoration: underline;">办理</a> 
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
        <input id="Checkbox1" runat="server" class="selectAll" name="checkbox" type="checkbox" onclick="if(this.checked){$('.sel').attr('checked','checked')}else{$('.sel').removeAttr('checked')}" />
        <span>全选</span>
        <input id="Button1" runat="server" class="none delete" onclick="if(confirm('您确定要删除吗?')){if(typeof(sel)!='undefined')checkall(sel,0,'?del=1')}"
            type="button" />
    </div>
    <script type="text/javascript">
        $(function () {
            //按钮权限验证
            CheckLimit("<%=WebCommon.Public.GetUserLimit().ToLower()%>");
        });
</script>
</form>
</body>
</html>
