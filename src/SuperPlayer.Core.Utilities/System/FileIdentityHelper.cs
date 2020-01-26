using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace System.IO
{
    public static class FileIdentityHelper
    {
        public static string GenerateFileIdentityRoughly(string filepath)
        {
            FileInfo fileInfo = new FileInfo(filepath);
            return fileInfo.GenerateFileIdentityRoughly();
        }

        public static string GenerateFileIdentityRoughly(this FileInfo fileInfo)
        {
            using (Stream stream = fileInfo.OpenRead())
            {
                return GenerateFileIdentityRoughly(stream);
            }
        }

        public static string GenerateFileIdentityRoughly(Stream stream)
        {
            List<long> posions = GeneratePosition(stream.Length);

            string key = string.Empty;

            for (int i = 0; i < posions.Count; i++)
            {
                stream.Position = posions[i];
                key += (byte)stream.ReadByte();
            }

            key = stream.Length + key;

            return CreateMD5Hash(key);
        }


        public static string CreateMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static List<long> GeneratePosition(long length)
        {
            List<long> posions = new List<long>();

            if (length > 100)
            {
                long range = length / 50;

                for (int i = 0; i < 50; i++)
                {
                    posions.Add(i * range);
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    posions.Add(i);
                }
            }

            return posions;
        }
    }
}
