using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;

namespace ProjectApp.ViewModel
{
    static class LoadImage
    {
        static string filePath = "";
        static public BitmapImage LoadNewImage()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                filePath = ofd.FileName;
                var bi = new BitmapImage();
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    bi.BeginInit();
                    bi.CacheOption = BitmapCacheOption.OnLoad;
                    bi.StreamSource = fs;
                    bi.EndInit();
                }
                return bi;
            }
            else
            {
                MessageBox.Show("Не удалось открыть файл!");
                return null;
            }
        }

        static public byte[] BitmapImageToBytes(BitmapImage img)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(img));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }

        static public BitmapImage BytesToBitmapImage(byte[] imageData)
        {
            BitmapImage bi = new BitmapImage();
            using (var fs = new MemoryStream(imageData))
            {
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.StreamSource = fs;
                bi.EndInit();
            }
            return bi;
        }
    }
}
