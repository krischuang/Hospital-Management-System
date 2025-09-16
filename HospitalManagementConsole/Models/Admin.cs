using HospitalManagementConsole.Service;

namespace HospitalManagementConsole.Menu;

// Admin class inheriting from User
internal class Admin : User
{
    // Define variables
    private string inputFirst = "", inputLast = "", inputEmail = "", inputPhone = "", inputStnumber = "", inputStreet = "", inputCity = "", inputState = "", inputPassword = "";

    // Constructor using base class constructor
    public Admin(int id, string password, string name, string email, string phone,  string address)
        : base(id, password, name, email, phone, address){}

    // Override virtual method from base and list all of the doctor details
    public override void ListDoctorDetails()
    {
        UserDesign.ShowHeadline("All Doctor");
        Console.WriteLine();
        Console.WriteLine($"{"Name",-15} | {"Email Address",-30} | {"Phone",-15} | {"Address",-30}");
        Console.WriteLine(new string('-', 111));

        // Load Doctor Information to Display
        List<Doctor> doctors = FileManager.LoadDoctorsData();
        foreach (Doctor doctor in doctors)
        {
            Console.WriteLine(doctor.ToString());
        }
    }

    // Check all of the doctors information
    public void CheckDoctorDetails()
    {
        // Define the bool to control while loop
        bool exit = false;
        while (!exit) {
            UserDesign.ShowHeadline("Doctor Details");
            Console.WriteLine();
            Console.Write("Please enter the ID of the doctor who's details you are checking. Or press n to return to menu: ");

            string id = Console.ReadLine();
            Console.WriteLine();
            if ("n".Equals(id))
            {
                break;
            }
            // Using extension method for validation
            else if (!id.IsValidId())
            {
                Console.WriteLine("Type Error, Please type some key to try again.");
                Console.ReadKey();
            }
            else
            {
                // Load Doctor Data and match the id
                List<Doctor> docs = FileManager.LoadDoctorsData();
                foreach (Doctor doc in docs)
                {
                    if (Convert.ToInt32(id) == doc.Id ) {
                        Console.WriteLine($"{"Name",-15} | {"Email Address",-30} | {"Phone",-15} | {"Address",-30}");
                        Console.WriteLine(new string('-', 111));
                        Console.WriteLine(doc.ToString());
                        exit = true;
                    }
                }
                // If no doctor id match, also show type error
                if (!exit)
                {
                    Console.WriteLine("Type Error, Please type some key to try again.");
                    Console.ReadKey(true);
                }
            }
        }
    }

    // List all patients in the system
    public override void ListPatientDetails()
    {
        UserDesign.ShowHeadline("All Patients");
        Console.WriteLine();
        Console.WriteLine($"{"Patient",-15} | {"Doctor",-15} | {"Email Address",-30} | {"Phone",-15} | {"Address",-30}");
        Console.WriteLine(new string('-', 111));

        // List all of the patient information
        List<Patient> patients = FileManager.LoadPatientsData();
        foreach (Patient patient in patients) {
            Console.WriteLine(patient.ToString());
        }
    }

    // Check all of the patients information
    public void CheckPatientsDetails()
    {
        bool exit = false;
        while (!exit)
        {
            UserDesign.ShowHeadline("Patient Details");
            Console.WriteLine();
            Console.Write("Please enter the ID of the patient who's details you are checking. Or press n to return to menu: ");

            string id = Console.ReadLine();
            Console.WriteLine();
            if ("n".Equals(id))
            {
                break;
            }
            else if (!id.IsValidId())
            {
                Console.WriteLine("Type Error, Please type some key to try again.");
                Console.ReadKey(true);
            }
            else
            {
                List<Patient> pats = FileManager.LoadPatientsData();
                foreach (Patient pat in pats)
                {
                    if (Convert.ToInt32(id) == pat.Id)
                    {
                        Console.WriteLine($"{"Name",-15} | {"Doctor", -15} {"Email Address",-30} | {"Phone",-15} | {"Address",-30}");
                        Console.WriteLine(new string('-', 111));
                        Console.WriteLine(pat.ToString());
                        exit = true;
                    }
                }
                if (!exit)
                {
                    Console.WriteLine("Type Error, Please type some key to try again.");
                    Console.ReadKey(true);
                }
            }
        }
    }

    // Add new patient to the system
    public void AddPatient()
    {
        bool inputLoop = true;
        while (inputLoop)
        {
            UserDesign.ShowHeadline("Add Patient");
            Console.WriteLine("Registering a new patient with the DOTNET Hospital Management System");
            inputLoop = InputData();
        }

        // Load to add new data into the list
        List<Patient> pats = FileManager.LoadPatientsData();
        int id = Service.Utils.GenerateId();
        pats.Add(new Patient(id, String.Format("{0} {1}", inputFirst, inputLast), inputEmail, inputPhone, string.Format("{0} {1}, {2}, {3}", inputStnumber, inputStreet, inputCity, inputState), 
                                                inputPassword, 0));
        // Save patients data
        FileManager.SavePatientsData(pats);
        Console.WriteLine("{0} {1} added to the system!", inputFirst, inputLast);
    }

    // Add new doctor to the system
    public void AddDoctor()
    {
        bool inputLoop = true;
        // Layout build
        while (inputLoop)
        {
            UserDesign.ShowHeadline("Add Doctor");
            Console.WriteLine("Registering a new doctor with the DOTNET Hospital Management System");
            inputLoop = InputData();
        }
       
        // Load to add new data into the list
        List<Doctor> docs = FileManager.LoadDoctorsData();
        int id = Service.Utils.GenerateId();
        docs.Add(new Doctor(id, String.Format("{0} {1}", inputFirst, inputLast), inputEmail, inputPhone, string.Format("{0} {1}, {2}, {3}", inputStnumber, inputStreet, inputCity, inputState),
                                               inputPassword));
        // Save doctors data
        FileManager.SaveDoctorsData(docs);
        Console.WriteLine("{0} {1} added to the system!", inputFirst, inputLast);
    }
    private bool InputData() 
    {
        // Display input column name
        Console.WriteLine("First Name: ");
        Console.WriteLine("Last Name: ");
        Console.WriteLine("Password: ");
        Console.WriteLine("Email: ");
        Console.WriteLine("Phone: ");
        Console.WriteLine("Street Number: ");
        Console.WriteLine("Street: ");
        Console.WriteLine("City: ");
        Console.WriteLine("State: ");

        // Input all variable
        Console.SetCursorPosition(12, 6);
        inputFirst = Console.ReadLine();
        Console.SetCursorPosition(11, 7);
        inputLast = Console.ReadLine();
        Console.SetCursorPosition(10, 8);
        inputPassword = Utils.ReadPasswordMasked();
        Console.SetCursorPosition(7, 9);
        inputEmail = Console.ReadLine();
        Console.SetCursorPosition(7, 10);
        inputPhone = Console.ReadLine();
        Console.SetCursorPosition(15, 11);
        inputStnumber = Console.ReadLine();
        Console.SetCursorPosition(8, 12);
        inputStreet = Console.ReadLine();
        Console.SetCursorPosition(6, 13);
        inputCity = Console.ReadLine();
        Console.SetCursorPosition(7, 14);
        inputState = Console.ReadLine();

        if (String.IsNullOrWhiteSpace(inputFirst) || String.IsNullOrWhiteSpace(inputLast) || String.IsNullOrWhiteSpace(inputPassword) || String.IsNullOrWhiteSpace(inputEmail) ||
            String.IsNullOrWhiteSpace(inputPhone) || String.IsNullOrWhiteSpace(inputStnumber) || String.IsNullOrWhiteSpace(inputStreet) || String.IsNullOrWhiteSpace(inputCity) ||
            String.IsNullOrWhiteSpace(inputState)) 
        {
            return true;
        }
        return false;
    }

    // Override ToString for custom string representation
    public override string ToString()
    {
        return $"{Name, -15} | {Email, -30} | {Phone, -15} | {Address, -30}";
    }

    // Override method to show admin specific menu
    public override void ShowMenu()
    {
        try
        {
            AdminMenu.ShowMenu(this);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error showing admin menu:" + e.Message);
            Console.ReadKey();
        }
    }
}