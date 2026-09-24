using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_05
{
    internal class StandardShipment : Shipment, ITrackable, IInsurable
    {
        // Constructor chaining: no extra members, just forwards to Shipment's base(...).
        public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }

        public override decimal EstimatedCost => DeliveryFee + (Weight * 5);

        public override void PrintShipment()
        {
            Console.WriteLine("Standard Shipment");
            Console.WriteLine();
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description   : {Description}");
            Console.WriteLine($"Weight        : {Weight} KG");
            Console.WriteLine($"Delivery Fee  : {DeliveryFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }

        public string GetTrackingStatus() => $"Shipment {TrackingCode} is Ready.";

        public decimal CalculateInsurance() => EstimatedCost * 0.05m;
    }
}
