using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_05
{
    internal class CompletedShipment : Shipment, ITrackable, IInsurable
    {
        public CompletedShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }

        public override decimal EstimatedCost => DeliveryFee + (Weight * 5);

        public override void PrintShipment()
        {
            Console.WriteLine("Completed Shipment");
            Console.WriteLine();
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description   : {Description}");
            Console.WriteLine($"Weight        : {Weight} KG");
            Console.WriteLine($"Delivery Fee  : {DeliveryFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
            Console.WriteLine("Status        : Completed");
        }

        public string GetTrackingStatus() => $"Shipment {TrackingCode} has been Completed.";

        public decimal CalculateInsurance() => EstimatedCost * 0.05m;
    }
}
