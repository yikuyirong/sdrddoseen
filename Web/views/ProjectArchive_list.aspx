<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectArchive_List.aspx.cs"
    Inherits="Web.views.ProjectArchive_list" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ OutputCache Location="None" VaryByParam="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=6" />
    <title>档案管理</title>
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
                        <td height="36">
                            <span style="font-weight: bold; margin-left: 10px;">图档管理 <span style="font-family: SimSun">
                                >> </span>档案管理 </span>
                        </td>
                        <td align="right">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr id="toplist" runat="server">
                                    <td width="20">
                                        <img src="../images/application_form_add.png" alt="筛选" />
                                    </td>
                                    <td width="36">
                                        <span onclick="parent.window.open('../views/ProjectArchive_Search.aspx')" style="cursor: pointer;">
                                            筛选</span>
                                    </td>
                                    <td width="20" limit="ProjectArchive_Add">
                                        <img src="../images/application_form_add.png" alt="新增" />
                                    </td>
                                    <td width="84" limit="ProjectArchive_Add">
                                        <span onclick="parent.window.open('../views/ProjectArchive_add.aspx')" style="cursor: pointer;">
                                            新增项目存档</span>
                                    </td>
                                    <td width="20" style="cursor: pointer">
                                        <img src="../images/refresh-icon.png" alt="刷新" />
                                    </td>
                                    <td width="36" style="cursor: pointer" onclick="location.reload()">
                                        刷新
                                    </td>
                                    <td width="147">
                                        <input runat="server" type="text" style="color:#ccc;height: 20px; width: 145px; border: 1px solid #8a8a8a;line-height: 20px;font-size:12px"
                                            id="keywords" value="档案名称/专业/卷册/档案类型" onfocus="this.value=''" name="keywords" />
                                    </td>
                                    <td width="48">
                                        <a style="display: block; width: 40px; padding: 2px 0; background: #93bc12; border: 1px solid #7b9e0d;
                                            color: #fff; text-align: center;cursor:pointer" onclick="scan('ClassName2,PA_Type1',keywords.value)">
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
                <td align="center">
                    项目名称
                </td>
                <td  align="center">
                    类目1
                </td>
                <td align="center">
                    类目2
                </td>
                <td align="center">
                    类目3
                </td>
                 <td  align="center">
                    档案名称
                </td>
                <td width="50" align="center">
                    类型
                </td>
                <td width="80" align="center">
                    状态
                </td>
                <td width="50" align="center">
                    密级
                </td>
                <td width="100">
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
                        <td style="padding: 3px 0" align="center">
                            <%#Eval("ProjectName")%>
                        </td>
                        <td>
                            <%#Eval("ClassName1") %>
                        </td>
                        <td>
                            <%#Eval("ClassName2")%>
                        </td>
                        <td>
                            <%#Eval("ClassName3")%>
                        </td>
                        <td align="center">
                                <%#Eval("PA_Name") %><br><%#Eval("AddDate") %>
                        </td>
                        <td>
                          <%#Eval("PA_Type2")%>  
                        </td>
                        <td>
                            <%#Eval("Status")%>
                        </td>  
                        <td>
                            <%#Eval("PA_Limit")%>
                        </td>                           
                        <td align="center" id="caozuo" runat="server">
                         <span limit="ProjectArchive_List.del" class="<%=limitShow%>"><a href="#" onclick="if(confirm('确定要删除吗？')) location.href='?limit=del&id=<%#Eval("ID")%>'"  style="text-decoration: underline;">删除</a> 
                         <a limit="ProjectArchive_Edit" class="underline" onclick="parent.window.open('../views/ProjectArchive_Edit.aspx?id=<%#Eval("ID")%>')">编辑</a> </span><br>
                         <a class="underline <%#Eval("PA_Type2").ToString()=="电子版"?"":"none"%> <%#Eval("PA_Limit").ToString()!="普通"?"none":""%>" onclick="window.external.download('<%#Eval("PA_File") %>','<%#Eval("PA_File") %>',true)">查看</a>
                         <a class="underline" onclick="parent.window.open('../views/ProjectArchiveRequest_add.aspx?limit=<%=Server.UrlEncode("借阅申请")%>&aid=<%#Eval("ID")%>')">借阅</a>
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
</body>
</html>
