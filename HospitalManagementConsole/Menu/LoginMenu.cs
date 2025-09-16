using HospitalManagementConsole.Service;
using System.Text.RegularExpressions;

namespace HospitalManagementConsole.Menu
{
    // Static class for handling user login
    internal static class LoginMenu
    {
        // Define variable
        private static string id = "", password = "";

        // Main login method that returns authenticated User
        public static User Show()
        {
            // While Loop to continue running in the system
            while (true)
            {
                // Exception handling for login layout and id check
                try
                {
                    // Compose the user information part
                    UserDesign.ShowHeadline("Login");
                    Console.WriteLine("");
                    Console.WriteLine("ID: ");
                    Console.WriteLine("Password: ");

                    // Cursor changed to the position and read id information and trim to avoid space
                    Console.SetCursorPosition(4, 6);
                    id = Console.ReadLine().Trim();

                    // Extension method for masked password input
                    Console.SetCursorPosition(10, 7);
                    password = Utils.ReadPasswordMasked();

                    // Input validation using regex
                    if (!Regex.IsMatch(id, @"^\d+$"))
                    {
                        Console.WriteLine("Invalid ID");
                        UserDesign.PressFunction("retry");
                        continue;
                    }
                }
                catch (Exception e)
                {
                    // Catch and handle any exceptions during login
                    Console.WriteLine("Error Occurred in Login Menu Forming: " + e.Message);
                    UserDesign.PressFunction("retry");
                }

                // Exception handling for login process
                try
                {
                    // Find User Authentication and Return User Type
                    User user = FileManager.FindUser(Convert.ToInt32(id), password);
                    if (user != null)
                    {
                        Console.WriteLine("Valid Credentials");
                        UserDesign.PressFunction("continue");
                        return user;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Credentials");
                        UserDesign.PressFunction("retry");
                    }
                }
                catch (Exception e)
                {
                    // Catch and handle any exceptions during login
                    Console.WriteLine("Error Occurred in Finding Users: " + e.Message);
                    UserDesign.PressFunction("retry");
                }
            }
        }
    }
}
