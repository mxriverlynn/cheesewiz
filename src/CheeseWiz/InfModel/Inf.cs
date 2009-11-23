namespace CheeseWiz.InfModel
{
	public class Inf
	{
		public SourceDisksNames SourceDisksNames { get; set; }

		public SourceDisksFiles SourceDisksFiles { get; set; }

		public DestinationDirs DestinationDirs { get; set; }

		public Files Files { get; private set; }

		public Inf()
		{
			Files = new Files();
		}
	}
}