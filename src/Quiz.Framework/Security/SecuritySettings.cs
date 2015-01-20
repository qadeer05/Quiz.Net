using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Framework.Interfaces;

namespace Quiz.Framework.Security
{
    public class SecuritySettings: ISecuritySettings
    {
        public string EncryptionKey { get; set; }

        public List<string> AdminAreaAllowedIpAddresses { get; set; }

        public bool HideAdminMenuItemsBasedOnPermissions { get; set; }
    }
}
