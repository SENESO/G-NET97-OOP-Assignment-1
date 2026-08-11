using System;
using OOP_Assignment_1.Encapsulation;
using OOP_Assignment_1.Struct;
using OOP_Assignment_1.Indexer;

namespace OOP_Assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Question 06
            
            #region Indexer & Encapsulation
            
           
            DeliveryCenter center = new DeliveryCenter(10);

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Enter Shipment {i} Data");
                
                Console.Write("Tracking Code: ");
                string? tc = Console.ReadLine();
                
                Console.Write("Description: ");
                string? desc = Console.ReadLine();
                
                Console.Write("Weight: ");
                double.TryParse(Console.ReadLine(), out double weight);
                
                Console.Write("Delivery Fee: ");
                decimal.TryParse(Console.ReadLine(), out decimal fee);
                
                Console.Write("City: ");
                string? city = Console.ReadLine();
                
                Console.Write("Street: ");
                string? street = Console.ReadLine();
                
                Console.Write("Building Number: ");
                int.TryParse(Console.ReadLine(), out int building);

                DeliveryAddress address = new DeliveryAddress(city, street, building);
                

                Shipment s = new Shipment(tc, desc, weight, fee, address);
                
                if (center.AddShipment(s))
                {
                    Console.WriteLine("\nShipment added successfully.\n");
                }
            }


            Console.WriteLine("--- All Shipments");
            for (int i = 0; i < center.Count; i++)
            {
                Shipment s = center[i];
                s.PrintShipment();
                Console.WriteLine();
            }


            Console.Write("Enter a tracking code to search: ");
            string? searchCode = Console.ReadLine();


            Shipment found = center[searchCode];


            if (found.TrackingCode != null)
            {
                Console.WriteLine($"Shipment found: {found.TrackingCode} - {found.Description}");
            }
            else
            {
                Console.WriteLine("Shipment not found.");
            }
            Console.WriteLine();

            #endregion

            #region Struct 
            
         
            Console.WriteLine("--- Struct Copy Test ---");
            DeliveryAddress addr1 = new DeliveryAddress("Cairo", "Tahrir Street", 15);
            DeliveryAddress addr2 = addr1;
            
          
            addr2.BuildingNumber = 20;
            addr2.Street = "Makram Ebeid Street";
            
            Console.WriteLine($"Original Address: {addr1.GetFullAddress()}");
            Console.WriteLine($"Copied Address: {addr2.GetFullAddress()}");
            
            #endregion
            
            #endregion
        }
    }
}
