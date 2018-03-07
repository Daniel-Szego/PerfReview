var clientContext = "";
var lstName="";
var oList = "";
var Ids = "";
var FilterDetails = "";

function DeleteFilterdItems(listname) {
	try {
        $(".error").text("");
		Ids = "";
		FilterDetails = "";
		lstName = listname;
		var pathname = decodeURIComponent(decodeURIComponent($(location).attr('href')));		
		var startindex = pathname.indexOf("FilterField");
		
		if (startindex > 0) {	
			var length = pathname.length;
			var substring = pathname.substring(startindex, length);
			var array = substring.split('-');
			arrayOfStrings = [];
			for (var k = 0; k < array.length; k++) {
				if (array[k].toLowerCase().indexOf('FilterField'.toLowerCase()) >= 0 || array[k].toLowerCase().indexOf('FilterValue'.toLowerCase()) >= 0) {
					arrayOfStrings.push(array[k]);
				}
			}

			var FieldName = '';
			var FinalString = '';
			var FieldString = '';
			var Field = '';
			var Value = '';
			var FilterValue = '';			

			for (var i = 0; i < arrayOfStrings.length; i = i + 2) {
				if (arrayOfStrings[i].split('=')[0].toLowerCase().indexOf('FilterField'.toLowerCase()) >= 0) {
					Field = arrayOfStrings[i].split('=')[1];
					Value = arrayOfStrings[i + 1].split('=')[1].split(';#');
					FilterValue=arrayOfStrings[i + 1].split('=')[1].replace(';#', ', ');
				}
				else {
					Field = arrayOfStrings[i + 1].split('=')[1];
					Value = arrayOfStrings[i].split('=')[1].split(';#');
					FilterValue=arrayOfStrings[i].split('=')[1].replace(';#', ', ');
				}

				if (Field.toLowerCase() == "ManagerName".toLowerCase()) {
					FieldName = "Manager";
				}
				else if (Field.toLowerCase() == "NotesType".toLowerCase()) {
					FieldName = "Types";
				}
				else {
					FieldName = "Language";
				}        
				
				FilterDetails += "<b>" +FieldName + "</b> = " + FilterValue + "</br>";

				for (var j = 0; j < Value.length; j++) {
					FieldString += "(" + FieldName + " eq '" + encodeURIComponent(Value[j]) + "') or ";
				}

				FinalString += "(" + FieldString.substring(0, FieldString.length - 4) + ") and ";

				var FieldName = '';
				var FieldString = '';
				var Field = '';
				var Value = '';
			}
			
			var query=   "(" + FinalString.substring(0, FinalString.length - 5) + ")";			
			var svcUrl = _spPageContextInfo.siteAbsoluteUrl + '/_vti_bin/ListData.svc/' + lstName + "?$filter=" + query;    

			$.ajax({
				type: "GET",
				url: svcUrl,
				dataType: "json",
				success: function (msg) {
					var result = msg.d.results;									
					for (var j = 0; j < result.length; j++) {
						Ids += result[j].Id + ',';                    
					}					
					DeleteConfirmation();
				},
				error: function (data) {
					$(".error").text("Can not get filter items at the moment");
				}
			});
		}
		else{
			$(".error").text("There is no filter applied on list");
		}
	} catch (ex) {        
        $(".error").text("An Error has occured contact Admin");
    }
}

function DeleteConfirmation() {
	var arrayOfId = Ids.split(',');	
	var itemCount = arrayOfId.length - 1;
	if (itemCount > 0) {	
		var msg = "Are you sure you want to delete " + itemCount + " items from the list with the following parameters? </br></br>"+FilterDetails;
		fancyConfirm(msg, function () {
			do_something('yes');
		}, function () {
			do_something('no');
		});
	}
	else{
		$(".error").text("There is no item available with filter criteria");
	}
}

function fancyConfirm(msg, callbackYes, callbackNo) {
    jQuery.fancybox({
        'modal': true,
        'content': "<div style=\"margin:10px;width:400px;\">" + msg + "<div style=\"text-align:right;margin-top:10px;\"><input id=\"fancyConfirm_ok\" style=\"margin:3px;padding:2px;\" type=\"button\" value=\"Ok\"><input id=\"fancyconfirm_cancel\" style=\"margin:3px;padding:2px;\" type=\"button\" value=\"Cancel\"></div></div>",
        'beforeShow': function () {
            jQuery("#fancyconfirm_cancel").click(function () {
                $.fancybox.close();
                callbackNo();
            });

            jQuery("#fancyConfirm_ok").click(function () {
                DeleteItems();
                $.fancybox.close();
            });
        }
    });
}

function DeleteItems() {
    try {
        var arrayOfId = Ids.split(',');		
        SP.SOD.executeFunc('SP.js', 'SP.ClientContext', function (){
        clientContext = SP.ClientContext.get_current();
        oList = clientContext.get_web().get_lists().getByTitle(lstName);
                    
        for (var i = 0; i < arrayOfId.length - 1; i++) {            
            var oListItem = oList.getItemById(arrayOfId[i]);            
            oListItem.deleteObject();
            clientContext.executeQueryAsync(Function.createDelegate(this, this.onQuerySucceeded), Function.createDelegate(this, this.onQueryFailed));
        }
        alert('All the items with selected criteria deleted successfully.');
        location.reload();
        });
    }
    catch (e) {
        $(".error").text("An Error has occured during item deletion. Please contact Admin");
    }
}

function onQuerySucceeded() {
}

function onQueryFailed(sender, args) {
    $(".error").text('Request failed. ' + args.get_message() + '\n' + args.get_stackTrace());
}