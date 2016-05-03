Type.registerNamespace("Fenetre.Sitefinity.FormHandler");

Fenetre.Sitefinity.FormHandler.FormHandlerDesigner = function (element) {
    this._toEmailAddresses = null;
    this._ccEmailAddresses = null;
    this._fromEmailAddress = null;
    this._emailSubject = null;
    this._emailBody = null;
    this._emailBodyHTML = null;
    this._mailUploadedFilesAsAttachments = null;

    this._clientEmailSubject = null;
    this._clientEmailBody = null;
    this._clientEmailBodyHTML = null;
    this._clientCcEmailAddresses = null;
    this._clientFromEmailAddress = null;
    this._clientConfirmationEmailAddressFormControlName = null;
    this._sendClientConfirmation = null;
    this._isClientEmailAddressUsedAsFromEmailAddress = null;
    this._clientConfirmationControlName = null;
    this._clientConfirmationControlSendOptionValue = null;

	/* Initialize RedirectPage fields */
    this._pageSelectorRedirectPage = null;
    this._selectorTagRedirectPage = null;
    this._RedirectPageDialog = null;

    this._showPageSelectorRedirectPageDelegate = null;
    this._pageSelectedRedirectPageDelegate = null;

    Fenetre.Sitefinity.FormHandler.FormHandlerDesigner.initializeBase(this, [element]);
}

Fenetre.Sitefinity.FormHandler.FormHandlerDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        Fenetre.Sitefinity.FormHandler.FormHandlerDesigner.callBaseMethod(this, 'initialize');

        this._toggleFormSelectDelegate = Function.createDelegate(this, function () {
        	dialogBase.resizeToContent();
        });

        this._toggleEmailTemplateDelegate = Function.createDelegate(this, function () {
        	dialogBase.resizeToContent();
        });

        this._toggleClientEmailTemplateDelegate = Function.createDelegate(this, function () {
        	dialogBase.resizeToContent();
        });

        this._toogleEmailSettingsDelegate = Function.createDelegate(this, function () {
            dialogBase.resizeToContent();
        });

        this._toggleClientEmailSettingsDelegate = Function.createDelegate(this, function () {
        	dialogBase.resizeToContent();
        });

        this._toggleRedirectPageDelegate = Function.createDelegate(this, function () {
        	dialogBase.resizeToContent();
        });

        jQuery("#expanderEmailSettings").click(this._toogleDesignSettingsDelegate);

        jQuery("#emailSettingsExp a:first").click(this._toogleEmailSettingsDelegate).click(function () {
        	//jQuery(".sfExpandableSection").toggleClass("sfExpandedSection", false);
        	jQuery("#emailTemplateExp").toggleClass("sfExpandedSection", false);
        	jQuery("#formSelectExp").toggleClass("sfExpandedSection", false);
        	jQuery("#clientEmailTemplateExp").toggleClass("sfExpandedSection", false);
        	jQuery("#clientEmailSettingsExp").toggleClass("sfExpandedSection", false);
        	jQuery("#redirectPageExp").toggleClass("sfExpandedSection", false);
        	$(this).parents(".sfExpandableSection:first").toggleClass("sfExpandedSection");
            dialogBase.resizeToContent();
        });

        jQuery("#formSelectExp a:first").click(this._toggleFormSelectDelegate).click(function () {
        	//jQuery(".sfExpandableSection").toggleClass("sfExpandedSection", false);
        	jQuery("#emailSettingsExp").toggleClass("sfExpandedSection", false);
        	jQuery("#emailTemplateExp").toggleClass("sfExpandedSection", false);
        	jQuery("#clientEmailTemplateExp").toggleClass("sfExpandedSection", false);
        	jQuery("#clientEmailSettingsExp").toggleClass("sfExpandedSection", false);
        	jQuery("#redirectPageExp").toggleClass("sfExpandedSection", false);
        	$(this).parents(".sfExpandableSection:first").toggleClass("sfExpandedSection");

        	dialogBase.resizeToContent();
        });
        jQuery("#emailTemplateExp a:first").click(this._toggleEmailTemplateDelegate).click(function () {
        	//jQuery(".sfExpandableSection").toggleClass("sfExpandedSection", false);
        	jQuery("#emailSettingsExp").toggleClass("sfExpandedSection", false);
        	jQuery("#formSelectExp").toggleClass("sfExpandedSection", false);
        	jQuery("#clientEmailTemplateExp").toggleClass("sfExpandedSection", false);
        	jQuery("#clientEmailSettingsExp").toggleClass("sfExpandedSection", false);
        	jQuery("#redirectPageExp").toggleClass("sfExpandedSection", false);
        	$(this).parents(".sfExpandableSection:first").toggleClass("sfExpandedSection");
        	dialogBase.resizeToContent();
        });
        
        jQuery("#clientEmailTemplateExp a:first").click(this._toggleClientEmailTemplateDelegate).click(function () {
        	//jQuery(".sfExpandableSection").toggleClass("sfExpandedSection", false);
        	jQuery("#emailSettingsExp").toggleClass("sfExpandedSection", false);
        	jQuery("#formSelectExp").toggleClass("sfExpandedSection", false);
        	jQuery("#emailTemplateExp").toggleClass("sfExpandedSection", false);
        	jQuery("#clientEmailSettingsExp").toggleClass("sfExpandedSection", false);
        	jQuery("#redirectPageExp").toggleClass("sfExpandedSection", false);
        	$(this).parents(".sfExpandableSection:first").toggleClass("sfExpandedSection");
        	dialogBase.resizeToContent();
        });

        jQuery("#clientEmailSettingsExp a:first").click(this._toggleClientEmailSettingsDelegate).click(function () {
        	//jQuery(".sfExpandableSection").toggleClass("sfExpandedSection", false);
        	jQuery("#emailTemplateExp").toggleClass("sfExpandedSection", false);
        	jQuery("#formSelectExp").toggleClass("sfExpandedSection", false);
        	jQuery("#clientEmailTemplateExp").toggleClass("sfExpandedSection", false);
        	jQuery("#emailSettingsExp").toggleClass("sfExpandedSection", false);
        	jQuery("#redirectPageExp").toggleClass("sfExpandedSection", false);
        	$(this).parents(".sfExpandableSection:first").toggleClass("sfExpandedSection");
        	dialogBase.resizeToContent();
        });

        jQuery("#redirectPageExp a:first").click(this._toggleRedirectPageDelegate).click(function () {
        	//jQuery(".sfExpandableSection").toggleClass("sfExpandedSection", false);
        	jQuery("#emailTemplateExp").toggleClass("sfExpandedSection", false);
        	jQuery("#formSelectExp").toggleClass("sfExpandedSection", false);
        	jQuery("#clientEmailTemplateExp").toggleClass("sfExpandedSection", false);
        	jQuery("#emailSettingsExp").toggleClass("sfExpandedSection", false);
        	//jQuery("#redirectPageExp").toggleClass("sfExpandedSection", false);
        	$(this).parents(".sfExpandableSection:first").toggleClass("sfExpandedSection");
        	dialogBase.resizeToContent();
        });
    	//var p = this.get_propertyEditor();
        //jQuery(p.get_advancedModeButton()).hide();
        
    	/* Initialize RedirectPage */
        this._showPageSelectorRedirectPageDelegate = Function.createDelegate(this, this._showPageSelectorRedirectPageHandler);
        $addHandler(this.get_pageSelectButtonRedirectPage(), "click", this._showPageSelectorRedirectPageDelegate);

        this._pageSelectedRedirectPageDelegate = Function.createDelegate(this, this._pageSelectedRedirectPageHandler);
        this.get_pageSelectorRedirectPage().add_doneClientSelection(this._pageSelectedRedirectPageDelegate);

        if (this._selectorTagRedirectPage) {
        	this._RedirectPageDialog = jQuery(this._selectorTagRedirectPage).dialog({
        		autoOpen: false,
        		modal: false,
        		width: 395,
        		closeOnEscape: true,
        		resizable: false,
        		draggable: false,
        		zIndex: 5000
        	});
        }

    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
    	Fenetre.Sitefinity.FormHandler.FormHandlerDesigner.callBaseMethod(this, 'dispose');

    	/* Dispose RedirectPage */
    	if (this._showPageSelectorRedirectPageDelegate) {
    		$removeHandler(this.get_pageSelectButtonRedirectPage(), "click", this._showPageSelectorRedirectPageDelegate);
    		delete this._showPageSelectorRedirectPageDelegate;
    	}

    	if (this._pageSelectedRedirectPageDelegate) {
    		this.get_pageSelectorRedirectPage().remove_doneClientSelection(this._pageSelectedRedirectPageDelegate);
    		delete this._pageSelectedRedirectPageDelegate;
    	}
    },

    /* --------------------------------- public methods ---------------------------------- */

    findElement: function (id) {
        var result = jQuery(this.get_element()).find("#" + id).get(0);
        return result;
    },

    /* Called when the designer window gets opened and here is place to "bind" your designer to the control properties */
    refreshUI: function () {
        var controlData = this._propertyEditor.get_control(); /* JavaScript clone of your control - all the control properties will be properties of the controlData too */

        
        var p = this.get_propertyEditor();
        //jQuery(p.get_advancedModeButton()).hide();
        

        /* RefreshUI ToEmailAddresses */
        jQuery(this.get_toEmailAddresses()).val(controlData.ToEmailAddresses);
        /* RefreshUI CcEmailAddresses */
        jQuery(this.get_ccEmailAddresses()).val(controlData.CcEmailAddresses);
        /* RefreshUI FromEmailAddress */
        jQuery(this.get_fromEmailAddress()).val(controlData.FromEmailAddress);
        /* RefreshUI EmailSubject */
        jQuery(this.get_emailSubject()).val(controlData.EmailSubject);
        /* RefreshUI EmailBody */
        jQuery(this.get_emailBody()).val(controlData.EmailBody);

        jQuery(this.get_clientCcEmailAddresses()).val(controlData.ClientCcEmailAddresses);
	    jQuery(this.get_clientFromEmailAddress()).val(controlData.ClientFromEmailAddress);
        jQuery(this.get_clientEmailSubject()).val(controlData.ClientEmailSubject);
        jQuery(this.get_clientEmailBody()).val(controlData.ClientEmailBody);
        jQuery(this.get_clientConfirmationEmailAddressFormControlName()).val(controlData.ClientConfirmationEmailAddressFormControlName);

        jQuery(this.get_clientConfirmationControlName()).val(controlData.ClientConfirmationControlName);
        jQuery(this.get_clientConfirmationControlSendOptionValue()).val(controlData.ClientConfirmationControlSendOptionValue);


        this.get_emailBodyHTML().control.set_value(controlData.EmailBodyHTML);
        this.get_clientEmailBodyHTML().control.set_value(controlData.ClientEmailBodyHTML);

        /* RefreshUI MailUploadedFilesAsAttachments */
        jQuery(this.get_mailUploadedFilesAsAttachments()).attr('checked', controlData.MailUploadedFilesAsAttachments);
        jQuery(this.get_sendClientConfirmation()).attr('checked', controlData.SendClientConfirmation);
        jQuery(this.get_isClientEmailAddressUsedAsFromEmailAddress()).attr('checked', controlData.IsClientEmailAddressUsedAsFromEmailAddress);
        
        if (controlData && controlData.FormId) {
            var dataItemId = controlData.FormId;
            if (dataItemId) {
                this.get_gridSelector().set_selectedKeys([dataItemId]);
            }
        }

    	/* RefreshUI RedirectPage */
        if (controlData.RedirectPage && controlData.RedirectPage !== "00000000-0000-0000-0000-000000000000") {
        	var pagesSelectorRedirectPage = this.get_pageSelectorRedirectPage().get_pageSelector();
        	var selectedPageLabelRedirectPage = this.get_selectedRedirectPageLabel();
        	var selectedPageButtonRedirectPage = this.get_pageSelectButtonRedirectPage();
        	pagesSelectorRedirectPage.add_selectionApplied(function (o, args) {
        		var selectedPage = pagesSelectorRedirectPage.get_selectedItem();
        		if (selectedPage) {
        			selectedPageLabelRedirectPage.innerHTML = selectedPage.Title.Value;
        			jQuery(selectedPageLabelRedirectPage).show();
        			selectedPageButtonRedirectPage.innerHTML = '<span>Change</span>';
        		}
        	});
        	pagesSelectorRedirectPage.set_selectedItems([{ Id: controlData.RedirectPage }]);
        }

    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {

        if (typeof (Page_ClientValidate) == 'function') {
            Page_ClientValidate();
        }

        if (Page_IsValid) {
            var controlData = this._propertyEditor.get_control();
            controlData.ToEmailAddresses = jQuery(this.get_toEmailAddresses()).val();
            controlData.CcEmailAddresses = jQuery(this.get_ccEmailAddresses()).val();
            controlData.FromEmailAddress = jQuery(this.get_fromEmailAddress()).val();
            controlData.EmailSubject = jQuery(this.get_emailSubject()).val();
            controlData.EmailBody = jQuery(this.get_emailBody()).val();
            controlData.EmailBodyHTML = this.get_emailBodyHTML().control.get_value();
            controlData.MailUploadedFilesAsAttachments = jQuery(this.get_mailUploadedFilesAsAttachments()).is(':checked');

            controlData.ClientCcEmailAddresses = jQuery(this.get_clientCcEmailAddresses()).val();
            controlData.ClientFromEmailAddress = jQuery(this.get_clientFromEmailAddress()).val();
            controlData.ClientEmailSubject = jQuery(this.get_clientEmailSubject()).val();
            controlData.ClientEmailBody = jQuery(this.get_clientEmailBody()).val();
            controlData.ClientEmailBodyHTML = this.get_clientEmailBodyHTML().control.get_value();
            controlData.SendClientConfirmation = jQuery(this.get_sendClientConfirmation()).is(':checked');
            controlData.IsClientEmailAddressUsedAsFromEmailAddress = jQuery(this.get_isClientEmailAddressUsedAsFromEmailAddress()).is(':checked');
            
            controlData.ClientConfirmationEmailAddressFormControlName = jQuery(this.get_clientConfirmationEmailAddressFormControlName()).val();

            controlData.ClientConfirmationControlName = jQuery(this.get_clientConfirmationControlName()).val();
            controlData.ClientConfirmationControlSendOptionValue = jQuery(this.get_clientConfirmationControlSendOptionValue()).val();

            var selectedItems = this.get_gridSelector().getSelectedItems();

            if (selectedItems.length > 0) {
                controlData.FormId = selectedItems[0].Id;
            }
        }
        else
        {
            preventDefault();
            stopPropagation();

        }
    },

	/* --------------------------------- private methods --------------------------------- */

	/* RedirectPage private methods */
    _showPageSelectorRedirectPageHandler: function (selectedItem) {
    	var controlData = this._propertyEditor.get_control();
    	var pagesSelector = this.get_pageSelectorRedirectPage().get_pageSelector();
    	if (controlData.RedirectPage) {
    		pagesSelector.set_selectedItems([{ Id: controlData.RedirectPage }]);
    	}
    	this._RedirectPageDialog.dialog("open");
    	jQuery("#designerLayoutRoot").hide();
    	this._RedirectPageDialog.dialog().parent().css("min-width", "355px");
    	dialogBase.resizeToContent();
    },

    _pageSelectedRedirectPageHandler: function (items) {
    	var controlData = this._propertyEditor.get_control();
    	var pagesSelector = this.get_pageSelectorRedirectPage().get_pageSelector();
    	this._RedirectPageDialog.dialog("close");
    	jQuery("#designerLayoutRoot").show();
    	dialogBase.resizeToContent();
    	if (items == null) {
    		return;
    	}
    	var selectedPage = pagesSelector.get_selectedItem();
    	if (selectedPage) {
    		this.get_selectedRedirectPageLabel().innerHTML = selectedPage.Title.Value;
    		jQuery(this.get_selectedRedirectPageLabel()).show();
    		this.get_pageSelectButtonRedirectPage().innerHTML = '<span>Change</span>';
    		controlData.RedirectPage = selectedPage.Id;
    	}
    	else {
    		jQuery(this.get_selectedRedirectPageLabel()).hide();
    		this.get_pageSelectButtonRedirectPage().innerHTML = '<span>Select...</span>';
    		controlData.RedirectPage = "00000000-0000-0000-0000-000000000000";
    	}
    },


    /* --------------------------------- properties -------------------------------------- */

    /* ToEmailAddresses properties */
    get_toEmailAddresses: function () { return this._toEmailAddresses; }, 
    set_toEmailAddresses: function (value) { this._toEmailAddresses = value; },

    /* CcEmailAddresses properties */
    get_ccEmailAddresses: function () { return this._ccEmailAddresses; }, 
    set_ccEmailAddresses: function (value) { this._ccEmailAddresses = value; },

    /* FromEmailAddress properties */
    get_fromEmailAddress: function () { return this._fromEmailAddress; }, 
    set_fromEmailAddress: function (value) { this._fromEmailAddress = value; },

    /* EmailSubject properties */
    get_emailSubject: function () { return this._emailSubject; }, 
    set_emailSubject: function (value) { this._emailSubject = value; },

    /* EmailBody properties */
    get_emailBody: function () { return this._emailBody; }, 
    set_emailBody: function (value) { this._emailBody = value; },

    /* EmailBodyHTML properties */
    get_emailBodyHTML: function () { return this._emailBodyHTML; },
    set_emailBodyHTML: function (value) { this._emailBodyHTML = value; },

    /* MailUploadedFilesAsAttachments properties */
    get_mailUploadedFilesAsAttachments: function () { return this._mailUploadedFilesAsAttachments; },
    set_mailUploadedFilesAsAttachments: function (value) { this._mailUploadedFilesAsAttachments = value; },

    get_clientCcEmailAddresses: function () { return this._clientCcEmailAddresses; },
    set_clientCcEmailAddresses: function (value) { this._clientCcEmailAddresses = value; },

    get_clientFromEmailAddress: function () { return this._clientFromEmailAddress; },
    set_clientFromEmailAddress: function (value) { this._clientFromEmailAddress = value; },

    get_clientEmailSubject: function () { return this._clientEmailSubject; },
    set_clientEmailSubject: function (value) { this._clientEmailSubject = value; },

    get_clientEmailBody: function () { return this._clientEmailBody; },
    set_clientEmailBody: function (value) { this._clientEmailBody = value; },

    get_clientEmailBodyHTML: function () { return this._clientEmailBodyHTML; },
    set_clientEmailBodyHTML: function (value) { this._clientEmailBodyHTML = value; },

    get_sendClientConfirmation: function () { return this._sendClientConfirmation; },
    set_sendClientConfirmation: function (value) { this._sendClientConfirmation = value; },

    get_isClientEmailAddressUsedAsFromEmailAddress: function () { return this._isClientEmailAddressUsedAsFromEmailAddress; },
    set_isClientEmailAddressUsedAsFromEmailAddress: function (value) { this._isClientEmailAddressUsedAsFromEmailAddress = value; },

    get_clientConfirmationEmailAddressFormControlName: function () { return this._clientConfirmationEmailAddressFormControlName; },
    set_clientConfirmationEmailAddressFormControlName: function (value) { this._clientConfirmationEmailAddressFormControlName = value; },

    get_clientConfirmationControlName: function () { return this._clientConfirmationControlName; },
    set_clientConfirmationControlName: function (value) { this._clientConfirmationControlName = value; },

    get_clientConfirmationControlSendOptionValue: function () { return this._clientConfirmationControlSendOptionValue; },
    set_clientConfirmationControlSendOptionValue: function (value) { this._clientConfirmationControlSendOptionValue = value; },


    get_gridSelector: function () {
        return this._gridSelector;
    }, set_gridSelector: function (value) {
        this._gridSelector = value;
    },

    get_pageSelectButtonRedirectPage: function () {
    	if (this._pageSelectButtonRedirectPage == null) {
    		this._pageSelectButtonRedirectPage = this.findElement("pageSelectButtonRedirectPage");
    	}
    	return this._pageSelectButtonRedirectPage;
    },
    get_selectedRedirectPageLabel: function () {
    	if (this._selectedRedirectPageLabel == null) {
    		this._selectedRedirectPageLabel = this.findElement("selectedRedirectPageLabel");
    	}
    	return this._selectedRedirectPageLabel;
    },
    get_pageSelectorRedirectPage: function () {
    	return this._pageSelectorRedirectPage;
    },
    set_pageSelectorRedirectPage: function (val) {
    	this._pageSelectorRedirectPage = val;
    },
    get_selectorTagRedirectPage: function () {
    	return this._selectorTagRedirectPage;
    },
    set_selectorTagRedirectPage: function (value) {
    	this._selectorTagRedirectPage = value;
    },

    get_gridSelector: function () {
    	return this._gridSelector;
    }, set_gridSelector: function (value) {
    	this._gridSelector = value;
    }
}

Fenetre.Sitefinity.FormHandler.FormHandlerDesigner.registerClass('Fenetre.Sitefinity.FormHandler.FormHandlerDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);

