namespace CheeseWiz.InfModel
{
	public class SourceDisksNames: InfSection
	{
		public SourceDisksNames(InfSection section): base(section.Section, section.Content){}

		public ResourceFolder GetFolderByReferenceNumber(string referenceNumber)
		{
			return new ResourceFolder();
		}
	}
}