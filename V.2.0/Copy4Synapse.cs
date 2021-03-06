﻿using System;
using System.IO;

namespace Copy4Synapse
{
    class Copy4Synapse
    {
        static void Main()
        {
            bool confirmed = false;
            string source;
            string target;
            string destFile;
            string fileName;
            string sbstr;
            // Streamreader instanziieren 
            StreamReader path = new StreamReader("../path/conf.ini");
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
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Quellpfad existiert!");
                Console.ResetColor();
                Console.WriteLine("");
                //alle dateien im Vz werden in diesem StringArray hinterlegt
                string[] files = System.IO.Directory.GetFiles(source);

                if (System.IO.Directory.Exists(target))
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Zielpfad existiert!");
                    Console.ResetColor();
                    Console.WriteLine("");

                    foreach (string s in files)
                    {
                        fileName = System.IO.Path.GetFileName(s);
                        destFile = System.IO.Path.Combine(target, fileName);
                        System.IO.File.Copy(s, destFile, true);
                    }
                }
                else
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Der Zielpfad (" + target + ") " + " existiert nicht");
                    Console.ResetColor();
                    Console.WriteLine("");
                    do
                    {

                        ConsoleKey response;
                        do
                        {
                            Console.Write("Soll das Verzeichnis erstellt werden ?(j/n)");
                            response = Console.ReadKey(false).Key;   // true is intercept key (dont show), false is show
                            if (response != ConsoleKey.Enter)
                            {
                                Console.WriteLine();
                            }
                        } while (response != ConsoleKey.J && response != ConsoleKey.N);

                        if (response == ConsoleKey.J)
                        {
                            DirectoryInfo dir = Directory.CreateDirectory(target);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Das Verzeichnis wurde erstellt am {0}.", Directory.GetCreationTime(target));
                            Console.ResetColor();       
                            foreach (string s in files)
                            {
                                fileName = System.IO.Path.GetFileName(s);
                                destFile = System.IO.Path.Combine(target, fileName);
                                System.IO.File.Copy(s, destFile, true);
                            }   
                            confirmed = response == ConsoleKey.J;
                        }
                        else if (response == ConsoleKey.N)
                        {
                            Console.WriteLine("Das Verzeichnis wurde nicht erstellt!");
                            confirmed = response == ConsoleKey.N;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Kopiervorgang abgebrochen");
                            Console.ResetColor();
                        }

                    } while (!confirmed);
                }
                if (System.IO.Directory.Exists(target) && System.IO.Directory.Exists(source))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Kopiervorgang beendet");
                    Console.ResetColor(); 
                }
            }
            else
            {
                //falls Quellpfad nicht vorhanden gib einen Fehler aus
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Der Quellpfad (" + source + ") " + " existiert nicht!");
                Console.ResetColor();

            }
            //und ende
            Console.WriteLine("");
            Console.WriteLine("Beliebige Taste zum Schließen");
            Console.ReadKey();
        }
    }
}
