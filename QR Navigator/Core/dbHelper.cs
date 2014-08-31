using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QRNavigatorData
{
    class dbHelper
    {
        private const string ConString = "Data Source='isostore:/QRDB.sdf'";
        public static  string QRVal  ;
     public    static void CreateDatabase()
        { 
        using (var context =new QRNavigatorDbContext(ConString))
        {
            if (!context.DatabaseExists())
            {
                context.CreateDatabase();
            }
        }
        }

     public static void SaveQRVal(QrHistory NewQr)
     {

         using (var context = new QRNavigatorDbContext(ConString))
         {
             context.QrHistory.InsertOnSubmit(NewQr );
             context.SubmitChanges();
         }
     }
    }
}
