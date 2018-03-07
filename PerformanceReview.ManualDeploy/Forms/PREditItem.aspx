<%@ Page language="C#" MasterPageFile="~masterurl/default.master"    Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage,Microsoft.SharePoint,Version=15.0.0.0,Culture=neutral,PublicKeyToken=71e9bce111e9429c" meta:progid="SharePoint.WebPartPage.Document" meta:webpartpageexpansion="full"  %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Import Namespace="Microsoft.SharePoint" %> <%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<asp:Content ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:ListFormPageTitle runat="server"/>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderPageTitleInTitleArea" runat="server">
	<span class="die">
		<SharePoint:ListProperty Property="LinkTitle" runat="server" id="ID_LinkTitle"/>
	</span>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderPageImage" runat="server">
	<img src="/_layouts/15/images/blank.gif?rev=23" width='1' height='1' alt="" />
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderMain" runat="server">
<script type="text/javascript" src="../../SiteAssets/JQuery/jquery1.10.2.js"></script>
<script type="text/javascript" src="../../SiteAssets/JQuery/jquery.SPServices-2014.01.js"></script>
<script type="text/javascript" src="../../SiteAssets/JQuery/PerformanceReview.js"></script>
<script type="text/javascript" src="../../SiteAssets/JQuery/PREditFormActions.js"></script>
<style>
.cellctrl input[type=text] {
    width: 80%;
}
</style>
<SharePoint:UIVersionedContent UIVersion="4" runat="server">
	<ContentTemplate>
	<div style="padding-left:5px">
	</ContentTemplate>
</SharePoint:UIVersionedContent>
	<table class="span12" id="onetIDListForm">
	 <tr>
	  <td>
	 <WebPartPages:WebPartZone runat="server" FrameType="None" ID="Main" Title="loc:Main"><ZoneTemplate>
		<WebPartPages:DataFormWebPart runat="server" EnableOriginalValue="False" DisplayName="PerformanceReview" ViewFlag="1048584" ViewContentTypeId="" Default="FALSE" ListUrl="" ListDisplayName="" ListName="{3DCAB08E-B70A-4AC7-BE31-D316352DC210}" ListId="3dcab08e-b70a-4ac7-be31-d316352dc210" PageType="PAGE_EDITFORM" PageSize="-1" UseSQLDataSourcePaging="True" DataSourceID="" ShowWithSampleData="False" AsyncRefresh="False" ManualRefresh="False" AutoRefresh="False" AutoRefreshInterval="60" NoDefaultStyle="TRUE" InitialAsyncDataFetch="False" Title="PerformanceReview" FrameType="None" SuppressWebPartChrome="False" Description="" IsIncluded="True" PartOrder="2" FrameState="Normal" AllowRemove="True" AllowZoneChange="True" AllowMinimize="True" AllowConnect="True" AllowEdit="True" AllowHide="True" IsVisible="True" DetailLink="" HelpLink="" HelpMode="Modeless" Dir="Default" PartImageSmall="" MissingAssembly="Cannot import this Web Part." PartImageLarge="" IsIncludedFilter="" ExportControlledProperties="True" ConnectionID="00000000-0000-0000-0000-000000000000" ID="g_2952b771_a64c_4c4d_8e15_85e804c2ee8d" ChromeType="None" ExportMode="All" __MarkupType="vsattributemarkup" __WebPartId="{2952B771-A64C-4C4D-8E15-85E804C2EE8D}" __AllowXSLTEditing="true" WebPart="true" Height="" Width=""><DataSources>
<SharePoint:SPDataSource runat="server" DataSourceMode="ListItem" SelectCommand="&lt;View&gt;&lt;Query&gt;&lt;Where&gt;&lt;Eq&gt;&lt;FieldRef Name=&quot;ContentType&quot;/&gt;&lt;Value Type=&quot;Text&quot;&gt;Item&lt;/Value&gt;&lt;/Eq&gt;&lt;/Where&gt;&lt;/Query&gt;&lt;/View&gt;" UseInternalName="True" UseServerDataFormat="True"><SelectParameters><WebPartPages:DataFormParameter ParameterKey="ListItemId" PropertyName="ParameterValues" DefaultValue="0" Name="ListItemId"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="weburl" PropertyName="ParameterValues" DefaultValue="http://hcchspdev01:1122/sites/PerformanceReviewDB" Name="weburl"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="ListID" PropertyName="ParameterValues" DefaultValue="{3DCAB08E-B70A-4AC7-BE31-D316352DC210}" Name="ListID"></WebPartPages:DataFormParameter>
			</SelectParameters><UpdateParameters><WebPartPages:DataFormParameter ParameterKey="ListItemId" PropertyName="ParameterValues" DefaultValue="0" Name="ListItemId"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="weburl" PropertyName="ParameterValues" DefaultValue="http://hcchspdev01:1122/sites/PerformanceReviewDB" Name="weburl"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="ListID" PropertyName="ParameterValues" DefaultValue="{3DCAB08E-B70A-4AC7-BE31-D316352DC210}" Name="ListID"></WebPartPages:DataFormParameter>
			</UpdateParameters><InsertParameters><WebPartPages:DataFormParameter ParameterKey="ListItemId" PropertyName="ParameterValues" DefaultValue="0" Name="ListItemId"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="weburl" PropertyName="ParameterValues" DefaultValue="http://hcchspdev01:1122/sites/PerformanceReviewDB" Name="weburl"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="ListID" PropertyName="ParameterValues" DefaultValue="{3DCAB08E-B70A-4AC7-BE31-D316352DC210}" Name="ListID"></WebPartPages:DataFormParameter>
			</InsertParameters><DeleteParameters><WebPartPages:DataFormParameter ParameterKey="ListItemId" PropertyName="ParameterValues" DefaultValue="0" Name="ListItemId"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="weburl" PropertyName="ParameterValues" DefaultValue="http://hcchspdev01:1122/sites/PerformanceReviewDB" Name="weburl"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="ListID" PropertyName="ParameterValues" DefaultValue="{3DCAB08E-B70A-4AC7-BE31-D316352DC210}" Name="ListID"></WebPartPages:DataFormParameter>
			</DeleteParameters>
</SharePoint:SPDataSource>
</DataSources>
<Xsl>






<xsl:stylesheet xmlns:x="http://www.w3.org/2001/XMLSchema" xmlns:dsp="http://schemas.microsoft.com/sharepoint/dsp" version="1.0" exclude-result-prefixes="xsl msxsl ddwrt" xmlns:ddwrt="http://schemas.microsoft.com/WebParts/v2/DataView/runtime" xmlns:asp="http://schemas.microsoft.com/ASPNET/20" xmlns:__designer="http://schemas.microsoft.com/WebParts/v2/DataView/designer" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:SharePoint="Microsoft.SharePoint.WebControls" xmlns:ddwrt2="urn:frontpage:internal">
	<xsl:output method="html" indent="no"/>
	<xsl:decimal-format NaN=""/>
	<xsl:param name="dvt_apos">&apos;</xsl:param>
	<xsl:param name="ManualRefresh"></xsl:param>
	<xsl:variable name="dvt_1_automode">0</xsl:variable>
	<xsl:template match="/" xmlns:x="http://www.w3.org/2001/XMLSchema" xmlns:dsp="http://schemas.microsoft.com/sharepoint/dsp" xmlns:asp="http://schemas.microsoft.com/ASPNET/20" xmlns:__designer="http://schemas.microsoft.com/WebParts/v2/DataView/designer" xmlns:SharePoint="Microsoft.SharePoint.WebControls">
		<xsl:choose>
			<xsl:when test="($ManualRefresh = 'True')">
				<table width="100%" border="0" cellpadding="0" cellspacing="0">
					<tr>
						<td valign="top">
							<xsl:call-template name="dvt_1"/>
						</td>
						<td width="1%" class="ms-vb" valign="top">
							<img src="/_layouts/15/images/staticrefresh.gif" id="ManualRefresh" border="0" onclick="javascript: {ddwrt:GenFireServerEvent('__cancel')}" alt="Click here to refresh the dataview."/>
						</td>
					</tr>
				</table>
			</xsl:when>
			<xsl:otherwise>
				<xsl:call-template name="dvt_1"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
	
	<xsl:template name="dvt_1">
		<xsl:variable name="dvt_StyleName">ListForm</xsl:variable>
		<xsl:variable name="Rows" select="/dsQueryResponse/Rows/Row"/>
		<div>
			<span id="part1">
				<table >
					<xsl:call-template name="dvt_1.body">
						<xsl:with-param name="Rows" select="$Rows"/>
					</xsl:call-template>
				</table>
			</span>
			<SharePoint:AttachmentUpload runat="server" ControlMode="Edit"/>
			<SharePoint:ItemHiddenVersion runat="server" ControlMode="Edit"/>
		</div>
	</xsl:template>
	<xsl:template name="dvt_1.body">
		<xsl:param name="Rows"/>
		<tr>
			<td class="ms-toolbar" nowrap="nowrap">
				<table>
					<tr>	
						<td class="ms-toolbar" nowrap="nowrap" align="right">
							<input type="button" class="btn" onclick="UpdateSupervisor('PerformanceReview');" title="Update supervisors info" value="Update supervisor's info"/>
						</td>
						<td class="ms-toolbar" nowrap="nowrap">
							<SharePoint:SaveButton runat="server" ControlMode="Edit" id="savebutton1" CssClass="btn"/>
						</td>
						<td class="ms-separator">&#160;</td>
						<td class="ms-toolbar" nowrap="nowrap" align="right">
						
							<SharePoint:GoBackButton runat="server" ControlMode="Edit" id="gobackbutton1" />
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td class="ms-toolbar" nowrap="nowrap">
				<SharePoint:FormToolBar runat="server" ControlMode="Edit"/>
				<SharePoint:ItemValidationFailedMessage runat="server" ControlMode="Edit"/>
			</td>
		</tr>
		<xsl:for-each select="$Rows">
			<xsl:call-template name="dvt_1.rowedit"/>
		</xsl:for-each>
		<tr>
			<td class="ms-toolbar" nowrap="nowrap">
				<table>
					<tr>
						<td class="ms-descriptiontext" nowrap="nowrap">
							<SharePoint:CreatedModifiedInfo ControlMode="Edit" runat="server"/>
						</td>
						<td class="ms-toolbar" nowrap="nowrap" align="right">
							<input type="button" onclick="UpdateSupervisor('PerformanceReview');" title="Update supervisors info" value="Update supervisor's info"/>
						</td>
						<td class="ms-toolbar" nowrap="nowrap">
							<SharePoint:SaveButton runat="server" ControlMode="Edit" id="savebutton2"/>
						</td>
						<td class="ms-separator">&#160;</td>
						<td class="ms-toolbar" nowrap="nowrap" align="right">
							<SharePoint:GoBackButton runat="server" ControlMode="Edit" id="gobackbutton2"/>
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</xsl:template>
	<xsl:template name="dvt_1.rowedit">
		<xsl:param name="Pos" select="position()"/>
		<tr>
			<td>
			<div class="container">
				<table style="display:none" class="table table-noborder">
					<tr>
						<td >
							<H3 class="ms-standardheader">
								<nobr>Title</nobr>
							</H3>
						</td>
						<td  class="cellctrl">
							<SharePoint:FormField runat="server" id="ff1{$Pos}" ControlMode="Edit" FieldName="Title" __designer:bind="{ddwrt:DataBind('u',concat('ff1',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@Title')}"/>
							<SharePoint:FieldDescription runat="server" id="ff1description{$Pos}" FieldName="Title" ControlMode="Edit"/>
						</td>
					</tr>
				</table>
				
				
				<div>
							<span class="span12 ms-formbody"><strong><u>Employee Data</u></strong></span>
					
				</div>
				
				<table class="table table-bordered">
					<tr>
						
						<td class="span2" >
							<h5 class="ms-standardheader ms-formbody">
								PersNumber
							</h5>
						</td>
						
						
						<td style="display:none;">
		
							<SharePoint:FormField runat="server" id="ff23{$Pos}" ControlMode="Edit" FieldName="PersNumber" __designer:bind="{ddwrt:DataBind('u',concat('ff23',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@PersNumber')}"/>
							<SharePoint:FieldDescription runat="server" id="ff23description{$Pos}" FieldName="PersNumber" ControlMode="Edit"/>
						</td>
						
						
						<td class="span2">
						<div class="ms-formbody">
							<xsl:value-of select="@PersNumber" disable-output-escaping="yes"/>
							</div>
						</td>
						
						<td class="span2">
							<h5 class="ms-standardheader ms-formbody">
								Employee Name
							</h5>
						</td>
						
						<td  style="display:none">
							<SharePoint:FormField runat="server" id="ff14{$Pos}" ControlMode="Edit" FieldName="LastName" __designer:bind="{ddwrt:DataBind('u',concat('ff14',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@LastName')}"/>
							<SharePoint:FieldDescription runat="server" id="ff14description{$Pos}" FieldName="LastName" ControlMode="Edit"/>
							<span>, </span>
							<SharePoint:FormField runat="server" id="ff12{$Pos}" ControlMode="Edit" FieldName="FirstName" __designer:bind="{ddwrt:DataBind('u',concat('ff12',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@FirstName')}"/>
							<SharePoint:FieldDescription runat="server" id="ff12description{$Pos}" FieldName="FirstName" ControlMode="Edit"/>
						</td>
						
						<td class="span2">
						<div class="ms-formbody">

							<xsl:value-of select="@LastName" disable-output-escaping="yes"/><span>, </span><xsl:value-of select="@FirstName" disable-output-escaping="yes"/>
							</div>
						</td>
						
						<td class="span2">
							<h5 class="ms-standardheader ms-formbody">
								Country
							</h5>
						</td>
						
						<td style="display:none">
							<SharePoint:FormField runat="server" id="ff10{$Pos}" ControlMode="Edit" FieldName="Ctry" __designer:bind="{ddwrt:DataBind('u',concat('ff10',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@Ctry')}"/>
							<SharePoint:FieldDescription runat="server" id="ff10description{$Pos}" FieldName="Ctry" ControlMode="Edit"/>
						</td>
						
						<td class="span2">
						<div class="ms-formbody">

							<xsl:value-of select="@Ctry" disable-output-escaping="yes"/>
							</div>
						</td>						
					</tr>
					
					
					
			
					<tr>
						<td class="span2" >
							<H5 class="ms-standardheader ms-formbody">
								Pers Area
							</H5>
						</td>
						
						<td class="ms-formbody cellctrl" style="display:none;">
							<SharePoint:FormField runat="server" id="ff22{$Pos}" ControlMode="Edit" FieldName="PersAreaName" __designer:bind="{ddwrt:DataBind('u',concat('ff22',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@PersAreaName')}"/>
							<SharePoint:FieldDescription runat="server" id="ff22description{$Pos}" FieldName="PersAreaName" ControlMode="Edit"/>
						</td>
						<td class="span2" >
						<div class="ms-formbody">
							<xsl:value-of select="@PersAreaName" disable-output-escaping="yes"/>
							</div>
						</td>
						<td class="span2" >
							<H5 class="ms-standardheader ms-formbody">
							
								Employee SubGroup
							</H5>
						</td>
						<td class="ms-formbody cellctrl" style="display:none;">
							<SharePoint:FormField runat="server" id="ff11{$Pos}" ControlMode="Edit" FieldName="EmplSubGrpName" __designer:bind="{ddwrt:DataBind('u',concat('ff11',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@EmplSubGrpName')}"/>
							<SharePoint:FieldDescription runat="server" id="ff11description{$Pos}" FieldName="EmplSubGrpName" ControlMode="Edit"/>
						</td>
						<td class="span2" >
						<div class="ms-formbody">

							<xsl:value-of select="@EmplSubGrpName" disable-output-escaping="yes"/>
							</div>
						</td>
						<td class="span2"  >
							<H5 class="ms-standardheader ms-formbody">
								Org.Unit
							</H5>
						</td>							
						<td class="ms-formbody cellctrl" style="display:none">
							<SharePoint:FormField runat="server" id="ff18{$Pos}" ControlMode="Edit" FieldName="OrgUnitName" __designer:bind="{ddwrt:DataBind('u',concat('ff18',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@OrgUnitName')}"/>
							<SharePoint:FieldDescription runat="server" id="ff18description{$Pos}" FieldName="OrgUnitName" ControlMode="Edit"/>
						</td>
						<td class="span2"  >
						<div class="ms-formbody cellctrl">

							<xsl:value-of select="@OrgUnitName" disable-output-escaping="yes"/>
							</div>
						</td>
					</tr>
				
				
					<tr>
						<td class="span2">
							<H5 class="ms-standardheader ms-formbody">
								SBU
							</H5>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl" style="display:none;">
							<SharePoint:FormField runat="server" id="ff34{$Pos}" ControlMode="Edit" FieldName="SbuName" __designer:bind="{ddwrt:DataBind('u',concat('ff34',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@SbuName')}"/>
							<SharePoint:FieldDescription runat="server" id="ff34description{$Pos}" FieldName="SbuName" ControlMode="Edit"/>
						</td>
						<td class="span2">
						<div class="ms-formbody">

							<xsl:value-of select="@SbuName" disable-output-escaping="yes"/>
							</div>
						</td>						
						<td class="span2">
							<H5 class="ms-standardheader ms-formbody">
								RTG
							</H5>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl" style="display:none">
							<SharePoint:FormField runat="server" id="ff30{$Pos}" ControlMode="Edit" FieldName="RTG" __designer:bind="{ddwrt:DataBind('u',concat('ff30',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@RTG')}"/>
							<SharePoint:FieldDescription runat="server" id="ff30description{$Pos}" FieldName="RTG" ControlMode="Edit"/>
						</td>
						<td class="span2">
						<div class="ms-formbody">

							<xsl:value-of select="@RTG" disable-output-escaping="yes"/>
							</div>
						</td>
						<td class="span2">
							<H5 class="ms-standardheader ms-formbody">
								Part.Time %
							</H5>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl" style="display:none">
							<SharePoint:FormField runat="server" id="ff29{$Pos}" ControlMode="Edit" FieldName="PT" __designer:bind="{ddwrt:DataBind('u',concat('ff29',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@PT')}"/>
							<SharePoint:FieldDescription runat="server" id="ff29description{$Pos}" FieldName="PT" ControlMode="Edit"/>
						</td>
						<td class="span2">
						<div class="ms-formbody">
							<xsl:value-of select="@PT" disable-output-escaping="yes"/>
							</div>
						</td>
					</tr>
				
					<tr>
						<td class="span2">
							<H5 class="ms-standardheader ms-formbody">
								SSGL Level
							</H5>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl" style="display:none">
							<SharePoint:FormField runat="server" id="ff35{$Pos}" ControlMode="Edit" FieldName="SSGL" __designer:bind="{ddwrt:DataBind('u',concat('ff35',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@SSGL')}"/>
							<SharePoint:FieldDescription runat="server" id="ff35description{$Pos}" FieldName="SSGL" ControlMode="Edit"/>
						</td>
						<td >
						<div class="ms-formbody">
							<xsl:value-of select="@SSGL" disable-output-escaping="yes"/>
							</div>
						</td>
						<td class="span2">
							<H5 class="ms-standardheader ms-formbody">
								Adjusted Service Date
							</H5>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl" style="display:none;">
							<SharePoint:FormField runat="server" id="ff2{$Pos}" ControlMode="Edit" FieldName="ASDDate" __designer:bind="{ddwrt:DataBind('u',concat('ff2',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@ASDDate')}"/>
							<SharePoint:FieldDescription runat="server" id="ff2description{$Pos}" FieldName="ASDDate" ControlMode="Edit"/>
						</td>
						<td class="span2">
						<div class="ms-formbody">
							<xsl:value-of select="@ASDDate" disable-output-escaping="yes"/>
							</div>
						</td>
						<td class="span2" >
							<H5 class="ms-standardheader ms-formbody">
								Leave Date
							</H5>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl" style="display:none;">
							<SharePoint:FormField runat="server" id="ff15{$Pos}" ControlMode="Edit" FieldName="Leavedate" __designer:bind="{ddwrt:DataBind('u',concat('ff15',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@Leavedate')}"/>
							<SharePoint:FieldDescription runat="server" id="ff15description{$Pos}" FieldName="Leavedate" ControlMode="Edit"/>
						</td>
						<td>
						<div class="ms-formbody">
							<xsl:value-of select="@Leavedate" disable-output-escaping="yes"/>
							</div>
						</td>
					</tr>
				</table>
				
				<div>
				<span class="span12 ms-formbody"><strong><u>Previous Year Performance</u></strong></span>
							</div>
						
				
				<table class="table table-bordered">
					<tr>
						<td class="span3">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>Previous_Year_PC_Name</nobr>
							</H5>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl" style="display:none;">
							<SharePoint:FormField runat="server" id="ff28{$Pos}" ControlMode="Edit" FieldName="Previous_Year_PC_Name" __designer:bind="{ddwrt:DataBind('u',concat('ff28',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@Previous_Year_PC_Name')}"/>
							<SharePoint:FieldDescription runat="server" id="ff28description{$Pos}" FieldName="Previous_Year_PC_Name" ControlMode="Edit"/>
						</td>
						<td class="span3" >
						<div class="ms-formbody">
							<xsl:value-of select="@Previous_Year_PC_Name" disable-output-escaping="yes"/>
							</div>
						</td>
						<td class="span3" >
							<H5 class="ms-standardheader ms-formbody">
								<nobr>Previous_Year_PC</nobr>
							</H5>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl" style="display:none;">
							<SharePoint:FormField runat="server" id="ff27{$Pos}" ControlMode="Edit" FieldName="Previous_Year_PC" __designer:bind="{ddwrt:DataBind('u',concat('ff27',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@Previous_Year_PC')}"/>
							<SharePoint:FieldDescription runat="server" id="ff27description{$Pos}" FieldName="Previous_Year_PC" ControlMode="Edit"/>
						</td>
						<td class="span3" >
						<div class="ms-formbody">
							<xsl:value-of select="@Previous_Year_PC" disable-output-escaping="yes"/>
							</div>
						</td>
						<td width="190px" valign="top" class="ms-formlabel" style="display:none">
							<H3 class="ms-standardheader">
								<nobr>Previous_Year_IPF_Name</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl" style="display:none">
							<SharePoint:FormField runat="server" id="ff26{$Pos}" ControlMode="Edit" FieldName="Previous_Year_IPF_Name" __designer:bind="{ddwrt:DataBind('u',concat('ff26',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@Previous_Year_IPF_Name')}"/>
							<SharePoint:FieldDescription runat="server" id="ff26description{$Pos}" FieldName="Previous_Year_IPF_Name" ControlMode="Edit"/>
						</td>
						<td class="span3" >
						<div class="ms-formbody">

							<xsl:value-of select="@Previous_Year_IPF_Name" disable-output-escaping="yes"/>
							</div>
						</td>
						<td width="190px" valign="top" class="ms-formlabel" style="display:none">
							<H3 class="ms-standardheader">
								<nobr>Previous_Year_IPF</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl" style="display:none;">
							<SharePoint:FormField runat="server" id="ff25{$Pos}" ControlMode="Edit" FieldName="Previous_Year_IPF" __designer:bind="{ddwrt:DataBind('u',concat('ff25',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@Previous_Year_IPF')}"/>
							<SharePoint:FieldDescription runat="server" id="ff25description{$Pos}" FieldName="Previous_Year_IPF" ControlMode="Edit"/>
						</td>
						<td class="span3">
						<div class="ms-formbody">

							<xsl:value-of select="@Previous_Year_IPF" disable-output-escaping="yes"/>
							</div>
						</td>
					</tr>
				</table>
				
				
				<div>
							<span class="span12 ms-formbody"><strong><u>Current Year Performance</u></strong></span>
							
							</div>

				<table class="table table-bordered" >
					<tr>
						<td valign="middle">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>Behaviours</nobr>
							</H5>
						</td>
						<td align="center" class="ms-formbody cellctrl">
							<select id="select_behaviour">
								  <option value="exeeds">Exeeds Expectations</option>
							  <option value="meets">Meets Expectations</option>
							  <option value="bellow">Bellow Expectations</option>
							</select>
						</td>
						<td align="center">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>Goals</nobr>
							</H5>
						</td>
						<td align="center" class="ms-formbody cellctrl">
						<select id="select_goals">							
							  <option value="exeeds">Exeeds Expectations</option>
							  <option value="meets">Meets Expectations</option>
							  <option value="bellow">Bellow Expectations</option>
							</select>
						</td>
					
						<td>
							<table class="table table-bordered"> 
							<tr>
								<td>
									<H5 class="ms-standardheader ms-formbody">
										<nobr>Category Number</nobr>
									</H5>
								</td>
								<td valign="top" class="ms-formbody cellctrl">
									<div id="category_number"> </div>
								</td>
							</tr>
							<tr>
								<td>
									<H5 class="ms-standardheader ms-formbody">
										<nobr>Category Description</nobr>
									</H5>
								</td>
								<td valign="top" class="ms-formbody cellctrl">
									<div id="category_desc"> </div>							
								</td>
							</tr>
							</table>
						</td>
					</tr>
					<tr>
					  <td>
						   <H5 class="ms-standardheader ms-formbody">
								<nobr>Range Table</nobr>
						   </H5>
						</td>
						<td valign="top">
							<div id="range_table"></div>
							<table>
								<tr>
   									<th>Category</th>
   									<th>From</th>
  									<th>Till</th> 
								</tr>
								<tr>
									<td>
										<div id="range_table_cat1"></div>
									</td>
									<td>
										<div id="range_table_from1"></div>
									</td>
									<td>
										<div id="range_table_till1"></div>
									</td>
								</tr>
								<tr>
									<td>
										<div id="range_table_cat2"></div>
									</td>
									<td>
										<div id="range_table_from2"></div>
									</td>
									<td>
										<div id="range_table_till2"></div>
									</td>
								</tr>
								<tr>
									<td>
										<div id="range_table_cat3"></div>
									</td>
									<td>
										<div id="range_table_from3"></div>
									</td>
									<td>
										<div id="range_table_till3"></div>
									</td>
								</tr>
								<tr>
									<td>
										<div id="range_table_cat4"></div>
									</td>
									<td>
										<div id="range_table_from4"></div>
									</td>
									<td>
										<div id="range_table_till4"></div>
									</td>
								</tr>
								<tr>
									<td>
										<div id="range_table_cat5"></div>
									</td>
									<td>
										<div id="range_table_from5"></div>
									</td>
									<td>
										<div id="range_table_till5"></div>
									</td>
								</tr>
								<tr>
									<td>
										<div id="range_table_cat6"></div>
									</td>
									<td>
										<div id="range_table_from6"></div>
									</td>
									<td>
										<div id="range_table_till6"></div>
									</td>
								</tr>
								<tr>
									<td>
										<div id="range_table_cat7"></div>
									</td>
									<td>
										<div id="range_table_from7"></div>
									</td>
									<td>
										<div id="range_table_till7"></div>
									</td>
								</tr>
								<tr>
									<td>
										<div id="range_table_cat8"></div>
									</td>
									<td>
										<div id="range_table_from8"></div>
									</td>
									<td>
										<div id="range_table_till8"></div>
									</td>
								</tr>
								<tr>
									<td>
										<div id="range_table_cat9"></div>
									</td>
									<td>
										<div id="range_table_from9"></div>
									</td>
									<td>
										<div id="range_table_till9"></div>
									</td>
								</tr>

							</table>
							
						</td>
					</tr>
			</table>
				
				
				<div style="display:none">
							<span class="span12 ms-formbody"><strong><u>SBU Split</u></strong></span></div>
							
						
				<table class="table-bordered table" style="display:none;">
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								SBU_1
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl">
							<SharePoint:FormField runat="server" id="ff31{$Pos}" InDesign="true" ControlMode="Edit" FieldName="SBU_1" __designer:bind="{ddwrt:DataBind('u',concat('ff31',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@SBU_1')}"/>
							<SharePoint:FieldDescription runat="server" id="ff31description{$Pos}" FieldName="SBU_1" ControlMode="Edit"/>
						</td>
						<td width="190px" valign="top" class="ms-formlabel" style="display:none">
							<H3 class="ms-standardheader">
								Perc_SBU_1
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl">
							<SharePoint:FormField runat="server" id="ff19{$Pos}" ControlMode="Edit" FieldName="Perc_SBU_1" __designer:bind="{ddwrt:DataBind('u',concat('ff19',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@Perc_SBU_1')}"/>
							<SharePoint:FieldDescription runat="server" id="ff19description{$Pos}" FieldName="Perc_SBU_1" ControlMode="Edit"/>
						</td>
						<td width="190px" valign="top" class="ms-formlabel" style="display:none">							
								% SBU 1							
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl">							
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								SBU_2
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl">
							<SharePoint:FormField runat="server" id="ff32{$Pos}" InDesign="true" ControlMode="Edit" FieldName="SBU_2" __designer:bind="{ddwrt:DataBind('u',concat('ff32',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@SBU_2')}"/>
							<SharePoint:FieldDescription runat="server" id="ff32description{$Pos}" FieldName="SBU_2" ControlMode="Edit"/>
						</td>
						<td width="190px" valign="top" class="ms-formlabel" style="display:none">
							<H3 class="ms-standardheader">
								Perc_SBU_2
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl">
							<SharePoint:FormField runat="server" id="ff20{$Pos}" ControlMode="Edit" FieldName="Perc_SBU_2" __designer:bind="{ddwrt:DataBind('u',concat('ff20',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@Perc_SBU_2')}"/>
							<SharePoint:FieldDescription runat="server" id="ff20description{$Pos}" FieldName="Perc_SBU_2" ControlMode="Edit"/>
						</td>
						<td width="190px" valign="top" class="ms-formlabel" style="display:none">							
								% SBU 2							
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl">							
						</td>											
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								SBU_3
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl">
							<SharePoint:FormField runat="server" InDesign="true" id="ff33{$Pos}" ControlMode="Edit" FieldName="SBU_3" __designer:bind="{ddwrt:DataBind('u',concat('ff33',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@SBU_3')}"/>
							<SharePoint:FieldDescription runat="server" id="ff33description{$Pos}" FieldName="SBU_3" ControlMode="Edit"/>
						</td>
						<td width="190px" valign="top" class="ms-formlabel" style="display:none">
							<H3 class="ms-standardheader">
								Perc_SBU_3
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl">
							<SharePoint:FormField runat="server" id="ff21{$Pos}" ControlMode="Edit" FieldName="Perc_SBU_3" __designer:bind="{ddwrt:DataBind('u',concat('ff21',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@Perc_SBU_3')}"/>
							<SharePoint:FieldDescription runat="server" id="ff21description{$Pos}" FieldName="Perc_SBU_3" ControlMode="Edit"/>
						</td>
						<td width="190px" valign="top" class="ms-formlabel" style="display:none">							
								% SBU 3							
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl">							
						</td>
					</tr>
				</table>
				
				<div>
							<span class="span12 ms-formbody"><strong><u>Comments</u></strong></span>
							</div>
					
				<table class="table table-bordered" >
					<tr>
						<td width="190px" valign="top" class="ms-formlabel" style="display:none;">
							<H3 class="ms-standardheader">
								<nobr>comment</nobr>
							</H3>
						</td>
						<td class="span12" >
						<div class="ms-formbody">
							<SharePoint:FormField runat="server" id="ff7{$Pos}" ControlMode="Edit" FieldName="comment" __designer:bind="{ddwrt:DataBind('u',concat('ff7',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@comment')}"/>
							<SharePoint:FieldDescription runat="server" id="ff7description{$Pos}" FieldName="comment" ControlMode="Edit"/>
						</div>
						</td>
					</tr>
				</table>
				
				
						<div>

					<span class="span12 ms-formbody"><strong><u>Supervisor</u></strong></span></div>
						
				<table class="table table-bordered"  >
					<tr>
						<td class="span2">
							<H5 class="ms-standardheader ms-formbody">
								Sap Number
							</H5>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl" style="display:none;">
							<SharePoint:FormField runat="server" id="ff4{$Pos}" ControlMode="Edit" FieldName="BFGuid" __designer:bind="{ddwrt:DataBind('u',concat('ff4',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@BFGuid')}"/>
							<SharePoint:FieldDescription runat="server" id="ff4description{$Pos}" FieldName="BFGuid" ControlMode="Edit"/>
						</td>
						<td class="span2">
						<div class="ms-formbody">
							<xsl:value-of select="@BFGuid" disable-output-escaping="yes"/>
							</div>
						</td>
						<td class="span2" >
							<H5 class="ms-standardheader ms-formbody">
								Name
							</H5>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl" style="display:none;">
							<SharePoint:FormField runat="server" id="ff5{$Pos}" ControlMode="Edit" FieldName="BFGuide" __designer:bind="{ddwrt:DataBind('u',concat('ff5',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@BFGuide')}"/>
							<SharePoint:FieldDescription runat="server" id="ff5description{$Pos}" FieldName="BFGuide" ControlMode="Edit"/>
						</td>
						<td class="span2">
						<div class="ms-formbody">

							<xsl:value-of select="@BFGuide" disable-output-escaping="yes"/></div>
						</td>
						<td class="span2" >
							<H5 class="ms-standardheader ms-formbody">
								Email
							</H5>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl" style="display:none;">
							<SharePoint:FormField runat="server" id="ff3{$Pos}" ControlMode="Edit" FieldName="BFEmail" __designer:bind="{ddwrt:DataBind('u',concat('ff3',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@BFEmail')}"/>
							<SharePoint:FieldDescription runat="server" id="ff3description{$Pos}" FieldName="BFEmail" ControlMode="Edit"/>
						</td>
						<td class="span2" >
						<div class="ms-formbody">

							<xsl:value-of select="@BFEmail" disable-output-escaping="yes"/></div>
						</td>
					</tr>
				</table>
				<table border="0" cellspacing="0" width="100%" style="display:none" class="table-noborder">										
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>BFGuide_CN</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl">
							<SharePoint:FormField runat="server" id="ff6{$Pos}" ControlMode="Edit" FieldName="BFGuide_CN" __designer:bind="{ddwrt:DataBind('u',concat('ff6',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@BFGuide_CN')}"/>
							<SharePoint:FieldDescription runat="server" id="ff6description{$Pos}" FieldName="BFGuide_CN" ControlMode="Edit"/>
						</td>
					</tr>
					
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>control_field</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl">
							<SharePoint:FormField runat="server" id="ff8{$Pos}" ControlMode="Edit" FieldName="control_field" __designer:bind="{ddwrt:DataBind('u',concat('ff8',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@control_field')}"/>
							<SharePoint:FieldDescription runat="server" id="ff8description{$Pos}" FieldName="control_field" ControlMode="Edit"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>counter</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl">
							<SharePoint:FormField runat="server" id="ff9{$Pos}" ControlMode="Edit" FieldName="counter" __designer:bind="{ddwrt:DataBind('u',concat('ff9',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@counter')}"/>
							<SharePoint:FieldDescription runat="server" id="ff9description{$Pos}" FieldName="counter" ControlMode="Edit"/>
						</td>
					</tr>				
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>Supervisor</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl">
							<SharePoint:FormField runat="server" id="ff36{$Pos}" ControlMode="Edit" FieldName="Supervisor" __designer:bind="{ddwrt:DataBind('u',concat('ff36',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@Supervisor')}"/>
							<SharePoint:FieldDescription runat="server" id="ff36description{$Pos}" FieldName="Supervisor" ControlMode="Edit"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>Supervisor_CN</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl">
							<SharePoint:FormField runat="server" id="ff37{$Pos}" ControlMode="Edit" FieldName="Supervisor_CN" __designer:bind="{ddwrt:DataBind('u',concat('ff37',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@Supervisor_CN')}"/>
							<SharePoint:FieldDescription runat="server" id="ff37description{$Pos}" FieldName="Supervisor_CN" ControlMode="Edit"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>UpdatedInfo</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl">
							<SharePoint:FormField runat="server" id="ff38{$Pos}" ControlMode="Edit" FieldName="UpdatedInfo" __designer:bind="{ddwrt:DataBind('u',concat('ff38',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@UpdatedInfo')}"/>
							<SharePoint:FieldDescription runat="server" id="ff38description{$Pos}" FieldName="UpdatedInfo" ControlMode="Edit"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>CurrentUser</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl">
							<SharePoint:FormField runat="server" id="ff39{$Pos}" ControlMode="Edit" FieldName="CurrentUser" __designer:bind="{ddwrt:DataBind('u',concat('ff39',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@CurrentUser')}"/>
							<SharePoint:FieldDescription runat="server" id="ff39description{$Pos}" FieldName="CurrentUser" ControlMode="Edit"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>Memo</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl">
							<SharePoint:FormField runat="server" id="ff40{$Pos}" ControlMode="Edit" FieldName="Memo" __designer:bind="{ddwrt:DataBind('u',concat('ff40',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@Memo')}"/>
							<SharePoint:FieldDescription runat="server" id="ff40description{$Pos}" FieldName="Memo" ControlMode="Edit"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>PREmails</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody cellctrl">
							<SharePoint:FormField runat="server" id="ff41{$Pos}" ControlMode="Edit" FieldName="PREmails" __designer:bind="{ddwrt:DataBind('u',concat('ff41',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@PREmails')}"/>
							<SharePoint:FieldDescription runat="server" id="ff41description{$Pos}" FieldName="PREmails" ControlMode="Edit"/>
						</td>
					</tr>
					<tr id="idAttachmentsRow">
						<td nowrap="true" valign="top" class="ms-formlabel" width="20%">
							<SharePoint:FieldLabel ControlMode="Edit" FieldName="Attachments" runat="server"/>
						</td>
						<td valign="top" class="ms-formbody" width="80%">
							<SharePoint:FormField runat="server" id="AttachmentsField" ControlMode="Edit" FieldName="Attachments" __designer:bind="{ddwrt:DataBind('u','AttachmentsField','Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@Attachments')}"/>
							<script>
          var elm = document.getElementById(&quot;idAttachmentsTable&quot;);
          if (elm == null || elm.rows.length == 0)
          document.getElementById(&quot;idAttachmentsRow&quot;).style.display=&apos;none&apos;;
        </script>
						</td>
					</tr>
					<xsl:if test="$dvt_1_automode = '1'" ddwrt:cf_ignore="1">
						<tr>
							<td colspan="99" class="ms-vb">
								<span ddwrt:amkeyfield="ID" ddwrt:amkeyvalue="ddwrt:EscapeDelims(string(@ID))" ddwrt:ammode="view"></span>
							</td>
						</tr>
					</xsl:if>
				</table>
				</div>
			</td>
			
		</tr>
	</xsl:template>
</xsl:stylesheet>	</Xsl>
<DataFields>


@Title,Title;@ASDDate,ASDDate;@BFEmail,BFEmail;@BFGuid,BFGuid;@BFGuide,BFGuide;@BFGuide_CN,BFGuide_CN;@comment,comment;@control_field,control_field;@counter,counter;@Ctry,Ctry;@EmplSubGrpName,EmplSubGrpName;@FirstName,FirstName;@IPA,IPA;@LastName,LastName;@Leavedate,Leavedate;@Name_IPA,Name_IPA;@Name_PR,Name_PR;@OrgUnitName,OrgUnitName;@Perc_SBU_1,Perc_SBU_1;@Perc_SBU_2,Perc_SBU_2;@Perc_SBU_3,Perc_SBU_3;@PersAreaName,PersAreaName;@PersNumber,PersNumber;@PR,PR;@Previous_Year_IPF,Previous_Year_IPF;@Previous_Year_IPF_Name,Previous_Year_IPF_Name;@Previous_Year_PC,Previous_Year_PC;@Previous_Year_PC_Name,Previous_Year_PC_Name;@PT,PT;@RTG,RTG;@SBU_1,SBU_1;@SBU_2,SBU_2;@SBU_3,SBU_3;@SbuName,SbuName;@SSGL,SSGL;@Supervisor,Supervisor;@Supervisor_CN,Supervisor_CN;@UpdatedInfo,UpdatedInfo;@Name,Name;@CurrentUser,CurrentUser;@Memo,Memo;@PREmails,PREmails;@Authors,Authors;@ID,ID;@ContentType,Content Type;@Modified,Modified;@Created,Created;@Author,Created By;@Editor,Modified By;@_UIVersionString,Version;@Attachments,Attachments;@File_x0020_Type,File Type;@FileLeafRef,Name (for use in forms);@FileDirRef,Path;@FSObjType,Item Type;@_HasCopyDestinations,Has Copy Destinations;@_CopySource,Copy Source;@ContentTypeId,Content Type ID;@_ModerationStatus,Approval Status;@_UIVersion,UI Version;@Created_x0020_Date,Created;@FileRef,URL Path;@ItemChildCount,Item Child Count;@FolderChildCount,Folder Child Count;@AppAuthor,App Created By;@AppEditor,App Modified By;</DataFields>
<ParameterBindings>
		 <ParameterBinding Name="ListItemId" Location="QueryString(ID)" DefaultValue="0"/>
		 <ParameterBinding Name="weburl" Location="None" DefaultValue="http://hcchspdev01:1122/sites/PerformanceReviewDB"/>
		 <ParameterBinding Name="ListID" Location="None" DefaultValue="{3DCAB08E-B70A-4AC7-BE31-D316352DC210}"/>
		 <ParameterBinding Name="dvt_apos" Location="Postback;Connection"/>
		 <ParameterBinding Name="ManualRefresh" Location="WPProperty[ManualRefresh]"/>
		 <ParameterBinding Name="UserID" Location="CAMLVariable" DefaultValue="CurrentUserName"/>
		 <ParameterBinding Name="Today" Location="CAMLVariable" DefaultValue="CurrentDate"/>
	 </ParameterBindings>
</WebPartPages:DataFormWebPart>

		</ZoneTemplate></WebPartPages:WebPartZone>
	  </td>
	 </tr>
	</table>
<SharePoint:UIVersionedContent UIVersion="4" runat="server">
	<ContentTemplate>
	</div>
	</ContentTemplate>
</SharePoint:UIVersionedContent>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderAdditionalPageHead" runat="server">
	<SharePoint:DelegateControl runat="server" ControlId="FormCustomRedirectControl" AllowMultipleControls="true"/>
	<SharePoint:UIVersionedContent UIVersion="4" runat="server"><ContentTemplate>
		<SharePoint:CssRegistration Name="forms.css" runat="server"/>
	</ContentTemplate></SharePoint:UIVersionedContent>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderTitleLeftBorder" runat="server">
<table cellpadding="0" height="100%" width="100%" cellspacing="0">
 <tr><td class="ms-areaseparatorleft"><img src="/_layouts/15/images/blank.gif?rev=23" width='1' height='1' alt="" /></td></tr>
</table>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderTitleAreaClass" runat="server">
<script type="text/javascript" id="onetidPageTitleAreaFrameScript">
	if (document.getElementById("onetidPageTitleAreaFrame") != null)
	{
		document.getElementById("onetidPageTitleAreaFrame").className="ms-areaseparator";
	}
</script>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderBodyAreaClass" runat="server">
<SharePoint:StyleBlock runat="server">
.ms-bodyareaframe {
	padding: 8px;
	border: none;
}
</SharePoint:StyleBlock>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderBodyLeftBorder" runat="server">
<div class='ms-areaseparatorleft'><img src="/_layouts/15/images/blank.gif?rev=23" width='8' height='100%' alt="" /></div>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderTitleRightMargin" runat="server">
<div class='ms-areaseparatorright'><img src="/_layouts/15/images/blank.gif?rev=23" width='8' height='100%' alt="" /></div>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderBodyRightMargin" runat="server">
<div class='ms-areaseparatorright'><img src="/_layouts/15/images/blank.gif?rev=23" width='8' height='100%' alt="" /></div>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderTitleAreaSeparator" runat="server"/>