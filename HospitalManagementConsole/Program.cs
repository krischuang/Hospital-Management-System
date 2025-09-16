using HospitalManagementConsole.Menu;

namespace HospitalManagementConsole
{
    // Main program class for Hospital Management System
    internal class Program
    {
        // Entry point of the application
        static void Main(string[] args)
        {
            try
            {
                // Set the title in the console
                Console.Title = "Hospital Management System";
                // Show login menu and get authenticated user
                User user = LoginMenu.Show();
                // Display menu based on user type (Patient, Doctor, Admin, Receptionist)
                user.ShowMenu();
            }
            catch (Exception e)
            {
                // Handle any unhandled exceptions in the application 
                Console.WriteLine("Error Occurred in Main Function: " + e.Message);
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                Environment.Exit(1);
            }
        }
    }
}
