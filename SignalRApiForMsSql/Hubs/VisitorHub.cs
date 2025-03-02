using Microsoft.AspNetCore.SignalR;
using SignalRApiForMsSql.Model;

namespace SignalRApiForMsSql.Hubs
{
    public class VisitorHub:Hub
    {
        private readonly VisitorService _visitorService;

        public VisitorHub(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }
        public async Task GetVisitorList() // signalrconsume invoke metodu buraya geliyor
        {
            await Clients.All.SendAsync("ReceiveVisitorList", _visitorService.GetVisitorChartList());
        }
    }
}
