namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        public static void Main()
        {
            using (FileStream readStream = File.OpenRead(@"..\OddLines\Files\copyMe.png"))
            using (FileStream writeStream = File.OpenWrite(@"..\OddLines\Files\copyMe(1).png"))
            {

                byte[] buffer = new Byte[1024];
                int bytesRead;

                while ((bytesRead =
                        readStream.Read(buffer, 0, 1024)) > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                }
            }
        }
    }
}
