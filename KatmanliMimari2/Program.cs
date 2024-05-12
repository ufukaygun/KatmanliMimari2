
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli_Mimari
{
    #region UI Katmanı
    public class Program
    {
        static void Main(string[] args)
        {
            KullaniciManager kullaniciManager = new KullaniciManager();

            Console.WriteLine("Merhaba Yapmak istediğiniz işlemi seçiniz");
            Console.WriteLine("1- Kişi Eklemek");
            Console.WriteLine("2- Kişi Silmek");

            int secim = int.Parse(Console.ReadLine());

            if (secim == 1)
            {
                Console.WriteLine("Eklemek istediğiniz kişinin adını giriniz");
                Kullanici kullanici = new Kullanici();
                kullanici.Ad = Console.ReadLine();
                kullaniciManager.Ekle(kullanici);
            }
            else if (secim == 2)
            {
                Console.WriteLine("Silmek istediğiniz kişinin adını giriniz");
                Kullanici kullanici = new Kullanici();
                kullanici.Ad = Console.ReadLine();
                kullaniciManager.Sil(kullanici);
            }




            //Uygulamaya bazı özellikleri olan (fiyat stok vs.) urun sınıfı ekleyin


            // UrunManager sınıfının bir örneği oluşturuluyor
            UrunManager urunManager = new UrunManager();

            Console.WriteLine("Merhaba Yapmak istediğiniz işlemi seçiniz");
            Console.WriteLine("3- Urun Eklemek");
            Console.WriteLine("4- Urun Silmek");
            Console.WriteLine("5- Urun Güncellemek");

            int tercih = int.Parse(Console.ReadLine());

            if (tercih == 3)
            {
                Urun urun = new Urun();

                Console.WriteLine("Eklemek istediğiniz Ürünün adını giriniz");
                urun.UrunAdi = Console.ReadLine();

                Console.WriteLine("Eklemek istediğiniz Ürünün Fiyatını giriniz");
                urun.Fiyat = int.Parse(Console.ReadLine());

                Console.WriteLine("Eklemek istediğiniz Ürünün Stoğunu giriniz");
                urun.Stok = int.Parse(Console.ReadLine());

                urunManager.UrunEkle(urun);
            }
            else if (tercih == 4)
            {
                Console.WriteLine("Silmek istediğiniz ürünün Id'sini giriniz");
                Urun urun = new Urun();
                urun.Id = int.Parse(Console.ReadLine());
                urunManager.UrunSil(urun);
            }
            else if (tercih == 5)
            {
                Urun urun = new Urun();
                Console.WriteLine("Güncellemek istediğiniz ürünün Id'sini giriniz");
                urun.Id = int.Parse(Console.ReadLine());

                Console.WriteLine("Güncellemek istediğiniz ürünün yeni adını giriniz");
                urun.UrunAdi = Console.ReadLine();

                Console.WriteLine("Güncellemek istediğiniz ürünün yeni Fiyatını giriniz");
                urun.Fiyat = int.Parse(Console.ReadLine());

                Console.WriteLine("Güncellemek istediğiniz ürünün yeni Stoğunu giriniz");
                urun.Stok = int.Parse(Console.ReadLine());
                urunManager.UrunGuncelle(urun);
            }
            Console.ReadLine();
        }
    }
    #endregion





    #region Business (Ara KAtman) İş Katmanı

    class KullaniciManager
    {
        KullaniciDAL _kullaniciDAL = new();
        public void Ekle(Kullanici kullanici)
        {
            if (kullanici.Ad.Length >= 3)
            {
                _kullaniciDAL.Ekle(kullanici);
            }
            else
            {
                Console.WriteLine("3 harften küçük olamaz");
            }

        }
        public void Sil(Kullanici kullanici)
        {
            if (!string.IsNullOrWhiteSpace(kullanici.Ad))
            {
                _kullaniciDAL.Sil(kullanici);
            }
            else
            {
                Console.WriteLine("silinecek kullanıcı adı boş bırakılamaz");
            }
        }
    }

    class UrunManager
    {
        UrunDal _urunDal = new();

        // UrunDal sınıfı burada oluşturulmalıdır.

        // Ürün eklemek için bir metod
        public void UrunEkle(Urun urun)
        {
            if (urun.Stok < 0 || urun.Fiyat <= 0)
            {
                Console.WriteLine("Hata: Stok ve fiyat değerleri negatif olamaz!");
                return; // Metottan çık
            }
            else
            {
                // Burada iş mantığını yazabilirsiniz.
                Console.WriteLine("Ürün eklendi:");
                Console.WriteLine("Ürün Adı: " + urun.UrunAdi);
                Console.WriteLine("Stok: " + urun.Stok);
                Console.WriteLine("Fiyat: " + urun.Fiyat);
                UrunDal urunDal = new();
                _urunDal.Ekle(urun);
            }


        }

        // Ürün silmek için bir metod
        public void UrunSil(Urun urun)
        {
            // Burada iş mantığını yazabilirsiniz.
            // Örneğin, veritabanından ilgili ürünü silme işlemi yapılabilir.
            Console.WriteLine("Ürün silindi:");
            Console.WriteLine("Ürün ID: " + urun.Id);
            UrunDal urunDal = new();
            _urunDal.Sil(urun);
        }

        public void UrunGuncelle(Urun urun)
        {
            if (urun.Stok < 0 || urun.Fiyat <= 0)
            {
                Console.WriteLine("Hata: Stok ve fiyat değerleri negatif olamaz!");
                return; // Metottan çık
            }
            else
            {
                // Burada iş mantığını yazabilirsiniz.
                Console.WriteLine("Ürün güncellendi:");
                Console.WriteLine("Ürün ID: " + urun.Id);
                Console.WriteLine("Yeni Ürün Adı: " + urun.UrunAdi);
                Console.WriteLine("Yeni Stok: " + urun.Stok);
                Console.WriteLine("Yeni Fiyat: " + urun.Fiyat);
                _urunDal.Guncelle(urun);
            }
        }

    }

    #endregion







    #region DAL (Data Access Layer) Veri Erişim katmanı

    class KullaniciDAL
    {
        public void Ekle(Kullanici kullanici)
        {
            Console.WriteLine("Kullanıcı veri tabanına eklendi");
        }
        public void Sil(Kullanici kullanici)
            => Console.WriteLine("Kullancıı veirtabanından silindi");

    }
    class UrunDal
    {
        KatmanliMimariContext _context = new();

        public void Ekle(Urun urun)
        {
            Console.WriteLine("Ürün veri tabanına eklendi");
            _context.Add(urun);
            _context.SaveChanges();
        }
        public void Sil(Urun urun)
            => Console.WriteLine("Ürün veirtabanından silindi");
        public void Guncelle(Urun urun)
        {
            Console.WriteLine("Ürün güncellendi");
            using (var _c = new KatmanliMimariContext())
            {
                _c.Update(urun);
                _c.SaveChanges();
            }
        }

    }
    // DbContext sınıfı oluşturuluyor ve Urun sınıfı bir veritabanı tablosuna eşleniyor
    public class KatmanliMimariContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Veritabanı bağlantı dizesini burada yapılandırın
            optionsBuilder.UseSqlServer("Server=.;Database=KatmanliDb;User Id=sa;Password=1234;TrustServerCertificate=true");
        }

        public DbSet<Urun> Urunler { get; set; }

    }


    #endregion







    #region Entity (YArdımcı KAtman) Veri tabanı tablolarının bulunacağı katman

    class Kullanici
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }

    }

    public class Urun
    {
        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public int Stok { get; set; }
        public int Fiyat { get; set; }

    }
}

#endregion









