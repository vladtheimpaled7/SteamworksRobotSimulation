﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Assets
{
    public static class LoadAndSaveScores
    {
        /*
         @Param h = highscore to be saved
         place = ranking in highscores
             */
        
        public static void saveScore(HighScore h, int place)
        {
           IFormatter form = new BinaryFormatter();
            Stream str = new FileStream(makeName(place),
                                        FileMode.Create,
                                        FileAccess.Write,
                                        FileShare.None
                                        );
            form.Serialize(str, h);
            str.Close();
         }
        public static HighScore readHighScore(int place)
        {
            //TODO write the method
            IFormatter form = new BinaryFormatter();
            Stream str = new FileStream(makeName(place),
                                        FileMode.Open,
                                        FileAccess.Read,
                                        FileShare.Read);
            return (HighScore)form.Deserialize(str);
            
        }
        private static string makeName(int place) {
            return place + ".sc";
        }
    }
}
