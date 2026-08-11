namespace OOP_Assignment_1.Struct
{
    #region Question 01
    internal struct DeliveryAddress
    {
        #region Attributes
        public string? City;
        public string? Street;
        public int BuildingNumber;
        #endregion

        #region Constructor
        public DeliveryAddress(string? city, string? street, int buildingNumber)
        {
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
        }
        #endregion

        #region Methods
        public string GetFullAddress()
        {
            return $"{BuildingNumber} {Street}, {City}";
        }

        public override string ToString()
        {
            return GetFullAddress();
        }
        #endregion
    }
    #endregion
}
