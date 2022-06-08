// Autor: Temple Of Horus

using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
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

            // Get game name.
            Console.Write("Game name: ");
            string GameName = Console.ReadLine();

            // Get hex title of game.
            Console.Write("Hex title of game: 0x");
            long HexTitle = Convert.ToInt64(Console.ReadLine(), 16);

            // Processing.
            Console.WriteLine("Processing...");

            // Create directories.
            string BaseDirectory = @"D:\Xbox 360 Preservation\" + GameName + @" [0x" + HexTitle.ToString("x") + @"]\";
            Directory.CreateDirectory(BaseDirectory);
            string ContentDirectory = BaseDirectory + @"Content\";
            Directory.CreateDirectory(ContentDirectory);
            string MarketDirectory = BaseDirectory + @"marketplace-xb.xboxlive.com\";
            Directory.CreateDirectory(MarketDirectory);
            string TemporaryDirectory = @"D:\Xbox 360 Preservation\Temporary Files\";
            Directory.CreateDirectory(TemporaryDirectory);

            // Create txt files.
            string LogFile = BaseDirectory + @"Log.txt";
            File.Create(LogFile).Close();
            string DownloadLinksFile = BaseDirectory + @"Download Links.txt";
            File.Create(DownloadLinksFile).Close();
            string idFile = BaseDirectory + @"id.txt";
            File.Create(idFile).Close();


            // Variables.
            string MD5File = "any";
            string SHA1File = "any";
            string SHA256File = "any";
            string SHA512File = "any";

            int LogNumber = 0;
            int LinkNumber = 0;
            int idNumber = 0;

            string ContentNumberDirectory = "any";
            string ReadFile = "any";
            string ContentFile = "any";
            string Filetxt = "any";
            string hexOfferIdFile = "any";
            string TemporaryFile = TemporaryDirectory + "1";
            string itemNumContent = "any";

            string PageURL = "any";
            Uri URIFileName;
            string FileName = "any";

            bool FileDownloaded = true;

            string country = "any";
            for (int i = 1; i <= 46; i++)
            {
                switch (i)
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

                // Create directories.
                string CountryDirectory = MarketDirectory + country + @"\";
                Directory.CreateDirectory(CountryDirectory);
                string MainSourceDirectory = CountryDirectory + @"Main Source\";
                Directory.CreateDirectory(MainSourceDirectory);
                string hexOfferIdDirectory = CountryDirectory + @"hexOfferId\";
                Directory.CreateDirectory(hexOfferIdDirectory);

                // Parsing of first page.
                PageURL = @"http://marketplace-xb.xboxlive.com/marketplacecatalog/v1/product/" + country + @"?pagenum=1&pagesize=100&postcsv=true&tiers=2.3&offerfilter=1&hextitles=0x" + HexTitle.ToString("x");

                FileDownloaded = true;
                try
                {
                    new WebClient().DownloadFile(PageURL, TemporaryFile);
                }
                catch (WebException e)
                {
                    FileDownloaded = false;
                    File.AppendAllText(LogFile, @"[" + ++LogNumber + @"] " + "URL: " + PageURL + "\n" + "Description: Parsing of first page has failed. Temporary file was not downloaded.\n\n");
                }

                if (FileDownloaded == true)
                {
                    ReadFile = File.ReadAllText(TemporaryFile);
                    File.Delete(TemporaryFile);

                    // Number of pages to parse.
                    int GettotalItemsFrom = ReadFile.IndexOf("<totalItems>") + "<totalItems>".Length;
                    int GettotalItemsTo = ReadFile.IndexOf("</totalItems>");
                    string GettotalItemsRes = ReadFile.Substring(GettotalItemsFrom, GettotalItemsTo - GettotalItemsFrom);
                    int ConvtotalItemsRes = Int32.Parse(GettotalItemsRes);
                    int NumPages = ((ConvtotalItemsRes / 100) + 1);

                    // Parsing pages.
                    if (GettotalItemsRes != "0")
                    {
                        for (int PageNum = 1; PageNum <= NumPages; PageNum++)
                        {
                            string PageNumberDirectory = MainSourceDirectory + PageNum + @"\";
                            Directory.CreateDirectory(PageNumberDirectory);

                            PageURL = @"http://marketplace-xb.xboxlive.com/marketplacecatalog/v1/product/" + country + @"?pagenum=" + PageNum + @"&pagesize=100&postcsv=true&tiers=2.3&offerfilter=1&hextitles=0x" + HexTitle.ToString("x");

                            Uri URIPageName = new Uri(PageURL);
                            string URIPageFileName = System.IO.Path.GetFileName(URIPageName.AbsolutePath);

                            string PageFile = PageNumberDirectory + URIPageFileName + ".xml";

                            FileDownloaded = true;
                            try
                            {
                                new WebClient().DownloadFile(PageURL, PageFile);
                            }
                            catch (WebException e)
                            {
                                FileDownloaded = false;
                                File.AppendAllText(LogFile, @"[" + ++LogNumber + @"] " + "URL: " + PageURL + "\n" + "Description: Page was not downloaded.\n\n");
                            }

                            if (FileDownloaded == true)
                            {
                                Filetxt = PageNumberDirectory + @"File.txt";
                                File.Create(Filetxt).Close();

                                MD5File = CalculateMD5(PageFile);
                                SHA1File = CalculateSHA1(PageFile);
                                SHA256File = CalculateSHA256(PageFile);
                                SHA512File = CalculateSHA512(PageFile);

                                File.AppendAllText(Filetxt, "File name: " + URIPageFileName + "\nDownload Link: " + PageURL + "\n\nHash:\nMD5 Checksum: " + MD5File + "\nSHA-1 Checksum: " + SHA1File + "\nSHA-256 Checksum: " + SHA256File + "\nSHA-512 Checksum: " + SHA512File + "\nGenerated by Temple Of Horus.");

                                // Parsing URLs.
                                ReadFile = File.ReadAllText(PageFile);
                                foreach (Match URL in Regex.Matches(ReadFile, @"(http|ftp|https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?"))
                                {
                                    if (!(File.ReadAllText(DownloadLinksFile).Contains(URL.Value)))
                                    {
                                        File.AppendAllText(DownloadLinksFile, @"[" + ++LinkNumber + @"] " + URL.Value + "\n");

                                        URIFileName = new Uri(URL.Value);
                                        FileName = System.IO.Path.GetFileName(URIFileName.AbsolutePath);
                                        if (string.IsNullOrEmpty(FileName))
                                        {
                                            File.AppendAllText(LogFile, @"[" + ++LogNumber + @"] " + "URL: " + URL.Value + "\n" + "Description: File has not name.\n\n");
                                            FileName = "No name";
                                        }
                                        ContentNumberDirectory = ContentDirectory + LinkNumber + @"\";
                                        Directory.CreateDirectory(ContentNumberDirectory);
                                        ContentFile = ContentNumberDirectory + FileName;

                                        FileDownloaded = true;
                                        try
                                        {
                                            new WebClient().DownloadFile(URL.Value, ContentFile);
                                        }
                                        catch (WebException e)
                                        {
                                            FileDownloaded = false;
                                            File.AppendAllText(LogFile, @"[" + ++LogNumber + @"] " + "URL: " + URL.Value + "\n" + "Description: File was not downloaded.\n\n");
                                        }

                                        if (FileDownloaded == true)
                                        {
                                            Filetxt = ContentNumberDirectory + @"File.txt";
                                            File.Create(Filetxt).Close();

                                            MD5File = CalculateMD5(ContentFile);
                                            SHA1File = CalculateSHA1(ContentFile);
                                            SHA256File = CalculateSHA256(ContentFile);
                                            SHA512File = CalculateSHA512(ContentFile);

                                            File.AppendAllText(Filetxt, "File name: " + FileName + "\nDownload Link: " + URL.Value + "\n\nHash:\nMD5 Checksum: " + MD5File + "\nSHA-1 Checksum: " + SHA1File + "\nSHA-256 Checksum: " + SHA256File + "\nSHA-512 Checksum: " + SHA512File + "\nGenerated by Temple Of Horus.");
                                        }
                                    }
                                }

                                //Parsing hexOfferIds.
                                int itemNumNumber = 0;
                                foreach (Match itemNum in Regex.Matches(ReadFile, @"(<a:entry itemNum=)(.*?)(<\/a:entry>)"))
                                {
                                    string itemNumDirectory = hexOfferIdDirectory + ++itemNumNumber + @"\";
                                    Directory.CreateDirectory(itemNumDirectory);

                                    itemNumContent = itemNum.Value;
                                    int GetidFrom = itemNumContent.IndexOf("<a:id>urn:uuid:") + "<a:id>urn:uuid:".Length;
                                    int GetidTo = itemNumContent.IndexOf("</a:id>");
                                    string Getid = itemNumContent.Substring(GetidFrom, GetidTo - GetidFrom);

                                    if (!(File.ReadAllText(idFile).Contains(Getid)))
                                    {
                                        File.AppendAllText(idFile, @"[" + ++idNumber + @"] " + Getid + " [hexOfferId: missing, contentId: missing]\n");
                                    }

                                    PageURL = @"http://marketplace-xb.xboxlive.com/marketplacecatalog/v1/product/" + country + @"?pagenum=1&pagesize=100&postcsv=true&tiers=2.3&hexoffers=0x";

                                    string ReadhexOffer = "any";
                                    bool hexOfferIdFound = true;
                                    // hexOfferId was not found.
                                    if (!(itemNum.Value.Contains(@"<hexOfferId>")))
                                    {
                                        hexOfferIdFound = false;

                                        int GetproductTypeFrom = itemNumContent.IndexOf("<productType>") + "<productType>".Length;
                                        int GetproductTypeTo = itemNumContent.IndexOf("</productType>");
                                        string GetproductType = itemNumContent.Substring(GetproductTypeFrom, GetproductTypeTo - GetproductTypeFrom);

                                        if (GetproductType == "1")
                                        {
                                            PageURL += HexTitle.ToString("x") + "f0000001";
                                            try
                                            {
                                                new WebClient().DownloadFile(PageURL, TemporaryFile);
                                                ReadhexOffer = File.ReadAllText(TemporaryFile);

                                                if (ReadhexOffer.Contains(@"<totalItems>0</totalItems>"))
                                                {
                                                    PageURL = PageURL.Replace(HexTitle.ToString("x") + "f0000001", HexTitle.ToString("x") + "00000000");
                                                }

                                                File.Delete(TemporaryFile);
                                            }
                                            catch (WebException e)
                                            {
                                                File.AppendAllText(LogFile, @"[" + ++LogNumber + @"] " + "URL: " + PageURL + "\n" + "Description: Temporary file was not downloaded.\n\n");
                                            }
                                        }
                                        else if (GetproductType == "5")
                                        {
                                            PageURL += HexTitle.ToString("x") + "00000000";
                                        }
                                        else if (GetproductType == "23")
                                        {
                                            PageURL += HexTitle.ToString("x") + "00000001";
                                        }
                                        else
                                        {
                                            PageURL += HexTitle.ToString("x") + Getid[16] + Getid[17] + Getid[21] + Getid[22] + Getid[24] + Getid[25] + Getid[26] + Getid[27];
                                        }

                                        try
                                        {
                                            new WebClient().DownloadFile(PageURL, TemporaryFile);
                                            ReadhexOffer = File.ReadAllText(TemporaryFile);

                                            if (!(ReadhexOffer.Contains(@"<totalItems>0</totalItems>")))
                                            {
                                                hexOfferIdFound = true;
                                            }

                                            File.Delete(TemporaryFile);
                                        }
                                        catch (WebException e)
                                        {
                                            File.AppendAllText(LogFile, @"[" + ++LogNumber + @"] " + "URL: " + PageURL + "\n" + "Description: Temporary file was not downloaded.\n\n");
                                        }
                                    }

                                    // hexOfferId was found.
                                    else
                                    {
                                        string hexOfferIdStart = "<hexOfferId>0x" + HexTitle.ToString("x");
                                        int GethexOfferIdFrom1 = itemNumContent.IndexOf(hexOfferIdStart) + hexOfferIdStart.Length;
                                        int GethexOfferIdTo1 = itemNumContent.IndexOf("</hexOfferId>");
                                        string GethexOfferId1 = itemNumContent.Substring(GethexOfferIdFrom1, GethexOfferIdTo1 - GethexOfferIdFrom1);

                                        PageURL += HexTitle.ToString("x") + GethexOfferId1;
                                    }

                                    // Parsing hexOfferId page.
                                    if (hexOfferIdFound == true)
                                    {
                                        URIFileName = new Uri(PageURL);
                                        FileName = System.IO.Path.GetFileName(URIFileName.AbsolutePath);
                                        if (string.IsNullOrEmpty(FileName))
                                        {
                                            File.AppendAllText(LogFile, @"[" + ++LogNumber + @"] " + "URL: " + PageURL + "\n" + "Description: File has not name.\n\n");
                                            FileName = "No name";
                                        }
                                        hexOfferIdFile = itemNumDirectory + FileName + ".xml";

                                        FileDownloaded = true;
                                        try
                                        {
                                            new WebClient().DownloadFile(PageURL, hexOfferIdFile);
                                        }
                                        catch (WebException e)
                                        {
                                            FileDownloaded = false;
                                            File.AppendAllText(LogFile, @"[" + ++LogNumber + @"] " + "URL: " + PageURL + "\n" + "Description: File was not downloaded.\n\n");
                                        }

                                        if (FileDownloaded == true)
                                        {
                                            Filetxt = itemNumDirectory + @"File.txt";
                                            File.Create(Filetxt).Close();

                                            MD5File = CalculateMD5(hexOfferIdFile);
                                            SHA1File = CalculateSHA1(hexOfferIdFile);
                                            SHA256File = CalculateSHA256(hexOfferIdFile);
                                            SHA512File = CalculateSHA512(hexOfferIdFile);

                                            File.AppendAllText(Filetxt, "File name: " + FileName + "\nDownload Link: " + PageURL + "\n\nHash:\nMD5 Checksum: " + MD5File + "\nSHA-1 Checksum: " + SHA1File + "\nSHA-256 Checksum: " + SHA256File + "\nSHA-512 Checksum: " + SHA512File + "\nGenerated by Temple Of Horus.");

                                            ReadhexOffer = File.ReadAllText(hexOfferIdFile);
                                            foreach (Match contentId in Regex.Matches(ReadhexOffer, @"(?<=\<contentId\>).*?(?=\<\/contentId\>)"))
                                            {
                                                int GethexOfferIdFrom2 = ReadhexOffer.IndexOf("<hexOfferId>") + "<hexOfferId>".Length;
                                                int GethexOfferIdTo2 = ReadhexOffer.IndexOf("</hexOfferId>");
                                                string GethexOfferId2 = ReadhexOffer.Substring(GethexOfferIdFrom2, GethexOfferIdTo2 - GethexOfferIdFrom2);

                                                if (!(File.ReadAllText(idFile).Contains(contentId.Value)))
                                                {
                                                    int GeteffTitIdFrom = ReadhexOffer.IndexOf("<effectiveTitleId>") + "<effectiveTitleId>".Length;
                                                    int GeteffTitIdTo = ReadhexOffer.IndexOf("</effectiveTitleId>");
                                                    string GeteffTitId = ReadhexOffer.Substring(GeteffTitIdFrom, GeteffTitIdTo - GeteffTitIdFrom);
                                                    int effTitId = Int32.Parse(GeteffTitId);

                                                    byte[] contentIdBytes = Convert.FromBase64String(contentId.Value);
                                                    string contentIdHex = BitConverter.ToString(contentIdBytes);
                                                    contentIdHex = contentIdHex.Replace("-", "");
                                                    contentIdHex = contentIdHex.ToLower();

                                                    PageURL = @"http://download.xbox.com/content/" + effTitId.ToString("x") + @"/" + contentIdHex + @".xcp";

                                                    if (!(File.ReadAllText(DownloadLinksFile).Contains(PageURL)))
                                                    {
                                                        ContentNumberDirectory = ContentDirectory + ++LinkNumber + @"\";
                                                        Directory.CreateDirectory(ContentNumberDirectory);

                                                        URIFileName = new Uri(PageURL);
                                                        FileName = System.IO.Path.GetFileName(URIFileName.AbsolutePath);
                                                        if (string.IsNullOrEmpty(FileName))
                                                        {
                                                            File.AppendAllText(LogFile, @"[" + ++LogNumber + @"] " + "URL: " + PageURL + "\n" + "Description: File has not name.\n\n");
                                                            FileName = "No name";
                                                        }
                                                        ContentFile = ContentNumberDirectory + FileName;

                                                        FileDownloaded = true;
                                                        try
                                                        {
                                                            new WebClient().DownloadFile(PageURL, ContentFile);
                                                        }
                                                        catch (WebException e)
                                                        {
                                                            string PageURL2 = @"http://download.xbox.com/content/gond360/" + effTitId.ToString("x") + @"/" + contentIdHex + @".xcp";
                                                            try
                                                            {
                                                                new WebClient().DownloadFile(PageURL2, ContentFile);
                                                                PageURL = PageURL2;
                                                            }
                                                            catch
                                                            {
                                                                FileDownloaded = false;
                                                                File.AppendAllText(LogFile, @"[" + ++LogNumber + @"] " + "URL: " + PageURL + "\n" + "Description: File was not downloaded.\n\n");
                                                            }
                                                        }

                                                        File.AppendAllText(DownloadLinksFile, @"[" + LinkNumber + @"] " + PageURL + "\n");

                                                        if (FileDownloaded == true)
                                                        {
                                                            Filetxt = ContentNumberDirectory + @"File.txt";
                                                            File.Create(Filetxt).Close();

                                                            MD5File = CalculateMD5(ContentFile);
                                                            SHA1File = CalculateSHA1(ContentFile);
                                                            SHA256File = CalculateSHA256(ContentFile);
                                                            SHA512File = CalculateSHA512(ContentFile);

                                                            File.AppendAllText(Filetxt, "File name: " + FileName + "\nDownload Link: " + PageURL + "\n\nHash:\nMD5 Checksum: " + MD5File + "\nSHA-1 Checksum: " + SHA1File + "\nSHA-256 Checksum: " + SHA256File + "\nSHA-512 Checksum: " + SHA512File + "\nGenerated by Temple Of Horus.");
                                                        }
                                                    }
                                                }
                                                string ReplaceMissing = File.ReadAllText(idFile);
                                                ReplaceMissing = ReplaceMissing.Replace(Getid + " [hexOfferId: missing, contentId: missing]", Getid + " [hexOfferId: " + GethexOfferId2 + ", contentId: " + contentId.Value + "]");
                                                File.WriteAllText(idFile, ReplaceMissing);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Directory.Delete(TemporaryDirectory);
        }
    }
}