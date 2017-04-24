<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DesignTask_Correct22.aspx.cs" Inherits="Web.views.DesignTask_Correct2" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=6" />
    <title>会签单</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
</head>
<body style="background:#fff">
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server" style="width:840px">
    <table class="ke-zeroborder" cellspacing="0" cellpadding="0" style="width:800px;margin-left:20px" border="0">
        <tbody>
            <tr>
                <td style="font-weight: bold;" height="40" align="center">
                    会签单
                </td>
            </tr>
            <tr>
                <td>
                    <table class="ke-zeroborder" cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tbody>
                            <tr>
                                <td>
                                    <table class="ke-zeroborder" cellspacing="1" style="margin-bottom:-1px;background:#000" cellpadding="0" width="100%" border="0">
                                        <tbody>
                                            <tr>
                                                <td width="30%" colspan="2" style="width:140px;height:30px;background:#fff">
                                                    &nbsp;专业：&emsp;<asp:Label ID="ClassName1" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td style="text-align:right;background:#fff">
                                                    SDHEEPDI/QJ-7-3-3-2010&nbsp;
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table class="ke-zeroborder" style="background: #000;" cellspacing="1" cellpadding="0"
                                        width="100%" border="0">
                                        <tbody>
                                            <tr>
                                                <td style="background: #fff;" height="40" align="center">
                                                    工程名称
                                                </td>
                                                <td style="background: #fff;" colspan="3">
                                                    &emsp;<asp:Label ID="ProjectName" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background: #fff;" height="40" width="100" align="center">
                                                    子项名称
                                                </td>
                                                <td style="background: #fff;">
                                                    &emsp;<asp:Label ID="ClassName3" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td style="background: #fff; width: 100px;" align="center">
                                                    图号
                                                </td>
                                                <td style="background: #fff;">
                                                    &emsp;<asp:Label ID="ProjectNo" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background: #fff;" height="40" align="center">
                                                    委托会签人</td>
                                                <td style="background: #fff;" colspan="2" align="center">
                                                    时间</td>
                                                <td style="background: #fff;" colspan="1" align="center">
                                                    主要问题简述</td>
                                            </tr>
                                            <div id="correctinfo" runat="server">
                                            <tr>
                                                <td style="background: #fff;text-align:center;height:50px">1</td>
                                                <td style="background: #fff;text-align:center" colspan="2">1</td>
                                                <td style="background: #fff;text-align:center">1</td>
                                            </tr>
                                            </div>
                                            <tr>
                                                <td style="background: #fff;" height="40" align="center">
                                                    会审会签主持人
                                                </td>
                                                <td style="background: #fff;" colspan="3">
                                                    &emsp;<asp:Label ID="Designer" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <div style="height:30px"></div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
