<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DesignTask_Correct.aspx.cs" Inherits="Web.views.DesignTask_Correct" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=6" />
    <title>项目质量统计</title>
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
                    成品校审单
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
                                                    SDHEEPDI/QJ-10-01-2010&nbsp;
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
                                                    卷册名称
                                                </td>
                                                <td style="background: #fff;">
                                                    &emsp;<asp:Label ID="ClassName3" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td style="background: #fff; width: 100px;" align="center">
                                                    工程编号
                                                </td>
                                                <td style="background: #fff;">
                                                    &emsp;<asp:Label ID="ProjectNo" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background: #fff;" height="40" align="center">
                                                    <span style="height: 40px; border-right: #000 1px solid; float: left; width: 48px;">
                                                        图纸自然张数</span><span style="float: left;width:48px; line-height: 40px;text-align:center"><asp:Label
                                                            ID="PaperNum1" runat="server" Text="Label"></asp:Label> 张</span>
                                                </td>
                                                <td style="background: #fff;">
                                                    <span style="height: 44px; border-right: #000 1px solid; float: left; text-align: center;
                                                        line-height: 40px; width: 25%;">折合1#图</span><span style="height: 44px; border-right: #000 1px solid;
                                                            float: left; text-align: center; line-height: 40px; width: 25%;"><asp:Label ID="PaperNum2"
                                                                runat="server" Text="Label"></asp:Label> 张</span><span
                                                                    style="height: 44px; border-right: #000 1px solid; float: left; text-align: center;
                                                                    line-height: 40px; width: 25%;">文字资料</span><span style="float: left; text-align: center;
                                                                        line-height: 40px;width:60px"><asp:Label ID="PaperNum3"
                                                                runat="server" Text="Label"></asp:Label> 页</span>
                                                </td>
                                                <td style="background: #fff" align="center">
                                                    主设人
                                                </td>
                                                <td style="background: #fff" align="center">
                                                    <asp:Label ID="MainDesigner" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="background: #fff;" rowspan="4" width="100" align="center">
                                                    <span style="height: 163px; border-right: #000 1px solid; float: left; width: 30px;">
                                                        <br />
                                                        错<br />误<br />统<br />计</span><span style="height: 41px;line-height:20px; border-bottom: #000 1px solid; float: left;
                                                            width: 70px;">类别<br />（个数）</span><span style="height: 40px; border-bottom: #000 1px solid;
                                                                float: left; line-height: 40px; width: 70px;">校对</span><span style="height: 40px;
                                                                    border-bottom: #000 1px solid; float: left; line-height: 40px; width: 70px;">审核</span><span
                                                                        style="line-height: 40px;">审定</span>
                                                </td>
                                                <td style="background: #fff;" height="40" align="center">
                                                    原则性错误
                                                </td>
                                                <td style="background: #fff;" align="center">
                                                    技术性错误
                                                </td>
                                                <td style="background: #fff;" align="center">
                                                    一般性错误
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background: #fff;text-align:center" height="40">
                                                    <asp:Label ID="error1Num1" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td style="background: #fff;" align="center">
                                                    <asp:Label ID="error1Num2" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td style="background: #fff;" align="center">
                                                    <asp:Label ID="error1Num3" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background: #fff;text-align:center" height="40">
                                                    <asp:Label ID="error2Num1" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td style="background: #fff;" align="center">
                                                    <asp:Label ID="error2Num2" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td style="background: #fff;" align="center">
                                                    <asp:Label ID="error2Num3" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background: #fff;text-align:center" height="40">
                                                    <asp:Label ID="error3Num1" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td style="background: #fff;" align="center">
                                                    <asp:Label ID="error3Num2" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td style="background: #fff;" align="center">
                                                    <asp:Label ID="error3Num3" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background: #fff;" height="40" align="center">
                                                    文件号
                                                </td>
                                                <td style="background: #fff;" colspan="2" align="center">
                                                    校/审意见及签署
                                                </td>
                                                <td style="background: #fff;" colspan="1" align="center">
                                                    设计人意见
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background: #fff;" height="200" align="center">
                                                </td>
                                                <td style="background: #fff; text-align: left;" colspan="2" align="center" valign="top" id="correctinfo" runat="server">
                                                </td>
                                                <td style="background: #fff; text-align: left;" colspan="1" align="center" valign="top" id="correctinfo2" runat="server">
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
