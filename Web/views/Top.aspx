<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="Web.views.Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <link href="../css/top.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery-1.11.0.js"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <script type="text/javascript">


        //判断是否支持createPopup

        if (!window.createPopup) {
            var __createPopup = function () {
                var SetElementStyles = function (element, styleDict) {
                    var style = element.style;
                    for (var styleName in styleDict) style[styleName] = styleDict[styleName];
                }
                var eDiv = document.createElement('div');
                SetElementStyles(eDiv, { 'position': 'absolute', 'top': 0 + 'px', 'left': 0 + 'px', 'width': 0 + 'px', 'height': 0 + 'px', 'zIndex': 1000, 'display': 'none', 'overflow': 'hidden' });
                eDiv.body = eDiv;
                var opened = false;
                var setOpened = function (b) {
                    opened = b;
                }
                var getOpened = function () {
                    return opened;
                }
                var getCoordinates = function (oElement) {
                    var coordinates = { x: 0, y: 0 };
                    while (oElement) {
                        coordinates.x += oElement.offsetLeft;
                        coordinates.y += oElement.offsetTop;
                        oElement = oElement.offsetParent;
                    }
                    return coordinates;
                }
                return { htmlTxt: '', document: eDiv, isOpen: getOpened(), isShow: false, hide: function () { SetElementStyles(eDiv, { 'top': 0 + 'px', 'left': 0 + 'px', 'width': 0 + 'px', 'height': 0 + 'px', 'display': 'none' }); eDiv.innerHTML = ''; this.isShow = false; }, show: function (iX, iY, iWidth, iHeight, oElement) { if (!getOpened()) { document.body.appendChild(eDiv); setOpened(true); }; this.htmlTxt = eDiv.innerHTML; if (this.isShow) { this.hide(); }; eDiv.innerHTML = this.htmlTxt; var coordinates = getCoordinates(oElement); eDiv.style.top = (iX + coordinates.x) + 'px'; eDiv.style.left = (iY + coordinates.y) + 'px'; eDiv.style.width = iWidth + 'px'; eDiv.style.height = iHeight + 'px'; eDiv.style.display = 'block'; this.isShow = true; } }
            }
            window.createPopup = function () {
                return __createPopup();
            }
        } 


        var oPopup = window.createPopup();
        var oPopTempStr = "<div style='width:90px;background:url(../images/index-menu-it-bg.png) left top no-repeat'>\
        <ul style='background:url(../images/index-menu-ib-bg.png) left top no-repeat;margin-top:15px;margin-left:0px;padding-bottom:10px'></ul><div style='margin-top:-19px;height:10px;background:url(../images/index-menu-ib-bgb.png) no-repeat'></div>\</div>";
        oPopup.document.body.innerHTML = oPopTempStr;
        function oPopuphide() { oPopup.hide(); } //用户响应客户端的Main_Deactivate事件防止菜单溢出程序
        $(function () {
            //登陆状态板块  
            $(".span3").mouseover(function () {
                $(this).css("background", "url(../images/xg-icon_.png) left 4px no-repeat");
                $(this).find("ul").css("display", "block");
            });
            $(".span3").mouseout(function () {
                $(this).css("background", "url(../images/xg-icon.png) 42px 15px no-repeat");
                $(this).find("ul").css("display", "none");
            });
            $(".span3").click(function () {
                $(this).css("background", "url(../images/xg-icon.png) 42px 15px no-repeat");
                $(this).find("ul").css("display", "none");
            });

            //菜单
            $(".index-menuli").mouseover(function () {
                var menuIndex = $(this).index() + 1;
                $(this).find("img").attr("src", "../images/menu" + menuIndex + "_.png");
                var htmlStr = $(this).find(".index-submenu ul").html();

                //oPopup.document.body.childNodes(0).childNodes(0).innerHTML = htmlStr;

                var aa = oPopup.document.body.childNodes(0).childNodes(0);

                aa.innerHTML = htmlStr;

                var htmlheight = oPopup.document.body.childNodes(0).offsetHeight - 13;
                oPopup.show(-8, 75, 90, htmlheight, this); //这里的-8是子菜单向右移动多少PX，75是子菜单向下移动多少px
                if (htmlStr == "") oPopup.hide();
                //选定菜单时关闭弹出
                $(oPopup.document).click(function () {
                    oPopup.hide();
                });
            });

            $(".index-menuli").mouseout(function () {
                var menuIndex = $(this).index() + 1;
                $(this).find("img").attr("src", "../images/menu" + menuIndex + ".png");
                $(this).find(".index-submenu").css("display", "none");
                oPopup.document.body.style.display = "1px solid red";
            });

            //权限配置
            $(".index-menu-it li").hide();
            var limit = "<%=LimitStr%>";
            var limitSplit = limit.split(',');
            for (var i = 0; i < limitSplit.length; i++) {
                if (limitSplit[i].indexOf(".") > 0) {
                    $(".index-menu-it li[onclick*='" + limitSplit[i].split(".")[0] + "'][onclick*='" + limitSplit[i].split(".")[1] + "']").show();
                    $(".index-menu-it li[onclick*='" + limitSplit[i].split(".")[0] + "'][onclick*='" + limitSplit[i].split(".")[1] + "']").parents("li").show();
                }
                else {
                    $(".index-menu-it li[onclick*='" + limitSplit[i].split(".")[0] + "']").show();
                    $(".index-menu-it li[onclick*='" + limitSplit[i].split(".")[0] + "']").parents("li").show();
                }
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="index-top">
        <div class="index-top-right">
            <div class="index-tr-t">
                <div class="index-trt-r">
                    <span style="background-position: -7px top" onclick="window.external.min()"></span>
                    <span style="background-position: -30px top" onclick="window.external.max()"></span>
                    <span style="background-position: -55px top" onclick="window.external.close()"></span>
                </div>
                <div class="index-trt-l" style="cursor: arrow">
                    <div><asp:Label ID="LocalJueSe" runat="server" Text="" style="line-height: 32px; padding: 0 3px; color: #87dafe; cursor: move"></asp:Label></div>
                    <div style="line-height: 32px;padding-top:5px;pading-left:5px; color: #fff; overflow: hidden; text-align: center">
                        <asp:Label ID="LocalUser" runat="server" Text=""></asp:Label></div>
                    <div class="span3" style="padding:0 15px">
                        <span style="line-height: 32px">系统</span>
                        <ul class="ul-del">
                            <li><a href="Alert_List.aspx" target="rightFrame">历史消息</a></li>
                            <li><a href="#" onclick="window.external.open('../views/Password.aspx',0,0)">修改密码</a></li>
                            <li><a href="#" onclick="window.external.download('/inc/help.doc','/help.doc',false)">使用帮助</a></li>
                            <li><a href="#" onclick="window.external.close()">退出系统</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="index-logo">
                <a href="#" onclick="window.open('FlowWork_Home.aspx','rightFrame')"><img src="../images/logo.png" /></a></div>
        </div>
        <ul class="index-menu">
            <li id="a" class="index-menuli" style="display: none">
                <img src="../images/menu1.png" alt="经营管理" />
                <div class="index-submenu">
                    <div class="index-menu-it">
                        <ul>
                            <li id="a1" style="<%=MenuStyle%>" onclick="parent.window.open('Project_List.aspx','rightFrame')">
                                项目登记</li>
                            <li id="a2" style="<%=MenuStyle%>" onclick="parent.window.open('ProjectContract_List.aspx','rightFrame')">
                                合同管理</li>
                            <li id="a3" style="<%=MenuStyle%>" onclick="parent.window.open('ProjectContractPay_List.aspx','rightFrame')">
                                收费管理</li>
                            <li id="Li7" style="<%=MenuStyle%>" onclick="parent.window.open('Class_List.aspx?pid=98&limit=项目外包单位','rightFrame')">
                                外包单位分类</li>
                            <li id="a4" style="<%=MenuStyle%>" onclick="parent.window.open('ProjectOuterCompany_List.aspx?limit=项目外包单位','rightFrame')">
                                外包单位管理</li>
                            <li id="a5" style="<%=MenuStyle%>" onclick="parent.window.open('ProjectOuter_List.aspx?limit=项目外包','rightFrame')">
                                项目外包管理</li>
                            <li id="Li2" style="<%=MenuStyle%>" onclick="parent.window.open('ProjectOuterPay_List.aspx?limit=项目外包','rightFrame')">
                                外包收费管理</li>
                            <li id="a6" style="<%=MenuStyle%>" onclick="parent.window.open('ProjectBid_List.aspx','rightFrame')">
                                客户管理</li>
                            <li id="a7" style="<%=MenuStyle%>" onclick="parent.window.open('Report1.aspx','rightFrame')">
                                统计报表</li>
                        </ul>
                    </div>
                </div>
            </li>
            <li id="b" class="index-menuli" style="display: none">
                <img src="../images/menu2.png" alt="生产管理" />
                <div class="index-submenu">
                    <div class="index-menu-it">
                        <ul>
                            <li id="b3" style="<%=MenuStyle%>" onclick="parent.window.open('Flow_List.aspx','rightFrame')">
                                流程管理</li>
                            <li id="b4" style="<%=MenuStyle%>" onclick="parent.window.open('FlowNode_List.aspx','rightFrame')">
                                节点管理</li>
                            <li id="b5" style="<%=MenuStyle%>" onclick="parent.window.open('FlowWork_List.aspx','rightFrame')">
                                工作管理</li>
                            <li id="b6" style="<%=MenuStyle%>" onclick="parent.window.open('FlowNodeTask_List.aspx','rightFrame')">
                                工作任务安排</li>
                            <li id="b7" style="<%=MenuStyle%>" onclick="parent.window.open('DesignTask_List.aspx','rightFrame')">
                                卷册任务安排</li>
                            <li id="Li1" style="<%=MenuStyle%>" onclick="parent.window.open('DesignTask_List2.aspx','rightFrame')">
                                卷册任务执行</li>
                            <li id="b8" style="<%=MenuStyle%>" onclick="parent.window.open('FlowWork_List2.aspx','rightFrame')">
                                进度监控</li>
                            <li id="b11" style="<%=MenuStyle%>" onclick="parent.window.open('Report2.aspx','rightFrame')">
                                生产汇总</li>
                            <li id="d6" style="<%=MenuStyle%>" onclick="parent.window.open('Report4.aspx','rightFrame')">
                                工作量统计</li>
                            <li id="b12" style="<%=MenuStyle%>" onclick="parent.window.open('DesignChange_List.aspx','rightFrame')">
                                项目变更单</li>
                            <li id="Li13" style="<%=MenuStyle%>" onclick="parent.window.open('OutFile_List.aspx','rightFrame')">
                                外来资料</li>
                            <li id="Li14" style="<%=MenuStyle%>" onclick="parent.window.open('OtherWork_List.aspx','rightFrame')">
                                其他工日</li>
                            <li id="Li15" style="<%=MenuStyle%>" onclick="parent.window.open('PlanManage_List.aspx','rightFrame')">
                                进度管理表</li>
                            <li id="d4" style="<%=MenuStyle%>" onclick="parent.window.open('ProjectDocument_List.aspx','rightFrame')">
                                网上提资</li>
                        </ul>
                    </div>
                </div>
            </li>
            <li id="c" class="index-menuli" style="display: none">
                <img src="../images/menu3.png" alt="总承包管理" />
                <div class="index-submenu">
                    <div class="index-menu-it">
                        <ul>
                            <li id="Li8" style="<%=MenuStyle%>" onclick="parent.window.open('Class_List.aspx?pid=99&limit=设计外包单位','rightFrame')">
                                外包单位分类</li>
                            <li id="c3" style="<%=MenuStyle%>" onclick="parent.window.open('ProjectOuterCompany_List.aspx?limit=设计外包单位','rightFrame')">
                                外包单位管理</li>
                            <li id="c1" style="<%=MenuStyle%>" onclick="parent.window.open('ProjectOuter_List.aspx?limit=设计外包','rightFrame')">
                                设计外包管理</li>
                            <li id="Li3" style="<%=MenuStyle%>" onclick="parent.window.open('ProjectOuterPay_List.aspx?limit=设计外包','rightFrame')">
                                设计外包收费</li>
                            <li id="Li9" style="<%=MenuStyle%>" onclick="parent.window.open('Class_List.aspx?pid=100&limit=采购单位','rightFrame')">
                                采购单位分类</li>
                            <li id="c6" style="<%=MenuStyle%>" onclick="parent.window.open('ProjectOuterCompany_List.aspx?limit=采购单位','rightFrame')">
                                采购单位管理</li>
                            <li id="c4" style="<%=MenuStyle%>" onclick="parent.window.open('ProjectOuter_List.aspx?limit=采购','rightFrame')">
                                采购管理</li>
                            <li id="Li4" style="<%=MenuStyle%>" onclick="parent.window.open('ProjectOuterPay_List.aspx?limit=采购','rightFrame')">
                                采购收费管理</li>
                            <li id="Li10" style="<%=MenuStyle%>" onclick="parent.window.open('Class_List.aspx?pid=101&limit=施工单位','rightFrame')">
                                施工单位分类</li>
                            <li id="c9" style="<%=MenuStyle%>" onclick="parent.window.open('ProjectOuterCompany_List.aspx?limit=施工单位','rightFrame')">
                                施工单位管理</li>
                            <li id="c7" style="<%=MenuStyle%>" onclick="parent.window.open('ProjectOuter_List.aspx?limit=施工','rightFrame')">
                                施工管理</li>
                            <li id="Li5" style="<%=MenuStyle%>" onclick="parent.window.open('ProjectOuterPay_List.aspx?limit=施工','rightFrame')">
                                施工收费管理</li>
                            <li id="c10" style="<%=MenuStyle%>" onclick="parent.window.open('ProjectBuilderLog_List.aspx','rightFrame')">
                                施工日志管理</li>
                        </ul>
                    </div>
                </div>
            </li>
            <li id="d" class="index-menuli" style="display: none">
                <img src="../images/menu4.png" alt="质量管理" />
                <div class="index-submenu">
                    <div class="index-menu-it">
                        <ul>
                            <li id="d1" style="<%=MenuStyle%>" onclick="parent.window.open('FlowForm_List.aspx','rightFrame')">
                                ISO表单管理</li>
                            <li id="d2" style="<%=MenuStyle%>" onclick="parent.window.open('FlowFormWord_List.aspx','rightFrame')">
                                ISO短语管理</li>
                            <li id="d3" style="<%=MenuStyle%>" onclick="parent.window.open('UserName_List.aspx','rightFrame')">
                                电子签名</li>
                            <%--<li id="d5" style="<%=MenuStyle%>" onclick="parent.window.open('DesignCorrect_List.aspx','rightFrame')">
                                电子校审</li>--%>
                            <li id="Li6" style="<%=MenuStyle%>" onclick="parent.window.open('Report3.aspx','rightFrame')">
                                设计质量分析</li>
                        </ul>
                    </div>
                </div>
            </li>
            <li id="e" class="index-menuli" style="display: none">
                <img src="../images/menu5.png" alt="图档管理" />
                <div class="index-submenu">
                    <div class="index-menu-it">
                        <ul>
                            <li id="e7" style="<%=MenuStyle%>" onclick="parent.window.open('Class_List.aspx?pid=227&limit=公共档案','rightFrame')">
                                档案分类</li>
                            <li id="e1" style="<%=MenuStyle%>" onclick="parent.window.open('ProjectArchive_List.aspx','rightFrame')">
                                项目存档</li>
                            <li id="e2" style="<%=MenuStyle%>" onclick="window.external.open('../views/ProjectArchive_Search.aspx',0,0)">
                                档案查询</li>
                            <li id="e4" style="<%=MenuStyle%>" onclick="parent.window.open('ProjectArchiveRequest_List.aspx?limit=借阅申请','rightFrame')">
                                借阅申请</li>
                            <li id="e5" style="<%=MenuStyle%>" onclick="parent.window.open('ProjectArchiveVertion_List.aspx','rightFrame')">
                                版本管理</li>
                            <li id="e6" style="<%=MenuStyle%>" onclick="parent.window.open('ProjectArchiveRequest_List.aspx?limit=出版申请','rightFrame')">
                                出版申请</li>
                            <li id="Li11" style="<%=MenuStyle%>" onclick="parent.window.open('Report5.aspx','rightFrame')">
                                出版统计</li>
                        </ul>
                    </div>
                </div>
            </li>
            <li id="f" class="index-menuli" style="display: none">
                <img src="../images/menu6.png" alt="办公管理" />
                <div class="index-submenu">
                    <div class="index-menu-it">
                        <ul>
                            <li id="f1" style="<%=MenuStyle%>" onclick="parent.window.open('Info_List.aspx','rightFrame')">
                                新闻公告</li>
                            <li id="f2" style="<%=MenuStyle%>" onclick="parent.window.open('WeekWork_List.aspx','rightFrame')">
                                工作计划</li>
                            <li id="f3" style="<%=MenuStyle%>" onclick="parent.window.open('Message_List.aspx','rightFrame')">
                                内部消息</li>
                            <li id="f4" style="<%=MenuStyle%>" onclick="parent.window.open('User_List.aspx','rightFrame')">
                                人事管理</li>
                            <li id="Li12" style="<%=MenuStyle%>" onclick="parent.window.open('Disk_List.aspx','rightFrame')">
                                共享资源</li>

                        </ul>
                    </div>
                </div>
            </li>
            <li id="g" class="index-menuli" style="display: none">
                <img src="../images/menu7.png" alt="系统设置" />
                <div class="index-submenu">
                    <div class="index-menu-it">
                        <ul>
                            <li id="g1" style="<%=MenuStyle%>" onclick="parent.window.open('Class_List.aspx','rightFrame')">
                                分类管理</li>
                            <li id="e3" style="<%=MenuStyle%>" onclick="parent.window.open('DesignVolume_List.aspx','rightFrame')">
                                卷册设置</li>
                            <li id="g2" style="<%=MenuStyle%>" onclick="parent.window.open('Limit_List.aspx','rightFrame')">
                                角色权限</li>
                            <li id="g3" style="<%=MenuStyle%>" onclick="window.external.open('../views/DataBack.aspx',0,0)">
                                数据备份</li>
                            <li id="g4" style="<%=MenuStyle%>" onclick="parent.window.open('Log.aspx','rightFrame')">
                                系统日志</li>
                            <li id="g5" style="<%=MenuStyle%>" onclick="window.external.open('../views/Config.aspx',0,0)">
                                系统参数</li>
                        </ul>
                    </div>
                </div>
            </li>
            <li class="index-menuli" style="display: block">
                <img src="../images/menu8.png" alt="退出系统" onclick="window.external.close()" />
                <div class="index-submenu">
                    <div class="index-menu-it">
                        <ul>
                        </ul>
                    </div>
                </div>
            </li>
        </ul>
    </div>
    </form>
</body>
</html>
