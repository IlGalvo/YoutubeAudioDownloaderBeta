using System;
using System.Collections.Generic;
using System.Net;

namespace YoutubeClientManagerBeta
{
    internal static class Utilities
    {
        #region GENERAL
        public static string ValidateGenericField(string genericField, string fieldName)
        {
            if (genericField == null)
            {
                throw (new ArgumentNullException(fieldName));
            }

            genericField = genericField.Trim().Normalize();

            if (genericField == string.Empty)
            {
                throw new ArgumentException(fieldName);
            }

            return genericField;
        }

        public static Dictionary<string, string> SplitUrlQuery(string urlQuery)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (string rawParam in urlQuery.Split('&'))
            {
                string param = WebUtility.UrlDecode(rawParam);
                int index = param.IndexOf('=');

                dictionary[param.Substring(0, index)] = param.Substring(index + 1);
            }

            return dictionary;
        }

        public static string ExtractValue(string fullText, string keyStart, string keyStop)
        {
            string extractText = fullText.Substring((fullText.IndexOf(keyStart) + keyStart.Length));

            return (extractText.Substring(0, extractText.IndexOf(keyStop)));
        }
        #endregion
    }
}
