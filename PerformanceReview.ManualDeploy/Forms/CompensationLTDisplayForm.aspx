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
<script type="text/javascript" src="../../SiteAssets/JQuery/CustomPrint.js"></script>
<script type="text/javascript"> 
$(document).ready(function() 
{


GetNewPerformancelblName();	


  JSRequest.EnsureSetup();
  var CompensateID =JSRequest.QueryString["CompID"]; 
  var list="Letters";	
 

    
	var query="<Query><Where><Eq><FieldRef Name='ID'/><Value Type='Counter'>"+CompensateID+"</Value></Eq></Where></Query>";
    var rowlimit=1;
	var result=GetListItems(list, query,rowlimit);
	
	
              jQuery(result).find("z\\:row").each(function() {	
              	     
					
				var Type=$(this).attr('ows_NotesType');
				
				if(Type=="Merit")
				{
				$('#Merit').show();
				$('#AxaltaBonus').hide();
				$('#Bonus').hide();
				
				}
				if(Type=="AxaltaBonus")
				{
				$('#Merit').hide();
				$('#AxaltaBonus').show();
				
				}
					
                             	
				 
				 var firstName=$(this).attr('ows_FirstName');
				 var LastName=$(this).attr('ows_LastName');
				 var EmpName="";
				 if(LastName!="")
				 {
				 EmpName=firstName+","+LastName;
				 }
				 else
				 {
				 EmpName=firstName;
              
				}
				 $("#NameValue").html(EmpName);
				
				var newStatementDate=SplitDate($(this).attr('ows_StatementDate'));
				 		$("#StatementDateValue").html(newStatementDate);

				
				
				
                 $("#BUFunctionValue").html($(this).attr('ows_BU_Function'));				
                 $("#MangNameValue").html($(this).attr('ows_ManagerName')); 
                 $("#LocationValue").html($(this).attr('ows_Location')); 
                 $("#PerformanceCategorylblValue").html("<br/>"+$(this).attr('ows_PerformanceCategory')); 
                 
                 $("#MonthlySalary_Value").html($(this).attr('ows_MonthlySalary')); 
                 $("#AnnualSalaryValue").html($(this).attr('ows_AnnualSalary'));
                 
                //var ChangePercentNumeric=ConvertPercentage($(this).attr('ows_ChangePercent'));
                
               
                 $("#ChangePercent_Value").html($(this).attr('ows_ChangePercent')); 
                 
                 $("#ChangeAmtValue").html($(this).attr('ows_ChangeAmount')); 
                 $("#NewMnthSalaryValue").html($(this).attr('ows_NewMonthlySalary')); 
                 $("#NewAnnualSalaryValue").html($(this).attr('ows_NewAnnualSalary')); 
                 $("#RTGValue").html($(this).attr('ows_RTG'));
                 var newEffectiveDate=SplitDate($(this).attr('ows_EffectiveDate'));
				 		$("#EffectiveDateValue").html(newEffectiveDate);

                 
                 $("#STIPTargetValue").html($(this).attr('ows_STIPTarget')); 
                 $("#ProrationFactorValue").html($(this).attr('ows_ProrationFactor')); 
                 $("#CorporateFactorValue").html($(this).attr('ows_CorporateFactor')); 
                 $("#IBFValue").html($(this).attr('ows_IBF')); 
                 
                   var language= $(this).attr('ows_Language'); 
                
                 if(language!="FRENCH2")
                      {
                          $("#CPMonthlySeniority").hide();
                          $("#CPNewMonthlySeniority").hide();
                      }

 
			});
			
// Extended Printing Functionality

  var PrintPreview = JSRequest.QueryString["PrintPreview"]; 
  if (PrintPreview)
  {
  	 try {
        $("#imgprint").attr("src", L_Menu_BaseUrl + "/SiteAssets/Images/printerIcon.png");
        customPrint();
    } catch (ex) {
        WriteExceptionLog(ex, "Print- Page Load Script");
    }

  }
			
});

function GetListItems(listName, query,rowlimit) {	

var result;
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
          
      
            try {
            var options;
                if (status == "success" && exeresult) 
                {
                    result=exeresult;                        
                                  
                    
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
      
      return result;
}

function GetNewPerformancelblName()
{
//Statment Date
var CsString=$('#StatementDate').html();

 var arr=SplitLblName(CsString);
 $("#StatementDate").html(arr);

//AnnualCompensation Statement
var AnnualComp=$('#AnnualCompensationValue').html();
var NewAnnualComp=SplitAnnualCompHeading(AnnualComp);
$('#AnnualCompensationValue').html(NewAnnualComp);

//Name
var NamePerformance=$('#NameLbl').html();
var NewNamePerformance=SplitLblName(NamePerformance);
$('#NameLbl').html(NewNamePerformance);

//BU Function
var BUFunc=$('#BUFunctionlbl').html();
var NewBUFunc=SplitLblName(BUFunc);
$('#BUFunctionlbl').html(NewBUFunc);


//ManagerName
var ManagName=$('#MangNameLbl').html();
var NewMangName=SplitLblName(ManagName);
$('#MangNameLbl').html(NewMangName);


//Performace Category
var PefName=$('#PerformanceCategorylblNme').html();
var NewPefName=SplitLblName(PefName);
$('#PerformanceCategorylblNme').html(NewPefName);

//MeritTile
var MeritTitle=$('#MeritTitle').html();
var NewMeritTitle=SplitLblName(MeritTitle);
$('#MeritTitle').html(NewMeritTitle);

//Location

var Location=$('#LocationLbl').html();
var NewLocation=SplitLblName(Location);
$('#LocationLbl').html(NewLocation);



}

function SplitLblName(lblName)
{

        var string=lblName;
        var CharSplit=";";
        var NameChar="-";
        var arr ="";
        var count=0;
         
        var NewlblName="";
       if(lblName.indexOf(CharSplit) != -1)
       {
        arr=lblName.split(";");
       NewlblName=arr[0] +"<br>"+arr[1];
       string=NewlblName;
       count=1;

       }  
       if(lblName.indexOf(NameChar) != -1&&count!=1)
       {
        arr=lblName.split("-");
       NewlblName=arr[0] +"-"+"<br>"+arr[1];
       string=NewlblName;
       }
       
         
    return string;
         

}

function ConvertPercentage(PercentVal)
{
var Numeric="";
if(PercentVal!="")
{
var Percent=PercentVal.slice(0,-1);
Numeric=Percent/100;
}
return Numeric;
}


function SplitAnnualCompHeading(lblComp)
{

        var string=lblComp;
        var CharSplit=";";
        var arr ="";
        var NewlblName="";
       if(lblComp.indexOf(CharSplit) != -1)
       {
        arr=string.split(";");
       NewlblName=arr[0] +"<br>"+"<br>"+arr[1];

       }  
       else
       {
       NewlblName=string;
       }      
    return NewlblName;
         

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
	<table class="ms-core-tableNoSpace" id="onetIDListForm" width="100%" >
	 <tr>
	  <td>
	 <WebPartPages:WebPartZone runat="server" FrameType="None" ID="Main" Title="loc:Main"><ZoneTemplate>
		<WebPartPages:DataFormWebPart runat="server" EnableOriginalValue="False" DisplayName="CSLetterTemplate" ViewFlag="8" ViewContentTypeId="" Default="FALSE" ListName="{3FC068F1-6C06-4B68-B3B0-468716F1EFDC}" ListId="3fc068f1-6c06-4b68-b3b0-468716f1efdc" PageType="PAGE_DISPLAYFORM" PageSize="-1" UseSQLDataSourcePaging="True" DataSourceID="" ShowWithSampleData="False" AsyncRefresh="False" ManualRefresh="False" AutoRefresh="False" AutoRefreshInterval="60" NoDefaultStyle="TRUE" InitialAsyncDataFetch="False" Title="CSLetterTemplate" FrameType="None" SuppressWebPartChrome="False" Description="" IsIncluded="True" PartOrder="2" FrameState="Normal" AllowRemove="True" AllowZoneChange="True" AllowMinimize="True" AllowConnect="True" AllowEdit="True" AllowHide="True" IsVisible="True" DetailLink="" HelpLink="" HelpMode="Modeless" Dir="Default" PartImageSmall="" MissingAssembly="Cannot import this Web Part." PartImageLarge="" IsIncludedFilter="" ExportControlledProperties="True" ConnectionID="00000000-0000-0000-0000-000000000000" ID="g_73225afd_e877_4896_a5a8_a560fcc726a5" ChromeType="None" ExportMode="All" __MarkupType="vsattributemarkup" __WebPartId="{73225AFD-E877-4896-A5A8-A560FCC726A5}" __AllowXSLTEditing="true" WebPart="true" Height="" Width=""><DataSources>
<SharePoint:SPDataSource runat="server" DataSourceMode="ListItem" SelectCommand="&lt;View&gt;&lt;/View&gt;" UseInternalName="True" UseServerDataFormat="True"><SelectParameters><WebPartPages:DataFormParameter ParameterKey="ListItemId" PropertyName="ParameterValues" DefaultValue="0" Name="ListItemId"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="weburl" PropertyName="ParameterValues" DefaultValue="http://hcchspdev01:1122/sites/PerformanceReviewDB" Name="weburl"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="ListID" PropertyName="ParameterValues" DefaultValue="{3FC068F1-6C06-4B68-B3B0-468716F1EFDC}" Name="ListID"></WebPartPages:DataFormParameter>
			</SelectParameters><UpdateParameters><WebPartPages:DataFormParameter ParameterKey="ListItemId" PropertyName="ParameterValues" DefaultValue="0" Name="ListItemId"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="weburl" PropertyName="ParameterValues" DefaultValue="http://hcchspdev01:1122/sites/PerformanceReviewDB" Name="weburl"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="ListID" PropertyName="ParameterValues" DefaultValue="{3FC068F1-6C06-4B68-B3B0-468716F1EFDC}" Name="ListID"></WebPartPages:DataFormParameter>
			</UpdateParameters><InsertParameters><WebPartPages:DataFormParameter ParameterKey="ListItemId" PropertyName="ParameterValues" DefaultValue="0" Name="ListItemId"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="weburl" PropertyName="ParameterValues" DefaultValue="http://hcchspdev01:1122/sites/PerformanceReviewDB" Name="weburl"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="ListID" PropertyName="ParameterValues" DefaultValue="{3FC068F1-6C06-4B68-B3B0-468716F1EFDC}" Name="ListID"></WebPartPages:DataFormParameter>
			</InsertParameters><DeleteParameters><WebPartPages:DataFormParameter ParameterKey="ListItemId" PropertyName="ParameterValues" DefaultValue="0" Name="ListItemId"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="weburl" PropertyName="ParameterValues" DefaultValue="http://hcchspdev01:1122/sites/PerformanceReviewDB" Name="weburl"></WebPartPages:DataFormParameter><WebPartPages:DataFormParameter ParameterKey="ListID" PropertyName="ParameterValues" DefaultValue="{3FC068F1-6C06-4B68-B3B0-468716F1EFDC}" Name="ListID"></WebPartPages:DataFormParameter>
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
						<td>
							<input type="button" id="btnPrint" value="Print" onclick="javascript:customPrint();"/>
						</td>
						<td class="ms-toolbar" nowrap="nowrap" align="right">
							<SharePoint:GoBackButton runat="server" ControlMode="Display" id="gobackbutton1"/>
						</td>
					</tr>					
				</table>
			</td>
		</tr>
		<tr>
			<td class="ms-toolbar" nowrap="nowrap" style="display:none;">
				<SharePoint:FormToolBar runat="server" ControlMode="Display"/>
				<SharePoint:ItemValidationFailedMessage runat="server" ControlMode="Display"/>
			</td>
		</tr>
		<xsl:for-each select="$Rows">
			<xsl:call-template name="dvt_1.rowview"/>
		</xsl:for-each>
		<tr>
			<td class="ms-toolbar" nowrap="nowrap">
				<table style="display:none">
					<tr>
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
		<tr id="Printcontent">
			<td>	
				<table class="table table-noborder">
				<tr>				
					<td class="span12">
					<img id="imglogo" src="../../SiteAssets/Axalta_logo_global.png" />					
					</td>
					<td  class="span5 text-right" id="StatementDate" style="padding-right:10px;vertical-align :bottom" >
					<div>
						<xsl:value-of select="@StatementDate_Label"/>
						</div>
					</td>
					
					<td class="text-right span1" id="StatementDateValue" style="padding-right:10px; vertical-align:bottom">
				
					
						<xsl:value-of select="@StatementDate_Value"/>
						
					</td>
				</tr>
				<tr>
					<td class="span12" colspan="3" >
							<nobr><strong>CONFIDENTIAL</strong></nobr>
					</td>
				</tr>
			</table>
				<table class="table table-bordered">
				<tr>
				
				<td id="AnnualCompensationValue">
									<h4 class="text-center"><strong><xsl:value-of select="@Annual_Compensation_Statement"/></strong></h4>			
						</td>
												
				</tr>
			
				</table>
					<table class="table table-bordered"  >
					
					<tr>
						
						<td class="span3" id="NameLbl">
						<div class="ms-formbody">
							<xsl:value-of select="@Name_Label"/>
							</div>
						</td>
											
						<td class="span3" id="NameValue">
						<div class="ms-formbody">
							<xsl:value-of select="@Name_Value"/>
							</div>
						</td>
						
											
						<td class="span3"  id="BUFunctionlbl">
						<div class="ms-formbody">
							<xsl:value-of select="@BU_Function_Label"/>
							</div>
						</td>
					
						<td class="span3"  id="BUFunctionValue">
						<div class="ms-formbody">
							<xsl:value-of select="@BU_Function_Value"/>
							</div>
						</td>
					</tr>
					
					
					
					<tr>
					
					
<td  class="span3"  id="MangNameLbl">
<div class="ms-formbody">
							<xsl:value-of select="@ManagerName_Label"/>
							</div>
						</td>



<td  class="span3"  id="MangNameValue">
<div class="ms-formbody">
							<xsl:value-of select="@ManagerName_Value"/>
							</div>
						</td>
					
					
					<td  class="span3" id="LocationLbl">
					<div class="ms-formbody">
							<xsl:value-of select="@Location_Label"/>
							</div>
						</td>


<td class="span3" id="LocationValue">
<div class="ms-formbody">
							<xsl:value-of select="@Location_Value"/>
							</div>
						</td>
					
					
					
					</tr>
					
					
					
										
					
					</table>
					
					
					
					
					<table class="table" style="border-top: solid 5px #dddddd; border-bottom: solid 5px #dddddd">
					<tr>
					
					<td class="span6"  id="PerformanceCategorylblNme">
					<div class="ms-formbody">					
					
							<xsl:value-of select="@PerformanceCategory_Label"/>
							</div>						
					
					</td>
					
					
					
<td class="span6"  id="PerformanceCategorylblValue">
<div class="ms-formbody">
<p>test</p>
							<xsl:value-of select="@PerformanceCategory_Value"/>
							</div>
						</td>
					
					</tr>
					
					</table>
					
					
		
		



<table class="table table-bordered" id="Merit">

<tr>

<td class="span12" colspan="2"  id="MeritTitle">
					<h5>	<xsl:value-of select="@Merit_Title"/></h5>				
						
								</td>

</tr>


<tr>


<td  class="span8" id="MontlySalary_Label">
<div class="ms-formbody">
							<xsl:value-of select="@MontlySalary_Label"/>
							</div>
						</td>


<td class="span4" id="MonthlySalary_Value">
<div class="ms-formbody">
							<xsl:value-of select="@MonthlySalary_Value"/>
							</div>
						</td>




</tr>
<tr id="CPMonthlySeniority">


<td class="span8"  id="AnnualSalarylbl">
<div class="ms-formbody">
							<xsl:value-of select="@AnnualSalary_Title"/></div>
						</td>


<td class="span4" id="AnnualSalaryValue">
<div class="ms-formbody">
							<xsl:value-of select="@AnnualSalary_Value"/>
							</div>
						</td>


</tr>


<tr>


<td class="span8" >
<div class="ms-formbody">
							<xsl:value-of select="@ChangePercent_Label"/>
							</div>
						</td>



<td class="span4" id="ChangePercent_Value">
							<xsl:value-of select="@ChangePercent_Value"/>
						</td>


</tr>


<tr>
<td class="span8">
							<div class="ms-formbody">
<xsl:value-of select="@ChangeAmount_Label"/>
</div>
						</td>


<td class="span4" id="ChangeAmtValue">
<div class="ms-formbody">
							<xsl:value-of select="@ChangeAmount_Value"/>
							</div>
						</td>

</tr>


<tr>


<td class="span8">
<div class="ms-formbody">
							<xsl:value-of select="@NewMonthlySalary_Label"/>
							</div>
						</td>



<td  class="span4" id="NewMnthSalaryValue">
<div class="ms-formbody">
							<xsl:value-of select="@NewMonthlySalary_Value"/>
							</div>
						</td>



</tr>



<tr id="CPNewMonthlySeniority">

<td  class="span8">
<div class="ms-formbody">
							<xsl:value-of select="@NewAnnualSalary_Label"/>
							</div>
						</td>


<td class="span4" id="NewAnnualSalaryValue">
<div class="ms-formbody">
							<xsl:value-of select="@NewAnnualSalary_Value"/>
							</div>
						</td>


</tr>


<tr>


	<td class="span8">
							<div class="ms-formbody">
<xsl:value-of select="@RTG_Label"/>
</div>
						</td>



<td class="span4" id="RTGValue">
<div class="ms-formbody">
							<xsl:value-of select="@RTG_Value"/>
							</div>
						</td>

</tr>


<tr>

<td class="span8">
<div class="ms-formbody">
					
	<xsl:value-of select="@EffectiveDate_Label"/>
</div>	
						</td>



<td class="span4"  id="EffectiveDateValue">
<div class="ms-formbody">
							<xsl:value-of select="@EffectiveDate_Value"/>
							</div>
						</td>



</tr>




</table>


			
	<table class="table table-bordered"  id="AxaltaBonus">
	<tr>
	
	<td class="span12" colspan="2">
	
						<h5 class="text-left">	<xsl:value-of select="@STIPActual_Label"/> </h5>
						</td>
	
	</tr>
	
	
	<tr>
	
	<td class="span8">
					<div class="ms-formbody">
		<xsl:value-of select="@STIPTarget_Label"/>
		</div>
						</td>


<td  class="span4" id="STIPTargetValue">
<div class="ms-formbody">

						<xsl:value-of select="@STIPTarget_Value"/>
						</div>
						</td>
	
	
	</tr>
	
	
	
	<tr>
	
	<td class="span8">
							
							<div class="ms-formbody">
<xsl:value-of select="@ProrationFactor_Label"/>
</div>
						</td>




<td class="span4"  id="ProrationFactorValue">
<div class="ms-formbody">
							<xsl:value-of select="@ProrationFactor_Value"/>
							</div>
						</td>

	
	
	</tr>
	
	
	<tr>
	<td class="span8" >
							<div class="ms-formbody">
<xsl:value-of select="@CorporateFactor_Label"/>
</div>
						</td>



<td class="span4" id="CorporateFactorValue">
				<div class="ms-formbody">
			<xsl:value-of select="@CorporateFactor_Value"/>
			</div>
						</td>

	
	
	</tr>
	
	<tr>
	
	

<td class="span8" >
<div class="ms-formbody">
							<xsl:value-of select="@IBF_Label"/>
							</div>
						</td>




<td class="span4" id="IBFValue">
<div class="ms-formbody">
							<xsl:value-of select="@IBF_Value"/>
							</div>
						</td>	

	
	
	</tr>
	
	</table>	
	
	<table class="table table-bordered">
					<tr>
						<td class="span4">
							<H5 class="ms-standardheader ms-formbody">
								<nobr>MANAGER&apos;S COMMENTS:</nobr>
							</H5>
						</td>
			</tr>
									


<tr>
	<td style="height:180px;">
	<div class="ms-formbody">
	</div>	</td>
</tr>
				

</table>
	
	

<table class="table table-bordered">

<tr id="Bonus" >

	<td class="span12" bgcolor="#D7FFD7">
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














	
					<table style="display:none">
					
					
				<tr id="StatementDatelblNotUsed">
				
				<td width="190px" class="ms-formlabel" style="display:none">
							<H3 class="ms-standardheader">
								<nobr>StatementDate_Label</nobr>
							</H3>
						</td>
				<td width="190px"  class="ms-formlabel" style="display:none">
							<H3 class="ms-standardheader">
								<nobr>StatementDate_Value</nobr>
							</H3>
						</td>
				
				</tr>	
				
				
				
				<tr id="AnnualCompensationIDNotUsed" align="center">
						
						
						
						<td width="190px" valign="top" class="ms-formlabel" >
							<H3 class="ms-standardheader">
								<nobr>Annual_Compensation_Statement</nobr>
							</H3>
						</td>
						
						
					</tr>
				
				
				<tr>
				<td width="190px" valign="top" class="ms-formlabel" id="nameLabelNotUsed">
							<H3 class="ms-standardheader">
								<nobr>Name_Label</nobr>
							</H3>
						</td>
				<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>Name_Value</nobr>
							</H3>
						</td>
				
			
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>BU_Function_Label</nobr>
							</H3>
						</td>
						
					
				
				
				<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>BU_Function_Value</nobr>
							</H3>
						</td>
				
				</tr>
				
				
				
				
					
					<tr style="display:none">
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>Title</nobr>
							</H3>
						</td>
						<td width="190px" valign="top" class="ms-formbody">
							<xsl:value-of select="@Title"/>
						</td>
					</tr>
					
					
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ActualRestrictedStock_Label</nobr>
							</H3>
						</td>
						<td width="190px" class="ms-formbody" id="Location">
							<xsl:value-of select="@ActualRestrictedStock_Label"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ActualRestrictedStock_Value</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@ActualRestrictedStock_Value"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ActualStock_Label</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@ActualStock_Label"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ActualStock_Value</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@ActualStock_Value"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ActualTarget_Label</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@ActualTarget_Label"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ActualTarget_Value</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@ActualTarget_Value"/>
						</td>
					</tr>
					
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>AnnualSalary_Title</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>AnnualSalary_Value</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>BlackScholes_Label</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@BlackScholes_Label"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>BlackScholes_Value</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@BlackScholes_Value"/>
						</td>
					</tr>
					
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ChangeAmount_Label</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ChangeAmount_Value</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ChangePercent_Label</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ChangePercent_Value</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>CorporateFactor_Label</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>CorporateFactor_Value</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>EffectiveDate_Label</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>EffectiveDate_Value</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ExpectedLTI_Label</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@ExpectedLTI_Label"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ExpectedLTI_Value</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@ExpectedLTI_Value"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>GrantPrice_Label</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@GrantPrice_Label"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>GrantPrice_Value</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@GrantPrice_Value"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>IBF_Label</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>IBF_Value</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>IPA_Label</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@IPA_Label"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>IPA_Value</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@IPA_Value"/>
						</td>
					</tr>
					<tr>
						
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>Language</nobr>
							</H3>
						</td>
						
						<td width="400px" class="ms-formbody" id="Language">
							<xsl:value-of select="@Language" disable-output-escaping="yes"/>
						</td>
						
						
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>Location_Label</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>Location_Value</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>LookupLabels</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@LookupLabels"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>LookupValues</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@LookupValues"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>LTI_Title</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@LTI_Title"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>LTIFactor_Label</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@LTIFactor_Label"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>LTIFactor_Value</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@LTIFactor_Value"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>LTILevel_Label</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@LTILevel_Label"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>LTILevel_Value</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@LTILevel_Value"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ManagerName_Label</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ManagerName_Value</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>Merit_Title</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>MonthlySalary_Value</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>MontlySalary_Label</nobr>
							</H3>
						</td>
						
					</tr>
					
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>NewAnnualSalary_Label</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>NewAnnualSalary_Value</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>NewMonthlySalary_Label</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>NewMonthlySalary_Value</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>PerformanceCategory_Label</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>PerformanceCategory_Value</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ProrationFactor_Label</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>ProrationFactor_Value</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>PSUGrant_Label</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@PSUGrant_Label"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>PSUGrant_Value</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@PSUGrant_Value"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>RTG_Label</nobr>
							</H3>
						</td>
					
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>RTG_Value</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>SARGrant_Label</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@SARGrant_Label"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>SARGrant_Value</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@SARGrant_Value"/>
						</td>
					</tr>
					
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>STIP_DPC_Title</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@STIP_DPC_Title"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>STIP_Dupont_Title</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@STIP_Dupont_Title"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>STIP_Title</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@STIP_Title"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>STIPActual_Label</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>STIPActual_Value</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@STIPActual_Value"/>
						</td>
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>STIPTarget_Label</nobr>
							</H3>
						</td>
					
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>STIPTarget_Value</nobr>
							</H3>
						</td>
						
					</tr>
					<tr>
						<td width="190px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>NotesType</nobr>
							</H3>
						</td>
						<td width="400px" valign="top" class="ms-formbody">
							<xsl:value-of select="@NotesType"/>
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


























@Title,Title;@ActualRestrictedStock_Label,ActualRestrictedStock_Label;@ActualRestrictedStock_Value,ActualRestrictedStock_Value;@ActualStock_Label,ActualStock_Label;@ActualStock_Value,ActualStock_Value;@ActualTarget_Label,ActualTarget_Label;@ActualTarget_Value,ActualTarget_Value;@Annual_Compensation_Statement,Annual_Compensation_Statement;@AnnualSalary_Title,AnnualSalary_Title;@AnnualSalary_Value,AnnualSalary_Value;@BlackScholes_Label,BlackScholes_Label;@BlackScholes_Value,BlackScholes_Value;@BU_Function_Label,BU_Function_Label;@BU_Function_Value,BU_Function_Value;@ChangeAmount_Label,ChangeAmount_Label;@ChangeAmount_Value,ChangeAmount_Value;@ChangePercent_Label,ChangePercent_Label;@ChangePercent_Value,ChangePercent_Value;@CorporateFactor_Label,CorporateFactor_Label;@CorporateFactor_Value,CorporateFactor_Value;@EffectiveDate_Label,EffectiveDate_Label;@EffectiveDate_Value,EffectiveDate_Value;@ExpectedLTI_Label,ExpectedLTI_Label;@ExpectedLTI_Value,ExpectedLTI_Value;@GrantPrice_Label,GrantPrice_Label;@GrantPrice_Value,GrantPrice_Value;@IBF_Label,IBF_Label;@IBF_Value,IBF_Value;@IPA_Label,IPA_Label;@IPA_Value,IPA_Value;@Language,Language;@Location_Label,Location_Label;@Location_Value,Location_Value;@LookupLabels,LookupLabels;@LookupValues,LookupValues;@LTI_Title,LTI_Title;@LTIFactor_Label,LTIFactor_Label;@LTIFactor_Value,LTIFactor_Value;@LTILevel_Label,LTILevel_Label;@LTILevel_Value,LTILevel_Value;@ManagerName_Label,ManagerName_Label;@ManagerName_Value,ManagerName_Value;@Merit_Title,Merit_Title;@MonthlySalary_Value,MonthlySalary_Value;@MontlySalary_Label,MontlySalary_Label;@Name_Label,Name_Label;@Name_Value,Name_Value;@NewAnnualSalary_Label,NewAnnualSalary_Label;@NewAnnualSalary_Value,NewAnnualSalary_Value;@NewMonthlySalary_Label,NewMonthlySalary_Label;@NewMonthlySalary_Value,NewMonthlySalary_Value;@PerformanceCategory_Label,PerformanceCategory_Label;@PerformanceCategory_Value,PerformanceCategory_Value;@ProrationFactor_Label,ProrationFactor_Label;@ProrationFactor_Value,ProrationFactor_Value;@PSUGrant_Label,PSUGrant_Label;@PSUGrant_Value,PSUGrant_Value;@RTG_Label,RTG_Label;@RTG_Value,RTG_Value;@SARGrant_Label,SARGrant_Label;@SARGrant_Value,SARGrant_Value;@StatementDate_Label,StatementDate_Label;@StatementDate_Value,StatementDate_Value;@STIP_DPC_Title,STIP_DPC_Title;@STIP_Dupont_Title,STIP_Dupont_Title;@STIP_Title,STIP_Title;@STIPActual_Label,STIPActual_Label;@STIPActual_Value,STIPActual_Value;@STIPTarget_Label,STIPTarget_Label;@STIPTarget_Value,STIPTarget_Value;@NotesType,NotesType;@ID,ID;@ContentType,Content Type;@Modified,Modified;@Created,Created;@Author,Created By;@Editor,Modified By;@_UIVersionString,Version;@Attachments,Attachments;@File_x0020_Type,File Type;@FileLeafRef,Name (for use in forms);@FileDirRef,Path;@FSObjType,Item Type;@_HasCopyDestinations,Has Copy Destinations;@_CopySource,Copy Source;@ContentTypeId,Content Type ID;@_ModerationStatus,Approval Status;@_UIVersion,UI Version;@Created_x0020_Date,Created;@FileRef,URL Path;@ItemChildCount,Item Child Count;@FolderChildCount,Folder Child Count;@AppAuthor,App Created By;@AppEditor,App Modified By;</DataFields>
<ParameterBindings>
		 <ParameterBinding Name="ListItemId" Location="QueryString(ID)" DefaultValue="0"/>
		 <ParameterBinding Name="weburl" Location="None" DefaultValue="http://hcchspdev01:1122/sites/PerformanceReviewDB"/>
		 <ParameterBinding Name="ListID" Location="None" DefaultValue="{3FC068F1-6C06-4B68-B3B0-468716F1EFDC}"/>
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
