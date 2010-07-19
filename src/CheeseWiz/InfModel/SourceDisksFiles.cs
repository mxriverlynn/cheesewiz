using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using CheeseWiz.Logging;

namespace CheeseWiz.InfModel
{
	public class SourceDisksFiles : InfSection
	{
		private IList<SourceFile> SourceFiles { get; set; }
		private ILogger Logger { get; set; }

		public SourceDisksFiles(InfSection section, ILogger logger)
			: base(section.Section, section.Content)
		{
			Logger = logger;
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

		public IEnumerable<SourceFile> GetResourceFiles()
		{
			IEnumerable<SourceFile> files = SourceFiles.Where(f => f.Filename.Contains(".resources.dll"));
			return new List<SourceFile>(files);
		}

		public void RenameFile(string referenceNumber, string originalFilename, string newFilename)
		{
			Logger.Debug("Renaming Source Disk File To '" + newFilename + "=" + referenceNumber + "'");
			var expression = string.Format(@"\""(?<filename>{0})\""={1}", originalFilename, referenceNumber);
			var regex = new Regex(expression, RegexOptions.Multiline);
			Content = regex.Replace(Content, "\"" + newFilename + "\"=" + referenceNumber);
		}
	}
}