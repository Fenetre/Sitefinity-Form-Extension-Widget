<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sfFields" Namespace="Telerik.Sitefinity.Web.UI.Fields" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Modules.Forms.Web.UI.Fields" TagPrefix="sfForms" %>

<sitefinity:ResourceLinks ID="resourcesLinks" runat="server">
    <sitefinity:ResourceFile Name="Styles/Ajax.css" />
</sitefinity:ResourceLinks>
<div class="sfContentViews sfSingleContentView" style="max-height: 400px; overflow: auto; ">
<ol>        
    <li class="sfFormCtrl">
    <asp:Label runat="server" AssociatedControlID="Title" CssClass="sfTxtLbl">Title</asp:Label>
    <asp:TextBox ID="Title" runat="server" CssClass="sfTxt" />
    <div class="sfExample">Title shown above the captcha field</div>
    </li>
    
    <li class="sfFormCtrl">
    <asp:Label runat="server" AssociatedControlID="Description" CssClass="sfTxtLbl">Description</asp:Label>
    <asp:TextBox ID="Description" runat="server" CssClass="sfTxt" />
    <div class="sfExample">Description for captcha field</div>
    </li>
    
    <li class="sfFormCtrl">
    <asp:Label runat="server" AssociatedControlID="ErrorMessage" CssClass="sfTxtLbl">Error message</asp:Label>
    <asp:TextBox ID="ErrorMessage" runat="server" CssClass="sfTxt" />
    <div class="sfExample">Error message shown if invalid code submitted</div>
    </li>

    <li class="sfFormCtrl">
    <asp:Label runat="server" AssociatedControlID="Example" CssClass="sfTxtLbl" Visible="false">Example</asp:Label>
    <asp:TextBox ID="Example" runat="server" CssClass="sfTxt" Visible="false" />
    <div class="sfExample" style="display:none;">An example of a valid value</div>
    </li>
    
</ol>
<sfForms:MetaFieldNameTextBox runat="server" id="metaFieldNameTextBox"></sfForms:MetaFieldNameTextBox>
</div>
