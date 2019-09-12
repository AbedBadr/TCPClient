using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace TCPEchoClient
{
    class TCPClient2
    {
        static void Main1(string[] args)
        {
            TcpClient clientSocket = new TcpClient("127.0.0.1", 6789);
            Console.WriteLine("Client ready");

            Stream ns = clientSocket.GetStream();  //provides a Stream
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            for (int i = 0; i < 5; i++)
            {
                string message = $"LX, {i}";
                sw.WriteLine(message);

                string serverAnswer = sr.ReadLine();

                Console.WriteLine("Server: " + serverAnswer);

                Thread.Sleep(100);
            }

            Console.WriteLine("No more from server. Press Enter");
            Console.ReadLine();

            ns.Close();

            clientSocket.Close();

        }
    }
}
