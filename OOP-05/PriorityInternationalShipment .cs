using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_05
{
    internal class PriorityInternationalShipment : InternationalShipment
    {
        public PriorityInternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, string destinationCountry, decimal customsFee)
            : base(trackingCode, description, weight, deliveryFee, destination, destinationCountry, customsFee)
        {
        }
        public sealed override void GenerateCustomsReport()
        {
            Console.WriteLine($"[PRIORITY] Customs report for {TrackingCode}: destination {DestinationCountry}, " +
                               $"customs fee {CustomsFee} EGP. Processed with priority handling.");
        }
    }
}
