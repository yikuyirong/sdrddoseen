<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DesignTask_list2.aspx.cs"
    Inherits="Web.views.DesignTask_list2" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ OutputCache Location="None" VaryByParam="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=6" />
    <title>卷册任务执行</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server" style="height:100%">
<script type="text/javascript">
    var msgdiv = "";
    function InputDesigner(id) {
        if ($("#msgdiv").html() != "") {
            msgdiv = $("#msgdiv").html();
            $("#msgdiv").html("");
        }
        var htmlStr = msgdiv;
        $$.MsgBox("会签发送", htmlStr, "发起会签:submit(" + id + ")", "转入审核:subpass(" + id + ")");
    }
    function submit(id) {
        if (Designer.value != "") {
            o = document.getElementById("Designer");
            var DesignerStr = "";
            for (i = 0; i < o.length; i++) {
                if (o.options[i].selected) {
                    DesignerStr += o.options[i].value + ",";
                }
            }
            window.open("?id=" + id + "&Designer=" + DesignerStr, "hidefrm");
            setTimeout(function () { location.reload(); }, 1000);
            $$.MsgBox(0);
        }
    }
    function subpass(id) {
        window.open("?id=" + id + "&Designer=审核", "hidefrm");
        setTimeout(function () { location.reload(); }, 1000);
            $$.MsgBox(0);
    }
    </script>
    <div id="msgdiv" class="none">
            <div style="margin-top: 15px; width: 200px; font-size: 12px;">
                <asp:DropDownList ID="Designer" multiple="multiple" Height="300" runat="server" CssClass="select">
                </asp:DropDownList>
            </div>
    </div>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="background: url(../images/list-title-bg.png) repeat-x;">
        <tr>
            <td class="sousuo">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="20%" height="36">
                            <span style="font-weight: bold; margin-left: 10px;">生产管理 <span style="font-family: SimSun">
                                >> </span>卷册任务</span>
                        </td>
                        <td align="right">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="20" style="cursor: pointer">
                                        <img src="../images/application_form_magnify.png" alt="后退" />
                                    </td>
                                    <td width="36" style="cursor: pointer" onclick="location.href='DesignTask_List2.aspx'">
                                        后退
                                    </td>
                                    <td width="22" style="cursor: pointer">
                                        <img src="../images/refresh-icon.png" alt="刷新" />
                                    </td>
                                    <td width="36" style="cursor: pointer" onclick="location.reload()">
                                        刷新
                                    </td>
                                   <td width="147">
                                        <input type="text" style="color:#ccc;height: 20px; width: 145px; border: 1px solid #8a8a8a;line-height: 20px;font-size:12px"
                                            id="keywords" value="项目名称/人员名称" onfocus="this.value=''" name="keywords" />
                                    </td>
                                    <td width="48">
                                        <a style="display: block; width: 40px; padding: 2px 0; background: #93bc12; border: 1px solid #7b9e0d;
                                            color: #fff; text-align: center;cursor:pointer" onclick="scan('ProjectName,NodeUser,DT_SheJiRen,DT_JiaoDuiRen,DT_ShenHeRen,DT_ShenDingRen',keywords.value)">
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
                    专业名称
                </td>
                <td align="center">
                    设总
                </td>
                <td align="center">
                    主设
                </td>
                <td align="center">
                    设计人
                </td>
                <td align="center">
                    校审人
                </td>
                <td align="center">
                    节点用户
                </td>
                <td align="center">
                    上次状态
                </td>
                <td align="center">
                    <asp:DropDownList ID="Status1" runat="server" AutoPostBack="true"
                        onselectedindexchanged="Status1_SelectedIndexChanged">
                        <asp:ListItem Value="">全部状态</asp:ListItem>
                        <asp:ListItem Value="等待设计">等待设计</asp:ListItem>
                        <asp:ListItem Value="等待校对">等待校对</asp:ListItem>
                        <asp:ListItem Value="等待审核">等待审核</asp:ListItem>
                        <asp:ListItem Value="等待会签">等待会签</asp:ListItem>
                        <asp:ListItem Value="等待审定">等待审定</asp:ListItem>
                        <asp:ListItem Value="结束">结束</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="center">
                    校审操作
                </td>
                <td width="90" align="center">
                    设计操作
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
                        <td align="center" width="90">
                            <%#Eval("ProjectName")%>
                        </td>
                        <td width="120">
                            <%#Eval("ID")%><br>
                            <%#Eval("ClassName1")%><br>
                            <%#Eval("ClassName2")%><br>
                            <%#Eval("ClassName3")%><br><%#Eval("DT_TuHao")%>
                        </td>
                        <td>
                            <%#Eval("DesignManager")%>
                        </td>
                        <td>
                            <%#Eval("DesignMain")%>
                        </td>
                        <td>
                            <%#Eval("DT_SheJiRen")%>
                        </td>
                        <td>
                            校对人：<%#Eval("DT_JiaoDuiRen")%><br>
                            审核人：<%#Eval("DT_ShenHeRen")%><br>
                            审定人：<%#Eval("DT_ShenDingRen")%>
                        </td>
                        <td>
                            <%#Eval("NodeUser").ToString().Replace(",","<br>")%>
                        </td>
                        <td>
                            <%#Eval("StatusLast")%>
                        </td>
                        <td class="<%#Eval("Status")%>">
                            <%#Eval("Status")%>
                        </td>
                        <td>
                            <a href="DesignCorrect_List.aspx?where=designtaskid=<%#Eval("ID") %>" class="underline">设计校审</a>
                        </td>
                        <td align="center"><iframe frameborder="0" width="0" height="0" name="hidefrm"></iframe>
                        <a class="underline <%#Eval("Status").ToString()=="等待会签"?"":"none"%>  <%#Eval("DT_SheJiRen").ToString()==WebCommon.Public.GetUserName()?"":"none"%>  <%#Eval("NodeUser").ToString()==WebCommon.Public.GetUserName()?"":"none"%>" onclick="InputDesigner(<%#Eval("ID") %>)">发起会签</a> 
                        <span class="underline <%#Eval("DT_SheJiRen").ToString()!=WebCommon.Public.GetUserName()?"none":"block"%> <%#Eval("status").ToString()!="等待设计"?"none":"block"%>" onclick="parent.window.open('../views/DesignTask_Upload.aspx?type=sheji&id=<%#Eval("ID")%>')">上传文件</span> 
                        <span class="underline <%#Eval("status").ToString()!="结束"?"none":"block"%>" onclick="parent.window.open('views/DesignTask_Correct.aspx?taskid=<%#Eval("ID") %>')">校审核验单</span> 
                        <span class="underline <%#Eval("status").ToString()!="结束"?"none":"block"%>" onclick="parent.window.open('views/DesignTask_Correct2.aspx?type=read&taskid=<%#Eval("ID") %>')">会签单</span>
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
<script>
$(function(){
$(".任务录入").css("color","gray");
$(".任务审批").css("color","black");
$(".等待设计").css("color","green");
$(".等待校对").css("color","orange");
$(".等待审核").css("color","blue");
$(".等待会签").css("color", "#ffdd00");
$(".等待审定").css("color","red");
$(".结束").css("color","gray");
});
</script>
</body>
</html>
