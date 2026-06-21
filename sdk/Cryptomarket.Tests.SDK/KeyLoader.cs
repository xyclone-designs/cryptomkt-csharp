
using System.Text.Json.Nodes;

namespace CryptoMarket.Tests.SDK
{
    public class KeyLoader
    {
        static KeyLoader()
        {
            Dictionary<string, string> keys = [];
            try
            {
                // create a JSON reader
                using FileStream json_str = File.Open("/home/ismael/cryptomarket/keys.json", FileMode.Open);

                JsonNode json_obj = JsonNode.Parse(json_str);

                apiKey = json_obj["apiKey"].GetValue<string>();
                apiSecret = json_obj["apiSecret"].GetValue<string>();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.StackTrace);
            }
        }

        private static string apiKey;
        private static string apiSecret;

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