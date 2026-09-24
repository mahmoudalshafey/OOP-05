using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_05
{
    internal class DeliveryCenter
    {
        private const int MaxCapacity = 20;
        private readonly Shipment[] _shipments = new Shipment[MaxCapacity];
        private int _count = 0;

        public string CenterName { get; set; }

        public Driver Driver { get; set; }

        public DeliveryCenter(string centerName)
        {
            CenterName = centerName;
        }

        public Shipment this[int index]
        {
            get
            {
                if (index >= 0 && index < _count)
                    return _shipments[index];
                return default;
            }
            set
            {
                if (index >= 0 && index < _count)
                    _shipments[index] = value;
            }
        }

        public Shipment this[string trackingCode]
        {
            get
            {
                for (int i = 0; i < _count; i++)
                {
                    if (_shipments[i].TrackingCode == trackingCode)
                        return _shipments[i];
                }
                return default;
            }
        }

        public bool AddShipment(Shipment shipment)
        {
            if (_count >= MaxCapacity)
                return false;

            _shipments[_count] = shipment;
            _count++;
            return true;
        }

        public bool RemoveShipment(string trackingCode)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_shipments[i].TrackingCode == trackingCode)
                {
                    for (int j = i; j < _count - 1; j++)
                        _shipments[j] = _shipments[j + 1];

                    _shipments[_count - 1] = null;
                    _count--;
                    return true;
                }
            }
            return false;
        }

        public void PrintAllShipments()
        {
            for (int i = 0; i < _count; i++)
            {
                _shipments[i].PrintShipment();
                Console.WriteLine(new string('-', 42));
            }
        }
        public void PrintTrackingStatuses()
        {
            for (int i = 0; i < _count; i++)
            {
                if (_shipments[i] is ITrackable trackable)
                    Console.WriteLine(trackable.GetTrackingStatus());
            }
        }
    }
}
