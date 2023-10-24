
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Computer
{
    
        interface IComponents { string GetDescription(); }

        class Classroom {
            public List<Computer> Comp { get; set; }
            public Classroom() { Comp = new List<Computer>(); }

            public override string ToString() { string pocitac = "Computer in classroom: ";
                foreach(var stroj in Comp) { pocitac += stroj.GetDescription(); }
                return pocitac;
            }
        }
    class Computer
    {
        public IComponents Motherboard { get; set; }
        public IComponents RAMM { get; set; }
        public IComponents StorageDisk { get; set; }
        public IComponents ProcesorCPU { get; set; }

        public Computer(IComponents motherboard, IComponents ram, IComponents disk, IComponents procesor)
        {
            Motherboard = motherboard;
            RAMM = ram;
            StorageDisk = disk;
            ProcesorCPU = procesor;
        }
        public string GetDescription()
        {
            return ($"Computers with components motherboard {Motherboard.GetDescription()}\n RAM {RAMM.GetDescription()}\n  disk {StorageDisk.GetDescription()}\n  procesor {ProcesorCPU.GetDescription()}");
        }
    }
    class Deska : IComponents
    {
        public string Oznaceni { get; set; }
        public string Vyrobce { get; set; }

        public string GetDescription()
        {
            return ($"signature {Oznaceni} maker {Vyrobce}");
        }
    }

    class Disk : IComponents
    {
        public bool Ssd { get; set; }
        public int Capacity { get; set; }
        public string Konektor { get; set; }

        public string GetDescription()
        {
            return ($"SSD {Ssd} capacity {Capacity} conector {Konektor}");
        }
    }

    class Procesor : IComponents
    {
        public string Vyrobce { get; set; }
        public double Frekvence { get; set; }
        public string Patice { get; set; }

        public string GetDescription()
        {
            return ($"factory {Vyrobce} frequention {Frekvence} patice {Patice}");
        }
    }

    class Ram : IComponents
    {
        public string Typ { get; set; }
        public int Kapacita { get; set; }

        public string GetDescription()
        {
            return $"type {Typ} capacity {Kapacita}";
        }
    }

    class Sestavy 
        {

        public static void Main()
        {
            Deska MB1 = new Deska { Oznaceni = "LOKFSA", Vyrobce = "ASUS" };
            Ram MEM1 = new Ram { Typ = "DDR4", Kapacita = 32 };
            Disk STO1 = new Disk { Ssd = true, Capacity = 512, Konektor = "SATA" };
            Procesor CPU1 = new Procesor { Vyrobce = "AMD", Frekvence = 4.2, Patice = "AM5" };

            Computer stroj1 = new Computer(MB1, MEM1, STO1, CPU1);

            Deska MB2 = new Deska { Oznaceni = "FRDS", Vyrobce = "MSI" };
            Ram MEM2 = new Ram { Typ = "DDR5", Kapacita = 16 };
            Disk STO2 = new Disk { Ssd = false, Capacity = 256, Konektor = "SATA" };
            Procesor CPU2 = new Procesor { Vyrobce = "AMD", Frekvence = 4.8, Patice = "AM4" };

            Computer stroj2 = new Computer(MB2, MEM2, STO2, CPU2);

            Classroom classroom = new Classroom();
            classroom.Comp.Add(stroj1);
            classroom.Comp.Add(stroj2);

            Console.WriteLine(classroom);

            if (classroom.Comp.Count > 1)
            {
                Console.WriteLine("Vyrobce desky druheho pocitace " + ((Deska)classroom.Comp[1].Motherboard).Vyrobce);
            }
        }
        }
    }

