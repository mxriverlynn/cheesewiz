using System;

namespace CheeseWiz.InfModel
{
	public class ResourceFolder
	{
		public string ReferenceNumber { get; private set; }
		public string ResourceName { get; private set; }
		public string FolderName { get; set; }

		public ResourceFolder(string referenceNumber, string resourceName, string folderName)
		{
			ReferenceNumber = referenceNumber;
			ResourceName = resourceName;
			FolderName = folderName;
		}
	}
}