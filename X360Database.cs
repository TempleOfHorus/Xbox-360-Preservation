// Autor: Temple Of Horus

using System.Net;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        // Functions to calculate hashes.
        static string CalculateMD5(string FleName) // MD5
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(FleName))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToUpperInvariant();
                }
            }
        }
        static string CalculateSHA1(string FleName) // SHA1
        {
            using (var sha1 = SHA1.Create())
            {
                using (var stream = File.OpenRead(FleName))
                {
                    var hash = sha1.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToUpperInvariant();
                }
            }
        }
        static string CalculateSHA256(string FleName) // SHA-256
        {
            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(FleName))
                {
                    var hash = sha256.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToUpperInvariant();
                }
            }
        }
        static string CalculateSHA512(string FleName) // SHA512
        {
            using (var sha512 = SHA512.Create())
            {
                using (var stream = File.OpenRead(FleName))
                {
                    var hash = sha512.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToUpperInvariant();
                }
            }
        }

        // Create directories.
        string BaseDirectory = @"D:\Xbox 360 Preservation\Database of marketplace-xb.xboxlive.com\";
        Directory.CreateDirectory(BaseDirectory);
        string TemporaryDirectory = BaseDirectory + @"Temporary Files\";
        Directory.CreateDirectory(TemporaryDirectory);

        // Variables.
        string MD5File = "any";
        string SHA1File = "any";
        string SHA256File = "any";
        string SHA512File = "any";

        string ReadFile = "any";
        string Filetxt = "any";
        string TemporaryFile = TemporaryDirectory + "1";

        string PageURL = "any";

        bool FileDownloaded = true;

        string XboxStore = "any";
        string country = "any";
        int producttype = 0; //1.2.3.4.5.7.8.9.10.12.13.14.15.17.18.19.20.21.22.23.24.30.31.34.35.37.39.40.45.46.47.50.51.53.54.57.58.59.60.61.62.63.64.66.67
        for (int k = 1; k <= 2; k++)
        {
            switch (k) //1, 3
            {
                case 1:
                    XboxStore = "1";
                    break;
                case 2:
                    XboxStore = "3";
                    break;
            }

            string StoreDirectory = BaseDirectory + "Store " + XboxStore + @"\";
            Directory.CreateDirectory(StoreDirectory);

            for (int i = 1; i <= 46; i++)
            {
                switch (i) //en-us es-ar pt-br en-ca es-cl es-co es-mx nl-be fr-be cs-cz da-dk de-de es-es fr-fr en-ie it-it hu-hu nl-nl nb-no de-at pl-pl pt-pt de-ch sk-sk fr-ch fi-fi sv-se en-gb el-gr ru-ru en-au en-hk en-in en-nz en-sg ko-kr zh-cn zh-tw ja-jp zh-hk en-za tr-tr he-il ar-ae ar-sa
                {
                    case 1:
                        country = "en-us";
                        break;
                    case 2:
                        country = "es-ar";
                        break;
                    case 3:
                        country = "pt-br";
                        break;
                    case 4:
                        country = "en-ca";
                        break;
                    case 5:
                        country = "es-cl";
                        break;
                    case 6:
                        country = "es-co";
                        break;
                    case 7:
                        country = "es-mx";
                        break;
                    case 8:
                        country = "nl-be";
                        break;
                    case 9:
                        country = "fr-be";
                        break;
                    case 10:
                        country = "cs-cz";
                        break;
                    case 11:
                        country = "da-dk";
                        break;
                    case 12:
                        country = "de-de";
                        break;
                    case 13:
                        country = "es-es";
                        break;
                    case 14:
                        country = "fr-fr";
                        break;
                    case 15:
                        country = "en-ie";
                        break;
                    case 16:
                        country = "it-it";
                        break;
                    case 17:
                        country = "hu-hu";
                        break;
                    case 18:
                        country = "nl-nl";
                        break;
                    case 19:
                        country = "nb-no";
                        break;
                    case 20:
                        country = "de-at";
                        break;
                    case 21:
                        country = "pl-pl";
                        break;
                    case 22:
                        country = "pt-pt";
                        break;
                    case 23:
                        country = "de-ch";
                        break;
                    case 24:
                        country = "sk-sk";
                        break;
                    case 25:
                        country = "fr-ch";
                        break;
                    case 26:
                        country = "fi-fi";
                        break;
                    case 27:
                        country = "sv-se";
                        break;
                    case 28:
                        country = "en-gb";
                        break;
                    case 29:
                        country = "el-gr";
                        break;
                    case 30:
                        country = "ru-ru";
                        break;
                    case 31:
                        country = "en-au";
                        break;
                    case 32:
                        country = "en-hk";
                        break;
                    case 33:
                        country = "en-in";
                        break;
                    case 34:
                        country = "en-nz";
                        break;
                    case 35:
                        country = "en-sg";
                        break;
                    case 36:
                        country = "ko-kr";
                        break;
                    case 37:
                        country = "zh-cn";
                        break;
                    case 38:
                        country = "zh-tw";
                        break;
                    case 39:
                        country = "ja-jp";
                        break;
                    case 40:
                        country = "zh-hk";
                        break;
                    case 41:
                        country = "en-za";
                        break;
                    case 42:
                        country = "tr-tr";
                        break;
                    case 43:
                        country = "he-il";
                        break;
                    case 44:
                        country = "ar-ae";
                        break;
                    case 45:
                        country = "ar-sa";
                        break;
                    case 46:
                        country = "fr-ca";
                        break;
                }

                for (int j = 1; j <= 45; j++)
                {
                    switch (j)
                    {
                        case 1:
                            producttype = 1;
                            break;
                        case 2:
                            producttype = 2;
                            break;
                        case 3:
                            producttype = 3;
                            break;
                        case 4:
                            producttype = 4;
                            break;
                        case 5:
                            producttype = 5;
                            break;
                        case 6:
                            producttype = 7;
                            break;
                        case 7:
                            producttype = 8;
                            break;
                        case 8:
                            producttype = 9;
                            break;
                        case 9:
                            producttype = 10;
                            break;
                        case 10:
                            producttype = 12;
                            break;
                        case 11:
                            producttype = 13;
                            break;
                        case 12:
                            producttype = 14;
                            break;
                        case 13:
                            producttype = 15;
                            break;
                        case 14:
                            producttype = 17;
                            break;
                        case 15:
                            producttype = 18;
                            break;
                        case 16:
                            producttype = 19;
                            break;
                        case 17:
                            producttype = 20;
                            break;
                        case 18:
                            producttype = 21;
                            break;
                        case 19:
                            producttype = 22;
                            break;
                        case 20:
                            producttype = 23;
                            break;
                        case 21:
                            producttype = 24;
                            break;
                        case 22:
                            producttype = 30;
                            break;
                        case 23:
                            producttype = 31;
                            break;
                        case 24:
                            producttype = 34;
                            break;
                        case 25:
                            producttype = 35;
                            break;
                        case 26:
                            producttype = 37;
                            break;
                        case 27:
                            producttype = 39;
                            break;
                        case 28:
                            producttype = 40;
                            break;
                        case 29:
                            producttype = 45;
                            break;
                        case 30:
                            producttype = 46;
                            break;
                        case 31:
                            producttype = 47;
                            break;
                        case 32:
                            producttype = 50;
                            break;
                        case 33:
                            producttype = 51;
                            break;
                        case 34:
                            producttype = 53;
                            break;
                        case 35:
                            producttype = 54;
                            break;
                        case 36:
                            producttype = 57;
                            break;
                        case 37:
                            producttype = 58;
                            break;
                        case 38:
                            producttype = 59;
                            break;
                        case 39:
                            producttype = 60;
                            break;
                        case 40:
                            producttype = 61;
                            break;
                        case 41:
                            producttype = 62;
                            break;
                        case 42:
                            producttype = 63;
                            break;
                        case 43:
                            producttype = 64;
                            break;
                        case 44:
                            producttype = 66;
                            break;
                        case 45:
                            producttype = 67;
                            break;
                    }

                    // Create directories.
                    string CountryDirectory = StoreDirectory + country + @"\";
                    Directory.CreateDirectory(CountryDirectory);
                    string ProdTypeDirectory = CountryDirectory + @"Product Type " + producttype + @"\";
                    Directory.CreateDirectory(ProdTypeDirectory);

                    PageURL = "http://marketplace-xb.xboxlive.com/marketplacecatalog/v1/product/" + country + "?pagenum=1&pagesize=100&postcsv=true&tiers=2.3&offerfilter=1&producttypes=" + producttype + "&stores=" + XboxStore;

                    do
                    {
                        try
                        {
                            new WebClient().DownloadFile(PageURL, TemporaryFile);
                            FileDownloaded = true;
                        }
                        catch
                        {
                            FileDownloaded = false;
                        }
                    } while (FileDownloaded != true);

                    // Downloading pages.
                    ReadFile = File.ReadAllText(TemporaryFile);
                    File.Delete(TemporaryFile);

                    int GettotalItemsFrom = ReadFile.IndexOf("<totalItems>") + "<totalItems>".Length;
                    int GettotalItemsTo = ReadFile.LastIndexOf("</totalItems>");
                    String GettotalItemsRes = ReadFile.Substring(GettotalItemsFrom, GettotalItemsTo - GettotalItemsFrom);

                    int x = Int32.Parse(GettotalItemsRes);
                    int NumPages = (x / 100) + 1;
                    if (NumPages > 1001)
                    {
                        NumPages = 1001;
                    }

                    for (int pagenum = 1; pagenum <= NumPages; pagenum++)
                    {
                        PageURL = "http://marketplace-xb.xboxlive.com/marketplacecatalog/v1/product/" + country + "?pagenum=" + pagenum + "&pagesize=100&postcsv=true&tiers=2.3&offerfilter=1&producttypes=" + producttype + "&stores=" + XboxStore;

                        string PageNumberDirectory = ProdTypeDirectory + pagenum + @"\";
                        Directory.CreateDirectory(PageNumberDirectory);
                        string PageFile = PageNumberDirectory + country + ".xml";

                        do
                        {
                            try
                            {
                                new WebClient().DownloadFile(PageURL, PageFile);
                                FileDownloaded = true;
                            }
                            catch
                            {
                                FileDownloaded = false;
                            }
                        } while (FileDownloaded != true);

                        Filetxt = PageNumberDirectory + @"File.txt";
                        File.Create(Filetxt).Close();

                        MD5File = CalculateMD5(PageFile);
                        SHA1File = CalculateSHA1(PageFile);
                        SHA256File = CalculateSHA256(PageFile);
                        SHA512File = CalculateSHA512(PageFile);

                        File.AppendAllText(Filetxt, "File name: " + country + "\nDownload Link: " + PageURL + "\n\nHash:\nMD5 Checksum: " + MD5File + "\nSHA-1 Checksum: " + SHA1File + "\nSHA-256 Checksum: " + SHA256File + "\nSHA-512 Checksum: " + SHA512File + "\nGenerated by Temple Of Horus.");
                    }
                }
            }
            Directory.Delete(TemporaryDirectory);
        }
    }
}