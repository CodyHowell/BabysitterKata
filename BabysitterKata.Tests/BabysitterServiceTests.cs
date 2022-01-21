using NUnit.Framework;
using System;

namespace BabysitterKata.Tests
{
    public class BabysitterServiceTests
    {
        private BabysitterService _babysitterService;

        [SetUp]
        public void Setup()
        {
            _babysitterService = new BabysitterService();
        }

        [Test]
        public void CalculateNightlyCharge_StartTimeBeforeBedtime_EndtimeAfterMidnight()
        {
            var startDate = DateTime.Parse("1/20/2022 18:00:00");
            var endDate = DateTime.Parse("1/21/2022 02:00:00");
            var bedtimeDate = DateTime.Parse("1/20/2022 22:00:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 96m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }

        [Test]
        public void CalculateNightlyCharge_StartTimeBeforeBedtime_EndtimeAfterMidnight_FractionalHours()
        {
            var startDate = DateTime.Parse("1/20/2022 17:30:00");
            var endDate = DateTime.Parse("1/21/2022 01:45:00");
            var bedtimeDate = DateTime.Parse("1/20/2022 19:20:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 60m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }

        [Test]
        public void CalculateNightlyCharge_StartTimeBeforeBedtime_EndtimeBeforeMidnight()
        {
            var startDate = DateTime.Parse("1/20/2022 18:00:00");
            var endDate = DateTime.Parse("1/20/2022 23:00:00");
            var bedtimeDate = DateTime.Parse("1/20/2022 22:00:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 56m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }

        [Test]
        public void CalculateNightlyCharge_StartTimeBeforeBedtime_EndtimeBeforeMidnight_FractionalHours()
        {
            var startDate = DateTime.Parse("1/20/2022 17:30:00");
            var endDate = DateTime.Parse("1/20/2022 23:30:00");
            var bedtimeDate = DateTime.Parse("1/20/2022 22:00:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 56m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }

        [Test]
        public void CalculateNightlyCharge_StartTimeAfterBedtime_EndtimeBeforeMidnight()
        {
            var startDate = DateTime.Parse("1/20/2022 18:00:00");
            var endDate = DateTime.Parse("1/20/2022 23:00:00");
            var bedtimeDate = DateTime.Parse("1/20/2022 17:00:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 40m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }

        [Test]
        public void CalculateNightlyCharge_StartTimeAfterBedtime_EndTimeBeforeMidnight_FractionalHours()
        {
            var startDate = DateTime.Parse("1/20/2022 17:30:00");
            var endDate = DateTime.Parse("1/20/2022 23:00:00");
            var bedtimeDate = DateTime.Parse("1/20/2022 17:00:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 40m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }

        [Test]
        public void CalculateNightlyCharge_StartTimeAfterBedtime_StartTimeAfterMidnight()
        {
            var startDate = DateTime.Parse("1/21/2022 01:00:00");
            var endDate = DateTime.Parse("1/21/2022 03:00:00");
            var bedtimeDate = DateTime.Parse("1/20/2022 17:00:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 32m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }

        [Test]
        public void CalculateNightlyCharge_StartTimeAfterBedtime_EndtimeAfterMidnight()
        {
            var startDate = DateTime.Parse("1/20/2022 18:00:00");
            var endDate = DateTime.Parse("1/21/2022 03:00:00");
            var bedtimeDate = DateTime.Parse("1/20/2022 17:00:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 96m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }

        [Test]
        public void CalculateNightlyCharge_StartTimeAfterBedtime_EndtimeAfterMidnight_FractionalHours()
        {
            var startDate = DateTime.Parse("1/20/2022 18:30:00");
            var endDate = DateTime.Parse("1/21/2022 03:45:00");
            var bedtimeDate = DateTime.Parse("1/20/2022 17:00:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 88m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }

        [Test]
        public void CalculateNightlyCharge_StartTimeAfterMidnight_StartTimeAfterBedtime()
        {
            var startDate = DateTime.Parse("1/21/2022 01:00:00");
            var endDate = DateTime.Parse("1/21/2022 03:00:00");
            var bedtimeDate = DateTime.Parse("1/20/2022 17:00:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 32m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }

        [Test]
        public void CalculateNightlyCharge_StartTimeAfterMidnight_StartTimeAfterBedtime_FractionalHours()
        {
            var startDate = DateTime.Parse("1/21/2022 01:30:00");
            var endDate = DateTime.Parse("1/21/2022 03:45:00");
            var bedtimeDate = DateTime.Parse("1/20/2022 17:00:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 32m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }

        [Test]
        public void CalculateNightlyCharge_StartTimeAfterMidnight_StartTimeBeforeBedtime()
        {
            var startDate = DateTime.Parse("1/21/2022 01:00:00");
            var endDate = DateTime.Parse("1/21/2022 03:00:00");
            var bedtimeDate = DateTime.Parse("1/21/2022 02:00:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 32m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }

        [Test]
        public void CalculateNightlyCharge_StartTimeAfterMidnight_StartTimeBeforeBedtime_FractionalHours()
        {
            var startDate = DateTime.Parse("1/21/2022 01:30:00");
            var endDate = DateTime.Parse("1/21/2022 03:45:00");
            var bedtimeDate = DateTime.Parse("1/21/2022 02:15:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 32m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }

        [Test]
        public void CalculateNightlyCharge_BedtimeAfterEndTime()
        {
            var startDate = DateTime.Parse("1/20/2022 17:00:00");
            var endDate = DateTime.Parse("1/20/2022 19:00:00");
            var bedtimeDate = DateTime.Parse("1/20/2022 20:00:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 24m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }

        [Test]
        public void CalculateNightlyCharge_BedtimeAfterEndTime_FractionalHours()
        {
            var startDate = DateTime.Parse("1/20/2022 17:30:00");
            var endDate = DateTime.Parse("1/20/2022 19:45:00");
            var bedtimeDate = DateTime.Parse("1/20/2022 20:00:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 24m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }


        [Test]
        public void CalculateNightlyCharge_BedtimeAfterEndTime_EndTimeAfterMidnight()
        {
            var startDate = DateTime.Parse("1/20/2022 19:00:00");
            var endDate = DateTime.Parse("1/21/2022 01:00:00");
            var bedtimeDate = DateTime.Parse("1/21/2022 02:00:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 76m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }

        [Test]
        public void CalculateNightlyCharge_BedtimeAfterEndTime_EndTimeAfterMidnight_FractionalHours()
        {
            var startDate = DateTime.Parse("1/20/2022 19:30:00");
            var endDate = DateTime.Parse("1/21/2022 01:25:00");
            var bedtimeDate = DateTime.Parse("1/21/2022 02:00:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 64m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }

        [Test]
        public void CalculateNightlyCharge_BedtimeAfterEndTime_StartTimeAfterMidnight()
        {
            var startDate = DateTime.Parse("1/21/2022 01:00:00");
            var endDate = DateTime.Parse("1/21/2022 03:00:00");
            var bedtimeDate = DateTime.Parse("1/21/2022 03:30:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 32m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }

        [Test]
        public void CalculateNightlyCharge_BedtimeAfterEndTime_StartTimeAfterMidnight_FractionalHours()
        {
            var startDate = DateTime.Parse("1/21/2022 01:30:00");
            var endDate = DateTime.Parse("1/21/2022 03:45:00");
            var bedtimeDate = DateTime.Parse("1/21/2022 03:46:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 32m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }

        [Test]
        public void CalculateNightlyCharge_StartTimeBeforeFivePM()
        {
            var startDate = DateTime.Parse("1/20/2022 14:30:00");
            var endDate = DateTime.Parse("1/20/2022 21:00:00");
            var bedtimeDate = DateTime.Parse("1/20/2022 19:00:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 40m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }

        [Test]
        public void CalculateNightlyCharge_EndTimeAfterFourAM()
        {
            var startDate = DateTime.Parse("1/20/2022 17:00:00");
            var endDate = DateTime.Parse("1/21/2022 05:00:00");
            var bedtimeDate = DateTime.Parse("1/20/2022 19:00:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 128m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }

        [Test]
        public void CalculateNightlyCharge_EndTimeBeforeStartTime()
        {
            var startDate = DateTime.Parse("1/20/2022 19:00:00");
            var endDate = DateTime.Parse("1/20/2022 18:00:00");
            var bedtimeDate = DateTime.Parse("1/20/2022 20:00:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 0m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }

        [Test]
        public void CalculateNightlyCharge_EndTimeSameAsStartTime()
        {
            var startDate = DateTime.Parse("1/20/2022 19:00:00");
            var endDate = DateTime.Parse("1/20/2022 19:00:00");
            var bedtimeDate = DateTime.Parse("1/20/2022 20:00:00");

            var actualNightCharge = _babysitterService.CalculateNightlyCharge(startDate, endDate, bedtimeDate);
            const decimal expectedNightCharge = 0m;

            Assert.AreEqual(expectedNightCharge, actualNightCharge);
        }
    }
}