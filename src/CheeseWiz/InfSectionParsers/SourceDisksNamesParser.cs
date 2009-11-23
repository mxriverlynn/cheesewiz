namespace CheeseWiz.InfSectionParsers
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