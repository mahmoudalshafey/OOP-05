using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_05
{
    internal abstract partial class Shipment 
    {
        private string _trackingCode;
        private string _description;
        private decimal _weight;
        private decimal _deliveryFee;

        private static int _totalShipmentsCreated;


        public string TrackingCode
        {
            get => _trackingCode;
            private set => _trackingCode = value;
        }
        public string Description
        {
            get => _description;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _description = value;
            }
        }
        public decimal Weight
        {
            get => _weight;
            set
            {
                if (value > 0)
                    _weight = value;
            }
        }
        public decimal DeliveryFee
        {
            get => _deliveryFee;
            private set
            {
                if (value > 0)
                    _deliveryFee = value;
            }
        }
        public DeliveryAddress Destination { get; set; }

        public abstract decimal EstimatedCost { get; }
        protected Shipment(string trackingCode)
            : this(trackingCode, "Unknown", 1m, 50m, new DeliveryAddress("Unknown City", "Unknown Street", 0))
        {
        }
        protected Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
        {
            _trackingCode = string.IsNullOrWhiteSpace(trackingCode) ? "UNKNOWN" : trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = destination;
        }

        static Shipment()
        {
            _totalShipmentsCreated = 0;
            Console.WriteLine("Shipment System Initialized");
        }

        public static int GetTotalShipmentsCreated() => _totalShipmentsCreated;


        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
                DeliveryFee = newFee;
        }

        public void UpdateWeight(decimal newWeight)
        {
            Weight = newWeight;
        }
        public void UpdateWeight(decimal newWeight, decimal extraPackingWeight)
        {
            Weight = newWeight + extraPackingWeight;
        }
        public abstract void PrintShipment();

        public Shipment CopyShipment()
        {
            return (Shipment)MemberwiseClone();
        }

        public Shipment ShallowCopy()
        {
            return (Shipment)MemberwiseClone();
        }
        public Shipment DeepCopy()
        {
            Shipment clone = (Shipment)MemberwiseClone();
            clone.Destination = Destination.Clone();
            return clone;
        }
    }
}
