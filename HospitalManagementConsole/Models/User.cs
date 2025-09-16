using System.Net;

namespace HospitalManagementConsole.Menu
{
    // Abstract base class demonstrating inheritance and abstraction
    internal abstract class User
    {
        // Properties with private setters
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public string Password { get; private set; }

        // Default constructor demonstrates constructor chaining
        public User() 
        {
            Id = 0;
            Name = "";
            Email = "";
            Phone = "";
            Address = "";
            Password = "";
        }

        // Parameterized constructor for initializing user data
        public User(int id, string name, string email, string phone, string address, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            Password = password;
        }

        // Abstract method must be implemented by derived classes
        public abstract void ShowMenu();

        // Virtual method can be overridden in derived classes
        public virtual void ListDoctorDetails() 
        {
            Console.WriteLine(string.Format($"{0} | {1} | {2} | {3}", Id, Name, Password, Email, Phone));
        }

        public virtual void ListPatientDetails()
        {
            Console.WriteLine(string.Format($"{0} | {1} | {2} | {3}", Id, Name, Password, Email, Phone));
        }
    }
}
