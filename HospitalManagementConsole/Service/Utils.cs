namespace HospitalManagementConsole.Service
{
    // Utility class for common functions
    internal class Utils
    {
        private static Random random = new Random();

        // Method to read password with masking
        public static string ReadPasswordMasked() 
        {
            try
            {
                // Password masking method
                string password = "";
                ConsoleKeyInfo key;
                while (true) 
                {
                    // if Enter key to break, backspace to remove last one
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter) break;
                    if (key.Key == ConsoleKey.Backspace)
                    {
                        if (password.Length > 0) {
                            password = password.Remove(password.Length - 1);
                            Console.Write("\b \b");
                        }
                        continue;
                    }
                    password += key.KeyChar;
                    Console.Write('*'); // masking
                }
                Console.WriteLine();
                return password;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading password: " + e.Message);
                return null;
            }
        }
        
        // Method to generate unique ID
        public static int GenerateId()
        {
            try
            {
                int id;
                List<int> userIds = FileManager.LoadUsedIds();
                int attempts = 0;
                do {
                    // Requirement define 5-8 digits
                    id = random.Next(10000, 99999999);
                    attempts++;
                    // Prevent infinite loop
                    if (attempts > 1000)
                    {
                        throw new Exception("Unable to generate unique ID");
                    }
                } while (userIds.Contains(id));

                userIds.Add(id);
                FileManager.SaveUsedIds(userIds);
                return id;
            }
            catch (Exception e)
            {
                // Return exception
                Console.WriteLine("Error generating ID: " + e.Message);
                return 0;
            }
        }
    }
}
