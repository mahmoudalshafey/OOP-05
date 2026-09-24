using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_05
{
    internal abstract partial class Shipment
    {
        private string _trackingStatus = "In Transit";
        public string TrackingStatus => _trackingStatus;
        public string GetTrackingStatus() => $"Shipment {TrackingCode} is {_trackingStatus}.";

        public void UpdateTrackingStatus(string newStatus)
        {
            if (string.IsNullOrWhiteSpace(newStatus) || newStatus == _trackingStatus)
                return;

            _trackingStatus = newStatus;
            OnTrackingStatusChanged(newStatus);
        }
        partial void OnTrackingStatusChanged(string newStatus);
    }
}
