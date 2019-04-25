using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.cs
{
    class Program
    {
        static string userInput;

        static void Main(string[] args)
        {
            Car masin1 = new Car("Bmw", "m5");
            Car masin2 = new Car("Mercedec", "Sclass");
            do
            {
                Console.WriteLine("1.Go");
                Console.WriteLine("2.Top up ");
                Console.WriteLine("3.Local km ");
                Console.WriteLine("4.Global km ");
                Console.WriteLine("5.Exit");
                Console.Write(">>>>>>");
                userInput = Console.ReadLine();
                if (CheckInput(userInput))
                {
                    switch (userInput)
                    {
                        case "1":
                            masin1.Go();



                            break;
                        case "2":
                            masin1.Topup();
                            break;
                        case "3":
                            masin1.Stop();
                            break;
                        case "4":
                            Console.WriteLine("Global km bu qederdir");
                            break;
                        case "5":
                            Console.WriteLine("Xidmetden istifade etdiyiniz ucun tesekkurler");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Xahis edirik yuxardikaki reqemlerden birin daxil edin");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Xahis edirik reqem  daxil edin");
                }
            } while (userInput != "5");




        }
        static public bool CheckInput(string input)
        {
            try
            {
                int userInput = Convert.ToInt32(input);
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }
    }
    class Car
    {
        public string Marka;
        public string Model;
        private int FullEff;
        private double CurrentEff = 50;
        private double MaxFuell;
        public double LocalKM;
        public double GlobalKm;
        public double UsedEff;
        public double neededEff;
        public double AllEff;

        public Car(string marka, string model, int fullEff = 20, int maxFuell=60)
        {
            Marka = marka;
            Model = model;
            FullEff = fullEff;
            MaxFuell = maxFuell;
        }
        public void Go()
        {
            double neededKM = 0;
            while (neededKM == 0)
            {
                Console.Write("Nece km Getmek isdeyirsiz? : ");
                string input = Console.ReadLine();


                if (CheckInput(input))
                {
                    neededKM = Convert.ToDouble(input);

                    if (CurrentEff <= neededKM / 100 * FullEff)
                    {
                        Console.WriteLine("Sizin benziniz yoxdur.Lütfen Benzin doldurun");

                    }
                    else
                    {
                        UsedEff= neededKM / 100 * FullEff;
                        CurrentEff = CurrentEff - UsedEff;


                        Console.WriteLine("Siz {0} km getdiniz.{1} lt benizin istifade etdiniz ve {2} lt benizininiz qaldi", neededKM, UsedEff, CurrentEff);

                    }
                }
                else
                {
                    Console.WriteLine("Xahis edirik reqem gonderin");
                }
            }



        }
        
        
        public void Topup()
        {
            Console.Write("Nece lt benzin doldurmaq isteyirsiniz?");
            string input = Console.ReadLine();
            double neededEff = 0;
            while (neededEff == 0) { 
            if(CheckInput(input))
                {
                neededEff = Convert.ToDouble(input);
                    if(neededEff+ CurrentEff > MaxFuell)
                    {

                        Console.WriteLine("Siz {0} lt benzin doldura bilmezsiniz cunki benzin ceninizin hecmi kicikdir.", neededEff);
                    }
                    else
                    {
                        AllEff = CurrentEff + neededEff;
                        Console.WriteLine("Siz {0} lt benzin yuklediniz. Cendeki benzin miqdari {1} lt-dir.", neededEff, AllEff);
                    }

                
            }
            else
            {
                Console.WriteLine("Xahis edirik reqem gonderin");
            }

            }
        }
        public void Stop()
        {
            
            //Console.WriteLine("Siz {0} km yol getmisiniz ve {1} lt benzin var", neededKM, UsedEff);
        }
        public bool CheckInput(string input)
        {
            try
            {
                Convert.ToUInt32(input);
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

    }

}

