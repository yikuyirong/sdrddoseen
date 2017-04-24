/// <reference path="jquery-1.11.0.js" />

var $$ = new Object(); //定义public类名

var ApiPath = "/"; //API的访问地址

//限制右键和F5刷新
document.oncontextmenu = function () { return false; }
document.onselectstart = function () { return false; }
document.onkeydown = function () { if (event.keyCode == 116 || event.keyCode == 122) { event.keyCode = 0; return false }; }

//全局统一加载事件
$(function () {
    //全局加载条
    $(window).bind("beforeunload", function () { $$.LoadingBox("…正在处理…", 600000); });
    //所有列表页移动表格变色
    $(".tr1 td").mouseover(function () { $(this).siblings().css("background", "#e9e9e9"); $(this).css("background", "#e9e9e9"); });
    $(".tr1 td").mouseout(function () { $(this).siblings().css("background", "#fff"); $(this).css("background", "#fff"); });
});


//全局列表页按钮权限验证
function CheckLimit(limitStr) {
    //var limitStr = "<%=WebCommon.Public.GetUserLimit().ToLower()%>";
    //alert(limitStr);
    $("[limit]").hide();
    for (var i = 0; i < $("[limit]").length; i++) {
        var limit = $("[limit]:eq(" + i + ")").attr("limit").toLowerCase();
        //alert(limit)
        if (limitStr.indexOf(limit) >= 0) {
            $("[limit]:eq(" + i + ")").show();
        }
    }
}

//全局列表页通用搜索方法
function scan(key, value) {
    key = $.trim(key);
    value = $.trim(value);
    var hrefStr = "where=";
    if (key != "") {
        var keys = key.split(',');
        for (var i = 0; i < keys.length; i++) {
            hrefStr += keys[i] + " like '%" + value + "%'";
            if (i != keys.length - 1) hrefStr += " or ";
        }
        //alert(hrefStr);
    }
    //location.href = hrefStr;
    $$.PostUrl(hrefStr);
}

//绑定数据并分页用于信息分页列表
$$.BindDataByPage = function (pageID, tempID, sql, pagesize, pageindex, where, order, callback, type) {
    ///<summary>
    /// 功能：绑定数据并分页用于信息分页列表
    /// 例如：<div id="pager">{startpage} {lastpage} {pageindex}/{pagecount} {nextpage} {endpage}</div>
    /// 范例：BindDataByPage("pager","list1","readinfo",5,1,"id>8","id desc");
    ///</summary>
    var pageObj = $("#" + pageID);
    //绑定数据列表
    //sql = encodeURIComponent(sql);
    if (!type) type = "html";
    $$.BindData(tempID, sql, pagesize, pageindex, where, order,
    function (recordNum) {
        //计算总页数
        var pageCount = parseInt(recordNum / pagesize);
        if (recordNum % pagesize > 0) pageCount++;
        //生成页码
        pageindex = parseInt(pageindex);
        var CurrentCss = "";
        var PageStr = "<a>&lt;</a>";
        for (var i = 1; i <= pageCount; i++) {
            if (i == pageindex) CurrentCss = " class='current'";
            if ((i > pageindex - 4 && i < pageindex + 4) && i != 1 || i == pageCount || i == 1) PageStr += "<a " + CurrentCss + ">" + i + "</a>";
            if (i == pageindex + 5 || (pageindex - 4 - i > 1 && i == 2)) PageStr += "<a>...</a>";
            CurrentCss = "";
        }
        PageStr += "<a>&gt;</a>";
        pageObj.html(PageStr);
        //页码点击事件
        pageObj.find("a").bind("click",
        function () {
            //pageObj.find("a").removeClass("current");
            //$(this).addClass("current");
            if ($(this).text() == "...") return;
            pageindex = $(this).text();
            $$.BindDataByPage(pageID, tempID, sql, pagesize, pageindex, where, order);
        });

        //上一页点击事件
        pageObj.find("a").first().unbind().bind("click",
        function () {
            if (pageindex == 1) return;
            if (pageindex > 1) pageindex--;
            $$.BindDataByPage(pageID, tempID, sql, pagesize, pageindex, where, order);
        });

        //下一页点击事件
        pageObj.find("a").last().unbind().bind("click",
        function () {
            if (pageindex == pageCount) return;
            if (pageindex < pageCount) pageindex++;
            $$.BindDataByPage(pageID, tempID, sql, pagesize, pageindex, where, order);
        });
        if (callback) callback(recordNum);
    }, type);
}

//指定模板绑定数据用于绑定普通列表(模板中用{字段名}来代替要输出的内容)
$$.BindData = function (tempID, sql, pagesize, pageindex, where, order, callback, type) {
    ///<summary>
    /// 功能：指定模板绑定数据用于绑定普通列表(模板中用{字段名}来代替要输出的内容)
    /// 例如：var recordNum=BindData("list1","readinfo",5,1,"id>8","id desc");
    /// 参数：模板ID(多个ID用逗号隔开),调用方法,每页数量,当前页码,条件,排序,回调方法,填充类别(html/text/append)
    ///</summary>
    try {
        $$.LoadingBox("处理中...", 10000);
        for (var x in tempID.split(",")) {
            var tempid = tempID.split(",")[x];
            var tempObj = $("#" + tempid); //初始化模板对象
            var tempStr = $.trim(tempObj.html());
            if (tempStr.indexOf("<!--") >= 0) tempStr = tempStr.substring(4, $.trim(tempObj.html()).length - 3); //获取模板内容并去除两边空白和注释符
            if (!tempObj.data("template")) tempObj.data("template", tempStr); //对象附加模板
        }
        var recordNum = 0;
        //sql = encodeURIComponent(sql);//转换URL编码
        var Url = ApiPath + "api.ashx?action=data_read&sql=" + sql + "&pagesize=" + pagesize + "&pageindex=" + pageindex + "&where=" + encodeURIComponent(where) + "&order=" + order + "&callback=?";
        $.ajaxSetup({ async: true }); //false为同步 true为异步
        $.getJSON(Url,
        function (data) {
            $$.LoadingBox(0);
            if (type) { if (type == "debug") alert(JSON.stringify(data)); } //json转字符串 错误调试
            for (var x in tempID.split(",")) {
                var tempid = tempID.split(",")[x];
                var tempObj = $("#" + tempid);
                var result = ""; //定义返回结果
                $(data).each(function (index) { //遍历Json数组
                    var obj = data[index]; //获取当前Json对象
                    var template = tempObj.data("template"); //获取目标模板
                    for (name in obj) {
                        //遍历数据填充模板并累加结果(支持大写和小写)
                        var objvalue = obj[name];

                        //判断包含冒号并把冒号后面的数字作为截取字符的数量或时间格式化
                        //{title:10}截取10个字符  {datetime:yyyy-MM-dd}格式化年月日具体看Format方法
                        if (template.indexOf(name + ":") > 0)//大写
                        {
                            var indexValue = template.indexOf(name + ":") + name.length + 1;
                            var cutNum = template.substring(indexValue, indexValue + 20).indexOf("}");
                            var cutNumStr = template.substring(indexValue, indexValue + cutNum);
                            objvalue = objvalue.replace(new RegExp("-", "g"), "/");
                            if (cutNum > 4) objvalue = new Date(objvalue).format(cutNumStr);
                            else objvalue = objvalue.substring(0, cutNumStr);
                        }
                        if (template.indexOf(name.toLowerCase() + ":") > 0)//小写
                        {
                            var indexValue = template.indexOf(name.toLowerCase() + ":") + name.length + 1;
                            var cutNum = template.substring(indexValue, indexValue + 20).indexOf("}");
                            var cutNumStr = template.substring(indexValue, indexValue + cutNum);
                            objvalue = objvalue.replace(new RegExp("-", "g"), "/");
                            if (cutNum > 4) objvalue = new Date(objvalue).format(cutNumStr);
                            else objvalue = objvalue.substring(0, cutNumStr);
                        }
                        //if(tempID=="list2" && name.toLowerCase()=="dealuser")alert(name);调试语句
                        //含冒号不含冒号的都做数据替换处理（正则匹配{}的字符串）
                        template = template.replace(new RegExp("{" + name + "([^\}]*)}", "g"), objvalue);
                        template = template.replace(new RegExp("{" + name.toLowerCase() + "([^\}]*)}", "g"), objvalue);
                    }
                    result += template;
                });
                //结果写入目标容器
                if (!type) type = "html";
                if (type == "debug") type = "html";
                if (tempObj.is(":hidden")) {
                    eval("tempObj." + type + "(result)");
                }
                else {
                    eval("tempObj." + type + "(result).hide().fadeIn()");
                }
            }
            if (data.length > 0) { if (data[0].RecordNum) recordNum = data[0].RecordNum; }
            if (callback) callback(recordNum); //回调返回记录数
        });
        return recordNum; //如果想有返回记录总数必须传async参数为false
    } catch (err) {
        $$.LoadingBox(err.message, 1000);
    }
}

//根据SQL语句获取Json
$$.GetTableJson = function (sql, pagesize, pageindex, where, order, callback) {
    ///<summary>
    /// 功能：根据SQL语句获取Json
    ///</summary>
    sql = encodeURIComponent(sql);
    var Url = ApiPath + "api.ashx?action=data_read&sql=" + sql + "&where=" + where + "&order=" + order + "&pagesize=" + pagesize + "&pageindex=" + pageindex + "&callback=?";
    $.ajaxSetup({ async: true }); //false为同步 true为异步
    $.getJSON(Url, callback);
}

//模板格式化填充(以数据库表某一个表数据序列化后的单维数组Json填充)
$$.FillTable = function (tempStr, jsonObj) {
    ///<summary>
    /// 功能：模板格式化填充(以数据库表某一个表数据序列化后的单维数组Json填充)
    /// 说明：遍历数据填充模板并累加结果(支持大写和小写)
    ///</summary>
    var result = "";
    for (data in jsonObj) {
        var obj = jsonObj[data];
        result += $$.Fill(tempStr, obj);
    }
    return result;
}

//模板格式化填充(以数据库表某一行数据序列化后的单维数组Json填充)
$$.Fill = function (tempStr, jsonObj) {
    ///<summary>
    /// 功能：模板格式化填充(以数据库表某一行数据序列化后的单维数组Json填充)
    /// 说明：遍历数据填充模板并累加结果(支持大写和小写)
    ///</summary>
    for (name in jsonObj) {
        tempStr = tempStr.replace(new RegExp("{" + name + "}", "g"), jsonObj[name]);
        tempStr = tempStr.replace(new RegExp("{" + name.toLowerCase() + "}", "g"), jsonObj[name]);
    }
    return tempStr;
}

//对象赋值为指定ID的表的某个字段值
$$.SetValue = function (obj, table, field, where) {
    ///<summary>
    /// 功能：(异步)对象赋值为指定ID的表的某个字段值
    /// 例如：SetValue($("#pager"),"tbl_admin","adminname","id=1");
    ///</summary>
    var Url = ApiPath + "api.ashx?action=data_getvalue&table=" + table + "&where=" + where + "&field=" + field + "&callback=?";
    $.ajaxSetup({ async: true }); //false为同步 true为异步
    $.getJSON(Url,
    function (data) {
        alert(JSON.stringify(data)); //json转字符串
        if (obj[0].tagName.toLowerCase() == "input") {
            obj.val(data.result);
        } else {
            obj.html(data.result);
        }
    });
}

//将某个对象组字符串截取指定长度并还原原位
$$.CutStr = function (obj, start, end) {
    ///<summary>
    /// 功能：将字符串截取指定长度
    /// 例如：CutStr($(".name"),0,5)截取前6个字符
    ///</summary>
    for (var i = 0; i < obj.length; i++) {
        var splitStr = $(obj[i]).html().substring(start, end);
        $(obj[i]).html(splitStr);
    }
}

//日期格式化将Date转化为指定格式的String
Date.prototype.format = function (fmt) {
    ///<summary>
    /// 功能：将 Date 转化为指定格式的String
    /// 说明：月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字)
    /// 范例：(new Date()).format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
    /// 范例：(new Date()).format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18
    ///</summary>
    var o = {
        "M+": this.getMonth() + 1,                 //月份 
        "d+": this.getDate(),                    //日 
        "h+": this.getHours(),                   //小时 
        "m+": this.getMinutes(),                 //分 
        "s+": this.getSeconds(),                 //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds()             //毫秒 
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}

//模板格式化数据填充
$$.Format = function (source, params) {
    ///<summary>
    /// 功能：模板格式化数据填充
    /// 说明：var text="a{0}b{1}c{2}" $$.Format(text,"x","y","z")
    ///</summary>
    if (arguments.length == 1) return function () {
        var args = $.makeArray(arguments);
        args.unshift(source);
        return $.format.apply(this, args);
    };
    if (arguments.length > 2 && params.constructor != Array) {
        params = $.makeArray(arguments).slice(1);
    }
    if (params.constructor != Array) {
        params = [params];
    }
    $.each(params,
    function (i, n) {
        source = source.replace(new RegExp("\\{" + i + "\\}", "g"), n);
    });
    return source;
};

//向当前页面发送URL参数，原有参数自动替换，没有的参数自动新增
$$.PostUrl = function (urlstring) {
    ///<summary>
    /// 功能：向当前页面发送URL参数，原有参数自动替换，没有的参数自动新增
    /// 说明：PostUrl("area=3")//单参数变量  PostUrl("area=3&city=7")//多参数变量
    ///</summary>
    var locationhref;
    var UrlSplit;
    var UrlStringSplit;
    var PString;
    var PurlString;
    var isExist;
    if (location.href.indexOf('?') > 0) {
        locationhref = location.href.split('?')[1];
        UrlSplit = locationhref.split('&');
        UrlStringSplit = urlstring.split('&');
        for (var m = 0; m < UrlStringSplit.length; m++) {
            PurlString = UrlStringSplit[m];
            isExist = 0;
            for (var l = 0; l < UrlSplit.length; l++) {
                PString = UrlSplit[l];
                if (PString.split('=')[0] == PurlString.split('=')[0]) {
                    locationhref = locationhref.replace(PString, PurlString);
                    isExist = 1;
                    break;
                }
            }
            if (isExist == 0) {
                locationhref += "&" + PurlString;
            }
        }
        if (locationhref.indexOf('&') == 0) {
            locationhref = locationhref.replace('&', '');
        }
        window.location = "?" + locationhref;
    } else {
        window.location = "?" + urlstring;
    }
}

//获取页面URL参数值
$$.Request = function (paras) {
    ///<summary>
    /// 功能：获取页面URL参数值
    /// 说明：$$.Request("area")
    ///</summary>
    var url = location.href;
    var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
    var paraObj = {}
    for (i = 0; j = paraString[i]; i++) {
        paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
    }
    var returnValue = paraObj[paras.toLowerCase()];
    if (typeof (returnValue) == "undefined") {
        return "";
    } else {
        return returnValue;
    }
}

//全屏自定义透明加载框
$$.LoadingBox = function (msg, timeout, url) {
    ///<summary>
    /// 功能：全屏自定义透明加载框
    /// 说明：也可以用于信息提示一下就消失
    ///</summary>
    if (arguments[0] == 0) {
        $$.MsgBox(0);
    }
    else {
        $$.MsgBox("", "<center style='line-height:20px;padding:6px;width:130px;color:#3D832F;font-weight:bold'>" + msg + "</center>", "", "", timeout);
    }
    if (url) setTimeout("window.location = '" + url + "'", timeout);
}

//全屏自定义透明消息框
var MsgBoxTime; //控制超时对象
$$.MsgBox = function (inTitle, inContent, inBtn1, inBtn2, timeOut) {
    ///<summary>
    /// 功能：全屏自定义透明消息框
    /// 说明：如果内容超过15个字会自动识别为html格式(可以手动定义内容样式) 范例：请看public.js中详细说明
    ///</summary>
    //$$.MsgBox("标题","内容","确定:alert('true')","取消:alert('false')",3000);//自定义标题、内容、按钮、事件、3秒后自动关闭
    //$$.MsgBox("标题","内容","确定:alert('true')","取消:alert('false')");//自定义标题、内容、按钮、事件
    //$$.MsgBox("标题","内容","立刻执行:$$.MsgBox(0)");//自定义标题、内容、自定单个按钮及事件
    //$$.MsgBox("标题","内容","","");//自定义标题、内容、不显示按钮
    //$$.MsgBox("标题","内容");//自定义标题、内容、只显示确认按钮
    //$$.MsgBox("","<center style='padding:15px;line-height:15px'>操作成功!</center>","","",2000);//自定义只显示内容、不显示标题及按钮、可以配合$$.MsgBox(0)/或超时关闭提示
    //$$.MsgBox("内容");//自定义内容、显示默认标题和确认按钮
    //$$.MsgBox(0);//关闭提示框0 打开提示框1
    $(".msgdiv").remove();
    var title = inTitle;
    var content = inContent;
    var btn1 = inBtn1;
    var btn2 = inBtn2;
    var btn1fun = btn2fun = "$$.MsgBox(0)";
    var state = 1; //默认显示提示框
    if (arguments.length == 1) {
        if (arguments[0] == 0) state = 0; //如果只有一个参数并且等于0那么关闭提示框
        if (arguments[0].length > 0) content = arguments[0];
    }
    if (arguments[0] == null || arguments[0] == "" || arguments.length == 1) title = "提示消息";
    if (arguments[1] == null && arguments.length > 1 || arguments.length == 0) content = "这是一条提示消息的内容";
    if (arguments[2] == null) { btn1 = "确定"; }
    else {
        btn1 = btn1;
        if (btn1.indexOf(':') > 0) { btn1fun = btn1.split(':')[1]; btn1 = btn1.split(':')[0]; }
    }
    if (arguments[3] == null) { btn2 = "取消"; }
    else {
        btn2 = btn2;
        if (btn2.indexOf(':') > 0) { btn2fun = btn2.split(':')[1]; btn2 = btn2.split(':')[0]; }
    }
    var styleStr1 = "display:none;position:absolute;top:0;left:0;z-index:0;width:100%;height:100%;background:#ccc;opacity:0.3;filter:alpha(opacity=30);box-sizing:border-box;-moz-box-sizing:border-box;-webkit-box-sizing:border-box;";
    var styleStr2 = "display:none;position:absolute;margin-left:-10em;left:50%;top:50%;border-radius:0.5em;background-color:#fff;border:1px solid #CFF1EB;";
    var tempstr1 = '<div class=msgdiv style=' + styleStr1 + '></div>';
    var tempstr2 = tempstr1 +
    '<div class=msgdiv style="' + styleStr2 + '">' +
	'<div style="height:30px; line-height:30px;padding-left:1em;font-size:14px; border-bottom:1px solid #CFF1EB;cursor:arrow; color:#41cfb9;">' + title + '<div onclick="$$.MsgBox(0)" style="text-align:center;width:25px;float:right;position:absolute;padding:0px;top:-2px;right:0px">x</div></div>' +
    '<div style="padding:1em;font-size:14px; color:#525252">' + content + '</div>' +
    '<div class="msgbtn" style="height:30px; border-top:1px solid #F0F0F0;">' +
    '<div class="touch" style="border-radius:0 0 0 0.5em;float:left; width:49%;height:30px; font-size:14px; line-height:30px; color:#41cfb9;text-align:center; border:0; cursor:default">' + btn1 + '</div>' +
    '<div class="touch" style="border-radius:0 0 0.5em 0;float:left; width:49%;height:30px; font-size:14px; line-height:30px; color:#41cfb9;text-align:center; border-left:1px solid #F0F0F0; cursor:default">' + btn2 + '</div>' +
    '</div>' +
	'</div>';
    if ($(".msgdiv").length == 0) $("body").append(tempstr2);
    if (arguments[3] == "" || arguments[3] == null) {
        $(".msgbtn div:first-child").width("100%");
        $(".msgbtn div:last-child").hide();
    }
    else {
        $(".msgbtn div:first-child").width("49%");
        $(".msgbtn div:last-child").show();
    }
    $(".msgbtn div:first-child").unbind().bind("click", function () { eval(btn1fun); });
    $(".msgbtn div:last-child").unbind().bind("click", function () { eval(btn2fun); });
    if (state == 1) {
        if (btn1 == "") $(".msgdiv").fadeIn(500);
        else $(".msgdiv:eq(0)").fadeIn(500);
        //$(parent.window.document.body).append(tempstr1);//父系Body变色
        //$(parent.window.document.body).find(".msgdiv").show();
    }
    else if (state == 0) {
        $(".msgdiv").fadeOut();
        //$(".msgdiv:eq(1)").animate({ top: "0", opacity: 0 }, "fast");
        //$(parent.window.document.body).find(".msgdiv").hide();
        return; //返回
        //uexWindow.evaluateScript('', 0, 'if($(".msgdiv").length==0){$("body").append("'+tempstr1+'");}$(".msgdiv").hide()');
    }
    //加载完html之后处理事件
    if (content.length > 15) {
        $(".msgdiv:eq(1) div:eq(1)").css("padding", "0em"); //如果作为HTML浮窗所以内容不需要边距
        $(".msgdiv:eq(1)").css("width", "150px");
    }
    else {
        $(".msgdiv:eq(1)").css("width", "150px"); //处理默认消息框的宽度
    }
    if (inTitle == "" && state != 0) {
        $(".msgdiv:eq(1) div:eq(0)").hide(); //如果标题参数为空隐藏标题
        //$(".msgdiv:eq(1) div:eq(1)").css("padding","0em");//如果作为HTML浮窗所以内容不需要边距
        $(".msgdiv:eq(1) div:eq(1)").children().first().css("border-radius", "0.3em 0.3em 0em 0em"); //如果标题隐藏内容内第一个对象上方加圆角
    }
    if (inBtn1 == "") {
        $(".msgbtn").hide(); //如果第三个参数为空隐藏按钮
        //$(".msgdiv:eq(1) div:eq(1)").css("padding-left","0em");//如果作为HTML浮窗所以内容不需要边距
        if (inTitle == "") {
            $(".msgdiv:eq(1) div:eq(1)").children().first().css("border-radius", "0.3em"); //如果按钮隐藏并且标题也隐藏那么内容内第一个对象加圆角
        }
        else {
            $(".msgdiv:eq(1) div:eq(1)").children().first().css("border-radius", "0em 0em 0.3em 0.3em"); //如果按钮隐藏内容内第一个对象下方加圆角
        }
    }
    if ($(".msgdiv:eq(1) div:eq(1)").html().indexOf(" src") > 0) {
        //如果内容中有图片等待图片加载完毕再计算宽高定位
        var img = new Image();
        img.src = $(".msgdiv:eq(1) div:eq(1) [src]").attr("src");
        img.onload = function () {
            var contentWidth = $(".msgdiv:eq(1)").width();
            var contentHeight = $(".msgdiv:eq(1)").height();
            var contentWidthLeft = $(".msgdiv:eq(1)").width() / 2;
            var contentHeightTop = $(".msgdiv:eq(1)").height() / 2;
            var contentTop = window.screen.height / 3.5 + $(document).scrollTop();
            contentWidthLeft = "-" + contentWidthLeft + "px";
            contentHeightTop = "-" + contentHeightTop + "px";
            $(".msgdiv:eq(0)").height($(document).height());
            $(".msgdiv:eq(1)").css({ "width": contentWidth, "height": contentHeight, "margin-left": contentWidthLeft, "margin-top": contentHeightTop, "top": contentTop });
        };
    }
    else {
        //直接计算宽高定位
        var contentWidth = $(".msgdiv:eq(1)").width();
        var contentHeight = $(".msgdiv:eq(1)").height();
        var contentWidthLeft = $(".msgdiv:eq(1)").width() / 2;
        var contentHeightTop = $(".msgdiv:eq(1)").height() / 2;
        var contentTop = window.screen.height / 3.5 + $(document).scrollTop();
        contentWidthLeft = "-" + contentWidthLeft + "px";
        contentHeightTop = "-" + contentHeightTop + "px";
        $(".msgdiv:eq(0)").height($(document).height());
        $(".msgdiv:eq(1)").css({ "width": contentWidth, "height": contentHeight, "margin-left": contentWidthLeft, "margin-top": contentHeightTop, "top": contentTop });
    }
    if (arguments[4] != null) {
        clearTimeout(MsgBoxTime); //关闭超时开关(防止超时关闭后来新开的MsgBox)
        MsgBoxTime = setTimeout("$$.MsgBox(0)", arguments[4]); //超时自动关闭
    }
    else {
        clearTimeout(MsgBoxTime); //关闭超时开关(防止超时关闭后来新开的MsgBox)
    }
    //处理展现动画
    var msgTop = $(".msgdiv:eq(1)").css("top");
    if (btn1 != "") $(".msgdiv:eq(1)").show().css({ "top": "0", "opacity": "0" }).animate({ top: msgTop, opacity: 1 }, "fast"); //.animate({ zoom: 1.05 }, "fast").animate({ zoom: 1 }, "fast");
}

//cookie的应用方法
$$.Cookie = function (name, value, options) {
    ///<summary>
    /// 功能：Cookie的应用方法
    /// 说明：$$.Cookie("name", "value");设置Cookie的值，把name变量的值设为value
    /// 说明：$$.Cookie("name", "value", {expires: 7, path: "/", domain: "jquery.com", secure: true});新建一个Cookie 包括有效期 路径 域名等
    /// 说明：$$.Cookie("name", null);删除一个Cookie
    /// 说明：var account= $$.Cookie("name");取Cookie(name)值给account
    ///</summary>
    if (typeof value != 'undefined') {
        options = options || {};
        if (value === null) {
            value = '';
            options.expires = -1;
        }
        var expires = '';
        if (options.expires && (typeof options.expires == 'number' || options.expires.toUTCString)) {
            var date;
            if (typeof options.expires == 'number') {
                date = new Date();
                date.setTime(date.getTime() + (options.expires * 24 * 60 * 60 * 1000));
            } else {
                date = options.expires;
            }
            expires = '; expires=' + date.toUTCString();
        }
        var path = options.path ? '; path=' + options.path : '';
        var domain = options.domain ? '; domain=' + options.domain : '';
        var secure = options.secure ? '; secure' : '';
        document.cookie = [name, '=', encodeURIComponent(value), expires, path, domain, secure].join('');
    } else {
        var cookieValue = null;
        if (document.cookie && document.cookie != '') {
            var cookies = document.cookie.split(';');
            for (var i = 0; i < cookies.length; i++) {
                var cookie = jQuery.trim(cookies[i]);
                // Does this cookie string begin with the name we want?
                if (cookie.substring(0, name.length + 1) == (name + '=')) {
                    cookieValue = decodeURIComponent(cookie.substring(name.length + 1));
                    break;
                }
            }
        }
        return cookieValue;
    }
};

//异步上传图片$$封装
$$.Upload = function (fileId, url, callback) {
    ///<summary>
    /// 功能：异步上传图片$$封装
    /// 说明：$$.Upload("file1",ApiPath+"api.ashx?action=data_upload&folder=pic&size=500000&width=300&height=300&callback=?",function(data,status){}) 保存到PIC文件夹并500K限制缩略300*300
    ///</summary>
    $.ajaxFileUpload({
        url: url,
        secureuri: false,
        fileElementId: fileId,
        dataType: "Text",
        success: function (data, status) {
            callback(data, status);
        }
    });
}
//异步上传图片$封装
//$.ajaxFileUpload({url:ApiPath+"api.ashx",secureuri:false,fileElementId: 'fileToUpload',dataType: 'html',success:function(data,status){}});
$.extend({
    createUploadIframe: function (id, uri) {
        //create frame
        var frameId = 'jUploadFrame' + id;
        var iframeHtml = '<iframe id="' + frameId + '" name="' + frameId + '" style="position:absolute; top:-9999px; left:-9999px"';
        if (window.ActiveXObject) {
            if (typeof uri == 'boolean') {
                iframeHtml += ' src="' + 'javascript:false' + '"';

            } else if (typeof uri == 'string') {
                iframeHtml += ' src="' + uri + '"';

            }
        }
        iframeHtml += ' />';
        jQuery(iframeHtml).appendTo(document.body);

        return jQuery('#' + frameId).get(0);
    },
    createUploadForm: function (id, fileElementId, data) {
        //create form	
        var formId = 'jUploadForm' + id;
        var fileId = 'jUploadFile' + id;
        var form = jQuery('<form  action="" method="POST" name="' + formId + '" id="' + formId + '" enctype="multipart/form-data"></form>');
        if (data) {
            for (var i in data) {
                jQuery('<input type="hidden" name="' + i + '" value="' + data[i] + '" />').appendTo(form);
            }
        }
        var oldElement = jQuery('#' + fileElementId);
        var newElement = jQuery(oldElement).clone();
        jQuery(oldElement).attr('id', fileId);
        jQuery(oldElement).attr('name', fileElementId);
        jQuery(oldElement).before(newElement);
        jQuery(oldElement).appendTo(form);
        //set attributes
        jQuery(form).css('position', 'absolute');
        jQuery(form).css('top', '-1200px');
        jQuery(form).css('left', '-1200px');
        jQuery(form).appendTo('body');
        return form;
    },
    ajaxFileUpload: function (s) {
        // TODO introduce global settings, allowing the client to modify them for all requests, not only timeout		
        s = jQuery.extend({},
        jQuery.ajaxSettings, s);
        var id = new Date().getTime();
        var form = jQuery.createUploadForm(id, s.fileElementId, (typeof (s.data) == 'undefined' ? false : s.data));
        var io = jQuery.createUploadIframe(id, s.secureuri);
        var frameId = 'jUploadFrame' + id;
        var formId = 'jUploadForm' + id;
        // Watch for a new set of requests
        if (s.global && !jQuery.active++) {
            jQuery.event.trigger("ajaxStart");
        }
        var requestDone = false;
        // Create the request object
        var xml = {}
        if (s.global) jQuery.event.trigger("ajaxSend", [xml, s]);
        // Wait for a response to come back
        var uploadCallback = function (isTimeout) {
            var io = document.getElementById(frameId);
            try {
                if (io.contentWindow) {
                    xml.responseText = io.contentWindow.document.body ? io.contentWindow.document.body.innerHTML : null;
                    xml.responseXML = io.contentWindow.document.XMLDocument ? io.contentWindow.document.XMLDocument : io.contentWindow.document;

                } else if (io.contentDocument) {
                    xml.responseText = io.contentDocument.document.body ? io.contentDocument.document.body.innerHTML : null;
                    xml.responseXML = io.contentDocument.document.XMLDocument ? io.contentDocument.document.XMLDocument : io.contentDocument.document;
                }
            } catch (e) {
                jQuery.handleError(s, xml, null, e);
            }
            if (xml || isTimeout == "timeout") {
                requestDone = true;
                var status;
                try {
                    status = isTimeout != "timeout" ? "success" : "error";
                    // Make sure that the request was successful or notmodified
                    if (status != "error") {
                        // process the data (runs the xml through httpData regardless of callback)
                        var data = jQuery.uploadHttpData(xml, s.dataType);
                        // If a local callback was specified, fire it and pass it the data
                        if (s.success) s.success(data, status);

                        // Fire the global callback
                        if (s.global) jQuery.event.trigger("ajaxSuccess", [xml, s]);
                    } else jQuery.handleError(s, xml, status);
                } catch (e) {
                    status = "error";
                    jQuery.handleError(s, xml, status, e);
                }

                // The request was completed
                if (s.global) jQuery.event.trigger("ajaxComplete", [xml, s]);

                // Handle the global AJAX counter
                if (s.global && ! --jQuery.active) jQuery.event.trigger("ajaxStop");

                // Process result
                if (s.complete) s.complete(xml, status);

                jQuery(io).unbind()

                setTimeout(function () {
                    try {
                        jQuery(io).remove();
                        jQuery(form).remove();

                    } catch (e) {
                        jQuery.handleError(s, xml, null, e);
                    }

                },
                100)

                xml = null

            }
        }
        // Timeout checker
        if (s.timeout > 0) {
            setTimeout(function () {
                // Check to see if the request is still happening
                if (!requestDone) uploadCallback("timeout");
            },
            s.timeout);
        }
        try {

            var form = jQuery('#' + formId);
            jQuery(form).attr('action', s.url);
            jQuery(form).attr('method', 'POST');
            jQuery(form).attr('target', frameId);
            if (form.encoding) {
                jQuery(form).attr('encoding', 'multipart/form-data');
            } else {
                jQuery(form).attr('enctype', 'multipart/form-data');
            }
            jQuery(form).submit();

        } catch (e) {
            jQuery.handleError(s, xml, null, e);
        }

        jQuery('#' + frameId).load(uploadCallback);
        return {
            abort: function () { }
        };

    },
    uploadHttpData: function (r, type) {
        var data = !type;
        data = type == "xml" || data ? r.responseXML : r.responseText;
        // If the type is "script", eval it in global context
        if (type == "script") jQuery.globalEval(data);
        // Get the JavaScript object, if JSON is used.
        if (type == "json") eval("data = " + data);
        // evaluate scripts within html
        if (type == "html") jQuery("<div>").html(data).evalScripts();

        return data;
    }
});

//判断对象是否呈现在浏览器区域并执行相关处理
$$.Monitor = function (objs, callback) {
    ///<summary>
    /// 功能：判断对象是否呈现在浏览器区域并执行相关处理
    /// 范例：在页面onload事件中使用
    /// var step1 = document.getElementById("step1");
    /// var step2 = document.getElementById("step2");
    /// var objs = [step1, step2];
    /// window.onscroll = window.onresize = function()
    /// {
    ///     $$.Monitor(objs, function(obj)
    ///     {
    ///         switch (obj)
    ///         {
    ///             case step1:
    ///                 $$.LoadingBox("按需加载阶段1方法", 1000);
    ///                 break
    ///             case step2:
    ///                 $$.LoadingBox("按需加载阶段2方法", 1000);
    ///                 break
    ///         }
    ///     })
    /// }
    ///</summary>
    var prec1 = $.getClient();
    var prec2;
    for (var i = objs.length - 1; i >= 0; i--) {
        if (objs[i]) {
            prec2 = $.getSubClient(objs[i]);
            if ($.intens(prec1, prec2)) {
                callback(objs[i]);
                // 加载资源后，删除监测
                delete objs[i];
            }
        }
    }
}
$.extend({
    //返回浏览器的可视区域位置 
    getClient: function () {
        var l, t, w, h;
        l = document.documentElement.scrollLeft || document.body.scrollLeft;
        t = document.documentElement.scrollTop || document.body.scrollTop;
        w = document.documentElement.clientWidth;
        h = document.documentElement.clientHeight;
        return { left: l, top: t, width: w, height: h };
    },
    //返回待加载资源位置 
    getSubClient: function (p) {
        var l = 0, t = 0, w, h;
        w = p.offsetWidth;
        h = p.offsetHeight;
        while (p.offsetParent) {
            l += p.offsetLeft;
            t += p.offsetTop;
            p = p.offsetParent;
        }
        return { left: l, top: t, width: w, height: h };
    },
    //判断两个矩形是否相交,返回一个布尔值 
    intens: function (rec1, rec2) {
        var lc1, lc2, tc1, tc2, w1, h1;
        lc1 = rec1.left + rec1.width / 2;
        lc2 = rec2.left + rec2.width / 2;
        tc1 = rec1.top + rec1.height / 2;
        tc2 = rec2.top + rec2.height / 2;
        w1 = (rec1.width + rec2.width) / 2;
        h1 = (rec1.height + rec2.height) / 2;
        return Math.abs(lc1 - lc2) < w1 && Math.abs(tc1 - tc2) < h1;
    }
});

//全局通用验证表单开始
var LoseColor="#ff9000";//失败后颜色
var SuccColor="";//成功后颜色(自动获取)
function checkform(Formname){
/*
* 功能:验证所有的表单
* 使用方法:
* <script language="javascript" src="inc/script.js"></script>
* <form name="form1">
* <input type="text" name="id" check="参数1,参数2,参数3,参数4">
* <input type="submit" onClick="return checkform(form1)">或者写在form里<form name="form1" onsubmit="return checkform(this)">
* </form>
* 全局触发判断方式:if (!checkform(form1)) return;
* 参数使用说明:
* 参数1:如果是必填项该值为"必",如果是可选项该值为"选"
* 参数2:目前有7个值可选
		"空":判断该处不能为空
		"帐":判断该处必须由数字`字母`下划线组成一般用于注册帐号
		"数":判断该处必须为数字
		"邮":判断该处必须为邮件
		"全":判断该处必须为全角字符
		"半":判断该处必须为半角字符
		"英":判断该处必须为字母
		"汉":判断该处必须为汉字
		"网":判断该处必须为网址
		"电":判断该处必须为电话号码
		"日":判断该处必须为日期格式
		"多":判断该处的多项选择 ★例：check="必,多,0,5" 表示为至少选择0个最多选择5个
		"重":当前内容和上边内容相同(密码验证)
* 参数3:限制字符个数的下限
* 参数4:限制字符个数的上限
*例子:check="必,数,0,8" 表示为必选项并且为数字型字符不得超过8个
*例子:check="选,邮,8,8" 表示为可选项并且为邮件型字符数必须为8个
*例子:check="选,英,5,16" 表示为可选项并且为字母型字符数为5~16个之间
*如果表单中含有ewebeditor等在线编辑器请将其调用iframe的名字改为editor即可
*/
//return true;
var obj = Formname.elements;
var BoxValue=0;//多选的初始值
var limit1=0;//多选的初始下限
var limit2=0;//多选的初始上限
//遍历所有表元素
for(var i=0;i<obj.length;i++)
  {
  var checkStr=obj[i].getAttribute("check");
  //是验证检测类型
  if(checkStr)
    {
	  if(checkStr.split(",")[0]=="选"&&obj[i].value!=""||checkStr.split(",")[0]=="必")
	  {
		//替换表单中的非法字符开始
		var nostr="',`,delete,clean,insert,add,update,modify";
		var objvaluestr=obj[i].value;
		//循环替换
		var nosplit=nostr.split(",");
		var nostrnum=nosplit.length;
		var objvaluenum=0;
		for(var m=0;m<nostrnum;m=m+2)
		{
   	    	objvaluenum=objvaluestr.split(nosplit[m]).length;
   	    	for(var k=1;k<objvaluenum;k++)
   	    	{
   	    	objvaluestr=objvaluestr.replace(nosplit[m],nosplit[m+1]);
   	    	}
		}
		//字符还原
		obj[i].value=objvaluestr
        if($(obj[i]).css("border-color")!="1px solid "+colorRgb(LoseColor))SuccColor=$(obj[i]).css("border-color");//获取原始边框颜色
	    //替换表单中的非法字符结束
		if(!obj[i].value){loseback(obj[i],"变色处为必须填写项")}
		else
		 {
		  var switchstr=checkStr.split(",")[1];
		  switch(switchstr)
            {
             case "空" : CheckExp(obj[i],obj[i].value.match(/[^\f\n\r\t\v]/i),"让你随意输都可以出错看样我们的程序有问题谢谢您的反馈");
			 break;
			 case "帐" : CheckExp(obj[i],obj[i].value.match(/^[A-Za-z0-9._@]+$/i),"非法字符: '"+obj[i].value.charAt(obj[i].value.search(/[^A-Za-z0-9._@]/i))+"'\n\n帐号必须由数字、字母、下划线组成");
			 break;
             case "数" : CheckExp(obj[i],obj[i].value.match(/^[0-9.]+$/i),"非法字符: '"+obj[i].value.charAt(obj[i].value.search(/[^0-9.]/i))+"'\n\n变色处必须为数字");
			 break;
			 case "电" : CheckExp(obj[i],obj[i].value.match(/^[0-9-]+$/i),"非法字符: '"+obj[i].value.charAt(obj[i].value.search(/[^0-9-]/i))+"'\n\n变色处必须为电话号码");
			 break;
			 case "日" : CheckExp(obj[i],obj[i].value.match(/^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$/i),"变色处必须为日期格式");
			 break;
			 case "邮" : CheckExp(obj[i],obj[i].value.match(/(.+)\@+([\,\w\.-]+)\.+([\,\w\.-]+)/i),"变色处必须为Email格式");
			 break;
			 case "全" : CheckExp(obj[i],obj[i].value.match(/^[\W\n\r]+$/i),"非法字符: '"+obj[i].value.charAt(obj[i].value.search(/[^\W\n\r]/i))+"'\n\n变色处必须为全角字符");
			 break;
			 case "半" : CheckExp(obj[i],obj[i].value.match(/^[\x00-\x88]+$/i),"非法字符: '"+obj[i].value.charAt(obj[i].value.search(/[^\x00-\x88]/i))+"'\n\n变色处必须为半角字符");
			 break;
			 case "英" : CheckExp(obj[i],obj[i].value.match(/^[a-zA-Z]+$/i),"非法字符: '"+obj[i].value.charAt(obj[i].value.search(/[^a-zA-Z]/i))+"'\n\n变色处必须为字母格式");
			 break;
			 case "汉" : CheckExp(obj[i],obj[i].value.match(/^[^\x00-\xff]+$/i),"非法字符: '"+obj[i].value.charAt(obj[i].value.search(/[\x00-\xff]/i))+"'\n\n变色处必须为汉字");
			 break;
			 case "网" : CheckExp(obj[i],obj[i].value.match(/^http:\/\/([\,\w\.-]+)\.+([\,\w\.-]+)/i),"变色处必须为网址的标准格式!\n如：http://www.doseen.com");
			 break;
			 case "多" : if(obj[i].checked){BoxValue++};limit1=checkStr.split(",")[2];limit2=checkStr.split(",")[3];
			 break;
			 case "重" : if(obj[i].value!=obj[i-1].value){loseback(obj[i],"两次输入的密码不相同！")}else{sucback(obj[i])};
			 break;
			 default  : loseback(obj[i],"校验代码 ‘"+switchstr+"’ 不存在,请程序员核实");
            }
		  }
		}else{result=1}
     }else{result=1}
  if(result==0){return false;}
  }
  //如果存在多选判断开始
  if(parseInt(BoxValue)<parseInt(limit1)){alert("多选处请至少选择"+limit1+"个");return false;}
  if (parseInt(BoxValue) > parseInt(limit2)) { alert("多选处的选择结果不得超过" + limit2 + "个"); return false; }
  return true;
}
//验证成功并检测字符个数后返回结果
function sucback(eimobj)
{
    var checkStr = eimobj.getAttribute("check");
    var strnum1 = parseInt(checkStr.split(",")[2]);
    var strnum2 = parseInt(checkStr.split(",")[3]);
    var strlen = eimobj.value.length;
    var arr = eimobj.value.match(/[^\x00-\x80]/ig);
    if (arr != null) { strlen += arr.length }
    if (parseInt(strlen) < parseInt(strnum1) || parseInt(strlen) > parseInt(strnum2))
    {
        if (parseInt(strlen) < parseInt(strnum1)) { notice = "字符数至少为" + strnum1 + "个" }
        if (parseInt(strlen) > parseInt(strnum2)) { notice = "字符数不得超过" + strnum2 + "个" }
        if (parseInt(strnum1) == parseInt(strnum2)) { notice = "字符数必须为" + strnum2 + "个" }
        loseback(eimobj, notice);
    }
    else
    {
        eimobj.style.border = "#aaa"; //SuccColor; //恢复原始边框颜色
        if ($(eimobj).next().attr("color") == LoseColor && $(eimobj).next().is("font")) $(eimobj).next().remove(); //去除提示文字
        result = 1;
    }
}
//验证失败返回结果
function loseback(eimobj, notice)
{
    eimobj.style.border = "1px solid " + LoseColor; //失败后的边框颜色
    if ($(eimobj).next().attr("color") == LoseColor && $(eimobj).next().is("font")) $(eimobj).next().remove(); //去除提示文字
    $(eimobj).after("<font size=2 color='" + LoseColor + "' title='" + notice + "'>&nbsp;？</font>"); //后缀提醒
    //alert(notice);//弹框提醒
    eimobj.focus();
    result = 0;
}
//判断当前元素正则表达式
function CheckExp(eimobj,pass,notice){
  if(!pass){loseback(eimobj,notice);}else{sucback(eimobj)}
}
//16进制颜色转为RGB格式
function colorRgb(string){
	//十六进制颜色值的正则表达式
    var reg = /^#([0-9a-fA-f]{3}|[0-9a-fA-f]{6})$/;
	var sColor = string.toLowerCase();
	if(sColor && reg.test(sColor)){
		if(sColor.length === 4){
			var sColorNew = "#";
			for(var i=1; i<4; i+=1){
				sColorNew += sColor.slice(i,i+1).concat(sColor.slice(i,i+1));	
			}
			sColor = sColorNew;
		}
		//处理六位的颜色值
		var sColorChange = [];
		for(var i=1; i<7; i+=2){
			sColorChange.push(parseInt("0x"+sColor.slice(i,i+2)));	
		}
		return "rgb(" + sColorChange.join(", ") + ")";
	}else{
		return sColor;	
	}
}