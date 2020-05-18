using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TemperaturLib;

namespace UDPSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World press enter to start prepare sending environment!");
            Console.ReadLine();
            Random rvalue = new Random();
            TemperaturLib.Temperatur temperatur;

            UdpClient udpSender = new UdpClient(0);
            udpSender.EnableBroadcast = true;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 11111);

            Console.WriteLine("ready to start press enter again");
            Console.ReadLine();
            string dateToday = DateTime.Now.Date.ToString();

            while (true)
            {
                temperatur = new TemperaturLib.Temperatur(1, DateTime.Now);

                byte[] sendBytes = Encoding.ASCII.GetBytes(temperatur.ToString());

                try
                {
                    Console.WriteLine("sending :" + temperatur.ToString());
                    udpSender.Send(sendBytes, sendBytes.Length, endPoint);
                    Thread.Sleep(3000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

        }
    }
}