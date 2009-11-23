using CheeseWiz.InfModel;

namespace CheeseWiz.InfRepairing
{
	public class InfRepairer
	{
		private IResourceFileProcessor ResourceFileProcessor { get; set; }

		public InfRepairer(IResourceFileProcessor resourceFileProcessor)
		{
			ResourceFileProcessor = resourceFileProcessor;
		}

		public Inf Repair(Inf inf)
		{
			ResourceFileProcessor.RenameFiles();



			return null;
		}
	}
}