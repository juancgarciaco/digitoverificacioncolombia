using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Rectec.Utils.CSUtils.Persona
{
    public static class DigitoVerificacionColombia
    {
        /// <summary>
        /// Permite comprobar un documento con estilo (900,540,587, 900.540.587, 36.000,000)
		/// y compararlo con un dígito de verificación
        /// </summary>
        /// <param name="numeroDocumento">Documento a generar dígito de verificación paraa comparar</param>
        /// <param name="digitoVerificacion">Dígito a comprobar</param>
        /// <returns>Devuelva System.Boolean. true si el dígito autogenerado y el adjunto son iguales</returns>
        public static bool ComprobarDigito(string numeroDocumento, int digitoVerificacion)
        {
            // Inicializar
            decimal _numeroDocumentoDecimal = decimal.Zero;
            int? _digitoVerificacion;

            // Asignar
            string _numeroDocumentoString = LimpiarNumeroDocumento(numeroDocumento);
            decimal.TryParse(_numeroDocumentoString, out _numeroDocumentoDecimal);

            // Retornar falso cuando no haya numero positivo mayor a cero
            if (_numeroDocumentoDecimal <= decimal.Zero)
            {
                return false;
            }

            // Calcular dígito verificación sobre el documento decimal
            _digitoVerificacion = CalcularDigito(_numeroDocumentoDecimal);

            // 
            return (_digitoVerificacion == digitoVerificacion);
        }

        /// <summary>
        /// Permite comprobar un documento con estilo (9005405878, 900540587-3, 900.540.587-6, 36.000,000-8)
		/// Se extrae el último dígito y se toma como dígito verificación para comparar
        /// </summary>
        /// <param name="numeroDocumento">Documento a generar dígito de verificación paraa comparar</param>
        /// <returns>Devuelva System.Boolean. true si el dígito autogenerado y el ultimo dígito del documento enviado son iguales</returns>
        public static bool ComprobarDigito(string numeroDocumento)
        {
            string _numeroDocumentoString;
            int _cantidadDigitos;
            string _tempDigitoVerificacionString, _tempNumeroDocumentoString;
            short _tempDigitoVerificacion;
            decimal _tempNumeroDocumentoDecimal;

            // Limpiar el string entrante de caracterese no numericos
            _numeroDocumentoString = LimpiarNumeroDocumento(numeroDocumento);

            // Hallar la cantidad de caracteres de la cadena limpia
            _cantidadDigitos = _numeroDocumentoString.Length;

            // Devolver falso si la cantidad de caracteres menor a 2 ("0", "", "A", "0.")
            if (_cantidadDigitos < 2)
            {
                return false;
            }

            // Extraer el dígito de verificación de la cadena limpia y conevertirla en short ("9005001001" ==> 1)
            _tempDigitoVerificacionString = _numeroDocumentoString.Substring(_cantidadDigitos - 1, 1);
            short.TryParse(_tempDigitoVerificacionString, out _tempDigitoVerificacion);

            // Extraer el número de documento de la cadena limpia y conevertirla en decimal ("9005001001" ==> 900500100)
            _tempNumeroDocumentoString = _numeroDocumentoString.Substring(0, _cantidadDigitos - 1);
            decimal.TryParse(_tempNumeroDocumentoString, out _tempNumeroDocumentoDecimal);


            if (_tempNumeroDocumentoDecimal <= decimal.Zero)
            {
                return false;
            }

            var _digitoVerificacion = CalcularDigito(_tempNumeroDocumentoDecimal);
            return (_digitoVerificacion == _tempDigitoVerificacion);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroDocumento">string (Número documento sin dígito verificación) acepta caractes no numericos (,.; A-z)</param>
        /// <returns>Nullable(Int) (Dígito)</returns>
        public static int? Calcular(string numeroDocumento)
        {
            decimal _numeroDocumentoDecimal = decimal.Zero;
            string _numeroDocumentoString = LimpiarNumeroDocumento(numeroDocumento);
            decimal.TryParse(_numeroDocumentoString, out _numeroDocumentoDecimal);

            if (_numeroDocumentoDecimal > decimal.Zero)
            {
                return CalcularDigito(_numeroDocumentoDecimal);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroDocumento">string (Número documento sin dígito verificación)</param>
        /// <returns>Nullable(Int) (Dígito)</returns>
        public static int? Calcular(decimal numeroDocumento)
        {
            if (numeroDocumento > decimal.Zero)
            {
                return CalcularDigito(numeroDocumento);
            }
            return null;
        }

        #region Private Functions

        /// <summary>
        /// Recibe un número documento, lo evalua yretorna el dígito verificación)
        /// </summary>
        /// <param name="numeroDocumento">decimal (Número documento sin dígito verificación)</param>
        /// <returns>Nullable(Int) (Dígito)</returns>
        private static int? CalcularDigito(decimal numeroDocumento)
        {
            string _numeroDocumentoString = numeroDocumento.ToString();
            int[] _primos = new int[] { 0, 3, 7, 13, 17, 19, 23, 29, 37, 41, 43, 47, 53, 59, 67, 71 };
            int _digitoVerificacion, _primoActual, _totalOperacion = 0, _residuo, _cantidadDigitos = _numeroDocumentoString.Length;

            if (!(numeroDocumento > decimal.Zero))
            {
                return null;
            }

            for (int i = 0; i < _cantidadDigitos; i++)
            {
                _primoActual = int.Parse(_numeroDocumentoString.Substring(i, 1));
                _totalOperacion += _primoActual * _primos[_cantidadDigitos - i];
            }
            _residuo = _totalOperacion % 11;
            if (_residuo > 1)
            {
                _digitoVerificacion = 11 - _residuo;
            }
            else
            {
                _digitoVerificacion = _residuo;
            }
            return _digitoVerificacion;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroDocumento"></param>
        /// <returns></returns>
        private static string LimpiarNumeroDocumento(string numeroDocumento)
        {
            Regex rgx = new Regex("[^0-9]");
            return rgx.Replace(numeroDocumento, string.Empty);
        }
        #endregion

    }
}
