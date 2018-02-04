namespace SlicingFile
{
    using System;
    using System.IO;
    
    public class Program
    {
        public static void Main()
        {
            int numSplices = int.Parse(Console.ReadLine());
            using (FileStream readStream = new FileStream(@"..\OddLines\Files\sliceMe.mp4", FileMode.OpenOrCreate))
            
            {
                var size = readStream.Length;
                var fileChunk = readStream.Length / numSplices;
                var buffer = new Byte[readStream.Length];

                int offset = 0;

                for (int i = 0; i < numSplices - 1; i++)
                {

                    string fileName = $"Part-{i}.mp4";
                    using (FileStream writer = File.OpenWrite($@"..\OddLines\Files\{fileName}"))
                    {
                        int bytesRead;

                        while ((bytesRead =
                                readStream.Read(buffer, 0, fileChunk)) > 0)
                        {
                            writer.Write(buffer, 0, bytesRead);
                        }
                    }
                    fileChunk *= 2;
                }


            }
        }
        
        
    }
}
