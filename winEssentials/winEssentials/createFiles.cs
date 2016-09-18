using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace winEssentials
{
    class CreateFiles
    {
        public static void createText(string chemin, string fileName, string[] text)
        {
            string path = chemin;
            switch(chemin)
            {
                case "desk":
                    path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    break;
                case "doc":
                    path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    break;
                case "music":
                    path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                    break;
                case "picture":
                    path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    break;
                case "video":
                    path = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                    break;
            }

            try
            {
                File.WriteAllText(path + "/" + fileName + ".txt", getFullText(text), System.Text.Encoding.UTF8);
                Utile.WriteMsg("Fichier crée avec succès", 1);
            }
            catch(Exception ex)
            {
                Utile.WriteMsg("Impossible de créer le fichier texte, vérifier que le chemin soit correct", 2);
            }
           
        }

        public static string getFullText(string[] text)
        {
            StringBuilder body = new StringBuilder();

            for (int i = 3; i < text.Length; i++)
            {
                body.Append(text[i] + " ");

            }
            return body.ToString();
        }
    }
}
