using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DaBoyzApp.Services;

public static class AdminAuthService
{
    private static readonly string CredentialsFolder =
        Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
            "DaBoyzApp");

    private static readonly string CredentialsFile =
        Path.Combine(
            CredentialsFolder,
            "admin_credentials.dat");


    // =========================================================
    // SAVE REMEMBERED CREDENTIALS
    // =========================================================

    public static void SaveCredentials(
        string username,
        string password)
    {
        try
        {
            Directory.CreateDirectory(
                CredentialsFolder);

            string credentials =
                $"{username}\n{password}";

            byte[] plainBytes =
                Encoding.UTF8.GetBytes(credentials);

            byte[] encryptedBytes =
                ProtectedData.Protect(
                    plainBytes,
                    null,
                    DataProtectionScope.CurrentUser);

            File.WriteAllBytes(
                CredentialsFile,
                encryptedBytes);
        }
        catch
        {
            // Remember Me should never prevent login.
        }
    }


    // =========================================================
    // LOAD REMEMBERED CREDENTIALS
    // =========================================================

    public static (
        string Username,
        string Password
    )? LoadCredentials()
    {
        try
        {
            if (!File.Exists(CredentialsFile))
            {
                return null;
            }

            byte[] encryptedBytes =
                File.ReadAllBytes(
                    CredentialsFile);

            byte[] plainBytes =
                ProtectedData.Unprotect(
                    encryptedBytes,
                    null,
                    DataProtectionScope.CurrentUser);

            string credentials =
                Encoding.UTF8.GetString(
                    plainBytes);

            string[] parts =
                credentials.Split(
                    '\n',
                    2);

            if (parts.Length != 2)
            {
                ClearCredentials();
                return null;
            }

            return (
                parts[0],
                parts[1]
            );
        }
        catch
        {
            ClearCredentials();
            return null;
        }
    }


    // =========================================================
    // CLEAR REMEMBERED CREDENTIALS
    // =========================================================

    public static void ClearCredentials()
    {
        try
        {
            if (File.Exists(CredentialsFile))
            {
                File.Delete(CredentialsFile);
            }
        }
        catch
        {
            // Ignore cleanup failures.
        }
    }
}