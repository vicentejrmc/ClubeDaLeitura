using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Util
{
    public static class Convertor
    {
        public static int ConverterStringParaInt()
        {
            int numero = 0;
            if (int.TryParse(Console.ReadLine(), out numero))
            {
                if (numero == 0)
                {
                    Notificar.ExibirMensagem("Numero Inválido, Tente novamente", ConsoleColor.Red);
                    return 0;
                }
                return numero;
            }
            else
            {
                Notificar.ExibirMensagem("Numero Inválido, Tente novamente", ConsoleColor.Red);
                return 0;
            }
        }

        public static DateTime? ConverterStringParaDate(string texto)
        {
            if (DateTime.TryParseExact(texto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
            {
                return data;
            }
            else
            {
                Notificar.ExibirMensagem("Data inválida! Use o formato dd/mm/aaaa.", ConsoleColor.Red);
                return null;
            }
        }
    }
}
