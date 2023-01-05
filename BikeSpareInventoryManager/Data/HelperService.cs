using System.Security.Cryptography;
using System.Text;

namespace BikeSpareInventoryManager.Data
{
    public class HelperService
    {
        private readonly static string _secretKey = "G5j23RYBc98NIkqGttii1y60h8Pv2iyM3PAEyAuLDwIim2VGJVabMSriubUS";

        public static string ConvertHash(string hash)
        {
            using (var hmac = new HMACSHA512())
            {
                hmac.Key = Encoding.UTF8.GetBytes(_secretKey);

                byte[] data = hmac.ComputeHash(Encoding.UTF8.GetBytes(hash));

                var sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
    }
}
