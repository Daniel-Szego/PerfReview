(function () {
    var PrintPreviewContext = {};

    // You can provide templates for:
    // View, DisplayForm, EditForm and NewForm
    PrintPreviewContext.Templates = {};
    PrintPreviewContext.Templates.Fields = {
        "Print": {
            "View": PrintPreviewTemplate
        }
    };

    SPClientTemplates.TemplateManager.RegisterTemplateOverrides(
        PrintPreviewContext
        );
})();

// The favoriteColorViewTemplate provides the rendering logic
// the custom field type when it is displayed in the view form.
function PrintPreviewTemplate(ctx) {
    try {

        var urlArchive;
        var urlArmServer;
        var item = ctx.CurrentItem;
        var name = item[ctx.CurrentFieldSchema.Name];

        var listTitle = ctx.ListTitle;
        var itemId = item.ID;
        var displayformurl = ctx.displayFormUrl;
        var url = " ".concat(displayformurl).concat("&ID=").concat(itemId).concat("&PrintPreview=true");

        var htmlToReturn = "<div><a href=\"#\" id=\"pr_printpreview" + itemId + "\" onclick=\"pr_dialogfunction(\'" + url + "\')\">Print Preview</a><div>";

        return htmlToReturn;
    }
    catch (ex) {
        //WriteExceptionLog(ex, "PageLoad- PRSecurity.js");
        ErrorLog("PageLoad- PRSecurity.js", ex);
        $(".error").text("An Error has occured contact Admin");
    }
    return "";
}

function pr_dialogfunction(pageUrl) {
    window.open(pageUrl);
    //var options = { url: pageUrl, width: 800, height: 600 };
    //SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
}

