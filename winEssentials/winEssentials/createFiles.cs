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
            string path = Utile.getPathByCode(chemin);
            
            try
            {

                File.WriteAllText(path + @"\" + fileName + ".txt", getFullText(text), System.Text.Encoding.UTF8);
                Utile.WriteMsg("Fichier crée avec succès : " + path + @"\" + fileName + ".txt", 1);
            }
            catch(Exception ex)
            {
                Utile.WriteMsg(path + @"\" + fileName + ".txt");
                Utile.WriteMsg("Impossible de créer le fichier texte, vérifier que le chemin soit correct", 2);
            }
           
        }

        public static string getFullText(string[] text)
        {
            StringBuilder body = new StringBuilder();

            for (int i = 4; i < text.Length; i++)
            {
                body.Append(text[i] + " ");

            }
            return body.ToString();
        }
    }
}
