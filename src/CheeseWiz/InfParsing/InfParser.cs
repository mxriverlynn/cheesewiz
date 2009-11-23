using System.Collections.Generic;
using System.Text.RegularExpressions;
using CheeseWiz.InfModel;
using CheeseWiz.InfParsing.InfSectionParsers;

namespace CheeseWiz.InfParsing
{
	public class InfParser
	{
		private readonly IDictionary<string, IInfSectionParser> registeredInfSectionParsers = new Dictionary<string, IInfSectionParser>();

		public InfParser()
		{
			ConfigureInfSectionParsers();
		}

		public Inf Parse(string contents)
		{
			var infSections = SplitInfContents(contents);
			Inf inf = BuildInfFromSections(infSections);
			return inf;
		}

		private Inf BuildInfFromSections(IEnumerable<InfSection> infSections)
		{
			var inf = new Inf();
			foreach(var infSection in infSections)
			{
				IInfSectionParser sectionParser = GetSectionHandler(infSection);
				sectionParser.AddSectionToInf(inf, infSection);
			}
			return inf;
		}

		private IInfSectionParser GetSectionHandler(InfSection section)
		{
			IInfSectionParser parser;
			
			string key;
			if (section.Section.HasType)
				key = section.Section.Type;
			else
				key = section.Section.Name;

			if (registeredInfSectionParsers.ContainsKey(key))
				parser = registeredInfSectionParsers[key];
			else
				parser = new GenericSectionParser();

			return parser;
		}

		private IList<InfSection> SplitInfContents(string contents)
		{
			var regEx = new Regex(@"\[(?<section>.*?)\]", RegexOptions.Multiline);
			string[] splitContents = regEx.Split(contents);


			IList<InfSection> infSections = new List<InfSection>();
			for (int i = 1; i <= splitContents.Length-1; i += 2)
			{
				string section = splitContents[i];
				string content = splitContents[i + 1];

				var infSection = new InfSection(section, content);
				infSections.Add(infSection);
			}
			return infSections;
		}

		private void ConfigureInfSectionParsers()
		{
			registeredInfSectionParsers[InfSections.SourceDisksNames.ToString()] = new SourceDisksNamesParser();
			registeredInfSectionParsers[InfSections.SourceDisksFiles.ToString()] = new SourceDisksFilesParser();
			registeredInfSectionParsers[InfSections.DestinationDirs.ToString()] = new DestinationDirsParser();
			registeredInfSectionParsers[InfSections.Files.ToString()] = new FilesParser();
		}
	}
}