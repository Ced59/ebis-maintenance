using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Classes
{
    /// <summary>
    /// Contient des méthodes génériques sur les strings
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// Génère une string aléatoire, par exemple pour un mot de passe
        /// </summary>
        /// <param name="longueur">longueur de la string résultante</param>
        /// <returns>La string aléatoire générée</returns>
        public static string CreerStringAleatoire(int longueur)
        {
            const string CHAR_LIST = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@";
            StringBuilder sb = new StringBuilder(32);
            byte[] buffer;
            uint num;

            using (RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider())
            {
                buffer = new byte[sizeof(uint)];

                for (int i = longueur; i > 0; i--)
                {
                    csp.GetBytes(buffer);
                    num = BitConverter.ToUInt32(buffer, 0);
                    sb.Append(CHAR_LIST[(int)(num % (uint)CHAR_LIST.Length)]);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Validation format email
        /// </summary>
        /// <param name="email">L'email à vérifier</param>
        /// <returns>true si l'email est dans un format valide, false sinon</returns>
        public static bool EstEmailValide(string email)
        {
            return Regex.IsMatch(email, (@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"));
        }

        /// <summary>
        /// Détermine si la string passée est en minuscules ou pas
        /// </summary>
        /// <param name="str">La string à vérifier</param>
        /// <returns>true si la string est en minuscules, false sinon</returns>
        public static bool EstEnMinuscules(string str)
        {
            return new Regex(@"^([^A-Z])+$").IsMatch(str);
        }

        /// <summary>
        /// Détermine si la string passée est en majuscules ou pas
        /// </summary>
        /// <param name="str">La string à vérifier</param>
        /// <returns>true si la string est en majuscules, false sinon</returns>
        public static bool EstEnMajuscules(string str)
        {
            return new Regex(@"^([^a-z])+$").IsMatch(str);
        }
    }
}