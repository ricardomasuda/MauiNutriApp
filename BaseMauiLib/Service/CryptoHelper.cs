namespace MauiLib1.Service;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class CryptoHelper
{
    // Chave secreta para criptografia. Deve ser guardada em local seguro.
    private const string EncryptionKey = "EstaEhUmaChave128";

    // Método para criptografar uma senha
    public static string EncryptString(string password)
    {
        using Aes aesAlg = Aes.Create();
        aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 16)); // Pegue os primeiros 16 caracteres
        aesAlg.GenerateIV();

        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        using MemoryStream msEncrypt = new MemoryStream();
        using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
        {
            swEncrypt.Write(password);
        }

        byte[] encryptedBytes = msEncrypt.ToArray();

        // Concatenar IV ao início do array criptografado
        byte[] resultBytes = new byte[aesAlg.IV.Length + encryptedBytes.Length];
        Array.Copy(aesAlg.IV, 0, resultBytes, 0, aesAlg.IV.Length);
        Array.Copy(encryptedBytes, 0, resultBytes, aesAlg.IV.Length, encryptedBytes.Length);

        return Convert.ToBase64String(resultBytes);
    }

    // Método para descriptografar uma senha
    public static string DecryptString(string encryptedPassword)
    {
        byte[] cipherBytes = Convert.FromBase64String(encryptedPassword);
        byte[] iv = new byte[16]; // O IV é os primeiros 16 bytes do array criptografado
        Array.Copy(cipherBytes, 0, iv, 0, 16);

        using Aes aesAlg = Aes.Create();
        aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 16)); // Pegue os primeiros 16 caracteres
        aesAlg.IV = iv;

        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        using MemoryStream msDecrypt = new MemoryStream(cipherBytes, 16, cipherBytes.Length - 16);
        using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using StreamReader srDecrypt = new StreamReader(csDecrypt);

        return srDecrypt.ReadToEnd();
    }
}