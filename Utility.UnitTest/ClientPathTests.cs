using System;
using NUnit.Framework;
using Tgs.Core.Infrastructures.Utility;

namespace Utility.UnitTest
{
    [TestFixture]
    public class ClientPathTests
    {
        [Test]
        public void Client_Should_Process_Nullable_DateTimeOffset()
        {
            var parameter = new
            {
                Time = (DateTimeOffset?) new DateTimeOffset(
                    2021,
                    6,
                    2,
                    0,
                    0,
                    0,
                    TimeSpan.Zero)
            };

            var expected = "Time=2021-06-02T00:00:00.00Z";

            var actual = ClientPath.AppendWithProperties(string.Empty, parameter);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}