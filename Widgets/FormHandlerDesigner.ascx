<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sfFields" Namespace="Telerik.Sitefinity.Web.UI.Fields" %>

<style>
   .ErrorControl
	{
		color: #E93333;
	}
</style>

<sitefinity:ResourceLinks ID="resourcesLinks" runat="server">
	<sitefinity:ResourceFile Name="Styles/Ajax.css" />
	<sitefinity:ResourceFile Name="Styles/Grid.css" />
	<sitefinity:ResourceFile Name="Styles/ToolBar.css" />
	<sitefinity:ResourceFile Name="Styles/jQuery/jquery.ui.core.css" />
	<sitefinity:ResourceFile Name="Styles/jQuery/jquery.ui.dialog.css" />
	<sitefinity:ResourceFile Name="Styles/jQuery/jquery.ui.theme.sitefinity.css" />
</sitefinity:ResourceLinks>

	<div id="formSelectPageSelect">
		<div id="formSelectExp" class="sfExpandableSection sfExpandedSection">
			<h3><a id="expanderFormSelect" href="javascript:void(0);" class="sfMoreDetails">Select a form</a></h3>
			<br />
			<ul class="sfTargetList">
				<li class="sfFormCtrl">
					<sitefinity:FlatSelector id="itemSelector" runat="server"
						ItemType="Telerik.Sitefinity.Forms.Model.FormDescription"
						ItemsFilter="Visible == true AND Status == Live"
						DataKeyNames="Id"
						ShowSelectedFilter="false"
						AllowPaging="false"
						PageSize="10"
						AllowSearching="false"
						ShowProvidersList="false"
						InclueAllProvidersOption="false"
						ServiceUrl="~/Sitefinity/Services/Forms/FormsService.svc">
					</sitefinity:FlatSelector>
				</li>
			</ul>
		</div>
	</div>

	<div id="emailSettingPageSelect">
		<div id="emailSettingsExp" class="sfExpandableSection">
			<h3><a id="expanderEmailSettings" href="javascript:void(0);" class="sfMoreDetails">E-mail options</a></h3>
			<br />
			<ul class="sfTargetList">
					  
				<li class="sfFormCtrl">
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ToEmailAddresses" runat="server" EnableClientScript="true" Enabled="true" ErrorMessage="To e-mail addresses is a required field" SetFocusOnError="true" CssClass="ErrorControl" Display="Dynamic"></asp:RequiredFieldValidator>
					<asp:Label runat="server" AssociatedControlID="ToEmailAddresses" CssClass="sfTxtLbl">To e-mail addresses</asp:Label>
					<asp:TextBox ID="ToEmailAddresses" runat="server" CausesValidation="true" CssClass="sfTxt" />
					<div class="sfExample">Addresses to which the submitted form data will be send. <br /> (seperate multiple addresses with ',' or ';')</div>
				</li>
	
				<li class="sfFormCtrl">
					<asp:Label runat="server" AssociatedControlID="CcEmailAddresses" CssClass="sfTxtLbl">CC e-mail addresses</asp:Label>
					<asp:TextBox ID="CcEmailAddresses" runat="server" CssClass="sfTxt" />
					<div class="sfExample"> CC Addresses to which the submitted form data will be send. <br /> (seperate multiple addresses with ',' or ';')</div>
				</li>
	
				<li class="sfFormCtrl">
					<asp:Label runat="server" AssociatedControlID="FromEmailAddress" CssClass="sfTxtLbl">From e-mail address</asp:Label>
					<asp:TextBox ID="FromEmailAddress" runat="server" CssClass="sfTxt" />
					<div class="sfExample">From e-mail address</div>
				</li>
			</ul>
		</div>
	</div>
	<div id="emailTemplatePageSelect">
		<div id="emailTemplateExp" class="sfExpandableSection">
			<h3><a id="expanderEmailTemplate" href="javascript:void(0);" class="sfMoreDetails">E-mail template</a></h3>
			<br />
			<ul class="sfTargetList">

				<li class="sfFormCtrl">
					<asp:Label runat="server" AssociatedControlID="EmailSubject" CssClass="sfTxtLbl">E-mail subject</asp:Label>
					<asp:TextBox ID="EmailSubject" runat="server" CssClass="sfTxt" />
					<div class="sfExample">E-mail subject</div>
				</li>

				 <li class="sfFormCtrl">
					<asp:Label runat="server" AssociatedControlID="MailUploadedFilesAsAttachments" CssClass="sfTxtLbl">Send uploaded files as attachments</asp:Label>
					<asp:CheckBox ID="MailUploadedFilesAsAttachments" runat="server" CssClass="sfTxt" />
					<div class="sfExample">Indicates if the files uploaded by the user are send as attachments.</div>
				</li>
	
				<li class="sfFormCtrl">
					 <br/>
					<asp:Label runat="server" AssociatedControlID="EmailBody" CssClass="sfTxtLbl">E-mail body</asp:Label>
					<asp:TextBox ID="EmailBody" Rows="20" TextMode="MultiLine" runat="server" CssClass="sfTxt" />
					<div class="sfExample">E-mail body text, use #FormData# to include the submitted form data of the user.</div>
				</li>

			   
				<li class="sfFormCtrl"> 
					 <br/>
					<asp:Label ID="Label1" runat="server" AssociatedControlID="EmailBodyHTML" CssClass="sfTxtLbl">E-mail HTML body</asp:Label>
					<sfFields:HtmlField
						ID="EmailBodyHTML"
						runat="server"
						Width="99%"
						Height="370px" 
						>
					</sfFields:HtmlField>
					<div class="sfExample">E-mail HTML body text, use #FormData# to include the submitted form data of the user.</div>
				</li>
			</ul>
		</div>
	</div>
	<div id="clientEmailSettingPageSelect">
		<div id="clientEmailSettingsExp" class="sfExpandableSection">
			<h3><a id="expanderClientEmailSettings" href="javascript:void(0);" class="sfMoreDetails">Client e-mail options</a></h3>
			<br />
			<ul class="sfTargetList">
				<li class="sfFormCtrl">
					<asp:Label runat="server" AssociatedControlID="SendClientConfirmation" CssClass="sfTxtLbl">Send confirmation e-mail to client</asp:Label>
					<asp:CheckBox ID="SendClientConfirmation" runat="server" CssClass="sfTxt" />
					<div class="sfExample">Indicates if a confirmation mail will be send to the client (ie. the user that submitted the form)</div>
				</li>
  
				<li class="sfFormCtrl">
					<asp:Label runat="server" AssociatedControlID="ClientConfirmationEmailAddressFormControlName" CssClass="sfTxtLbl">Client e-mail address form control name</asp:Label>
					<asp:TextBox ID="ClientConfirmationEmailAddressFormControlName" runat="server" CausesValidation="true" CssClass="sfTxt" />
					<div class="sfExample">Name of the control that holds the client's e-mail address ("Name for developers"). To this address, the confirmation mail will be send.</div>
				</li>

				<li class="sfFormCtrl">
					<asp:Label runat="server" AssociatedControlID="ClientConfirmationControlName" CssClass="sfTxtLbl">Form control name for client confirmation</asp:Label>
					<asp:TextBox ID="ClientConfirmationControlName" runat="server" CausesValidation="true" CssClass="sfTxt" />
					<div class="sfExample">Name of the control that indicates if client's confirmation mail will be send.</div>
				</li>

					<li class="sfFormCtrl">
					<asp:Label runat="server" AssociatedControlID="ClientConfirmationControlSendOptionValue" CssClass="sfTxtLbl">Form control value for client confirmation</asp:Label>
					<asp:TextBox ID="ClientConfirmationControlSendOptionValue" runat="server" CausesValidation="true" CssClass="sfTxt" />
					<div class="sfExample">The value of the control that indicates if client's confirmation mail will be send.</div>
				</li>
	
				<li class="sfFormCtrl">
					<asp:Label runat="server" AssociatedControlID="ClientCcEmailAddresses" CssClass="sfTxtLbl">CC e-mail addresses client e-mail</asp:Label>
					<asp:TextBox ID="ClientCcEmailAddresses" runat="server" CssClass="sfTxt" />
					<div class="sfExample">CC addresses to which the client confirmation mail will be send. <br /> (seperate multiple addresses with ',' or ';')</div>
				</li>
	
				<li class="sfFormCtrl">
					<asp:Label runat="server" AssociatedControlID="ClientFromEmailAddress" CssClass="sfTxtLbl">From e-mail address client e-mail</asp:Label>
					<asp:TextBox ID="ClientFromEmailAddress" runat="server" CssClass="sfTxt" />
					<div class="sfExample">From e-mail address from which the client confirmation e-mail will be send</div>
				</li>

				 <li class="sfFormCtrl">
					<asp:Label runat="server" AssociatedControlID="IsClientEmailAddressUsedAsFromEmailAddress" CssClass="sfTxtLbl">Use client e-mail address as "from" address to administrator </asp:Label>
					<asp:CheckBox ID="IsClientEmailAddressUsedAsFromEmailAddress" runat="server" CssClass="sfTxt" />
					<div class="sfExample">Indicates whether the client's e-mail address is used as sender address for the e-mail that will be sent to the administrator.</div>
				</li>

			</ul>
		</div>
	</div>
	<div id="clientEmailTemplatePageSelect">
		<div id="clientEmailTemplateExp" class="sfExpandableSection">
			<h3><a id="expanderClientEmailTemplate" href="javascript:void(0);" class="sfMoreDetails">Client e-mail template</a></h3>
			<br />
			<ul class="sfTargetList">
				<li class="sfFormCtrl">
					<asp:Label runat="server" AssociatedControlID="ClientEmailSubject" CssClass="sfTxtLbl">Client e-mail subject</asp:Label>
					<asp:TextBox ID="ClientEmailSubject" runat="server" CssClass="sfTxt" />
					<div class="sfExample">E-mail subject for mail to client</div>
				</li>

				<li class="sfFormCtrl">
					 <br/>
					<asp:Label runat="server" AssociatedControlID="ClientEmailBody" CssClass="sfTxtLbl">Client e-mail body</asp:Label>
					<asp:TextBox ID="ClientEmailBody" Rows="20" TextMode="MultiLine" runat="server" CssClass="sfTxt" />
					<div class="sfExample">E-mail body text for mail to client. Use #FormData# to include the submitted form data of the user.</div>
				</li>
			   
				<li class="sfFormCtrl"> 
					 <br/>
					<asp:Label runat="server" AssociatedControlID="ClientEmailBodyHTML" CssClass="sfTxtLbl">Client e-mail HTML body</asp:Label>
					<sfFields:HtmlField
						ID="ClientEmailBodyHTML"
						runat="server"
						Width="99%"
						Height="370px" 
						>
					</sfFields:HtmlField>
					<div class="sfExample">E-mail HTML body text for mail to client. Use #FormData# to include the submitted form data of the user.</div>
				</li>
			</ul>
		</div>
	</div>
	<div id="redirectPageSelect">
		<div id="redirectPageExp" class="sfExpandableSection">
			<h3><a id="expanderRedirectPage" href="javascript:void(0);" class="sfMoreDetails">Redirect page</a></h3>
			<br />
			<ul class="sfTargetList">        
				<li class="sfFormCtrl">
				<label class="sfTxtLbl" for="selectedRedirectPageLabel">Redirect page</label>
				<span style="display: none;" class="sfSelectedItem" id="selectedRedirectPageLabel">
					<asp:Literal runat="server" Text="" />
				</span>
				<span class="sfLinkBtn sfChange">
					<a href="javascript: void(0)" class="sfLinkBtnIn" id="pageSelectButtonRedirectPage">
						<asp:Literal runat="server" Text="<%$Resources:Labels, SelectDotDotDot %>" />
					</a>
				</span>
				<div id="selectorTagRedirectPage" runat="server" style="display: none;">
					<sf:PagesSelector runat="server" ID="pageSelectorRedirectPage" 
						AllowExternalPagesSelection="false" AllowMultipleSelection="false" />
				</div>
				<div class="sfExample"></div>
				</li>
			</ul>
		</div>
	</div>


