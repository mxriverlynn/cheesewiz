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

		public void Repair(Inf inf)
		{
			foreach (SourceFile resourceFile in inf.SourceDisksFiles.GetResourceFiles())
			{
				ResourceFolder resourceFolder = inf.SourceDisksNames.GetFolderByReferenceNumber(resourceFile.ReferenceNumber);
				SourceFile renamedFile = ResourceFileProcessor.RenameFile(resourceFolder.Foldername, resourceFile);
				resourceFile.Filename = renamedFile.Filename;

				//FileSection fileSection = inf.Files[resourceFolder.ResourceName];

				

			}
		}
	}
}