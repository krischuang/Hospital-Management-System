using HospitalManagementConsole.Menu;

namespace HospitalManagementConsole.Service
{
    // Generic helper class to demonstrate use of generics and allows us to write code that works with any data type
    internal class GenericHelper
    {
        // Generic method to find item by ID and using same coding style as the rest of the project
        public static T FindById<T>(List<T> data, int id) where T : class
        {
            // Check what type T is and use appropriate foreach loop

            if (typeof(T) == typeof(Patient))
            {
                // Cast to Patient list and search
                List<Patient> patients = data as List<Patient>;
                foreach (Patient patient in patients)
                {
                    if (patient.Id == id)
                    {
                        return patient as T;
                    }
                }
            }
            else if (typeof(T) == typeof(Doctor))
            {
                // Cast to Doctor list and search
                List<Doctor> doctors = data as List<Doctor>;
                foreach (Doctor doctor in doctors)
                {
                    if (doctor.Id == id)
                    {
                        return doctor as T;
                    }
                }
            }
            else if (typeof(T) == typeof(Admin))
            {
                // Cast to Admin list and search
                List<Admin> admins = data as List<Admin>;
                foreach (Admin admin in admins)
                {
                    if (admin.Id == id)
                    {
                        return admin as T;
                    }
                }
            }
            else if (typeof(T) == typeof(Appointment))
            {
                // Cast to Appointment list and search
                List<Appointment> appointments = data as List<Appointment>;
                foreach (Appointment appointment in appointments)
                {
                    if (appointment.Id == id)
                    {
                        return appointment as T;
                    }
                }
            }
            else if (typeof(T) == typeof(Receptionist))
            {
                // Cast to Receptionist list and search
                List<Receptionist> receptionists = data as List<Receptionist>;
                foreach (Receptionist receptionist in receptionists)
                {
                    if (receptionist.Id == id)
                    {
                        return receptionist as T;
                    }
                }
            }
            return null;
        }
    }
}