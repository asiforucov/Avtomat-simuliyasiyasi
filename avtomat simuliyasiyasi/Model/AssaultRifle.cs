using avtomat_simuliyasiyasi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _03_11_2021.Model
{
    class AssaultRifle : Gun
    {
        internal object Model;

        public int AmountOfBullets { get; set; }
        public int MagazineCapacity { get; set; }
        public int CurrentMagazineCount { get; set; }
        public object Power { get; private set; }

        public AssaultRifle(string model, double power, int amountOfBullets, int magazineCapacity) : base(model, power)
        {
            AmountOfBullets = amountOfBullets;
            MagazineCapacity = magazineCapacity;
            CurrentMagazineCount = magazineCapacity;
        }
        #region Reload1

        public string Reload()
        {
            int Empty = MagazineCapacity - CurrentMagazineCount;
            if ((AmountOfBullets - Empty) > 0)
            {
                AmountOfBullets -= Empty;
                CurrentMagazineCount += Empty;
                return $"{Empty} Güllə əlavə olundu";

            }
            else
            {
                CurrentMagazineCount += AmountOfBullets;
                AmountOfBullets = 0;
                return "Qalan güllələr darağa əlavə olundu ";
            }

        }
        #endregion
        #region Reload2
        public string Reload(int count)
        {

            if (count + CurrentMagazineCount > MagazineCapacity)
            {
                return $"Maqazində {MagazineCapacity - CurrentMagazineCount} " +
                    $"yer var siz {count} güllə doldura bilməzsiniz! " +
                    $" maqazin fullandı ";
                Reload();

            }
            else if (AmountOfBullets < count)
            {
                return $"sizn yetəri qədər gülləniz yoxdur \n" +
                    $"qalan gülləniz:{AmountOfBullets}  " +
                    $"və güllə 0 dan fərqlidiseəbu gulleni maqazinə doldurduq eks halda güllə bitmiş olur";
                Reload();
            }
            else
            {
                AmountOfBullets -= count;
                CurrentMagazineCount += count;
                return $"{count} güllə dolduruldu";

            }

        }
        #endregion
        #region Shoot1
        public string Shoot()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = CurrentMagazineCount - 1; i >= 0; i--)
            {

                stringBuilder.Append("   ->   ");
            }
            CurrentMagazineCount = 0;
            return stringBuilder.ToString() + "\n güllə bitdi reload edin";
        }
        #endregion
        #region Shoot2
        public string Shoot(int Count)
        {
            CurrentMagazineCount -= 1;
            return "   ->   ";
        }
        #endregion
        #region Info
        public string Info()
        {
            return $"Model ={Model}\n" +
                $"Power ={Power}\n" +
                $"AmountOfBullets ={AmountOfBullets}\n" +
                $"MagazineCapacity ={MagazineCapacity}\n" +
                $"CurrentMagazineCount ={CurrentMagazineCount}\n";
            #endregion
        }
    }
}
