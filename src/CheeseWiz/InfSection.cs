namespace CheeseWiz
{
	public class InfSection
	{
		public string Content { get; private set; }

		public SectionName Section { get; private set; }

		public InfSection(string section, string content)
		{
			Section = new SectionName(section);
			Content = content;
		}
	}
}