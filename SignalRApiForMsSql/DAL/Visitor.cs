﻿namespace SignalRApiForMsSql.DAL
{
    public enum Ecity
    {
        İstanbul = 1,
        Ankara = 2,
        Edirne = 3,
        Antalya = 4,
        Bursa = 5
    }
    public class Visitor
    {
        public int VisitorID { get; set; }
        public Ecity City { get; set; }
        public int CityVisitCount { get; set; }
        public DateTime VisitDate { get; set; }
    }

}
