using System;

namespace CAI_10_AgendaV3.InterfazConsola.Complementos
{
    public class Validadores
    {
        public static bool ValidarLimites(int NRO, int MIN, int MAX)
        {
            if (NRO < MIN) return false;
            if (NRO > MAX) return false;
            else return true;
        }

        public static bool ValidarSoloTexto(string texto)
        {
            foreach (char letra in texto)
            {
                if (!char.IsLetter(letra))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
