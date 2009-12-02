using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using CheeseWiz.InfModel;
using CheeseWiz.InfParsing;
using CheeseWiz.InfRepairing;
using CheeseWiz.Logging;

namespace CheeseWiz.Console
{

	class Program
	{

		private static ILogger _logger;
		private static string _originaDir;

		static void Main(string[] args)
		{
			SetupLogger();
			int returnCode = 0;
			try
			{
				if (!ValidateArgs(args))
					return;

				string infFile = args[0];
				SetCurrentFolder(infFile);

				string infContents = ReadInfFile(infFile);
				Inf inf = ParseInfFile(infContents);
				RepairInfFile(inf);
				WriteInfFile(infFile, inf);
			}
			catch (Exception ex)
			{
				_logger.Error("Error Patching INF File For Compact Framework");
				_logger.Error(ex);
				returnCode = -1;
			}
			finally
			{
				ResetCurrentFolder();
			}
			Environment.Exit(returnCode);
		}

		private static void ResetCurrentFolder()
		{
			if (!string.IsNullOrEmpty(_originaDir))
				Environment.CurrentDirectory = _originaDir;
		}

		private static void SetCurrentFolder(string infFile)
		{
			_originaDir = Environment.CurrentDirectory;
			FileInfo fileInfo = new FileInfo(infFile);
			_logger.Debug("Changing Working Folder To: " + fileInfo.Directory.FullName);
			Environment.CurrentDirectory = fileInfo.Directory.FullName;
		}



		private static void SetupLogger()
		{
			FileInfo asm = new FileInfo(Assembly.GetExecutingAssembly().Location);
			string config = Path.Combine(asm.Directory.FullName, "log4net.config");
			if (File.Exists(config))
				Log.InitializeUsing(config);
			_logger = Log.For<Program>();
		}

		private static bool ValidateArgs(ICollection<string> args)
		{
			bool valid = true;
			if (args == null || args.Count == 0)
			{
				valid = false;
				_logger.Error("You must provide the location of a .inf file to repair.");
			}
			return valid;
		}

		private static string ReadInfFile(string file)
		{
			string fileContents;
			if (File.Exists(file))
				fileContents = File.ReadAllText(file);
			else
			{
				string msg = "Specified INF File Does Not Exist: " + file;
				throw new Exception(msg);
			}
			return fileContents;
		}

		private static void WriteInfFile(string infFile, Inf inf)
		{
			_logger.Info("Writing Repaired INF Out To '" + infFile + "'");
			string infContents = inf.RebuildInf();
			File.WriteAllText(infFile, infContents);
		}

		private static void RepairInfFile(Inf inf)
		{
			ILogger logger = Log.For<InfRepairer>();
			IResourceFileProcessor processor = new ResourceFileProcessor();
			InfRepairer repairer = new InfRepairer(processor, logger);
			repairer.Repair(inf);
		}

		private static Inf ParseInfFile(string infContents)
		{
			ILogger logger = Log.For<InfParser>();
			InfParser parser = new InfParser(logger);
			Inf inf = parser.Parse(infContents);
			return inf;
		}
	}
}