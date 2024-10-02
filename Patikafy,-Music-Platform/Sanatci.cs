public class Sanatci
{
    public string Ad { get; set; }
    public int CikisYili { get; set; }
    public string MuzikTuru { get; set; }
    public int AlbumSatis { get; set; }

    public Sanatci(string ad, int cikisYili, string muzikTuru, int albumSatis)
    {
        Ad = ad;
        CikisYili = cikisYili;
        MuzikTuru = muzikTuru;
        AlbumSatis = albumSatis;
    }
}
