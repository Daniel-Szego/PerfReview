
var PR = "";
var IPA = "";
var NamePR1 = "";
var NameIPA1 = "";
var getlegendval1 = "";
var Leads = "";
var MinIPAVal = "";
var MaxIPVal = "";
var IPAValue = "";
var PREditModeVal = "";

$(document).ready(function ()
{
    PREditModeVal = $('select[title="New PC"] option:selected').val();
    PopulatePRIPA();
    $('select[title="New PC"]').val(PREditModeVal);

    $('select[title="New PC"]').change(function ()
    {
        //alert("hi");
        PR = $('select[title="New PC"] option:selected').text();

        IPA = $("input[title='New IPF']").val();
        NamePR1 = $("input[title='Name_PR']").val();
        NameIPA1 = $("input[title='Name_IPA']").val();
        IPAValue = $("input[title='New IPF']").val();
    });

    // extenstion release 2
    $("#select_behaviour").change(onDropDownChanged);
    $("#select_goals").change(onDropDownChanged);
    onDropDownChanged();
    loadRangeTable();
});

function loadRangeTable()
{
    var _country = $("#id_country").text();
    if (_country)
    {

        try {
            $(".error").text("");
            $().SPServices(
                {
                    operation: 'GetListItems',
                    async: false,
                    debug: true,
                    listName: 'IPA_Range',
                    CAMLRowLimit: '<RowLimit>10</RowLimit>',
                    CAMLQuery: '<Query><Where><Eq><FieldRef Name="Country"/><Value Type="Text">' + _country + '</Value></Eq></Where></Query>',
                    completefunc: function (xData, Status) {                   
                        $(xData.responseXML).SPFilterNode("z:row").each(function () {
                            var categoryID = $(this).attr("ows_CategoryID");
                            var rangeFrom = $(this).attr("ows_Range_From");
                            var rangeRill = $(this).attr("ows_Range_Till");
                        });
                    }
                });
        } catch (ex) {
            WriteExceptionLog(ex, "ViewInstructions-PRjs");
            $(".error").text("An Error has occured contact Admin");
            $(".success").text("");
        }

        

    }
}

function onDropDownChanged()
{
    var goalVal = $("#select_goals").val();
    var behVar = $("#select_behaviour").val();
    var catNumDiv = $("#category_number");
    var catDescDiv = $("#category_desc");

    if ((goalVal == "exeeds") && (behVar == "exeeds"))
    {
        catNumDiv.text("1");
        catDescDiv.text("Exceptionel Performer");
        catDescDiv.css("background-color", "lawngreen");
    }
    else if ((goalVal == "meets") && (behVar == "exeeds"))
    {
        catNumDiv.text("3");
        catDescDiv.text("Leading Performer");
        catDescDiv.css("background-color", "LightGreen");
    }
    else if ((goalVal == "bellow") && (behVar == "exeeds")) {
        catNumDiv.text("6");
        catDescDiv.text("Improvement Needed");
        catDescDiv.css("background-color", "LightSalmon");
    }
    else if ((goalVal == "exeeds") && (behVar == "meets")) {
        catNumDiv.text("2");
        catDescDiv.text("Leading Performer");
        catDescDiv.css("background-color", "LightGreen");
    }
    else if ((goalVal == "meets") && (behVar == "meets")) {
        catNumDiv.text("4");
        catDescDiv.text("Strong Performer");
        catDescDiv.css("background-color", "LightGreen");
    }
    else if ((goalVal == "bellow") && (behVar == "meets")) {
        catNumDiv.text("8");
        catDescDiv.text("Imporvement Required")
        catDescDiv.css("background-color", "Yellow");
    }
    else if ((goalVal == "exeeds") && (behVar == "bellow")) {
        catNumDiv.text("5");
        catDescDiv.text("Improvement Needed");
        catDescDiv.css("background-color", "LightSalmon");
    }
    else if ((goalVal == "meets") && (behVar == "bellow")) {
        catNumDiv.text("7");
        catDescDiv.text("Impprovement Required");
        catDescDiv.css("background-color", "Yellow");
    }
    else if ((goalVal == "bellow") && (behVar == "bellow")) {
        catNumDiv.text("9");
        catDescDiv.text("Unsatisfactory");
        catDescDiv.css("background-color", "Tomato");
    }
    else {
        catDescDiv.css("background-color", "white");
    }

}

function UpdateSuperVisor()
{
    var sapno;
    JSRequest.EnsureSetup();
    var itemid = JSRequest.QueryString["ID"];
    sapno = prompt("Please Type the SAP Number of the new business functional supervisor", "");
    var url = "/Lists/PerformanceReview/PRPopUpPeoplePicker.aspx?IsDlg=1&ID=" + itemid + "&sapno=" + sapno;
    OpenPopUpPage(L_Menu_BaseUrl + url);
}

function PreSaveAction()
{
    var NamePR = $("input[title= 'Name_PR']").val();
    var NameIPA = $("input[title= 'Name_IPA']").val();

    var IPA = $("input[title='New IPF']").val().trim().length;
    var IPAValue = $("input[title='New IPF']").val().trim();
    var PRSelection = $('select[title="New PC"] option:selected').text();

    if (NamePR != "N/A")
    {
        if (PRSelection == "(None)")
        {
            alert("The value for 'Performance Rating (IPP)' is mandatory.");
            return false;
        }
        else
        {
            if (IPA == "0")
            {
                alert("You must specify a value for this required field IPA");
                return false;
            }
            else
            {
                $().SPServices(
                {
                    operation: 'GetListItems',
                    async: false,
                    debug: true,
                    listName: 'PerformanceKeywords',
                    CAMLRowLimit: '<RowLimit></RowLimit>',
                    CAMLQuery: '<Query><Where><And><Eq><FieldRef Name="Name_x0020_PR" /><Value Type="Text">' + NamePR + '</Value></Eq><And><Eq><FieldRef Name="Name_x0020_IPA" /><Value Type="Text">' + NameIPA + '</Value></Eq><Eq><FieldRef Name="PR" /><Value Type="Text">' + PRSelection + '</Value></Eq></And></And></Where></Query>',
                    completefunc: function (xData, Status)
                    {
                        $(xData.responseXML).SPFilterNode("z:row").each(function ()
                        {
                            //debugger;                  
                            getlegendval = $(this).attr("ows_IPA");
                        }); //XData Ends
                        //$('#ddlApprover').append(ddlfirstval+options);               
                    } //FilterNode ends ends
                }); //SPServices() end	
                Leads = getlegendval.split(':');
                MinIPAVal = Leads[0];
                MaxIPVal = Leads[1];
                //return true;	
                
                switch(PRSelection)
                {
                case "Insufficient time to evaluate":
                	if(IPAValue != "100")
                	{
                	alert("If the performance rating is 'Insufficient time to evaluate' the IPA value should always be " + MinIPAVal);
                    return false;
                	}
                	else if (parseInt(IPAValue) % 5 != 0)
              	  	{
                    alert(IPAValue + " is not a valid value, should be multiple of 5");
                    return false;
               		}
               		else
                	{
                	$('select[title="control_field"]').val("Ready"); 
               		return true;
               		}
               		break;
                case "Successful performance":
                	if (PRSelection == "Successful performance" && (parseInt(IPAValue) < parseInt(MinIPAVal)) || (parseInt(IPAValue) > parseInt(MaxIPVal)))
                	{
                    alert("If the performance rating is Successful performance, the IPA value should be between " + MinIPAVal + " and " + MaxIPVal);
                    return false;
                	}
               	 	else if (parseInt(IPAValue) % 5 != 0)
                	{
                    alert(IPAValue + " is not a valid value, should be multiple of 5");
                    return false;
                	}
                	else
               	 	{
               	 	$('select[title="control_field"]').val("Ready");
               		return true;
               		}
                	break;
                 case "Consistently exceptional performance":
                 	if (PRSelection == "Consistently exceptional performance" && (parseInt(IPAValue) < parseInt(MinIPAVal)) || (parseInt(IPAValue) > parseInt(MaxIPVal)))
                	{
                    alert("If the performance rating is Consistently exceptional performance, the IPA value should be between " + MinIPAVal + " and " + MaxIPVal);
                    return false;
                	}
                	else if (parseInt(IPAValue) % 5 != 0)
                	{
                    alert(IPAValue + " is not a valid value, should be multiple of 5");
                    return false;
                	}
                	else
                	{
                	    $('select[title="control_field"]').val("Ready");
               		return true;
               		}
                	break;
                case "Below required performance":
                	if (PRSelection == "Below required performance" && (parseInt(IPAValue) < parseInt(MinIPAVal)) || (parseInt(IPAValue) > parseInt(MaxIPVal)))
                	{
                    alert("If the performance rating is Below required performance, the IPA value should be between " + MinIPAVal + " and " + MaxIPVal);
                    return false;
                	}
                	else if (parseInt(IPAValue) % 5 != 0)
                	{
                    alert(IPAValue + " is not a valid value, should be multiple of 5");
                    return false;
                	}
                	else
                	{
                	$('select[title="control_field"]').val("Ready");
               		return true;
               		}
                	break;
                }
            }
        }
    } //Ends If(!="N/A")
    else
    {
        if (IPA == "0")
        {
            alert("You must specify a value for this required field IPA");
            return false;
        }
        else
        {
            var getlegendval = [];
            $().SPServices(
            {
                operation: 'GetListItems',
                async: false,
                debug: true,
                listName: 'PerformanceKeywords',
                CAMLRowLimit: '<RowLimit></RowLimit>',
                CAMLQuery: '<Query><Where><And><Eq><FieldRef Name="Name_x0020_PR" /><Value Type="Text">' + NamePR + '</Value></Eq><Eq><FieldRef Name="Name_x0020_IPA" /><Value Type="Text">' + NameIPA + '</Value></Eq></And></Where></Query>',
                completefunc: function (xData, Status)
                {
                    $(xData.responseXML).SPFilterNode("z:row").each(function ()
                    {
                        //debugger;                  
                        getlegendval.push($(this).attr("ows_IPA"));
                    }); //XData Ends
                    //$('#ddlApprover').append(ddlfirstval+options);               
                } //FilterNode ends ends
            }); //SPServices() end	
            
            var status = "0";
            var multip5= "0";
            $.each(getlegendval, function (i, val)
            {
                Leads = val.split(':');
                MinIPAVal = Leads[0];
                MaxIPVal = Leads[1];
                
                if(parseInt(IPAValue) % 5 != 0)
               	 {
               	 	status= "1";
               	 	alert(IPAValue + " is not a valid value, should be multiple of 5");
                    return false;
                 } 
                 else if(NamePR== "N/A" && parseInt(IPAValue) >= parseInt(MinIPAVal) && parseInt(IPAValue) <= parseInt(MaxIPVal))
                {
                status= "2";
                }                
            });
           if(status == "0")
            {
            	 alert(IPAValue + " is not valid, IPA value should be in one of the following brackets: 0-50, 90-110, 150-200");
                 return false;
            }
            else if(status == "1")
            {
            return false;
            }
            else
            {
                $('select[title="control_field"]').val("Ready");
            	return true;
            }
        }        
    }
    //return true;
}

function PopulatePRIPA()
{
    //var variablename = $("input[title='title of the input control']").val();        
    var options;
    var Leads;
    var items;

    var NamePR = $("input[title= 'Name_PR']").val();
    var NameIPA = $("input[title= 'Name_IPA']").val();

    if (NamePR == "N/A")
    {
        $('#tdPR').css("display", "none");
    }
    if (NameIPA == "N/A")
    {
        $('#tdIPA').css("display", "none");
    }

    $().SPServices(
    {
        operation: 'GetListItems',
        async: false,
        debug: true,
        listName: 'PerformanceKeywords',
        CAMLRowLimit: '<RowLimit></RowLimit>',
        CAMLQuery: '<Query><Where><And><Eq><FieldRef Name="Name_x0020_PR" /><Value Type="Text">' + NamePR + '</Value></Eq><Eq><FieldRef Name="Name_x0020_IPA" /><Value Type="Text">' + NameIPA + '</Value></Eq></And></Where></Query>',
        completefunc: function (xData, Status)
        {
            
            $('select[title="New PC"]').empty();
            var ddlfirstval = "<option value=0>(None)</option>";
            $('select[title="New PC"]').append(ddlfirstval);

            $(xData.responseXML).SPFilterNode("z:row").each(function ()
            {
                
                var PROptions = "<option value='" + $(this).attr("ows_ID") + "'>" + $(this).attr("ows_PR") + "</option>";               
                $('select[title="New PC"]').append(PROptions);
            }); //XData Ends
            //$('#ddlApprover').append(ddlfirstval+options);               
        } //FilterNode ends ends
    }); //SPServices() end 
}
