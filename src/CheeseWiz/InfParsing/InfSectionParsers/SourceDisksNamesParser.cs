using CheeseWiz.InfModel;

namespace CheeseWiz.InfParsing.InfSectionParsers
{
	public class SourceDisksNamesParser: GenericSectionParser
	{
		public override void AddSectionToInf(Inf inf, InfSection section)
		{
			var sourceDisksNames = new SourceDisksNames(section);
			inf.SourceDisksNames = sourceDisksNames;

			base.AddSectionToInf(inf, sourceDisksNames);
		}
	}
}