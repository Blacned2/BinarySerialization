using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySerilestirme_III
{
    [Serializable]
    public class Urun
    {
        public int _urunId;
        public string _urunAd;
        public double _urunFiyat;
        public double _kdvDahilFiyat;

        public int UrunId
        {
            get { return _urunId; }
            set { _urunId = value; }
        }
        public string UrunAd
        {
            get { return _urunAd; }
            set { _urunAd = value; }
        }
        public double UrunFiyat
        {
            get { return _urunFiyat; }
            set { _urunFiyat = value; }
        }
        public double KdvDahilFiyat
        {
            get { return _kdvDahilFiyat; }
            set { _kdvDahilFiyat = value; }
        }
        public Urun(int urunId, string urunAd, double urunFiyat)
        {
            this.UrunId = urunId;
            this.UrunAd = urunAd;
            this.UrunFiyat = urunFiyat;
            KdvDahilFiyat = urunFiyat + (urunFiyat * 0.08);
        }

        public override string ToString()
        {
            return UrunAd;
        }
    }
}
