using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLETest1.ViewModel
{
    public interface IBLConnTagParam
    {
        string tagService { get; set; }
        string tagWriteChar { get; set; }
        string tagNotifyChar { get; set; }
    }

    public class BLConnTagParamESP : IBLConnTagParam
    {
        public string tagService { get; set; } = "0000fff0-0000-1000-8000-00805f9b34fb";
        public string tagWriteChar { get; set; } = "0000fff1-0000-1000-8000-00805f9b34fb";
        public string tagNotifyChar { get; set; } = "0000fff2-0000-1000-8000-00805f9b34fb";
    }

    public class BLConnTagParamGuoMing : IBLConnTagParam
    {
        public string tagService { get; set; } = "00002760-08C2-11E1-9073-0E8AC72E1001";
        public string tagWriteChar { get; set; } = "00002760-08C2-11E1-9073-0E8AC72E0001";
        public string tagNotifyChar { get; set; } = "00002760-08C2-11E1-9073-0E8AC72E0002";
    }

}
