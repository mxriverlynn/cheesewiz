using System.IO;
using log4net;
using log4net.Config;

namespace CheeseWiz.Logging
{
	public class Log
	{
		public static ILogger For(object itemToLogFor)
		{
			return new Log4NetLogger(LogManager.GetLogger(itemToLogFor.GetType()));
		}

		public static ILogger For<T>()
		{
			return new Log4NetLogger(LogManager.GetLogger(typeof(T)));
		}

		public static void InitializeUsing(string configFile)
		{
			if (File.Exists(configFile))
				XmlConfigurator.ConfigureAndWatch(new FileInfo(configFile));
		}
	}
}