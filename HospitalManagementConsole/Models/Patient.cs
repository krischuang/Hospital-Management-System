using HospitalManagementConsole.Service;

namespace HospitalManagementConsole.Menu;

// Patient class inheriting from User base class
internal class Patient : User
{
    // Get and set method
    public int DoctorId { get; set; }
    public string DoctorName { get; set; }

    // Constructor using base class constructor (inheritance)
    public Patient(int id, string name, string email, string phone, string address, string password, int doctorId)
        : base(id, name, email, phone, address, password)
    {
        // Construct to set variables
        DoctorId = doctorId;
        DoctorName = CheckDoctorName(doctorId);
    }

    // Override virtual method from base class (method overriding)
    public override void ListPatientDetails()
    {
        try
        {
            // Show patient information
            UserDesign.ShowHeadline("My Details");
            Console.WriteLine();
            Console.WriteLine(String.Format("{0}'s Details\n\nPatient ID: {1}\nFull Name: {2}\nAddress: {3}\nEmail: {4}\nPhone: {5}", Name, Id, Name, Address, Email, Phone));
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occurred in: " + e.Message);
        }
    }

    // Method to display doctor information for this patient
    public void ListDoctorDetails()
    {
        try {
            // Build layout
            UserDesign.ShowHeadline("My Doctor");
            Console.WriteLine();
            Console.WriteLine("Your Doctor:");
            Console.WriteLine();
            Console.WriteLine($"{"Name",-15} | {"Email Address",-30} | {"Phone",-15} | {"Address",-30}");
            Console.WriteLine(new string('-', 95));

            // Load doctor data
            List<Doctor> docs = FileManager.LoadDoctorsData();
            // Use Generic to get doctorId's information
            Doctor myDoctor = GenericHelper.FindById<Doctor>(docs, DoctorId);
            if (myDoctor != null)
            {
                Console.WriteLine(myDoctor.ToString());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occurred in: " + e.Message);
        }
    }

    // Display appointment details for patient
    public void ListAppointmentDetails()
    {
        try
        {
            // Build layout
            UserDesign.ShowHeadline("My Appointments");
            Console.WriteLine();
            Console.WriteLine("Appointments for {0}", Name);
            Console.WriteLine();
            Console.WriteLine($"{"Doctor",-15} | {"Patient",-15} | {"Description",-30}");
            Console.WriteLine(new string('-', 63));

            // Load appointments data and match the patient id
            List<Appointment> apps = FileManager.LoadAppointmentsData();
            foreach (Appointment app in apps)
            {
                if (app.PatientId == Id)
                {
                    // Display information
                    Console.WriteLine(app.ToString());
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occurred in: " + e.Message);
        }
    }

    // Book new appointment with doctor
    public void BookAppointment()
    {
        // Build layout
        UserDesign.ShowHeadline("Book Appointment");
        // If user doesn't choose doctor
        if (DoctorId == 0)
        {
            // Display and load data
            Console.WriteLine("You are not registered with any doctor! Please choose which doctor you would like to register with ");
            List<Doctor> docs = FileManager.LoadDoctorsData();
            int num = 1;

            // Anonymous method (delegate) for iterating through doctors
            docs.ForEach(delegate (Doctor doc)
            {
                Console.WriteLine("{0} {1}", num.ToString(), doc.ToString());
                num++;
            });

            Console.WriteLine("Please choose a doctor:");
            string docNum = Console.ReadLine();

            // Find choosing data
            int selectedIndex = Convert.ToInt32(docNum) - 1;
            if (selectedIndex >= 0 && selectedIndex < docs.Count)
            {
                // find doctor data (user choosed)
                Doctor assignDoc = docs[selectedIndex];
                Console.WriteLine("You are booking a new appointment with {0}", assignDoc.Name);
                Console.Write("Description of the appointment: ");
                string desc = Console.ReadLine();

                List<Patient> pats = FileManager.LoadPatientsData();
                Patient currentPatient = GenericHelper.FindById<Patient>(pats, Id);
                
                // Change identical pats doctor id
                if (currentPatient != null)
                {
                    currentPatient.DoctorId = assignDoc.Id;
                    DoctorId = assignDoc.Id;
                    DoctorName = assignDoc.Name;
                }
                // Save it
                FileManager.SavePatientsData(pats);

                // Load apppointment data
                List<Appointment> apps = FileManager.LoadAppointmentsData();
                int id = Utils.GenerateId();
                apps.Add(new Appointment(id, assignDoc.Id, Id, desc));
                // Appointments Saved
                FileManager.SaveAppointmentsData(apps);
                // Mail send
                Task task = Mailer.MailFunction(Name, Email, DoctorName, id);
                Console.WriteLine("The appointment has been booked successfully");
            }
            else
            {
                Console.WriteLine("Invalid doctor selection");
            }
        }
        else
        {
            // You are already registered doctor
            Console.Write("You are booking a new appointment with {0}\nDescription of the appointment: ", DoctorName);
            string desc = Console.ReadLine();
            
            // Get appointment history data
            List<Appointment> apps = FileManager.LoadAppointmentsData();
            // Generate new Id
            int id = Utils.GenerateId();
            apps.Add(new Appointment(id, DoctorId, Id, desc));
            // Save information
            FileManager.SaveAppointmentsData(apps);
            // Mail send
            Task task = Mailer.MailFunction(Name, Email, DoctorName, id);
            Console.WriteLine("The appointment has been booked successfully");
        }
        // Garbage collection happens automatically when method exits
    }

    // Check doctor name method
    public string CheckDoctorName(int doctorid)
    {
        if (doctorid == 0)
            return null;

        try
        {
            // Load all doctors
            List<Doctor> doctors = FileManager.LoadDoctorsData();

            // Using GenericHelper FindById<T> to find the doctor
            Doctor doctor = GenericHelper.FindById<Doctor>(doctors, doctorid);

            // Return the name if found, otherwise null
            return doctor != null ? doctor.Name : null;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error finding doctor: " + e.Message);
            return null;
        }
    }

    // Override ToString for custom string representation
    public override string ToString()
    {
        return $"{Name, -15} | {DoctorName, -15} |{Email, -30} | {Phone, -15} | {Address, -30}";
    }

    // Show menu
    public override void ShowMenu()
    {
        try
        {
            PatientMenu.ShowMenu(this);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error showing patient menu:" + e.Message);
            Console.ReadKey();
        }
    }
}