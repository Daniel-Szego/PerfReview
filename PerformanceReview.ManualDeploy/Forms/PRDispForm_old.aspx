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
<SharePoint:UIVersionedContent UIVersion="4" runat="server">
	<ContentTemplate>
	<div style="padding-left:5px">
	</ContentTemplate>
</SharePoint:UIVersionedContent>
	<table class="ms-core-tableNoSpace" id="onetIDListForm">
	 <tr>
	  <td>
	 <WebPartPages:WebPartZone runat="server" FrameType="None" ID="Main" Title="loc:Main"><ZoneTemplate>
		<WebPartPages:DataFormWebPart runat="server" EnableOriginalValue="False" DisplayName="PerformanceReview" ViewFlag="1048584" ViewContentTypeId="" Default="FALSE" ListUrl="" ListDisplayName="" ListName="{3DCAB08E-B70A-4AC7-BE31-D316352DC210}" ListId="3dcab08e-b70a-4ac7-be31-d316352dc210" PageType="PAGE_DISPLAYFORM" PageSize="-1" UseSQLDataSourcePaging="True" DataSourceID="" ShowWithSampleData="False" AsyncRefresh="False" ManualRefresh="False" AutoRefresh="False" AutoRefreshInterval="60" NoDefaultStyle="TRUE" InitialAsyncDataFetch="False" Title="PerformanceReview" FrameType="None" SuppressWebPartChrome="False" Description="" IsIncluded="True" PartOrder="2" FrameState="Normal" AllowRemove="True" AllowZoneChange="True" AllowMinimize="True" AllowConnect="True" AllowEdit="True" AllowHide="True" IsVisible="True" DetailLink="" HelpLink="" HelpMode="Modeless" Dir="Default" PartImageSmall="" MissingAssembly="Cannot import this Web Part." PartImageLarge="" IsIncludedFilter="" ExportControlledProperties="True" ConnectionID="00000000-0000-0000-0000-000000000000" ID="g_1f216d97_b6dc_4dd8_92cb_16e535542ee5" ChromeType="None" ExportMode="All" __MarkupType="vsattributemarkup" __WebPartId="{1F216D97-B6DC-4DD8-92CB-16E535542EE5}" __AllowXSLTEditing="true" WebPart="true" Height="" Width=""><DataSources>
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
					
						<xsl:variable name="dvt_RowCount" select="count($Rows)"/>
					
						<xsl:variable name="dvt_IsEmpty" select="$dvt_RowCount = 0"/>
					
						<xsl:choose>
							<xsl:when test="$dvt_IsEmpty">
								<xsl:call-template name="dvt_1.empty"/>
							</xsl:when>
							<xsl:otherwise>
							<table border="0" width="100%">
								<xsl:call-template name="dvt_1.body">
									<xsl:with-param name="Rows" select="$Rows"/>
									
								</xsl:call-template>
							</table>
							</xsl:otherwise>
						</xsl:choose>
						</xsl:template>
						<xsl:template name="dvt_1.body">
							<xsl:param name="Rows"/>
						<tr>
							<td class="ms-toolbar" nowrap="nowrap">
							<table>
								<tr>
									<!--	<td width="99%" class="ms-toolbar" nowrap="nowrap"><IMG SRC="/_layouts/15/images/blank.gif" width="1" height="18"/></td>-->
									
									<td class="ms-toolbar" nowrap="nowrap" align="right">
									
										<input type="button" onclick="UpdateSupervisor('PerformanceReview');" title="Update supervisors info" value="Update supervisor's info"/>
										</td>

									<td class="ms-toolbar" nowrap="nowrap" align="right">
									
									<SharePoint:GoBackButton runat="server" ControlMode="Display" id="gobackbutton1"/>
									
									</td>
								</tr>
							</table>
							</td>
						</tr>
						<tr>
							<td class="ms-toolbar" nowrap="nowrap">
							<SharePoint:FormToolBar runat="server" ControlMode="Display"/>
							
							<SharePoint:ItemValidationFailedMessage runat="server" ControlMode="Display"/>
							
							</td>
						</tr>
							<xsl:for-each select="$Rows">
								<xsl:call-template name="dvt_1.rowview"/>
							</xsl:for-each>
							<tr>
								<td class="ms-toolbar" nowrap="nowrap">
								<table>
									<tr>
										<td class="ms-descriptiontext" nowrap="nowrap">
										
										<SharePoint:CreatedModifiedInfo ControlMode="Display" runat="server"/>
										
										</td>
										<td class="ms-toolbar" nowrap="nowrap" align="right">
										
										<input type="button" onclick="UpdateSupervisor('PerformanceReview');" title="Update supervisors info" value="Update supervisor's info"/>
										</td>
										<td class="ms-toolbar" nowrap="nowrap" align="right">
										
										<SharePoint:GoBackButton runat="server" ControlMode="Display" id="gobackbutton2"/>
										
										</td>
									</tr>
								</table>
								</td>
							</tr>
							</xsl:template>
							<xsl:template name="dvt_1.rowview">
							<tr>
								<td>
								<div>
										<span class="span12 ms-formbody"><strong><u>Employee Data</u></strong></span></div>
										
								<table class="table table-bordered" >					
									<tr>
										<td class="span2">
										
										<H5 class="ms-standardheader ms-formbody">
										<nobr>PersNumber</nobr>
										</H5>
										</td>
										<td>
										
										<div class="ms-formbody">
										<xsl:value-of select="@PersNumber" disable-output-escaping="yes"/>
										</div>
										
										</td>
										
										<td class="span2">
										
										<H5 class="ms-standardheader ms-formbody">
										<nobr>Employee Name</nobr>
										</H5>
										</td>
										<td class="span2">
						<div class="ms-formbody">

							<xsl:value-of select="@LastName" disable-output-escaping="yes"/><span>, </span><xsl:value-of select="@FirstName" disable-output-escaping="yes"/>
							</div>
						</td>									
										
										
										<td class="span1" >
										<H5 class="ms-standardheader ms-formbody">
														
										<nobr>Ctry</nobr>
										</H5>
										</td>
										
										<td class="span1">
										<div class="ms-formbody">
										<xsl:value-of select="@Ctry" disable-output-escaping="yes"/>
										</div>
										</td>
										
										
									</tr>
									<tr>
										<td class="span2" >
										
										<H5 class="ms-standardheader ms-formbody">
										<nobr>PersAreaName</nobr>
										</H5>
										</td>
										<td class="span2" >
										<div class="ms-formbody">

										<xsl:value-of select="@PersAreaName" disable-output-escaping="yes"/>
										</div>
										</td>
										<td  class="span2">
										
										<H5 class="ms-standardheader ms-formbody">
										<nobr>EmplSubGrpName</nobr>
										</H5>
										</td>
										<td class="span2" >
										<div class="ms-formbody">

										<xsl:value-of select="@EmplSubGrpName" disable-output-escaping="yes"/>
										</div>
										</td>
										<td class="span2">
										<H5 class="ms-standardheader ms-formbody">
										<nobr>OrgUnitName</nobr>
										</H5>
										</td>
										<td  class="span2" >
										<div class="ms-formbody">
										<xsl:value-of select="@OrgUnitName" disable-output-escaping="yes"/>
										</div>
										</td>
									</tr>
									<tr>
										<td class="span2" >
										
										<H5 class="ms-standardheader ms-formbody">
										<nobr>SbuName</nobr>
										</H5>
										</td>
										<td class="span2" >
										<div class="ms-formbody">

										<xsl:value-of select="@SbuName" disable-output-escaping="yes"/>
										</div>
										</td>
										<td class="span2">
										
										<H5 class="ms-standardheader ms-formbody">
										<nobr>RTG</nobr>
										</H5>
										</td>
										<td class="span2" >
										<div class="ms-formbody">

										<xsl:value-of select="@RTG" disable-output-escaping="yes"/>
										</div>
										</td>
										<td class="span2">
										
										<H5 class="ms-standardheader ms-formbody">
										<nobr>PT</nobr>
										</H5>
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
										<nobr>SSGL</nobr>
										</H5>
										</td>
										<td class="span2">
										<div class="ms-formbody">

										<xsl:value-of select="@SSGL" disable-output-escaping="yes"/>
										</div>
										</td>
										<td class="span2" >
										
										<H5 class="ms-standardheader ms-formbody">
										<nobr>ASDDate</nobr>
										</H5>
										</td>
										<td class="span2">
										<div class="ms-formbody">

										<xsl:value-of select="@ASDDate" disable-output-escaping="yes"/>
										</div>
										</td>
										<td class="span2">
										
										<H5 class="ms-standardheader ms-formbody">
										<nobr>Leavedate</nobr>
										</H5>
										</td>
										<td class="span2" >
										<div class="ms-formbody">

										<xsl:value-of select="@Leavedate" disable-output-escaping="yes"/>
										</div>
										</td>
									</tr>
								</table>
								
										<div>
										<span class="span12 ms-formbody"><strong><u>Previous Year Performance</u></strong></span>
										</div>

								<table class="table table-bordered" >
									<tr>
										<td class="span3">
										<div class="ms-formbody">
										<xsl:value-of select="@Previous_Year_PC_Name" disable-output-escaping="yes"/>
										</div>
										</td>
										
										<td class="span3">
										<div class="ms-formbody">
										<xsl:value-of select="@Previous_Year_PC" disable-output-escaping="yes"/>
										</div>
										</td>
										<td class="span3">
										<div class="ms-formbody">

										<xsl:value-of select="@Previous_Year_IPF_Name" disable-output-escaping="yes"/>
										</div>
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
					
					<table class="table table-bordered">
									<tr>
										<td class="span3">
										<div class="ms-formbody">

										<xsl:value-of select="@Name_PR" disable-output-escaping="yes"/>
										</div>
										</td>
										<td class="span3">
										<div class="ms-formbody">

										<xsl:value-of select="@PR" disable-output-escaping="yes"/>
										</div>
										</td>
										<td class="span3">
										<div class="ms-formbody">

										<xsl:value-of select="@Name_IPA" disable-output-escaping="yes"/>
										</div>
										</td>
										<td class="span3">
										<div class="ms-formbody">

										<xsl:value-of select="@IPA" disable-output-escaping="yes"/>
										</div>
										</td>
									</tr>
									</table>
									
									<div>
										<span class="span12 ms-formbody"><strong><u>Comments</u></strong></span>
									</div>
									<table>
									<tr>
										<td colspan="2" style="display:none" >
										
										<H3 class="ms-standardheader ms-formbody">
										<nobr>comment</nobr>
										</H3>
										</td>
										
										<td colspan="2" style="display:none">
										<div class="ms-formbody">

										<xsl:value-of select="@comment" disable-output-escaping="yes"/>
										</div>
										</td>
									</tr>
								</table>					
								
									
									<div>	<span class="span12 ms-formbody"><strong><u>Supervisor</u></strong></span></div>
									
									
									<table class="table table-bordered">	
									<tr>
										<td class="span2">
										
										<H5 class="ms-standardheader ms-formbody">
										<nobr>BFGuid</nobr>
										</H5>
										</td>
										<td class="span2">
										<div class="ms-formbody">
										
										<xsl:value-of select="@BFGuid" disable-output-escaping="yes"/>
										</div>
										</td>
										<td class="span2">
										
										<H5 class="ms-standardheader ms-formbody">
										<nobr>BFGuide</nobr>
										</H5>
										</td>
										<td class="span2">
										<div class="ms-formbody">

										<xsl:value-of select="@BFGuide" disable-output-escaping="yes"/>
										</div>
										
										</td>
										<td class="span2">
										
										<H5 class="ms-standardheader ms-formbody">
										<nobr>BFEmail</nobr>
										</H5>
										</td>
										<td class="span2">
										<div class="ms-formbody">

										<xsl:value-of select="@BFEmail" disable-output-escaping="yes"/>
										</div>
										</td>
									</tr>
								</table>
								<table style="display:none">
									<tr>
										<td width="190px" valign="top" class="ms-formlabel">
										
										<H3 class="ms-standardheader">
										<nobr>Title</nobr>
										</H3>
										</td>
										<td width="400px" valign="top" class="ms-formbody">
										
										<xsl:value-of select="@Title"/>
										</td>
									</tr>
									<tr>
										<td width="190px" valign="top" class="ms-formlabel">
										
										<H3 class="ms-standardheader">
										<nobr>BFGuide_CN</nobr>
										</H3>
										</td>
										<td width="400px" valign="top" class="ms-formbody">
										
										<xsl:value-of select="@BFGuide_CN" disable-output-escaping="yes"/>
										
										</td>
									</tr>
									<tr>
										<td width="190px" valign="top" class="ms-formlabel">
										
										<H3 class="ms-standardheader">
										<nobr>control_field</nobr>
										</H3>
										</td>
										<td width="400px" valign="top" class="ms-formbody">
										
										<xsl:value-of select="@control_field"/>
										
										</td>
									</tr>
									<tr>
										<td width="190px" valign="top" class="ms-formlabel">
										
										<H3 class="ms-standardheader">
										<nobr>counter</nobr>
										</H3>
										</td>
										<td width="400px" valign="top" class="ms-formbody">
										
										<xsl:value-of select="@counter"/>
										
										</td>
									</tr>
									<tr>
										<td width="190px" valign="top" class="ms-formlabel">
										
										<H3 class="ms-standardheader">
										<nobr>Perc_SBU_1</nobr>
										</H3>
										</td>
										<td width="400px" valign="top" class="ms-formbody">
										
										<xsl:value-of select="@Perc_SBU_1"/>
										
										</td>
									</tr>
									<tr>
										<td width="190px" valign="top" class="ms-formlabel">
										
										<H3 class="ms-standardheader">
										<nobr>Perc_SBU_2</nobr>
										</H3>
										</td>
										<td width="400px" valign="top" class="ms-formbody">
										
										<xsl:value-of select="@Perc_SBU_2"/>
										
										</td>
									</tr>
									<tr>
										<td width="190px" valign="top" class="ms-formlabel">
										
										<H3 class="ms-standardheader">
										<nobr>Perc_SBU_3</nobr>
										</H3>
										</td>
										<td width="400px" valign="top" class="ms-formbody">
										
										<xsl:value-of select="@Perc_SBU_3"/>
										
										</td>
									</tr>
									<tr>
										<td width="190px" valign="top" class="ms-formlabel">
										
										<H3 class="ms-standardheader">
										<nobr>SBU_1</nobr>
										</H3>
										</td>
										<td width="400px" valign="top" class="ms-formbody">
										
										<xsl:value-of select="@SBU_1"/>
										</td>
									</tr>
									<tr>
										<td width="190px" valign="top" class="ms-formlabel">
										
										<H3 class="ms-standardheader">
										<nobr>SBU_2</nobr>
										</H3>
										</td>
										<td width="400px" valign="top" class="ms-formbody">
										
										<xsl:value-of select="@SBU_2"/>
										</td>
									</tr>
									<tr>
										<td width="190px" valign="top" class="ms-formlabel">
										
										<H3 class="ms-standardheader">
										<nobr>SBU_3</nobr>
										</H3>
										</td>
										<td width="400px" valign="top" class="ms-formbody">
										
										<xsl:value-of select="@SBU_3"/>
										</td>
									</tr>
									<tr>
										<td width="190px" valign="top" class="ms-formlabel">
										
										<H3 class="ms-standardheader">
										<nobr>Supervisor</nobr>
										</H3>
										</td>
										<td width="400px" valign="top" class="ms-formbody">
										
										<xsl:value-of select="@Supervisor" disable-output-escaping="yes"/>
										
										</td>
									</tr>
									<tr>
										<td width="190px" valign="top" class="ms-formlabel">
										
										<H3 class="ms-standardheader">
										<nobr>Supervisor_CN</nobr>
										</H3>
										</td>
										<td width="400px" valign="top" class="ms-formbody">
										
										<xsl:value-of select="@Supervisor_CN" disable-output-escaping="yes"/>
										
										</td>
									</tr>
									<tr>
										<td width="190px" valign="top" class="ms-formlabel">
										
										<H3 class="ms-standardheader">
										<nobr>UpdatedInfo</nobr>
										</H3>
										</td>
										<td width="400px" valign="top" class="ms-formbody">
										
										<xsl:value-of select="@UpdatedInfo"/>
										
										</td>
									</tr>
									<tr>
										<td width="190px" valign="top" class="ms-formlabel">
										
										<H3 class="ms-standardheader">
										<nobr>CurrentUser</nobr>
										</H3>
										</td>
										<td width="400px" valign="top" class="ms-formbody">
										
										<xsl:value-of select="@CurrentUser" disable-output-escaping="yes"/>
										
										</td>
									</tr>
									<tr>
										<td width="190px" valign="top" class="ms-formlabel">
										
										<H3 class="ms-standardheader">
										<nobr>Memo</nobr>
										</H3>
										</td>
										<td width="400px" valign="top" class="ms-formbody">
										
										<xsl:value-of select="@Memo"/>
										</td>
									</tr>
									<tr>
										<td width="190px" valign="top" class="ms-formlabel">
										
										<H3 class="ms-standardheader">
										<nobr>PREmails</nobr>
										</H3>
										</td>
										<td width="400px" valign="top" class="ms-formbody">
										
										<a href="{substring-before(@PREmails, ', ')}">
										
										<xsl:value-of select="substring-after(@PREmails, ', ')"/>
										
										</a>
										</td>
									</tr>
									<tr id="idAttachmentsRow">
										<td nowrap="true" valign="top" class="ms-formlabel" width="20%">
										
										<SharePoint:FieldLabel ControlMode="Display" FieldName="Attachments" runat="server"/>
										
										</td>
										<td valign="top" class="ms-formbody" width="80%">
										
										<SharePoint:FormField runat="server" id="AttachmentsField" ControlMode="Display" FieldName="Attachments" __designer:bind="{ddwrt:DataBind('u','AttachmentsField','Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@Attachments')}"/>
										
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
								</td>
							</tr>
							</xsl:template>
							<xsl:template name="dvt_1.empty">
								<xsl:variable name="dvt_ViewEmptyText">There are no items to show in this view.</xsl:variable>
							
							<table border="0" width="100%">
								<tr>
									<td class="ms-vb">
									<xsl:value-of select="$dvt_ViewEmptyText"/>
									
									</td>
								</tr>
							</table>
							</xsl:template>
							</xsl:stylesheet>	</Xsl>
<DataFields>


@Title,Title;@ASDDate,Adj. Serv. Date;@BFEmail,BFEmail;@BFGuid,SAP# Bus. Func. Sup;@BFGuide,Name Bus. Func. Sup;@BFGuide_CN,BFGuide_CN;@comment,Comment;@control_field,control_field;@counter,counter;@Ctry,Country;@EmplSubGrpName,EESubgr;@FirstName,First Name;@IPA,IPA;@LastName,Last Name;@Leavedate,Leavers Date;@Name_IPA,Name_IPA;@Name_PR,Name_PR;@OrgUnitName,Org. Unit;@Perc_SBU_1,Perc_SBU_1;@Perc_SBU_2,Perc_SBU_2;@Perc_SBU_3,Perc_SBU_3;@PersAreaName,Pers. Area;@PersNumber,SAP Number;@PR,PR;@Previous_Year_IPF,Previous. Year IPF;@Previous_Year_IPF_Name,Previous_Year_IPF_Name;@Previous_Year_PC,Previous. Year IPC;@Previous_Year_PC_Name,Previous_Year_PC_Name;@PT,Work Time %;@RTG,RTG;@SBU_1,SBU_1;@SBU_2,SBU_2;@SBU_3,SBU_3;@SbuName,SBU;@SSGL,SSGL;@Supervisor,Supervisor;@Supervisor_CN,Supervisor_CN;@UpdatedInfo,UpdatedInfo;@Name,Name;@CurrentUser,CurrentUser;@Memo,Memo;@PREmails,PREmails;@Authors,Authors;@Status,Status;@PC,PC;@IPF,IPF;@Image,Image;@ID,ID;@ContentType,Content Type;@Modified,Modified;@Created,Created;@Author,Created By;@Editor,Modified By;@_UIVersionString,Version;@Attachments,Attachments;@File_x0020_Type,File Type;@FileLeafRef,Name (for use in forms);@FileDirRef,Path;@FSObjType,Item Type;@_HasCopyDestinations,Has Copy Destinations;@_CopySource,Copy Source;@ContentTypeId,Content Type ID;@_ModerationStatus,Approval Status;@_UIVersion,UI Version;@Created_x0020_Date,Created;@FileRef,URL Path;@ItemChildCount,Item Child Count;@FolderChildCount,Folder Child Count;@AppAuthor,App Created By;@AppEditor,App Modified By;</DataFields>
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
}</SharePoint:StyleBlock>
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
