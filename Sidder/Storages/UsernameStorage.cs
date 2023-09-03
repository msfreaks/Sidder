using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Runtime.Caching;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SidderApp.Storages
{
    internal static class Usernames
    {
        private static MemoryCache Cache { get; set; }

        static Usernames()
        {
            Cache = new MemoryCache("usernameCache");
        }

        public static string ResolveSID(string sidString)
        {
            if (!Cache.Contains(sidString))
            {
                try
                {
                    var usernameValue = new UsernameValue()
                    {
                        NTAccount = new SecurityIdentifier(sidString).Translate(typeof(NTAccount)).ToString(),
                        UserPrincipalName = UserPrincipal.FindByIdentity(Config.CurrentConfig.PrincipalContext, sidString).UserPrincipalName
                    };

                    Cache.Set(sidString, usernameValue, new CacheItemPolicy() { AbsoluteExpiration = DateTime.Now.AddMinutes(60) });
                    return Config.CurrentConfig.UsernameFormat == UsernameFormatType.NTAccount ? usernameValue.NTAccount : usernameValue.UserPrincipalName;
                }
                catch
                {
                    return "SID Resolve Error";
                }
            }
            else
            {
                var usernameValue = (UsernameValue)Cache.Get(sidString);

                return Config.CurrentConfig.UsernameFormat == UsernameFormatType.NTAccount ? usernameValue.NTAccount : usernameValue.UserPrincipalName;
            }
        }

        private class UsernameValue
        {
            public string NTAccount { get; set; }
            public string UserPrincipalName { get; set; }

            public UsernameValue()
            {
                this.NTAccount = string.Empty;
                this.UserPrincipalName = string.Empty;
            }
        }
    }
}
