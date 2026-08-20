using System;
using OOP_Assignment_1.Encapsulation;
using OOP_Assignment_1.Struct;
using OOP_Assignment_1.Indexer;

namespace OOP_Assignment_1
{
    #region Part 01 : Theoretical Questions
    /* 
    Part 01 : Theoretical Questions

    Question 1

    Consider the following code:
    public struct DeliveryAddress {
        public string City;
        public string Street;
    }

    public class Customer {
        public string Name;
    }

    a) What happens when a DeliveryAddress variable is copied into another variable and the copy is modified?
    Answer: Since `DeliveryAddress` is a struct (a value type), copying it creates a completely independent copy of the data. Modifying the copy will not affect the original variable.

    b) What happens when a Customer variable is copied into another variable and one variable modifies the object?
    Answer: Since `Customer` is a class (a reference type), copying the variable only copies the reference, not the actual object. Both variables will point to the same object in memory. If one variable is used to modify the object, the changes will be reflected when accessing the object through the other variable.


    Question 2

    Consider the following struct:
    public struct Shipment {
        public string Description; public double Weight; public decimal DeliveryFee;
    }

    a) Identify at least three problems with this design from an encapsulation perspective.
    Answer: 
    1. Lack of Control: The fields are public, meaning they can be accessed and modified directly from anywhere without any control.
    2. Lack of Validation: There is no validation when assigning values. For instance, `Weight` or `DeliveryFee` could be set to negative values, or `Description` could be set to null or empty, which might lead to invalid states.
    3. Exposing Internal Implementation: It exposes the internal representation of the data. If the internal data structure needs to change in the future, it would break any external code that depends directly on these public fields.

    b) How can private fields and public properties improve this design?
    Answer: By making the fields private and exposing them through public properties, we can add validation logic within the `set` accessors (e.g., ensuring `Weight` is greater than 0 before assigning it). Properties also allow us to make certain data read-only from the outside (by omitting the `set` accessor or making it private). This hides the internal state, ensures the object always remains in a valid state, and enforces true encapsulation.
    */
    #endregion

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
