using System.IO;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;

namespace CheeseWiz.Logging
{
	public class Log
	{
		static Log()
		{
			AddConsoleAppender();
		}

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

		private static void AddConsoleAppender()
		{
			ILayout layout = new SimpleLayout();
			var appender = new ConsoleAppender {Layout = layout};
			BasicConfigurator.Configure(appender);
		}
	}
}