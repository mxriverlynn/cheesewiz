using CheeseWiz.InfModel;

namespace CheeseWiz.InfRepairing
{
	public interface IResourceFileProcessor
	{
		SourceFile RenameFile(string folder, SourceFile file);
	}
}