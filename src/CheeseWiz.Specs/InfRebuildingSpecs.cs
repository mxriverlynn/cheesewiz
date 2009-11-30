using CheeseWiz.InfModel;
using CheeseWiz.InfParsing;
using CheeseWiz.InfRepairing;
using CheeseWiz.Logging;
using CheeseWiz.Specs.BDD;
using NUnit.Framework;
using Rhino.Mocks;

namespace CheeseWiz.Specs
{
	public class InfRebuildingSpecs
	{
		public static class under
		{
			public abstract class the_default_context : ContextSpecification
			{
				protected Inf SUT;
				private IResourceFileProcessor resourceFileProcessor;

				protected override void EstablishContext()
				{
					SUT = GetInf();
					resourceFileProcessor = GetResourceFileProcessor();
					ILogger logger = Mock<ILogger>();
					var infRepairer = new InfRepairer(resourceFileProcessor, logger);
					infRepairer.Repair(SUT);
				}

				private IResourceFileProcessor GetResourceFileProcessor()
				{
					var processor = Mock<IResourceFileProcessor>();
					processor.Stub(p => p.RenameFile(null, null))
						.IgnoreArguments()
						.Return(new SourceFile("CheeseWiz.CFApp.es.resources.dll", "2"))
						.Repeat.Once();
					return processor;
				}

				private Inf GetInf()
				{
					ILogger logger = Mock<ILogger>();
					var parser = new InfParser(logger);
					return parser.Parse(SampleInfContents.Sample);
				}
			}
		}

		public class when_rebuilding_the_inf_after_repairing_it : under.the_default_context
		{
			private string infContents;
			protected override void When()
			{
				infContents = SUT.RebuildInf();
			}

			[Test]
			public void it_should_contain_the_Version_section()
			{
				infContents.ShouldContain("[Version]");
			}

			[Test]
			public void it_should_contain_the_CEStrings_section()
			{
				infContents.ShouldContain("[CEStrings]");
			}

			[Test]
			public void it_should_contain_the_Strings_section()
			{
				infContents.ShouldContain("[Strings]");
			}

			[Test]
			public void it_should_contain_the_CEDevice_section()
			{
				infContents.ShouldContain("[CEDevice]");
			}

			[Test]
			public void it_should_contain_the_DefaultInstall_section()
			{
				infContents.ShouldContain("[DefaultInstall]");
			}

			[Test]
			public void it_should_contain_the_SourceDisksNames_section()
			{
				infContents.ShouldContain("[SourceDisksNames]");
			}

			[Test]
			public void it_should_contain_the_SourceDisksFiles_section()
			{
				infContents.ShouldContain("[SourceDisksFiles]");
			}

			[Test]
			public void it_should_contain_the_DestinationDirs_section()
			{
				infContents.ShouldContain("[DestinationDirs]");
			}

			[Test]
			public void it_should_contain_the_FilesCommon1_section()
			{
				infContents.ShouldContain("[Files.Common1]");
			}

			[Test]
			public void it_should_contain_the_FilesCommon2_section()
			{
				infContents.ShouldContain("[Files.Common2]");
			}

			[Test]
			public void it_should_contain_the_Shortcuts_section()
			{
				infContents.ShouldContain("[Shortcuts]");
			}

			[Test]
			public void it_should_contain_the_RegKeys_section()
			{
				infContents.ShouldContain("[RegKeys]");
			}

		}
	}
}