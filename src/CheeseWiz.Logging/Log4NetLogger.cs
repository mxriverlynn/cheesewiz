using System;
using log4net;

namespace CheeseWiz.Logging
{
	public class Log4NetLogger : ILogger
	{
		private readonly ILog _underlyingLogger;

		public Log4NetLogger(ILog underlyingLogger)
		{
			_underlyingLogger = underlyingLogger;
		}

		public void Debug(string message, params object[] args)
		{
			_underlyingLogger.DebugFormat(message, args);
		}

		public void Error(Exception exception)
		{
			_underlyingLogger.Error(exception.ToString());
		}

		public void Error(string message)
		{
			_underlyingLogger.Error(message);
		}

		public void Error(string message, params object[] args)
		{
			_underlyingLogger.ErrorFormat(message, args);
		}

		public void Warn(string message)
		{
			_underlyingLogger.Warn(message);
		}

		public void Warn(string message, params object[] args)
		{
			_underlyingLogger.WarnFormat(message, args);
		}

		public void Info(string message, params object[] args)
		{
			_underlyingLogger.InfoFormat(message, args);
		}
	}
}