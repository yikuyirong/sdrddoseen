<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Limit_Edit.aspx.cs" Inherits="Web.views.Limit_Edit" %>

<%@ Register Src="../inc/wintop.ascx" TagName="wintop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看角色</title>
    <link href="../css/Public.css" rel="stylesheet" type="text/css" />
    <link href="../css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="../js/public.js" type="text/javascript"></script>
    <style type="text/css">
        .divScrollBar
        {
            background-color: #ddd;
            position: absolute;
            opacity: 0.5;
            filter: Alpha(opacity=50);
        }
        .divScrollBar:hover
        {
            opacity: 1;
            filter: Alpha(opacity=100);
        }
        .divScrollBar div
        {
            background-color: #333;
            position: absolute;
            left: 0px;
            top: 0px;
        }
    </style>
    <script type="text/javascript" src="../js/jsScroll.js"></script>
</head>
<body>
    <uc2:wintop ID="wintop1" runat="server" />
    <form id="form1" name="form1" runat="server">
    <br>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="tbl_add" border="0" cellspacing="0" cellpadding="5" width="600" align="center"
                style="line-height: 24px">
                <tr>
                    <td class="tdbg" width="80" align="right">
                        角 色：
                    </td>
                    <td class="tdbg">
                        <asp:TextBox runat="server" ID="LimitName" class="input" check="必,空,0,20"></asp:TextBox>
                    </td>
                </tr>
                <tr class="tdbg">
                    <td align="right">
                        备 注：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="Remark" class="input" check="选,空,0,20"></asp:TextBox>
                    </td>
                </tr>
                <tr class="tdbg">
                    <td align="right">
                        权 限：<br>
                        <input onclick="if($('input[type=checkbox]').attr('checked')){$('input[type=checkbox]').removeAttr('checked');}else{$('input[type=checkbox]').attr('checked','checked');}"
                            type="button" width="40" height="23" style="padding-bottom: 3px" value="全选" />&nbsp;
                    </td>
                    <td>
                        <div id="div1" style="width: auto; overflow: hidden; height: 200px; border: solid 1px gray;">
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->项目登记" value="Project_List" />项目登记列表
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->项目登记->新增按钮" value="Project_Add" />项目登记添加
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->项目登记->编辑按钮" value="Project_Edit" />项目登记编辑
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->项目登记->删除按钮" value="Project_List.del" />项目登记删除
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->项目登记->重启按钮" value="Project_List.reset" />项目流程重启<br>
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->合同管理" value="ProjectContract_List" />合同管理
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->合同管理->新增按钮" value="ProjectContract_Add" />合同管理添加
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->合同管理->编辑按钮" value="ProjectContract_Edit" />合同管理修改
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->合同管理->删除按钮" value="ProjectContract_List.del" />合同管理删除<br>
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->收费管理" value="ProjectContractPay_List" />收费管理列表
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->收费管理->新增按钮" value="ProjectContractPay_Add" />收费管理添加
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->收费管理->编辑按钮" value="ProjectContractPay_Edit" />收费管理修改
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->收费管理->删除按钮" value="ProjectContractPay_List.del" />收费管理删除<br>
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->外包单位分类" value="Class_List.项目外包单位" />外包单位分类查看
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->外包单位分类->新增按钮" value="Class_Add.项目外包单位" />外包单位分类添加
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->外包单位分类->编辑按钮" value="Class_Edit.项目外包单位" />外包单位分类修改
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->外包单位分类->删除按钮" value="Class_List.项目外包单位|del" />外包单位分类删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->外包单位管理" value="ProjectOuterCompany_List.项目外包单位" />外包单位管理列表
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->外包单位管理->新增按钮" value="ProjectOuterCompany_Add.项目外包单位" />外包单位管理添加
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->外包单位管理->编辑按钮" value="ProjectOuterCompany_Edit.项目外包单位" />外包单位管理修改
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->外包单位管理->删除按钮" value="ProjectOuterCompany_List.项目外包单位|del" />外包单位管理删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->项目外包管理" value="ProjectOuter_List.项目外包" />外包大项列表
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->项目外包管理->新增按钮" value="ProjectOuter_Add.项目外包" />外包大项添加
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->项目外包管理->编辑按钮" value="ProjectOuter_Edit.项目外包" />外包大项修改
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->项目外包管理->删除按钮" value="ProjectOuter_List.项目外包|del" />外包大项删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->外包收费管理" value="ProjectOuterPay_List.项目外包" />外包收费管理
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->外包收费管理->新增按钮" value="ProjectOuterPay_Add.项目外包" />外包收费新增
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->外包收费管理->修改按钮" value="ProjectOuterPay_Edit.项目外包" />外包收费修改
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->外包收费管理->删除按钮" value="ProjectOuterPay_List.项目外包|del" />外包收费删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->客户管理" value="ProjectBid_List" />客户管理列表
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->客户管理->新增按钮" value="ProjectBid_Add" />客户管理添加
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->客户管理->编辑按钮" value="ProjectBid_Edit" />客户管理修改
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->客户管理->删除按钮" value="ProjectBid_List.del" />客户管理删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：经营管理->统计报表" value="Report1" />统计报表列表<br />
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->表单管理" value="FlowForm_List" />表单管理列表
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->表单管理->新增按钮" value="FlowForm_Add" />表单管理添加
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->表单管理->编辑按钮" value="FlowForm_Edit" />表单管理修改
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->表单管理->删除按钮" value="FlowForm_List.del" />表单管理删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->短语管理" value="FlowFormWord_List" />短语管理列表
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->短语管理->新增按钮" value="FlowFormWord_Add" />短语管理添加
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->短语管理->编辑按钮" value="FlowFormWord_Edit" />短语管理修改
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->短语管理->删除按钮" value="FlowFormWord_List.del" />短语管理删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->流程管理" value="Flow_List" />流程管理列表
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->流程管理->新增按钮" value="Flow_Add" />流程管理添加
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->流程管理->编辑按钮" value="Flow_Edit" />流程管理修改
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->流程管理->删除按钮" value="Flow_List.del" />流程管理删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->节点管理" value="FlowNode_List" />节点管理列表
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->节点管理->新增按钮" value="FlowNode_Add" />节点管理添加
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->节点管理->编辑按钮" value="FlowNode_Edit" />节点管理修改
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->节点管理->删除按钮" value="FlowNode_List.del" />节点管理删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->工作管理" value="FlowWork_List" />工作管理列表
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->工作管理->查看按钮" value="Flow_Show" />流程图查看
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->工作管理->修改按钮" value="FlowWork_Edit" />流程图修改
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->工作管理->办理按钮" value="FlowWork_Deal" />流程图办理<br />
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->工作管理->新增按钮" value="FlowWork_Add" />工作管理添加
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->工作管理->编辑按钮" value="FlowWork_Edit" />工作管理修改<br />
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->工作任务安排" value="FlowNodeTask_List" />任务安排列表
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->工作任务安排->新增按钮" value="FlowNodeTask_Add" />任务安排添加
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->工作任务安排->编辑按钮" value="FlowNodeTask_Edit" />任务安排修改
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->工作任务安排->删除按钮" value="FlowNodeTask_List.del" />任务安排删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->卷册任务安排" value="DesignTask_List" />卷册任务安排列表
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->卷册任务安排->新增按钮" value="DesignTask_Add" />卷册任务添加
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->卷册任务安排->编辑按钮" value="DesignTask_Edit" />卷册任务修改
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->卷册任务安排->删除按钮" value="DesignTask_Add.del" />卷册任务删除
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->卷册任务安排->执行按钮" value="DesignTask_List2" />卷册任务执行
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->卷册任务安排->上传按钮" value="DesignTask_Upload" />卷册任务上传
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->卷册任务执行->校审核验单按钮" value="DesignTask_Correct" />校审核验单查看<br />
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->卷册任务安排->执行按钮" value="FlowWork_List2" />进度监控查看<br />
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->工作监察" value="FlowWorkLog_List" />工作监察列表<br />
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->设计版本管理" value="DesignVertion_List" />设计版本管理列表<br />
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->生产汇总" value="Report2" />生产汇总列表<br />
                            <input name="LimitInfo" type="checkbox" title="权限：主流程-确认主设" value="ProjectDesigner_Add" />确认主设<br />
                            <input name="LimitInfo" type="checkbox" title="权限：主流程-确认主设删除" value="ProjectDesigner_Add.del" />确认主设删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：主流程-主设人员审批" value="ProjectDesigner_Confirm" />主设人员审批<br />
                            <input name="LimitInfo" type="checkbox" title="权限：主流程-卷册任务书审批" value="DesignTask_Confirm" />卷册任务书审批<br />
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->项目变更单" value="DesignChange_List" />项目变更单列表
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->项目变更单->新增按钮" value="DesignChange_Add" />项目变更单添加
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->项目变更单->编辑按钮" value="DesignChange_Edit" />项目变更单修改
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->项目变更单->删除按钮" value="DesignChange_List.del" />项目变更单删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->其他工日" value="disk" />共享资源查看
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->其他工日->新增按钮" value="disk_Add" />共享资源添加
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->其他工日->编辑按钮" value="disk_Edit" />共享资源修改
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->其他工日->删除按钮" value="disk_List.del" />共享资源删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->其他工日" value="OtherWork_List" />其他工日查看
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->其他工日->新增按钮" value="OtherWork_Add" />其他工日添加
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->其他工日->编辑按钮" value="OtherWork_Edit" />其他工日修改
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->其他工日->删除按钮" value="OtherWork_List.del" />其他工日删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->外来资料" value="OutFile_List" />外来资料查看
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->外来资料->新增按钮" value="OutFile_Add" />外来资料添加
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->外来资料->编辑按钮" value="OutFile_Edit" />外来资料修改
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->外来资料->删除按钮" value="OutFile_List.del" />外来资料删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->进度管理表" value="PlanManage_List" />进度管理表查看
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->进度管理表->新增按钮" value="PlanManage_Add" />进度管理表添加
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->进度管理表->编辑按钮" value="PlanManage_Edit" />进度管理表修改
                            <input name="LimitInfo" type="checkbox" title="权限：生产管理->进度管理表->删除按钮" value="PlanManage_List.del" />进度管理表删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->设计外包管理" value="ProjectOuter_List.设计外包" />设计外包管理列表
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->设计外包管理->新增按钮" value="ProjectOuter_Add.设计外包" />设计外包管理添加
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->设计外包管理->编辑按钮" value="ProjectOuter_Edit.设计外包" />设计外包管理修改
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->设计外包管理->查看按钮" value="ProjectOuter_List.设计外包|read" />设计外包管理查看
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->设计外包管理->删除按钮" value="ProjectOuter_List.设计外包|del" />设计外包管理删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->设计外包收费->删除按钮" value="ProjectOuterPay_List.设计外包" />设计外包收费列表
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->设计外包收费->新增按钮" value="ProjectOuterPay_Add.设计外包" />设计外包收费添加
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->设计外包收费->编辑按钮" value="ProjectOuterPay_Edit.设计外包" />设计外包付款修改
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->设计外包收费->删除按钮" value="ProjectOuterPay_List.设计外包|del" />设计外包付款删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->外包单位分类" value="Class_List.设计外包单位" />设计外包单位分类查看
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->外包单位分类->新增按钮" value="Class_Add.设计外包单位" />设计外包单位分类添加
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->外包单位分类->编辑按钮" value="Class_Edit.设计外包单位" />设计外包单位分类修改
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->外包单位分类->删除按钮" value="Class_List.设计外包单位|del" />设计外包单位分类删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->外包单位管理" value="ProjectOuterCompany_List.设计外包单位" />外包单位列表
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->外包单位管理->新增按钮" value="ProjectOuterCompany_Add.设计外包单位" />外包单位添加
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->外包单位管理->编辑按钮" value="ProjectOuterCompany_Edit.设计外包单位" />外包单位修改
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->外包单位管理->删除按钮" value="ProjectOuterCompany_List.设计外包单位|del" />外包单位删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->采购管理" value="ProjectOuter_List.采购" />采购管理列表
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->采购管理->新增按钮" value="ProjectOuter_Add.采购" />采购管理添加
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->采购管理->编辑按钮" value="ProjectOuter_Edit.采购" />采购管理修改
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->采购管理->查看按钮" value="ProjectOuter_List.采购|read" />采购管理查看
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->采购管理->删除按钮" value="ProjectOuter_List.采购|del" />采购管理删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->采购收费管理" value="ProjectOuterPay_List.采购" />采购付款管理列表
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->采购收费管理->新增按钮" value="ProjectOuterPay_Add.采购" />采购付款管理添加
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->采购收费管理->编辑按钮" value="ProjectOuterPay_Edit.采购" />采购付款管理修改
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->采购收费管理->删除按钮" value="ProjectOuterPay_List.采购|del" />采购付款管理删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->采购单位分类" value="Class_List.采购单位" />采购单位分类查看
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->采购单位分类->新增按钮" value="Class_Add.采购单位" />采购单位分类添加
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->采购单位分类->编辑按钮" value="Class_Edit.采购单位" />采购单位分类修改
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->采购单位分类->删除按钮" value="Class_List.采购单位|del" />采购单位分类删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->采购单位管理" value="ProjectOuterCompany_List.采购单位" />采购单位管理列表
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->采购单位管理->新增按钮" value="ProjectOuterCompany_Add.采购单位" />采购单位管理添加
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->采购单位管理->编辑按钮" value="ProjectOuterCompany_Edit.采购单位" />采购单位管理修改
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->采购单位管理->删除按钮" value="ProjectOuterCompany_List.采购单位|del" />采购单位管理删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->施工管理" value="ProjectOuter_List.施工" />施工管理列表
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->采购单位管理->新增按钮" value="ProjectOuter_Add.施工" />施工管理添加
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->采购单位管理->编辑按钮" value="ProjectOuter_Edit.施工" />施工管理修改
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->采购单位管理->查看按钮" value="ProjectOuter_List.施工|read" />施工管理查看
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->采购单位管理->删除按钮" value="ProjectOuter_List.施工|del" />施工管理删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->施工收费管理" value="ProjectOuterPay_List.施工" />施工付款管理查看
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->施工收费管理->新增按钮" value="ProjectOuterPay_Add.施工" />施工付款管理添加
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->施工收费管理->编辑按钮" value="ProjectOuterPay_Edit.施工" />施工付款管理修改
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->施工收费管理->删除按钮" value="ProjectOuterPay_List.施工|del" />施工付款管理删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->施工单位分类" value="Class_List.施工单位" />施工单位分类查看
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->施工单位分类->新增按钮" value="Class_Add.施工单位" />施工单位分类添加
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->施工单位分类->编辑按钮" value="Class_Edit.施工单位" />施工单位分类修改
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->施工单位分类->删除按钮" value="Class_List.施工单位|del" />施工单位分类删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->施工单位" value="ProjectOuterCompany_List.施工单位" />施工单位管理列表
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->施工单位->新增按钮" value="ProjectOuterCompany_Add.施工单位" />施工单位管理添加
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->施工单位->编辑按钮" value="ProjectOuterCompany_Edit.施工单位" />施工单位管理修改
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->施工单位->删除按钮" value="ProjectOuterCompany_List.施工单位|del" />施工单位管理删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->施工日志管理" value="ProjectBuilderLog_List" />施工日志管理列表
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->施工日志管理->新增按钮" value="ProjectBuilderLog_Add" />施工日志管理添加
                            <input name="LimitInfo" type="checkbox" title="权限：总承包管理->施工日志管理->删除按钮" value="ProjectBuilderLog_List.del" />施工日志管理删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：质量管理->ISO表单管理" value="FlowForm_List" />ISO表单管理列表
                            <input name="LimitInfo" type="checkbox" title="权限：质量管理->ISO表单管理->新增按钮" value="FlowForm_Add" />ISO表单管理添加
                            <input name="LimitInfo" type="checkbox" title="权限：质量管理->ISO表单管理->编辑按钮" value="FlowForm_Edit" />ISO表单管理修改
                            <input name="LimitInfo" type="checkbox" title="权限：质量管理->ISO表单管理->删除按钮" value="FlowForm_List.del" />ISO表单管理删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：质量管理->短语管理" value="FlowFormWord_List" />ISO短语管理查看
                            <input name="LimitInfo" type="checkbox" title="权限：质量管理->短语管理->新增按钮" value="FlowFormWord_Add" />ISO短语管理添加
                            <input name="LimitInfo" type="checkbox" title="权限：质量管理->短语管理->编辑按钮" value="FlowFormWord_Edit" />ISO短语管理修改
                            <input name="LimitInfo" type="checkbox" title="权限：质量管理->短语管理->删除按钮" value="FlowFormWord_List.del" />ISO短语管理删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：质量管理->电子签名" value="UserName_List" />电子签名
                            <input name="LimitInfo" type="checkbox" title="权限：质量管理->电子签名->编辑按钮" value="UserName_Edit" />电子签名修改<br />
                            <input name="LimitInfo" type="checkbox" title="权限：质量管理->网上提资" value="ProjectDocument_List" />网上提资列表
                            <input name="LimitInfo" type="checkbox" title="权限：质量管理->网上提资->新增按钮" value="ProjectDocument_Add" />网上提资添加
                            <input name="LimitInfo" type="checkbox" title="权限：质量管理->网上提资->编辑按钮" value="ProjectDocument_Edit" />网上提资修改
                            <input name="LimitInfo" type="checkbox" title="权限：质量管理->网上提资->删除按钮" value="ProjectDocument_List.del" />网上提资删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：质量管理->电子校审" value="DesignCorrect_List" />电子校审列表
                            <input name="LimitInfo" type="checkbox" title="权限：质量管理->电子校审->新增按钮" value="DesignCorrect_Add" />电子校审添加
                            <input name="LimitInfo" type="checkbox" title="权限：质量管理->电子校审->编辑按钮" value="DesignCorrect_Edit" />电子校审修改
                            <input name="LimitInfo" type="checkbox" title="权限：质量管理->电子校审->删除按钮" value="DesignCorrect_list.del" />电子校审删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：质量管理->设计质量分析" value="Report3" />设计质量分析
                            <input name="LimitInfo" type="checkbox" title="权限：质量管理->工作量统计" value="Report4" />工作量统计<br />
                            <input name="LimitInfo" type="checkbox" title="权限：图档管理->公共档案分类" value="Class_List.公共档案" />公共档案分类查看
                            <input name="LimitInfo" type="checkbox" title="权限：图档管理->公共档案分类->新增按钮" value="Class_Add.公共档案" />公共档案分类添加
                            <input name="LimitInfo" type="checkbox" title="权限：图档管理->公共档案分类->编辑按钮" value="Class_Edit.公共档案" />公共档案分类修改
                            <input name="LimitInfo" type="checkbox" title="权限：图档管理->公共档案分类->删除按钮" value="Class_List.公共档案|del" />公共档案分类删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：图档管理->项目存档" value="ProjectArchive_List" />项目存档查看
                            <input name="LimitInfo" type="checkbox" title="权限：图档管理->项目存档->新增按钮" value="ProjectArchive_Add" />项目存档添加
                            <input name="LimitInfo" type="checkbox" title="权限：图档管理->项目存档->编辑按钮" value="ProjectArchive_Edit" />项目存档修改
                            <input name="LimitInfo" type="checkbox" title="权限：图档管理->项目存档->新增按钮" value="ProjectArchive_List.del" />项目存档删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：图档管理->档案查询" value="ProjectArchive_Search" />档案查询<br />
                            <input name="LimitInfo" type="checkbox" title="权限：图档管理->借阅申请" value="ProjectArchiveRequest_List.借阅申请" />借阅申请查看
                            <input name="LimitInfo" type="checkbox" title="权限：图档管理->借阅申请->新增按钮" value="ProjectArchiveRequest_Add.借阅申请" />借阅申请添加
                            <input name="LimitInfo" type="checkbox" title="权限：图档管理->借阅申请->编辑按钮" value="ProjectArchiveRequest_Edit.借阅申请" />借阅申请修改
                            <input name="LimitInfo" type="checkbox" title="权限：图档管理->借阅申请->删除按钮" value="ProjectArchiveRequest_List.借阅申请|del" />借阅申请删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：图档管理->出版申请" value="ProjectArchiveRequest_List.出版申请" />出版申请查看
                            <input name="LimitInfo" type="checkbox" title="权限：图档管理->出版申请->新增按钮" value="ProjectArchiveRequest_Add.出版申请" />出版申请添加
                            <input name="LimitInfo" type="checkbox" title="权限：图档管理->出版申请->编辑按钮" value="ProjectArchiveRequest_Edit.出版申请" />出版申请修改
                            <input name="LimitInfo" type="checkbox" title="权限：图档管理->出版申请->删除按钮" value="ProjectArchiveRequest_List.出版申请|del" />出版申请删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：图档管理->版本管理" value="ProjectArchiveVertion_List" />版本管理
                            <input name="LimitInfo" type="checkbox" title="权限：图档管理->出版统计" value="Report5" />出版统计<br />
                            <input name="LimitInfo" type="checkbox" title="权限：办公管理->新闻公告" value="Info_List" />新闻公告查看
                            <input name="LimitInfo" type="checkbox" title="权限：办公管理->新闻公告->新增按钮" value="Info_Add" />新闻公告添加
                            <input name="LimitInfo" type="checkbox" title="权限：办公管理->新闻公告->编辑按钮" value="Info_Edit" />新闻公告修改
                            <input name="LimitInfo" type="checkbox" title="权限：办公管理->新闻公告->删除按钮" value="Info_List.del" />新闻公告删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：办公管理->工作计划" value="WeekWork_List" />工作计划查看
                            <input name="LimitInfo" type="checkbox" title="权限：办公管理->工作计划->新增按钮" value="WeekWork_Add" />工作计划添加
                            <input name="LimitInfo" type="checkbox" title="权限：办公管理->工作计划->编辑按钮" value="WeekWork_Edit" />工作计划修改
                            <input name="LimitInfo" type="checkbox" title="权限：办公管理->工作计划->删除按钮" value="WeekWork_List.del" />工作计划删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：办公管理->内部消息" value="Message_List" />内部消息
                            <input name="LimitInfo" type="checkbox" title="权限：办公管理->内部消息->查看按钮" value="Message_Detail" />内部消息查看
                            <input name="LimitInfo" type="checkbox" title="权限：办公管理->内部消息->新增按钮" value="Message_Add" />内部消息添加
                            <input name="LimitInfo" type="checkbox" title="权限：办公管理->内部消息->删除按钮" value="Message_List.del" />内部消息删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：办公管理->人事管理" value="User_List" />人事管理查看
                            <input name="LimitInfo" type="checkbox" title="权限：办公管理->人事管理->新增按钮" value="User_Add" />人事管理添加
                            <input name="LimitInfo" type="checkbox" title="权限：办公管理->人事管理->编辑按钮" value="User_Edit" />人事管理修改
                            <input name="LimitInfo" type="checkbox" title="权限：办公管理->人事管理->删除按钮" value="User_List.del" />人事管理删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：办公管理->共享资源" value="Disk_List" />共享资源查看
                            <input name="LimitInfo" type="checkbox" title="权限：办公管理->共享资源->新增按钮" value="Disk_Add" />共享资源添加
                            <input name="LimitInfo" type="checkbox" title="权限：办公管理->共享资源->编辑按钮" value="Disk_Edit" />共享资源修改
                            <input name="LimitInfo" type="checkbox" title="权限：办公管理->共享资源->删除按钮" value="Disk_List.del" />共享资源删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：系统设置->卷册设置" value="DesignVolume_List" />卷册设置查看
                            <input name="LimitInfo" type="checkbox" title="权限：系统设置->卷册设置->新增按钮" value="DesignVolume_Add" />卷册设置添加
                            <input name="LimitInfo" type="checkbox" title="权限：系统设置->卷册设置->编辑按钮" value="DesignVolume_Edit" />卷册设置修改
                            <input name="LimitInfo" type="checkbox" title="权限：系统设置->卷册设置->删除按钮" value="DesignVolume_Add.del" />卷册设置删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：系统设置->角色权限" value="Limit_List" />角色权限查看
                            <input name="LimitInfo" type="checkbox" title="权限：系统设置->角色权限->新增按钮" value="Limit_Add" />角色权限添加
                            <input name="LimitInfo" type="checkbox" title="权限：系统设置->角色权限->编辑按钮" value="Limit_Edit" />角色权限修改
                            <input name="LimitInfo" type="checkbox" title="权限：系统设置->角色权限->删除按钮" value="Limit_List.del" />角色权限删除<br />
                            <input name="LimitInfo" type="checkbox" title="权限：系统设置->角色权限->编辑按钮" value="DataBack" />数据备份<br />
                            <input name="LimitInfo" type="checkbox" title="权限：系统设置->分类管理" value="Class_List" />分类管理<br />
                            <input name="LimitInfo" type="checkbox" title="权限：系统设置->系统日志" value="Log" />系统日志<br />
                            <input name="LimitInfo" type="checkbox" title="权限：系统设置->系统参数" value="Config" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td height="60" align="center" colspan="2">
                        <input id="btn_submit" type="button" class="aler-btn" runat="server" value="确定提交"
                            onclick="if(checkform(document.forms[0]))" onserverclick="btn_submit_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input id="Button1" runat="server" name="" type="button" class="aler-btn" onclick="window.external.close()"
                            value="关闭窗口" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br>
    </form>
    <script type="text/javascript">
        $(function () {
            var limit = "<%=LimitInfoText %>";
            var limitSplit = limit.split(",");
            //alert(limit);
            for (var i = 0; i < limitSplit.length; i++) {
                $("input[type=checkbox][value='" + limitSplit[i] + "']").attr("checked", "checked");
            }
            //虚拟滚动条
            jsScroll(document.getElementById('div1'), 10, 'divScrollBar');
        });
    </script>
</body>
</html>
