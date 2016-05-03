using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Fluent.Modules;

namespace Fenetre.Sitefinity.Modules
{
    /// <summary>
    /// Does nothing at this point. This is a dummy module that contains
    /// hardcoded properties that are used install the widget.
    /// </summary>
	public class FenetreModule : ModuleBase
	{
		protected override Telerik.Sitefinity.Configuration.ConfigSection GetModuleConfig()
		{
			return new ConfigSection();
		}

		public override void Install(Telerik.Sitefinity.Abstractions.SiteInitializer initializer)
		{
		}

		public override Guid LandingPageId
		{
			get { return new Guid(landingPageIdString); }
		}

		public override Type[] Managers
		{
			get
			{
				return new Type[0];
			}
		}

		public override void Upgrade(Telerik.Sitefinity.Abstractions.SiteInitializer initializer, Version upgradeFrom)
		{
		}

		public static readonly string moduleName = "FenetreModule";
		public static readonly string moduleTitle = "Fenêtre Add-ons";
		public static readonly string moduleDescription = "Module containing some very interesting and useful widgets. Powered by Fenêtre.";
		private static readonly string landingPageIdString = "2D0858D6-5239-4A58-A05F-8F222D630E14";
	}
}
