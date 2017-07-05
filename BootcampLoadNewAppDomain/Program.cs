using System;
using System.Threading;

namespace BootcampLoadNewAppDomain
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain domainA = AppDomain.CreateDomain("MyDomainA");
            AppDomain domainB = AppDomain.CreateDomain("MyDomainB");
            AppDomain domainC = AppDomain.CreateDomain("Boatmaker");

            domainA.SetData("DomainKey", "Domain A value");
            domainB.SetData("DomainKey", "Domain B value");
            domainC.SetData("DomainKey", "Domain Boatmaker's value");
            
            OutputCall();
            domainA.DoCallBack(OutputCall); // CrossAppDomainDelegate call
            domainB.DoCallBack(OutputCall); // CrossAppDomainDelegate call
            domainC.DoCallBack(OutputCall);
            Console.ReadLine();
        }

        public static void OutputCall()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine("the value '{0}' was found in {1}, running on thread Id {2}",
                domain.GetData("DomainKey"), domain.FriendlyName,
                Thread.CurrentThread.ManagedThreadId.ToString());
        }
    }
}
