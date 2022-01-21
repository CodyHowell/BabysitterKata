using System;

namespace BabysitterKata
{
    public class BabysitterService
    {
        /// <summary>
        /// Will calculate a night of work as a babysitter with the following conditions:
        /// - starts no earlier than 5:00PM (any work done before this will not be paid for)
        /// - leaves no later than 4:00AM (any work done after this will not be paid for)
        /// - gets paid $12/hour from start-time to bedtime
        /// - gets paid $8/hour from bedtime to midnight
        /// - gets paid $16/hour from midnight to end of job
        /// - gets paid for full hours(no fractional hours) (time worked every pay period ie. start-bedtime will be rounded down)
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="bedtime"></param>
        /// <param name="startToBedtimePay"></param>
        /// <param name="bedtimeToMidnightPay"></param>
        /// <param name="midnightToEndPay"></param>
        /// <returns>Amount of money to be charged for night of work</returns>
        public decimal CalculateNightlyCharge(DateTime startTime, DateTime endTime, DateTime bedtime, decimal startToBedtimePay = 12.00m, decimal bedtimeToMidnightPay = 8.00m, decimal midnightToEndPay = 16.00m)
        {
            if (EndTimeBeforeOrSameAsStartTime(startTime, endTime))
                return 0.00m;

            var midnight = DetermineClosestMidnight(startTime);

            var updatedStartTime = CorrectStartTime(startTime);
            var updatedEndTime = CorrectEndTime(endTime);

            if (StartTimeAfterMidnight(updatedStartTime, midnight))
            {
                return CalculateTimePeriodSubtotal(updatedStartTime, updatedEndTime, midnightToEndPay);
            }

            if (BedtimeAfterEndTime(bedtime, endTime))
            {
                return CalculatePayBedTimeAfterEndTime(startTime, endTime, midnight, startToBedtimePay, midnightToEndPay);
            }

            if (StartTimeBeforeBedtime(updatedStartTime, bedtime))
            {
                return CalculatePayStartTimeBeforeBedtime(updatedStartTime, updatedEndTime, bedtime, midnight, startToBedtimePay, bedtimeToMidnightPay, midnightToEndPay);
            }
            else
            {
                return CalculatePayStartTimeAfterBedtime(updatedStartTime, updatedEndTime, bedtime, midnight, bedtimeToMidnightPay, midnightToEndPay);
            }
        }

        private decimal CalculatePayStartTimeBeforeBedtime(DateTime startTime, DateTime endTime, DateTime bedtime, DateTime midnight, decimal startToBedtimePay, decimal bedtimeToMidnightPay, decimal midnightToEndPay)
        {
            var runningPayTotal = 0.00m;
            runningPayTotal += CalculateTimePeriodSubtotal(startTime, bedtime, startToBedtimePay);

            if (EndTimeBeforeMidnight(endTime, midnight))
            {
                runningPayTotal += CalculateTimePeriodSubtotal(bedtime, endTime, bedtimeToMidnightPay);
            }
            else
            {
                runningPayTotal += CalculateTimePeriodSubtotal(bedtime, midnight, bedtimeToMidnightPay);
                runningPayTotal += CalculateTimePeriodSubtotal(midnight, endTime, midnightToEndPay);
            }

            return runningPayTotal;
        }

        private decimal CalculatePayBedTimeAfterEndTime(DateTime startTime, DateTime endTime, DateTime midnight, decimal startToBedtimePay, decimal midnightToEndPay)
        {
            var runningPayTotal = 0.00m;

            if (EndTimeBeforeMidnight(endTime, midnight))
            {
                runningPayTotal += CalculateTimePeriodSubtotal(startTime, endTime, startToBedtimePay);
            }
            else
            {
                runningPayTotal += CalculateTimePeriodSubtotal(startTime, midnight, startToBedtimePay);
                runningPayTotal += CalculateTimePeriodSubtotal(midnight, endTime, midnightToEndPay);
            }

            return runningPayTotal;
        }

        private decimal CalculatePayStartTimeAfterBedtime(DateTime startTime, DateTime endTime, DateTime bedtime, DateTime midnight, decimal bedtimeToMidnightPay, decimal midnightToEndPay)
        {
            var runningPayTotal = 0.00m;
            if (EndTimeBeforeMidnight(endTime, midnight))
            {
                runningPayTotal += CalculateTimePeriodSubtotal(startTime, endTime, bedtimeToMidnightPay);
            }
            else
            {
                runningPayTotal += CalculateTimePeriodSubtotal(startTime, midnight, bedtimeToMidnightPay);
                runningPayTotal += CalculateTimePeriodSubtotal(midnight, endTime, midnightToEndPay);
            }

            return runningPayTotal;
        }

        private decimal CalculateTimePeriodSubtotal(DateTime timePeriodStart, DateTime timePeriodEnd, decimal timePeriodPay)
        {
            var hoursWorked = timePeriodEnd.Subtract(timePeriodStart);
            var fullHoursWorked = Convert.ToInt32(Math.Floor(hoursWorked.TotalHours));
            return fullHoursWorked * timePeriodPay;
        }

        /// <summary>
        /// The closest midnight is relavent in the event that the babysitter needs to come after
        /// midnight. This method ensures that the correct day of midnight is being used for the calculations.
        /// </summary>
        private DateTime DetermineClosestMidnight(DateTime startTime)
        {
            if (startTime.Subtract(startTime.Date).TotalHours < 12)
                return startTime.Date;
            else
                return startTime.AddDays(1).Date;
        }

        private bool EndTimeBeforeMidnight(DateTime endTime, DateTime midnight)
        {
            return endTime.CompareTo(midnight) < 0;
        }

        private bool StartTimeBeforeBedtime(DateTime startTime, DateTime bedtime)
        {
            return startTime.CompareTo(bedtime) < 0;
        }

        private bool StartTimeAfterMidnight(DateTime startTime, DateTime midnight)
        {
            return startTime.CompareTo(midnight) > 0;
        }

        private bool EndTimeBeforeOrSameAsStartTime(DateTime startTime, DateTime endTime)
        {
            return startTime.CompareTo(endTime) >= 0;
        }

        private bool BedtimeAfterEndTime(DateTime bedtime, DateTime endTime)
        {
            return bedtime.CompareTo(endTime) > 0;
        }

        private DateTime CorrectStartTime(DateTime startTime)
        {
            if (startTime.Hour < 4 || startTime.Hour >= 17)
                return startTime;

            return UpdateDateTimeHour(startTime, 17);
        }

        private DateTime CorrectEndTime(DateTime endTime)
        {
            if (endTime.Hour <= 4 || endTime.Hour > 17)
                return endTime;

            return UpdateDateTimeHour(endTime, 4);
        }

        private DateTime UpdateDateTimeHour(DateTime originalDateTime, int hourToUpdateTo)
        {
            return new DateTime(originalDateTime.Year,
                month: originalDateTime.Month,
                day: originalDateTime.Day,
                hour: hourToUpdateTo,
                minute: 0,
                second: 0);
        }
    }
}
