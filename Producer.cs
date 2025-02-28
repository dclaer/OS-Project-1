#define PRODUCER // Define the PRODUCER symbol

using System;
using System.IO;
using System.IO.Pipes;
using System.Text;

class Producer
{
    static void Main(string[] args)
    {
#if PRODUCER
        Console.WriteLine("Producer: Starting...");

        using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "testpipe", PipeDirection.Out))
        {
            Console.WriteLine("Producer: Connecting to pipe...");
            pipeClient.Connect();
            Console.WriteLine("Producer: Connected to pipe.");

            string message = "Hello from Producer!";
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            pipeClient.Write(messageBytes, 0, messageBytes.Length);
            Console.WriteLine($"Producer: Sent message: {message}");
        }

        Console.WriteLine("Producer: Exiting...");
#endif
    }
}