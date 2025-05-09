using System;
using System.Globalization;

namespace InsuranceApp;

class Program
{
    //global variables
    static int numOfLaptops = 0, numOfDesktops = 0, numOfOther=0;
    static float totalInsurance = 0;
    static string mostExpensiveDevice;
    static float mostEpensiveCost = -1;
    static List<string> categories = new List<string>() { "Laptop", "Deskop", "Other" };

    //Checkint checks the method that Number enetered is valid and its betwen the min and the max. 
    //checkint
    static int CheckInt(string question,int min,int max)
    {
        while (true)

        {
            try
            {
                Console.WriteLine(question);
                int userInt = Convert.ToInt32(Console.ReadLine());

                if (userInt >= min && userInt <= max)
                {
                    return userInt;
                }

                Console.WriteLine($"Error: Number must be between {min} and {max}");
            }
            catch
            {
                Console.WriteLine("Eror: You must enter a valid number");
            }

        }

    }

    //Check float used to check that number is not less than 1 and  not more than 9999
    //checkfloat
    static float CheckCost()
    {
        while (true)

        {
            try
            {
                Console.WriteLine("Enter device cost");
                float userCost = float.Parse(Console.ReadLine());

                if (userCost >= 1 && userCost <= 9999)
                {
                    return userCost;
                }

                Console.WriteLine($"Error: Number must be between {1} and {9999}");
            }
            catch
            {
                Console.WriteLine("Eror: You must enter a valid number");
            }

        }

    }

    //Check name to make sure nothing is entered and to Eror`
    static string CheckName()
    {
        while (true)
        {
            string deviceName;
            Console.WriteLine("Enter Enter device name:\n");
            deviceName = Console.ReadLine().ToUpper();
           
            if (!deviceName.Equals(""))
            {
                return deviceName;
            }

            Console.WriteLine("Eror: Invalid Name entered");
        }
        

    }

    //Collects Device Data,Calculates insurance Cost and depreciation

    static void OneDevice()
    
    {
        string deviceName;
        deviceName = CheckName();
        //Device name user has to enter the device name



        //Device Cost

        float deviceCost = 0;



        deviceCost = CheckCost();
        //Number of devices

        int numberOfDevices;
        numberOfDevices = CheckInt("Enter number devices",1,449);
        //Category of devices

        int categoryOfdevices;
        ;
        categoryOfdevices = CheckInt("Choose the Category\n" +
        "1-laptop\n" +
       "2-desktop\n" +
       "3-other\n",1,3);

        
       
        if(categoryOfdevices == 1)
        {
            numOfLaptops += numberOfDevices;
        }
        if(categoryOfdevices == 2)
        {
            numOfDesktops += numberOfDevices;
        }
        if(categoryOfdevices == 3)
        {
            numOfOther += numberOfDevices;
        }
        //Insurance Discount
        // Insurancee Discount finds out there discount.
        float insuranceDiscount = 0.10f;
        float insuraneCost = 0;
        if (numberOfDevices < 6)
        {
            Console.WriteLine("full cost because there are less thatn 6");
            insuraneCost = deviceCost * numberOfDevices;
        }
        else
        {
            insuraneCost = deviceCost * 5;
            insuraneCost += (numberOfDevices - 5) * 0.9f;
        }
        Console.WriteLine($"Total cost for {numberOfDevices} x {deviceName} is = {(deviceCost*numberOfDevices).ToString("C", CultureInfo.CurrentCulture)} ");

        totalInsurance += insuraneCost;

        if  (deviceCost > mostEpensiveCost)
        {
            mostEpensiveCost = deviceCost;
            mostExpensiveDevice = deviceName;
        }



        //depressionOver6-months
        // finds out depression over 6 months and how much Money they have lost.
        float depressionOver6months;
        depressionOver6months = deviceCost;
        Console.WriteLine("Month\t\tvalue loss");
        for (int monthCounter = 1; monthCounter < 7; monthCounter++)
        {
            depressionOver6months = depressionOver6months * 0.95f;
            Console.WriteLine($"{monthCounter}\t\t{depressionOver6months.ToString("n2")} ");
        }
        Console.ReadLine();
        Console.WriteLine($"category: {categories[categoryOfdevices - 1]}");


    }
    //when the program runs thats when thr main method get called.
    static void Main(string[] args)
    {

        //Welcome message Welcome user to Insurance app.
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(".___                                                                             \n" +
 "|   | ____   ________ ______________    ____   ____  ____   _____  ______ ______  \n"+
 "|   |/    \\ /  ___/  |  \\_  __ \\__  \\  /    \\_/ ___\\/ __ \\  \\__  \\ \\____ \\____ \\ \n" +

 "|   |   |  \\ ___ \\|  |  /|  | \\// __ \\|   |  \\  \\__\\  ___/   / __ \\|  |_> >  |_> >\n" +

 "|___|___|  /____  >____/ |__|  (____  /___|  /\\___  >___  > (____  /   __/|   __/ \n" +

 "         \\/     \\/                  \\/     \\/     \\/    \\/       \\/|__|   |__|    "); 

        Console.ReadLine();

        string proceed = "";
        while (proceed.Equals("")) 
        {
            //call OneDevice Method
            OneDevice();


            //display message asking if user wants to add another device
            Console.WriteLine("Press Enter to add another device or type quit to stop");


            //store the user's response
            // used to store the responce.
            proceed = Console.ReadLine();
  
        }
        //NumberofLaptops needed Insurance.
        //NumberOfLaptops
        Console.WriteLine($"The number of laptops: {numOfLaptops}");  
        Console.WriteLine($"The number of desktops: {numOfDesktops}");  
        Console.WriteLine($"The number of other devices: {numOfOther}");

        //Displays toatl value of insurance 
        //Display total value for insurance
        Console.WriteLine($"The total value for insurance= {totalInsurance.ToString("c")}");

        //Display most expensivedevice and its cost
        Console.WriteLine($"the most expensive device:{mostExpensiveDevice} @ {mostEpensiveCost.ToString("c")}");
        

        //float numberOfLaptops = categoryOfdevices;

        //Console.WriteLine("Number of devices\n ");

        //numberOfDevices = numberOfDevices;

        Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Eror: Invalid name entered");
        Console.ForegroundColor = ConsoleColor.Blue;




        Console.ReadLine();
    }
    
}


