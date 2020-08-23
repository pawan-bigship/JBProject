using Microsoft.OData.Edm;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JBProject.Dtos.Shared
{
    public static class DateFormat
    {
        //public static String FormatOfDate(String date)
        //{
        //    SimpleDateFormat format = new SimpleDateFormat("yyyy-dd-MM HH:mm:ss");
        //    String d = "";
        //    try
        //    {
             
        //        d = format(date);
        //    }
        //    catch (Exception e)
        //    {
        //       // e.Message;
        //    }
        //    return d;
        //}
        public static String RemoveTSeprator(String date)
        {
            SimpleDateFormat format = new SimpleDateFormat("yyyy-dd-MM HH:mm:ss");
            String d="";
                try
            {
                Date date1 = format.Parse(date.Replace("T", " "));
                  d = new SimpleDateFormat("yyyy/dd/MM HH:mm:ss").Format(date1);
                         }
            catch (Exception e)
            {
                
            }
            return d;
        }
        public static String AddingTSeprator(String date)
        {
            SimpleDateFormat format = new SimpleDateFormat("yyyy-dd-MM HH:mm:ss");
            String d="";
            try
            {
                Date date1 = format.Parse(date.Replace(" ", "T"));
                d = new SimpleDateFormat("yyyy/dd/MMTHH:mm:ss").Format(date1);
            }
   catch (Exception e)
            {

            }
            return d;
        }
    }
}
