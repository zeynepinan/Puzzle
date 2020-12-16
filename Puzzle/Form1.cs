using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap[] parcaResimler = new Bitmap[16];
        Bitmap alinanResim;
        Rectangle secili_alan;
        Random rnd = new Random();
        Graphics gr = null;
        Bitmap resim;

        public int tiklandi = 0;
        public int x, y;
        public int a = 0, b = 0;
        OpenFileDialog dosya = new OpenFileDialog();
        public static int puanHesabi = 0;
        public static int DogruhamleSayisi = 0;
        public static int YanlishamleSayisi = 0;
        public static int hamleSayisi = 0;
        
        public int ilkpuan;

        private void button17_Click(object sender, EventArgs e)
        {
            b++;

            if (b > 1)
            {
                for (int i = 1; i <= 16; i++) this.Controls["button" + i].BackgroundImage = null;
                for (int i = 0; i < 16; i++) { alinanResim = null; parcaResimler[i] = null; }
            }
            try
            {
                string kullaniciAdi = System.Environment.UserName;
                dosya.InitialDirectory = $"C:\\Users\\{kullaniciAdi}\\Desktop\\Puzzle\\Puzzle\\images";
                dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
                dosya.ShowDialog();
                string DosyaYolu = dosya.FileName;
                alinanResim = new Bitmap(DosyaYolu);
              
               
                label1.Visible = true;

               

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void button18_Click(object sender, EventArgs e)
        {

            label1.Visible = false;
            int sutunSayisi = 4;
            int satirSayisi = 4;
            int x = 0;
            int y = 0;
            int yeni_sayi = -1, eski_sayi = -1;
            bool durum = false;

            try
            {
                if (button1.BackgroundImage == null && b != 0)
                {
                    for (int i = 0; i < satirSayisi; i++)
                    {
                        for (int j = 0; j < sutunSayisi; j++)
                        {

                            secili_alan = new Rectangle(x, y, alinanResim.Width / sutunSayisi, alinanResim.Height / satirSayisi);
                            resim = new Bitmap(secili_alan.Width, secili_alan.Height);
                            gr = Graphics.FromImage(resim);
                            gr.DrawImage(alinanResim, 0, 0, secili_alan, GraphicsUnit.Pixel);

                            do
                            {
                                eski_sayi = yeni_sayi;
                                yeni_sayi = rnd.Next(0, 16);
                                if (parcaResimler[yeni_sayi] == null)
                                { parcaResimler[yeni_sayi] = resim; durum = false; }
                                else
                                    durum = true;
                            } while (durum);

                            x += alinanResim.Width / sutunSayisi;
                        }
                        y += alinanResim.Height / satirSayisi;
                        x = 0;
                    }
                    gr.Dispose();



                }
                else if (button1.BackgroundImage != null && b != 0)
                {
                    Bitmap[] karistir = new Bitmap[16];
                    int k = 0;

                    for (int i = 0; i < parcaResimler.Length; i++)
                    {
                        do
                        {
                            eski_sayi = yeni_sayi;
                            yeni_sayi = rnd.Next(0, 16);
                            if (karistir[yeni_sayi] == null)
                            { karistir[yeni_sayi] = parcaResimler[k]; k++; durum = false; }
                            else
                                durum = true;

                        } while (durum);


                    }
                    for (int i = 0; i < 16; i++) parcaResimler[i] = karistir[i];



                }
                else
                    MessageBox.Show("Resim seçim işlemi yapılmadı!!");

                for (int i = 1; i <= 16; i++) this.Controls["button" + i].BackgroundImage = parcaResimler[i - 1];
                for (int i = 1; i <= 16; i++)
                {
                    Button btn = this.Controls["button" + i] as Button;
                    btn.FlatAppearance.BorderSize = 2;
                    btn.FlatAppearance.BorderColor = Color.Yellow;
                }

                eslestirme();
                label5.Text = (puanHesabi * 10).ToString();
                ilkpuan = int.Parse(label5.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (tiklandi == 0)
            {
                tiklandi++; x = 0;

            }
            else
            {

                y = 0;
                cagir(x, y);
                tiklandi = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (tiklandi == 0)
            {
                tiklandi++; x = 1;

            }
            else
            {
                y = 1;
                cagir(x, y);
                tiklandi = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tiklandi++;

            if (tiklandi == 1)
            {
                x = 2;

            }
            if (tiklandi == 2)
            {

                y = 2;
                cagir(x, y);
                tiklandi = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tiklandi++;

            if (tiklandi == 1)
            {
                x = 3;

            }
            if (tiklandi == 2)
            {

                y = 3;
                cagir(x, y);
                tiklandi = 0;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tiklandi++;

            if (tiklandi == 1)
            {
                x = 4;

            }
            if (tiklandi == 2)
            {

                y = 4;
                cagir(x, y);
                tiklandi = 0;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tiklandi++;

            if (tiklandi == 1)
            {
                x = 5;

            }
            if (tiklandi == 2)
            {

                y = 5;
                cagir(x, y);
                tiklandi = 0;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tiklandi++;

            if (tiklandi == 1)
            {
                x = 6;

            }
            if (tiklandi == 2)
            {

                y = 6;
                cagir(x, y);
                tiklandi = 0;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tiklandi++;

            if (tiklandi == 1)
            {
                x = 7;

            }
            if (tiklandi == 2)
            {

                y = 7;
                cagir(x, y);
                tiklandi = 0;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tiklandi++;

            if (tiklandi == 1)
            {
                x = 8;

            }
            if (tiklandi == 2)
            {

                y = 8;
                cagir(x, y);
                tiklandi = 0;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tiklandi++;

            if (tiklandi == 1)
            {
                x = 9;

            }
            if (tiklandi == 2)
            {

                y = 9;
                cagir(x, y);
                tiklandi = 0;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tiklandi++;

            if (tiklandi == 1)
            {
                x = 10;

            }
            if (tiklandi == 2)
            {

                y = 10;
                cagir(x, y);
                tiklandi = 0;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tiklandi++;

            if (tiklandi == 1)
            {
                x = 11;

            }
            if (tiklandi == 2)
            {

                y = 11;
                cagir(x, y);
                tiklandi = 0;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tiklandi++;

            if (tiklandi == 1)
            {
                x = 12;

            }
            if (tiklandi == 2)
            {

                y = 12;
                cagir(x, y);
                tiklandi = 0;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tiklandi++;

            if (tiklandi == 1)
            {
                x = 13;

            }
            if (tiklandi == 2)
            {

                y = 13;
                cagir(x, y);
                tiklandi = 0;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            tiklandi++;

            if (tiklandi == 1)
            {
                x = 14;

            }
            if (tiklandi == 2)
            {

                y = 14;
                cagir(x, y);
                tiklandi = 0;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            tiklandi++;

            if (tiklandi == 1)
            {
                x = 15;

            }
            if (tiklandi == 2)
            {

                y = 15;
                cagir(x, y);
                tiklandi = 0;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string kullaniciAdi = System.Environment.UserName;
            TextReader tReader = new StreamReader($"C:\\Users\\{kullaniciAdi}\\Desktop\\Projeler\\Puzzle\\Puzzle\\enyüksekskor.txt");
            string okunan = tReader.ReadToEnd();
            string[] satirlar = okunan.Split('\n');

            string temp = satirlar[0];
            for (int i = 1; i < satirlar.Length - 1; i++)
            {

                if (int.Parse(satirlar[i]) > int.Parse(temp))
                {
                    temp = satirlar[i];
                }
            }



            tReader.Close();

            label3.Text = (temp);
        }
        int toplam = 0;

        private void button19_Click(object sender, EventArgs e)
        {
            
            Form2 form2 = new Form2();
            form2.textBox1.Text = hamleSayisi.ToString();
           
            string kullaniciAdi = System.Environment.UserName;
            StreamReader streamReader = File.OpenText($"C:\\Users\\{kullaniciAdi}\\Desktop\\Puzzle\\Puzzle\\enyüksekskor.txt");
            string metin;

            while ((metin = streamReader.ReadLine()) != null)
            {
                form2.listMetin.Items.Add(metin);
            }


            streamReader.Close();
            form2.Show(); //form2 göster diyoruz
            this.Hide();
        }

        void cagir(int x, int y)
        {
            hamleSayisi++;


            Bitmap gecici;
            try
            {
                gecici = new Bitmap(parcaResimler[x]);
                parcaResimler[x] = parcaResimler[y];
                parcaResimler[y] = gecici;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


            for (int i = 1; i <= 16; i++) this.Controls["button" + i].BackgroundImage = parcaResimler[i - 1];

            Button btn1 = this.Controls["button" + (x + 1)] as Button;
            Button btn2 = this.Controls["button" + (y + 1)] as Button;

            btn1.FlatAppearance.BorderSize = 2;
            btn1.FlatAppearance.BorderColor = Color.Yellow;
            btn2.FlatAppearance.BorderSize = 2;
            btn2.FlatAppearance.BorderColor = Color.Yellow;


            eslestirme();


           


            if (btn1.BackgroundImage != null)
            {

                if (btn1.FlatAppearance.BorderSize == 0 && btn2.FlatAppearance.BorderSize == 0) DogruhamleSayisi++;
                else if (btn1.FlatAppearance.BorderSize == 2 && btn2.FlatAppearance.BorderSize == 2) YanlishamleSayisi +=2;
                else { DogruhamleSayisi++; YanlishamleSayisi++; }


               


                label5.Text = (toplam + ((DogruhamleSayisi * 10) - (YanlishamleSayisi * 5)) + ilkpuan).ToString();

                toplam = int.Parse(label5.Text);
                ilkpuan = 0;
                DogruhamleSayisi = 0; YanlishamleSayisi = 0;

                if (int.Parse(label5.Text) > 100) label5.Text = "100";
                if (int.Parse(label5.Text) < 0) label5.Text = "0";
            }
            if (puanHesabi == 16)
            {
                string kullaniciAdi = System.Environment.UserName;
                StreamWriter sw = new StreamWriter($"C:\\Users\\{kullaniciAdi}\\Desktop\\Puzzle\\Puzzle\\enyüksekskor.txt", append: true);
                sw.WriteLine(label5.Text);
                sw.Close();
            }
        }

        void eslestirme()
        {
            puanHesabi = 0;
            try
            {
                int gen = alinanResim.Width / 4;
                int yuk = alinanResim.Height / 4;
                int satir = 0, sutun = 0;
                int t = -1;
                int say = 0;

                for (int n = 0; n < 4; n++)
                {
                    for (int m = 0; m < 4; m++)
                    {
                        t++;
                        for (int i = 0; i < gen; i++)
                        {
                            for (int j = 0; j < yuk; j++)
                            {
                                if (alinanResim.GetPixel(i + sutun, j + satir) != parcaResimler[t].GetPixel(i, j))
                                {
                                    say++;

                                }
                                else break;

                            }
                        }
                        if (say == 0)
                        {
                            Button btn = this.Controls["button" + (t + 1)] as Button;
                            btn.FlatAppearance.BorderSize = 0;
                            if (btn.FlatAppearance.BorderSize == 0) puanHesabi++;

                        }
                        say = 0;
                        sutun += gen;

                    }
                    satir += yuk;
                    sutun = 0;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }


    }
}
