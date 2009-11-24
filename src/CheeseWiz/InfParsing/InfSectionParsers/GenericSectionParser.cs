using CheeseWiz.InfModel;

namespace CheeseWiz.InfParsing.InfSectionParsers
{
	public class GenericSectionParser : IInfSectionParser
	{
		public virtual void AddSectionToInf(Inf inf, InfSection section)
		{
			inf.AddSection(section);
		}
	}
}