using HospitalManagementConsole.Service;

namespace HospitalManagementConsole.Menu;

// Admin class inheriting from User
internal class Receptionist : User
{
    // Constructor using base class constructor
    public Receptionist(int id, string password, string name, string email, string phone,  string address)
        : base(id, password, name, email, phone, address){}

    // List Doctor Details
    public override void ListDoctorDetails()
    {
        // Build layout
        UserDesign.ShowHeadline("All Doctors");
        Console.WriteLine();
        Console.WriteLine($"{"Name",-15} | {"Email Address",-30} | {"Phone",-15} | {"Address",-30}");
        Console.WriteLine(new string('-', 111));

        // Load doctors data
        List<Doctor> doctors = FileManager.LoadDoctorsData();
        foreach (Doctor doctor in doctors)
        {
            Console.WriteLine(doctor.ToString());
        }
    }


    // List all patients in the system
    public override void ListPatientDetails()
    {
        // Layout build
        UserDesign.ShowHeadline("All Patients");
        Console.WriteLine();
        Console.WriteLine($"{"Patient",-15} | {"Doctor",-15} | {"Email Address",-30} | {"Phone",-15} | {"Address",-30}");
        Console.WriteLine(new string('-', 111));

        // Load patients data
        List<Patient> patients = FileManager.LoadPatientsData();
        foreach (Patient patient in patients) {
            Console.WriteLine(patient.ToString());
        }
    }

    // Display all appointments for this doctor
    public void ListAppointmentDetails()
    {
        try
        {
            // Layout build
            UserDesign.ShowHeadline("All Appointments");
            Console.WriteLine();
            Console.WriteLine($"{"Doctor",-15} | {"Patient",-15} | {"Description",-30}");
            Console.WriteLine(new string('-', 63));

            // Load patients data
            List<Appointment> apps = FileManager.LoadAppointmentsData();
            foreach (Appointment app in apps)
            {
                Console.WriteLine(app.ToString());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error loading appointments: " + e.Message);
        }
    }

    // Override ToString for custom string representation
    public override string ToString()
    {
        return $"{Name, -15} | {Email, -30} | {Phone, -15} | {Address, -30}";
    }

    // Polymorphic method to show recptionist specific menu
    public override void ShowMenu()
    {
        try
        {
            ReceptionistMenu.ShowMenu(this);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error showing receptionist menu:" + e.Message);
            Console.ReadKey();
        }
    }
}