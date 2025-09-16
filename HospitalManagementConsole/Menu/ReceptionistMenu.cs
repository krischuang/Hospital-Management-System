using HospitalManagementConsole.Service;

namespace HospitalManagementConsole.Menu
{
    // Static class for administrator menu functionality
    internal class ReceptionistMenu
    {
        // Define variable
        private static bool typeError = false;

        // Main menu display method for admin users
        public static void ShowMenu(Receptionist recept) {
            while (true) 
            {
                Console.Clear();
                // Display appropriate heading for admin menu
                UserDesign.ShowHeadline("Receptionist Menu");
                // Welcome message with admin name
                Console.WriteLine("Welcome to DOTNET Hospital Management System {0}", recept.Name);
                Console.WriteLine();
                // Display menu options for administrator
                Console.WriteLine("Please choose an option: ");
                Console.WriteLine("1. List all doctors");
                Console.WriteLine("2. List all patients");
                Console.WriteLine("3. List all appointments");
                Console.WriteLine("4. Logout");
                Console.WriteLine("5. Exit");

                // Check if type error or not
                if (typeError)
                {
                    Console.WriteLine("Type error, please try it again.");
                }

                // Read user input
                Console.SetCursorPosition(25, 7);
                string key = Console.ReadLine();

                // Exception handling for menu operations
                try
                {
                    switch (key)
                    {
                        case "1":
                            // List all doctors functionality
                            typeError = false;
                            recept.ListDoctorDetails();
                            Console.WriteLine();
                            UserDesign.PressFunction("continue");
                            break;
                        case "2":
                            // List all patients in the system
                            typeError = false;
                            recept.ListPatientDetails();
                            Console.WriteLine();
                            UserDesign.PressFunction("continue");
                            break;
                        case "3":
                            // List all appointments in the system
                            typeError = false;
                            recept.ListAppointmentDetails();
                            UserDesign.PressFunction("continue");
                            break;
                        case "4":
                            // Return to login menu
                            typeError = false;
                            User newUser = LoginMenu.Show();
                            newUser.ShowMenu();
                            return; // Exit current menu completely
                        case "5":
                            // Exit system functionality
                            typeError = false;
                            Console.SetCursorPosition(1, 17);
                            Environment.Exit(0);
                            break;
                        default:
                            // Show type error message and let user try it again
                            typeError = true;
                            break;
                    }
                }
                catch (Exception e)
                {
                    // Handle any exceptions during menu operations
                    Console.WriteLine("Error occurred: " + e.Message);
                }
            }
        }
        // Two phase garbage collection (process: collect -> wait -> collect again)
        ~ReceptionistMenu()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}