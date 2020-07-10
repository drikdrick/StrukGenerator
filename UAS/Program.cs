using System;
using System.Collections;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UAS
{

    class Program
    {

        enum TipeX { Kemeja, Kaos, Dress , Jas };
        enum UkuranX { S, M, L , XL, XXL };


        public static int Panjang = 1000;
        public static Pakaian[] PakaianUmum = new Pakaian[Panjang];
        private static void Main()
        {
            Pakaian Baru = new Pakaian();
            Console.Title = "Pakaian";
            
            Console.Clear();
            
            string val;
            Console.WriteLine("                  MENU                  ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Input Data");
            Console.WriteLine("2. Tampil Data");
            Console.WriteLine("3. Keluar");
            Console.WriteLine("========================================");

            Console.Write("Masukkan Kode [1-3] : ");

            val = Console.ReadLine();

            int a = Convert.ToInt32(val);
            if (a == 1)
            {
                InputData();
            }
            else if (a == 2)
            {
                if(Panjang == 1000)
                {
                    Console.Clear();
                    Console.WriteLine("Tanggal : " + (DateTime.Now).ToString("dd-MMMM-yyyy", new System.Globalization.CultureInfo("id-ID")));
                    Console.WriteLine("============================================================================================");
                    Console.WriteLine("Tipe \t Ukuran \t Warna \t Harga \t \t Qty \t Subtotal");
                    Console.WriteLine("============================================================================================");

                    Console.WriteLine("Object reference not set to an instance of an object.");
                    Console.ReadKey();
                }
                else
                {
                    TampilData(Panjang, PakaianUmum);
                }


            }
            else if (a == 3)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Kode Tidak Valid");
                System.Threading.Thread.Sleep(500);
            }

            Main();

        }
        public class Pakaian
        {

            public string Tipe;
            public int Ukuran;
            public string Warna;
            public double Harga;
            public int Qty;
            public double Subtotal;

            public void SetData(string Tipe, int Ukuran, string Warna, double Harga, int Qty, double Subtotal)
            {
                this.Tipe = Tipe;
                this.Ukuran = Ukuran;
                this.Warna = Warna;
                this.Harga = Harga;
                this.Qty = Qty;
                this.Subtotal = this.Harga * this.Qty;
            }
            public void printData()
            {
                TipeX e = TipeX.Kemeja;
                TipeX f = (TipeX)(Enum.GetValues(e.GetType())).GetValue(Convert.ToInt32(Tipe));

                
                UkuranX x = UkuranX.S;
                UkuranX y = (UkuranX)(Enum.GetValues(x.GetType())).GetValue(Ukuran);

                string HargaRp = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp {0:N}", Harga);
                string SubtotalRp = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp {0:N}", Subtotal);

                Console.WriteLine(f +"\t"+ y +" \t \t "+Warna + "\t" + HargaRp + "\t" + Qty +"\t" + SubtotalRp + "\t");

                
            }
            public void Dispose()
            {
                this.Tipe = "";
                this.Ukuran = 0;
                this.Warna = "";
                this.Harga = 0;
                this.Qty = 0;
                this.Subtotal = 0;
            }

        }

        // When you implement IEnumerable, you must also implement IEnumerator.
        public class PeopleEnum : IEnumerator
        {
            public Pakaian[] _datapakaian;

            // Enumerators are positioned before the first element
            // until the first MoveNext() call.
            int position = -1;

            public PeopleEnum(Pakaian[] list)
            {
                _datapakaian = list;
            }

            public bool MoveNext()
            {
                position++;
                return (position < _datapakaian.Length);
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public Pakaian Current
            {
                get
                {
                    try
                    {
                        return _datapakaian[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        private static void TampilData( int a,Pakaian[] A)
        {
            double Total = 0;
            Console.Clear();

            Console.WriteLine("Tanggal : " + (DateTime.Now).ToString("dd-MMMM-yyyy", new System.Globalization.CultureInfo("id-ID")));
            Console.WriteLine("============================================================================================");
            Console.WriteLine("Tipe \t Ukuran \t Warna \t Harga \t \t Qty \t Subtotal");
            Console.WriteLine("============================================================================================");
            for (int i = 0; i < a; i++)
            {
                A[i].printData();
                Total = Total+ A[i].Subtotal;
            }

            string TotalRp = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp {0:N}", Total);
            Console.WriteLine("============================================================================================");
            Console.WriteLine("\t \t \t \t \t \t Total : " + TotalRp);


            Console.ReadKey();

        }
        private static void InputData()
        {
            Console.Clear();
            
            string jumlah;
            string tipe;
            string ukuran;
            string warna;
            string harga;
            string qty;
            int a;

            Console.WriteLine("===============================================");
            Console.WriteLine("                  INPUT DATA                   ");
            Console.WriteLine("===============================================");
            

            Console.Write("Masukkan Jumlah Pakaian : ");

            jumlah = Console.ReadLine();
            a = Convert.ToInt32(jumlah);
            Panjang = a;
            Pakaian[] myPakaian = InitializeArray<Pakaian>(a);

            for (int i = 0; i < a; i++)
            {
                myPakaian[i] = new Pakaian();
                Console.WriteLine("Tipe Pakaian :");
                Console.WriteLine("1. Kemeja");
                Console.WriteLine("2. Kaos");
                Console.WriteLine("3. Dress");
                Console.WriteLine("4. Jas");

                Console.Write("Masukkan Tipe [1-4] : ");
                tipe = Console.ReadLine();
                while(Convert.ToInt32(tipe) < 1 || Convert.ToInt32(tipe) > 4)
                {
                    Console.WriteLine("Kode Tidak Valid");
                    System.Threading.Thread.Sleep(500);
                    Console.Write("Masukkan Tipe [1-4] : ");
                    tipe = Console.ReadLine();

                }
                
                    myPakaian[i].Tipe = tipe;
                


                Console.WriteLine("Ukuran :");
                Console.WriteLine("1. S");
                Console.WriteLine("2. M");
                Console.WriteLine("3. L");
                Console.WriteLine("4. XL");
                Console.WriteLine("5. XXL");

                Console.Write("Masukkan Ukuran [1-5] : ");
                ukuran = Console.ReadLine();
                
                while (Convert.ToInt32(ukuran) <1 || Convert.ToInt32(ukuran) > 5)
                {
                    Console.WriteLine("Kode Tidak Valid");
                    System.Threading.Thread.Sleep(500);
                    Console.Write("Masukkan Ukuran [1-5] : ");
                    ukuran = Console.ReadLine();
                }
                
                    myPakaian[i].Ukuran = Convert.ToInt32(ukuran);
                

                Console.Write("Masukkan Warna : ");
                warna = Console.ReadLine();
                myPakaian[i].Warna = warna;
                Console.Write("Masukkan Harga : ");
                harga = Console.ReadLine();
                myPakaian[i].Harga = Convert.ToDouble(harga);
                Console.Write("Masukkan Qty : ");
                qty = Console.ReadLine();
                myPakaian[i].Qty = Convert.ToInt32(qty);
                myPakaian[i].SetData(myPakaian[i].Tipe, myPakaian[i].Ukuran, myPakaian[i].Warna, myPakaian[i].Harga, myPakaian[i].Qty, myPakaian[i].Subtotal);
                PakaianUmum[i] = myPakaian[i];


            }
            

                Console.ReadKey();
            Main();
        }

        private static T[] InitializeArray<T>(int length) where T : new()
        {
            T[] array = new T[length];
            for (int i = 0; i < length; ++i)
            {
                array[i] = new T();
            }

            return array;
        }
    }
}
