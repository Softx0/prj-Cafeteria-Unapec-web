using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prj_cafeteria.Utils
{
    public class Validaciones
    {
        public Validaciones()
        {

        }

        public bool IsValiCedula(string pCedula)
        {
            int vnTotal = 0;
            string vcCedula = pCedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (vcCedula.Equals("00000000000"))
                if (pLongCed < 11 || pLongCed > 11)
                    return false;

            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
            }

            if (vnTotal % 10 == 0)
                return true;
            else
                return false;
        }

        public bool IsValiRNC(string pRNC)
        {
            //para verificar si es un dígito o no
            if (!pRNC.All(char.IsDigit))
                return false;

            char[] peso = { '7', '9', '8', '6', '5', '4', '3', '2' };
            int suma = 0;
            int division = 0;

            if (pRNC.Length != 9)
                return false;
            else
            {

                for (int i = 0; i < 8; i++)
                {
                    string rw = pRNC.ElementAt(i).ToString();
                    suma = suma + Convert.ToInt32(pRNC.ElementAt(i).ToString()) * Convert.ToInt32(peso[i]);
                }

                division = suma / 11;
                int resto = suma - (division * 11);
                int digito = 0;

                if (resto == 0)
                    digito = 2;
                else if (resto == 1)
                    digito = 1;
                else
                    digito = 11 - resto;

                if (digito != Convert.ToInt32(pRNC.ElementAt(8).ToString()))
                    return false;
            }

            return true;
        }
    }
}