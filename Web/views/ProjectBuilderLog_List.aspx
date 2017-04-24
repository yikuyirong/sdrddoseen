<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectBuilderLog_List.aspx.cs" Inherits="Web.views.ProjectBuilderLog_List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ OutputCache Location="None" VaryByParam="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=6" />
    <title>施工日志</title>
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
        $$.MsgBox("", htmlStr, "确定:submit()", "取消");
    }
    function submit() {
        var whereStr = "1=1";
        if (time1 != "" && time2 != "") whereStr += " and PBL_Time>='" + time1.value + "' and PBL_Time<='" + time2.value + "'";
        location.href = "?where=" + whereStr;
    }
    </script>
    <div id="msgdiv" class="none">
    <div style="margin:15px;width:270px;font-size:12px;padding-left:20px">
         时间：<input id="time1" type="text" value="" class="input1" onfocus="calendar.setHook(this)" />～<input id="time2" type="text" value="" class="input1" onfocus="calendar.setHook(this)" />
    </div>
    </div>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="background: url(../images/list-title-bg.png) repeat-x;">
        <tr>
            <td class="sousuo">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="36">
                            <span style="font-weight: bold; margin-left: 10px;">总承包管理 <span style="font-family: SimSun">
                                >> </span>施工日志管理 </span>
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
                                    <td width="20" limit="ProjectBuilderLog_Add">
                                        <img src="../images/application_form_add.png" alt="新增" />
                                    </td>
                                    <td width="60" limit="ProjectBuilderLog_Add">
                                        <span onclick="parent.window.open('../views/ProjectBuilderLog_Add.aspx')" style="cursor: pointer;">
                                            新增日志</span>
                                    </td>
                                    <td width="20" style="cursor: pointer">
                                        <img src="../images/refresh-icon.png" alt="刷新" />
                                    </td>
                                    <td width="36" style="cursor: pointer" onclick="location.reload()">
                                        刷新
                                    </td>
                                    <td width="147">
                                        <input runat="server" value="项目编号/项目名称" onfocus="this.value=''" type="text" style="color:#ccc;height: 20px; width: 145px; border: 1px solid #8a8a8a;line-height: 20px;font-size:12px" id="keywords" name="keywords" />
                                    </td>
                                    <td width="48">
                                        <a style="display: block; width: 40px; padding: 2px 0; background: #93bc12; border: 1px solid #7b9e0d;
                                            color: #fff; text-align: center; cursor: pointer" onclick="scan('ProjectID',keywords.value)">
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
                <td colspan="4" height="28">
                </td>
            </tr>
            <tr id="titlediv" class="td1" style="position: absolute">
                <td width="50">
                    选择
                </td>
                <td align="center">
                    工程名称
                </td>
                <td align="center">
                    日期
                </td>
                <td align="center">
                    天气/温度/风力
                </td>
                <td width="100" align="center">
                    组织安排
                </td>
                <td width="100" align="center">
                    施工情况
                </td>
                <td width="100" align="center">
                    协助请求
                </td>
                <td width="100" align="center">
                    操作
                </td>
            </tr>
            <script type="text/javascript">
                function mymove()
                {
                    var isIE = !!window.ActiveXObject;
                    var isIE6 = isIE && !window.XMLHttpRequest;
                    var titlediv = document.getElementById("titlediv");
                    var maindiv = document.getElementById("maindiv");
                    if (isIE6)
                    {
                        titlediv.style.top = maindiv.scrollTop;
                    }
                    else
                    {
                        titlediv.style.top = maindiv.scrollTop;
                    }
                }
                mymove();
            </script>
            <asp:Repeater ID="ProjectList" runat="server">
                <ItemTemplate>
                    <tr class="tr1">
                        <td height="25" align="center">
                            <input class="sel" id="CheckBoxAll" type="checkbox" />
                        </td>
                        <td>
                            <%#Eval("ProjectName")%>
                        </td>
                        <td>
                            <%#Convert.ToDateTime(Eval("PBL_Time")).ToString("yyyy-MM-dd")%>
                        </td>
                        <td align="left">
                            <%#Eval("PBL_Whether")%> -
                            <%#Eval("PBL_Wind")%> -
                            <%#Eval("PBL_Wind")%>
                        </td>
                        <td title="<%#Eval("PBL_Info1")%>">
                            查看　<span class="underline <%#Eval("PBL_Info1File").ToString()!=""?"":"none"%>" onclick="window.external.download('<%#Eval("PBL_Info1File")%>','<%#Eval("PBL_Info1File")%>',true)">附件</span>
                        </td>
                        <td title="<%#Eval("PBL_Info2")%>">
                            查看　<span class="underline <%#Eval("PBL_Info2File").ToString()!=""?"":"none"%>" onclick="window.external.download('<%#Eval("PBL_Info2File")%>','<%#Eval("PBL_Info2File")%>',true)">附件</span>
                        </td>
                        <td title="<%#Eval("PBL_Info3")%>">
                            查看　<span class="underline <%#Eval("PBL_Info3File").ToString()!=""?"":"none"%>" onclick="window.external.download('<%#Eval("PBL_Info3File")%>','<%#Eval("PBL_Info3File")%>',true)">附件</span>
                        </td>
                        <td>
                            <a limit="ProjectBuilderLog_Edit" href="#"  onclick="parent.window.open('../views/ProjectBuilderLog_Edit.aspx?id=<%#Eval("ID")%>')" style="text-decoration: underline;">
                                编辑</a> <a limit="ProjectBuilderLog_List.del" href="#" onclick="if(confirm('确定要删除吗？')) location.href='?limit=del&id=<%#Eval("ID")%>'" style="text-decoration: underline;">
                                删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <webdiyer:AspNetPager ID="AspNetPager1" UrlPaging="true" runat="server" ShowFirstLast="true"
        LayoutType="Div" CssClass="pager" PageIndexBoxClass="PageSelect" CurrentPageButtonClass="PageSel">
    </webdiyer:AspNetPager>
    <div class="btmdo">
        <input class="selectAll" name="checkbox" type="checkbox" onclick="if(this.checked){$('.sel').attr('checked','checked')}else{$('.sel').removeAttr('checked')}" />
        <span>全选</span>
        <input class="none delete" onclick="if(confirm('您确定要删除吗?')){if(typeof(sel)!='undefined')checkall(sel,0,'?del=1')}"
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