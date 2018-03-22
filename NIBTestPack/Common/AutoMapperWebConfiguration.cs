using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace NIBTestPack
{
    public class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles("NIBTestPack", "DataAccess", "BusinessService", "ExpenseBusinessService");
            });
        }
    }
}