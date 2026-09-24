using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_05
{
    internal abstract class Shipment
    {
        private string _trackingCode;
        private string _description;
        private decimal _weight;
        private decimal _deliveryFee;

        // Read-only from outside the class (public get, private set).
        public string TrackingCode
        {
            get => _trackingCode;
            private set => _trackingCode = value;
        }

        // Read/write with validation: cannot be null, empty or whitespace.
        // Invalid values are silently ignored and the previous valid value is kept.
        public string Description
        {
            get => _description;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _description = value;
            }
        }

        // Read/write with validation: must be greater than 0.
        public decimal Weight
        {
            get => _weight;
            set
            {
                if (value > 0)
                    _weight = value;
            }
        }

        // Public getter, private setter, validated internally (> 0).
        public decimal DeliveryFee
        {
            get => _deliveryFee;
            private set
            {
                if (value > 0)
                    _deliveryFee = value;
            }
        }

        // Public read/write property.
        public DeliveryAddress Destination { get; set; }

        // Abstract: each derived type supplies its own cost formula.
        // Must NOT be backed by a stored field - it is calculated on request.
        public abstract decimal EstimatedCost { get; }

        // Constructor 1: only the tracking code is supplied.
        // Uses default values: Description = "Unknown", Weight = 1, DeliveryFee = 50,
        // and a default destination.
        protected Shipment(string trackingCode)
            : this(trackingCode, "Unknown", 1m, 50m, new DeliveryAddress("Unknown City", "Unknown Street", 0))
        {
        }

        // Constructor 2: full set of values supplied by the caller.
        protected Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
        {
            _trackingCode = string.IsNullOrWhiteSpace(trackingCode) ? "UNKNOWN" : trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = destination;
        }

        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
                DeliveryFee = newFee;
        }

        // Overload 1: simply updates the shipment weight.
        public void UpdateWeight(decimal newWeight)
        {
            Weight = newWeight;
        }

        // Overload 2: updates the weight after adding extra packing weight.
        public void UpdateWeight(decimal newWeight, decimal extraPackingWeight)
        {
            Weight = newWeight + extraPackingWeight;
        }

        // Abstract: every derived type prints its own information.
        public abstract void PrintShipment();
    }
}
