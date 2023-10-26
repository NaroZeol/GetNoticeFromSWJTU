using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Program.Utilities
{
    public class CheckNetwork
    {
        [DllImport("wininet.dll", EntryPoint = "InternetGetConnectedState")]
        public extern static bool InternetGetConnectedState(out int conState, int reader);

        public static bool IsNetworkConnected
        {
            get
            {
                return InternetGetConnectedState(out int _, 0);
            }
        }
    }
}
