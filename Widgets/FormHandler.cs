using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Forms.Model;
using Telerik.Sitefinity.Modules.Forms;
using Telerik.Sitefinity.Modules.Forms.Events;
using Telerik.Sitefinity.Modules.Forms.Web.UI.Fields;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web.UI.Fields;

namespace Fenetre.Sitefinity.FormHandler
{
    /// <summary>
    /// This class is used to create and save forms and to send the e-mail messages associated with them.
    /// </summary>
	[Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(Fenetre.Sitefinity.FormHandler.FormHandlerDesigner))]
	public class FormHandler : Telerik.Sitefinity.Modules.Forms.Web.UI.FormsControl
	{
		#region Private properties

		private string toEmailAddresses;
		private string ccEmailAddresses;
		private string fromEmailAddress;
		private string clientEmailAddress;
		private string emailSubject;
		private string emailBody;
		private string emailBodyHTML;
		private bool mailUploadedFilesAsAttachments = true;
		private bool sendClientConfirmation = false;

		private string clientConfirmationEmailAddressFormControlName;
		private string clientConfirmationControlName;
		private string clientConfirmationControlSendOptionValue;

		private string clientEmailSubject;
		private string clientEmailBody;
		private string clientEmailBodyHTML;
		private string clientCcEmailAddresses;
		private string clientFromEmailAddress;
		private string referrerUrlSessionKey;
		private bool isClientEmailAddressUsedAsFromEmailAddress = false;

		private const string SUBMITTED_FORM_DATA_STRING_TAG = "#FormData#";
		private const string REFERRER_URL_TAG = "#ReferrerUrl#";

		private Guid redirectPage;
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the FormHandler class.
		/// </summary>
		public FormHandler()
		{
		}

		#endregion

		#region Public properties
        /// <summary>
        /// The subject of the message.
        /// </summary>
		public string EmailSubject
		{
			get
			{
				return emailSubject;
			}

			set
			{
				emailSubject = value;
			}
		}

        /// <summary>
        /// The body of the message.
        /// </summary>
		public string EmailBody
		{
			get
			{
				return emailBody;
			}

			set
			{
				emailBody = value;
			}
		}

        /// <summary>
        /// The body of the message using HTML markup for the layout.
        /// </summary>
		public string EmailBodyHTML
		{
			get
			{
				return emailBodyHTML;
			}

			set
			{
				emailBodyHTML = value;
			}
		}

        /// <summary>
        /// The addressess the message will be sent to.
        /// </summary>
		public string ToEmailAddresses
		{
			get
			{
				return toEmailAddresses;
			}

			set
			{
				toEmailAddresses = value;
			}
		}

        /// <summary>
        /// The addresses the message will be carbon copied to.
        /// </summary>
		public string CcEmailAddresses
		{
			get
			{
				return ccEmailAddresses;
			}

			set
			{
				ccEmailAddresses = value;
			}
		}

        /// <summary>
        /// The addresses the message will be sent from.
        /// </summary>
		public string FromEmailAddress
		{
			get
			{
				return fromEmailAddress;
			}

			set
			{
				fromEmailAddress = value;
			}
		}

        /// <summary>
        /// The attachments of the message.
        /// </summary>
		[DefaultValue(true)]
		public bool MailUploadedFilesAsAttachments
		{
			get
			{
				return mailUploadedFilesAsAttachments;
			}

			set
			{
				mailUploadedFilesAsAttachments = value;
			}
		}

        /// <summary>
        /// A boolean stating whether the client receives a 
        /// confirmation of their submitted form.
        /// </summary>
		public bool SendClientConfirmation
		{
			get
			{
				return sendClientConfirmation;
			}
			set
			{
				sendClientConfirmation = value;
			}
		}

        /// <summary>
        /// The name of the control that holds the address the confirmation
        /// message will be sent to.
        /// </summary>
		public string ClientConfirmationEmailAddressFormControlName
		{
			get
			{
				return clientConfirmationEmailAddressFormControlName;
			}
			set
			{
				clientConfirmationEmailAddressFormControlName = value;
			}
		}

        /// <summary>
        /// The name of the control that indicates whether the client wishes
        /// to receive a confirmation message.
        /// </summary>
		public string ClientConfirmationControlName
		{
			get
			{
				return clientConfirmationControlName;
			}
			set
			{
				clientConfirmationControlName = value;
			}
		}

        /// <summary>
        /// The value of the control that indicates whether the client wishes
        /// to receive a confirmation message.
        /// </summary>
		public string ClientConfirmationControlSendOptionValue
		{
			get
			{
				return clientConfirmationControlSendOptionValue;
			}
			set
			{
				clientConfirmationControlSendOptionValue = value;
			}
		}

        /// <summary>
        /// Subject of the confirmation message.
        /// </summary>
		public string ClientEmailSubject
		{
			get
			{
				return clientEmailSubject;
			}

			set
			{
				clientEmailSubject = value;
			}
		}

        /// <summary>
        /// Body of the confirmation message.
        /// </summary>
		public string ClientEmailBody
		{
			get
			{
				return clientEmailBody;
			}

			set
			{
				clientEmailBody = value;
			}
		}

        /// <summary>
        /// Body of the confirmation message using
        /// HTML markup for the layout.
        /// </summary>
		public string ClientEmailBodyHTML
		{
			get
			{
				return clientEmailBodyHTML;
			}

			set
			{
				clientEmailBodyHTML = value;
			}
		}

        /// <summary>
        /// The addresses the confirmation message will
        /// be carbon copied to.
        /// </summary>
		public string ClientCcEmailAddresses
		{
			get
			{
				return clientCcEmailAddresses;
			}

			set
			{
				clientCcEmailAddresses = value;
			}
		}

        /// <summary>
        /// The address the confirmation message will be sent from.
        /// </summary>
		public string ClientFromEmailAddress
		{
			get
			{
				return clientFromEmailAddress;
			}

			set
			{
				clientFromEmailAddress = value;
			}
		}

        /// <summary>
        /// A boolean stating whether the message sent to the
        /// administrator will hold the client's e-mail address as
        /// from address
        /// </summary>
		public bool IsClientEmailAddressUsedAsFromEmailAddress
		{
			get
			{
				return isClientEmailAddressUsedAsFromEmailAddress;
			}
			set
			{
				isClientEmailAddressUsedAsFromEmailAddress = value;
			}
		}

        /// <summary>
        /// 
        /// </summary>
		public string ReferrerUrlSessionKey
		{
			get
			{
				return referrerUrlSessionKey;
			}
			set
			{
				referrerUrlSessionKey = value;
			}
		}

        /// <summary>
        /// The page the client gets redirected to after submitting the form
        /// </summary>
        public Guid RedirectPage
		{
			get
			{
				return redirectPage;
			}
			set
			{
				redirectPage = value;
			}
		}

		#endregion

		#region Initialize

		/// <summary>
		/// Configures the submit button.
		/// </summary>
		/// <param name="control">The submit control.</param>
		/// <param name="validationGroup">The validation group.</param>
		protected override void ConfigureSubmitButton(System.Web.UI.Control control, string validationGroup)
		{
			var submit = control as FormSubmitButton;
			submit.Click += new EventHandler(submit_Click);
			base.ConfigureSubmitButton(control, validationGroup);
			EventHub.Subscribe<FormSavedEvent>(FormHandler_FormSaved);
		}

		#endregion

		#region Eventhandlers

        /// <summary>
        /// Evemthandler that handles the submit action. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void FormHandler_FormSaved(IFormEvent eventInfo)
		{
			FormsManager manager = FormsManager.GetManager();
			var form = manager.GetForm(eventInfo.FormId);
			if (form.SubmitAction != SubmitAction.PageRedirect)
			{
				if (form.SubmitAction == SubmitAction.TextMessage && !string.IsNullOrEmpty(form.SuccessMessage))
				{
					if (this.SuccessMessageLabel.Style["display"] == "none")
					{
						this.SuccessMessageLabel.Style.Remove("display");
					}
				}
			}
			else
			{
				if (this.RedirectPage != null && this.RedirectPage != Guid.Empty)
				{
					PageNode pageNode = App.WorkWith().Page(RedirectPage).Get();
					var url = Telerik.Sitefinity.Modules.Pages.PageExtesnsions.GetFullUrl(pageNode, Thread.CurrentThread.CurrentCulture, false, true); //.ToLowerInvariant().Replace("~/", String.Empty);
					this.Page.Response.Redirect(url);
				}
			}
		}

        /// <summary>
        /// Eventhandler that handles form validation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void submit_Click(object sender, EventArgs e)
		{
			if (FieldControls.Where(o => !o.IsValid()).Count() == 0)
			{
				SendSubmittedFormDataEmail();
			}
			else
			{
				var invalidControl = FieldControls.Where(o => !o.IsValid()).FirstOrDefault();

				if (invalidControl is FieldControl)
				{
					Page.SetFocus(((FieldControl)invalidControl).ClientID);
				}
				else if (invalidControl is FormCaptcha)
				{
					Page.SetFocus(((FormCaptcha)invalidControl).ClientID);
				}
				else if (invalidControl is FormCheckboxes)
				{
					Page.SetFocus(((FormCheckboxes)invalidControl).ClientID);
				}
			}
		}

		#endregion

		#region Methods

        /// <summary>
        /// Method that builds and sends confirmation messages to the administrator and, 
        /// if <see cref="SendClientConfirmation"/> is true, the client too.
        /// </summary>
		private void SendSubmittedFormDataEmail()
		{
			StringBuilder formDataBuilder = new StringBuilder();
			StringBuilder formDataHTMLBuilder = new StringBuilder();

			List<Attachment> attachments = new List<Attachment>();

			foreach (var fieldControl in this.FieldControls)
			{
				if (fieldControl is FormCheckboxes)
				{
					StringBuilder choicesString = new StringBuilder();

					var choices = ((List<String>)((FormCheckboxes)fieldControl).Value).ToList();

					for (int i = 0; i < choices.Count(); i++)
					{
						choicesString.Append(choices[i]);
						if (i != choices.Count() - 1)
						{
							choicesString.Append(", ");
						}
					}

					formDataBuilder.Append(String.Format("{0}: {1}\r\n", ((FormCheckboxes)fieldControl).Title, choicesString.ToString()));
					formDataHTMLBuilder.Append(String.Format("{0}: {1}<br/>", ((FormCheckboxes)fieldControl).Title, choicesString.ToString()));
				}
				else if (fieldControl is FieldControl)
				{
					var control = fieldControl as FieldControl;
					if (MailUploadedFilesAsAttachments && control.Value.GetType().Equals(typeof(Telerik.Web.UI.UploadedFileCollection)))
					{
						Telerik.Web.UI.UploadedFileCollection uploadedFileCollection = (Telerik.Web.UI.UploadedFileCollection)control.Value;
						attachments.AddRange(FormHandlerMail.CreateFormHandlerMailAttachments(uploadedFileCollection));
					}
					else if(fieldControl.GetType() != typeof(FormCaptcha))
					{
						formDataBuilder.Append(String.Format("{0}: {1}\r\n", control.Title, control.Value));
						formDataHTMLBuilder.Append(String.Format("{0}: {1}<br/>", control.Title, control.Value));
					}
				}
			}

			// Try get client e-mailaddress
			if (!String.IsNullOrWhiteSpace(this.ClientConfirmationEmailAddressFormControlName))
			{
				FormTextBox emailFormControl = this.FieldControls.OfType<FormTextBox>().Where(f => f.MetaField.FieldName == this.ClientConfirmationEmailAddressFormControlName).FirstOrDefault();
				if (emailFormControl != null)
				{
					clientEmailAddress = emailFormControl.Value.ToString();
				}
			}

			// Try get client ClientConfirmationControl
			if (!String.IsNullOrWhiteSpace(this.ClientConfirmationControlName) && !String.IsNullOrWhiteSpace(this.clientConfirmationControlSendOptionValue) && SendClientConfirmation)
			{
				FieldControl clientConfirmationControlName = this.FieldControls.OfType<FieldControl>().Where(f => f.DataFieldName == this.ClientConfirmationControlName).FirstOrDefault();

				if (clientConfirmationControlName != null)
				{
					SendClientConfirmation = false;

					if (clientConfirmationControlName is FormCheckboxes)
					{
						var choices = ((List<String>)((FormCheckboxes)clientConfirmationControlName).Value).ToList();
						foreach (var selectedChoices in choices)
						{
							if (selectedChoices.ToUpper().Equals(clientConfirmationControlSendOptionValue.ToUpper()))
							{
								SendClientConfirmation = true;
								break;
							}
						}
					}

					else if (clientConfirmationControlName is FormMultipleChoice)
					{
						if (clientConfirmationControlSendOptionValue.ToUpper().Equals(clientConfirmationControlName.Value.ToString().ToUpper()))
						{
							SendClientConfirmation = true;		
						}
					}
					

				}
			}

			#region Administrator mail
			string bodyText = string.Empty;

			if (!string.IsNullOrWhiteSpace(emailBody))
			{
				bodyText = emailBody.Replace(SUBMITTED_FORM_DATA_STRING_TAG, formDataBuilder.ToString());
			}

			string bodyHTMLText = string.Empty;

			if (!string.IsNullOrWhiteSpace(emailBodyHTML))
			{
				bodyHTMLText = emailBodyHTML.Replace(SUBMITTED_FORM_DATA_STRING_TAG, formDataHTMLBuilder.ToString());
			}
			string actualReferrerUrlSessionKey = !String.IsNullOrWhiteSpace(ReferrerUrlSessionKey) ? ReferrerUrlSessionKey : "REFERRER_URL";
			string referrerUrl = String.Empty;
			if(HttpContext.Current.Session[actualReferrerUrlSessionKey] != null)
			{
				referrerUrl = ((Uri)HttpContext.Current.Session[actualReferrerUrlSessionKey]).ToString();
			}
			bodyHTMLText = bodyHTMLText.Replace(REFERRER_URL_TAG, referrerUrl);

			string fromEmailAddressToUse = !String.IsNullOrWhiteSpace(clientEmailAddress) && IsClientEmailAddressUsedAsFromEmailAddress ? clientEmailAddress : fromEmailAddress;

			FormHandlerMail.SendFormHandlerEmailMessage(fromEmailAddressToUse, ToEmailAddresses, ccEmailAddresses, emailSubject, bodyText, bodyHTMLText, attachments, this.FormName);
			#endregion

			#region Client confirmation
			if (SendClientConfirmation && !String.IsNullOrWhiteSpace(clientEmailAddress))
			{
				string clientBodyText = string.Empty;

				if (!string.IsNullOrWhiteSpace(clientEmailBody))
				{
					clientBodyText = clientEmailBody.Replace(SUBMITTED_FORM_DATA_STRING_TAG, formDataBuilder.ToString());
				}

				string clientBodyHTMLText = string.Empty;

				if (!string.IsNullOrWhiteSpace(clientEmailBodyHTML))
				{
					clientBodyHTMLText = clientEmailBodyHTML.Replace(SUBMITTED_FORM_DATA_STRING_TAG, formDataHTMLBuilder.ToString());
				}

				FormHandlerMail.SendFormHandlerEmailMessage(clientFromEmailAddress, clientEmailAddress, clientCcEmailAddresses, clientEmailSubject, clientBodyText, clientBodyHTMLText, null, this.FormName);
			}
			#endregion
		}

		#endregion

       
		#region Scripts
        /// <summary>
        /// Gets the references to the javascript files.
        /// </summary>
        /// <returns></returns>
        #if !NO_FORMS_CLIENT_SCRIPT
		public override IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
		{
			string assemblyName = typeof(FormHandler).Assembly.FullName;
			var baseScripts = base.GetScriptReferences();
			var all = baseScripts.ToList();
			all.Add(new System.Web.UI.ScriptReference(FormHandler.scriptReference, assemblyName));
			return all;
		}
        #endif

		#endregion

		#region Private members & constants
        
		public const string scriptReference = "Fenetre.Sitefinity.FormHandler.Widgets.FormHandler.js";

		#endregion
	}
}