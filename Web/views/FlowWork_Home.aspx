<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowWork_Home.aspx.cs"
    Inherits="Web.views.FlowWork_Home" %>

<%@ OutputCache Location="None" VaryByParam="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=6" />
    <title>工作计划</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <style type="text/css">
        td { height: 20px; }
        #weekworklist, #weekworklist2 { margin: 0; padding: 0; padding-left: 20px; padding-top: 10px; list-style: none; }
        #weekworklist li, #weekworklist2 li { display: inline; float: left; margin-right: 10px; margin-top: 10px; width: 170px; height: 230px; background: #efefef; border: 1px solid #ccc; }
        #weekworklist li h3, #weekworklist2 li h3 { margin: 0; margin-bottom: 20px; height: 32px; line-height: 32px; }
    </style>
    <script type="text/javascript">
        window.onload = function ()
        {
            var h = document.documentElement.offsetHeight;
            document.getElementById("weekworklist").style.height = h + "px";
            document.getElementById("weekworklist2").style.height = h + "px";
        }
        window.onresize = function ()
        {
            var h = document.documentElement.offsetHeight;
            document.getElementById("weekworklist").style.height = h + "px";
            document.getElementById("weekworklist2").style.height = h + "px";
        }
    </script>
</head>
<body>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="background: url(../images/list-title-bg.png) repeat-x;">
        <tr>
            <td class="sousuo">
                <table width="100%" height="32" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <span style="font-weight: bold; margin-left: 10px;">>> 项目主线工作 </span>
                        </td>
                        <td>
                            <span style="font-weight: bold; margin-left: 10px;">>> 项目设计工作 </span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div>
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td width="50%">
                    <ul id="weekworklist" style="padding-bottom: 60px; overflow-y: scroll">
                        <asp:Repeater ID="Rep_List" runat="server">
                            <ItemTemplate>
                                <li>
                                    <table cellpadding="0" cellspacing="0" border="0" width="170">
                                        <tr>
                                            <td title="<%#Eval("ProjectName")%>" colspan="2" style="border:0;padding:5px 0;color: #fff; background: #404040" align="center">
                                                <%#WebCommon.Public.CutStr(Eval("ProjectName").ToString(),14)%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" height="18">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                业务经理：
                                            </td>
                                            <td width="100">
                                                <%#Eval("ProjectManager")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                当前节点：
                                            </td>
                                            <td>
                                                <%#Eval("NodeNo")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                节点人员：
                                            </td>
                                            <td title="<%#Eval("NodeUser")%>">
                                                <%#WebCommon.Public.CutStr(Eval("NodeUser").ToString(),7)%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                项目状态：
                                            </td>
                                            <td>
                                                <%#Eval("Status")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                流 程 图：
                                            </td>
                                            <td>
                                                <span onclick="parent.window.open('views/Project_Flow.aspx?ProjectID=<%#Eval("ID")%>')" class="underline" style="cursor:pointer">查看</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                项目信息：
                                            </td>
                                            <td>
                                                <span onclick="parent.window.open('views/Project_Edit.aspx?type=read&id=<%#Eval("ID")%>')" class="underline" style="cursor:pointer">查看</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                主设信息：
                                            </td>
                                            <td>
                                                <span onclick="parent.window.open('views/ProjectDesigner_Confirm.aspx?type=read&ProjectID=<%#Eval("ID")%>')" class="underline" style="cursor:pointer">查看</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center"><br>
<input style="margin-bottom:5px" class="<%#Eval("NodeNo").ToString()!="发起合同评审"?"none":"block"%>" type="button" onclick="parent.window.open('views/FlowWork_Add.aspx?type=read&FlowID=39&ProjectID=<%#Eval("ID")%>')" value="发起合同评审" />
<input style="margin-bottom:5px" class="<%#Eval("NodeNo").ToString()!="发起合同评审"?"none":"block"%>" type="button" onclick="location.href='?Type=cancel&ProjectID=<%#Eval("ID")%>'" value="撤回" />
<input style="margin-bottom:5px" class="<%#Eval("NodeNo").ToString()!="合同评审处理"?"none":"block"%>" type="button" onclick="parent.window.open('views/FlowWork_Deal.aspx?ProjectID=<%#Eval("ID")%>')" value="合同评审处理" />
<input style="margin-bottom:5px" class="<%#Eval("NodeNo").ToString()!="上传合同"?"none":"block"%>" type="button" onclick="parent.window.open('views/ProjectContract_Add.aspx?ProjectID=<%#Eval("ID")%>')" value="上传合同" />
<input style="margin-bottom:5px" class="<%#Eval("NodeNo").ToString()!="确认设总"?"none":"block"%>" type="button" onclick="parent.window.open('views/Project_Edit2.aspx?ProjectID=<%#Eval("ID")%>')" value="确认设总" />
<input style="margin-bottom:5px" class="<%#Eval("NodeNo").ToString()!="设总人员审批"?"none":"block"%>" type="button" onclick="parent.window.open('views/Project_Edit3.aspx?type=read&ProjectID=<%#Eval("ID")%>')" value="设总人员审批" />
<input style="margin-bottom:5px" class="<%#Eval("NodeNo").ToString()!="确认主设"?"none":"block"%>" type="button" onclick="parent.window.open('views/ProjectDesigner_Add.aspx?ProjectID=<%#Eval("ID")%>')" value="确认主设" />
<input style="margin-bottom:5px" class="<%#Eval("NodeNo").ToString()!="主设人员审批"?"none":"block"%>" type="button" onclick="parent.window.open('views/ProjectDesigner_Confirm.aspx?ProjectID=<%#Eval("ID")%>')" value="主设人员审批" />
<input style="margin-bottom:5px" class="<%#Eval("NodeNo").ToString()!="卷册任务执行"?"none":"block"%>" type="button" onclick="parent.window.open('views/DesignTask_Add.aspx?ProjectID=<%#Eval("ID")%>&ClassName=水工专业')" value="卷册任务书录入" />
<input style="margin-bottom:5px" class="<%#Eval("NodeNo").ToString()!="卷册任务执行"?"none":"block"%> <%#CheckLeader(Eval("ID"))?"":"none"%>" type="button" onclick="parent.window.open('views/DesignTask_Confirm.aspx?ProjectID=<%#Eval("ID")%>&ClassName=水工专业')" value="卷册任务书审批" />
<input style="margin-bottom:5px" class="<%#Eval("NodeNo").ToString()!="卷册任务执行"?"none":"block"%>" type="button" onclick="location.href='DesignTask_List2.aspx?ProjectID=<%#Eval("ID")%>'" value="设计工作处理" />
<input style="margin-bottom:5px" class="<%#Eval("NodeNo").ToString()!="项目结束并存档"?"none":"block"%>" type="button" onclick="location.href='?Type=save&ProjectID=<%#Eval("ID")%>'" value="项目结束并存档" /><br>
                                            <br></td>
                                        </tr>
                                    </table>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </td>
                <td width="50%">
                    <ul id="weekworklist2" style="padding-bottom: 60px; overflow-y: scroll">
                        <asp:Repeater ID="Rep_List2" runat="server">
                            <ItemTemplate>
                                <li>
                                    <table cellpadding="0" cellspacing="0" border="0" width="170">
                                        <tr>
                                            <td title="<%#Eval("ProjectName")%>" colspan="2" style="border:0;padding:5px 0;color: #fff; background: #404040" align="center">
                                                <%#WebCommon.Public.CutStr(Eval("ProjectName").ToString(),14)%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" height="18">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                业务经理：
                                            </td>
                                            <td width="100">
                                                <%#Eval("ProjectManager")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                当前节点：
                                            </td>
                                            <td>
                                                <%#Eval("NodeNo")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                节点人员：
                                            </td>
                                            <td title="<%#Eval("NodeUser")%>">
                                                <%#WebCommon.Public.CutStr(Eval("NodeUser").ToString(),7)%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                项目状态：
                                            </td>
                                            <td>
                                                <%#Eval("Status")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                流 程 图：
                                            </td>
                                            <td>
                                                <span onclick="parent.window.open('views/Project_Flow.aspx?ProjectID=<%#Eval("ID")%>')" class="underline" style="cursor:pointer">查看</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                项目信息：
                                            </td>
                                            <td>
                                                <span onclick="parent.window.open('views/Project_Edit.aspx?type=read&id=<%#Eval("ID")%>')" class="underline" style="cursor:pointer">查看</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                主设信息：
                                            </td>
                                            <td>
                                                <span onclick="parent.window.open('views/ProjectDesigner_Confirm.aspx?type=read&ProjectID=<%#Eval("ID")%>')" class="underline" style="cursor:pointer">查看</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center"><br>
                                                <input onclick="location.href='DesignTask_List2.aspx?ProjectID=<%#Eval("ID")%>'" type="button" value="查看并处理工作" />
                                            </td>
                                        </tr>
                                    </table>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
