using HospitalManagementConsole.Service;

namespace HospitalManagementConsole.Menu
{
    // Static class for administrator menu functionality
    internal class AdminMenu
    {
        // Define variable
        private static bool typeError = false;

        // Main menu display method for admin users
        public static void ShowMenu(Admin admin) {
            while (true) 
            {
                // Display appropriate heading for admin menu
                UserDesign.ShowHeadline("Administrator Menu");
                // Welcome message with admin name
                Console.WriteLine("Welcome to DOTNET Hospital Management System {0}", admin.Name);
                Console.WriteLine();
                // Display menu options for administrator
                Console.WriteLine("Please choose an option: ");
                Console.WriteLine("1. List all doctors");
                Console.WriteLine("2. Check doctor details");
                Console.WriteLine("3. List all patients");
                Console.WriteLine("4. Check patients details");
                Console.WriteLine("5. Add doctor");
                Console.WriteLine("6. Add patient");
                Console.WriteLine("7. Logout");
                Console.WriteLine("8. Exit");
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
                            admin.ListDoctorDetails();
                            Console.WriteLine();
                            UserDesign.PressFunction("continue");
                            break;
                        case "2":
                            // Check specific doctor details by ID
                            typeError = false;
                            admin.CheckDoctorDetails();
                            Console.WriteLine();
                            UserDesign.PressFunction("continue");
                            break;
                        case "3":
                            // List all patients in the system
                            typeError = false;
                            admin.ListPatientDetails();
                            Console.WriteLine();
                            UserDesign.PressFunction("continue");
                            break;
                        case "4":
                            // Check specific patient details by ID
                            typeError = false;
                            admin.CheckPatientsDetails();
                            Console.WriteLine();
                            UserDesign.PressFunction("continue");
                            break;
                        case "5":
                            // Add new doctor to the system
                            typeError = false;
                            admin.AddDoctor();
                            Console.WriteLine();
                            UserDesign.PressFunction("continue");
                            break;
                        case "6":
                            // Add new patient to the system
                            typeError = false;
                            admin.AddPatient();
                            Console.WriteLine();
                            UserDesign.PressFunction("continue");
                            break;
                        case "7":
                            // Return to login menu
                            typeError = false;
                            User newUser = LoginMenu.Show();
                            newUser.ShowMenu();
                            // Exit current menu completely
                            return;
                        case "8":
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
        ~AdminMenu()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
