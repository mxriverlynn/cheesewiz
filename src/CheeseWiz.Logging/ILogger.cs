using System;

namespace CheeseWiz.Logging
{
	public interface ILogger
	{
		void Debug(string message, params object[] args);
		void Error(Exception exception);
		void Error(string message);
		void Error(string message, params object[] args);
		void Warn(string message);
		void Warn(string message, params object[] args);
		void Info(string message, params object[] args);
	}
}