<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Web.UI" TagPrefix="telerik" Namespace="Telerik.Web.UI" %>

<asp:Label runat="server" ID="titleLabel" CssClass="sfTxtLbl" Text="title label" AssociatedControlID="radCaptcha" />
<div class="sfFieldWrp">
     <sf:SitefinityLabel runat="server" ID="descriptionLabel" WrapperTagName="div" CssClass="sfDescription" visible="false"/>
    <sf:SitefinityLabel runat="server" ID="exampleLabel" WrapperTagName="div" CssClass="sfExample" visible="false"/>
    <telerik:RadCaptcha runat="server" ID="radCaptcha" />
</div>