namespace HospitalManagementConsole.Service
{
    // Extension class for validation methods
    internal static class UserDesign
    {
        // Define variables
        private const string SYSTEMNAME = "DOTNET Hospital Management System";
        private const int COLUMNNUM = 39;
        public static int leftPadding, rightPadding;

        // Show headline in the system
        public static void ShowHeadline(string functionName)
        {
            try
            {
                // Layout information clear
                Console.Clear();
                string systemCenter = TextCentralize(SYSTEMNAME);
                // Function Name Centralize
                string functionCenter = TextCentralize(functionName);
                // Display login menu header
                Console.WriteLine('¢z' + new string('¢w', 39) + '¢{');
                Console.WriteLine("¢x" + systemCenter + "¢x");
                Console.WriteLine("¢x " + new string('-', 37) + " ¢x");
                Console.WriteLine("¢x" + functionCenter + "¢x");
                Console.WriteLine('¢|' + new string('¢w', 39) + '¢}');
            }
            catch (Exception e)
            {
                // If any error occurs during show headline, show error message
                Console.WriteLine("Error Occurred in Show HeadLine:" + e.Message);
            }
        }

        // Calculate Text Central Space
        private static string TextCentralize(string textName)
        {
            try
            {
                // System Text Centralize (Calculate Padding)
                leftPadding = (COLUMNNUM - textName.Length) / 2;
                rightPadding = COLUMNNUM - textName.Length - leftPadding;
                string textCenter = new string(' ', leftPadding) + textName + new string(' ', rightPadding);
                return textCenter;
            }
            catch (Exception e) 
            {
                // If any error occurs during text centralize, return empty string
                Console.WriteLine("Error Occurred in Centralize:" + e.Message);
                return null;
            }
        }

        // Method to press function execution
        public static void PressFunction(string functionName)
        {
            // Show pause message and readkey to stay user input key
            Console.Write("Press any key to {0}...", functionName);
            Console.ReadKey();
        }
    }
}