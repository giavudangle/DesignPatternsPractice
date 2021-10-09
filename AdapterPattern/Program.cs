using System;

namespace AdapterPattern
{
    interface ILightningPhone
    {
        void recharge();
        void useLightning();
    }


    interface IMicroUsbPhone
    {
        void recharge();
        void useMicroUsb();
    }

    public class Iphone : ILightningPhone
    {
        private bool connector;
        public void recharge()
        {
            if (connector)
            {
                Console.WriteLine("Recharge started");
                Console.WriteLine("Recharge finished");
            }
            else
            {
                Console.WriteLine("Connect Lightning first");
            }
        }

        public void useLightning()
        {
            connector = true;
            Console.WriteLine("Lightning connected");

        }
    }

    public class Android : IMicroUsbPhone
    {
        private bool connector;

        public void recharge()
        {
            if (connector)
            {
                Console.WriteLine("Recharge started");
                Console.WriteLine("Recharge finished");
            }
            else
            {
                Console.WriteLine("Connect MicroUsb first");
            }
        }

        public void useMicroUsb()
        {
            connector = true;
            Console.WriteLine("MicroUsb connected");
        }
    }

    class LightningToMicroUsbAdapter : IMicroUsbPhone
    {
        private readonly ILightningPhone lightningPhone;
        public LightningToMicroUsbAdapter(ILightningPhone lightningPhone)
        {
            this.lightningPhone = lightningPhone;
        }
        public void useMicroUsb()
        {
            Console.WriteLine("MicroUsb connected");
            lightningPhone.useLightning();
        }
        public void recharge()
        {
            lightningPhone.recharge();
        }
    }

    class Program
    {
        static void rechargeMicroUsbPhone(IMicroUsbPhone phone)
        {
            phone.useMicroUsb();
            phone.recharge();
        }
        static void rechargeLightningPhone(ILightningPhone phone)
        {
            phone.useLightning();
            phone.recharge();
        }

        static void Main(string[] args)
        {
            Android android = new Android();
            Iphone iPhone = new Iphone();
            Console.WriteLine("Recharging android with MicroUsb");
            rechargeMicroUsbPhone(android);
            Console.WriteLine("Recharging iPhone with Lightning");
            rechargeLightningPhone(iPhone);
            Console.WriteLine("Recharging iPhone with MicroUsb");
            rechargeMicroUsbPhone(new LightningToMicroUsbAdapter(iPhone));
        }
    }
}
