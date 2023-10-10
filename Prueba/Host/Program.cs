using System;
using System.ServiceModel;

namespace Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Comunication.Login))) 
            {
                host.Open();
                Console.WriteLine("Running Server...");
                Console.ReadLine();
            }
        }
    }
}
