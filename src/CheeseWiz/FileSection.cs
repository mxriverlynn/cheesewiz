namespace CheeseWiz
{
	public class FileSection: InfSection
	{
		public FileSection(InfSection section): base(section.Section, section.Content){}
	}
}