/* 
*
* Copyright (C) 2006-2011 Jedox AG
*
* This program is free software; you can redistribute it and/or modify it
* under the terms of the GNU General Public License (Version 2) as published
* by the Free Software Foundation at http://www.gnu.org/copyleft/gpl.html.
*
* This program is distributed in the hope that it will be useful, but WITHOUT
* ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
* FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for
* more details.
*
* You should have received a copy of the GNU General Public License along with
* this program; if not, write to the Free Software Foundation, Inc., 59 Temple
* Place, Suite 330, Boston, MA 02111-1307 USA
*
* You may obtain a copy of the License at
*
* <a href="http://www.jedox.com/license_palo_bi_suite.txt">
*   http://www.jedox.com/license_palo_bi_suite.txt
* </a>
*
* If you are developing and distributing open source applications under the
* GPL License, then you are free to use Palo under the GPL License.  For OEMs,
* ISVs, and VARs who distribute Palo with their products, and do not license
* and distribute their source code under the GPL, Jedox provides a flexible
* OEM Commercial License.
*
* \author
* 
*
*/

/*
using System.Collections.Generic;
*/
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Apalo.XlAddin.Utils
{
    class Crypto
    {
        #region Standard stuff
        private Crypto()
        { }
        #endregion

        #region Rijndael
        public static string Rijndaele(string inputString, string inputKey, string inputIV)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] key = Encoding.UTF8.GetBytes(inputKey);
            byte[] IV = md5.ComputeHash(Encoding.UTF8.GetBytes(inputIV));
            string result = "";

            try
            {
                using (RijndaelManaged rijn = new RijndaelManaged())
                {
                    rijn.Mode = CipherMode.CFB;
                    rijn.Padding = PaddingMode.None;
                    rijn.FeedbackSize = 8;

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (ICryptoTransform encryptor = rijn.CreateEncryptor(key, IV))
                        {
                            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(inputString.PadRight(16));
                            }
                            result = Convert.ToBase64String(msEncrypt.ToArray());
                        }
                    }
                    rijn.Clear();
                }
            }
            catch 
            { }

            return result;
        }

        public static string Rijndaeled(string inputString, string inputKey, string inputIV)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] key = Encoding.UTF8.GetBytes(inputKey);
            byte[] IV = md5.ComputeHash(Encoding.UTF8.GetBytes(inputIV));
            string result = "";

            try
            {
                using (RijndaelManaged rijn = new RijndaelManaged())
                {
                    rijn.Mode = CipherMode.CFB;
                    rijn.Padding = PaddingMode.None;
                    rijn.FeedbackSize = 8;

                    using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(inputString)))
                    using (ICryptoTransform decryptor = rijn.CreateDecryptor(key, IV))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        using (StreamReader swDecrypt = new StreamReader(csDecrypt))
                        {
                            result = swDecrypt.ReadToEnd();
                        }
                        rijn.Clear();
                    }
                }
                
            }
            catch
            { }

            return result.TrimEnd();
        }
        #endregion

        #region DES
        public static string DESe(string inputString)
        {
            string resultString = "";
            byte[] plaintext = Encoding.ASCII.GetBytes(inputString);
            DES des = new DESCryptoServiceProvider();
            des.Mode = CipherMode.CBC;
            des.Key = Encoding.ASCII.GetBytes("9dab4fc5");
            des.IV = Encoding.ASCII.GetBytes("aa9a5c43");
            MemoryStream memStreamEncryptedData = new MemoryStream();
            memStreamEncryptedData.Write(plaintext, 0, plaintext.Length);
            CryptoStream encStream = new CryptoStream(memStreamEncryptedData, des.CreateEncryptor(des.Key, des.IV), CryptoStreamMode.Write);
            resultString = Convert.ToBase64String(memStreamEncryptedData.ToArray());
            encStream.Close();
            return resultString;
        }

        public static string DESd(string inputString)
        {
            string resultString = "";
            try
            {
                byte[] ciphertext = Convert.FromBase64String(inputString);
                DES des = new DESCryptoServiceProvider();
                des.Mode = CipherMode.CBC;
                des.Key = Encoding.ASCII.GetBytes("9dab4fc5");
                des.IV = Encoding.ASCII.GetBytes("aa9a5c43");
                MemoryStream memDecryptStream = new MemoryStream();
                memDecryptStream.Write(ciphertext, 0, ciphertext.Length);
                CryptoStream cs_decrypt = new CryptoStream(memDecryptStream, des.CreateDecryptor(des.Key, des.IV), CryptoStreamMode.Write);
                resultString = Encoding.ASCII.GetString(memDecryptStream.ToArray());
                //cs_decrypt.Close();
            }
            catch (Exception exc)
            {
                Utils.ErrorHandler.DisplayError("Error decrypting", exc);
            }

            return resultString;
        }
        #endregion

        #region MD5
        public static string MD5(string input)
        {
            // step 1, calculate MD5 hash from input
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
        #endregion

        #region Base64
        public static string Base64e(string inputString)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(inputString));
        }

        public static string Base64d(string inputString)
        {
            return Convert.FromBase64String(inputString).ToString();
        }
        #endregion

        #region URL
        public static string URLe(string inputString)
        {
            return System.Web.HttpUtility.UrlEncode(inputString);
        }

        public static string URLd(string inputString)
        {
            return System.Web.HttpUtility.UrlDecode(inputString);
        }
        #endregion
    }
}
