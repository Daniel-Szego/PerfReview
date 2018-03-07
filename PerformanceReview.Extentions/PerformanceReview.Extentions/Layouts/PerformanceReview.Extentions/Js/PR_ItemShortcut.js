(function () {
    var ItemShortcutContext = {};

    // You can provide templates for:
    // View, DisplayForm, EditForm and NewForm
    ItemShortcutContext.Templates = {};
    ItemShortcutContext.Templates.Fields = {
        "Link": {
            "View": ItemShortcutTemplate
        }
    };

    SPClientTemplates.TemplateManager.RegisterTemplateOverrides(
        ItemShortcutContext
        );
})();

// The favoriteColorViewTemplate provides the rendering logic
// the custom field type when it is displayed in the view form.
function ItemShortcutTemplate(ctx) {
    try {

        var urlArchive;
        var urlArmServer;
        var item = ctx.CurrentItem;
        var name = item[ctx.CurrentFieldSchema.Name];
        var listTitle = ctx.ListTitle;
        var itemId = item.ID;
        var displayformurl = ctx.displayFormUrl;
        var url = " ".concat(displayformurl).concat("&ID=").concat(itemId);
        
        var htmlToReturn = "<div><a href=\"#\" id=\"pr_shortcut" + itemId + "\" onclick=\"pr_dialogfunction(\'" + url + "\')\">Go to Item</a></div>";
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



