<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="WebApplication1net.WebUserControl1" %>


<asp:TextBox runat="server"  ID="txt2" />	


<table>
	<tr>
		<td><label>test2</label>	</td>
		<td><label>test23</label>	</td>
		<td><label>test24</label>	</td>
	</tr>
	<tr>
		<td><label>test22</label><%=showstr %>	</td>
		<td><label>test232</label>	</td>
		<td><label>test242</label><%# showstr %><%# Eval(showstr)%></td>
	</tr>
</table>
