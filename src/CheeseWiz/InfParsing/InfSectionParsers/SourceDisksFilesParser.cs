using CheeseWiz.InfModel;

namespace CheeseWiz.InfParsing.InfSectionParsers
{
	public class SourceDisksFilesParser : GenericSectionParser
	{
		public override void AddSectionToInf(Inf inf, InfSection section)
		{
			var sourceDisksFiles = new SourceDisksFiles(section);
			inf.SourceDisksFiles = sourceDisksFiles;

			base.AddSectionToInf(inf, sourceDisksFiles);
		}
	}
}