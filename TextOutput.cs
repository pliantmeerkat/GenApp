using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class TextOutput
    {

        public void Write(string Key, string chords, string Transform)
        {
            string Output = "";
            //template for output
            Output =                       "---------------------------------------------The Road To Transformation-------------------------------------------------" +
                     Environment.NewLine + "--------------------------------------------------Performance Sheet-----------------------------------------------------" +
                     Environment.NewLine +
                     "Here is the output from the GenApp Program, your transformations and chords are both listed below" +
                     Environment.NewLine + "the process required for performance/composition of this piece is simple and are as follows:" +
                     Environment.NewLine +
                     "1: The piece will last the time taken for the piece to play all chords generated, and then in" +
                     Environment.NewLine +
                     "retrograde back to the start." +
                     Environment.NewLine +
                     "2: You must only use notes from the chords generated." +
                     Environment.NewLine +
                     "3: You may play the parts in cannon however, and layer notes of the previous chords with the current" +
                     Environment.NewLine +
                     "Chord." + Environment.NewLine +
                     "4: If you have generated rhtyhms you may only use those rhtyhms, it is suggested to use one metre" +
                     Environment.NewLine +
                     "per instrunemt, and create resultants of the parts to create new interesting rhtyhms!" +
                     Environment.NewLine +
                     "5: You may use as many parts as you wish, but it suggested to use between 3 and 5" +
                     Environment.NewLine +
                     "6: These rules may appear limiting but the creative possibilities using this process are almost endless" +
                     Environment.NewLine +
                     "so let the creative juices flow and make some great music!!" +
                     Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                     Environment.NewLine + "Key:" + Environment.NewLine + Key + Environment.NewLine + Environment.NewLine +
                     "Transfomations:" + Environment.NewLine +
                     Transform + Environment.NewLine + Environment.NewLine +
                     "Chords:" + Environment.NewLine +
                     chords + Environment.NewLine;



            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Output\GenApp.txt", Output);

            //code to write all text to one bitmap file

            
        }
        //code to export rhytms as bitmap image..
        public void BitmapOut(string textW, string textM)
        {
            //creat lines in text
            //m refers to music text, and w is word text


            Image img = new Bitmap(1, 1);
            //create two different fonts
            Font fontM = new Font("MusiSync", 18);
            Font fontW = new Font("Georgia Pro Cond", 20);

            Graphics G = Graphics.FromImage(img);


            //measure the string 
            SizeF textSizeM = G.MeasureString(textM, fontM);
            SizeF textSizeW = G.MeasureString(textW, fontW);

            SizeF Total = textSizeM + textSizeW;

            //free up dummy img and old graphics object
            img.Dispose();
            G.Dispose();

            //create new image of the correct size
            img = new Bitmap((int)Total.Width, (int)Total.Height);

            G = Graphics.FromImage(img);

            //paint the background
            G.Clear(SystemColors.GradientInactiveCaption);

            //create a brush for the text
            Brush textBrush = new SolidBrush(SystemColors.InfoText);

            //add blank lines under first string

            

            //code to assign string to image file
            using (G = Graphics.FromImage(img))
            {
                G.DrawString(textW, fontW, textBrush, 0, 0);
                G.DrawString(textM, fontM, textBrush, 0, 0);

            }

            //save file in main directory
            img.Save(AppDomain.CurrentDomain.BaseDirectory + @"\Output\img.png", ImageFormat.Png);

            textBrush.Dispose();
            G.Dispose();


        }

    }
}
