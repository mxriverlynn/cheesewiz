namespace CheeseWiz
{
	public class DestinationDirsParser : IInfSectionParser
	{
		public void AddSectionToInf(Inf inf, InfSection section)
		{
			var destinationDirs = new DestinationDirs(section);
			inf.DestinationDirs = destinationDirs;
		}
	}
}