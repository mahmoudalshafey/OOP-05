using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_05
{
    internal class ExpressShipment : Shipment, ITrackable, IInsurable
    {
        private decimal _extraFee;

        public decimal ExtraFee
        {
            get => _extraFee;
            set
            {
                if (value >= 0)
                    _extraFee = value;
            }
        }

        public ExpressShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, decimal extraFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extraFee;
        }

        public override decimal EstimatedCost => DeliveryFee + (Weight * 5) + ExtraFee;

        public override void PrintShipment()
        {
            Console.WriteLine("Express Shipment");
            Console.WriteLine();
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description   : {Description}");
            Console.WriteLine($"Weight        : {Weight} KG");
            Console.WriteLine($"Delivery Fee  : {DeliveryFee} EGP");
            Console.WriteLine($"Extra Fee     : {ExtraFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }

        public string GetTrackingStatus() => $"Shipment {TrackingCode} is Out for Delivery.";

        public decimal CalculateInsurance() => EstimatedCost * 0.08m;
    }
}
