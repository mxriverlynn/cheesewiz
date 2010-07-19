namespace CheeseWiz.InfModel
{
	public class SourceFile
	{
		public string Filename { get; set; }
		public string ReferenceNumber { get; private set; }

		public SourceFile(string filename, string referencenumber)
		{
			Filename = filename;
			ReferenceNumber = referencenumber;
		}
	}
}