using Java.Nio.File;
using Java.Util;
using Com.Squareup.Moshi;
using Okio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Com.Cryptomarket.Sdk
{
    public class KeyLoader
    {
        private static string apiKey;
        private static string apiSecret;
        static KeyLoader()
        {
            Dictionary<string, string> keys = new HashMap<string, string>();
            try
            {

                // create a JSON reader
                JsonReader reader = JsonReader.Of(Okio.Buffer(Okio.Source(Paths["/home/ismael/cryptomarket/keys.json"].ToFile())));

                // start top-level object
                reader.BeginObject();

                // read all tokens
                while (reader.HasNext())
                {
                    string name = reader.NextName();
                    string value = reader.NextString();
                    keys.Put(name, value);
                }

                reader.EndObject();

                //close the writer
                reader.Dispose();
            }
            catch (Exception ex)
            {
                ex.PrintStackTrace();
            }

            apiKey = keys["apiKey"];
            apiSecret = keys["apiSecret"];
        }

        public static string GetApiKey()
        {
            return apiKey;
        }

        public static string GetApiSecret()
        {
            return apiSecret;
        }
    }
}