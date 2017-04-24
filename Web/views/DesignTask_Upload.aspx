<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DesignTask_Upload.aspx.cs" Inherits="Web.views.DesignTask_Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>上传文件</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/kindeditor/themes/default/default.css" />
    <link rel="stylesheet" href="/kindeditor/plugins/code/prettify.css" />
    <script charset="utf-8" src="/kindeditor/kindeditor.js"></script>
    <script charset="utf-8" src="/kindeditor/lang/zh_CN.js"></script>
    <script charset="utf-8" src="/kindeditor/plugins/code/prettify.js"></script>
    <script src="../js/Calendar.js" type="text/javascript"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br>
            <br />
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="470" align="center"
                style="line-height: 24px">
            <%if (WebCommon.Public.ToString(Request.QueryString["type"]) == "sheji")
              {%>
            <tr>
                <td class="tdbg" width="120" align="right">
                    设计意见：</td>
                <td class="tdbg">
                    <textarea id="Correct" runat="server" style="height:77px;width:267px"></textarea>
                </td>
            </tr>
            <%}%>
                <%if (WebCommon.Public.ToString(Request.QueryString["type"]) != "sheji"){%>
            <tr>
                <td class="tdbg" width="120" align="right">
                    校审意见：</td>
                <td class="tdbg">
                    <textarea id="CorrectInfo" runat="server" readonly="readonly" style="height:77px;width:267px"></textarea>
                </td>
            </tr>
            <tr>
                <td class="tdbg" width="120" align="right">
                <script language="javascript">
                    function InsertInfo() {
                        if ($("#CorrectContent").val() == "") {
                            alert("请输入错误内容");
                            return;
                        }
                        if ($("#CorrectInfo").val().indexOf($("#CorrectContent").val())>0) {
                            alert("输入重复");
                            return;
                        }
                        $("#CorrectInfo").val($("#CorrectInfo").val()+$("#CorrectType").val() + ':' + $("#CorrectContent").val() + '\r\n');
                        if ($("#CorrectType").val() == "一般性错误") $("#ErrorNum1").val(parseInt($("#ErrorNum1").val()) + 1);
                        if ($("#CorrectType").val() == "技术性错误") $("#ErrorNum2").val(parseInt($("#ErrorNum2").val()) + 1);
                        if ($("#CorrectType").val() == "原则性错误") $("#ErrorNum3").val(parseInt($("#ErrorNum3").val()) + 1);
                    }
                </script>
                </td>
                <td class="tdbg"><select name="CorrectType" id="CorrectType">
                    <option value="一般性错误">一般性错误</option>
                    <option value="技术性错误">技术性错误</option>
                    <option value="原则性错误">原则性错误</option>
                    </select>&nbsp;<input type="text" id="CorrectContent" class='input' style="width:150px">&nbsp;<input onclick="InsertInfo()" type="button" value="插入" />
                </td>
            </tr>
            <tr>
                <td class="tdbg" width="120" align="right">
                    错误统计：</td>
                <td class="tdbg"><input type="text" readonly="readonly" value="0" style="width:50px" class="input" runat="server" id="ErrorNum1" />&nbsp;<input type="text" value="0" style="width:50px" readonly="readonly" class="input" runat="server" id="ErrorNum2" />&nbsp;<input type="text" value="0" readonly="readonly" style="width:50px" class="input" runat="server" id="ErrorNum3" />
                </td>
            </tr><%}%>            <%if (WebCommon.Public.ToString(Request.QueryString["type"]) == EndNode)
                                    {%>
            <tr>
                <td class="tdbg" width="120" align="right">图纸自然张数：</td>
                <td class="tdbg"><asp:TextBox runat='server' ID='PaperNum1' Width="50" class='input' check='必,空,0,150' >0</asp:TextBox>&nbsp;张</td>
            </tr>
            <tr>
                <td class="tdbg" width="120" align="right">折合1#图：</td>
                <td class="tdbg"><asp:TextBox runat='server' ID='PaperNum2' Width="50" class='input' check='必,空,0,150' >0</asp:TextBox>&nbsp;张</td>
            </tr>
            <tr style="display:none">
                <td class="tdbg" width="120" align="right">文字资料(后期评级)：</td>
                <td class="tdbg"><asp:TextBox runat='server' ID='PaperNum3' Width="50" class='input' check='必,空,0,150' >1</asp:TextBox>&nbsp;张</td>
            </tr>
            <tr>
                <td class="tdbg" width="120" align="right">自动评级：</td>
                <td class="tdbg">
                <script type="text/javascript">
                    function AutoScore() {
                        var level = 3;
                        var err1max = 2;
                        var err2max = 4;
                        var err3max = 6;
                        if (level == 4) {
                            var err1max = 3;
                            var err2max = 5;
                            var err3max = 7;
                        }
                        //alert(level);
                        var err1 = parseInt($("#ErrorNum1").val());
                        var err2 = parseInt($("#ErrorNum2").val());
                        var err3 = parseInt($("#ErrorNum3").val());
                        var paper1 = parseInt($("#PaperNum1").val());
                        var paper2 = parseInt($("#PaperNum2").val());
                        var paper3 = parseInt($("#PaperNum3").val());
                        var result = "";
                        var score = (err1 + err2 + err3) / paper2 / 1;
//                        alert(err3 == 0);
                        //                        alert(err2 > err1max);
                        //alert(err1 / paper2 / 1 >= err3max);
                        //alert(err3 > 0);
//                        alert(err2 > err1max);
//                        alert(err1 / paper2 / 1 > err3max);
                        if (err3 >= 1 || err2 >= 2 || err1 / paper2 / 1 > err3max) result = "不合格";
                        else if (err1 / paper2 / 1 <= err1max) result = "优";
                        else if (err1 / paper2 / 1 <= err2max) result = "良";
                        else if (err3 == 0 && (err2 >= 1 || err1 / paper2 / 1 <= err3max)) result = "合格";
                        
                        $("#CorrectLevel").val(result);
                        alert("评级为：" + result);
                    }
                </script>
                    <asp:DropDownList ID="CorrectLevel" runat="server">
                    <asp:ListItem>优</asp:ListItem>
                    <asp:ListItem>良</asp:ListItem>
                    <asp:ListItem>合格</asp:ListItem>
                    <asp:ListItem>不合格</asp:ListItem>
                    </asp:DropDownList> <input type="button" onclick="AutoScore()" value="自动评级" />
                </td>
            </tr><%}%>
            <tr>
                <td class="tdbg" width="120" align="right">上传附件：</td>
                <td class="tdbg"><asp:FileUpload runat='server' ID='FileUrl' class='input' check='必,空,0,500' /></td>
            </tr>
                <tr class="tdbg">
                    <td height="60" align="center" colspan="2">
                        <input id="btn_submit" type="button" class="aler-btn" runat="server" value="确定提交"
                            onclick="if(checkform(document.forms[0]))" onserverclick="btnSave_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input name="" type="button" class="aler-btn" onclick="window.external.close()" value="关闭窗口" />
                    </td>
                </tr>
            </table>
    <br />
    <br />
    <br />
    </form>
</body>
</html>
