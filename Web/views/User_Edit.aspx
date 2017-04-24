<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Edit.aspx.cs" Inherits="Web.views.User_Edit" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看人事信息</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/Calendar.js" type="text/javascript"></script>
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <style type="text/css">
        .input1
        {
            height: 20px;
            border: 1px solid #ccc;
        }
    </style>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="750" align="center"
        style="line-height: 24px">
        <tr>
            <td width="100" align="right">
                登录账号：
            </td>
            <td>
                <input class="input1" runat="server" id="UserName" type="text" check="必,空,0,100"
                    size="22" />
            </td>
            <td width="100" align="right">
                学历：
            </td>
            <td width="200">
                <input class="input1" runat="server" id="U_Degrees" type="text" check="选,空,0,80"
                    size="22" />
            </td>
        </tr>
        <tr>
            <td align="right">
                权限角色：
            </td>
            <td>
                <asp:DropDownList ID="LimitID" runat="server" check="必,空,0,100">
                </asp:DropDownList>
            </td>
            <td align="right">
                大学专业：
            </td>
            <td>
                <input class="input1" runat="server" id="U_Professional" type="text" check="选,空,0,80"
                    size="22" />
            </td>
        </tr>
        <tr>
            <td align="right">
                部门：
            </td>
            <td>
                <asp:DropDownList ID="U_DepartID" runat="server" check="必,空,0,100">
                </asp:DropDownList>
            </td>
            <td align="right">
                毕业时间：
            </td>
            <td>
                <input class="input1" runat="server" id="U_GraduateTime" type="text"
                    check="必,日,0,40" size="22" /><img src="../images/date.jpg"  onclick="calendar.setHook(U_GraduateTime)" />
            </td>
        </tr>
        <tr>
            <td align="right">
                职位：
            </td>
            <td>
                <asp:DropDownList ID="U_JobID" runat="server" check="必,空,0,100" >
                </asp:DropDownList>
            </td>
            <td align="right">
                入职时间：
            </td>
            <td>
                <input class="input1" runat="server" id="U_EntryTime" type="text"
                    check="必,日,8,40" size="22" /><img src="../images/date.jpg"  onclick="calendar.setHook(U_EntryTime)" />
            </td>
        </tr>
        <tr>
            <td align="right">
                职级：
            </td>
            <td>
                <asp:DropDownList ID="U_JobRank" runat="server" check="必,空,0,100">
                </asp:DropDownList>
            </td>
            <td align="right">
                签合同时间：
            </td>
            <td>
                <input class="input1" runat="server" id="U_ContractStartTime" type="text" check="选,日,8,40"
                    size="22" /><img src="../images/date.jpg"  onclick="calendar.setHook(U_ContractStartTime)" />
            </td>
        </tr>
        <tr>
            <td align="right">
                职称：
            </td>
            <td>
                <asp:DropDownList ID="U_JobTitle" runat="server" check="必,空,0,100">
                </asp:DropDownList>
            </td>
            <td align="right">
                合同期限：
            </td>
            <td>
                <input class="input1" runat="server" id="U_ContractEndTime" type="text"
                    check="必,日,8,40" size="22" /><img src="../images/date.jpg"  onclick="calendar.setHook(U_ContractEndTime)" />
            </td>
        </tr>
        <tr>
            <td align="right">
                设计专业：
            </td>
            <td>
                <asp:CheckBoxList ID="U_Specialty" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"></asp:CheckBoxList>
            </td>
            <td align="right">
                入档时间：
            </td>
            <td>
                <input class="input1" runat="server" id="U_DocumentTime" type="text"
                    check="必,日,0,40" size="22" /><img src="../images/date.jpg"  onclick="calendar.setHook(U_DocumentTime)" />
            </td>
        </tr>
        <tr>
            <td align="right">
                姓名：
            </td>
            <td>
                <input class="input1" runat="server" id="U_Name" type="text" check="必,空,0,100"
                    size="22" />
            </td>
            <td align="right">
                手机：
            </td>
            <td>
                <input class="input1" runat="server" id="U_Mobile" type="text" check="选,电,11,40"
                    size="22" />
            </td>
        </tr>
        <tr>
            <td align="right">
                性别：
            </td>
            <td>
                <asp:RadioButtonList ID="U_Sex" runat="server" RepeatDirection="Horizontal" check="必,空,0,100">
                    <asp:ListItem Text="男" Value="男" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="女" Value="女"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td align="right">
                邮箱：
            </td>
            <td>
                <input class="input1" runat="server" id="U_Email" type="text" check="选,空,0,40"
                    size="22" />
            </td>
        </tr>
        <tr>
            <td align="right">
                身份证号：
            </td>
            <td>
                <input class="input1" runat="server" id="U_CardID" type="text" check="必,空,0,100"
                    size="22" />
            </td>
            <td align="right">
                电话：
            </td>
            <td>
                <input class="input1" runat="server" id="U_Phone" type="text" check="选,电,11,40"
                    size="22" />
            </td>
        </tr>
        <tr>
            <td align="right">
                状态：
            </td>
            <td>
                <asp:RadioButtonList ID="Status" runat="server" RepeatDirection="Horizontal" check="必,空,0,100">
                    <asp:ListItem Selected="True" Text="在职" Value="在职"></asp:ListItem>
                    <asp:ListItem Text="停职" Value="停职"></asp:ListItem>
                    <asp:ListItem Text="离职" Value="离职"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td align="right">
                登录密码：
            </td>
            <td>
                <asp:TextBox class="input1" ID="UserPwd" runat="server" TextMode="Password" check="选,空,0,100"
                    size="22"></asp:TextBox>
            </td>
        </tr>
                <tr>
                    <td align="right">
                        设计角色：
                    </td>
                    <td height="20" colspan="3">
                        <asp:CheckBoxList ID="U_DesignLimit" RepeatDirection="Horizontal" runat="server">
                        <asp:ListItem Value="设计人">设计人</asp:ListItem>
                        <asp:ListItem Value="校对人">校对人</asp:ListItem>
                        <asp:ListItem Value="审核人">审核人</asp:ListItem>
                        <asp:ListItem Value="审定人">审定人</asp:ListItem>
                        <asp:ListItem Value="核准人">核准人</asp:ListItem>
                        <asp:ListItem Value="批准人">批准人</asp:ListItem>
                        <asp:ListItem Value="主设">主设</asp:ListItem>
                        <asp:ListItem Value="设总">设总</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
        <tr>
            <td align="right">
                备注：
            </td>
            <td height="20" colspan="3">
                <textarea rows="5" id="Remark" runat="server" check="选,空,0,200" class="area" style="width:379px"></textarea>
            </td>
        </tr>
        <tr>
            <td height="10" colspan="4">
            </td>
        </tr>
        <tr>
            <td height="60" align="center" colspan="4">
                <input id="btn_submit" type="button" class="aler-btn" runat="server" value="确定提交"
                    onclick="if(checkform(document.forms[0]))" onserverclick="btnSave_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input id="Button1" runat="server" name="" type="button" class="aler-btn" onclick="window.external.close()"
                    value="关闭窗口" />
            </td>
        </tr>
    </table>
    <br />
    </form>
</body>
</html>
