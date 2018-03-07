<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LetterGeneration.ascx.cs" Inherits="PerformanceReview.VisualWebparts.LetterGeneration.LetterGeneration" %>


<asp:Label ID="lblMsg" runat="server" Text="" EnableViewState="false"></asp:Label>
 <div id="dvSource" runat="server">     
    <table >
        <tr>
            <td>
                <asp:FileUpload ID="fileupload" runat="server" />
                <asp:RegularExpressionValidator ID="regFileUpload" ControlToValidate="fileupload" ErrorMessage="The file is not a valid One" ForeColor="Red" ValidationExpression="^.*\.(XLSX|xlsx)$" runat="server"></asp:RegularExpressionValidator>            
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnupload" runat="server" Text="UploadExcel" OnClick="btnUpload_Click" />
            </td>
        </tr>
    </table>   
</div>