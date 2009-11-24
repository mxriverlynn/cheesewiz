using CheeseWiz.InfModel;

namespace CheeseWiz.InfParsing.InfSectionParsers
{
	public class FilesParser: GenericSectionParser
	{
		public override void AddSectionToInf(Inf inf, InfSection section)
		{
			var fileSection = new FileSection(section);
			inf.Files.AddSection(fileSection);

			base.AddSectionToInf(inf, fileSection);
		}
	}
}