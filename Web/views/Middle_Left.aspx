<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Middle_Left.aspx.cs" Inherits="Web.views.Middle_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>button_title_l</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<script type="text/javascript">
    window.onload = function ()
    {
        var h = document.documentElement.clientHeight;
        document.getElementsByTagName("table")[0].style.height = h + "px";
    }
    setInterval(onload, 100);
    function oa_tool()
    {
        if (window.parent.oa_frame.cols == "0,8,*")
        {
            frameshow.src = "../images/yincang-icon.png";
            oa_tree.title = "隐藏"
            window.parent.oa_frame.cols = "196,8,*";
        }
        else
        {
            frameshow.src = "../images/yincang-icon2.png";
            oa_tree.title = "显示"
            window.parent.oa_frame.cols = "0,8,*";
        }
    }
</script>
</head>
<body style="margin:0">
<table id="ddd" border="0" cellpadding="0" cellspacing="0" style="width:8px;text-align:center">
  <tr align="center">
    <td style="background:url(../images/yincang-bf.png) repeat-y">
      <div id="oa_tree" onclick="oa_tool();" title="隐藏"><img id="frameshow" src="../images/yincang-icon.png" alt="隐藏" width="8" height="34" /></div>
      </td>
  </tr>
</table>
</body>
</html>
