﻿using AutoMapper;
using DAL.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTrakerCore.UnitTests.TestConfigurations
{
    public class TestBaseFixture : IDisposable
    {
        public TestBaseFixture()
        {
            Context = DbContextFactory.Create();
            Mapper = Mappings.MapperFactory.Create();
        }

        public TaskTrackerContext Context { get; }
        public IMapper Mapper { get; }

        public void Dispose()
        {
            DbContextFactory.RemoveContext(Context);
        }
    }
}
