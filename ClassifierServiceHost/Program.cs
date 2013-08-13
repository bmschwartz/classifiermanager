using System;
using System.Collections.Generic;
using System.Text;

using System.ServiceModel;
using ClassifierServices;

namespace ClassifierServiceHost
{
    class Program
    {
        static ServiceHost host = null;

        static void StartService()
        {
            host = new ServiceHost(typeof(ClassifierJobService));
            host.Open();
        }

        static void CloseService()
        {
            if (host.State != CommunicationState.Closed)
            {
                host.Close();
            }
        }

        static void Main(string[] args)
        {
            StartService();

            Console.WriteLine("Classifier Manager Service is running....");
            Console.ReadKey();

            CloseService();
        }
    }
}