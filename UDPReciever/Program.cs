using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPReciever
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World receiver ready press enter!");
            Console.ReadLine();
            PostService postMeasure = new PostService();
            TemperaturLib.Temperatur temperatur;


            UdpClient receiveUdp = new UdpClient(11111);

            IPEndPoint receiveEndPoint = new IPEndPoint(IPAddress.Any, 0);

            Console.WriteLine("ready to receive data");

            try
            {
                while (true)
                {
                    Byte[] receiveBytes = receiveUdp.Receive(ref receiveEndPoint);
                    string receivedData = Encoding.ASCII.GetString(receiveBytes);

                    Console.WriteLine("This message was sent from " +
                                      receiveEndPoint.Address.ToString() +
                                      " on their port number " +
                                      receiveEndPoint.Port.ToString());

                    Console.WriteLine(receivedData);

                    string[] txtSplit = receivedData.Split(" ");
                    for (int i = 0; i < txtSplit.Length; i++)
                    {
                        Console.WriteLine(txtSplit[i]);
                    }

                    temperatur = new TemperaturLib.Temperatur(System.Convert.ToDecimal(txtSplit[0]), Convert.ToDateTime(txtSplit[1] + " " + txtSplit[2]));
                    postMeasure.PostItemHttpTask(temperatur);
                    Thread.Sleep(3000);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
