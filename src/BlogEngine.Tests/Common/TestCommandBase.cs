using AutoFixture;
using BlogEngine.Persistence;

namespace BlogEngine.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly BlogDbContext Context;
        protected readonly Fixture Fixture;

        public TestCommandBase()
        {
            Context = ContextFactory.Create();
            Fixture = new Fixture();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
