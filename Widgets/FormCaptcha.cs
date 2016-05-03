using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Data.Metadata;
using Telerik.Sitefinity.Metadata.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.Forms.Web.UI.Fields;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using Telerik.Sitefinity.Web.UI.Fields;
using Telerik.Sitefinity.Web.UI.Fields.Enums;
using Telerik.Web.UI;

namespace Fenetre.Sitefinity.FormHandler
{
	/// <summary>
	/// Class used to create custom control for Form Builder
	/// </summary>
	[DatabaseMapping(UserFriendlyDataType.ShortText)]
	[PropertyEditorTitle("FormCaptcha Properties"), Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(Fenetre.Sitefinity.FormHandler.FormCaptchaDesigner))]
	public class FormCaptcha : FieldControl, IFormFieldControl
	{
		#region Constructor
		/// <summary>
		/// Initializes a new instance of the FormCaptcha class.
		/// </summary>
		public FormCaptcha()
		{
			this.Title = "FormCaptcha";
		}
		#endregion

		#region Public properties (will show up in dialog)
		/// <summary>
		/// Example string
		/// </summary>
		public override string Example { get; set; }

		/// <summary>
		/// Title string
		/// </summary>
		public override string Title { get; set; }

		/// <summary>
		/// Description string
		/// </summary>
		public override string Description { get; set; }

		public string ErrorMessage { get; set; }
		#endregion

		#region IFormFieldControl members
		/// <summary>
		/// Gets or sets MetaField property to persist data from control to the DB when form is submitted
		/// </summary>
		[TypeConverter(typeof(ExpandableObjectConverter))]
		public IMetaField MetaField
		{
			get
			{
				if (this.metaField == null)
				{
					this.metaField = this.LoadDefaultMetaField();
				}

				return this.metaField;
			}
			set
			{
				this.metaField = value;
			}
		}
		#endregion

		#region Value method
		/// <summary>
		/// Get and set the value of the field. 
		/// </summary>
		public override object Value
		{
			get
			{
				return this.RadCaptcha.IsValid.ToString();
			}

			set
			{
				this.RadCaptcha.IsValid = Convert.ToBoolean(value);
			}
		}
		#endregion

		public override bool IsValid()
		{
			return this.RadCaptcha.IsValid;
		}
		#region Template
		/// <summary>
		/// Gets or sets the path of the external template to be used by the control.
		/// </summary>
		public override string LayoutTemplatePath
		{
			get
			{
				return FormCaptcha.layoutTemplatePath;
			}
		}

		/// <summary>
		/// Gets the name of the embedded layout template.
		/// </summary>
		/// <remarks>
		/// Override this property to change the embedded template to be used with the dialog
		/// </remarks>
		protected override string LayoutTemplateName
		{
			get
			{
				return FormCaptcha.layoutTemplateName;
			}
		}
		#endregion

		#region Labels on control template
		/// <summary>
		/// Gets reference to the TitleLabel
		/// </summary>
		protected internal virtual Label TitleLabel
		{
			get
			{
				return this.Container.GetControl<Label>("titleLabel", true);
			}
		}

		/// <summary>
		/// Gets reference to the DescriptionLabel
		/// </summary>
		protected internal virtual Label DescriptionLabel
		{
			get
			{
				return Container.GetControl<Label>("descriptionLabel", true);
			}
		}

		/// <summary>
		/// Gets reference to the ExampleLabel
		/// </summary>
		protected internal virtual Label ExampleLabel
		{
			get
			{
				return this.Container.GetControl<Label>("exampleLabel", this.DisplayMode == FieldDisplayMode.Write);
			}
		}

		/// <summary>
		/// Reference to the TitleControl
		/// </summary>
		protected override WebControl TitleControl
		{
			get
			{
				return this.TitleLabel;
			}
		}

		/// <summary>
		/// Reference to the DescriptionControl
		/// </summary>
		protected override WebControl DescriptionControl
		{
			get
			{
				return this.DescriptionLabel;
			}
		}

		/// <summary>
		/// Gets the reference to the control that represents the example of the field control.
		/// Return null if no such control exists in the template.
		/// </summary>
		/// <value></value>
		protected override WebControl ExampleControl
		{
			get
			{
				return this.ExampleLabel;
			}
		}
		#endregion

		#region Textbox on control
		/// <summary>
		/// Gets reference to the TextBox1 control
		/// </summary>
		public virtual RadCaptcha RadCaptcha
		{
			get
			{
				return this.Container.GetControl<RadCaptcha>("radCaptcha", true);
			}
		}
		#endregion

		#region InitializeControls method
		/// <summary>
		/// Initializes the controls.
		/// </summary>
		/// <remarks>
		/// Initialize your controls in this method. Do not override CreateChildControls method.
		/// </remarks>
		protected override void InitializeControls(GenericContainer container)
		{
			// Set the label values 
			this.ExampleLabel.Text = this.Example;
			if (!string.IsNullOrWhiteSpace(this.Title))
			{
				this.TitleLabel.Text = this.Title;
			}
			else
			{
				this.TitleLabel.Visible = false;
			}
			if (!string.IsNullOrWhiteSpace(this.Description))
			{
				this.DescriptionLabel.Text = this.Description;
			}
			else
			{
				this.DescriptionLabel.Visible = false;
			}
			this.RadCaptcha.ErrorMessage = ErrorMessage;
			if (!string.IsNullOrWhiteSpace(this.Description))
			{
				this.RadCaptcha.CaptchaTextBoxLabel = this.Description;
			}
			else
			{
				this.RadCaptcha.CaptchaTextBoxLabel = " ";
			} 
                        

			
		}
		#endregion


		#region Script methods
		/// <summary>
		/// Get list of all scripts used by control
		/// </summary>
		/// <returns>List of all scripts used by control</returns>
		public override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
		{
			var descriptor = new ScriptControlDescriptor(typeof(FormCaptcha).FullName, this.ClientID);
			descriptor.AddElementProperty("radCaptcha", this.RadCaptcha.ClientID);
			descriptor.AddProperty("dataFieldName", this.MetaField.FieldName); //the field name of the corresponding widget
			return new[] { descriptor };
		}

		/// <summary>
		/// Get reference to all scripts
		/// </summary>
		/// <returns>Reference to all scripts</returns>
		public override IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
		{
			var scripts = new List<ScriptReference>(base.GetScriptReferences())
            {
                new ScriptReference(FormCaptcha.scriptReference, "Fenetre.Sitefinity.FormHandler"),
                new ScriptReference("Telerik.Sitefinity.Web.UI.Fields.Scripts.FieldDisplayMode.js", "Telerik.Sitefinity"),
            };
			return scripts;
		}
		#endregion

		#region Private fields and constants
		private IMetaField metaField = null;
		public static readonly string layoutTemplatePath = "";
		public static readonly string layoutTemplateName = "Fenetre.Sitefinity.FormHandler.Widgets.FormCaptcha.ascx";
		public const string scriptReference = "Fenetre.Sitefinity.FormHandler.Widgets.FormCaptcha.js";
		#endregion
	}
}