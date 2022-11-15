using BookLoversProject.Domain.Domain;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace BookLoversProject
{
    public class Assignment8
    {
        public static void CompressAndEncryptGenres(List<Genre> genres)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            if (!File.Exists("OutputFile"))
            {
                using (var outputFile = new FileStream("OutputFile", FileMode.CreateNew))
                {
                    //Encryption
                    string password = "12345678";
                    UnicodeEncoding UE = new UnicodeEncoding();
                    byte[] key = UE.GetBytes(password);
                    RijndaelManaged RMCrypto = new RijndaelManaged();

                    using (CryptoStream cryptoStream = new CryptoStream(outputFile, RMCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write))

                    //GZip compression
                    using (var compressionStream = new GZipStream(cryptoStream, CompressionMode.Compress))
                    {
                        binaryFormatter.Serialize(compressionStream, genres);
                    }

                }
            }
        }

        public static List<Genre> DecompressAndDecryptGenres()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            List<Genre> decompressedGenres = new List<Genre>();

            using (var inputFile = File.OpenRead("OutputFile"))
            {
                //Decryption
                string password = "12345678";
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);
                RijndaelManaged RMCrypto = new RijndaelManaged();
                using (CryptoStream cryptoStream = new CryptoStream(inputFile, RMCrypto.CreateDecryptor(key, key), CryptoStreamMode.Read))

                //Decompression
                using (var decompressionStream = new GZipStream(cryptoStream, CompressionMode.Decompress))
                {
                    decompressedGenres = (List<Genre>)binaryFormatter.Deserialize(decompressionStream);
                }
            }
            return decompressedGenres;
        }
    }
}