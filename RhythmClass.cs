using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class RhythmClass
    {
        //rhythm gen code
        public string RhtyhmGen(Random Rnd, int time, int beats, string Alg)
        {
            //declarations
            string pattern = "", note = "";
            //time accumulator
            int TLimit = 0;


            //loop for generator:

            if (Alg == "Western Std")
            {
                pattern = WestStd(pattern, note, TLimit, beats, Rnd);
            }
            else
            {
                pattern = SyncMode(pattern, note, TLimit, beats, Rnd);
            }
            return pattern;

        }

        //syncoptation mode
        private string SyncMode(string pattern, string note, int TLimit, int beats, Random Rnd)
        {
            while (TLimit <= beats - 1)
            {
                int Choice = Rnd.Next(1, 11);
                switch (Choice)
                {
                    //semiquaver
                    case 1:
                    case 2:
                        note = "s";
                        TLimit += 1;
                        pattern = pattern + " " + note + " ";
                        break;
                    //quaver
                    case 3:
                    case 4:
                    case 5:
                        if (TLimit <= beats - 2)
                        {
                            note = "e";
                            TLimit += 2;
                            pattern = pattern + " " + note + " ";
                            break;
                        }
                        else
                        {
                            break;
                        }
                    //crotchet
                    case 6:
                    case 7:
                        if (TLimit <= beats - 4)
                        {
                            note = "q";
                            TLimit += 4;
                            pattern = pattern + " " + note + " ";
                            break;
                        }
                        else
                        {
                            break;
                        }

                    //minim
                    case 8:
                        if (TLimit <= beats - 8)
                        {
                            note = "h";
                            TLimit += 8;
                            pattern = pattern + " " + note + " ";
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 9:
                        note = "S";
                        TLimit += 1;
                        pattern = pattern + " " + note + " ";
                        break;
                    case 10:
                        if (TLimit <= beats - 2)
                        {
                            note = "E";
                            TLimit += 2;
                            pattern = pattern + " " + note + " ";
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 11:
                        if (TLimit <= beats - 4)
                        {
                            note = "Q";
                            TLimit += 4;
                            pattern = pattern + " " + note + " ";
                            break;
                        }
                        else
                        {
                            break;
                        }

                }

            }

            return pattern;
        }
        //western std mode
        private string WestStd(string pattern, string note, int TLimit, int beats, Random Rnd)
        {
            //designed to feature less syncopation and simpler generally on beat rhythms:
            while (TLimit <= beats - 1)
            {
                int Choice = Rnd.Next(1, 11);
                switch (Choice)
                {
                    //semiquaver
                    case 1:
                        note = "s";
                        TLimit += 1;
                        pattern = pattern + " " + note + " ";
                        break;
                    //quaver
                    case 2:
                    case 3:
                        if (TLimit <= beats - 2)
                        {
                            note = "e";
                            TLimit += 2;
                            pattern = pattern + " " + note + " ";
                            break;
                        }
                        else
                        {
                            break;
                        }
                    //crotchet
                    case 4:
                    case 5:
                    case 6:
                        if (TLimit <= beats - 4)
                        {
                            note = "q";
                            TLimit += 4;
                            pattern = pattern + " " + note + " ";
                            break;
                        }
                        else
                        {
                            break;
                        }

                    //minim
                    case 7:
                    case 8:
                        if (TLimit <= beats - 8)
                        {
                            note = "h";
                            TLimit += 8;
                            pattern = pattern + " " + note + " ";
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 9:
                        if (TLimit <= beats - 2)
                        {
                            note = "E";
                            TLimit += 2;
                            pattern = pattern + " " + note + " ";
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 10:
                    case 11:
                        if (TLimit <= beats - 4)
                        {
                            note = "Q";
                            TLimit += 4;
                            pattern = pattern + " " + note + " ";
                            break;
                        }
                        else
                        {
                            break;
                        }

                }

            }



            return pattern;
        }
            


    };

}



        

