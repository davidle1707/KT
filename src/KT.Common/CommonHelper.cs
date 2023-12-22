using System.Net;
using System.Net.Sockets;

namespace KT.Common;

public static class CommonHelper
{
    public static string MachineName() => Environment.MachineName;

    public static string MachineIpByDns()
    {
        try
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
        }
        catch { }

        return null;
    }

}