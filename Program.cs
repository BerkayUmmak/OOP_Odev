namespace OOP.Odev
{
    class Program
    {
        static List<KiralikEv> kiralikEvler = new List<KiralikEv>();
        static List<SatilikEv> satilikEvler = new List<SatilikEv>();

        static void Main(string[] args)
        {

            while (true)
            {

                MenuGetir();
            }
        }

        public static void MenuGetir()
        {

            Console.WriteLine("**** Emlakçı Uygulamasına Hoşgeldiniz ****\n");
            Console.WriteLine("Ev Tipi Seçiniz:\n");
            Console.WriteLine("1.Kiralık Ev\n2.Satılık Ev\n3.Çıkış");
            byte evscm = byte.Parse(Console.ReadLine());
            Console.Clear();
            string tur = "";
            if (evscm == 1)
            {
                tur = "Kiralık";
            }
            else if (evscm == 2)
            {
                tur = "Satılık";
            }
            else if (evscm == 3) { Environment.Exit(0); }
            else
            {
                Console.WriteLine("Hatalı bir seçim yaptınız tekrar denemek için herhangi bir tuşa basınız.");
                Console.ReadKey();
                Console.Clear();
                MenuGetir();
            }

            Console.WriteLine($"**{tur} Ev Menü**\n\n1.Ev Girişi\n2.Kayıtlı Evleri Göster\n3.Geri Dön\n4.Kapat\n\n**{tur} Ev Menü**");
            byte menuSecim = byte.Parse(Console.ReadLine());
            Console.Clear();



            switch (menuSecim)
            {
                case 1:
                    if (evscm == 1) { EvBilgiGiris<KiralikEv>(); }
                    else if (evscm == 2) { EvBilgiGiris<SatilikEv>(); }

                    break;
                case 2:

                    if (evscm == 1) { KiralikEvGetir(); }
                    else if (evscm == 2) { SatilikEvGetir(); }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("**Menüye Dönmek için Herhangi bir tuşa basınız!**");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Başlangıç menüsüne yönlendiriliyorsunuz...");
                    Console.ReadKey();
                    Console.Clear();
                    MenuGetir();
                    break;
                case 4:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Program Kapatılıyor...");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Hatalı Seçim Yaptınız !!!");
                    break;
            }
        }
        public static void EvBilgiGiris<T>() where T : Ev, new()
        {
            var ev = new T();

            Console.WriteLine("Lütfen Semt Bilgisi Giriniz : ");
            ev.Semt = Console.ReadLine();

            Console.WriteLine("Lütfen Kat Numarasını Giriniz : ");
            ev.KatNo = int.Parse(Console.ReadLine());

            Console.WriteLine("Lütfen Oda Sayısını Giriniz : ");
            ev.OdaSayisi = int.Parse(Console.ReadLine());

            Console.WriteLine("Lütfen Alan Bilgisini Giriniz : ");
            ev.Alan = double.Parse(Console.ReadLine());

            if (ev is KiralikEv kiralikEv)
            {
                Console.WriteLine("Lütfen Kira Bedelini Giriniz : ");
                kiralikEv.KiraFiyati = double.Parse(Console.ReadLine());

                Console.WriteLine("Lütfen Depozito Bedelini Giriniz : ");
                kiralikEv.Depozito = double.Parse(Console.ReadLine());

                kiralikEvler.Add(kiralikEv);
                DosyayaYaz(kiralikEv.ToString(), "kiralik_evler.txt");
            }
            else if (ev is SatilikEv satilikEv)
            {
                Console.WriteLine("Lütfen Satış Bedelini Giriniz : ");
                satilikEv.SatisFiyati = double.Parse(Console.ReadLine());

                satilikEvler.Add(satilikEv);
                DosyayaYaz(satilikEv.ToString(), "satilik_evler.txt");
            }

            Console.WriteLine();
            Console.WriteLine("Ev girişi başarılı! Devam etmek istiyor musunuz? (E/H)");
            string cevap = Console.ReadLine();


            if (cevap.ToUpper() == "E")
            {
                Console.Clear();
                EvBilgiGiris<T>();
            }
            else
            {
                Console.Clear();
                MenuGetir();
            }
        }
        public static void SatilikEvGetir()
        {

            Console.WriteLine("\nSatılık Evler:");
            Console.WriteLine(File.ReadAllText("satilik_evler.txt"));
        }
        public static void KiralikEvGetir()
        {
            Console.WriteLine("Kiralık Evler:");
            Console.WriteLine(File.ReadAllText("kiralik_evler.txt"));
        }

        public static void DosyayaYaz(string veri, string dosyaYolu)
        {
            using (StreamWriter sw = new StreamWriter(dosyaYolu, true))
            {
                sw.WriteLine(veri);
            }
        }
    }
}