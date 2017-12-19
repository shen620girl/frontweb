<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1net.WebForm1" %>
<%@ Register TagPrefix="uc1" TagName="WebCtl1" Src="WebUserControl1.ascx" %> 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
		<ul>
			<li><label>账号：</label><input type="text" name="t1" /></li>
			<li><label>密码：</label><input type="text" name="t2" /></li>
			<li><label>是否记住密码：</label><input type="text" name="t3" /></li>
			<li><label>上传文件：</label><br />
				
				<iframe src="file.html"  frameborder="no" border="0"></iframe>	
				
				



			</li>
			<li>
				<uc1:WebCtl1 id="WFC1" runat="server"></uc1:WebCtl1></li>
			
		</ul>
        <div>
        </div>
    </form>
</body>
</html>
