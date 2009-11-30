using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace CheeseWiz.Specs.BDD
{
	[TestFixture]
	public abstract class ContextSpecification
	{
		private bool _throwExceptions = true;
		protected Exception ExceptionThrown { get; private set; }

		[SetUp]
		public void BeforeEachSpec()
		{
			EstablishContext();

			try
			{
				When();
			}
			catch (Exception ex)
			{
				ExceptionThrown = ex;
                
				if (_throwExceptions) throw;
			}
		}

		protected abstract void EstablishContext();
		protected abstract void When();

		protected virtual void DoNotThrowExceptions()
		{
			_throwExceptions = false;
		}

		protected virtual T Mock<T>() where T : class
		{
			return MockRepository.GenerateMock<T>();
		}
	}
}