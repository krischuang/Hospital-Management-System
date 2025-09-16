using HospitalManagementConsole.Service;

namespace HospitalManagementConsole.Menu
{
    // Static class for doctor menu functionality
    internal class DoctorMenu
    {
        // Define variable
        private static bool typeError = false;

        // Main menu display method for doctor users
        public static void ShowMenu(Doctor doctor) {
            while (true) 
            {
                UserDesign.ShowHeadline("Doctor Menu");
                // Welcome message with doctor name
                Console.WriteLine("Welcome to DOTNET Hospital Management System {0}", doctor.Name);
                Console.WriteLine();
                // Display menu options for doctor
                Console.WriteLine("Please choose an option: ");
                Console.WriteLine("1. List doctor details");
                Console.WriteLine("2. List patients");
                Console.WriteLine("3. List appointments");
                Console.WriteLine("4. Check particular patient");
                Console.WriteLine("5. List appointments with patient");
                Console.WriteLine("6. Logout");
                Console.WriteLine("7. Exit");
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
                            // List doctor details functionality
                            typeError = false;
                            doctor.ListDoctorDetails();
                            Console.WriteLine();
                            UserDesign.PressFunction("continue");
                            break;
                        case "2":
                            // List all patients assigned to this doctor
                            typeError = false;
                            doctor.ListPatientDetails();
                            Console.WriteLine();
                            UserDesign.PressFunction("continue");
                            break;
                        case "3":
                            // List all appointments for this doctor
                            typeError = false;
                            doctor.ListAppointmentDetails();
                            Console.WriteLine();
                            UserDesign.PressFunction("continue");
                            break;
                        case "4":
                            // Check particular patient details by ID
                            typeError = false;
                            doctor.CheckPatientsDetails();
                            Console.WriteLine();
                            UserDesign.PressFunction("continue");
                            break;
                        case "5":
                            // List appointments with specific patient
                            typeError = false;
                            doctor.CheckAppointmentsByPatient();
                            Console.WriteLine();
                            UserDesign.PressFunction("continue");
                            break;
                        case "6":
                            // Return to login menu
                            typeError = false;
                            User newUser = LoginMenu.Show();
                            newUser.ShowMenu();
                            return; // Exit current menu completely
                        case "7":
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
        ~DoctorMenu()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
