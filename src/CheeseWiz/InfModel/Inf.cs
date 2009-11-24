using System;
using System.Collections.Generic;

namespace CheeseWiz.InfModel
{
	public class Inf
	{
		private readonly IDictionary<string, InfSection> sections = new Dictionary<string, InfSection>();

		public SourceDisksNames SourceDisksNames { get; set; }

		public SourceDisksFiles SourceDisksFiles { get; set; }

		public DestinationDirs DestinationDirs { get; set; }

		public Files Files { get; private set; }

		public Inf()
		{
			Files = new Files();
		}

		public void AddSection(InfSection section)
		{
			sections.Add(section.Section, section);
		}

		public InfSection GetSection(string sectionName)
		{
			InfSection section = null;
			if (sections.ContainsKey(sectionName))
			{
				section = sections[sectionName];
			}
			return section;
		}
	}
}