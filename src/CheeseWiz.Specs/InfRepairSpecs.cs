using System;
using CheeseWiz.InfModel;
using CheeseWiz.InfParsing;
using CheeseWiz.InfRepairing;
using CheeseWiz.Logging;
using CheeseWiz.Specs.BDD;
using NUnit.Framework;
using Rhino.Mocks;

namespace CheeseWiz.Specs
{
	public class InfRepairSpecs
	{
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
				inf.SourceDisksFiles.Content.ShouldContain("\"CheeseWiz.CFApp.es.resources.dll\"=2");
			}

			[Test]
			public void it_should_adjust_the_file_destinations()
			{
				inf.Files["Files.Common2"].Content.ShouldContain("\"CheeseWiz.CFApp.resources.dll\",\"CheeseWiz.CFApp.es.resources.dll\",,0");
			}
		}

		public class when_requesting_a_file_section_that_does_not_exist : under.the_default_context
		{

			Exception caughtException;

			protected override void When()
			{
				try
				{
					FileSection section = inf.Files["I dont exist"];
				}
				catch (Exception ex)
				{
					caughtException = ex;
				}
			}

			[Test]
			public void it_should_throw_an_exception()
			{
				caughtException.ShouldNotBeNull();
			}

			[Test]
			public void the_exception_should_contain_the_requested_section_name()
			{
				caughtException.Message.ShouldContain("I dont exist");
			}

			[Test]
			public void the_exception_should_contain_the_list_of_file_sections()
			{
				caughtException.Message.ShouldContain("Files;");
				caughtException.Message.ShouldContain("Files.Common2;");
			}
		}

		public class when_repairing_a_file_that_is_named_correctly : under.the_default_context
		{
			protected override Inf GetInf()
			{
				ILogger logger = Mock<ILogger>();
				var parser = new InfParser(logger);
				return parser.Parse(SampleInfContents.SampleWithProperlyNamedFiles);
			}

			protected override void When()
			{
				SUT.Repair(inf);
			}

			[Test]
			public void it_should_not_rename_the_file()
			{
				resourceFileProcessor.AssertWasNotCalled(fp => fp.RenameFile(Arg<string>.Is.Anything, Arg<SourceFile>.Is.Anything));
			}
		}

		public static class under
		{
			public abstract class the_default_context : ContextSpecification
			{
				protected InfRepairer SUT;
				protected IResourceFileProcessor resourceFileProcessor;
				protected Inf inf;

				protected override void EstablishContext()
				{
					inf = GetInf();
					resourceFileProcessor = GetResourceFileProcessor();
					ILogger logger = Mock<ILogger>();
					SUT = new InfRepairer(resourceFileProcessor, logger);
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

				protected virtual Inf GetInf()
				{
					ILogger logger = Mock<ILogger>();
					var parser = new InfParser(logger);
					return parser.Parse(SampleInfContents.Sample);
				}
			}
		}
	}
}