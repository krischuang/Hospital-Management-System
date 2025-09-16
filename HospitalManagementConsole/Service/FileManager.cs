using HospitalManagementConsole.Menu;

namespace HospitalManagementConsole.Service
{
    // File manager for data persistence with exception handling
    internal class FileManager
    {
        // File paths for data storage
        private static readonly string PatientsRoute = "../../../Data/patient.txt";
        private static readonly string DoctorsRoute = "../../../Data/doctor.txt";
        private static readonly string AppointmentRoute = "../../../Data/appointment.txt";
        private static readonly string AdminRoute = "../../../Data/admin.txt";
        private static readonly string ReceptionistRoute = "../../../Data/receptionist.txt";
        private static readonly string IdRoute = "../../../Data/ids.txt";
        
        // Load patients Data
        public static List<Patient> LoadPatientsData()
        {
            // Define variable
            List<Patient> patients = new List<Patient>();
            // Exception handling for file operations
            try
            {
                if (File.Exists(PatientsRoute))
                {
                    string[] datas = File.ReadAllLines(PatientsRoute);
                    foreach (string data in datas)
                    {
                        // Split data from txt file
                        string[] parts = data.Split("#~");
                        Patient patient = new Patient(Convert.ToInt32(parts[0]), parts[1], parts[2], parts[3], parts[4], parts[5], Convert.ToInt32(parts[6]));
                        patients.Add(patient);
                    }
                }
            }
            catch (Exception e)
            {
                // Handle file reading exceptions
                Console.WriteLine("Error when loading patients data: " + e.Message);
            }
            return patients;
        }

        // Save patients with exception handling
        public static void SavePatientsData(List<Patient> patients)
        {
            List<string> data = new List<string>();
            try
            {
                // Each data add into list
                foreach (Patient patient in patients)
                {
                    data.Add($"{patient.Id}#~{patient.Name}#~{patient.Email}#~{patient.Phone}#~{patient.Address}#~{patient.Password}#~{patient.DoctorId}");
                }
                // Save it into file
                File.WriteAllLines(PatientsRoute, data);
            }
            catch (Exception ex)
            {
                // Handle file writing exceptions
                Console.WriteLine("Error saving patients: " + ex.Message);
            }
        }

        // Load doctors data
        public static List<Doctor> LoadDoctorsData()
        {
            List<Doctor> doctors = new List<Doctor>();
            try
            {
                if (File.Exists(DoctorsRoute))
                {
                    string[] datas = File.ReadAllLines(DoctorsRoute);
                    foreach (string data in datas)
                    {
                        string[] parts = data.Split("#~");
                        Doctor doctor = new Doctor(Convert.ToInt32(parts[0]), parts[1], parts[2], parts[3], parts[4], parts[5]);
                        doctors.Add(doctor);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when loading doctors data: " + e.Message);
            }
            return doctors;
        }

        // Save doctors data
        public static void SaveDoctorsData(List<Doctor> doctors)
        {
            List<string> data = new List<string>();
            try
            {
                foreach (Doctor doctor in doctors)
                {
                    data.Add($"{doctor.Id}#~{doctor.Name}#~{doctor.Email}#~{doctor.Phone}#~{doctor.Address}#~{doctor.Password}");
                }
                File.WriteAllLines(DoctorsRoute, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving doctors: " + ex.Message);
            }
        }

        // Load appointments data
        public static List<Appointment> LoadAppointmentsData()
        {
            List<Appointment> Apps = new List<Appointment>();
            try
            {
                if (File.Exists(AppointmentRoute))
                {
                    string[] datas = File.ReadAllLines(AppointmentRoute);
                    foreach (string data in datas)
                    {
                        string[] parts = data.Split("#~");
                        Appointment app = new Appointment(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), parts[3]);
                        Apps.Add(app);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when loading appointments data: " + e.Message);
            }
            return Apps;
        }

        // Save appointments data
        public static void SaveAppointmentsData(List<Appointment> apps)
        {
            List<string> data = new List<string>();
            try
            {
                foreach (Appointment app in apps)
                {
                    data.Add($"{app.Id}#~{app.DoctorId}#~{app.PatientId}#~{app.Description}");
                }
                File.WriteAllLines(AppointmentRoute, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving appointments: " + ex.Message);
            }
        }

        // Load admins data
        public static List<Admin> LoadAdminsData()
        {
            List<Admin> admins = new List<Admin>();
            try
            {
                if (File.Exists(AdminRoute))
                {
                    
                    string[] datas = File.ReadAllLines(AdminRoute);
                    foreach (string data in datas)
                    {
                        string[] parts = data.Split("#~");
                        Admin admin = new Admin(Convert.ToInt32(parts[0]), parts[1], parts[2], parts[3], parts[4], parts[5]);
                        admins.Add(admin);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when loading admin data: " + e.Message);
            }
            return admins;
        }

        // Load receptionists data
        public static List<Receptionist> LoadReceptionistsData()
        {
            List<Receptionist> recepts = new List<Receptionist>();
            try
            {
                if (File.Exists(ReceptionistRoute))
                {

                    string[] datas = File.ReadAllLines(ReceptionistRoute);
                    foreach (string data in datas)
                    {
                        string[] parts = data.Split("#~");
                        Receptionist recept = new Receptionist(Convert.ToInt32(parts[0]), parts[1], parts[2], parts[3], parts[4], parts[5]);
                        recepts.Add(recept);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when loading receptionist data: " + e.Message);
            }
            return recepts;
        }

        // Load used IDs from file
        public static List<int> LoadUsedIds()
        {
            List<int> userIds = new List<int>();
            try
            {
                if (File.Exists(IdRoute))
                {
                    string[] datas = File.ReadAllLines(IdRoute);
                    foreach (string data in datas)
                    {
                        if (!string.IsNullOrWhiteSpace(data))
                        {
                            userIds.Add(Convert.ToInt32(data));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error loading used IDs: " + e.Message);
            }
            return userIds;
        }

        // Save used IDs with exception handling
        public static void SaveUsedIds(List<int> userIds)
        {
            try
            {
                // Create file
                if (!File.Exists(IdRoute))
                {
                    File.Create(IdRoute).Close();
                }
                // Using lambda expression to convert int to string
                List<string> idStrings = userIds.ConvertAll(id => id.ToString());
                File.WriteAllLines(IdRoute, idStrings);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error saving used IDs: " + e.Message);
            }
        }

        // Find user by credentials - demonstrates polymorphism
        public static User FindUser(int id, string password)
        {
            // Check patients data
            List<Patient> patients = LoadPatientsData();
            foreach (Patient patient in patients)
            {
                if (id == patient.Id && password.Equals(patient.Password))
                {
                    // Return as User type (polymorphism)
                    return patient;
                }
            }

            // Check doctors data
            List<Doctor> doctors = LoadDoctorsData();
            foreach (Doctor doctor in doctors)
            {
                if (id == doctor.Id && password.Equals(doctor.Password))
                {
                    // Return as User type (polymorphism)
                    return doctor;
                }
            }

            // Check admins data
            List<Admin> admins = LoadAdminsData();
            foreach (Admin admin in admins)
            {
                if (id == admin.Id && password.Equals(admin.Password))
                {
                    // Return as User type (polymorphism)
                    return admin;
                }
            }
            // Check receptionist data
            List<Receptionist> recepts = LoadReceptionistsData();
            foreach (Receptionist recept in recepts)
            {
                if (id == recept.Id && password.Equals(recept.Password))
                {
                    // Return as User type (polymorphism)
                    return recept;
                }
            }
            return null;
        }
    }
}