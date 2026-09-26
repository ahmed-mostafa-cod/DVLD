using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectDVLD
{
    public static class clsUtil
    {
        // دالة إنشاء معرف فريد لتسمية الصور
        public static string GenerateGUID()
        {
            return Guid.NewGuid().ToString();
            
        }

        // دالة إنشاء مجلد الصور إذا لم يكن موجوداً
        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        // الدالة التي كانت تسبب خطأ واستدعاها غير مكتمل
        public static bool CopyImageToProjectImagesFolder(ref string SourceFile)
        {
            // حدد المسار المفضل لحفظ الصور داخل مجلد المشروع/التطبيق
            string DestinationFolder = @"D:\source\C#\projectDVLD\Images";

            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            // توليد مسار الصورة الجديد باستخدام GUID للحفاظ على اسم فريد
            string DestinationFile = DestinationFolder + GenerateGUID() + Path.GetExtension(SourceFile);

            try
            {
                File.Copy(SourceFile, DestinationFile, true);
            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // إرجاع المسار الجديد في نفس المتغير
            SourceFile = DestinationFile;
            
            return true;
        }
    }
}
