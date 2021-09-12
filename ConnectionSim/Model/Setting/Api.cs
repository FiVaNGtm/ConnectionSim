namespace ConnectionSim.Model.Setting
{
    public class Api
    {
        public NewOrder NewOrder { get; set; }

        public Api()
        {
            NewOrder = new();
        }
    }
}