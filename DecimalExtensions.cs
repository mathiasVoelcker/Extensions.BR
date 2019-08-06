﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.BR
{
    public static class DecimalExtensions
    {
        /// <summary>
        /// Converte um valor decimal para uma string R$ 9.999,99
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static string ValorMonetario(this decimal valor)
        {
            var valorFormatado = string.Format("{0:#,0.00}", valor);
            return $"R$ {valorFormatado}";
        }
    }
}
