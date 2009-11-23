using CheeseWiz.Specs.BDD;
using NUnit.Framework;

namespace CheeseWiz.Specs
{
	public class InfRepairSpec
	{
		public static class under
		{
			public abstract class the_default_context: ContextSpecification
			{
				protected override void EstablishContext()
				{
				}
			}
		}

		public class when_specifying_the_folder_to_pull_localized_resources_from : under.the_default_context
		{
			protected override void When()
			{
			}

			[Test]
			public void it_should_adjust_the_source_disk_folder_names()
			{
				
			}

			[Test]
			public void it_should_adjust_the_source_disk_files()
			{
				
			}

			[Test]
			public void it_should_adjust_the_file_destinations()
			{
				
			}
		}
	}
}