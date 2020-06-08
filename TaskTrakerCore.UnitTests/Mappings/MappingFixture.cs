using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace TaskTrakerCore.UnitTests.Mappings
{
    public class MappingFixture
    {
        public MappingFixture() =>
            Mapper = MapperFactory.Create();

        public IMapper Mapper { get; set; }
    }
}
