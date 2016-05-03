using System;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using System.Collections.Generic;
using Telerik.Sitefinity.Forms.Model;
using Telerik.Sitefinity.Modules.Forms;
using Telerik.Sitefinity.Modules.Forms.Web.UI.Fields;

namespace Fenetre.Sitefinity.FormHandler
{
    /// <summary>
    /// Represents a designer for the <typeparamref name="Fenetre.Sitefinity.FormHandler.FormCaptcha"/> widget
    /// </summary>
    public class FormCaptchaDesigner : ControlDesignerBase
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
        /// Gets the layout template name
        /// </summary>
        protected override string LayoutTemplateName
        {
            get
            {
                return layoutTemplateName;
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
        /// Gets the control that is bound to the Title property
        /// </summary>
        protected virtual Control Title
        {
            get
            {
                return this.Container.GetControl<Control>("Title", true);
            }
        }

        /// <summary>
        /// Gets the control that is bound to the Description property
        /// </summary>
        protected virtual Control Description
        {
            get
            {
                return this.Container.GetControl<Control>("Description", true);
            }
        }

		protected virtual Control ErrorMessage
		{
			get
			{
				return this.Container.GetControl<Control>("ErrorMessage", true);
			}
		}
		
		/// <summary>
        /// Gets the control that is bound to the Example property
        /// </summary>
        protected virtual Control Example
        {
            get
            {
                return this.Container.GetControl<Control>("Example", true);
            }
        }

        /// <summary>
        /// Control that represents the meta field name
        /// </summary>
        public MetaFieldNameTextBox MetaFieldNameTextBox
        {
            get { return this.Container.GetControl<MetaFieldNameTextBox>("metaFieldNameTextBox", true); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the form handler captcha
        /// </summary>
        /// <param name="container"></param>
        protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
        {
            // Place your initialization logic here
            this.ConfigureMetaFieldName();
        }

        /// <summary>
        /// Configures the name of the meta field.
        /// </summary>
        private void ConfigureMetaFieldName()
        {
            var control = this.PropertyEditor.Control as IFormFieldControl;
            var formControl = (this.PropertyEditor.ControlData as FormDraftControl);
            var form = formControl.Form;

            // MetaField is not initialized
            if (string.IsNullOrEmpty(control.MetaField.FieldName))
            {
                this.MetaFieldNameTextBox.FieldName = control.GetType().Name + "_" + ((Control)control).ID.ToString();
                this.MetaFieldNameTextBox.ReadOnly = false;
            }
            else
            {
                this.MetaFieldNameTextBox.FieldName = control.MetaField.FieldName;
                if (formControl.Published) // form is already published
                {
                    var fieldName = control.MetaField.FieldName;
                    var fieldExists = form.GetMetaFields().Any(m => m.FieldName == fieldName);
                    if (fieldExists)
                    {
                        this.MetaFieldNameTextBox.ReadOnly = true;
                    }
                }
            }
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

            descriptor.AddElementProperty("title", this.Title.ClientID);
            descriptor.AddElementProperty("description", this.Description.ClientID);
            descriptor.AddElementProperty("example", this.Example.ClientID);
			descriptor.AddElementProperty("errorMessage", this.ErrorMessage.ClientID);
            descriptor.AddComponentProperty("metaFieldNameTextBox", this.MetaFieldNameTextBox.ClientID);

            return scriptDescriptors;
        }

        /// <summary>
        /// Gets a collection of ScriptReference objects that define script resources that the control requires.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(FormCaptchaDesigner.scriptReference, "Fenetre.Sitefinity.FormHandler"));
            return scripts;
        }
        #endregion

        #region Private members & constants
        public static readonly string layoutTemplatePath = "";
		public static readonly string layoutTemplateName = "Fenetre.Sitefinity.FormHandler.Widgets.FormCaptchaDesigner.ascx";
		public const string scriptReference = "Fenetre.Sitefinity.FormHandler.Widgets.FormCaptchaDesigner.js";
        #endregion
    }
}
 
