<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectBuilder_List.aspx.cs"
    Inherits="Web.views.ProjectBuilder_list" %>

<%@ OutputCache Location="None" VaryByParam="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=6" />
    <title>施工单位管理</title>
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
                        <td width="24%" height="36">
                            <span style="font-weight: bold; margin-left: 10px;">总承包管理 <span style="font-family: SimSun">
                                >> </span>施工单位管理 </span>
                        </td>
                        <td align="right">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="20" limit="ProjectBuilder_add">
                                        <img src="../images/application_form_add.png" alt="新增" />
                                    </td>
                                    <td width="84" limit="ProjectBuilder_add">
                                        <span onclick="parent.window.open('../views/ProjectBuilder_add.aspx')" style="cursor: pointer;">
                                            新增施工单位</span>
                                    </td>
                                    <td width="20" style="cursor: pointer">
                                        <img src="../images/refresh-icon.png" alt="刷新" />
                                    </td>
                                    <td width="36" style="cursor: pointer" onclick="location.reload()">
                                        刷新
                                    </td>
                                    <td width="147">
                                        <input runat="server" type="text" style="color:#ccc;height: 20px; width: 145px; border: 1px solid #8a8a8a;line-height: 20px;font-size:12px"
                                            id="keywords" value="项目编号" onfocus="this.value=''" name="keywords" />
                                    </td>
                                    <td width="48">
                                        <a style="display: block; width: 40px; padding: 2px 0; background: #93bc12; border: 1px solid #7b9e0d;
                                            color: #fff; text-align: center;cursor:pointer" onclick="">
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
                <td width="50" align="center" height="25">
                    选择
                </td>
                <td width="" align="center">
                    项目编号
                </td>
                <td width="150" align="center">
                    添加时间
                </td>
                <td width="100" align="center">
                    联系电话
                </td>
                <td width="100" align="center">
                    联系人
                </td>
                <td width="100" align="center">
                    邮箱
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
            <tr class="tr1">
                <td height="25" align="center">
                    <input class="sel" id="CheckBoxAll" type="checkbox" />
                </td>
                <td align="center">
                </td>
                <td align="center">
                </td>
                <td align="left">
                </td>
                <td align="center">
                </td>
                <td>
                </td>
                <td align="center">
                    <a limit="ProjectBuilder_List.del" href="#" onclick="location.href='?limit=del&id=<%#Eval("ID")%>'"  style="text-decoration: underline;">删除</a> <a limit="oa_note_info" onclick="parent.window.open('../views/oa_note_info.asp')"
                        target="_blank" style="text-decoration: underline;">编辑</a>
                </td>
            </tr>
        </table>
    </div>
    <div class="btmdo">
        <input id="Checkbox1" runat="server" class="selectAll" name="checkbox" type="checkbox" onclick="if(this.checked){$('.sel').attr('checked','checked')}else{$('.sel').removeAttr('checked')}" />
        <span>全选</span>
        <input id="Button1" runat="server" class="none delete" onclick="if(confirm('您确定要删除吗?')){if(typeof(sel)!='undefined')checkall(sel,0,'?del=1')}"
            type="button" />
    </div>
</body>
</html>
