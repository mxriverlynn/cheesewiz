using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using CheeseWiz.InfModel;
using CheeseWiz.InfRepairing;

namespace CheeseWiz.Console
{
	internal class ResourceFileProcessor : IResourceFileProcessor
	{
		public SourceFile RenameFile(string folder, SourceFile file)
		{
			DirectoryInfo info = new DirectoryInfo(folder);
			var sourceFile = Path.Combine(info.FullName, file.Filename);
			var destinationFile = GetNewFileName(file.Filename, info.Name);
			
			File.Move(sourceFile, Path.Combine(info.FullName, destinationFile));

			SourceFile renamedFile = new SourceFile(destinationFile, file.ReferenceNumber);
			return renamedFile;
		}

		private string GetNewFileName(string originalFileName, string folderName)
		{
			var regex = new Regex(@"(?<begin>.*)(?<end>\.resources.dll)");
			string newFileName = regex.Replace(originalFileName, "${begin}." + folderName + "${end}");
			return newFileName;
		}
	}
}