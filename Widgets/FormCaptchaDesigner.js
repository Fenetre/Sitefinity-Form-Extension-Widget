Type.registerNamespace("Fenetre.Sitefinity.FormHandler");

Fenetre.Sitefinity.FormHandler.FormCaptchaDesigner = function (element) {
    this._title = null;
    this._description = null;
    this._errorMessage = null;
    this._example = null;
    this._metaFieldNameTextBox = null;

    Fenetre.Sitefinity.FormHandler.FormCaptchaDesigner.initializeBase(this, [element]);
}

Fenetre.Sitefinity.FormHandler.FormCaptchaDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        Fenetre.Sitefinity.FormHandler.FormCaptchaDesigner.callBaseMethod(this, 'initialize');
    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        Fenetre.Sitefinity.FormHandler.FormCaptchaDesigner.callBaseMethod(this, 'dispose');
    },

    /* --------------------------------- public methods ---------------------------------- */

    findElement: function (id) {
        var result = jQuery(this.get_element()).find("#" + id).get(0);
        return result;
    },

    /* Called when the designer window gets opened and here is place to "bind" your designer to the control properties */
    refreshUI: function () {
        var controlData = this._propertyEditor.get_control(); /* JavaScript clone of your control - all the control properties will be properties of the controlData too */

        /* RefreshUI Title */
        jQuery(this.get_title()).val(controlData.Title);
        /* RefreshUI Description */
        jQuery(this.get_description()).val(controlData.Description);
        jQuery(this.get_errorMessage()).val(controlData.ErrorMessage);
        /* RefreshUI Example */
        jQuery(this.get_example()).val(controlData.Example);
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        controlData.Title = jQuery(this.get_title()).val();
        controlData.Description = jQuery(this.get_description()).val();
        controlData.ErrorMessage = jQuery(this.get_errorMessage()).val();
        controlData.Example = jQuery(this.get_example()).val();
        controlData.MetaField.FieldName = this.get_metaFieldNameTextBox().get_value();
    },


    /* --------------------------------- properties -------------------------------------- */

    /* Title properties */
    get_title: function () { return this._title; }, 
    set_title: function (value) { this._title = value; },

    /* Description properties */
    get_description: function () { return this._description; }, 
    set_description: function (value) { this._description = value; },

    /* ErrorMessage properties */
    get_errorMessage: function () { return this._errorMessage; },
    set_errorMessage: function (value) { this._errorMessage = value; },

    /* Example properties */
    get_example: function () { return this._example; }, 
    set_example: function (value) { this._example = value; },

    /* metaFieldNameTextBox properties */
    get_metaFieldNameTextBox: function () { return this._metaFieldNameTextBox; },
    set_metaFieldNameTextBox: function (value) { this._metaFieldNameTextBox = value; }
}

Fenetre.Sitefinity.FormHandler.FormCaptchaDesigner.registerClass('Fenetre.Sitefinity.FormHandler.FormCaptchaDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);

