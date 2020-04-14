using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace Petible_Auth_Service.Logic
{
    public class Encryption
    {
        //public string encryptpassword(string password)
        //{
        //    byte[] salt = new byte[32];
        //    RandomNumberGenerator.Create().GetBytes(salt);

        //    byte[] plainTextBytes = Encoding.Unicode.GetBytes(password);
        //    byte[] combinedBytes = new byte[plainTextBytes.Length + salt.Length];
        //    Buffer.BlockCopy(plainTextBytes, 0, combinedBytes, 0, plainTextBytes.Length);
        //    Buffer.BlockCopy(salt, 0, combinedBytes, plainTextBytes.Length, salt.Length);

        //    HashAlgorithm hashAlgo = new SHA256Managed();
        //    byte[] hash = hashAlgo.ComputeHash(combinedBytes);

        //    byte[] hashPlusSalt = new byte[hash.Length + salt.Length];
        //    Buffer.BlockCopy(hash, 0, hashPlusSalt, 0, hash.Length);
        //    Buffer.BlockCopy(salt, 0, hashPlusSalt, hash.Length, salt.Length);


        //}
    }
}
