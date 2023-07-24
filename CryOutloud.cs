using System;
using System.Security.Cryptography;
using System.Text;

public partial class CryOutloud
{

    private static TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
    private static MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();

    public static byte[] MD5Hash(string value)
    {
        return MD5.ComputeHash(Encoding.ASCII.GetBytes(value));
    }

    public static string Encrypt(string stringToEncrypt, string key)
    {
        DES.Key = MD5Hash(key);
        DES.Mode = CipherMode.ECB;
        byte[] Buffer = Encoding.ASCII.GetBytes(stringToEncrypt);
        return Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));
    }

    public static string Decrypt(string encryptedString, string key)
    {
        try
        {
            DES.Key = MD5Hash(key);
            DES.Mode = CipherMode.ECB;
            byte[] Buffer = Convert.FromBase64String(encryptedString);
            return Encoding.ASCII.GetString(DES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));
        }
        catch (Exception ex)
        {
            MessageBox.Show("Invalid Key", "Decryption Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        return default;
    }

}