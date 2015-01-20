using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Framework.Interfaces
{
    interface ISecuritySettings
    {
        string EncryptionKey { get; set; }

        List<string> AdminAreaAllowedIpAddresses { get; set; }

        bool HideAdminMenuItemsBasedOnPermissions { get; set; }
    }
}
