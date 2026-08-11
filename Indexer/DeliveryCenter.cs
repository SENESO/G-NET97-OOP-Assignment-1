using OOP_Assignment_1.Encapsulation;

namespace OOP_Assignment_1.Indexer
{
    #region Question 05
    internal struct DeliveryCenter
    {
        #region Attributes
        private Shipment[]? shipments;
        private int currentCount;
        #endregion

        #region Properties
        public int Count => currentCount;
        #endregion

        #region Constructor
        public DeliveryCenter(int capacity)
        {
            shipments = new Shipment[capacity];
            currentCount = 0;
        }
        #endregion

        #region Indexer
        public Shipment this[int index]
        {
            get
            {
                if (shipments == null || index < 0 || index >= currentCount)
                    return default;
                return shipments[index];
            }
            set
            {
                if (shipments != null && index >= 0 && index < currentCount)
                {
                    shipments[index] = value;
                }
            }
        }

        public Shipment this[string? trackingCode]
        {
            get
            {
                if (shipments != null && trackingCode != null)
                {
                    for (int i = 0; i < currentCount; i++)
                    {
                        if (shipments[i].TrackingCode == trackingCode)
                            return shipments[i];
                    }
                }
                return default;
            }
        }
        #endregion

        #region Methods
        public bool AddShipment(Shipment shipment)
        {
            if (shipments == null)
            {
                shipments = new Shipment[10];
                currentCount = 0;
            }

            if (currentCount < shipments.Length)
            {
                shipments[currentCount] = shipment;
                currentCount++;
                return true;
            }
            return false;
        }
        #endregion
    }
    #endregion
}
