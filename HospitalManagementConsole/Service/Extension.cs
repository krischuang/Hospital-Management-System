using System.Text.RegularExpressions;

namespace HospitalManagementConsole.Service
{
    // Extension class for validation methods
    internal static class Extension
    {
        // Extension method for validating ID format and range and could be converted to extension method
        public static bool IsValidId(this string value)
        {
            try
            {
                // If string is null or white space
                if (string.IsNullOrWhiteSpace(value))
                {
                    return false;
                }
                // Validate ID is numeric and within valid range
                if (!Regex.IsMatch(value, @"^\d+$"))
                {
                    return false;
                }
                int id = Convert.ToInt32(value);
                return id >= 10000 && id <= 99999999;
            }
            catch (Exception e)
            {
                // If any error occurs during validation, return false
                Console.WriteLine("Error Occurred in Extension: " + e.Message);
                return false;
            }
        }
    }
}
