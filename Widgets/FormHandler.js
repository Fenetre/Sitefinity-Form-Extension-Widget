/// <reference name="MicrosoftAjax.js"/>
Type.registerNamespace("Fenetre.Sitefinity.FormHandler");

Fenetre.Sitefinity.FormHandler.FormHandler = function (element) {

	Fenetre.Sitefinity.FormHandler.FormHandler.initializeBase(this, [element]);
};

Fenetre.Sitefinity.FormHandler.FormHandler.prototype = {

	/* --------------------------------- set up and tear down --------------------------------- */

	initialize: function () {
		Fenetre.Sitefinity.FormHandler.FormHandler.callBaseMethod(this, 'initialize');
	},

	dispose: function () {
		Fenetre.Sitefinity.FormHandler.FormHandler.callBaseMethod(this, 'dispose');
	}
};

Fenetre.Sitefinity.FormHandler.FormHandler.registerClass('Fenetre.Sitefinity.FormHandler.FormHandler', Telerik.Sitefinity.Modules.Forms.Web.UI.FormsControl);
