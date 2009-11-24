using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CheeseWiz.InfModel
{
	public class SourceDisksNames: InfSection
	{
		private readonly IDictionary<string, ResourceFolder> resourceFolders = new Dictionary<string, ResourceFolder>();

		public SourceDisksNames(InfSection section): base(section.Section, section.Content)
		{
			ParseSourceDisks();
		}

		public ResourceFolder GetFolderByReferenceNumber(string referenceNumber)
		{
			ResourceFolder resourceFolder = null;
			if (resourceFolders.ContainsKey(referenceNumber))
				resourceFolder = resourceFolders[referenceNumber];
			return resourceFolder;
		}

		private void ParseSourceDisks()
		{
			var regex = new Regex(@"(?<referencenumber>\d*?)=,""(?<resourcename>.*?)"",,""(?<foldername>.*?)""");
			var matches = regex.Matches(Content);
			foreach(Match match in matches)
			{
				string referenceNumber = match.Groups["referencenumber"].Value;
				string resourceName = match.Groups["resourcename"].Value;
				string folderName = match.Groups["foldername"].Value;
				ResourceFolder resourceFolder = new ResourceFolder(referenceNumber, resourceName, folderName);
				resourceFolders[referenceNumber] = resourceFolder;
			}
		}
	}
}