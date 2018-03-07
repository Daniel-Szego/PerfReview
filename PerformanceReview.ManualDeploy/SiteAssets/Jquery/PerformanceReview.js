// Global Variables
var clientContext = "";
var oList = "";
var collListItem = "";
var currentUserID = "";
var oListItem = "";
var Param = "";
var source = "";
//Instructions
function ViewInstructions(type) {
    try {
        $(".error").text("");
        $().SPServices(
            {
                operation: 'GetListItems',
                async: false,
                debug: true,
                listName: 'Instructions',
                CAMLRowLimit: '<RowLimit>1</RowLimit>',
                CAMLQuery: '<Query><Where><Eq><FieldRef Name="Section"/><Value Type="Text">' + type + '</Value></Eq></Where></Query>',
                completefunc: function (xData, Status) {
                    $(xData.responseXML).SPFilterNode("z:row").each(function () {
                        var Id = $(this).attr("ows_ID");
                        var link = _spPageContextInfo.webServerRelativeUrl + "/Lists/Instructions/DisplayItem.aspx?ID=" + Id + "&Source=" + encodeURIComponent(window.location.href);
                        window.location.href = link;
                    });
                }
            });
        //clientContext = new SP.ClientContext(_spPageContextInfo.webServerRelativeUrl);
        //oList = clientContext.get_web().get_lists().getByTitle('Instructions');
        //var camlQuery = new SP.CamlQuery();
        //camlQuery.set_viewXml(
        //    '<View><Query><Where><Eq><FieldRef Name=\'Section\' />' +
        //    '<Value Type=\'Text\'>' + type + '</Value></Eq></Where></Query>' +
        //    '<RowLimit>1</RowLimit></View>'
        //);
        //collListItem = oList.getItems(camlQuery);
        //clientContext.load(collListItem);
        //clientContext.executeQueryAsync(
        //    Function.createDelegate(this, this.onInstQuerySucceeded),
        //    Function.createDelegate(this, this.onInstQueryFailed)
        //);
    } catch (ex) {
        WriteExceptionLog(ex, "ViewInstructions-PRjs");
        $(".error").text("An Error has occured contact Admin");
        $(".success").text("");
    }
}

function onInstQuerySucceeded(sender, args) {
    try {
        var listItemEnumerator = collListItem.getEnumerator();
        while (listItemEnumerator.moveNext()) {
            oListItem = listItemEnumerator.get_current();
            var listItemID = oListItem.get_id();            
            var link = _spPageContextInfo.webServerRelativeUrl + "/Lists/Instructions/DisplayItem.aspx?ID=" + listItemID + "&Source=" + encodeURIComponent(window.location.href);
            window.location.href = link;
        }

    } catch (ex) {
        WriteExceptionLog(ex, "onQuerySucceeded-PRjs");
        $(".error").text("An Error has occured contact Admin");
    }
}

function onInstQueryFailed(sender, args) {
    $(".error").text('');
}

//I need help - please contact me
function CallHelp(listname) {
    try {
        $(".error").text("");
        currentUserID = _spPageContextInfo.userId;
        var confirmmodify = confirm("You are requesting for someone to contact you within the next 72 hours. Is this correct?");
        if (confirmmodify) {
            
            SP.SOD.executeFunc('SP.js', 'SP.ClientContext', function () {
                clientContext = SP.ClientContext.get_current();
                oList = clientContext.get_web().get_lists().getByTitle(listname);
                var camlQuery = new SP.CamlQuery();
                camlQuery.set_viewXml(
                    '<View><Query><OrderBy><FieldRef Name=\'Title\' Ascending=\'True\' /></OrderBy></Query>' +
                    '<RowLimit>1</RowLimit></View>'
                );
                collListItem = oList.getItems(camlQuery);
                clientContext.load(collListItem);
                clientContext.executeQueryAsync(
                    Function.createDelegate(this, this.onHelpQuerySucceeded),
                    Function.createDelegate(this, this.onHelpQueryFailed)
                );
            });
        } else {
            return false;
        }
    } catch (ex) {
        WriteExceptionLog(ex, "CallHelp-PRjs");
        $(".error").text("An Error has occured contact Admin");
        $(".success").text("");
    }
}

function onHelpQuerySucceeded(sender, args) {
    try {
        var listItemEnumerator = collListItem.getEnumerator();
        while (listItemEnumerator.moveNext()) {
            oListItem = listItemEnumerator.get_current();            
            oListItem.set_item('Title', "Yes");
            oListItem.set_item('CurrentUser', currentUserID);
            //need to update the current user name in separate field and to from in email
            oListItem.update();
        }
        clientContext.executeQueryAsync(
                Function.createDelegate(this, this.onHelpSucceeded),
                Function.createDelegate(this, this.onHelpFailed)
            );

    } catch (ex) {
        WriteExceptionLog(ex, "onHelpQuerySucceeded-PRjs");
        $(".error").text("An Error has occured contact Admin");
    }
}

function onHelpSucceeded(sender, args) {
    var msg=confirm('A message was sent to HRCoatings. You will be contacted within 3 days');
}
function onHelpFailed(sender, args) {
    $(".error").text('');
}
function onHelpQueryFailed(sender, args) {
    $(".error").text('');
}

//I am missing a reportee
function CallMissingReportee(listname) {
    $(".error").text("");
    if (listname == "DataCleaning") {
        OpenPopUpPageWithTitle(_spPageContextInfo.webServerRelativeUrl + '/SitePages/DCPopup.aspx?IsDlg=1', null, null, null, "I'm missing a reportee");
    }    
    if (listname == "PerformanceReview")
        OpenPopUpPageWithTitle(_spPageContextInfo.webServerRelativeUrl + '/SitePages/PRMissingaReportee.aspx?IsDlg=1', null, null, null, "I'm missing a reportee");
        
}
function OnMissingCallBackup(result, returnValue) {
    if (result == SP.UI.DialogResult.OK) {
        confirm('The current supervisor has been requested to move this employee to your list within 3 days. Might this not be done in 3 days, please contact HRCoatings.');
    }
}
function TriggerMissingReporteeMail() {
    try {
        $(".error").text("");
        
        currentUserID = _spPageContextInfo.userId;
        clientContext = SP.ClientContext.get_current();
        var listId = SP.ListOperation.Selection.getSelectedList();        
        collListItem = SP.ListOperation.Selection.getSelectedItems(clientContext);
        if (listId != null)
            oList = clientContext.get_web().get_lists().getById(listId);
        if (collListItem.length == 1) {            
            var itemid = collListItem[0].id;            
            oListItem = oList.getItemById(itemid);
            oListItem.set_item('Title', "Memo");
            oListItem.set_item('CurrentUser', currentUserID);
            oListItem.update();
            clientContext.executeQueryAsync(
                    Function.createDelegate(this, this.onMissingReporteeSucceeded),
                    Function.createDelegate(this, this.onMissingReporteeFailed)
                );
        }
        else {
            var msg=confirm("Please select one reportee missing from the list");
        }
    } catch (ex) {
        WriteExceptionLog(ex, "TriggerMissingReporteeMail-PRjs");
        $(".error").text("An Error has occured contact Admin");
    }
}
function onMissingReporteeSucceeded(sender, args) {
    
    var msg=confirm('The current supervisor has been requested to move this employee to your list within 3 days. Might this not be done in 3 days, please contact HRCoatings.');        
    SP.SOD.executeFunc('SP.js', 'SP.ClientContext', function () { ClosePopup(); });
}
function onMissingReporteeFailed(sender, args) {
    $(".error").text("An Error has occured contact Admin");
}

//This employee does not report to me
function CallNotReporting(listname) {
    try {
        $(".error").text("");
        Param = listname;
        currentUserID = _spPageContextInfo.userId;
        clientContext = SP.ClientContext.get_current();
        var listId = SP.ListOperation.Selection.getSelectedList();
        collListItem = SP.ListOperation.Selection.getSelectedItems(clientContext);
        if (listId != null)
            oList = clientContext.get_web().get_lists().getById(listId);
        if (collListItem.length == 1) {
            var itemid = collListItem[0].id;
            oListItem = oList.getItemById(parseInt(itemid));
            clientContext.load(oListItem);
            clientContext.executeQueryAsync(
                    Function.createDelegate(this, this.onNotReportSucceeded),
                    Function.createDelegate(this, this.onNotReportFailed)
                );
        }
        else {
            var msg=confirm("Please select one reportee missing from the list");
        }
    } catch (ex) {
        WriteExceptionLog(ex, "CallNotReporting-PRjs");
        $(".error").text("An Error has occured contact Admin");
    }
}

function onNotReportSucceeded(sender, args) {
    var LName = oListItem.get_item('LastName');
    var FName = oListItem.get_item('FirstName');
    var ID = oListItem.get_item('ID');
    var confselectedmsg = "Are you sure " + FName + " " + LName + " does not report to you?"
    var confselected = confirm(confselectedmsg);
    if (confselected) {
        var confknowsupver = confirm("Do you know who the new supervisor is? If you click OK, you will need to pick the new supervisor, who will receive an e-mail informing about the change.");
        if (confknowsupver) {
            //need to call the edit page need to add call back
            switch (Param) {
                case "DataCleaning":
                    OpenPopUpPageWithTitle(_spPageContextInfo.webServerRelativeUrl + '/Lists/DataCleaning/NotReporteePopup.aspx?IsDlg=1&ID=' + ID, null, null, null, "Select New Supervisor");
                    break;
                case "PerformanceReview":
                    OpenPopUpPageWithTitle(_spPageContextInfo.webServerRelativeUrl + '/Lists/PerformanceReview/PREmployeeNotReportingMe.aspx?IsDlg=1&ID=' + ID, null, null, null, "Select New Supervisor");
                    break;
                default: break;
            }
        }
        else {
            currentUserID = _spPageContextInfo.userId;
            oListItem.set_item('CurrentUser', currentUserID);
            oListItem.set_item('Title', "NotKnewSupervisor");

            oListItem.set_item('BFGuid', "");
            oListItem.set_item('BFGuide', "");
            oListItem.set_item('BFEmail', "");
            oListItem.set_item('Supervisor', ";#");
            oListItem.set_item('Supervisor_CN', ";#");
            oListItem.set_item('BFGuide_CN', ";#");
            oListItem.update();
            clientContext.executeQueryAsync(
                        Function.createDelegate(this, this.onupdateCurrentUserSucceeded),
                        Function.createDelegate(this, this.onupdateCurrentUserFailed)
                    );
        }

    }
}
function onNotReportFailed(sender, args) {
    $(".error").text("An Error has occured contact Admin");
}

function onupdateCurrentUserSucceeded(sender, args) {
    var msg=confirm("The requested change has been submitted. HRCoatings will be informed automatically about the change. The employee will be removed from your list within 3 days.");
}
function onupdateCurrentUserFailed(sender, args) {
    $(".error").text("An Error has occured contact Admin");
}

//Update supervisor's info
function UpdateSupervisor(listname) {
    try {
        $(".error").text("");
        var sapno="";
        var url = "";
        JSRequest.EnsureSetup();
        var itemid = JSRequest.QueryString["ID"];
        source = decodeURIComponent(JSRequest.QueryString["Source"]);        
        sapno = prompt("Please Type the SAP Number of the new business functional supervisor", "");
        switch (listname) {
            case "DataCleaning":
                url = "/Lists/DataCleaning/UpdateSupPopup.aspx?IsDlg=1&ID=" + itemid + "&sapno=" + sapno;
                break;
            case "PerformanceReview":
                url = "/Lists/PerformanceReview/PRPopUpPeoplePicker.aspx?IsDlg=1&ID=" + itemid + "&sapno=" + sapno;
                break;
            default: break;
        }
        OpenPopUpPageWithTitle(_spPageContextInfo.webServerRelativeUrl + url, OnUpdateCallBackup, null, null, "Select New Supervisor");
    } catch (ex) {
        WriteExceptionLog(ex, "UpdateSupervisor-PRjs");
        $(".error").text("An Error has occured contact Admin");
    }
}
function OnUpdateCallBackup(result, returnValue) {    
    if (result == SP.UI.DialogResult.OK) {
        window.location.href = source;
    }
}
//Close the Modal Popup
function ClosePopup() {
    ExecuteOrDelayUntilScriptLoaded(function () { SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel, "Cancelled"); }, "sp.js");    
}

//Show action in Datacleaning Status
function UpdateShow() {
    try {
        $(".error").text("");
        clientContext = SP.ClientContext.get_current();
        var listId = SP.ListOperation.Selection.getSelectedList();
        collListItem = SP.ListOperation.Selection.getSelectedItems(clientContext);
        if (listId != null)
            oList = clientContext.get_web().get_lists().getById(listId);
        var k;
        for (k in collListItem) {
            oListItem = oList.getItemById(collListItem[k].id);
            oListItem.set_item('Hide', "No");
            oListItem.update();
        }
        clientContext.executeQueryAsync(Function.createDelegate(this, this.onUpdateShowSucceeded), Function.createDelegate(this, this.onUpdateShowFailed));
    } catch (ex) {
        WriteExceptionLog(ex, "UpdateShow-PRjs");
        $(".error").text("An Error has occured contact Admin");
    }
}
function onUpdateShowSucceeded(sender, args) {
    window.location.reload();
}
function onUpdateShowFailed(sender, args) {
    $(".error").text("An Error has occured contact Admin");
}

//Hide action in Datacleaning Status
function UpdateHide() {
    try {
        $(".error").text("");
        clientContext = SP.ClientContext.get_current();
        var listId = SP.ListOperation.Selection.getSelectedList();
        collListItem = SP.ListOperation.Selection.getSelectedItems(clientContext);
        if (listId != null)
            oList = clientContext.get_web().get_lists().getById(listId);
        var k;
        for (k in collListItem) {
            oListItem = oList.getItemById(collListItem[k].id);
            oListItem.set_item('Hide', "Yes");
            oListItem.update();
        }
        clientContext.executeQueryAsync(Function.createDelegate(this, this.onUpdateHideSucceeded), Function.createDelegate(this, this.onUpdateHideFailed));
    } catch (ex) {
        WriteExceptionLog(ex, "UpdateHide-PRjs");
        $(".error").text("An Error has occured contact Admin");
    }
}
function onUpdateHideSucceeded(sender, args) {
    window.location.reload();
}
function onUpdateHideFailed(sender, args) {
    $(".error").text("An Error has occured contact Admin");
}