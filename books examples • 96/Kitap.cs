using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace books_examples___96
{
    internal class Kitap
    {
        public int Id { get; set; }
        public string AdYazar { get; set; }
        public string SayfaSayisi { get; set; }
        public string Tur { get; set; }
        public bool Okundu { get; set; }
        public DateTime Tarih { get; set; }

        public Kitap(int id, string adyazar, string sayfa, string tur, bool okundu, DateTime tarih)
        {
            Id = id;
            AdYazar = adyazar;
            SayfaSayisi = sayfa;
            Tur = tur;
            Okundu = okundu;
            Tarih = tarih;

        }
    }
}
