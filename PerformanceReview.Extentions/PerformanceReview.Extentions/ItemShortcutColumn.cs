using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceReview.Extentions
{
    public class ItemShortcutColumn : SPFieldText
    {

                // The solution deploys the JavaScript 
        // file to the CSRAssets folder 
        // in the WFE's layouts folder.
        private const string JSLinkUrl =
            "~site/_layouts/15/PerformanceReview.Extentions/Js/PR_ItemShortcut.js";

        // You have to provide constructors for SPFieldText.
        public ItemShortcutColumn(
            SPFieldCollection fields, 
            string name) :
            base(fields, name)
        {

        }

        public ItemShortcutColumn(
            SPFieldCollection fields, 
            string typename, 
            string name) :
            base(fields, typename, name)
        {

        }

        /// <summary>
        /// Override the JSLink property to return the 
        /// value of our custom JavaScript file.
        /// </summary>
        public override string JSLink
        {
            get
            {
                return JSLinkUrl;
            }
            set
            {
                base.JSLink = value;
            }
        }

    }
}
