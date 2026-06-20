
namespace CryptoMarket.Tests.SDK
{
    public class KeyLoader
    {
        private static string apiKey;
        private static string apiSecret;
        static KeyLoader()
        {
            Dictionary<string, string> keys = [];
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
                    
                    keys.Add(name, value);
                }

                reader.EndObject();

                //close the writer
                reader.Dispose();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.StackTrace);
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