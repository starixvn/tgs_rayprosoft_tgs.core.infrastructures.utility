using System;

namespace TGS.Core.Infrastructures.Utility
{
    public static class BrandSettlementIntervalGenerator
    {
        public static (DateTimeOffset? BeforeFromDate, DateTimeOffset? BeforeToDate, DateTimeOffset? AfterFromDate,
            DateTimeOffset? AfterToDate) GetDailyIntervalDays(DateTimeOffset? startDate = null)
        {
            var timeSpan = new TimeSpan(8, 0, 0);
            var now = new DateTimeOffset(DateTimeOffset.Now.Year, DateTimeOffset.Now.Month,
                DateTimeOffset.Now.Day, 0,
                0, 0, timeSpan);

            if (startDate != null)
            {
                var date = startDate.Value.ToOffset(timeSpan);
                now = new(date.Year, date.Month,
                    date.Day, 0,
                    0, 0, timeSpan);
            }

            return (now, now, now.AddDays(1), now.AddDays(1));
        }

        public static (DateTimeOffset? BeforeFromDate, DateTimeOffset? BeforeToDate, DateTimeOffset? AfterFromDate,
            DateTimeOffset? AfterToDate) GetWeeklyIntervalDays(DateTimeOffset? startDate = null)
        {
            var timeSpan = new TimeSpan(8, 0, 0);
            var now = new DateTimeOffset(DateTimeOffset.Now.Year, DateTimeOffset.Now.Month,
                DateTimeOffset.Now.Day, 0,
                0, 0, timeSpan);

            if (startDate != null)
            {
                var date = startDate.Value.ToOffset(timeSpan);
                now = new(date.Year, date.Month,
                    date.Day, 0,
                    0, 0, timeSpan);
            }

            return (now,
                now.Subtract(new TimeSpan((int) now.DayOfWeek - 7, 0, 0, 0)),
                now.Subtract(new TimeSpan((int) now.DayOfWeek - 8, 0, 0, 0)),
                now.Subtract(new TimeSpan((int) now.DayOfWeek - 14, 0, 0, 0)));
        }

        public static (DateTimeOffset? BeforeFromDate, DateTimeOffset? BeforeToDate, DateTimeOffset? AfterFromDate,
            DateTimeOffset? AfterToDate) GetMonthlyIntervalDays(DateTimeOffset? startDate = null)
        {
            var timeSpan = new TimeSpan(8, 0, 0);
            var now = new DateTimeOffset(DateTimeOffset.Now.Year, DateTimeOffset.Now.Month,
                DateTimeOffset.Now.Day, 0,
                0, 0, timeSpan);

            if (startDate != null)
            {
                var date = startDate.Value.ToOffset(timeSpan);
                now = new(date.Year, date.Month,
                    date.Day, 0,
                    0, 0, timeSpan);
            }

            var nextMonth = now.AddMonths(1);
            var nextNextMonth = now.AddMonths(2);
            var nextMonthFirstDay = new DateTimeOffset(nextMonth.Year, nextMonth.Month, 1, 0, 0, 0, timeSpan);
            var nextNextMonthFirstDay =
                new DateTimeOffset(nextNextMonth.Year, nextNextMonth.Month, 1, 0, 0, 0, timeSpan);
            return (now,
                nextMonthFirstDay.AddDays(-1),
                nextMonthFirstDay,
                nextNextMonthFirstDay.AddDays(-1));
        }
    }
}