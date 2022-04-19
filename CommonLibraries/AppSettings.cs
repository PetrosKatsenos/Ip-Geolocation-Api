using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraries
{
	public class AppSettings
	{
		private static IConfigurationRoot _settings;
		private static IConfigurationRoot Read
		{
			get
			{
				var filename = "appsettings.json";

				var builder = new ConfigurationBuilder()
					.SetBasePath(AppContext.BaseDirectory)
					.AddJsonFile(filename, false, true);

				return builder.Build();
			}
		}

		public static string GetKey(string key)
		{
			if (_settings == null)
			{
				_settings = Read;
			}

			if (key.Contains(":"))
			{
				return _settings.GetSection(key).Value;
			}

			return _settings[key];
		}
	}
}
