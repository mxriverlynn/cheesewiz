using CheeseWiz.InfModel;

namespace CheeseWiz.InfParsing.InfSectionParsers
{
	public class SourceDisksFilesParser : IInfSectionParser
	{
		public void AddSectionToInf(Inf inf, InfSection section)
		{
			var sourceDisksFiles = new SourceDisksFiles(section);
			inf.SourceDisksFiles = sourceDisksFiles;
		}
	}
}