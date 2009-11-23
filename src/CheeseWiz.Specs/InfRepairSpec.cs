using System.Diagnostics;
using System.IO;
using CheeseWiz.InfModel;
using CheeseWiz.InfParsing;
using CheeseWiz.InfRepairing;
using CheeseWiz.Specs.BDD;
using NUnit.Framework;
using Rhino.Mocks;

namespace CheeseWiz.Specs
{
	public class InfRepairSpec
	{
		public static class under
		{
			public abstract class the_default_context: ContextSpecification
			{
				protected InfRepairer SUT;
				protected IResourceFileProcessor resourceFileProcessor;
				protected Inf inf;

				protected override void EstablishContext()
				{
					inf = GetInf();
					resourceFileProcessor = Mock<IResourceFileProcessor>();
					SUT = new InfRepairer(resourceFileProcessor);
				}

				private Inf GetInf()
				{
					var parser = new InfParser();
					return parser.Parse(SampleInfContents.Sample);
				}
			}
		}

		public class when_repairing_the_localized_resource_file_references : under.the_default_context
		{
			protected override void When()
			{
				SUT.Repair(inf);
			}

			[Test]
			public void it_should_rename_the_localized_resource_files()
			{
				resourceFileProcessor.AssertWasCalled(rfp => rfp.RenameFile(null, null), mo => mo
					.IgnoreArguments()
					.Repeat.AtLeastOnce()
				);
			}

			[Test]
			public void it_should_adjust_the_source_disk_file_names()
			{
				inf.SourceDisksFiles.GetResourceFiles()[1].Filename.ShouldEqual("CheeseWiz.CFApp.es.resources.dll");
			}

			[Test]
			public void it_should_adjust_the_file_destinations()
			{
				
			}
		}
	}
}