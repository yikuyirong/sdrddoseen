<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wintop.ascx.cs" Inherits="Web.inc.wintop" %>
<HEAD> 
<META HTTP-EQUIV="Pragma" CONTENT="no-cache"> 
<META HTTP-EQUIV="Cache-Control" CONTENT="no-cache"> 
<META HTTP-EQUIV="Expires" CONTENT="0"> 
</HEAD>
<style media=print type="text/css">.noprint{visibility:hidden}</style>
<style type="text/css">
body{background-color:#f0f0f0;margin:0;padding:0}
.aler-top{height:40px;background:url(../images/aler-top.png) repeat-x}
.aler-left{float:left;height:100%;margin-left:15px;display:inline;line-height:40px;padding-left:15px;background:url(../images/aler-jt.png) left center no-repeat;color:#fff;font-size:16px}
.aler-right{float:right;display:inline;height:100%;margin-left:20px;margin-right:10px}
.aler-right span{display:block;float:left;margin-top:15px;width:25px;height:22px}
.aler-right span.aspan1{cursor:arrow;background:url(../images/aler-del.png) left top no-repeat}
.aler-right span.aspan2{cursor:arrow;background:url(../images/aler-del.png) -24px top no-repeat}
.aler-right span.aspan3{cursor:arrow;background:url(../images/aler-del.png) -48px top no-repeat}
.aler-btn{border:none;width:95px;height:32px;background:url(../images/aler-btn1.png) no-repeat;color:#fff;font-size:14px}
</style>
<div id="wintop1" class="aler-top noprint">
	    <div class="aler-left" id="headtitle">信息内容</div>
		<div class="aler-right">
		  <span class="aspan1" onclick="window.external.min()" title="最小化"></span>
		  <span class="aspan2" onclick="window.external.max()" title="最大化"></span>
		  <span class="aspan3" onclick="window.external.close()" title="关闭"></span>
	    </div>
</div>
<script type="text/javascript">
    window.onload = function () {
        headtitle.innerHTML = document.title;
    }
    window.open = function (url, trg) {
        var newWin = document.createElement('a');
        if (trg != null) { newWin.target = trg } else { newWin.target = '_blank' }
        newWin.href = url;
        document.body.appendChild(newWin);
        newWin.focus();
        newWin.click();
    }
</script>