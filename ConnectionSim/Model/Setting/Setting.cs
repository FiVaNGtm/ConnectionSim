using System;
using System.IO;
using System.Text.Json;

namespace ConnectionSim.Model.Setting
{
    public class Setting
    {
        public Api Api { get; set; }

        public Setting()
        {
            Api = new();
        }
    }
}