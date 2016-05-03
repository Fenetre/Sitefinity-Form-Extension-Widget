using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Abstractions.VirtualPath.Configuration;
using Fenetre.Sitefinity.Modules;
using Telerik.Sitefinity.Modules.Pages.Configuration;

namespace Fenetre.Sitefinity.FormHandler
{
	public class Installer
	{
		/// <summary>
		/// Method that is called by ASP.NET before application starts.
		/// </summary>
		public static void PreApplicationStart()
		{
			Bootstrapper.Initialized += (new EventHandler<ExecutedEventArgs>(Installer.Bootstrapper_Initialized));
		}

		/// <summary>
        /// Method that subscribes this object to the Sitefinity Bootstrapper_Initialized event, 
        /// which is fired after initialization of the Sitefinity application.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void Bootstrapper_Initialized(object sender, ExecutedEventArgs e)
		{
			if (e.CommandName != "RegisterRoutes" || !Bootstrapper.IsDataInitialized)
			{
				return;
			}

			InstallModule();
			InstallVirtualPaths();
			InstallWidget();
		}


		/// <summary>
        /// Method to programmatically install modules.
		/// </summary>
		private static void InstallModule()
		{
			// Define content view control
			var modulesConfig = Config.Get<SystemConfig>().ApplicationModules;
			AppModuleSettings customFieldsSetting = modulesConfig.Elements.Where(el => el.GetKey().Equals(FenetreModule.moduleName)).SingleOrDefault();
			if (customFieldsSetting == null)
			{
				AppModuleSettings moduleConfigElement = new AppModuleSettings(modulesConfig)
				{
					Name = FenetreModule.moduleName,
					Title = FenetreModule.moduleTitle,
					Description = FenetreModule.moduleDescription,
					Type = typeof(FenetreModule).AssemblyQualifiedName,
					StartupType = StartupType.OnApplicationStart
				};

				// Register the module
				modulesConfig.Add(FenetreModule.moduleName, moduleConfigElement);

				ConfigManager.GetManager().SaveSection(modulesConfig.Section);
			}
		}

		/// <summary>
		/// Below you will see how virtual paths can be programmatically installed
		/// </summary>
		private static void InstallVirtualPaths()
		{
			//SiteInitializer initializer = SiteInitializer.GetInitializer();
			//var virtualPathConfig = initializer.Context.GetConfig<VirtualPathSettingsConfig>();
			//var EventsCalendarViewConfig = new VirtualPathElement(virtualPathConfig.VirtualPaths)
			//{
			//	VirtualPath = SampleWidget.sampleWidgetVirtualPath + "*",
			//	ResolverName = "EmbeddedResourceResolver",
			//	ResourceLocation = typeof(SampleWidget).Assembly.GetName().Name
			//};
			//if (!virtualPathConfig.VirtualPaths.ContainsKey(SampleWidget.sampleWidgetVirtualPath + "*"))
			//{
			//	virtualPathConfig.VirtualPaths.Add(EventsCalendarViewConfig);
			//	Config.GetManager().SaveSection(virtualPathConfig);
			//}
		}

		/// <summary>
		/// Method that installs the widget.
		/// </summary>
		private static void InstallWidget()
		{
			//App.WorkWith().Module(FenetreModule.moduleName).Install()
			//	.PageToolbox().ContentSection()
			//		.LoadOrAddWidget<FormHandler>("FormHandler")
			//			.SetTitle("Fenêtre Form Handler")
			//			.SetDescription("Form handler which sends notifications and is able to use a captcha. Powered by Fenêtre.")
			//			.Done()
			//		.Done()
			//	.Done();

			//App.WorkWith().Module(FenetreModule.moduleName).Install()
			//	.Toolbox("FormControls").LoadOrAddSection("Fenetre")
			//		.SetTitle("Fenêtre Add-ons")
			//		.LoadOrAddWidget<FormCaptcha>("FormCaptcha")
			//			.SetTitle("Fenêtre Form Captcha")
			//			.SetDescription("Form capthca for use with the Fenêtre Form Handler. Powered by Fenêtre.")
			//	.Done();

			var sectionName = "Fenetre";
			var sectionTitle = "Fenêtre Add-ons";

			InstallSingleWidget("FormHandler", "Fenêtre Form Handler", typeof(FormHandler), sectionName, sectionTitle, "PageControls");
			InstallSingleWidget("FormCaptcha", "Fenêtre Form Captcha", typeof(FormCaptcha), sectionName, sectionTitle, "FormControls");
		}

        /// <summary>
        /// Method to install a single widget with the given parameters.
        /// </summary>
        /// <param name="controlName">Name of the widget</param>
        /// <param name="controlTitle">Name of the widget that will be visible in the front end</param>
        /// <param name="controlType">Type of the widget</param>
        /// <param name="sectionName">Name of the section the widget will be installed into</param>
        /// <param name="sectionTitle">Name of the section that will visible in the front end</param>
        /// <param name="toolBoxName">Name of the Sitefinity toolbox</param>
		private static void InstallSingleWidget(string controlName, string controlTitle, System.Type controlType, string sectionName, string sectionTitle, string toolBoxName)
		{
			var configManager = ConfigManager.GetManager();
			var config = configManager.GetSection<ToolboxesConfig>();

			var controls = config.Toolboxes[toolBoxName];
			var section = controls.Sections.Where<ToolboxSection>(e => e.Name == sectionName).FirstOrDefault();

			if (section == null)
			{
				section = new ToolboxSection(controls.Sections)
				{
					Name = sectionName,
					Title = sectionTitle
				};
				controls.Sections.Add(section);
			}

			if (!section.Tools.Any<ToolboxItem>(e => e.Name == controlName))
			{
				var tool = new ToolboxItem(section.Tools)
				{
					Name = controlName,
					Title = controlTitle,
					ControlType = controlType.AssemblyQualifiedName
				};
				section.Tools.Add(tool);
			}

			configManager.SaveSection(config);
		}
	}
}
