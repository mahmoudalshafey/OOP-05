using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_05
{
    internal class InternationalShipment : Shipment, ITrackable, IInsurable
    {
        private string _destinationCountry;
        private decimal _customsFee;

        public string DestinationCountry
        {
            get => _destinationCountry;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _destinationCountry = value;
            }
        }

        public decimal CustomsFee
        {
            get => _customsFee;
            set
            {
                if (value >= 0)
                    _customsFee = value;
            }
        }

        public InternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, string destinationCountry, decimal customsFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }

        public override decimal EstimatedCost => DeliveryFee + (Weight * 5) + CustomsFee;

        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine($"Customs report for {TrackingCode}: destination {DestinationCountry}, customs fee {CustomsFee} EGP.");
        }

        public override void PrintShipment()
        {
            Console.WriteLine("International Shipment");
            Console.WriteLine();
            Console.WriteLine($"Tracking Code        : {TrackingCode}");
            Console.WriteLine($"Description          : {Description}");
            Console.WriteLine($"Weight               : {Weight} KG");
            Console.WriteLine($"Delivery Fee         : {DeliveryFee} EGP");
            Console.WriteLine($"Destination Country  : {DestinationCountry}");
            Console.WriteLine($"Customs Fee          : {CustomsFee} EGP");
            Console.WriteLine($"Estimated Cost       : {EstimatedCost} EGP");
        }

        public string GetTrackingStatus() => $"Shipment {TrackingCode} has been Delivered.";

        public decimal CalculateInsurance() => EstimatedCost * 0.12m;
    }
}
