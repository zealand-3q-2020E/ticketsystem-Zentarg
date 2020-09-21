using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ClassLibrary;
using Oresundbron;
using Car = ClassLibrary.Car;

namespace ConsoleApp
{
    static class Program
    {
        private static string currencyAPIKey = "22e7777d7ebc8c2b8f248981e4a5de05";
        private static string currency = "DKK";
        private static double currencyValue = 1;

        static Customer customer = new Customer(new List<Vehicle>());

        static List<KeyValuePair<string, bool>> MainChoicesList = new List<KeyValuePair<string, bool>>()
        {
            new KeyValuePair<string, bool>("Buy Ticket", true),
            new KeyValuePair<string, bool>("List Purchases", false),
            new KeyValuePair<string, bool>("Sum of Purchases", false),
            new KeyValuePair<string, bool>("Choose Currency", false),
            new KeyValuePair<string, bool>("Exit", false)
        };

        static List<KeyValuePair<string, bool>> TicketChoicesList = new List<KeyValuePair<string, bool>>()
        {
            new KeyValuePair<string, bool>("Generic Ticket", true),
            new KeyValuePair<string, bool>("Oresundbron Ticket", false),
            new KeyValuePair<string, bool>("Storebaelt Ticket", false)
        };

        static List<KeyValuePair<string, bool>> VehicleChoicesList = new List<KeyValuePair<string, bool>>()
        {
            new KeyValuePair<string, bool>("Car", true),
            new KeyValuePair<string, bool>("M C", false)
        };

        static List<KeyValuePair<string, bool>> CurrencyChoicesList = new List<KeyValuePair<string, bool>>();

        static Dictionary<string, double> Currencies = new Dictionary<string, double>();

        static void Main(string[] args)
        {
            MainScreen();
        }

        static void MainScreen()
        {
            string choice = "";
            CycleChoicesList(MainChoicesList, 0, "Welcome, customer. Please select an option below: ");

            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                    break;
                if (key == ConsoleKey.DownArrow)
                    CycleChoicesList(MainChoicesList, 1, "Welcome, customer. Please select an option below: ");
                else if (key == ConsoleKey.UpArrow)
                    CycleChoicesList(MainChoicesList, -1, "Welcome, customer. Please select an option below: ");
            }

            foreach (KeyValuePair<string, bool> item in MainChoicesList)
            {
                if (item.Value)
                    choice = item.Key;
            }

            switch (choice)
            {
                case "Buy Ticket":
                    BuyTicket();
                    break;
                case "List Purchases":
                    ListPurchases();
                    break;
                case "Sum of Purchases":
                    SumPurchases();
                    break;
                case "Choose Currency":
                    ChangeCurrency();
                    break;
                case "Exit":
                    return;
            }
        }

        static void BuyTicket()
        {
            string ticketChoice = "";
            string vehicleChoice = "";
            DateTime date = DateTime.Now;
            string licensePlate = "12345678";
            bool brobizz;
            CycleChoicesList(TicketChoicesList, 0, "Please select the ticket you would like to buy: ");

            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                    break;
                if (key == ConsoleKey.DownArrow)
                    CycleChoicesList(TicketChoicesList, 1, "Please select the ticket you would like to buy: ");
                else if (key == ConsoleKey.UpArrow)
                    CycleChoicesList(TicketChoicesList, -1, "Please select the ticket you would like to buy: ");
            }

            foreach (KeyValuePair<string, bool> item in TicketChoicesList)
            {
                if (item.Value)
                    ticketChoice = item.Key;
            }


            CycleChoicesList(VehicleChoicesList, 0, "Please select the vehicle you would like to buy a ticket for: ");

            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                    break;
                if (key == ConsoleKey.DownArrow)
                    CycleChoicesList(VehicleChoicesList, 1, "Please select the vehicle you would like to buy a ticket for: ");
                else if (key == ConsoleKey.UpArrow)
                    CycleChoicesList(VehicleChoicesList, -1, "Please select the vehicle you would like to buy a ticket for: ");
            }

            foreach (KeyValuePair<string, bool> item in VehicleChoicesList)
            {
                if (item.Value)
                    vehicleChoice = item.Key;
            }
            Console.Clear();
            Console.WriteLine("Please enter the license plate");

            licensePlate = Console.ReadLine();

            while (licensePlate.Length > 7)
            {
                Console.Clear();
                Console.WriteLine("The length of license plate is over 7. Please re enter the license plate.");

                licensePlate = Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine($"License plate: {licensePlate}");
            date = GetDate();
            while (date == default)
            {
                Console.Clear();
                Console.WriteLine("The date was invalid.");
                date = GetDate();
            }

            Console.Clear();
            ConsoleKey ynKey = ConsoleKey.A;
            while (ynKey != ConsoleKey.Y && ynKey != ConsoleKey.N)
            {
                Console.Clear();
                Console.WriteLine("Do you have a brobizz in the car? Y/N");
                ynKey = Console.ReadKey().Key;
            }

            if (ynKey == ConsoleKey.Y)
                brobizz = true;
            else
                brobizz = false;

            switch (ticketChoice)
            {
                case "Generic Ticket":
                    if (vehicleChoice == "Car")
                    {
                        customer.Trips.Add(new ClassLibrary.Car(licensePlate, date, brobizz));
                    } else if (vehicleChoice == "M C")
                    {
                        customer.Trips.Add(new ClassLibrary.MC(licensePlate, date, brobizz));
                    }
                    break;
                case "Oresundbron Ticket":
                    if (vehicleChoice == "Car")
                    {
                        customer.Trips.Add(new Oresundbron.Car(licensePlate, date, brobizz));
                    }
                    else if (vehicleChoice == "M C")
                    {
                        customer.Trips.Add(new Oresundbron.MC(licensePlate, date, brobizz));
                    }
                    break;
                case "Storebaelt Ticket":
                    if (vehicleChoice == "Car")
                    {
                        customer.Trips.Add(new StoreBaeltTicketLibrary.Car(licensePlate, date, brobizz));
                    }
                    else if (vehicleChoice == "M C")
                    {
                        customer.Trips.Add(new ClassLibrary.MC(licensePlate, date, brobizz));
                    }
                    break;
            }

            Console.Clear();
            Console.WriteLine("You purchased the following ticket: ");
            Console.WriteLine($"> Ticket Type: {ticketChoice}");
            Console.WriteLine($"> Vehicle Type: {customer.Trips.Last().VehicleType()}");
            Console.WriteLine($"> Date: {date.ToShortDateString()}");
            Console.WriteLine($"> Price: {customer.Trips.Last().PriceAfterBrobizzDiscount() * currencyValue} {currency}");

            Console.WriteLine($"\r\n Press any key to go back to the main menu.");
            Console.ReadKey();
            MainScreen();
        }

        static DateTime GetDate()
        {
            Console.WriteLine("Please enter the date. Example: yyyy/mm/dd");
            string dateString = Console.ReadLine();
            string[] dateStringSplit = dateString.Split("/");
            bool isLeapYear = false;
            if (dateStringSplit.Length != 3)
            {
                return default;
            }

            if (int.Parse(dateStringSplit[1]) > 12 || int.Parse(dateStringSplit[1]) < 0)
            {
                return default;
            }


            isLeapYear = DateTime.IsLeapYear(int.Parse(dateStringSplit[0]));

            switch (int.Parse(dateStringSplit[1]))
            {
                case 2:
                    if (isLeapYear)
                    {
                        if (int.Parse(dateStringSplit[2]) > 29 || int.Parse(dateStringSplit[2]) < 0)
                            return default;
                    }
                    else
                    {
                        if (int.Parse(dateStringSplit[2]) > 28 || int.Parse(dateStringSplit[2]) < 0)
                            return default;
                    }

                    break;
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    if (int.Parse(dateStringSplit[2]) > 31 || int.Parse(dateStringSplit[2]) < 0)
                        return default;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    if (int.Parse(dateStringSplit[2]) > 30 || int.Parse(dateStringSplit[2]) < 0)
                        return default;
                    break;
                default:
                    return default;
            }
            return new DateTime(int.Parse(dateStringSplit[0]), int.Parse(dateStringSplit[1]), int.Parse(dateStringSplit[2]));
        }

        static void ListPurchases()
        {

            Console.Clear();
            Console.WriteLine("List of all your purchased tickets:");

            foreach (Vehicle trip in customer.Trips)
            {

                Console.WriteLine($"\r\n> Vehicle type: {trip.VehicleType()}");
                Console.WriteLine($"> Date: {trip.Date.ToShortDateString()}");
                Console.WriteLine($"> Brobizz: {trip.BrobizzPresent.ToString()}");
                Console.WriteLine($"> Price: {trip.PriceAfterBrobizzDiscount() * currencyValue} {currency}");
            }

            Console.WriteLine($"\r\n Press any key to go back to the main menu.");
            Console.ReadKey();
            MainScreen();
        }

        static void SumPurchases()
        {
            double sum = 0;

            Console.Clear();
            Console.WriteLine("Sum of all your purchased tickets:");

            foreach (Vehicle trip in customer.Trips)
            {
                sum += trip.PriceAfterBrobizzDiscount();
            }

            Console.WriteLine($"> {sum * currencyValue} {currency}");

            Console.WriteLine($"\r\n Press any key to go back to the main menu.");
            Console.ReadKey();
            MainScreen();
        }

        static void ChangeCurrency()
        {
            Console.WriteLine("\r\n Getting currencies, please wait...");
            GetCurrencies();
            CycleChoicesList(CurrencyChoicesList, 0, "Please choose your desired currency:");
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                    break;
                if (key == ConsoleKey.DownArrow)
                    CycleChoicesList(CurrencyChoicesList, 1, "Please choose your desired currency: ");
                else if (key == ConsoleKey.UpArrow)
                    CycleChoicesList(CurrencyChoicesList, -1, "Please choose your desired currency: ");
            }

            foreach (KeyValuePair<string, bool> pair in CurrencyChoicesList)
            {
                if (pair.Value)
                    currency = pair.Key;
            }

            currencyValue = Currencies[currency];

            
            Console.WriteLine($"\r\n Press any key to go back to the main menu.");
            Console.ReadKey();
            MainScreen();

        }

        static void CycleChoicesList(List<KeyValuePair<string, bool>> list, int direction, string messageToSendBeforeList)
        {
            Console.Clear();
            if (direction != 0)
            {
                int currentChosenIndex = list.FindIndex(i => i.Value);
                list[currentChosenIndex] = new KeyValuePair<string, bool>(list[currentChosenIndex].Key, false);
                if (direction == -1)
                {
                    if (currentChosenIndex - 1 < 0)
                        currentChosenIndex = list.Count;
                    list[currentChosenIndex - 1] = new KeyValuePair<string, bool>(list[currentChosenIndex - 1].Key, true);
                }
                else if (direction == 1)
                {
                    if (currentChosenIndex + 1 == list.Count)
                        currentChosenIndex = -1;
                    list[currentChosenIndex + 1] = new KeyValuePair<string, bool>(list[currentChosenIndex + 1].Key, true);
                }
            }

            Console.WriteLine(messageToSendBeforeList);
            foreach (KeyValuePair<string, bool> item in list)
            {
                if (item.Value)
                    Console.WriteLine($"> {item.Key}");
                else
                    Console.WriteLine($"  {item.Key}");
            }

        }

        static void GetCurrencies()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://api.exchangeratesapi.io/latest?base=DKK");

            request.Method = "GET";

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            CurrencyCallbackObject cback = JsonSerializer.Deserialize<CurrencyCallbackObject>(responseString);

            Currencies = cback.Rates;

            CurrencyChoicesList.Clear();

            foreach (KeyValuePair<string, double> pair in Currencies)
            {
                if (pair.Key == Currencies.First().Key)
                    CurrencyChoicesList.Add(new KeyValuePair<string, bool>(pair.Key, true));
                else
                    CurrencyChoicesList.Add(new KeyValuePair<string, bool>(pair.Key, false));
            }
        }

    }

    public class CurrencyCallbackObject
    {

        public CurrencyCallbackObject()
        {
            
        }

        [JsonPropertyName("rates")]
        public Dictionary<string, double> Rates { get; set; }
        [JsonPropertyName("base")]
        public string Base { get; set; }
        [JsonPropertyName("date")]
        public string Date { get; set; }
    }

}
