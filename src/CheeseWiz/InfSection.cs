namespace CheeseWiz
{
	public class InfSection
	{
		public string Content { get; private set; }

		public string Section { get; private set; }

		public InfSection(string section, string content)
		{
			Section = section;
			Content = content;
		}
	}
}