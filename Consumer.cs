namespace aclaerboOSProjectB;

#define CONSUMER // Define the CONSUMER symbol

using System;
using System.IO;
using System.IO.Pipes;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
#if CONSUMER
        Console.WriteLine("Consumer: Starting...");

        using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("testpipe", PipeDirection.In))
        {
            Console.WriteLine("Consumer: Waiting for connection...");
            pipeServer.WaitForConnection();
            Console.WriteLine("Consumer: Connected to pipe.");

            byte[] buffer = new byte[256];
            int bytesRead = pipeServer.Read(buffer, 0, buffer.Length);
            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"Consumer: Received message: {message}");
        }

        Console.WriteLine("Consumer: Exiting...");
#endif
    }
}