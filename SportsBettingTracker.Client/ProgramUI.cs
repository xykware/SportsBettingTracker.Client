using System;

namespace SportsBettingTracker.Client
{
    public class ProgramUI
    {
        HTTPMethods _http = new HTTPMethods();

        public void Run()
        {
            while (true)
            {
                Console.Title = "Sports Betting Tracker";
                Console.Clear();
                Console.WriteLine
                    (
                        "                    Welcome to the Sports Betting Tracker 1.0.\n" +
                        "************************************************************************************\n"
                    );

                Console.WriteLine
                    (
                        "Please Login to Get Started!\n\n" +
                        "1. Login\n" +
                        "2. Register\n" +
                        "0. Exit\n\n" +
                        "Enter the number of your selection:"
                    );

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        LoginMenu();
                        break;
                    case "2":
                        RegisterMenu();
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        Console.WriteLine("Please press any key to exit...");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nPlease enter a valid number.");
                        break;
                }
            }
        }

        private void LoginMenu()
        {
            Console.Title = "Sports Betting Tracker - Login";

            Console.Clear();
            Console.WriteLine("Enter your Email:");
            string email = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter your Password:");
            string password = null;

            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                password += key.KeyChar;
            }

            string token = _http.HTTPRequestToken(email, password);

            MainMenu(token);
        }

        private void RegisterMenu()
        {
            Console.Title = "Sports Betting Tracker - Register";
            
            Console.Clear();
            Console.WriteLine("Enter your Email:");
            string email = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter your Password:");
            string password = null;

            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                password += key.KeyChar;
            }

            Console.Clear();
            Console.WriteLine("Confirm your Password:");
            string confirmPassword = null;

            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                confirmPassword += key.KeyChar;
            }

            _http.HTTPRequest("https://localhost:44365/api/Account/Register", "POST", $"Email={email}&Password={password}&ConfirmPassword={confirmPassword}", null);

            string token = _http.HTTPRequestToken(email, password);

            MainMenu(token);
        }

        private void MainMenu(string token)
        {
            Console.Clear();
            Console.WriteLine("Here's your token:\n\n");
            Console.WriteLine(token);
            Console.ReadLine();
        }
    }
}
