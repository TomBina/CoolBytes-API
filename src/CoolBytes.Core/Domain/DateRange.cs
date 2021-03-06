﻿using System;

namespace CoolBytes.Core.Domain
{
    public class DateRange
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public TimeSpan Time => StartDate - EndDate;

        public DateRange(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public void Update(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        private DateRange()
        {
            
        }
    }
}