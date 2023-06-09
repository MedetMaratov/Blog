﻿using BlogEngine.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly BlogDbContext Context;

        public TestCommandBase()
        {
            Context = ContextFactory.Create();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
