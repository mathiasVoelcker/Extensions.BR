using Extensions.MV;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.BR
{
    public static class StringExtensions
    {
        private static string[] PREPOSICOES = new string[] { "e", "de", "da", "das", "do", "dos", "com", "na", "nas", "no", "nos" };

        private static string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
        private static string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

        public static string RemoverAcentos(this string text)
        {
            for (int i = 0; i < comAcentos.Length; i++)
            {
                text = text.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
            }
            return text;
        }

        /// <summary>
        /// Recebe uma string representando um valor em reais no formato R$ 9.999,99 e retorna o valor decimal
        /// </summary>
        /// <param name="text">String text</param>
        /// <returns>decimal</returns>
        public static decimal ConverterMoedaParaDecimal(this string text)
        {
            var numbString = text.Replace("R$ ", "").Replace(".", "");
            return decimal.Parse(numbString, new NumberFormatInfo() { NumberDecimalSeparator = "," });
        }


        /// <summary>
        /// Verifica se a string é um cpf válido.
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static bool CpFValido(this string cpf)
        {
            int[] mt1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mt2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string TempCPF;
            string Digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            TempCPF = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = resto.ToString();
            TempCPF = TempCPF + Digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = Digito + resto.ToString();

            return cpf.EndsWith(Digito);
        }

        public static string CapitalizarFrase(this string text, string[] wordsLowerCase = null, string[] wordsUpperCase = null)
        {
            if (text.IsNullOrEmpty()) return text;
            if (wordsLowerCase == null)
                wordsLowerCase = PREPOSICOES;
            else
            {
                var wordsLowerCaseList = wordsLowerCase.ToList();
                wordsLowerCaseList.AddRange(PREPOSICOES);
                wordsLowerCase = wordsLowerCaseList.ToArray();
            }
            return text.CapitalizeSentence(wordsLowerCase: wordsLowerCase, wordsUpperCase: wordsUpperCase);
        }

    }
}
