using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Security.Cryptography;
using DESCONIT.BLL;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid;
using System.Windows.Forms;
using System.Net;
namespace RSys
{
   public class Functions
    {
      

       public static DataSet RefreshAppointmentData()
       {
           BLL bll = new BLL(Tables.DiaryActions, Program.clsuser.CurrentDB, Program.clsuser.UserID);

           Hashtable ht = new Hashtable();
           ht.Add(DiaryActions.CreatedBy, Program.clsuser.UserID);
          DataSet  dsMain = bll.ExecuteSP("usp_" + Tables.DiaryActions + "Search", ht);
          dsMain.Tables[0].TableName = Tables.DiaryActions;
          return dsMain;
           


       }


       public static void DeleteAppointmentData(int ID)
       {
           BLL bll = new BLL(Tables.DiaryActions, Program.clsuser.CurrentDB, Program.clsuser.UserID);

           bll.Delete(ID);

           //return dsMain;



       }

       public static void ExportToExcel(GridView view, string fileName)
       {
           string filePath = "";
           FolderBrowserDialog fld = new FolderBrowserDialog();
           fld.ShowDialog();



           if (!fld.SelectedPath.Equals(string.Empty))
           {
              // TODO: Replace
                filePath = fld.SelectedPath + "\\" + fileName;
               view.ExportToXls(filePath, new XlsExportOptions(TextExportMode.Text, false));
               Messages.Information(fileName + " is generated at " + fld.SelectedPath);
           }
       }

       public static void ExportToPDF(GridView view, string fileName)
       {
           string filePath = "";
           FolderBrowserDialog fld = new FolderBrowserDialog();
           fld.ShowDialog();



           if (!fld.SelectedPath.Equals(string.Empty))
           {
               filePath = fld.SelectedPath + "\\" + fileName;
               view.ExportToPdf(filePath);
               Messages.Information(fileName + " is generated at " + filePath);
           }
       }

       public static string GenerateAPassKey(string passphrase)
       {
           // Pass Phrase can be any string
           string passPhrase = passphrase;
           // Salt Value can be any string(for simplicity use the same value as used for the pass phrase)
           string saltValue = passphrase;
           // Hash Algorithm can be "SHA1 or MD5"
           string hashAlgorithm = "SHA1";
           // Password Iterations can be any number
           int passwordIterations = 2;
           // Key Size can be 128,192 or 256
           int keySize = 256;
           // Convert Salt passphrase string to a Byte Array
           byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
           // Using System.Security.Cryptography.PasswordDeriveBytes to create the Key
           PasswordDeriveBytes pdb = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
           //When creating a Key Byte array from the base64 string the Key must have 32 dimensions.
           byte[] Key = pdb.GetBytes(keySize / 11);
           String KeyString = Convert.ToBase64String(Key);

           return KeyString;
       }


       public static string Encrypt(string plainStr, string KeyString)
       {
           RijndaelManaged aesEncryption = new RijndaelManaged();
           aesEncryption.KeySize = 256;
           aesEncryption.BlockSize = 128;
           aesEncryption.Mode = CipherMode.ECB;
           aesEncryption.Padding = PaddingMode.ISO10126;
           byte[] KeyInBytes = Encoding.UTF8.GetBytes(KeyString);
           aesEncryption.Key = KeyInBytes;
           byte[] plainText = ASCIIEncoding.UTF8.GetBytes(plainStr);
           ICryptoTransform crypto = aesEncryption.CreateEncryptor();
           byte[] cipherText = crypto.TransformFinalBlock(plainText, 0, plainText.Length);
           return Convert.ToBase64String(cipherText);
       }

       public static string Decrypt(string encryptedText, string KeyString)
       {
           try
           {
               RijndaelManaged aesEncryption = new RijndaelManaged();
               aesEncryption.KeySize = 256;
               aesEncryption.BlockSize = 128;
               aesEncryption.Mode = CipherMode.ECB;
               aesEncryption.Padding = PaddingMode.ISO10126;
               byte[] KeyInBytes = Encoding.UTF8.GetBytes(KeyString);
               aesEncryption.Key = KeyInBytes;
               ICryptoTransform decrypto = aesEncryption.CreateDecryptor();
               byte[] encryptedBytes;
              
               encryptedBytes = Convert.FromBase64CharArray(encryptedText.ToCharArray(), 0, encryptedText.Length);
               

               return ASCIIEncoding.UTF8.GetString(decrypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length));
           }
           catch (Exception ex)
           {
               return encryptedText;
           }
       }

      
       public static bool EmailAddressCheck(string emailAddress)
       {
           bool functionReturnValue = false;
           string pattern = "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
           Match emailAddressMatch = Regex.Match(emailAddress, pattern);
           if (emailAddressMatch.Success)
           {
               functionReturnValue = true;
           }
           else
           {
               functionReturnValue = false;
           }
           return functionReturnValue;
       }

       public static void ExportGridToExcel(GridControl gc, string FilePath)
       {
           try
           {

               // string FullPath = Application.StartupPath + "\\" + FileName;
               //string Message = "File has been created successfully on the path: " + FullPath + "\n\nDo you want to view this now?";
               DevExpress.XtraGrid.Export.GridViewExportLink link;
               DevExpress.XtraExport.ExportXlsProvider provider;

               provider = new DevExpress.XtraExport.ExportXlsProvider(FilePath);
               link = gc.MainView.CreateExportLink(provider) as DevExpress.XtraGrid.Export.GridViewExportLink;
               link.ExportCellsAsDisplayText = false;
               link.ExportTo(true);

           }
           catch (Exception ex)
           {
               Messages.Error(ex.Message);
           }
           finally
           { }
       }

       public static bool WebsiteAddressCheck(string website)
       {
           try
           {
               string url = website;
               if (url != "")
               {
                   WebRequest Irequest = WebRequest.Create(url);
                   WebResponse Iresponse = Irequest.GetResponse();
                   if (Iresponse != null)
                   {
                       return true;
                   }
                   else
                   {
                       return false;
                   }
               }
               else
               {
                   return false;
               }
           }
           catch (Exception ex)
           {
               return false;
           }
       }

       public static bool UrlIsValid(string smtpHost)
       {
           bool br = false;
           try
           {
               IPHostEntry ipHost = Dns.Resolve(smtpHost);
               br = true;
           }
           catch (Exception ex)
           {
               br = false;
           }
           return br;
       }

       public static void LogError(Exception ex)
       {
           try
           {
               BLL bll = new BLL(Tables.AppErrors, Program.clsuser.CurrentDB, Program.clsuser.UserID);

               DataSet ds = bll.GetByID(-1);

               DataRow dr = ds.Tables[0].NewRow();

               dr[AppErrors.MachineName] = Environment.MachineName + ":" + Dns.GetHostAddresses(Environment.MachineName)[2].ToString();
               dr[AppErrors.UserName] = Program.clsuser.UserName;
               dr[AppErrors.InnerException] = ex.InnerException;
               dr[AppErrors.ErrorMessage] = ex.Message;
               dr[AppErrors.Source] = ex.Source;
               dr[AppErrors.TargetSite] = ex.TargetSite;
               dr[AppErrors.StackTrace] = ex.StackTrace;

               bll.Insert(dr);
           }
           catch (Exception exErr)
           {
               Messages.Error(exErr.Message);
           }
       }

       public static bool IsPasswordStrong(string password)
       {
           const int MIN_LENGTH = 6;
           const int MAX_LENGTH = 15;

           if (password == null) throw new ArgumentNullException();

           bool meetsLengthRequirements = password.Length >= MIN_LENGTH && password.Length <= MAX_LENGTH;
           bool hasUpperCaseLetter = false;
           bool hasLowerCaseLetter = false;
           bool hasDecimalDigit = false;
           bool hasSpecialChar = false;

           if (meetsLengthRequirements)
           {
               foreach (char c in password)
               {
                   if (char.IsUpper(c)) hasUpperCaseLetter = true;
                   else if (char.IsLower(c)) hasLowerCaseLetter = true;
                   else if (char.IsDigit(c)) hasDecimalDigit = true;

               }
           }

           bool isValid = meetsLengthRequirements
                       && hasUpperCaseLetter
                       && hasLowerCaseLetter
                       && hasDecimalDigit;
           return isValid;

       }

    }
}
