using System.Text.RegularExpressions;

namespace CheeseWiz.InfModel
{
	public class FileSection: InfSection
	{
		public FileSection(InfSection section): base(section.Section, section.Content){}

		public void RenameFileSource(string originalSourceFileName, string newSourceFileName)
		{
			var regex = new Regex("\"(?<destination>.*?)\",\"(?<source>" + originalSourceFileName + ")\",,0");
			Content = regex.Replace(Content, "\"${destination}\",\"" + newSourceFileName + "\",,0");
		}
	}
}