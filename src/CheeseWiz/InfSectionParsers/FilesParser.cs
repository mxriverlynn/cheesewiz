namespace CheeseWiz.InfSectionParsers
{
	public class FilesParser : IInfSectionParser
	{
		public void AddSectionToInf(Inf inf, InfSection section)
		{
			var fileSection = new FileSection(section);
			inf.Files.AddSection(fileSection);
		}
	}
}