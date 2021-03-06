using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;

        //For NORMAL Rides

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

        /// <summary>
        /// Test case 2.1
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenInvoiceGenerated_thenShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.2, 2) };
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedSummary, invoiceSummary);
        }

        /// <summary>
        /// Test case 3.1
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenInvoiceGenerated_thenShouldReturnEnhancedInvoice()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.2, 2) };
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFares(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0, 15);
            Assert.AreEqual(expectedSummary, invoiceSummary);
        }

        /// <summary>
        /// Test case 4.1
        /// </summary>
        [Test]
        public void GivenUserName_ShouldReturnInvoice()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.2, 2) };
            RideRepository rideRepository = new RideRepository();
            string userName = "Bharath";
            rideRepository.AddRides(userName, rides);
            Ride[] rideData = rideRepository.GetRides(userName);
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFares(rideData);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0, 15);
            Assert.AreEqual(expectedSummary, invoiceSummary);
        }

        //For PREMIUM Rides

        /// <summary>
        /// Test case 5.1
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ForPremiumRides_ShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 40;
            Assert.AreEqual(expected, fare);
        }

        /// <summary>
        /// Test case 5.2
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ForPremiumRides_IfTotalFareLessthanMinFare_ShouldReturnMinimumFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 0.2;
            int time = 2;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 20;
            Assert.AreEqual(expected, fare);
        }

        /// <summary>
        /// Test case 5.3
        /// </summary>
        [Test]
        public void GivenMultipleRides_ForPremiumRides_WhenInvoiceGenerated_thenShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.2, 2) };
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 60.0);
            Assert.AreEqual(expectedSummary, invoiceSummary);
        }

        /// <summary>
        /// Test case 5.4
        /// </summary>
        [Test]
        public void GivenMultipleRides_ForPremiumRides_WhenInvoiceGenerated_thenShouldReturnEnhancedInvoice()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.2, 2) };
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFares(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 60.0, 30);
            Assert.AreEqual(expectedSummary, invoiceSummary);
        }

        /// <summary>
        /// Test case 5.5
        /// </summary>
        [Test]
        public void GivenUserName_ForPremiumRides_ShouldReturnInvoice()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.2, 2) };
            RideRepository rideRepository = new RideRepository();
            string userName = "Bharath";
            rideRepository.AddRides(userName, rides);
            Ride[] rideData = rideRepository.GetRides(userName);
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFares(rideData);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 60.0, 30);
            Assert.AreEqual(expectedSummary, invoiceSummary);
        }
    }
}