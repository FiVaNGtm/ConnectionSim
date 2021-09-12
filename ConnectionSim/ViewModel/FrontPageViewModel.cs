using ConnectionSim.Model.Infrastructure.Api;

namespace ConnectionSim.ViewModel
{
    public class FrontPageViewModel
    {
        public string      PageTitle      { get; set; } = "通信";
        public string      ReceiveCaption { get; set; } = "受信データ";
        public string      SendCaption    { get; set; } = "送信データ";
        public ApiAccessor ApiAccessor    { get; set; } = new();

    }
}