using CheeseWiz.InfModel;

namespace CheeseWiz.InfParsing.InfSectionParsers
{
	public class SourceDisksNamesParser : IInfSectionParser
	{
		public void AddSectionToInf(Inf inf, InfSection section)
		{
			var sourceDisksNames = new SourceDisksNames(section);
			inf.SourceDisksNames = sourceDisksNames;
		}
	}
}