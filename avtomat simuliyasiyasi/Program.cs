using System;
using _03_11_2021.Model;

namespace avtomat_simuliyasiyasi
{
    class Program
    {
        static void Main(string[] args)
        {

            AssaultRifle assaultRifle = CreateGun();
            Console.WriteLine("Silahiniz yaradildi :");
            assaultRifle.Info();

            while (true)
            {
                int InputMenu = PrintAndReturnI($"Menu:{assaultRifle.Model}\n" +
                   "1 - ates aç (tek tek)\n" +
                   "2 - ates aç  (auto)\n" +
                   "3 - Reload ele  (say ile)\n" +
                   "4 - Reload ele  (Auto)\n" +
                   "5 - Silahniz hazqinda informasiya\n" +
                   "6 - Quit\n");
                if (InputMenu == 6)
                {
                    break;
                }
                switch (InputMenu)
                {
                    case 1:
                        Console.WriteLine(assaultRifle.Shoot(1));
                        break;
                    case 2:
                        Console.WriteLine(assaultRifle.Shoot());
                        break;
                    case 3:
                        int Reloadcounut = PrintAndReturnI("gulle sayi daxil edin");
                        Console.WriteLine(assaultRifle.Reload(Reloadcounut));
                        break;
                    case 4:
                        Console.WriteLine(assaultRifle.Reload());
                        break;
                    case 5:
                        Console.WriteLine(assaultRifle.Info());
                        break;
                    default:
                        break;
                }
            }








        }
        public static AssaultRifle CreateGun()
        {
            string GunNAme = PrintAndReturn("Salam Silahinizin modelin" +
                " qeyd edin zehmet olmasa:");
            int Power = PrintAndReturnI("silahnizin gucun daxil edin:");
            int AmountOfBullets = PrintAndReturnI("ne qeder gulleye ehtiyaciniz olacaq?");
            int MagazineCapacity = PrintAndReturnI("silahnizin magazin tutumu ne qeder olacaq");
            AssaultRifle assaultRifle = new AssaultRifle(GunNAme, Power, AmountOfBullets, MagazineCapacity);
            return assaultRifle;
        }
        public static string PrintAndReturn(string output)
        {
        Start:
            try
            {
                Console.WriteLine(output);
                return Console.ReadLine();
            }
            catch (Exception)
            {

                Console.WriteLine("invalid input");
            }

            goto Start;

        }
        public static int PrintAndReturnI(string output)
        {
        Start:
            try
            {
                Console.WriteLine(output);
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {

                Console.WriteLine("invalid input");
            }

            goto Start;


        }
    }
}