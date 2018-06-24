﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace AideDeJeu.Tools
{
    public static class Helpers
    {
        public static T GetResourceObject<T>(string resourceName) where T : class
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            var assembly = typeof(Helpers).GetTypeInfo().Assembly;
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                return serializer.ReadObject(stream) as T;
            }
        }

        public static async Task<string> GetResourceStringAsync(string resourceName)
        {
            var assembly = typeof(Helpers).GetTypeInfo().Assembly;
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (var sr = new StreamReader(stream))
                {
                    return await sr.ReadToEndAsync();
                }
            }
        }

        public static async Task<string> GetStringFromUrl(string url)
        {
            using (var client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }

        public static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            text = text.Normalize(NormalizationForm.FormD);
            var chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();
            return new string(chars).Normalize(NormalizationForm.FormC);
        }

        public static string Capitalize(string text)
        {
            return string.Concat(text.Take(1)).ToUpper() + string.Concat(text.Skip(1)).ToString().ToLower();
        }

        public static string IdFromName(string name)
        {
            return name.ToLower().Replace(" ", "-").Replace("\'","").Replace("/","");
            //return RemoveDiacritics(name.ToLower().Replace(" ", "-").Replace("\'", ""));
        }


    }
}
