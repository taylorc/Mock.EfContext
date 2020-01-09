using Mock.EfContext.Application.Common.Interfaces;
using System;

namespace Mock.EfContext.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
