using System;

namespace Parking.Core.Helpers
{
    public static class FileHelper
    {
        public const string FilePath = "..\\Parking.Repository\\Json\\";//File Value.
        public static string Read(string location)
        {
            try
            {
                return System.IO.File.ReadAllText(location);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error Reading File : " + ex);
                System.Console.WriteLine("Continue ... ");

                return "";
            }            
        }
    }
}
