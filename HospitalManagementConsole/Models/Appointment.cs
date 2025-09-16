using HospitalManagementConsole.Service;

namespace HospitalManagementConsole.Menu;

// Appointment class for managing doctor-patient appointments
internal class Appointment
{
    // Encapsulation with private setters
    public int Id { get; private set; }
    public int DoctorId { get; private set; }
    public int PatientId { get; private set; }
    public string DoctorName { get; private set; }
    public string PatientName { get; private set; }
    public string Description { get; private set; }

    // Constructor example - initializes appointment with all required data
    public Appointment(int id, int doctorid, int patientid, string description)
    {
        Id = id;
        DoctorId = doctorid;
        PatientId = patientid;
        // Get the data from method
        DoctorName = CheckDoctorName(doctorid);
        PatientName = CheckPatientName(patientid);
        Description = description;
    }

    // Get Doctor Name
    public string CheckDoctorName(int doctorid)
    {
        try
        {
            // Load all doctors
            List<Doctor> doctors = FileManager.LoadDoctorsData();

            // Using gereric to get doctor data
            Doctor doctor = GenericHelper.FindById<Doctor>(doctors, doctorid);

            // Return the name if found
            return doctor != null ? doctor.Name : "Unknown";
        }
        catch (Exception e)
        {
            // Return Unknown Data
            Console.WriteLine("Error finding doctor: " + e.Message);
            return "Unknown";
        }
    }

    public string CheckPatientName(int patientid)
    {
        try
        {
            // Load all patients
            List<Patient> patients = FileManager.LoadPatientsData();

            // Using Generic FindById<T> to find the patient
            Patient patient = GenericHelper.FindById<Patient>(patients, patientid);

            // Return the name if found
            return patient != null ? patient.Name : "Unknown Patient";
        }
        catch (Exception e)
        {
            // Return Unknown Data
            Console.WriteLine("Error finding patient: " + e.Message);
            return "Unknown Patient";
        }
    }

    // Override ToString for custom string representation
    public override string ToString()
    {
        return $"{DoctorName,-15} | {PatientName,-15} |{Description,-30}";
    }
}
