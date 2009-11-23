using System.Collections.Generic;
using System.Text.RegularExpressions;
using CheeseWiz.InfSectionParsers;

namespace CheeseWiz
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
			if (registeredInfSectionParsers.ContainsKey(section.Section))
				parser = registeredInfSectionParsers[section.Section];
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

				infSections.Add(new InfSection(section, content));
			}
			return infSections;
		}

		private void ConfigureInfSectionParsers()
		{
			registeredInfSectionParsers[InfSections.SourceDisksNames.ToString()] = new SourceDisksNamesParser();
			registeredInfSectionParsers[InfSections.SourceDisksFiles.ToString()] = new SourceDisksFilesParser();
		}
	}
}