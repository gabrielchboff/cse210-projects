using System;
using System.IO;
using System.Security.Cryptography;

namespace PasswordManager
{
    public class EncryptionManager
    {
        private byte[] key; // 16 bytes for AES-128, 24 bytes for AES-192, 32 bytes for AES-256
        private byte[] iv; // 16 bytes IV for AES

        public EncryptionManager(byte[] key, byte[] iv)
        {
            this.key = key;
            this.iv = iv;
        }

        public void Encrypt(string inputFile, string outputFile)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
                using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
                using (CryptoStream csEncrypt = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write))
                {
                    fsInput.CopyTo(csEncrypt);
                }
            }
        }

        public void Decrypt(string inputFile, string outputFile)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
                using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
                using (CryptoStream csDecrypt = new CryptoStream(fsInput, decryptor, CryptoStreamMode.Read))
                {
                    csDecrypt.CopyTo(fsOutput);
                }
            }
        }
    }
}


