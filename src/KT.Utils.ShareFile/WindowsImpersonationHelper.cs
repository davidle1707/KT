using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace KT.Utils.ShareFile;

//refer: https://docs.microsoft.com/en-us/dotnet/api/system.security.principal.windowsidentity.runimpersonated?view=dotnet-plat-ext-3.1
internal class WindowsImpersonationHelper
{
    private readonly string _domain;
    private readonly string _userName;
    private readonly string _password;

    public WindowsImpersonationHelper(string domain, string userName, string password)
    {
        _domain = domain;
        _userName = userName;
        _password = password;
    }

    public (bool Success, string Error) Impersonate(Action impersonated)
    {
        var returnValue = LogonUser(_userName, _domain, _password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, out var safeAccessTokenHandle);
        if (!returnValue)
        {
            return (false, $"LogonUser failed with error code : {Marshal.GetLastWin32Error()}");
        }

        // Console.WriteLine("Before impersonation: " + WindowsIdentity.GetCurrent().Name);

        // Note: if you want to run as unimpersonated, pass  
        //       'SafeAccessTokenHandle.InvalidHandle' instead of variable 'safeAccessTokenHandle'  
#pragma warning disable CA1416 // Validate platform compatibility
        WindowsIdentity.RunImpersonated(safeAccessTokenHandle, () =>
        {
            impersonated();
        });
#pragma warning restore CA1416 // Validate platform compatibility

        return (true, null);
    }

    #region Dll Imports

    const int LOGON32_PROVIDER_DEFAULT = 0;
    const int LOGON32_LOGON_INTERACTIVE = 2;

    [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, out SafeAccessTokenHandle phToken);

    #endregion
}
