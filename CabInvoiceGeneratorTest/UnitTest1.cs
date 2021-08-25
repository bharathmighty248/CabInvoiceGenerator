using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;

        /// <summary>
        /// Test case 1.1
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }

        /// <summary>
        /// Test case 1.2
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_IfTotalFareLessthanMinFare_ShouldReturnMinimumFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 0.2;
            int time = 2;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 5;
            Assert.AreEqual(expected, fare);
        }

    }
}