using System.Text.RegularExpressions;
using HospitalManagementConsole.Service;

namespace HospitalManagementConsole.Menu;

// Doctor class inheriting from User
internal class Doctor : User
{
    // Constructor using base class constructor
    public Doctor(int id, string name, string email, string phone, string address, string password)
        : base(id, name, email, phone, address, password)
    {}

    // Override method from base class
    public override void ListDoctorDetails()
    {
        try
        {
            // Show the doctor's personal information and build layout
            UserDesign.ShowHeadline("My Details");
            Console.WriteLine();
            Console.WriteLine($"{"Name", -15} | {"Email Address", -30} | {"Phone", -15} | {"Address", -30}");
            Console.WriteLine(new string('-', 95));
            Console.WriteLine($"{Name,-15} | {Email,-30} | {Phone,-15} | {Address,-30}");
        }
        catch (Exception e)
        {
            // Exception console
            Console.WriteLine("Error displaying doctor details: " + e.Message);
        }
    }

    // List all patients assigned to this doctor
    public override void ListPatientDetails()
    {
        try
        {
            // Build layout
            UserDesign.ShowHeadline("My Patients");
            Console.WriteLine();
            // Load patients data
            List<Patient> patients = FileManager.LoadPatientsData();

            // Display match data
            Console.WriteLine($"{"Patient",-15} | {"Doctor",-15} | {"Email Address",-30} | {"Phone",-15} | {"Address", -30}");
            Console.WriteLine(new string('-', 111));
            foreach (Patient patient in patients)
            {
                if (patient.DoctorId == Id)
                {
                    Console.WriteLine(patient.ToString());
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error loading patient details: " + e.Message);
        }
    }

    // Display all appointments for this doctor
    public void ListAppointmentDetails()
    {
        try
        {
            // Build layout
            UserDesign.ShowHeadline("All Appointments");
            Console.WriteLine();
            Console.WriteLine($"{"Doctor",-15} | {"Patient",-15} | {"Description",-30}");
            Console.WriteLine(new string('-', 63));
            // Load Appointment Data
            List<Appointment> apps = FileManager.LoadAppointmentsData();
            foreach (Appointment app in apps)
            {
                // Id doctor id match
                if (app.DoctorId == Id)
                {
                    // Display all of the appointments data
                    Console.WriteLine(app.ToString());
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error loading appointments: " + e.Message);
        }
    }

    // Check specific patient details by ID
    public void CheckPatientsDetails()
    {
        try
        {
            bool exit = false;
            while (!exit)
            {
                // Build Layout
                UserDesign.ShowHeadline("Check Patient Details");
                Console.WriteLine();
                Console.Write("Enter the ID of the patient to check: ");
                string id = Console.ReadLine();
                Console.WriteLine();

                // Input validation using regex
                if (!Regex.IsMatch(id, @"^\d+$"))
                {
                    Console.WriteLine("Type Error, Please type some key to try again.");
                    Console.ReadKey();
                }
                else
                {
                    // Load patient data
                    List<Patient> pats = FileManager.LoadPatientsData();

                    foreach (Patient pat in pats)
                    {
                        // Id id match patient id
                        if (Convert.ToInt32(id) == pat.Id)
                        {
                            // Display
                            Console.WriteLine($"{"Name",-15} | {"Doctor",-15} | {"Email Address",-30} | {"Phone",-15} | {"Address",-30}");
                            Console.WriteLine(new string('-', 111));
                            Console.WriteLine(pat.ToString());
                            exit = true; // exit loop
                            break;
                        }
                    }

                    // If no patient id match, also show type error
                    if (!exit)
                    {
                        Console.WriteLine("Type Error, Please type some key to try again.");
                        Console.ReadKey();
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error checking patient details: " + e.Message);
            Console.ReadKey();
        }
    }

    // Check appointments for specific patient
    public void CheckAppointmentsByPatient()
    {
        try
        {
            bool exit = false;
            while (!exit)
            {
                // Build layout
                UserDesign.ShowHeadline("Appointments With");
                Console.WriteLine();
                Console.Write("Enter the ID of the patient you would like to view appointments for: ");
                string id = Console.ReadLine();
                Console.WriteLine();

                if ("n".Equals(id))
                {
                    break;
                }
                // If id is not numeric
                if (!Regex.IsMatch(id, @"^\d+$"))
                {
                    Console.WriteLine("Type Error, Please type some key to try again.");
                    Console.ReadKey();
                }
                else
                {
                    // Load appointment data
                    List<Appointment> apps = FileManager.LoadAppointmentsData();

                    // Display Appointment
                    Console.WriteLine($"{"Doctor",-15} | {"Patient",-15} | {"Description",-30}");
                    Console.WriteLine(new string('-', 63));
                    // Loop to find match data
                    foreach (Appointment app in apps)
                    {
                        // If patient id and doctor id match
                        if (Convert.ToInt32(id) == app.PatientId && app.DoctorId == Id)
                        {
                            Console.WriteLine(app.ToString());
                            exit = true;
                        }
                    }

                    // If no data match, also show type error
                    if (!exit)
                    {
                        Console.WriteLine("Type Error, Please type some key to try again.");
                        Console.ReadKey();
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error checking appointments: " + e.Message);
            Console.ReadKey();
        }
    }

    // Override ToString for custom string representation
    public override string ToString()
    {
        try
        {
            return $"{Name, -15} | {Email, -30} | {Phone, -15} | {Address, -30}";
        }
        catch (Exception e)
        {
            return "Error displaying doctor information: " + e.Message;
        }
    }

    // Show menu information
    public override void ShowMenu()
    {
        try
        {
            DoctorMenu.ShowMenu(this);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error showing doctor menu:" + e.Message);
            Console.ReadKey();
        }
    }
}