using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Sanatcı listesi oluşturma
        List<Sanatci> sanatcilar = new List<Sanatci>
        {
            new Sanatci("Ajda Pekkan", 1968, "Pop", 20_000_000),
            new Sanatci("Sezen Aksu", 1971, "Türk Halk Müziği/Pop", 10_000_000),
            new Sanatci("Funda arar", 1999, "Pop", 3_000_000),
            new Sanatci("Sertab Erener", 1994, "Pop", 5_000_000),
            new Sanatci("Sıla", 2009, "Pop", 3_000_000),
            new Sanatci("Serdar Ortaç", 1994, "Pop", 10_000_000),
            new Sanatci("Tarkan", 1992, "Pop", 40_000_000),
            new Sanatci("Hande Yener", 1999, "Pop", 7_000_000),
            new Sanatci("Hadise", 2005, "Pop", 5_000_000),
            new Sanatci("Gülben Ergen", 1997, "Türk Halk Müziği/Pop", 10_000_000),
            new Sanatci("Neşet Ertaş", 1960, "Türk Halk Müziği/Türk Sanat Müziği", 2_000_000),
            
        };

        // 1. Adı 'S' ile başlayan şarkıcılar
        var sIleBaslayan = sanatcilar.Where(s => s.Ad.StartsWith("S")).ToList();
        Console.WriteLine("Adı 'S' ile başlayan şarkıcılar:");
        foreach (var sanatci in sIleBaslayan)
        {
            Console.WriteLine(sanatci.Ad);
        }

        // 2. Albüm satışları 10 milyon'un üzerinde olan şarkıcılar
        var onMilyonUstu = sanatcilar.Where(s => s.AlbumSatis > 10_000_000).ToList();
        Console.WriteLine("\nAlbüm satışları 10 milyon'un üzerinde olan şarkıcılar:");
        foreach (var sanatci in onMilyonUstu)
        {
            Console.WriteLine(sanatci.Ad);
        }

        // 3. 2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar
        var popSanatcilar = sanatcilar
            .Where(s => s.CikisYili < 2000 && s.MuzikTuru == "Pop")
            .OrderBy(s => s.Ad)
            .GroupBy(s => s.CikisYili)
            .ToList();

        Console.WriteLine("\n2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar:");
        foreach (var grup in popSanatcilar)
        {
            Console.WriteLine($"Yılı: {grup.Key}");
            foreach (var sanatci in grup)
            {
                Console.WriteLine($" - {sanatci.Ad}");
            }
        }

        // 4. En çok albüm satan şarkıcı
        var enCokAlbumSatan = sanatcilar.OrderByDescending(s => s.AlbumSatis).FirstOrDefault();
        Console.WriteLine($"\nEn çok albüm satan şarkıcı: {enCokAlbumSatan.Ad} ({enCokAlbumSatan.AlbumSatis} albüm)");

        // 5. En yeni ve en eski çıkış yapan şarkıcı
        var enYeni = sanatcilar.OrderByDescending(s => s.CikisYili).FirstOrDefault();
        var enEski = sanatcilar.OrderBy(s => s.CikisYili).FirstOrDefault();

        Console.WriteLine($"\nEn yeni çıkış yapan şarkıcı: {enYeni.Ad} ({enYeni.CikisYili})");
        Console.WriteLine($"En eski çıkış yapan şarkıcı: {enEski.Ad} ({enEski.CikisYili})");
    }
}
