using System;
using System.Collections.Generic;
using System.Linq;

namespace CheeseWiz.InfModel
{
	public class Files
	{

		private readonly IDictionary<string, FileSection> fileSections = new Dictionary<string, FileSection>();

		public FileSection this [string sectionName]
		{
			get
			{
				CheckSections(sectionName);
				return fileSections[sectionName];
			}
		}

		private void CheckSections(string sectionName)
		{
			if (fileSections.ContainsKey(sectionName))
				return;

			string keys = string.Empty;
			foreach(string key in fileSections.Keys)
			{
				keys += key + "; ";
			}
			string message = String.Format("File section '{0}' not found. Available file sections are: {1}", sectionName, keys);
			throw new Exception(message);
		}

		internal void AddSection(FileSection fileSection)
		{
			fileSections[fileSection.Section] = fileSection;
		}
	}
}