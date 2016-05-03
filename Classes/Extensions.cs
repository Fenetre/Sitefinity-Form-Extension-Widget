using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Fenetre.Sitefinity.FormHandler
{
    /// <summary>
    /// This class constructs a new resourceManager for the FormHandler
    /// </summary>
	public static class Extensions
	{
		private static ResourceManager resourceManager = new ResourceManager(typeof(Extensions));
	}
}
