
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        Generator GenApp = new Generator();
        TranslatorCLASS TrnApp = new TranslatorCLASS();

        string KEY;
        String TON;
        TextOutput WriteToFile = new TextOutput();


        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        //function to open a message box on error
        public void MsgBoxOpen(string Text)
        {
            MessageBox.Show(Text, "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


        }

        //font for music output
        void CustomFont()
        {
            PrivateFontCollection PFC = new PrivateFontCollection();
            PFC.AddFontFile("MusiSync.ttf");
            
        }
        
        //function to write the outpus to the ui
        private void Write(string Key, string Ton, string C, string Chords)
        {
            TextOut.Text = "Key: " + Key + " " + Ton + "\n"
                + "Transformations: " + C + "\n"
                + "Chords:\n" + Chords;

                
        }
        private void WriteRhythm(string Pattern)
        {
            if (MultiMode.Checked == true)
            {
                ROut.AppendText(Pattern);
            }
            else
            {
                ROut.Text = Pattern;
            }

        }




        private void main()
        {
            //generator code function
            int Repeat = int.Parse(RebBox.Text);
            string Rep = "";
            string UsrChoice = comboBox4.Text;
            //assign main variables
            KEY = comboBox1.Text;
            TON = comboBox2.Text;
            GenApp.KEY(KEY);
            GenApp.KEY(TON);

            string C = "";
          
            

            try
            {   //find out length of piece from ui
                int Length = int.Parse(textBox1.Text);

                for (int i = 1; i <= Length; i++)

                {
                    C = GenApp.CHORDS(Length, UsrChoice);
                }
                //repeat code
                Rep = C;
                for(int i = 0; i < Repeat; i ++)
                {
                    Rep += C;
                }
                //assign C to R value
                C = Rep;
            }   

            catch
            {
                string TextOut = "Error, use only integers in Length Box";
                MsgBoxOpen(TextOut);
            }
            // translator code function

            string TotalChords = "";
            
            var key = KEY;
            var tone = TON;


            foreach (char c in C)
            {
                Tuple<string, string> KTON = TrnApp.Transform(key, tone, c.ToString());

                key = KTON.Item1;
                tone = KTON.Item2;


                TotalChords = (TotalChords + key + " " + tone + "; ");
                
            }
            // output code for ui

            string pattern = GenerateRhythm();

            Write(KEY, TON, C, TotalChords);
            WriteRhythm(pattern);



        }

        private string GenerateRhythm()
        {
            //declarations
            string time = "";
            int C = 0, Time;
            string pattern = "";
            string R;
            RhythmClass Rhythm = new RhythmClass();
            Random Rnd = new Random();
            string AlgChoice = RAlg.Text;

            //get time sig from combobox 3
            string TimeVal = comboBox3.Text;

            //todo insert code to create multiple rhythms


            //convert time sig to two values
            foreach (char c in TimeVal)
            {
                if (C < 1)
                {
                    time = c.ToString();
                }
                else
                {
                    break;
                }
            }
            //convert time to int value
            try
            {
                int Num = int.Parse(RAmountBox.Text);
                int beats = int.Parse(textBox3.Text);
                for (int i = 0; i < Num; i++)
                {
                    //get no of rhythms
                    Time = int.Parse(time);
                    //generate rhtyhms
                    R = Rhythm.RhtyhmGen(Rnd, Time, beats, AlgChoice);
                    R += "]";
                    pattern += R;
                }
                
            }

            catch
            {
                MsgBoxOpen("error, time signiture required");
            }

            //assign pattern to fuinction in rhythm class

           

            return pattern;

        }



        private void button1_Click(object sender, EventArgs e)
        {
            main();
        }


        //code for the print function :
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Output = TextOut.Text + ROut.Text;

            PrintDocument P = new PrintDocument();
            P.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                e1.Graphics.DrawString(Output, new Font("Times New Roman", 14),
                                       new SolidBrush(Color.Black), new RectangleF(
                                       0, 0, P.DefaultPageSettings.PrintableArea.Width,
                                       P.DefaultPageSettings.PrintableArea.Height));
            };
            try
            {
                DialogResult PrintVerify = MessageBox.Show("Are You Sure You Want To Print?",
                                                           "GenApp", MessageBoxButtons.YesNo);
                if (PrintVerify == DialogResult.Yes)
                {
                    P.Print();
                }
                else if(PrintVerify == DialogResult.No)
                {
                    
                }
            }
            catch(Exception ex)
            {
                MsgBoxOpen("Error occured while printing" + ex);
                throw new Exception("Error occured while printing", ex);
                
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //todo write save function
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //todo write load function
        }

        //random key function
        private void button1_Click_1(object sender, EventArgs e)
        {
            Tuple<string, string> KEYTON = GenApp.RandKey();
            KEY = KEYTON.Item1;
            TON = KEYTON.Item2;
            comboBox1.Text = KEY;
            comboBox2.Text = TON;

        }

        
        
        
            
        
        private void writeToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //import rhythm text for ouptut
            int counter = 0;
            string RhythmOut = "";
            string textout = "";
            string text = TextOut.Text;
            string Rhythm = ROut.Text;
            string Lines = "";
            foreach (char c in Rhythm)
            {
                RhythmOut += c;
                counter += 1;
                if(counter == 130)
                {
                    RhythmOut += "\n";
                    counter = 0;
                }
            }
            foreach(char c in text)
            {
                textout += c;
                counter += 1;
                if(counter == 100)
                {
                    textout += "\n";
                    counter = 0;
                }
            }
            //code to add empty lines to rhythm to allow space for written text
            using (StringReader reader = new StringReader(textout))
            {
                counter = 0;
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        Lines += "\n";
                    }

                } while (line != null);
            }



            Lines += RhythmOut;


            WriteToFile.Write(KEY + " " + TON, "hello", "world");
            WriteToFile.BitmapOut(textout, Lines);

        }
        //todo add rhythm only mode
        private void button2_Click_1(object sender, EventArgs e)
        {
            //code to just excecute rhythm generation..
            string pattern = GenerateRhythm();
            WriteRhythm(pattern);


        }

       
    }
}

