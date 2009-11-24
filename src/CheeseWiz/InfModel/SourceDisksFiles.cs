using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace CheeseWiz.InfModel
{
	public class SourceDisksFiles: InfSection
	{
		private IList<SourceFile> SourceFiles { get; set; }
		

		public SourceDisksFiles(InfSection section): base(section.Section, section.Content)
		{
			SourceFiles = ParseFiles(Content);
		}

		private List<SourceFile> ParseFiles(string content)
		{
			var regex = new Regex(@"\""(?<filename>.*?)\""=(?<referencenumber>\d{1,})", RegexOptions.Multiline);
			MatchCollection matches = regex.Matches(content);
			var resourceFiles = new List<SourceFile>();
			foreach (Match match in matches)
			{
				string filename = match.Groups["filename"].Value;
				string referencenumber = match.Groups["referencenumber"].Value;
				var resourceFile = new SourceFile(filename, referencenumber);
				resourceFiles.Add(resourceFile);
			}
			return resourceFiles;
		}

		public IList<SourceFile> GetResourceFiles()
		{
			IEnumerable<SourceFile> files = SourceFiles.Where(f => f.Filename.Contains(".resources.dll"));
			return new List<SourceFile>(files);
		}

		public void RenameFile(string referenceNumber, string newFilename)
		{			
			var regex = new Regex(@"\""(?<filename>.*?)\""=" + referenceNumber, RegexOptions.Multiline);
			Content = regex.Replace(Content, "\"" + newFilename + "\"=" + referenceNumber);
		}
	}
}