﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectDocument_List.aspx.cs"
    Inherits="Web.views.ProjectDocument_list" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ OutputCache Location="None" VaryByParam="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=6" />
    <title>网上提资</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<script type="text/javascript">
    var msgdiv = "";
    function InputDesigner(id) {
        if ($("#msgdiv").html() != "") {
            msgdiv = $("#msgdiv").html();
            $("#msgdiv").html("");
        }
        var htmlStr = msgdiv;
        $$.MsgBox("提资发送", htmlStr, "确定:submit(" + id + ")", "取消");
    }
    function submit(id) {
        if (Designer.value != "") location.href = "?id=" + id + "&Designer=" + Designer.value;
    }
    </script>
    <div id="msgdiv" class="none">
            <div style="margin: 15px; width: 200px; font-size: 12px;">
                <asp:DropDownList ID="Designer" runat="server" CssClass="select">
                </asp:DropDownList>
            </div>
    </div>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="background: url(../images/list-title-bg.png) repeat-x;">
        <tr>
            <td class="sousuo">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="20%" height="36">
                            <span style="font-weight: bold; margin-left: 10px;">质量管理 <span style="font-family: SimSun">
                                >> </span>网上提资 </span>
                        </td>
                        <td align="right">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="20" limit="ProjectDocument_Add">
                                        <img src="../images/application_form_add.png" alt="新增" />
                                    </td>
                                    <td width="84" limit="ProjectDocument_Add">
                                        <span onclick="parent.window.open('../views/ProjectDocument_Add.aspx')" style="cursor: pointer;">
                                            新增网上提资</span>
                                    </td>
                                    <td width="20" style="cursor: pointer">
                                        <img src="../images/refresh-icon.png" alt="刷新" />
                                    </td>
                                    <td width="36" style="cursor: pointer" onclick="location.reload()">
                                        刷新
                                    </td>
                                    <td width="147">
                                        <input runat="server" type="text" style="color:#ccc;height: 20px; width: 145px; border: 1px solid #8a8a8a;line-height: 20px;font-size:12px"
                                            id="keywords" value="提资用户/专业名称" onfocus="this.value=''" name="keywords" />
                                    </td>
                                    <td width="48">
                                        <a style="display: block; width: 40px; padding: 2px 0; background: #93bc12; border: 1px solid #7b9e0d;
                                            color: #fff; text-align: center;cursor:pointer" onclick="scan('UserName,ClassName',keywords.value)">
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
                <td>
                    提资用户
                </td>
                <td >
                    项目名称
                </td>
                <td>
                    受资专业
                </td>
                <td>
                    提资名称
                </td>
                <td>
                    提资文件
                </td>
                <td>
                    备注内容
                </td>
                <td>
                    节点
                </td>
                <td>
                    节点用户
                </td>
                <td>
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
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tr1">
                        <td style="padding: 3px 0" align="center" height="25">
                            <input class="sel" id="CheckBoxAll" type="checkbox" />
                        </td>
                        <td align="center">
                                <%#Eval("UserName") %>
                        </td>
                        <td>
                            <%#Eval("ProjectName")%>
                        </td>
                        <td>
                            <%#Eval("ClassName") %>
                        </td>
                        <td>
                            <%#Eval("PD_Name") %>[<%#Eval("PD_FileNo") %>]
                        </td>
                        <td>
                        <a class="underline" onclick="window.external.download('<%#Eval("PD_File") %>','<%#Eval("PD_File") %>',true)">查看</a> 
                        </td>
                        <td title="<%#Eval("remark") %>" onclick="$$.MsgBox('<%#Eval("remark") %>')">
                            详情
                        </td>
                        <td>
                            <%#Eval("Status")%>
                            <a class="underline <%#Eval("Status").ToString()=="发送设计人"?"":"none"%>  <%#Eval("PD_Users").ToString()==WebCommon.Public.GetUserName()?"":"none"%>" onclick="InputDesigner(<%#Eval("ID")%>)">发送</a> 
                        </td>
                        <td>
                            <%#Eval("PD_Users")%>
                        </td>
                        <td align="center">
                            <a class="underline <%#Eval("Status").ToString()=="异议返回"?"":"none"%>" onclick="if(confirm('确定要删除吗？')) location.href='?limit=del&id=<%#Eval("ID")%>'">删除</a> 
                            <a class="underline <%#Eval("Status").ToString()=="异议返回"?"":"none"%>" onclick="parent.window.open('../views/ProjectDocument_Edit.aspx?id=<%#Eval("ID")%>')">修改</a> 
                            <a class="underline <%#Eval("Status").ToString().Contains("审核")?"":"none"%> <%#Eval("PD_Users").ToString()==WebCommon.Public.GetUserName()?"":"none"%>" href="?type=通过&id=<%#Eval("ID")%>">通过</a> 
                            <a class="underline <%#Eval("Status").ToString().Contains("审核")?"":"none"%> <%#Eval("PD_Users").ToString()==WebCommon.Public.GetUserName()?"":"none"%>" href="?type=不通过&id=<%#Eval("ID")%>">不通过</a>
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
    </form>
    
    <script type="text/javascript">
        $(function () {
            //按钮权限验证
            CheckLimit("<%=WebCommon.Public.GetUserLimit().ToLower()%>");
        });
</script>
</body>
</html>
