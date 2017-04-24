<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectBuyAcount_List.aspx.cs"
    Inherits="Web.views.ProjectBuyAcount_list" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ OutputCache Location="None" VaryByParam="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=6" />
    <title>采购管理</title>
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
                            <span style="font-weight: bold; margin-left: 10px;">总承包管理 <span style="font-family: SimSun">
                                >> </span>采购管理 </span>
                        </td>
                        <td align="right">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="20" limit="ProjectBuyAcount_add">
                                        <img src="../images/application_form_add.png" alt="新增" />
                                    </td>
                                    <td width="60" limit="ProjectBuyAcount_add">
                                        <span onclick="parent.window.open('../views/ProjectBuyAcount_add.aspx')" style="cursor: pointer;">
                                            新增采购</span>
                                    </td>
                                    <td width="20" style="cursor: pointer">
                                        <img src="../images/refresh-icon.png" alt="刷新" />
                                    </td>
                                    <td width="36" style="cursor: pointer" onclick="location.reload()">
                                        刷新
                                    </td>
                                    <td width="147">
                                        <input runat="server" type="text" style="color: #ccc; height: 20px; width: 145px;
                                            border: 1px solid #8a8a8a; line-height: 20px; font-size: 12px" id="keywords"
                                            value="采购内容/采购联系人" onfocus="this.value=''" name="keywords" />
                                    </td>
                                    <td width="48">
                                        <a style="display: block; width: 40px; padding: 2px 0; background: #93bc12; border: 1px solid #7b9e0d;
                                            color: #fff; text-align: center; cursor: pointer" onclick="scan('PO_Content,PO_Link',keywords.value)">
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
                <td align="center">
                    采购联系人
                </td>
                <td align="center">
                    采购内容
                </td>
                <td align="center">
                    采购时间
                </td>
                <td width="80" align="center">
                    付款方式
                </td>
                <td width="80" align="center">
                    状态
                </td>
                <td width="100" align="center">
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
                        <td align="left">
                            <%#Eval("PO_Link") %>
                        </td>
                        <td align="left">
                            <%#Eval("PO_Content") %>
                        </td>
                        <td>
                            <%#Convert.ToDateTime(Eval("PO_StartTime")).ToString("yyyy-MM-dd")%>
                        </td>
                        <td>
                            <%#Eval("PO_FeeType") %>
                        </td>
                        <td>
                            <%#Eval("Status") %>
                        </td>
                        <td>
                            <a limit="ProjectBuyAcount_List.del" href="#" onclick="if(confirm('确定要删除吗？')) location.href='?limit=del&id=<%#Eval("ID")%>'" style="text-decoration: underline;">
                                删除</a> <a limit="ProjectBuyAcount_Edit" onclick="parent.window.open('../views/ProjectBuyAcount_Edit.aspx?id=<%#Eval("ID")%>')"
                                    target="_blank" style="text-decoration: underline;">编辑</a> <a onclick="parent.window.open('../views/ProjectBuyAcount_Edit.aspx?type=read&id=<%#Eval("ID")%>')"
                                        target="_blank" style="text-decoration: underline;">查看</a> <a onclick="parent.window.open('../views/ProjectBuyAcount_Edit.aspx?limt=read2&id=<%#Eval("ID")%>')"
                                        target="_blank" style="text-decoration: underline;">外看</a>
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
    <script type="text/javascript">
        $(function () {
            //按钮权限验证
            CheckLimit("<%=WebCommon.Public.GetUserLimit().ToLower()%>");
        });
</script>
</body>
</html>
