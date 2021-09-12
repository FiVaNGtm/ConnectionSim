using System.IO;
using System.Text.Json;

namespace ConnectionSim.Model.Setting
{
    public class SettingFileController
    {
        public Setting Setting { get; set; }

        public SettingFileController()
        {
            // TODO: 設定ファイルで通信内容を指定する
            Setting = new();
            var     opt        = new JsonSerializerOptions() { WriteIndented = true };
            var a = JsonSerializer.Serialize(Setting, opt);
            File.WriteAllText("setting.json", a);
            var     jsonstring = File.ReadAllText("setting.json");
            Setting s          = JsonSerializer.Deserialize<Setting>(jsonstring);
        }
    }
}