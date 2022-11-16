using BookLoversProject.Domain.Domain;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace BookLoversProject.Presentation
{
    public class Assignment8
    {
        string password;
        UnicodeEncoding UE;
        RijndaelManaged RMCrypto;

        public Assignment8()
        {
            password = "12345678";
            UE = new UnicodeEncoding();
            RMCrypto = new RijndaelManaged();
        }

        public void CompressAndEncryptGenres(List<Genre> genres)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            if (!File.Exists("OutputFile.txt"))
            {
                using (var outputFile = new FileStream("OutputFile.txt", FileMode.CreateNew))
                {
                    //Encryption
                    using (CryptoStream cryptoStream = new CryptoStream(outputFile,
                        RMCrypto.CreateEncryptor(UE.GetBytes(password), UE.GetBytes(password)), CryptoStreamMode.Write))
                    {
                        //GZip compression
                        using (var compressionStream = new GZipStream(cryptoStream, CompressionMode.Compress))
                        {
                            // binaryFormatter.Serialize(compressionStream, genres);
                            BinaryWriter binaryWriter = new BinaryWriter(compressionStream);
                            binaryWriter.Write(genres.Count());
                            foreach (var genre in genres)
                            {
                                binaryWriter.Write(genre.Id);
                                binaryWriter.Write(genre.Name);
                            }
                        }
                    }

                }
            }
        }

        public List<Genre> DecompressAndDecryptGenres()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            List<Genre> decompressedGenres = new List<Genre>();

            using (var inputFile = File.OpenRead("OutputFile.txt"))
            {
                //Decryption
                using (CryptoStream cryptoStream = new CryptoStream(inputFile,
                    RMCrypto.CreateDecryptor(UE.GetBytes(password), UE.GetBytes(password)), CryptoStreamMode.Read))
                {
                    //Decompression
                    using (var decompressionStream = new GZipStream(cryptoStream, CompressionMode.Decompress))
                    {
                        //decompressedGenres = (List<Genre>)binaryFormatter.Deserialize(decompressionStream);
                        BinaryReader binaryReader = new BinaryReader(decompressionStream);
                        int count = binaryReader.ReadInt32();
                        for (int index = 0; index < count; index++)
                        {
                            decompressedGenres.Add(new Genre
                            {
                                Id = binaryReader.ReadInt32(),
                                Name = binaryReader.ReadString()
                            });
                        }

                    }
                }
            }
            return decompressedGenres;
        }
    }
}