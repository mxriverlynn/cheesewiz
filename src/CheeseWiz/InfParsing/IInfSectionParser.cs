using CheeseWiz.InfModel;

namespace CheeseWiz.InfParsing
{
	public interface IInfSectionParser
	{
		void AddSectionToInf(Inf inf, InfSection section);
	}
}