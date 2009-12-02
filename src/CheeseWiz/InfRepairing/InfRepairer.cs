using CheeseWiz.InfModel;
using CheeseWiz.Logging;

namespace CheeseWiz.InfRepairing
{
	public class InfRepairer
	{
		private readonly ILogger _logger;
		private IResourceFileProcessor ResourceFileProcessor { get; set; }

		public InfRepairer(IResourceFileProcessor resourceFileProcessor, ILogger logger)
		{
			_logger = logger;
			ResourceFileProcessor = resourceFileProcessor;
		}

		public void Repair(Inf inf)
		{
			foreach (SourceFile resourceFile in inf.SourceDisksFiles.GetResourceFiles())
			{
				_logger.Info("Repairing INF for file: '" + resourceFile.Filename + "'");

				ResourceFolder resourceFolder = inf.SourceDisksNames.GetFolderByReferenceNumber(resourceFile.ReferenceNumber);
				SourceFile renamedFile = ResourceFileProcessor.RenameFile(resourceFolder.FolderName, resourceFile);

				_logger.Info("Looking For File Resource Name: " + resourceFolder.ResourceName);
				FileSection fileSection = inf.Files[resourceFolder.ResourceName];

				_logger.Debug("Renamed '" + resourceFile.Filename + "' to '" + renamedFile.Filename + "'");
				fileSection.RenameFileSource(resourceFile.Filename, renamedFile.Filename);
				inf.SourceDisksFiles.RenameFile(resourceFile.ReferenceNumber, renamedFile.Filename);
			}
		}
	}
}