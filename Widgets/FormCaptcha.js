Type.registerNamespace("Fenetre.Sitefinity.FormHandler");

Fenetre.Sitefinity.FormHandler.FormCaptcha = function (element) {
    this._radCaptcha = null;
    this._dataFieldName = null;
    Fenetre.Sitefinity.FormHandler.FormCaptcha.initializeBase(this, [element]);
}

Fenetre.Sitefinity.FormHandler.FormCaptcha.prototype = {
    /* --------------------------------- set up and tear down ---------------------------- */

    /* --------------------------------- public methods ---------------------------------- */

    // Gets the value of the field control.
    get_value: function () {
        return jQuery(this._radCaptcha).val();
    },

    // Sets the value of the text field control depending on DisplayMode.
    set_value: function (value) {
        jQuery(this._radCaptcha).val(value);
    },

    /* --------------------------------- event handlers ---------------------------------- */

    /* --------------------------------- private methods --------------------------------- */

    /* --------------------------------- properties -------------------------------------- */

    get_radCaptcha: function () {
        return this._radCaptcha;
    },

    set_radCaptcha: function (value) {
        this._radCaptcha = value;
    },

    get_dataFieldName: function () {
        return this._dataFieldName;
    },

    set_dataFieldName: function (value) {
        this._dataFieldName = value;
    }
}

Fenetre.Sitefinity.FormHandler.FormCaptcha.registerClass('Fenetre.Sitefinity.FormHandler.FormCaptcha', Telerik.Sitefinity.Web.UI.Fields.FieldControl);
