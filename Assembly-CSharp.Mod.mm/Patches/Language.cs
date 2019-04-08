using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using RoR2;
using MonoMod;
using UnityEngine;
using SimpleJSON;

namespace RoR2
{
    class patch_Language
    {
        [MonoModIgnore]
        private static extern Dictionary<string, string> LoadLanguageDictionary(string language);


        public static extern void orig_LoadAllFilesForLanguage(string language);
        public static void LoadAllFilesForLanguage(string language)
        {
            orig_LoadAllFilesForLanguage(language);
            LoadAllDictionariesFromAllMods(language);
        }

        //Checks "/Risk of Rain 2_Data/Managed/Mods/" for mods, then sends the zip file paths to LoadAllDictionariesFromMod()
        public static void LoadAllDictionariesFromAllMods(string language)
        {
            string modsDirectory = System.AppContext.BaseDirectory + "\\Risk of Rain 2_Data\\Managed\\Mods\\";

            string[] filePaths = Directory.GetFiles(modsDirectory, "*.zip");
            foreach (string zip in filePaths)
            {
                LoadAllDictionariesFromMod(language, zip);
            }

        }

        //Parses the .txt files located in /Language/EN_US/ and adds them to the game's dictionary through LoadLanguageFromString()
        public static void LoadAllDictionariesFromMod(string language, string zip)
        {
            UnityEngine.Debug.Log("Looking for language: " + language);
            using (ZipArchive archive = ZipFile.OpenRead(zip))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.StartsWith("Language/" + language + "/"))
                    {
                        //Stream langDir = entry.Open();
                        //langDir.
                        if (entry.FullName.EndsWith(".txt"))
                        {
                            UnityEngine.Debug.Log("Found language file: " + entry.FullName);
                            Stream stream = entry.Open();
                            StreamReader reader = new StreamReader(stream);
                            string contents = reader.ReadToEnd();
                            //UnityEngine.Debug.Log(entry.FullName + " contents: " + contents);
                            LoadLanguageFromString(language, contents);
                        }
                    }
                }
            }
        }

        private static void LoadLanguageFromString(string language, string languageFileContents)
        {
            Dictionary<string, string> dictionary = LoadLanguageDictionary(language);
            /*string text = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}/Language/{1}/{2}", UnityEngine.Application.dataPath, language));
            if (File.Exists(text))
            {

            }*/
            try
            {
                JSONNode jsonnode = JSON.Parse(languageFileContents);
                if (jsonnode != null)
                {
                    JSONNode jsonnode2 = jsonnode["strings"];
                    if (jsonnode2 != null)
                    {
                        foreach (string text2 in jsonnode2.Keys)
                        {
                            dictionary[text2] = jsonnode2[text2].Value;
                            UnityEngine.Debug.Log(text2 + " : " + dictionary[text2]);
                            //UnityEngine.Debug.Log(dictionary[text2]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                UnityEngine.Debug.Log("Failed to load strings from mod...");
                UnityEngine.Debug.Log(e);
            }
        }
        /*private static extern Dictionary<string, string> orig_LoadLanguageDictionary();
        [MonoModPublic]

        public static Dictionary<string, string> LoadLanguageDictionary()
        {
            return orig_LoadLanguageDictionary();
        }*/
    }
}
