
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApplication1
{
    class Generator
    {
        //creating a new object to generate "random" integers
        Random Rnd = new Random();
        //code to assign key/tonality from user input
        public string KEY(string key)
        {
            string Key = key;
            return key;

        }
        public string TONE(string ton)
        {
            string Tone = ton;
            return Tone;
        }
        //code to generate random key and tonality:
        public Tuple<string, string> RandKey()
        {
            string Key = "";
            string Tone = "";
            int Kchoice = Rnd.Next(1, 12);
            switch (Kchoice)
            {
                case 1:
                    Key = "C";
                    break;
                case 2:
                    Key = "C#";
                    break;
                case 3:
                    Key = "D";
                    break;
                case 4:
                    Key = "D#";
                    break;
                case 5:
                    Key = "E";
                    break;
                case 6:
                    Key = "F";
                    break;
                case 7:
                    Key = "F#";
                    break;
                case 8:
                    Key = "G";
                    break;
                case 9:
                    Key = "G#";
                    break;
                case 10:
                    Key = "A";
                    break;
                case 11:
                    Key = "A#";
                    break;
                case 12:
                    Key = "B";
                    break;
                default:
                    break;
            }

            int TChoice = Rnd.Next(1, 3);
            if (TChoice == 1)
            {
                Tone = "Major";
            }
            else if (TChoice == 2)
            {
                Tone = "Minor";
            }

            return new Tuple<string, string>(Key, Tone);
        }

        //todo write different alorithms depending on user input..
        //free generation mode
        public string FreeMode(int Length)
        {
            string C = "";
            string Chord = "";

            Chord = "";
            for (int i = 1; i <= Length; i++)
            {

                int Choice = Rnd.Next(1, 21);
                switch (Choice)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        Chord = "L";
                        break;
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                        Chord = "P";
                        break;
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                        Chord = "R";
                        break;
                    case 13:
                    case 14:
                        Chord = "H";
                        break;
                    case 15:
                    case 16:
                        Chord = "N";
                        break;
                    case 17:
                    case 18:
                        Chord = "S";
                        break;
                    case 19:
                    case 20:
                    case 21:
                        Chord = "A";
                        break;
                    default:
                        break;
                }
                C = (C + Chord);
            }
            return C;
        }


        //parent generation funtion
        public string CHORDS(int Length, string UsrChoice)
        {
            string C;

            if (UsrChoice == "Structured")
            {
                C = "!";
            }
            else
            {
                C = FreeMode(Length);

            }
            return C;
        }
    }

        
};
