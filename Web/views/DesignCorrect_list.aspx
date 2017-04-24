<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DesignCorrect_List.aspx.cs"
    Inherits="Web.views.DesignCorrect_list" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ OutputCache Location="None" VaryByParam="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=6" />
    <title>电子校审</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
</head>
<body>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="background: url(../images/list-title-bg.png) repeat-x;">
        <tr>
            <td class="sousuo">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="20%" height="36">
                            <span style="font-weight: bold; margin-left: 10px;">质量管理 <span style="font-family: SimSun">
                                >> </span>电子校审 </span>
                        </td>
                        <td align="right">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="20" style="cursor: pointer">
                                        <img src="../images/application_form_magnify.png" alt="后退" />
                                    </td>
                                    <td width="36" style="cursor: pointer" onclick="location.href='<%=WebCommon.Public.GetFromUrl()%>'">
                                        后退
                                    </td>
                                    <td width="20" style="cursor: pointer">
                                        <img src="../images/refresh-icon.png" alt="刷新" />
                                    </td>
                                    <td width="36" style="cursor: pointer" onclick="location.reload()">
                                        刷新
                                    </td>
                                    <td width="147">
                                        <input runat="server" type="text" style="color:#ccc;height: 20px; width: 145px; border: 1px solid #8a8a8a;line-height: 20px;font-size:12px"
                                            id="keywords" value="用户名" onfocus="this.value=''" name="keywords" />
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
                <td colspan="6" height="28">
                </td>
            </tr>
            <tr id="titlediv" class="td1" style="position: absolute">
                <td width="50" align="center">
                    选择
                </td>
                <td width="100" align="center">
                    用户信息
                </td>
                <td >
                    项目卷册任务
                </td>
                <td width="">
                    文件查看
                </td>
                <td width="" align="center">
                    节点用户
                </td>
                <td width="" align="center">
                    状态
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
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tr1">
                        <td style="padding: 3px 0" align="center" height="25">
                            <input class="sel" id="CheckBoxAll" type="checkbox" />
                        </td>
                        <td align="center">
                            设计人：<%#Eval("UserName") %><br>
                            校对人：<%#Eval("DT_JiaoDuiRen")%><br>
                            审核人：<%#Eval("DT_ShenHeRen")%><br>
                            审定人：<%#Eval("DT_ShenDingRen")%>
                        </td>
                        <td>
                            <%#Eval("ID")%><br>
                            <%#Eval("ProjectName")%><br>
                            <%#Eval("ProjectNo")%><br>
                            <%#Eval("ClassName1")%> - <%#Eval("dt_xuhao")%> - <%#Eval("dt_tuhao")%>
                        </td>
                        <td style="text-align:left">
                          <div class="<%#Eval("DC_File").ToString()==""?"none":"" %>">设计文件：<%#Eval("DC_FileTime") %> <span class="underline" onclick="window.external.download('<%#Eval("DC_File") %>','<%#Eval("DC_File") %>',false)">下载设计文件</span> <span class="underline <%#Eval("Status").ToString()=="等待校对"?"":"none" %>" onclick="parent.window.open('views/DesignTask_Upload.aspx?type=jiaodui&cid=<%#Eval("ID") %>')">上传校对文件</span></div>
                          <div class="<%#Eval("DC_File1").ToString()==""?"none":"" %>">校对文件：<%#Eval("DC_File1Time") %> <span class="underline" onclick="window.external.download('<%#Eval("DC_File1") %>','<%#Eval("DC_File1") %>',false)">下载校对文件</span> <span class="underline <%#Eval("Status").ToString()=="等待审核"?"":"none" %> <%#Eval("DT_ShenHeRen").ToString()==WebCommon.Public.GetUserName()?"":"none" %>" onclick="parent.window.open('views/DesignTask_Upload.aspx?type=shenhe&cid=<%#Eval("ID") %>')">上传审核文件</span>  <span class="underline <%#Eval("DC_File1CorrectInfo").ToString()==""?"none":"" %>" onclick="$$.MsgBox('校审结果','<div style=width:700px;padding:15px>校对人:<br><%#Eval("DC_File1CorrectInfo").ToString().Replace("\r\n","<br>") %><br><br>设计人:<br><%#Eval("DC_File1Correct").ToString().Replace("\r\n","<br>") %></div>')">查看校对意见</span></div>
                          <div class="<%#Eval("DC_File2").ToString()==""?"none":"" %>">审核文件：<%#Eval("DC_File2Time") %> <span class="underline <%#Eval("DC_File2").ToString()==""?"none":"" %>" onclick="window.external.download('<%#Eval("DC_File2") %>','<%#Eval("DC_File2") %>',false)">下载审核文件</span> <span class="underline <%#Eval("Status").ToString()=="等待审定"?"":"none" %> <%#Eval("DT_ShenDingRen").ToString()==WebCommon.Public.GetUserName()?"":"none" %>" onclick="parent.window.open('views/DesignTask_Upload.aspx?type=shending&cid=<%#Eval("ID") %>')">上传审定文件</span> <span class="underline <%#Eval("DC_File2CorrectInfo").ToString()==""?"none":"" %>" onclick="$$.MsgBox('校审结果','<div style=width:700px;padding:15px>审核人:<br><%#Eval("DC_File2CorrectInfo").ToString().Replace("\r\n","<br>") %><br><br>设计人:<br><%#Eval("DC_File2Correct").ToString().Replace("\r\n","<br>") %></div>')">查看审核意见</span></div>
                          <div class="">会签文件：<%#Eval("DC_File4Time") %> <span class="underline <%#Eval("DC_File4CorrectInfo").ToString()==""?"none":"" %>" onclick="window.external.download('<%#Eval("DC_File4") %>','<%#Eval("DC_File4") %>',false)">下载会签文件</span> <span class="underline <%#Eval("status").ToString()!="等待会签"?"none":"" %> <%#Eval("NodeUser").ToString().Contains(WebCommon.Public.GetUserName())?"":"none" %>" onclick="parent.window.open('views/DesignTask_Upload.aspx?type=huiqian&cid=<%#Eval("ID") %>')">我要会签</span> <span class="underline <%#Eval("DC_File4CorrectInfo").ToString()==""?"none":"" %>" onclick="$$.MsgBox('会签结果','<div style=width:700px;padding:15px>审核人:<br><%#Eval("DC_File4CorrectInfo").ToString().Replace("\r\n","<br>") %><br><br>设计人:<br><%#Eval("DC_File4Correct").ToString().Replace("\r\n","<br>") %></div>')">查看会签结果</span></div>
                          <div class="<%#Eval("DC_File3").ToString()==""?"none":"" %>">审定文件：<%#Eval("DC_File3Time") %> <span class="underline <%#Eval("DC_File3").ToString()==""?"none":"" %>" onclick="window.external.download('<%#Eval("DC_File3") %>','<%#Eval("DC_File3") %>',false)">下载审定文件</span> <span class="underline <%#Eval("DC_File3CorrectInfo").ToString()==""?"none":"" %>" onclick="$$.MsgBox('校审结果','<div style=width:700px;padding:15px>审定人:<br><%#Eval("DC_File3CorrectInfo").ToString().Replace("\r\n","<br>") %><br><br>设计人:<br><%#Eval("DC_File3Correct").ToString().Replace("\r\n","<br>") %></div></div>')">查看审定意见</span></div>
                        </td>
                        <td>
                            <%#Eval("NodeUser")%>
                        </td>
                        <td class="<%#Eval("Status")%>">
                            <%#Eval("Status")%>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
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

<script>
$(function(){
$(".任务录入").css("color","gray");
$(".任务审批").css("color","black");
$(".等待设计").css("color","green");
$(".等待校对").css("color","orange");
$(".等待审核").css("color","blue");
$(".等待会签").css("color","#ffdd00");
$(".等待审定").css("color","red");
$(".结束").css("color","gray");
});
</script>
</body>
</html>
