<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowWork_Add.aspx.cs" Inherits="Web.views.FlowWork_add" ValidateRequest="false" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增工作</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <script src="../js/Calendar.js" type="text/javascript"></script>
    <style type="text/css">
    .divScrollBar{background-color:#ddd;position:absolute;opacity:0.5; filter:Alpha(opacity=50);}
    .divScrollBar:hover{opacity:1; filter:Alpha(opacity=100);}
    .divScrollBar div{background-color:#333; position:absolute; left:0px; top:0px;}
    </style>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br />
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="900" align="center"
                style="line-height: 24px">
                <tr>
                    <td width="200" align="right">
                        工作流程：
                    </td>
                    <td width="700" align="left">
                        <asp:DropDownList ID="FlowID" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="FlowID_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="FlowName" runat="server" check="必,空,0,100" AutoPostBack="true"
                            OnSelectedIndexChanged="FlowName_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr runat="server">
                    <td align="right">
                        所属项目：
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ProjectType" AutoPostBack="true"
                            OnSelectedIndexChanged="ProjectType_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList runat="server" ID="ProjectID" AutoPostBack="true"
                            onselectedindexchanged="ProjectID_SelectedIndexChanged">
                        </asp:DropDownList>
                        <input id="FormContentSet" type="text" class="none" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        工作名称：
                    </td>
                    <td align="left">
                        <input runat="server" style="width:500px" type="text" id="WorkName" check="必,空,0,100" class="input" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" width="900" height="400" valign="top">
                        <div id="FormContent" onmouseout="$('#FormContentSet').val($('#FormContent').html());" runat="server" style="width:auto; overflow-y:scroll;overflow-x:hidden; height:400px; border:solid 1px gray;background:#fff"></div>
                    </td>
                </tr>
                <tr>
                    <td height="60" align="center" colspan="2">
                        <input id="btn_submit" type="button" class="aler-btn" runat="server" value="确定提交"
                            onclick="if(checkform(document.forms[0]))" onserverclick="btn_submit_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input runat="server" name="" type="button" class="aler-btn" onclick="window.external.close()"
                            value="关闭窗口" />
                    </td>
                </tr>
            </table>
    <br>
    <br>
    <asp:HiddenField ID ="hid" runat="server" />
    </form>
<script type="text/javascript">
    $(function () {
        $(".username")[0].value = document.getElementById("hid").value;
        $(".year:eq(0)").val("<%=DateTime.Now.Year%>");
        $(".month:eq(0)").val("<%=DateTime.Now.Month%>");
        $(".day:eq(0)").val("<%=DateTime.Now.Day%>");
        $(".username:eq(1)").val("<%=WebCommon.Public.GetUserName()%>");
    });
</script>
</body>
</html>
