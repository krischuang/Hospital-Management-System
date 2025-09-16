using HospitalManagementConsole.Service;

namespace HospitalManagementConsole.Menu
{
    // Static class for patient menu functionality
    internal class PatientMenu
    {
        // Define variable
        private static bool typeError = false;

        // Main menu display method for patient users
        public static void ShowMenu(Patient patient) {
            while (true)
            {
                // Display appropriate heading for patient menu
                UserDesign.ShowHeadline("Patient Menu");
                // Welcome message with patient name
                Console.WriteLine("Welcome to DOTNET Hospital Management System {0}", patient.Name);
                Console.WriteLine();
                // Display menu options
                Console.WriteLine("Please choose an option: ");
                Console.WriteLine("1. List patient details");
                Console.WriteLine("2. List my doctor details");
                Console.WriteLine("3. List all appointments");
                Console.WriteLine("4. Book appointment");
                Console.WriteLine("5. Exit to login");
                Console.WriteLine("6. Exit System");

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
                            // List patient details functionality
                            typeError = false;
                            patient.ListPatientDetails();
                            Console.WriteLine();
                            UserDesign.PressFunction("continue");
                            break;
                        case "2":
                            // List doctor details functionality
                            typeError = false;
                            patient.ListDoctorDetails();
                            Console.WriteLine();
                            UserDesign.PressFunction("continue");
                            break;
                        case "3":
                            // List all appointments functionality
                            typeError = false;
                            patient.ListAppointmentDetails();
                            Console.WriteLine();
                            UserDesign.PressFunction("continue");
                            break;
                        case "4":
                            // Book appointment functionality with object writing to file
                            typeError = false;
                            patient.BookAppointment();
                            Console.WriteLine();
                            UserDesign.PressFunction("continue");
                            break;
                        case "5":
                            // Return to login menu
                            typeError = false;
                            User newUser = LoginMenu.Show();
                            newUser.ShowMenu();
                            return; // Exit current menu completely
                        case "6":
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
        ~PatientMenu()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
