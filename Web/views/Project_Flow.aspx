<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Project_Flow.aspx.cs" Inherits="Web.views.Project_Flow" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>流程图</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="400" align="center"
                style="line-height: 24px">
                <tr>
                  <td style="text-align: center">
                      <div style="height:600px;overflow-y:scroll"><input title="节点名称：项目登记
节点用户：业务经理" id="Button2" type="button" runat="server" value="项目登记" />
                      <div class="arrow" style="line-height:12px">↓</div>
                      
                      <input title="节点名称：发起合同评审
节点用户：业务经理" id="Button5" type="button" runat="server" value="发起合同评审" />
                      <div class="arrow" style="line-height:12px">↓</div>

                      <input title="节点名称：合同评审处理
节点用户：技术副院长" id="Button6" type="button" runat="server" value="合同评审处理" />
                      <div class="arrow" style="line-height:12px">↓</div>
                      
                      <input title="节点名称：上传合同
节点用户：业务经理" id="Button7" type="button" runat="server" value="上传合同" />
                      <div class="arrow" style="line-height:12px">↓</div>
                      
                      <input title="节点名称：确认设总
节点用户：技术副院长" id="Button8" type="button" runat="server" value="确认设总" />
                      <div class="arrow" style="line-height:12px">↓</div>
                      
                      <input title="节点名称：设总人员审批
节点用户：院长" id="Button9" type="button" runat="server" value="设总人员审批" />
                      <div class="arrow" style="line-height:12px">↓</div>
                      
                      <input title="节点名称：确认主设
节点用户：设总" id="Button10" type="button" runat="server" value="确认主设" />
                      <div class="arrow" style="line-height:12px">↓</div>
                      
                      <input title="节点名称：主设人员审批
节点用户：室主任、技术管理部" id="Button11" type="button" runat="server" value="主设人员审批" />
                      <div class="arrow" style="line-height:12px">↓</div>
                      
                      <input title="节点名称：卷册任务书录入
节点用户：主设" id="Button12" type="button" runat="server" value="卷册任务书录入" />
                      <div class="arrow" style="line-height:12px">↓</div>
                      
                      <input title="节点名称：卷册任务书审批
节点用户：室主任、技术管理部" id="Button14" type="button" runat="server" value="卷册任务书审批" />
                      <div class="arrow" style="line-height:12px">↓</div>
                      
                      <input title="节点名称：设计工作处理
节点用户：设计师" id="Button1" type="button" runat="server" value="设计工作处理" />
                      <div class="arrow" style="line-height:12px">↓</div>
                      
                      <input title="节点名称：开始设计
节点用户：设计师" id="Button15" type="button" runat="server" disabled="disabled" value="开始设计" />
                      <div class="arrow" style="line-height:12px">↓</div>
                      
                      <input title="节点名称：开始校对
节点用户：设计师" id="Button16" type="button" runat="server" disabled="disabled" value="开始校对" />
                      <div class="arrow" style="line-height:12px">↓</div>
                      
                      <input title="节点名称：开始审核
节点用户：设计师" id="Button17" type="button" runat="server" disabled="disabled" value="开始审核" />
                      <div class="arrow" style="line-height:12px">↓</div>
                      
                      <input title="节点名称：发起会签
节点用户：设计师" id="Button18" type="button" runat="server" disabled="disabled" value="发起会签" />
                      <div class="arrow" style="line-height:12px">↓</div>
                      
                      <input title="节点名称：处理会签
节点用户：设计师" id="Button19" type="button" runat="server" disabled="disabled" value="处理会签" />
                      <div class="arrow" style="line-height:12px">↓</div>
                      
                      <input title="节点名称：开始审定
节点用户：设计师" id="Button20" type="button" runat="server" disabled="disabled" value="开始审定" />
                      <div class="arrow" style="line-height:12px">↓</div>
                      
                      <input title="节点名称：开始核准
节点用户：设计师" id="Button21" type="button" runat="server" disabled="disabled" value="开始核准" />
                      <div class="arrow" style="line-height:12px">↓</div>
                      
                      <input title="节点名称：项目结束并存档
节点用户：项目经理" id="Button22" type="button" runat="server" value="项目结束并存档" />
                      <div class="arrow" style="line-height:12px">↓</div></div>
                    </td>
                </tr>
                <tr>
                    <td height="20" align="center" colspan="2">
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
<script type="text/javascript">
    $(function () {
        $(".arrow:last").hide();
        $("input[value=<%=NodeNo%>]").css("background", "green").css("color", "white");
    });
</script>
</body>
</html>
