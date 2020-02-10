using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEasynvest.CrossCutting.Helper
{
    public static class Util
    {
        public static int DataDiff(char tipoRetorno, DateTime dataFrom, DateTime dataTo)
        {

            TimeSpan timeSpanValor;

            timeSpanValor = dataTo - dataFrom;

            if (tipoRetorno == 'd')
            {
                return timeSpanValor.Days;
            }
            else if (tipoRetorno == 'm')
            {
                double dblValue = 12 * (dataFrom.Year - dataTo.Year) + dataFrom.Month - dataTo.Month;
                return Convert.ToInt32(Math.Abs(dblValue));
            }
            else if (tipoRetorno == 'y')
            {
                return Convert.ToInt32((timeSpanValor.Days) / 365);
            }


            return 0;




        }
    }
}
