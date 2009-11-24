using System;
using System.IO;
using CheeseWiz.InfModel;
using CheeseWiz.InfParsing;
using CheeseWiz.InfRepairing;

namespace CheeseWiz
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args == null || args.Length == 0)
			{
				Console.WriteLine("You must provide the location of a .inf file to repair.");
				return;
			}

			string infFile = args[0];

			string infContents = ReadInfFile(infFile);
			Inf inf = ParseInfFile(infContents);
			RepairInfFile(inf);
			WriteInfFile(infFile, inf);
		}

		private static string ReadInfFile(string file)
		{
			return File.ReadAllText(file);
		}

		private static void WriteInfFile(string infFile, Inf inf)
		{
			string infContents = inf.RebuildInf();
			File.WriteAllText(infFile, infContents);
		}

		private static void RepairInfFile(Inf inf)
		{
			IResourceFileProcessor processor = new ResourceFileProcessor();
			InfRepairer repairer = new InfRepairer(processor);
			repairer.Repair(inf);
		}

		private static Inf ParseInfFile(string infContents)
		{
			InfParser parser = new InfParser();
			Inf inf = parser.Parse(infContents);
			return inf;
		}
	}
}
