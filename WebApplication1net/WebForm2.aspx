<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Add.Master" CodeBehind="AddMaintenanceContract.aspx.cs" Inherits="HuiYu.Portal.Equipment.PurchaseManage.AddMaintenanceContract" %>

<%@ Register Src="~/Controls/Dropdown/DepartmentList.ascx" TagPrefix="uc1" TagName="DepartmentList" %>

<%@ Import Namespace="HuiYu.Common" %>
<%@ Import Namespace="HuiYu.Entity.Equipment.Enums" %>
<%@ Import Namespace="HuiYu.Entity.Enums" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
	<style type="text/css">
		.tableText {
			height: 18px;
			line-height: 18px;
		}

		.w90 {
			width: 90%;
		}

		.w80 {
			width: 80%;
		}

		.w50 {
			width: 45%;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" runat="server">
	<ul class="placeul">
		<li><a href="/main.aspx" title="首页">首页</a></li>
		<li>台账管理</li>
		<li><a href="maintenancecontract.aspx" title="维保合同管理">维保合同管理</a></li>
		<li><% =string.IsNullOrWhiteSpace(Request.QueryString["id"]) ? "新建维保合同" : "编辑维保合同" %></li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphTitle" runat="server">
	维保合同信息
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphForm" runat="server">
	<div style="width: 100%; text-align: center; margin-bottom: 10px; margin-top: -10px;">
		<h1 style="font-size: 18px;"><%=this.Config.HospitalName %>医用设备维保合同</h1>
	</div>
	<table class="tablelist stable">
		<tr>

			<td>合同编号：</td>
			<td>
				<label><%=model.ContractNumber %></label>
				<input type="hidden" name="ContractNumber" class="tableText w70" maxlength="64"   value="<%=model.ContractNumber %>" readonly="readonly" /></td>
			<td>自定义编号：</td>
			<td>
				<input type="text" name="UserDefinedNumber" class="tableText w70" maxlength="64" value="<%=model.UserDefinedNumber %>" /></td>

			<td>合同名称：</td>
			<td>
				<input name="ContractName" type="text" data-empty="0" class="tableText w70" maxlength="64" readonly="readonly" /></td>
			<td><b>*</b>甲方名称：</td>
			<td>
				<input name="Employer" type="text" class="tableText w90" maxlength="64" readonly="readonly" /></td>
			<td><b>*</b>乙方名称：</td>
			<td>
				<input name="Contractor" id="Contractor" type="text" class="tableText w70" maxlength="50" /><a href="###" class="tablelink" title="选择选择乙方(供应商)名称" onclick='$.loadSupplier({title:"选择乙方(供应商)",query:{sm:2,SupplierType:<%=(int)SupplierType.设备供应商%>    }, callBack: function(data){$("input[name=Contractor]").val(data[0].Name); }});'>选择</a></td>
		</tr>
		<tr>
			
				<td>签订人：</td>
			<td>
				<input name="SignePerson" type="text" data-empty="0"  ispost="true" class="tableText w70" maxlength="64"  /></td>
		
			<td>合同金额：</td>
			<td>
				<input name="ContractPrice"  data-empty="0"  id="ContractPrice" type="text"  ispost="true" class="tableText w90" maxlength="64" value="" /></td>

			<td><b>*</b>签订日期：</td>
			<td>
				<input name="SignedDate" type="text" ispost="true" keyproperty="true" data-empty="1900-01-01" class="Wdate tableText w90" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd' })" /></td>

			<td><b>*</b>维保日期(起)：</td>
			<td>
				<input name="MaintenanceDate1" type="text" data-empty="1900-01-01" class="Wdate tableText w90" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd' })" /></td>
			<td><b>*</b>维保日期(止)：</td>
			<td>
				<input name="MaintenanceDate2" type="text" data-empty="1900-01-01" class="Wdate tableText w90" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd' })" /></td>

			
		</tr>
		<tr>
			<td>合同附件：</td>
			<td><a class="button blue" id="btnUpload">上传附件</a><input type="hidden" name="AttachmentID" id="attachmentID" /></td>

			<td><b>*</b>维保人员：</td>
			<td>
				<input type="text" name="MaintenanceStaff" class="tableText w90" maxlength="64" /></td>
			<td><b>*</b>维保电话：</td>
			<td>
				<input name="MaintenancePhone" type="tel" class="tableText w90" maxlength="50" /></td>

		</tr>

	</table>
	<div class="formtitle" style="margin: 20px 0px 10px 0px; clear: both;">
		<span>合同明细信息</span>
	</div>
	<table class="tablelist" id="tab3">
		<thead>
			<tr>
				<th>序号</th>
				<th><b>*</b>设备名称</th>

			</tr>
		</thead>
		 <tbody>
            <tr>
                <td align="center">1</td>
                 <td align="center">
                    <input name="Name" ispost="true" keyproperty="true" type="text" maxlength="64" class="tableText w80" /></td>
               </tr>
        </tbody>
		<tfoot>
			<tr class="tablefoot">
				<td align="right" colspan="8"></td>
				<td colspan="5" align="right"><a href="###;" class="button blue" id="btnAdd">添加设备</a></td>
			</tr>
		</tfoot>
	</table>
	<div class="formtitle" style="margin: 20px 0px 10px 0px">
		<span>付款明细</span>
	</div>
	
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphScript" runat="server">
	<script type="text/javascript">

		function validate(formData, jqForm, options) {
			formData.push({ name: "list", value: $.getTableData1("#tab") });
			formData.push({ name: "list1", value: $.getTableData1("#tab1") });
			layer.load("提交数据中，请稍侯...");
			return true;
		}
		function loadSupplier(obj) {
			$.loadSupplier({ title: "选择设备生产厂家", query: { sm: 2, SupplierType:<%=(int)SupplierType.设备生产厂家%>}, callBack: function (data) { $(obj).val(data[0].Name); } });
		}
		$(function () {
			$.inintForm({ jsonList:<%=model.DetailsList.ToJson()%>, c: "#tab2", append: false });
			$.tableDynamicAddRows1("#tab", { addSelector: "#btnAdd", deleteSelector: ".deltr", calculate: true });
			$.tableDynamicAddRows1("#tab1", { addSelector: "#btnAdd1", deleteSelector: ".deltr1" });
			$.calculate("#tab");//初始化时算合计金额
		});

		$("#btnUpload").click(function () {
			var container = $("#attachmentID");
			$.uploadAttachments1({
				attachType: <%=(int)AttachmentType.设备维保合同%>, container: container, title: '上传设备维保合同附件', call: function () {
					var data = $.dialog.data("AttachmentID");
					$(container).val(data);
				}
			});
		});


		//选择待维保设备
		function loadSbForAccounting(obj) {
			$.dialog.open("../load/loadaccountinglist.aspx?needMaintence=60", {
				width: $(window).width() * 0.9,
				height: $(window).height() * 0.8,
				title: "选择台帐进行维保操作",
				close: function () {
					var data = $.dialog.data("data");
					$.dialog.data('data', null);
					if (data == null) return;
					$.ajax({
						type: "post",
						url: "/services/equipment/sbarchivesmanageservices.ashx",
						data: { action: "loadarchivedata", accountingID: data, archiveType: 1 },
						dataType: "json",
						beforeSend: function () { layer.load('加载数据中，请稍侯...'); },
						error: function () { layer.closeAll(); $.dialog.alert("请求失败，请刷新页面重试！"); },
						success: function (msg) {
							layer.closeAll();
							$.inintForm({ jsonForm: null, jsonList: msg, c: "#tab", append: false });
						}
					});
				}
			}, false).lock();
		}
	</script>
</asp:Content>
<script runat="server">
	protected override void OnLoadComplete(EventArgs e)
	{
		base.OnLoadComplete(e);
		((HuiYu.Portal.Add)Master).InintModel = model;
		((HuiYu.Portal.Add)Master).InintList = model.DetailsList;
		((HuiYu.Portal.Add)Master).TipMsg = "设备维保合同";
		((HuiYu.Portal.Add)Master).Action = "/services/equipment/SbMaintenanceContractServices.ashx";
	}
</script>
