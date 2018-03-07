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


<style>
	h5, h4,h6
	{
		color:#333333 !important;
	}


</style>



<script type="text/javascript" src="../../SiteAssets/JQuery/jquery1.10.2.js"></script>
<script type="text/javascript" src="../../SiteAssets/JQuery/jquery.SPServices-2014.01.js"></script>
<script type="text/javascript">
$(document).ready(function()
{

var Type=$("#NotesType").text();	
			
				if(Type=="Merit")
				{
				$('#tbMerit').show();
				$('#AxaltaBonus').hide();
				$('#Bonus').hide();
				}
				if(Type=="AxaltaBonus")
				{
				$('#tbMerit').hide();
				$('#AxaltaBonus').show();

				}
					
					


UserInGrp=GetLogginedUserGrp();



if(UserInGrp=="true")
{
$("#CompLetterType").show();
$("#trShwLetterbtn").show();

//Hide Monthly senerioty Premium
var language=$("#CompLanguage").text();
if(language!="FRENCH2")
{
$("#CPMonthlySeniority").hide();
$("#CPNewMonthlySeniority").hide();
}

var Effective=$("#CPEffectiveDate").html();
var NewEffectiveDate=SplitDate(Effective);
$("#CPEffectiveDate").html(NewEffectiveDate);



var StatemenDate=$("#StatementDate").html();
var NewStatemenDateDate=SplitDate(StatemenDate);
$("#StatementDate").html(NewStatemenDateDate);

}

else
{
var LetterID="";
$("#CompLetterType").hide();
$("#trShwLetterbtn").hide();
LetterID=ShowLetterAdmin();
RedirectURL(LetterID);

}


});



function GetLogginedUserGrp()
{



 var UserInGrp="false";
 $().SPServices({  
  operation: "GetGroupCollectionFromUser",  
        userLoginName: $().SPServices.SPGetCurrentUser(),  
        async: false,  
        completefunc: function(xData, Status) 
        {
        if ($(xData.responseXML).find("Group[Name='SysAdmin']").length == 1)     
        {
        UserInGrp="true"
          
         }   
         else
            {
         UserInGrp="false"
         
          
}
  }
 
  });
  return UserInGrp;
  
  }

function RedirectURL(CsLetterTemplateID)
{

 
    

     JSRequest.EnsureSetup();
     var SelectedCompensation = JSRequest.QueryString['ID'];

//Print Preview Changing R2
    var PrintPreview = JSRequest.QueryString["PrintPreview"]; 
    
   if(PrintPreview)
   {        
    var targetUrl = L_Menu_BaseUrl + "/Lists/CSLetterTemplate/CompensationLTDisplayForm.aspx?ID="+CsLetterTemplateID+"&CompID="+SelectedCompensation+"&PrintPreview=true";
    window.location.href = targetUrl;
   }
   else
   {
    var targetUrl = L_Menu_BaseUrl + "/Lists/CSLetterTemplate/CompensationLTDisplayForm.aspx?ID="+CsLetterTemplateID+"&CompID="+SelectedCompensation;
    window.location.href = targetUrl;  	
   }
   
    
}


function ShowLetterAdmin()
{

    var list="CSLetterTemplate";	
    var language=$("#CompLanguage").text();
    var LetterType=$("#NotesType").text();
   
	var NotesType=SplitLblName(LetterType);
	
	
	var query="<Query><Where><And><Eq><FieldRef Name='Language' /><Value Type='Lookup'>"+language+"</Value></Eq><Eq><FieldRef Name='NotesType' /><Value Type='Lookup'>"+NotesType+"</Value></Eq></And></Where></Query>";
	
    var rowlimit=1;
	 var CsLetterTemplateID=GetListItems(list, query,rowlimit);
	 
	 return CsLetterTemplateID;

}


function ShowCompensationLetter()
{
var CsLetterID="";
CsLetterID=ShowLetterAdmin();


if(CsLetterID!="")
{
RedirectURL(CsLetterID);
}
else
{
confirm("This letter hasn't got a template. Contact with your administrator..");

}

}




function GetListItems(listName, query,rowlimit) {	

var CsLetterTemplateID;
    var soapEnv =
   "<soap:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'" +
   " xmlns:xsd='http://www.w3.org/2001/XMLSchema' \
      xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/'> \
      <soap:Body> \
        <GetListItems xmlns='http://schemas.microsoft.com/sharepoint/soap/'> \
          <listName>" + listName + "</listName> \
          <viewName></viewName> \
          <query>" + query + "</query> \
          <viewFields></viewFields> \
          <rowLimit>" + rowlimit + "</rowLimit> \
          <queryOptions><QueryOptions xmlns=''><IncludeMandatoryColumns>FALSE</IncludeMandatoryColumns><ViewAttributes Scope='RecursiveAll'/></QueryOptions></queryOptions> \
        </GetListItems> \
      </soap:Body> \
    </soap:Envelope>";
   
    $.ajax({
        url: L_Menu_BaseUrl + "/_vti_bin/Lists.asmx",
        type: "POST",
        dataType: "xml",
        data: soapEnv,
        async:false,
        complete: function (xData, status) {
            var exeresult="";
        
            exeresult = xData.responseXML;   
          
            //alert(xData.responseText);         
            try {
            var options;
                if (status == "success" && exeresult) 
                {
                    result=exeresult;                        
                                  
                    $(result).find("z\\:row").each(function() {			     
					CsLetterTemplateID=$(this).attr('ows_ID');
										
					});
		       }
            }
            catch (e) {
                //alert(e);
               // $(".error").text("An Error has occured contact Admin");
                //WriteExceptionLog(e,"GetListItems");
            }
        },
        contentType: "text/xml; charset=\"utf-8\""
      });
      
      return CsLetterTemplateID;
}


function SplitLblName(lblName)
{

        var string=lblName;
        var CharSplit="&";
        var arr ="";
        var NotesType="";
        
       if(lblName.indexOf(CharSplit) != -1)
       {
        arr=string.split("&");
       NotesType=arr[0] +"&amp;"+arr[1];

       }  
       else
       {
       NotesType=string;
       }      
    return NotesType;
         

}


function SplitDate(CPDate)
{


        var CharSplit=" ";
        var arr ="";
        var NewDate="";
       if(CPDate.indexOf(CharSplit) != -1)
       {
        arr=CPDate.split(" ");
       NewDate=arr[0];
       }  
       else
       {
       NewDate=CPDate;
       }      
    return NewDate;
         

}

</script>
<SharePoint:UIVersionedContent UIVersion="4" runat="server">
	<ContentTemplate>
	<div style="padding-left:5px">
	</ContentTemplate>
</SharePoint:UIVersionedContent>
	<table class="ms-core-tableNoSpace" id="onetIDListForm" width="100%">
	 <tr>
	  <td>
	 <WebPartPages:WebPartZone runat="server" FrameType="None" ID="Main" Title="loc:Main"><ZoneTemplate>
		<WebPartPages:DataFormWebPart runat="server" EnableOriginalValue="False" DisplayName="Letters" ViewFlag="1048584" ViewContentTypeId="" Default="FALSE" ListUrl="" ListDisplayName="" ListName="{6B302965-969E-4C8E-8789-454F6B5BDCA8}" ListId="6b302965-969e-4c8e-8789-454f6b5bdca8" PageType="PAGE_DISPLAYFORM" PageSize="-1" UseSQLDataSourcePaging="True" DataSourceID="" ShowWithSampleData="False" AsyncRefresh="False" ManualRefresh="False" AutoRefresh="False" AutoRefreshInterval="60" NoDefaultStyle="TRUE" InitialAsyncDataFetch="False" Title="Letters" FrameType="None" SuppressWebPartChrome="False" Description="" IsIncluded="True" PartOrder="2" FrameState="Normal" AllowRemove="True" AllowZoneChange="True" AllowMinimize="True" AllowConnect="True" AllowEdit="True" AllowHide="True" IsVisible="True" DetailLink="" HelpLink="" HelpMode="Modeless" Dir="Default" PartImageSmall="" MissingAssembly="Cannot import this Web Part." PartImageLarge="" IsIncludedFilter="" ExportControlledProperties="True" ConnectionID="00000000-0000-0000-0000-000000000000" ID="g_1ea22631_a2e2_42c5_8ca9_7dd64f537952" ChromeType="None" ExportMode="All" __MarkupType="vsattributemarkup" __WebPartId="{1EA22631-A2E2-42C5-8CA9-7DD64F537952}" __AllowXSLTEditing="true" WebPart="true" Height="" Width=""><DataSources>
<SharePoint:SPDataSource runat="server" DataSourceMode="ListItem" SelectCommand="&lt;View&gt;&lt;Query&gt;&lt;Where&gt;&lt;Eq&gt;&lt;FieldRef Name=&quot;ContentType&quot;/&gt;&lt;Value Type=&quot;Text&quot;&gt;Item&lt;/Value&gt;&lt;/Eq&gt;&lt;/Where&gt;&lt;/Query&gt;&lt;/View&gt;" UseInternalName="True" UseServerDataFormat="True"><SelectParameters><WebPartPages:DataFormParameter ParameterKey="ListItemId" PropertyName="ParameterValues" DefaultValue="0" Name="ListItemId"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="weburl" PropertyName="ParameterValues" DefaultValue="http://hcchspdev01:1122/sites/PerformanceReviewDB" Name="weburl"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="ListID" PropertyName="ParameterValues" DefaultValue="{6B302965-969E-4C8E-8789-454F6B5BDCA8}" Name="ListID"></WebPartPages:DataFormParameter>
			</SelectParameters><UpdateParameters><WebPartPages:DataFormParameter ParameterKey="ListItemId" PropertyName="ParameterValues" DefaultValue="0" Name="ListItemId"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="weburl" PropertyName="ParameterValues" DefaultValue="http://hcchspdev01:1122/sites/PerformanceReviewDB" Name="weburl"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="ListID" PropertyName="ParameterValues" DefaultValue="{6B302965-969E-4C8E-8789-454F6B5BDCA8}" Name="ListID"></WebPartPages:DataFormParameter>
			</UpdateParameters><InsertParameters><WebPartPages:DataFormParameter ParameterKey="ListItemId" PropertyName="ParameterValues" DefaultValue="0" Name="ListItemId"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="weburl" PropertyName="ParameterValues" DefaultValue="http://hcchspdev01:1122/sites/PerformanceReviewDB" Name="weburl"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="ListID" PropertyName="ParameterValues" DefaultValue="{6B302965-969E-4C8E-8789-454F6B5BDCA8}" Name="ListID"></WebPartPages:DataFormParameter>
			</InsertParameters><DeleteParameters><WebPartPages:DataFormParameter ParameterKey="ListItemId" PropertyName="ParameterValues" DefaultValue="0" Name="ListItemId"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="weburl" PropertyName="ParameterValues" DefaultValue="http://hcchspdev01:1122/sites/PerformanceReviewDB" Name="weburl"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="ListID" PropertyName="ParameterValues" DefaultValue="{6B302965-969E-4C8E-8789-454F6B5BDCA8}" Name="ListID"></WebPartPages:DataFormParameter>
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
				<table id="trShwLetterbtn">
				<tr ><td><input type="button" id="btnShowLetter" value="Show Letter" onclick="javascript:ShowCompensationLetter();"/></td>					<td><SharePoint:GoBackButton runat="server" ControlMode="Display" id="gobackbutton1"/></td>

						<td width="99%" class="ms-toolbar" nowrap="nowrap"><IMG SRC="/_layouts/15/images/blank.gif" width="1" height="18"/></td>
						<td class="ms-toolbar" nowrap="nowrap" align="right">
							
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
					<tr style="display:none">
						<td class="ms-descriptiontext" nowrap="nowrap">
							<SharePoint:CreatedModifiedInfo ControlMode="Display" runat="server"/>
						</td>
						<td width="99%" class="ms-toolbar" nowrap="nowrap"><IMG SRC="/_layouts/15/images/blank.gif" width="1" height="18"/></td>
						<td class="ms-toolbar" nowrap="nowrap" align="right">
							<SharePoint:GoBackButton runat="server" ControlMode="Display" id="gobackbutton2"/>
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</xsl:template>
	<xsl:template name="dvt_1.rowview">
		<tr id="CompLetterType">
			<td>
			
			
			<table class="table table-noborder" >			
			<tr>
						<td class="span1">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>Type</nobr>
							</H5>
						</td>
						<td class="span4" id="NotesType">
						<div class="ms-formbody">
							<xsl:value-of select="@NotesType"/>
							</div>
						</td>
				
						<td class="span3" >
							<H5 class="ms-standardheader text-right ms-formbody">
								<nobr>Language</nobr>
							</H5>
						</td>
						<td class=" span3" id="CompLanguage">
						<div class="ms-formbody">
							<xsl:value-of select="@Language"/>
							</div>
						</td>
					</tr>
			
			
			</table>
			
			
			
			
			<table>
			
	<tr>

<td>
<img id="imglogo" src="../../SiteAssets/Axalta_logo_global.png" style="padding-top:5px"/>

</td>

</tr>


<tr>
<td class="ms-formlabel text-center">
								<nobr><strong>CONFIDENTIAL</strong></nobr>
						</td>


</tr>		
			
			
			</table>
			
			
			
			<table>
			
			<tr>
			
			
						<td  class="span12 text-right"  style="padding-right:10px" >
					<div>
						Statement Date	</div>				
					</td>
						
						
						<td class="text-right span1" id="StatementDate" style="padding-right:10px">
					
							<xsl:value-of select="@StatementDate"/>
							

						</td>
					</tr>
			
			</table>
			
			
			
		<table class="table table-bordered" >
				<tr>
				<td>
				<h4 class="text-center"><strong><nobr>ANNUAL COMPENSATION STATEMENT</nobr></strong></h4>
							
						</td>
</tr>

</table>	
			
			<table class="table table-bordered" >	
			<tr>
						<td class="span3">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>FirstName</nobr>
							</H5>
						</td>
						<td class="span3">
						<div class="ms-formbody">
							<xsl:value-of select="@FirstName"/>
							</div>
						</td>
					
						<td class="span3">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>BU/Function</nobr>
							</H5>
						</td>
						<td  class="span3">
						<div class="ms-formbody">

							<xsl:value-of select="@BU_Function"/>
							</div>
						</td>
					</tr>
					
					<tr>
						<td class="span3">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>LastName</nobr>
							</H5>
						</td>
						<td class="span3">
						<div class="ms-formbody">
							<xsl:value-of select="@LastName"/>
							</div>
						</td>
					
					
						<td class="span3">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>Location</nobr>
							</H5>
						</td>
						<td class="span3">
						<div class="ms-formbody">
							<xsl:value-of select="@Location"/>
							</div>
						</td>
					</tr>
					
					
					<tr>
						<td class="span3">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>Line Manager Name</nobr>
							</H5>
						</td>
						<td class="span3">
						<div class="ms-formbody">
							<xsl:value-of select="@ManagerName"/>
							</div>
						</td>
				
						<td  class="span3">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>Line Manager Email</nobr>
							</H5>
						</td>
						<td  class="span3">
						<div class="ms-formbody">
							<xsl:value-of select="@ManagerEmail"/>
							</div>
						</td>
					</tr>
					
				<tr>
						<td  class="span3">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>Currency</nobr>
							</H5>
						</td>
						<td class="span3" >
						<div class="ms-formbody">
							<xsl:value-of select="@Currency"/>
							</div>
						</td>
						<td colspan="2"></td>
					</tr>	
			
			</table>
			
			
<table class="table" style="border-top: solid 5px #dddddd; border-bottom: solid 5px #dddddd">

<tr>
						<td class="span6">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>PERFORMANCE CATEGORY</nobr>
							</H5>
						</td>
						<td class="span6">
						<div class="ms-formbody">
							<xsl:value-of select="@PerformanceCategory"/>
							</div>
						</td>
					</tr>

</table>
			
			
	
	
	
	
	
	<table id="tbMerit" class="table table-bordered" >
	
<tr>
<td>

<H4 class="text-left ms-formbody">
								<nobr>Merit</nobr>							</H4>
</td>

</tr>

<tr>
						<td class="span4">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>Current Monthly Base Pay/Salary:</nobr>
							</H5>
						</td>
						<td class="span8">
						<div class="ms-formbody">
							<xsl:value-of select="@MonthlySalary"/>
							</div>
						</td>
					</tr>
					
					
					
					
					<tr id="CPMonthlySeniority">
						<td class="span4">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>Monthly Seniority Premium:</nobr>
							</H5>
						</td>
						<td class="span8">
						<div class="ms-formbody">
							<xsl:value-of select="@AnnualSalary"/>
							</div>
						</td>
					</tr>
					
					
					
					<tr>
						<td  class="span4">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>Change Percent:</nobr>
							</H5>
						</td>
						<td class="span8">
						<div class="ms-formbody">
							<xsl:value-of select="@ChangePercent"/></div>
						</td>
					</tr>
					
					
					<tr>
						<td class="span4">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>Change Amount:</nobr>
							</H5>
						</td>
						<td class="span8">
						<div class="ms-formbody">
							<xsl:value-of select="@ChangeAmount"/>
							</div>
						</td>
					</tr>
					
					
					
					<tr>
						<td class="span4">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>New Monthly Base Pay/Salary:</nobr>
							</H5>
						</td>
						<td class="span8">
						<div class="ms-formbody">
							<xsl:value-of select="@NewMonthlySalary"/>
							</div>
						</td>
					</tr>
					
					
					<tr id="CPNewMonthlySeniority">
						<td class="span4">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>New Monthly Seniority Premium:</nobr>
							</H5>
						</td>
						<td  class="span8">
						<div class="ms-formbody">
							<xsl:value-of select="@NewAnnualSalary"/>
							</div>
						</td>
					</tr>

<tr>
						<td class="span4">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>New Rate to guide (RTG):</nobr>
							</H5>
						</td>
						<td class="span8">
						<div class="ms-formbody">
							<xsl:value-of select="@RTG"/>
							</div>
						</td>
					</tr>

<tr>
						<td class="span4">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>Effective Date:</nobr>
							</H5>
						</td>
						<td  class="span8" id="CPEffectiveDate">
						
							<xsl:value-of select="@EffectiveDate"/>
							
						</td>
					</tr>



<tr>
						<td class="span4" style="display:none">
							<H3 class="ms-standardheader">
								<nobr>ExtraLabelMerit1</nobr>
							</H3>
						</td>
						<td  class="span4">
						<div class="ms-formbody">
							<xsl:value-of select="@ExtraLabelMerit1"/>
							</div>
						</td>
						
						<td class="span4">
						<div class="ms-formbody">
							<xsl:value-of select="@ExtraValueMerit1"/>
							</div>
						</td>
					</tr>


						<tr>
						<td class="span4">
						<div class="ms-formbody">
						<xsl:value-of select="@ExtraLabelMerit2"/></div>
						</td>
						
						<td class="span8">
						<div class="ms-formbody">
						<xsl:value-of select="@ExtraValueMerit2"/>
						</div>
						</td>
						
						</tr>
						
						
						
						<tr>
						<td class="span4">
						<div class="ms-formbody">
						<xsl:value-of select="@ExtraLabelMerit3"/>
						</div>
						</td>
						
						
						<td class="span8">
						<div class="ms-formbody">
						<xsl:value-of select="@ExtraValueMerit3"/>
						</div>
						</td>
						
						</tr>
						
							</table>
								
			
			
			
<table id="AxaltaBonus" class="table table-bordered">







<tr>
<td>

<H4 class="text-left ms-formbody">
								<nobr>2013 ANNUAL BONUS</nobr>							</H4>
</td>

</tr>








<tr>
						<td class="span4">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>2013 Bonus Target Award:</nobr>
							</H5>
						</td>
						<td class="span8">
						<div class="ms-formbody">
							<xsl:value-of select="@STIPTarget"/>
							</div>
						</td>
					</tr>
					
					
					
					
					<tr>
						<td  class="span4">
							<H4 class="ms-standardheader ms-formbody">
								<nobr>ProrationFactor:</nobr>
							</H4>
						</td>
						<td class="span8">
						<div class="ms-formbody">
							<xsl:value-of select="@ProrationFactor"/>
							</div>
						</td>
					</tr>
					
					
					
					<tr>
						<td class="span4">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>Individual Performance Assessment (IPA):</nobr>
							</H5>
						</td>
						<td  class="span8">
						<div class="ms-formbody">
							<xsl:value-of select="@CorporateFactor"/>
							</div>
						</td>
					</tr>
					
					
					<tr>
						<td class="span4">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>2013 Bonus Actual Award:</nobr>
							</H5>
						</td>
						<td class="span8">
						<div class="ms-formbody">
							<xsl:value-of select="@IBF"/>
							</div>
						</td>
					</tr>
					
					<tr>
					<td class="span4">
					<div class="ms-formbody">
							<xsl:value-of select="@ExtraLabelSTIP1"/>
							</div>
						</td>
					
					<td class="span8">
					<div class="ms-formbody">
							<xsl:value-of select="@ExtraValueSTIP1"/>
							</div>
						</td>
					
					</tr>


</table>		
<table class="table table-bordered" style="display:none">
					<tr>
						<td class="span4">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>MANAGER&apos;S COMMENTS:</nobr>
							</H5>
						</td>
						<td class="span8">
						<div class="ms-formbody">
</div>
							
						</td>
					</tr>				

</table>

	
	
	
	<table class="table table-bordered">

<tr id="Bonus" style="background-color:#D7FFD7;">

	<td class="span12">
	<div class="ms-formbody">
Bonus Formula:  Annual Guide Rate * Regional Target % * [(Business Factor * 75%) + (IPA * 25%)]	
	</div></td>
	
</tr>

<tr>
	<td>
	<div class="ms-formbody">
<h6>	* Please refer to your Manager for any questions.	</h6>
<h6>* If you are on a Sales Incentive Compensation program, you will be advised of your Sales Incentive payout through your Business.	</h6>
</div>	</td>
</tr>
<tr style="display:none">
	<td>
	<div class="ms-formbody">
<h6>* If you are on a Sales Incentive Compensation program, you will be advised of your Sales Incentive payout through your Business.	</h6>
</div>	</td>
</tr>


</table>
	
	
	
	
			
			
			
				<table border="0" cellspacing="0" width="100%" style="display:none">
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
								<nobr>ActualRestrictedStock</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@ActualRestrictedStock"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ActualStock</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@ActualStock"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ActualTarget</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@ActualTarget"/>
						</td>
					</tr>
					
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>BlackScholes</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@BlackScholes"/>
						</td>
					</tr>
					
					
					
					
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>CorporateFactor_2</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@CorporateFactor_2"/>
						</td>
					</tr>
					
					
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ExpectedLTI</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@ExpectedLTI"/>
						</td>
					</tr>
					
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ExtraLabelMerit2</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ExtraLabelMerit3</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ExtraLabelSTIP1</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ExtraValueMerit1</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ExtraValueMerit2</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ExtraValueMerit3</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ExtraValueSTIP1</nobr>
							</H3>
						</td>
						
					</tr>
					
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>GrantPrice</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@GrantPrice"/>
						</td>
					</tr>
					
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>IBF_2</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@IBF_2"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>IPA</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@IPA"/>
						</td>
					</tr>
					
					
					
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>LTIFactor</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@LTIFactor"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>LTILevel</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@LTILevel"/>
						</td>
					</tr>
					
					
					
					
					
					
					
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>PSUGrant</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@PSUGrant"/>
						</td>
					</tr>
					
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>SARGrant</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@SARGrant"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>StatementDate</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>STIPActual</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@STIPActual"/>
						</td>
					</tr>
					
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>Supervisor</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@Supervisor"/>
						</td>
					</tr>
					
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>YesNo</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@YesNo"/>
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
</DataFields>
<ParameterBindings>
		 <ParameterBinding Name="ListItemId" Location="QueryString(ID)" DefaultValue="0"/>
		 <ParameterBinding Name="weburl" Location="None" DefaultValue="http://hcchspdev01:1122/sites/PerformanceReviewDB"/>
		 <ParameterBinding Name="ListID" Location="None" DefaultValue="{6B302965-969E-4C8E-8789-454F6B5BDCA8}"/>
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

