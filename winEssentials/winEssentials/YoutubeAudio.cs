using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winEssentials
{
    class YoutubeAudio
    {
        private static bool completed = false;
        private static WebBrowser wb;
        private static string urlDownload;
        private static bool urlFound = false;
        private static string LinkAudio;
        private static int count;
        private static bool errorFound = false;

        public static void downloadAudio(string url)
        {
            Utile.WriteMsg("Traitement de la demande ...", 3);
            try
            {
                LinkAudio = url;
                wb = new WebBrowser();

                wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted1);
                wb.ScriptErrorsSuppressed = true;

                wb.Navigate("https://www.youtube-mp3.org/");

                while (!completed)
                {
                    if (urlFound)
                    {
                        wb = new WebBrowser();
                        
                        wb.ScriptErrorsSuppressed = true;

                        if (count == 0)
                        {
                            Utile.WriteMsg("La vidéo a été trouvé, le téléchargement a été enclenché !", 1);
                            wb.Navigate(urlDownload);
                        }else if (count == 3)
                        {
                            completed = true;
                        }
                        Thread.Sleep(200);

                        count++;
                    }
                    Application.DoEvents();

                    Thread.Sleep(100);
                    if (errorFound)
                    {
                        Utile.WriteMsg("Votre vidéo ne doit pas dépasser 20 minutes et ne doit pas être soumis à des droits d'auteurs, impossible de télécharger !", 2);

                        errorFound = false;
                        completed = false;
                        count = 0;
                        urlFound = false;
                        wb.Refresh();
                        return;
                    }
                }
                
                completed = false;
                count = 0;
                urlFound = false;
               
                wb.Refresh();
            }
            catch(Exception ex)
            {
                Utile.WriteMsg("Impossible de trouver la vidéo ! Veuillez réessayez avec un autre lien.", 2);
            }
          
        }

        static void wb_DocumentCompleted1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                wb.Document.GetElementById("youtube-url").SetAttribute("value", LinkAudio);
                wb.Document.GetElementById("submit").InvokeMember("click");

                string stateInfos = wb.Document.GetElementById("progress_info").OuterHtml;

                if (stateInfos.Split('<')[3].Split(' ').Length > 1)
                {
                    errorFound = true;
                    return;
                }

                HtmlElement download_link = wb.Document.GetElementById("dl_link");
                HtmlElementCollection links = download_link.GetElementsByTagName("a");

                for (int i = 0; i < links.Count; i++)
                {
                    string linkFound = links[i].GetAttribute("href");
  
                    if (linkFound.Contains("create"))
                    {
                        urlDownload = linkFound;
                        urlFound = true;
                    }
                }

            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}