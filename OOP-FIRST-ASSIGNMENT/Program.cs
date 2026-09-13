//Part 1
//1st answer
/* a) the struct is copy so changing or modifying will not affect the original value
 * b) if you said that customer.Name = "ALi" then it will become the name */

//2nd answer
/* a) first the parameters can be accessed directly , second no validation , third the internal data is exposed
 * b) by using private fields and public properties it will make you access the data through those properties */

//Part 2
//Smart Delivery Management System
using System;

public struct DeliveryAddress
{
    public string City;
    public string Street;
    public int BuildingNumber;

    
    public DeliveryAddress(string city, string street, int buildingNumber)
    {
        City = city;
        Street = street;
        BuildingNumber = buildingNumber;
    }

    
    public string GetFullAddress()
    {
        return City + ", " + Street + ", Building " + BuildingNumber;
    }
}


public struct Shipment
{
    
    private string trackingCode;
    private string description;
    private double weight;
    private decimal deliveryFee;

    
    public string TrackingCode
    {
        get { return trackingCode; }
        private set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                trackingCode = value;
            }
        }
    }

   
    public string Description
    {
        get { return description; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                description = value;
            }
        }
    }

    
    public double Weight
    {
        get { return weight; }
        set
        {
            if (value > 0)
            {
                weight = value;
            }
        }
    }

    
    public decimal DeliveryFee
    {
        get { return deliveryFee; }
        private set
        {
            if (value > 0)
            {
                deliveryFee = value;
            }
        }
    }

   
    public DeliveryAddress Destination { get; set; }

   
    public decimal EstimatedCost
    {
        get
        {
            return DeliveryFee + ((decimal)Weight * 5);
        }
    }


    public Shipment(string trackingCode)
    {
        this.trackingCode = "UNKNOWN";
        description = "Unknown";
        weight = 1;
        deliveryFee = 50;

        Destination = new DeliveryAddress(
            "Unknown",
            "Unknown",
            0
        );

        if (!string.IsNullOrWhiteSpace(trackingCode))
        {
            this.trackingCode = trackingCode;
        }
    }


    public Shipment(
        string trackingCode,
        string description,
        double weight,
        decimal deliveryFee,
        DeliveryAddress destination)
    {
      
        this.trackingCode = "UNKNOWN";
        this.description = "Unknown";
        this.weight = 1;
        this.deliveryFee = 50;
        Destination = destination;

        
        if (!string.IsNullOrWhiteSpace(trackingCode))
        {
            this.trackingCode = trackingCode;
        }

        if (!string.IsNullOrWhiteSpace(description))
        {
            this.description = description;
        }

        if (weight > 0)
        {
            this.weight = weight;
        }

        if (deliveryFee > 0)
        {
            this.deliveryFee = deliveryFee;
        }
    }


    
    public void UpdateDeliveryFee(decimal newFee)
    {
        if (newFee > 0)
        {
            DeliveryFee = newFee;
        }
    }


   
    public void PrintShipment()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Tracking Code: " + TrackingCode);
        Console.WriteLine("Description: " + Description);
        Console.WriteLine("Weight: " + Weight);
        Console.WriteLine("Delivery Fee: " + DeliveryFee);
        Console.WriteLine("Destination: " + Destination.GetFullAddress());
        Console.WriteLine("Estimated Cost: " + EstimatedCost);
        Console.WriteLine("--------------------------------");
    }
}


public struct DeliveryCenter
{
    private Shipment[] shipments;

  
    public DeliveryCenter()
    {
        shipments = new Shipment[10];
    }


    
    public Shipment this[int index]
    {
        get
        {
            if (index >= 0 && index < shipments.Length)
            {
                return shipments[index];
            }

            return default;
        }

        set
        {
            if (index >= 0 && index < shipments.Length)
            {
                shipments[index] = value;
            }
        }
    }


    public Shipment this[string trackingCode]
    {
        get
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i].TrackingCode == trackingCode)
                {
                    return shipments[i];
                }
            }

            return default;
        }
    }


    public bool AddShipment(Shipment shipment)
    {
        for (int i = 0; i < shipments.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(shipments[i].TrackingCode))
            {
                shipments[i] = shipment;
                return true;
            }
        }

        return false;
    }
}


class Program
{
    static void Main()
    {
      

        DeliveryCenter center = new DeliveryCenter();


      

        Console.WriteLine("Enter information for Shipment 1:");

        Console.Write("Tracking Code: ");
        string trackingCode1 = Console.ReadLine();

        Console.Write("Description: ");
        string description1 = Console.ReadLine();

        Console.Write("Weight: ");
        double weight1 = double.Parse(Console.ReadLine());

        Console.Write("Delivery Fee: ");
        decimal fee1 = decimal.Parse(Console.ReadLine());

        Console.Write("City: ");
        string city1 = Console.ReadLine();

        Console.Write("Street: ");
        string street1 = Console.ReadLine();

        Console.Write("Building Number: ");
        int building1 = int.Parse(Console.ReadLine());

        DeliveryAddress address1 =
            new DeliveryAddress(city1, street1, building1);

        Shipment shipment1 =
            new Shipment(
                trackingCode1,
                description1,
                weight1,
                fee1,
                address1
            );

        center.AddShipment(shipment1);



        Console.WriteLine("\nEnter information for Shipment 2:");

        Console.Write("Tracking Code: ");
        string trackingCode2 = Console.ReadLine();

        Console.Write("Description: ");
        string description2 = Console.ReadLine();

        Console.Write("Weight: ");
        double weight2 = double.Parse(Console.ReadLine());

        Console.Write("Delivery Fee: ");
        decimal fee2 = decimal.Parse(Console.ReadLine());

        Console.Write("City: ");
        string city2 = Console.ReadLine();

        Console.Write("Street: ");
        string street2 = Console.ReadLine();

        Console.Write("Building Number: ");
        int building2 = int.Parse(Console.ReadLine());

        DeliveryAddress address2 =
            new DeliveryAddress(city2, street2, building2);

        Shipment shipment2 =
            new Shipment(
                trackingCode2,
                description2,
                weight2,
                fee2,
                address2
            );

        center.AddShipment(shipment2);


        Console.WriteLine("\nEnter information for Shipment 3:");

        Console.Write("Tracking Code: ");
        string trackingCode3 = Console.ReadLine();

        Console.Write("Description: ");
        string description3 = Console.ReadLine();

        Console.Write("Weight: ");
        double weight3 = double.Parse(Console.ReadLine());

        Console.Write("Delivery Fee: ");
        decimal fee3 = decimal.Parse(Console.ReadLine());

        Console.Write("City: ");
        string city3 = Console.ReadLine();

        Console.Write("Street: ");
        string street3 = Console.ReadLine();

        Console.Write("Building Number: ");
        int building3 = int.Parse(Console.ReadLine());

        DeliveryAddress address3 =
            new DeliveryAddress(city3, street3, building3);

        Shipment shipment3 =
            new Shipment(
                trackingCode3,
                description3,
                weight3,
                fee3,
                address3
            );

        center.AddShipment(shipment3);



        Console.WriteLine("\n===== ALL SHIPMENTS =====");

        center[0].PrintShipment();
        center[1].PrintShipment();
        center[2].PrintShipment();


       

        Console.Write("\nEnter a tracking code to search: ");
        string searchCode = Console.ReadLine();

        Shipment foundShipment = center[searchCode];


        

        if (!string.IsNullOrWhiteSpace(foundShipment.TrackingCode))
        {
            Console.WriteLine("\nShipment found:");
            foundShipment.PrintShipment();
        }
        else
        {
            Console.WriteLine("Shipment not found.");
        }


       

        Console.WriteLine("\n===== STRUCT COPY DEMONSTRATION =====");

        DeliveryAddress original =
            new DeliveryAddress("Cairo", "Tahrir Street", 10);

        DeliveryAddress copy = original;

        // Modify the copy
        copy.City = "Giza";
        copy.BuildingNumber = 20;

        Console.WriteLine("Original:");
        Console.WriteLine(original.GetFullAddress());

        Console.WriteLine("Copy:");
        Console.WriteLine(copy.GetFullAddress());
    }
}