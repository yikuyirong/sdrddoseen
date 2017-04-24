<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report4_Info.aspx.cs"
    Inherits="Web.views.Report4_Info" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ OutputCache Location="None" VaryByParam="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=6" />
    <title>工作量统计</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <script src="../js/Calendar.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.onload = function () {
            var h = document.documentElement.offsetHeight;
            document.getElementById("maindiv").style.height = h + "px";
        }
        window.onresize = function () {
            var h = document.documentElement.offsetHeight;
            document.getElementById("maindiv").style.height = h + "px";
        }
    </script>
</head>
<body>
<form id="form1" runat="server">
    <div id="msgdiv" class="none">
    <div style="margin:15px;width:320px;font-size:12px;padding-left:20px">
         统计人员：<input id="username" type="text" value="" class="input1" /><br>
         统计时间：<input id="time1" type="text" value="" class="input1" onfocus="calendar.setHook(this)" />～<input id="time2" type="text" value="" class="input1" onfocus="calendar.setHook(this)" /><br>
    </div>
    </div>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="background: url(../images/list-title-bg.png) repeat-x;">
        <tr>
            <td class="sousuo">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="20%" height="36">
                            <span style="font-weight: bold; margin-left: 10px;">生产管理 <span style="font-family: SimSun">
                                >> </span>工作量统计</span>
                        </td>
                        <td align="right">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="22" style="cursor: pointer">
                                        <img src="../images/refresh-icon.png" />
                                    </td>
                                    <td width="36" style="cursor: pointer" onclick="$$.LoadingBox('…正在处理…', 15000);location.href='report4.aspx'">
                                        后退
                                    </td>
                                    <td width="22" style="cursor: pointer">
                                        <img src="../images/refresh-icon.png" />
                                    </td>
                                    <td width="36" style="cursor: pointer" onclick="Export()">
                                        导出
                                    </td>
                                   <td width="147">
                                        <input type="text" style="color:#ccc;height: 20px; width: 145px; border: 1px solid #8a8a8a;line-height: 20px;font-size:12px"
                                            id="keywords" value="项目名称/项目编号/设计人" onfocus="this.value=''" name="keywords" />
                                    </td>
                                    <td width="48">
                                        <a style="display: block; width: 40px; padding: 2px 0; background: #93bc12; border: 1px solid #7b9e0d;
                                            color: #fff; text-align: center;cursor:pointer" onclick="scan('DT_SheJiRen,ProjectName,ProjectNo',keywords.value)">
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
    <div id="maindiv" onscroll="mymove()" style="height:550px;overflow-y: scroll">
        <table width="100%" border="0" cellpadding="0" cellspacing="1" style="background: #f0f0f0">
            <tr>
                <td colspan="20" height="28">
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
                    专业卷册
                </td>
                <td align="center">
                    自然张
                </td>
                <td align="center">
                    折合张
                </td>
                <td align="center">
                    工日数
                </td>
                <td align="center">
                    设计
                </td>
                <td align="center">
                    校对
                </td>
                <td align="center">
                    审核
                </td>
                <td align="center">
                    审定
                </td>
                <td align="center">
                    出图时间
                </td>
                <td align="center">
                    校对
                </td>
                <td align="center">
                    审核
                </td>
                <td align="center">
                    审定
                </td>
                <td align="center">
                    司令图
                </td>
                <td align="center">
                    辅助
                </td>
                <td align="center">
                    归档
                </td>
                <td align="center">
                    出差
                </td>
                <td align="center">
                    投标
                </td>
                <td align="center">
                    初设
                </td>
                <td align="center">
                    咨询
                </td>
                <td align="center">
                    其他
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
                var ScriptStr = "";
            </script>
            <asp:Repeater ID="ProjectMain" runat="server" OnItemDataBound="ProjectMain_ItemDataBound">
                <ItemTemplate>
            <asp:Repeater ID="ProjectList" runat="server" OnItemDataBound="ProjectList_ItemDataBound">
                <ItemTemplate>
                    <tr class="tr1">
                        <td style="padding: 3px 0" align="center">
                            <input class="sel" type="checkbox" />
                        </td>
                        <td width="110" align="center" class="projectname">
                            <%#Eval("ProjectNo")%><br><%#Eval("ProjectName")%>
                        </td>
                        <td width="180">
                            <%#Eval("ClassName1")%><br>
                            <%#Eval("DT_TuHao")%> <%#Eval("ClassName2")%><br>
                            <%#Eval("ClassName3")%>(核定<%#Eval("DT_GuGong")%>工日)
                        </td>
                        <td class="num1_<%#Eval("ProjectName")%>">
                            <%#Eval("DT_SheJiRen").ToString()==username?Eval("PaperNum1"):""%>
                        </td>
                        <td class="num2_<%#Eval("ProjectName")%>">
                            <%#Eval("DT_SheJiRen").ToString() == username ? Math.Round(Convert.ToDouble(Eval("PaperNum2")),2).ToString() : ""%>
                        </td>
                        <td class="num3_<%#Eval("ProjectName")%>">
                            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <%#Eval("DT_SheJiRen")%>
                        </td>
                        <td>
                            <%#Eval("DT_JiaoDuiRen")%>
                        </td>
                        <td>
                            <%#Eval("DT_ShenHeRen")%>
                        </td>
                        <td>
                            <%#Eval("DT_ShenDingRen")%>
                        </td>
                        <td>
                            <%#Convert.ToDateTime(Eval("DealTime")).ToString("yyy-MM-dd")%>
                        </td>
                        <td class="num4_<%#Eval("ProjectName")%>">
                            <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="num5_<%#Eval("ProjectName")%>">
                            <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="num6_<%#Eval("ProjectName")%>">
                            <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="num7_<%#Eval("ProjectName")%>">
                        </td>
                        <td class="num8_<%#Eval("ProjectName")%>">
                        </td>
                        <td class="num9_<%#Eval("ProjectName")%>">
                        </td>
                        <td class="num10_<%#Eval("ProjectName")%>">
                        </td>
                        <td class="num11_<%#Eval("ProjectName")%>">
                        </td>
                        <td class="num12_<%#Eval("ProjectName")%>">
                        </td>
                        <td class="num13_<%#Eval("ProjectName")%>">
                        </td>
                        <td class="num14_<%#Eval("ProjectName")%>">
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr class="tr1">
                        <td style="padding: 3px 0" align="center">
                            <input class="sel" type="checkbox" />
                        </td>
                        <td width="110" align="center"><asp:Label ID="LabelProject" runat="server" Text=""></asp:Label>
                        </td>
                        <td width="180">
                        其他工日
                        </td>
                        <td class="num1_<%#Eval("ProjectName")%>">
                        </td>
                        <td class="num2_<%#Eval("ProjectName")%>">
                        </td>
                        <td class="num3_<%#Eval("ProjectName")%>">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td class="num4_<%#Eval("ProjectName")%>">
                        </td>
                        <td class="num5_<%#Eval("ProjectName")%>">
                        </td>
                        <td class="num6_<%#Eval("ProjectName")%>">
                        </td>
                        <td class="num7_<%#Eval("ProjectName")%>">
                            <asp:Label ID="Label司令图" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="num8_<%#Eval("ProjectName")%>">
                            <asp:Label ID="Label辅助" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="num9_<%#Eval("ProjectName")%>">
                            <asp:Label ID="Label归档" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="num10_<%#Eval("ProjectName")%>">
                            <asp:Label ID="Label出差" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="num11_<%#Eval("ProjectName")%>">
                            <asp:Label ID="Label投标" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="num12_<%#Eval("ProjectName")%>">
                            <asp:Label ID="Label初设" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="num13_<%#Eval("ProjectName")%>">
                            <asp:Label ID="Label咨询" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="num14_<%#Eval("ProjectName")%>">
                            <asp:Label ID="Label其他" runat="server" Text=""></asp:Label>
                        </td>
            </tr>
            <tr class="tr1">
                        <td style="padding: 3px 0" align="center">
                            <b>小计</b>
                        </td>
                        <td id="num0_<%#Eval("ProjectName")%>" style="font-weight:bold">
                        </td>
                        <td>
                        </td>
                        <td id="num1_<%#Eval("ProjectName")%>">
                        </td>
                        <td id="num2_<%#Eval("ProjectName")%>">
                        </td>
                        <td id="num3_<%#Eval("ProjectName")%>" style="font-weight:bold">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td id="num4_<%#Eval("ProjectName")%>" style="font-weight:bold">
                        </td>
                        <td id="num5_<%#Eval("ProjectName")%>" style="font-weight:bold">
                        </td>
                        <td id="num6_<%#Eval("ProjectName")%>" style="font-weight:bold">
                        </td>
                        <td id="num7_<%#Eval("ProjectName")%>" style="font-weight:bold">
                        </td>
                        <td id="num8_<%#Eval("ProjectName")%>" style="font-weight:bold">
                        </td>
                        <td id="num9_<%#Eval("ProjectName")%>" style="font-weight:bold">
                        </td>
                        <td id="num10_<%#Eval("ProjectName")%>" style="font-weight:bold">
                        </td>
                        <td id="num11_<%#Eval("ProjectName")%>" style="font-weight:bold">
                        </td>
                        <td id="num12_<%#Eval("ProjectName")%>" style="font-weight:bold">
                        </td>
                        <td id="num13_<%#Eval("ProjectName")%>" style="font-weight:bold">
                        </td>
                        <td id="num14_<%#Eval("ProjectName")%>" style="font-weight:bold">
                        <script>ScriptStr+="SumRow('<%#Eval("ProjectName")%>');"</script>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr class="tr1">
                        <td style="padding: 3px 0" align="center">
                            <b>合计</b>
                        </td>
                        <td id="num0" style="font-weight:bold">0
                        </td>
                        <td>
                        </td>
                        <td id="num1">0
                        </td>
                        <td id="num2">0
                        </td>
                        <td id="num3" style="font-weight:bold">0
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td id="num4" style="font-weight:bold">0
                        </td>
                        <td id="num5" style="font-weight:bold">0
                        </td>
                        <td id="num6" style="font-weight:bold">0
                        </td>
                        <td id="num7" style="font-weight:bold">0
                        </td>
                        <td id="num8" style="font-weight:bold">0
                        </td>
                        <td id="num9" style="font-weight:bold">0
                        </td>
                        <td id="num10" style="font-weight:bold">0
                        </td>
                        <td id="num11" style="font-weight:bold">0
                        </td>
                        <td id="num12" style="font-weight:bold">0
                        </td>
                        <td id="num13" style="font-weight:bold">0
                        </td>
                        <td id="num14" style="font-weight:bold">0
                        </td>
                    </tr>
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
        <input id="Button1" runat="server" class="none delete" onclick="if(confirm('您确定要删除吗?')){if(typeof(sel)!='undefined')checkall(sel,0,'?del=1')}" type="button" />
    </div>
    <iframe frameborder="0" width="0" height="0" name="ExportFrm"></iframe>
</form>
<script>
    $(function () {
        eval(ScriptStr);
        //$("#projectname").html($(".projectname:eq(0)").html());
    });

    function SumRow(id) {
        for (var i = 1; i < 15; i++) {
            var numstr = $(".num" + i+"_"+id).text();
            numstr = numstr.replace(/ /g, "+") + "0";
            $("#num" + i + "_" + id).html(Math.round(eval(numstr) * 100) / 100);
            if (i >= 7) {
                $("#num" + i + "_" + id).html(numstr.split('+')[0]);
            }
            $("#num" + i).html(parseFloat($("#num" + i).text()) + parseFloat($("#num" + i + "_" + id).text()));
        }
        var countStr = "";
        for (var i = 3; i < 15; i++) {
            countStr += $("#num" + i + "_" + id).text() + "+";
        }
        countStr += "0";
        $("#num0" + "_" + id).html(eval(countStr));
        var allValue = parseFloat($("#num0").text()) + parseFloat($("#num0_" + id).text());
        $("#num0").html(allValue + "工日");
    }

    function Export() {
        var time = new Date();
        var filename = time.toLocaleDateString();
        var record = $("#maindiv").html().replace("absolute","");
        ExportFrm.document.write("<style>body,table,td,ul,li{text-align:center;margin:0px; padding:0px;list-style.:none; font-size:12px;}</style>" + record + "");
        ExportFrm.document.execCommand("SaveAs", true, "工作量统计" + filename + ".html");
    }
</script>
</body>
</html>
