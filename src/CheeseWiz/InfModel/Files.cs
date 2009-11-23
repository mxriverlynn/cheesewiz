using System.Collections.Generic;

namespace CheeseWiz.InfModel
{
	public class Files
	{

		private readonly IDictionary<string, FileSection> fileSections = new Dictionary<string, FileSection>();

		public FileSection this [string sectionName]
		{
			get
			{
				return fileSections[sectionName];
			}
		}

		internal void AddSection(FileSection fileSection)
		{
			fileSections[fileSection.Section.Name] = fileSection;
		}
	}
}