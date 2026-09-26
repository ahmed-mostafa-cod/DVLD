using BusinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectDVLD
{
    internal static class clsGOLBAL
    {
        public static clsUser user;

        public static bool RemmemberUserNameAndPassword(string userName, string password)
        {
            try
            {
                string CurrentDirectory=System.IO.Directory.GetCurrentDirectory();
                string filePath = CurrentDirectory + "//data.txt";

                if (userName == "" && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }

                string dataSave = userName + "#//#" + password;
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(dataSave);
                    return true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public static bool GetStoredCredential(ref string UserName, ref string Password)
        {
            try
            {
                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

                string filePath = CurrentDirectory + "//data.txt";

                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);
                            UserName = result[0];
                            Password = result[1];
                        }
                        return true;

                    }



                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }   
        
    }
}
