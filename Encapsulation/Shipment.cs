using System;
using OOP_Assignment_1.Struct;

namespace OOP_Assignment_1.Encapsulation
{
    #region Question 02
    internal struct Shipment
    {
        #region Attributes
        private string? trackingCode;
        private string? description;
        private double weight;
        private decimal deliveryFee;
        #endregion

        #region Properties
        public string? TrackingCode
        {
            get { return trackingCode; }
        }

        public string? Description
        {
            get { return description; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    description = value;
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value > 0)
                    weight = value;
            }
        }

        public decimal DeliveryFee
        {
            get { return deliveryFee; }
            private set
            {
                if (value > 0)
                    deliveryFee = value;
            }
        }

        public DeliveryAddress Destination { get; set; }

        public decimal EstimatedCost
        {
            get { return DeliveryFee + (decimal)(Weight * 5); }
        }
        #endregion

        #region Question 02 - Constructor Overloading
        public Shipment(string? trackingCode)
        {
            this.trackingCode = string.IsNullOrWhiteSpace(trackingCode) ? "UNKNOWN" : trackingCode;
            this.description = "Unknown";
            this.weight = 1;
            this.deliveryFee = 50;
            this.Destination = default;
        }

        public Shipment(string? trackingCode, string? description, double weight, decimal deliveryFee, DeliveryAddress destination)
        {
            this.trackingCode = string.IsNullOrWhiteSpace(trackingCode) ? "UNKNOWN" : trackingCode;
            this.description = string.IsNullOrWhiteSpace(description) ? "Unknown" : description;
            this.weight = weight > 0 ? weight : 1;
            this.deliveryFee = deliveryFee > 0 ? deliveryFee : 50;
            this.Destination = destination;
        }
        #endregion

        #region Question 03 - Methods
        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
            {
                DeliveryFee = newFee;
            }
        }

        public void PrintShipment()
        {
            Console.WriteLine("---Tracking Code:");
            Console.WriteLine($"{TrackingCode} Description:");
            Console.WriteLine($"{Description} Weight: {Weight} KG");
            Console.WriteLine($"Delivery Fee: {DeliveryFee} EGP");
            Console.WriteLine($"Destination: {Destination.GetFullAddress()}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }

        public override string ToString()
        {
            return $"Tracking Code: {TrackingCode}, Description: {Description}";
        }
        #endregion
    }
    #endregion
}
