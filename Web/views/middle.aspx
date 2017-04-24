<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Middle.aspx.cs" Inherits="Web.views.middle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<frameset cols="196,8,*" frameborder="no" rows="*" border="0" framespacing="0" id="oa_frame">
  <frame src="left.aspx" name="leftFrame" noresize="noresize" scrolling="NO"/>
  <frame src="middle_left.aspx" id="mid_left" name="midFrame" noresize="noresize" scrolling="NO"/>
  <frame src="FlowWork_Home.aspx" name="rightFrame" noresize="noresize" id="rightFrame" scrolling="no"/>
</frameset>
<noframes>
    <body style="background-color: #e5edf0;">
    </body>
</noframes>
</html>
