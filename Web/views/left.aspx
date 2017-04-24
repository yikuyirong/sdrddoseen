<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="Web.views.left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <title>left</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery-1.11.0.js"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <style>
        .tab-block
        {
            height: 30px;
            margin: 0 5px;
            margin-bottom: 10px;
            border-bottom: 1px solid #ccc;
        }
        .tab-block span
        {
            display: inline;
            float: left;
            text-align: center;
        }
        .span11
        {
            background: #0090d0;
            color: #fff;
        }
        .span1
        {
            height: 100%;
            line-height: 30px;
            font-size: 14px;
            font-weight: bold;
            width: 80px;
            margin-right: 10px;
            color: #333;
        }
        .span2
        {
            height: 20px;
            margin-top: 5px;
            width: 32px;
        }
        .input
        {
            width: 135px;
        }
    </style>
    <script type="text/javascript">
        function qiehuan(obj)
        {
            if (obj == "shou")
            {
                var ob = document.getElementById("chushou");
                ob.className = 'span2 span11';
                var oj = document.getElementById("chuzu");
                oj.className = 'span2';
                document.getElementsByName("protype")[0].checked = true;
            }
            else
            {
                var ob = document.getElementById("chushou");
                ob.className = 'span2 ';
                var oj = document.getElementById("chuzu");
                oj.className = 'span2 span11';
                document.getElementsByName("protype")[1].checked = true;
            }

        }
    </script>
</head>
<body style="background: #ececec">
    <form id="form1" runat="server">
    <table cellspacing="0" cellpadding="0" width="196" bgcolor="#ececec">
       <tr>
            <td>
                <table width="202" border="0" cellpadding="0" cellspacing="0" style="margin-top: 10px;">
                    <tr>
                        <td>
                            <div style="margin: 0 10px; border: 1px solid #ccc; background: url(../images/gg-icon.png) left top repeat-x;
                                height: 26px; color: #000">
                                <span style="display: block; float: left; display: inline; padding-left: 15px; background: url(../images/jt-icon.png) 5px center no-repeat;
                                    height: 100%; line-height: 26px; font-weight: bold; font-size: 13px; color: #333">
                                    工作计划</span><a onclick="parent.window.open('Info_list.aspx','rightFrame')" style="cursor: pointer;
                                        display: block; height: 100%; line-height: 26px; float: right;margin-right:3px; display: inline;
                                        color: #999; font-size: 12px">更多&gt;&gt;</a></div>
                        </td>
                    </tr>
                    <tr>
                        <td height="10">
                        </td>
                    </tr>
                    <asp:Repeater runat="server" ID="Repeater1">
                        <ItemTemplate>
                            <tr>
                                <td colspan="2" bgcolor="#ececec" style="padding-left: 9px; padding-right: 9px;"
                                    valign="top">
                                    <p style="line-height: 22px; margin: 0">
                                        <span style="color: #93bc12">[<%#Eval("ClassID")%>] </span><a href="#" title='<%#Eval("I_Title") %>' onclick="parent.window.open('../views/info_detail.aspx?ID=<%#Eval("ID")%>')"><%#GetSubString(Convert.ToString(Eval("I_Title")),30)%> <%#Convert.ToDateTime(Eval("AddDate")).ToString("yy/MM/dd")%></a></p>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="202" border="0" cellpadding="0" cellspacing="0" style="margin-top: 10px;">
                    <tr>
                        <td>
                            <div style="margin: 0 10px; border: 1px solid #ccc; background: url(../images/gg-icon.png) left top repeat-x;
                                height: 26px; color: #000">
                                <span style="display: block; float: left; display: inline; padding-left: 15px; background: url(../images/jt-icon.png) 5px center no-repeat;
                                    height: 100%; line-height: 26px; font-weight: bold; font-size: 13px; color: #333">
                                    内部消息</span><a onclick="parent.window.open('Message_list.aspx','rightFrame')" style="cursor: pointer;
                                        display: block; height: 100%; line-height: 26px; float: right;margin-right:3px; display: inline;
                                        color: #999; font-size: 12px">更多&gt;&gt;</a></div>
                        </td>
                    </tr>
                    <tr>
                        <td height="10">
                        </td>
                    </tr>
                    <asp:Repeater runat="server" ID="InfoList">
                        <ItemTemplate>
                            <tr>
                                <td colspan="2" bgcolor="#ececec" style="padding-left: 9px; padding-right: 9px;"
                                    valign="top">
                                    <p style="line-height: 22px; margin: 0">
                                        <span style="color: #93bc12">[<%#Eval("UserNameFrom")%>] </span><a href="#" onclick="parent.window.open('../views/Message_Detail.aspx?ID=<%#Eval("ID")%>')"><%#Eval("MessageInfo")%></a></p>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table width="202" border="0" cellpadding="0" cellspacing="0" style="margin-top: 10px">
                    <tr>
                        <td>
                            <div style="margin: 0 10px; border: 1px solid #ccc; background: url(../images/gg-icon.png) left top repeat-x;
                                height: 26px; color: #000">
                                <span style="display: block; float: left; display: inline; font-weight: bold; padding-left: 15px;
                                    background: url(../images/jt-icon.png) 5px center no-repeat; height: 100%; line-height: 26px;
                                    font-size: 13px; color: #333">新闻公告</span><a onclick="parent.window.open('Info_list.aspx','rightFrame')"
                                        style="cursor: pointer; display: block; float: right;margin-right:3px; display: inline; height: 100%;
                                        line-height: 26px; color: #999; font-size: 12px">更多&gt;&gt;</a></div>
                        </td>
                    </tr>
                    <tr>
                        <td height="10">
                        </td>
                    </tr>
                    <asp:Repeater runat="server" ID="InfoList2">
                        <ItemTemplate>
                            <tr>
                                <td colspan="2" bgcolor="#ececec" style="padding-left: 9px; padding-right: 9px;"
                                    valign="top">
                                    <p style="line-height: 22px; margin: 0">
                                        <span style="color: #93bc12">[<%#Convert.ToDateTime(Eval("AddDate")).ToString("yy-MM-dd")%>]</span><a href="#" title='<%#Eval("I_Title")%>' onclick="parent.window.open('../views/info_detail.aspx?ID=<%#Eval("ID")%>')"> <%#GetSubString(Convert.ToString(Eval("I_Title")),16)%></a></p>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
