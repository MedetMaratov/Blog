using AutoMapper;
using BlogEngine.Persistence;
using BlogEngineApplication.Common.Mapping;
using BlogEngineApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngine.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public BlogDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = ContextFactory.Create();
            var configProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IBlogDbContext).Assembly));
            });
            Mapper = configProvider.CreateMapper();
        }

        public void Dispose()
        {
            ContextFactory.Destroy(Context);
        }

        [CollectionDefinition("QueryCollection")]
        public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
    }
}
