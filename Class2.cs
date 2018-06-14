using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{

   
    class TranslatorCLASS
    {
        Random Rd = new Random();

        private int NumAssign(string C)
        {
            int num = 0;
            switch (C)
            {
                case "C":
                    num = 10;
                    break;
                case "C#":
                    num = 15;
                    break;
                case "D":
                    num = 20;
                    break;
                case "D#":
                    num = 25;
                    break;
                case "E":
                    num = 30;
                    break;
                case "F":
                    num = 35;
                    break;
                case "F#":
                    num = 40;
                    break;
                case "G":
                    num = 45;
                    break;
                case "G#":
                    num = 50;
                    break;
                case "A":
                    num = 55;
                    break;
                case "A#":
                    num = 60;
                    break;
                case "B":
                    num = 65;
                    break;
                default:
                    break;
            }
            return num;
        }

        private string KeyCode(int Num)
        {
            string Key = "";

            //key assignment code:
            switch (Num)
            {
                case 10:
                    Key = "C";
                    break;
                case 15:
                    Key = "C#";
                    break;
                case 20:
                    Key = "D";
                    break;
                case 25:
                    Key = "D#";
                    break;
                case 30:
                    Key = "E";
                    break;
                case 35:
                    Key = "F";
                    break;
                case 40:
                    Key = "F#";
                    break;
                case 45:
                    Key = "G";
                    break;
                case 50:
                    Key = "G#";
                    break;
                case 55:
                    Key = "A";
                    break;
                case 60:
                    Key = "A#";
                    break;
                case 65:
                    Key = "B";
                    break;
                default:
                    break;
            }
            return Key;
        }

        private string Tonality(string Tone)
        {
            if (Tone == "Major")
            {
                Tone = "Minor";
            }
            else if(Tone == "Minor")
            {
                Tone = "Major";
            }
            return Tone;
        }


        public Tuple<string, string> AugFunc(string P, string T, int Randd)
        {
            
            int N = NumAssign(P);
            switch (Randd)
            {
                case 1:
                    //up L transform.
                    T = "Minor";
                    N += 5;
                    break;
                case 2:
                    //up P transform.
                    T = "Minor";
                    N += 25;
                    break;
                case 3:
                    //up R transform.
                    T = "Minor";
                    N += 45;
                    break;
                case 4:
                    //down L transform.
                    T = "Major";
                    N += 20;
                    break;
                case 5:
                    //down p transform.
                    T = "Major";
                    N += 40;
                    break;
                case 6:
                    //down R Transform.
                    T = "Major";
                    break;
            }
            if (N > 65)
            {
                N -= 60;
            }
            else if (N < 10)
            {
                N += 60;
            }


            P = KeyCode(N);
            
            return new Tuple<string, string>(P, T);
        }


        public Tuple<string, string> Augmented(string P, string T)
        {
            int II = Rd.Next(1, 6);

            Tuple<string, string> PTON = AugFunc(P, T, II);
            P = PTON.Item1;
            T = PTON.Item2;
            return new Tuple<string, string>(P, T);

        }
        

        public Tuple<string, string> Transform(string P, string T, string Tran)
        {
            //code for each trnasformation- using input tran to choose various methods within
            //declaration of int N for num assign function
            int N = NumAssign(P);


            if (T != "Aug")
            {
                
                switch (Tran)
                {
                    case "L":

                        if (T == "Major")
                        {
                            N += 20;
                        }
                        else if (T == "Minor")
                        {
                            N -= 20;
                        }
                        T = Tonality(T);
                        break;
                    case "P":
                        T = Tonality(T);
                        break;
                    case "R":

                        if (T == "Major")
                        {
                            N += 45;
                        }
                        else if (T == "Minor")
                        {
                            N -= 45;
                        }
                        T = Tonality(T);
                        break;
                    case "H":

                        if (T == "Major")
                        {
                            N += 20;
                        }
                        else if (T == "Minor")
                        {
                            N -= 20;
                        }
                        T = Tonality(T);
                        break;
                    case "N":

                        if (T == "Major")
                        {
                            N += 25;
                        }
                        else if (T == "Minor")
                        {
                            N -= 25;
                        }
                        T = Tonality(T);
                        break;
                    case "S":

                        if (T == "Major")
                        {
                            N += 20;
                        }
                        else if (T == "Minor")
                        {
                            N -= 20;
                        }
                        T = Tonality(T);
                        break;
                    case "A":
                        return new Tuple<string, string>(P, "Aug");

                    default:
                        break;
                }

            }


            else if (T == "Aug")
            {
                
                Tuple<string, string> PTON = Augmented(P, T);
                P = PTON.Item1;
                T = PTON.Item2;
                return new Tuple<string, string>(P, T);

            }

            //code to keep number in range
            if (N > 65)
            {
                N -= 60;
            }
            else if (N < 10)
            {
                N += 60;
            }



            P = KeyCode(N);
            return new Tuple<string, string>(P, T);
        }
        



    };
}
