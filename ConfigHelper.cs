using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyHelper
{
    public static class ConfigHelper
    {
        public static string jsonPath = "processes-config.json";

        public static List<string> GetProcesses()
        {

            using (StreamReader sr = new StreamReader(jsonPath))
            {
                string json = sr.ReadToEnd();
                var processesInfo = JsonConvert.DeserializeObject<ProcessesInfo>(json);
                return processesInfo.Processes;
            }
        }
    }


    public class ProcessesInfo
    {
        public List<string> Processes { get; set; } = new List<string>();
    }
}
