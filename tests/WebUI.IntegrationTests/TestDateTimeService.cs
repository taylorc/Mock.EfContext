using Mock.EfContext.Application.Common.Interfaces;
using System;

namespace Mock.EfContext.WebUI.IntegrationTests
{
    public class TestDateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
