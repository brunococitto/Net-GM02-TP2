using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Business.Logic
{
    public class Validaciones
    {
        static public void ValidarEmail(string email) 
        {
            try
            {
                if (!(email.Contains("@") & email.Contains(".")))
                {
                    throw new Exception();
                }
            }
            catch(Exception e)
            {
                Exception ExceptionManejada = new Exception("Formato de email erroneo", e);
                throw ExceptionManejada;
            }
        }

        static public void ValidarNulo(string campo, string tipo) 
        {
            try
            {
                if (string.IsNullOrWhiteSpace(campo))
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception($"El campo {tipo} debe completarse", e);
                throw ExceptionManejada;
            }
        }

        static public void ValidarClave(string clave)
        {
            try
            {
                if (clave.Length < 8)
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception($"La clave debe tener mas de 8 caracteres", e);
                throw ExceptionManejada;
            }
        }

        static public void ValidarConfirmacionClave(string clave,string clave2)
        {
            try
            {
                if (clave != clave2)
                {
                    throw new Exception();
                }
              
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception($"La claves ingresadas no coinciden ", e);
                throw ExceptionManejada;
            }
        }

        static public void ValidarNumero(string campo,string tipo)
        {
            Regex regex = new Regex("^[0-9]+$");
            try
            {
                if (!(regex.IsMatch(campo)))
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception($"El campo {tipo} debe ser numerico", e);
                throw ExceptionManejada;
            }

        }

        static public void ValidarLetras(string campo, string tipo)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");
            try
            {
               
                if (!(regex.IsMatch(campo)))
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception($"El campo {tipo} contener solo letras", e);
                throw ExceptionManejada;
            }

        }

        static public void ValidarLetrasNumeros(string campo, string tipo)
        {
            Regex regex = new Regex("^[a-zA-Z 1-9]+$");
            try
            {
                if (!(regex.IsMatch(campo)))
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception($"El campo {tipo} debe contener solo caracteres alfanuméricos", e);
                throw ExceptionManejada;
            }
        }
    }
}
