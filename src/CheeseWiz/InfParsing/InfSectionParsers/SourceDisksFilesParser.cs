using CheeseWiz.InfModel;
using CheeseWiz.Logging;

namespace CheeseWiz.InfParsing.InfSectionParsers
{
	public class SourceDisksFilesParser : GenericSectionParser
	{
		private ILogger Logger { get; set; }

		public SourceDisksFilesParser(ILogger logger)
		{
			Logger = logger;
		}

		public override void AddSectionToInf(Inf inf, InfSection section)
		{
			var sourceDisksFiles = new SourceDisksFiles(section, Logger);
			inf.SourceDisksFiles = sourceDisksFiles;

			base.AddSectionToInf(inf, sourceDisksFiles);
		}
	}
}