using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BusinessService
{
    public static class AutoMapperExtensions
    {
        public static TDestination To<TDestination>(this object source)
        {
            return Mapper.Map<TDestination>(source);
        }
    }
}
