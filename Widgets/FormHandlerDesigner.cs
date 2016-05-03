using System;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using System.Collections.Generic;
using Telerik.Sitefinity.Web.UI.Fields;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

[assembly: WebResource(Fenetre.Sitefinity.FormHandler.FormHandlerDesigner.scriptReference, "application/x-javascript")]
namespace Fenetre.Sitefinity.FormHandler
{
	/// <summary>
	/// Represents a designer for the <typeparamref name="Fenetre.Sitefinity.FormHandler.FormHandler"/> widget
	/// </summary>
	public class FormHandlerDesigner : ControlDesignerBase
	{
		#region Properties
		/// <summary>
		/// Gets the layout template path
		/// </summary>
		public override string LayoutTemplatePath
		{
			get
			{
				return String.Empty;
			}
		}


		/// <summary>
		/// Gets a reference to the form selector
		/// </summary>
		public FlatSelector GridSelector
		{
		  get { return this.Container.GetControl<FlatSelector>("itemSelector", true, TraverseMethod.DepthFirst); }
		}

		/// <summary>
		/// Gets the layout template name
		/// </summary>
		protected override string LayoutTemplateName
		{
			get
			{
				return FormHandlerDesigner.layoutTemplateName;
			}
		}

		protected override HtmlTextWriterTag TagKey
		{
			get
			{
				return HtmlTextWriterTag.Div;
			}
		}
		#endregion

		#region Control references
		/// <summary>
		/// Gets the control that is bound to the ToEmailAddresses property
		/// </summary>
		protected virtual Control ToEmailAddresses
		{
			get
			{
				return this.Container.GetControl<Control>("ToEmailAddresses", true);
			}
		}

		/// <summary>
		/// Gets the control that is bound to the CcEmailAddresses property
		/// </summary>
		protected virtual Control CcEmailAddresses
		{
			get
			{
				return this.Container.GetControl<Control>("CcEmailAddresses", true);
			}
		}

		/// <summary>
		/// Gets the control that is bound to the FromEmailAddress property
		/// </summary>
		protected virtual Control FromEmailAddress
		{
			get
			{
				return this.Container.GetControl<Control>("FromEmailAddress", true);
			}
		}

		/// <summary>
		/// Gets the control that is bound to the EmailSubject property
		/// </summary>
		protected virtual Control EmailSubject
		{
			get
			{
				return this.Container.GetControl<Control>("EmailSubject", true);
			}
		}

		/// <summary>
		/// Gets the control that is bound to the EmailBody property
		/// </summary>
		protected virtual Control EmailBody
		{
			get
			{
				return this.Container.GetControl<Control>("EmailBody", true);
			}
		}

		/// <summary>
		/// Gets the control that is bound to the EmailBodyHTML property
		/// </summary>
		protected virtual HtmlField EmailBodyHTML
		{
		  get
		  {
			return this.Container.GetControl<HtmlField>("EmailBodyHTML", true);
		  }
		}


		/// <summary>
		/// Gets the control that is bound to the MailUploadedFilesAsAttachments property
		/// </summary>
		protected virtual Control MailUploadedFilesAsAttachments
		{
		  get
		  {
			return this.Container.GetControl<Control>("MailUploadedFilesAsAttachments", true);
		  }
		}

		/// <summary>
		/// Gets the control that is bound to the ClientCcEmailAddresses property
		/// </summary>
		protected virtual Control ClientCcEmailAddresses
		{
			get
			{
				return this.Container.GetControl<Control>("ClientCcEmailAddresses", true);
			}
		}

		/// <summary>
		/// Gets the control that is bound to the ClientFromEmailAddress property
		/// </summary>
		protected virtual Control ClientFromEmailAddress
		{
			get
			{
				return this.Container.GetControl<Control>("ClientFromEmailAddress", true);
			}
		}

		/// <summary>
		/// Gets the control that is bound to the EmailSubject property
		/// </summary>
		protected virtual Control ClientEmailSubject
		{
			get
			{
				return this.Container.GetControl<Control>("ClientEmailSubject", true);
			}
		}

		/// <summary>
		/// Gets the control that is bound to the ClientEmailBody property
		/// </summary>
		protected virtual Control ClientEmailBody
		{
			get
			{
				return this.Container.GetControl<Control>("ClientEmailBody", true);
			}
		}

		/// <summary>
		/// Gets the control that is bound to the ClientEmailBodyHTML property
		/// </summary>
		protected virtual HtmlField ClientEmailBodyHTML
		{
			get
			{
				return this.Container.GetControl<HtmlField>("ClientEmailBodyHTML", true);
			}
		}

		/// <summary>
		/// Gets the control that is bound to the ClientConfirmationEmailAddressFormControlName property
		/// </summary>
		protected virtual Control ClientConfirmationEmailAddressFormControlName
		{
			get
			{
				return this.Container.GetControl<Control>("ClientConfirmationEmailAddressFormControlName", true);
			}
		}

		/// <summary>
		/// Gets the control that is bound to the ClientConfirmationControlName property
		/// </summary>
		protected virtual Control ClientConfirmationControlName
		{
			get
			{
				return this.Container.GetControl<Control>("ClientConfirmationControlName", true);
			}
		}

		/// <summary>
		/// Gets the control that is bound to the ClientConfirmationEmailAddressFormControlName property
		/// </summary>
		protected virtual Control ClientConfirmationControlSendOptionValue
		{
			get
			{
				return this.Container.GetControl<Control>("ClientConfirmationControlSendOptionValue", true);
			}
		}

		/// <summary>
		/// Gets the control that is bound to the SendClientConfirmation property
		/// </summary>
		protected virtual Control SendClientConfirmation
		{
			get
			{
				return this.Container.GetControl<Control>("SendClientConfirmation", true);
			}
		}

		/// <summary>
		/// Gets the control that is bound to the IsClientEmailAddressUsedAsFromEmailAddress property
		/// </summary>
		protected virtual Control IsClientEmailAddressUsedAsFromEmailAddress
		{
			get
			{
				return this.Container.GetControl<Control>("IsClientEmailAddressUsedAsFromEmailAddress", true);
			}
		}
		
        /// <summary>
		/// Gets the page selector control.
		/// </summary>
		/// <value>The page selector control.</value>
		protected internal virtual PagesSelector PageSelectorRedirectPage
		{
			get
			{
				return this.Container.GetControl<PagesSelector>("pageSelectorRedirectPage", true);
			}
		}

		/// <summary>
		/// Gets the selector tag.
		/// </summary>
		/// <value>The selector tag.</value>
		public HtmlGenericControl SelectorTagRedirectPage
		{
			get
			{
				return this.Container.GetControl<HtmlGenericControl>("selectorTagRedirectPage", true);
			}
		}
		#endregion

		#region Methods
        /// <summary>
        /// Initializes the designer.
        /// </summary>
        /// <param name="container"> 
        ///     Represents base implementation for template container. Template containers
        ///     are controls that are used as containers for other controls defined through
        ///     control templates (ITemplate).
        /// </param>
		protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
		{
		  EmailBodyHTML.DisplayMode = Telerik.Sitefinity.Web.UI.Fields.Enums.FieldDisplayMode.Write;
		  EmailBodyHTML.FixCursorIssue = true;
		  ClientEmailBodyHTML.DisplayMode = Telerik.Sitefinity.Web.UI.Fields.Enums.FieldDisplayMode.Write;
		  ClientEmailBodyHTML.FixCursorIssue = true;

		  GridSelector.DataMembers.Clear();

		  var item = new DataMemberInfo
		  {
			Name = "Title",
			HeaderText = "Title",
			ColumnTemplate = " <strong>{{Title}}</strong>",
			IsSearchField = true
		  };

		  GridSelector.DataMembers.Add(item);
		  GridSelector.ShowHeader = false;
		  GridSelector.ShowSelectedFilter = false;
		  GridSelector.BindOnLoad = true;

		  if (this.PropertyEditor != null)
		  {
			  var uiCulture = this.PropertyEditor.PropertyValuesCulture;
			  this.PageSelectorRedirectPage.UICulture = uiCulture;
		  }

		  this.DesignerMode = ControlDesignerModes.Simple;
		}

		#endregion

		#region IScriptControl implementation
		/// <summary>
		/// Gets a collection of script descriptors that represent ECMAScript (JavaScript) client components.
		/// </summary>
		public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptDescriptor> GetScriptDescriptors()
		{
			var scriptDescriptors = new List<ScriptDescriptor>(base.GetScriptDescriptors());
			var descriptor = (ScriptControlDescriptor)scriptDescriptors.Last();

			descriptor.AddElementProperty("toEmailAddresses", this.ToEmailAddresses.ClientID);
			descriptor.AddElementProperty("ccEmailAddresses", this.CcEmailAddresses.ClientID);
			descriptor.AddElementProperty("fromEmailAddress", this.FromEmailAddress.ClientID);
			descriptor.AddElementProperty("emailSubject", this.EmailSubject.ClientID);
			descriptor.AddElementProperty("emailBody", this.EmailBody.ClientID);
			descriptor.AddElementProperty("emailBodyHTML", this.EmailBodyHTML.ClientID);
			descriptor.AddElementProperty("mailUploadedFilesAsAttachments", this.MailUploadedFilesAsAttachments.ClientID);
			descriptor.AddElementProperty("clientCcEmailAddresses", this.ClientCcEmailAddresses.ClientID);
			descriptor.AddElementProperty("clientFromEmailAddress", this.ClientFromEmailAddress.ClientID);
			descriptor.AddElementProperty("clientEmailSubject", this.ClientEmailSubject.ClientID);
			descriptor.AddElementProperty("clientEmailBody", this.ClientEmailBody.ClientID);
			descriptor.AddElementProperty("clientEmailBodyHTML", this.ClientEmailBodyHTML.ClientID);
			descriptor.AddElementProperty("clientConfirmationEmailAddressFormControlName", this.ClientConfirmationEmailAddressFormControlName.ClientID);
			descriptor.AddElementProperty("clientConfirmationControlName", this.ClientConfirmationControlName.ClientID);
			descriptor.AddElementProperty("clientConfirmationControlSendOptionValue", this.ClientConfirmationControlSendOptionValue.ClientID);

			descriptor.AddElementProperty("sendClientConfirmation", this.SendClientConfirmation.ClientID);
			descriptor.AddElementProperty("isClientEmailAddressUsedAsFromEmailAddress", this.IsClientEmailAddressUsedAsFromEmailAddress.ClientID);
			descriptor.AddComponentProperty("gridSelector", this.GridSelector.ClientID);
            descriptor.AddComponentProperty("pageSelectorRedirectPage", this.PageSelectorRedirectPage.ClientID);
			descriptor.AddElementProperty("selectorTagRedirectPage", this.SelectorTagRedirectPage.ClientID);

			return scriptDescriptors;
		}

		/// <summary>
		/// Gets a collection of ScriptReference objects that define script resources that the control requires.
		/// </summary>
		public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
		{
			var scripts = new List<ScriptReference>(base.GetScriptReferences());
			scripts.Add(new ScriptReference(FormHandlerDesigner.scriptReference, typeof(FormHandlerDesigner).Assembly.FullName));
			return scripts;
		}
		#endregion

		#region Private members & constants
		//public static readonly string layoutTemplatePath = "~/FenetreSitefinityFormHandler/Fenetre.Sitefinity.FormHandler.FormHandlerDesigner.ascx";
		public static readonly string layoutTemplateName = "Fenetre.Sitefinity.FormHandler.Widgets.FormHandlerDesigner.ascx";
		public const string scriptReference = "Fenetre.Sitefinity.FormHandler.Widgets.FormHandlerDesigner.js";
		#endregion
	}
}
 
