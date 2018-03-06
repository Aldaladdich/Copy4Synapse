using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Copy4Synapse
{
    class Copy4Synapse
    {
        static void Main()
        {
            string source;
            string target;
            string destFile;
            string fileName;
            string sbstr;
		
		// Streamreader instanziieren 
            StreamReader path = new StreamReader("../path/Test.txt");
            //erste Zeile der Datei wird übersprungen
            path.ReadLine();            
			//die zweite Zeile wird ausgelesen und in sbstr gespeichert
            sbstr = path.ReadLine();            
            //nur der Pfad wird benötigt also werden die ersten 7 zeichen abgeschnitten und in source gespeichert
            source = sbstr.Substring(7);
            //zum überprüfen ob der Pfad korrekt ist wird das ergebnis wird ausgegeben
            Console.WriteLine("Der Quellpfad ist" + " " + source);
            
            //dasselbe für die dritte Zeile
            sbstr = path.ReadLine();
            target = sbstr.Substring(7);
            Console.WriteLine("Der Zielpfad ist" + " " + target);
            
            
            //prüfe ob das Quellverzeichnis vorhanden ist
            if (System.IO.Directory.Exists(source))
            {
            	//alle dateien im Vz werden in diesem StringArray hinterlegt
                string[] files = System.IO.Directory.GetFiles(source);

                foreach (string s in files)
                {
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(target, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
            else
            {

                //falls Quellpfad nicht vorhanden gib einen Fehler aus
                Console.WriteLine("Quellpfad existiert nicht");
            }
            //und ende
            Console.WriteLine("Kopiervorgang beendet");
            Console.WriteLine("Beliebige Taste zum Schließen");
            Console.ReadKey();
        }
    }
}