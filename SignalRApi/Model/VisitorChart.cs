namespace SignalRApi.Model
{
    public class VisitorChart
    {
        public VisitorChart()
        {
            Counts = new List<int>();
        }
        public string VisitDate { get; set; }
        public List<int> Counts { get; set; } // ilgili tarihte şehir kaç kşi tarafından ziyaret edildi
    }
}
