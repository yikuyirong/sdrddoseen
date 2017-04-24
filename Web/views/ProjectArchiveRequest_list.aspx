<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectArchiveRequest_List.aspx.cs"
    Inherits="Web.views.ProjectArchiveRequest_list" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ OutputCache Location="None" VaryByParam="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=6" />
    <title>档案审批</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <style media=print type="text/css">.noprint{visibility:hidden}</style>
</head>
<body>
<script type="text/javascript">
    var msgdiv = "";
    function InputRemark(id) {
        if ($("#msgdiv").html() != "") {
            msgdiv = $("#msgdiv").html();
            $("#msgdiv").html("");
        }
        var htmlStr = msgdiv;
        $$.MsgBox("申请用途", htmlStr, "确认借阅:submit(" + id + ")", "取消");
    }
    function submit(id) {
        window.open("ProjectArchiveRequest_Add.aspx?id=" + id + "&remark=" + $("#Remark").val());
        $$.MsgBox(0);
    }
    </script>
    <div id="msgdiv" class="none">
            <div style="margin-top: 15px; width: 200px; font-size: 12px;">
                <textarea class="area" cols="35" id="Remark" runat="server" rows="5" check="必,空,0,200"></textarea>
            </div>
    </div>
    <table class="noprint" width="100%" border="0" cellpadding="0" cellspacing="0" style="background: url(../images/list-title-bg.png) repeat-x;">
        <tr>
            <td class="sousuo">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="20%" height="36">
                            <span style="font-weight: bold; margin-left: 10px;">图档管理 <span style="font-family: SimSun">
                                >> </span><%=Title %> </span>
                        </td>
                        <td align="right">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="19" limit="ProjectArchiveRequest_add.<%=Title%>">
                                        <img src="../images/application_form_add.png" alt="新增" />
                                    </td>
                                    <td width="84" limit="ProjectArchiveRequest_add.<%=Title%>">
                                        <span onclick="parent.window.open('../views/ProjectArchiveRequest_add.aspx?limit=<%=Server.UrlEncode(Title)%>')" style="cursor: pointer;">
                                            新增<%=Title %></span>
                                    </td>
                                    <td width="20" style="cursor: pointer">
                                        <img src="../images/refresh-icon.png" alt="刷新" />
                                    </td>
                                    <td width="36" style="cursor: pointer" onclick="location.reload()">
                                        刷新
                                    </td>
                                        <td width="20">
                                            <img src="../images/application_form_add.png" alt="打印" />
                                        </td>
                                        <td width="36">
                                            <span onclick="window.print()" style="cursor: pointer;">打印</span>
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
                <td width="50" align="center">
                    用户名
                </td>
                <td width="150" align="center">
                    项目名称
                </td>
                <td width="" align="center">
                    专业卷册
                </td>
                <td width="" align="center">
                    档案名称
                </td>
                <td width="" align="center">
                    节点信息
                </td>
                <td width="50" align="center">
                    状态
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
                        <td align="center">
                            <%#Eval("UserName") %>
                        </td>
                        <td>
                            <%#Eval("ProjectName") %>
                        </td>
                        <td>
                            <%#Eval("ClassName1") %><br>
                            <%#Eval("ClassName2") %><br>
                            <%#Eval("ClassName3") %>
                        </td>
                        <td>
                            <%#Eval("ProjectArchiveName") %>
                        </td>
                        <td>
                            <%#Eval("NodeNo") %><br>
                            <%#Eval("NodeUser") %><br>
                            <%--出版的一些操作 改变NodeNo--%>
                            <a class="shen underline <%#Eval("RequestType").ToString()=="出版申请"?"":"none"%> <%#Eval("NodeUser").ToString().Contains(WebCommon.Public.GetUserName())?"":"none"%>" href="?nodeno=已出版&id=<%#Eval("ID")%>">已出版</a>
                            <a class="shen underline none <%#Eval("RequestType").ToString()=="出版申请"?"":"none"%> <%#Eval("NodeUser").ToString().Contains(WebCommon.Public.GetUserName())?"":"none"%>" href="?nodeno=已发图&id=<%#Eval("ID")%>">已发图</a>
                            <a class="shen underline none <%#Eval("RequestType").ToString()=="出版申请"?"":"none"%> <%#Eval("NodeUser").ToString().Contains(WebCommon.Public.GetUserName())?"":"none"%>" href="?nodeno=已回执&id=<%#Eval("ID")%>">已回执</a>
                        </td>
                        <td>
                            <%#Eval("Status") %><br>
                            <%--借阅的一些操作 改变Status--%>
                            <a class="shen underline <%#(WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1).C_Set1==WebCommon.Public.GetUserName()||Eval("NodeUser").ToString().Contains(WebCommon.Public.GetUserName())) && Eval("Status").ToString().Contains("未审")?"":"none"%>" href="?statustype=通过&id=<%#Eval("ID")%>">通过</a> 
                            <a class="shen underline <%#(WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1).C_Set1==WebCommon.Public.GetUserName()||Eval("NodeUser").ToString().Contains(WebCommon.Public.GetUserName())) && Eval("Status").ToString().Contains("未审")?"":"none"%>" href="?statustype=拒绝&id=<%#Eval("ID")%>">拒绝</a>
                            <a class="shen underline <%#(Eval("Status").ToString().Contains("未归还") || Eval("Status").ToString().Contains("通过"))&&Eval("RequestType").ToString()=="借阅申请"?"":"none"%>" href="?statustype=申请归还&id=<%#Eval("ID")%>">申请归还</a>
                            <a class="shen underline <%#Eval("Status").ToString().Contains("申请归还")?"":"none"%>" href="?statustype=已归还&id=<%#Eval("ID")%>">已归还</a> 
                            <a class="shen underline <%#Eval("Status").ToString().Contains("申请归还")?"":"none"%>" href="?statustype=未归还&id=<%#Eval("ID")%>">未归还</a>
                        </td>
                        <td align="center">
                            <a class="underline none" onclick="if(confirm('确定要删除吗？')) location.href='?limit=del&id=<%#Eval("ID")%>'">删除</a> 
                            <a class="underline none" onclick="parent.window.open('../views/ProjectArchiveRequest_Edit.aspx?id=<%#Eval("ID")%>')">编辑</a> 
                            <a class="underline" onclick="parent.window.open('../views/ProjectArchiveRequest_Edit.aspx?type=read&id=<%#Eval("ID")%>')">详情查看</a>
                            <a class="underline <%#Eval("Status").ToString().Contains("通过")?"":"none"%>" onclick="window.external.download('<%#Eval("ProjectArchiveFile")%>','<%#Eval("ProjectArchiveFile")%>',true)">图档下载</a>
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
    <div class="btmdo noprint">
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
