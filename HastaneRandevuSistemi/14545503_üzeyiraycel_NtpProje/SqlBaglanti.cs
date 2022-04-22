using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14545503_üzeyiraycel_NtpProje
{
    public class SqlBaglanti
    {
        public OleDbConnection baglanti { get; set; }
        public OleDbConnection yeniBaglanti()
        {
            
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=J:\\14545503_üzeyiraycel_ntpProje\\14545503_üzeyiraycel_NtpProje\\14545503_üzeyiraycel_NtpProje\\hastanerandevu.accdb");
            baglanti.Open();
            return baglanti;
        }

    }
}
