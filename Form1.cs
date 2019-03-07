using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazLabSudokuCozucu
{
    public partial class Form1 : Form
    {
        //thread loglarının biriktiği yer (bunun içindekiler dosyaya yazdırılıyor mesela)
        StringBuilder sb;

        private string dosyaYolu;

        private int[,] sudoku1;
        private int[,] sudoku2;
        private int[,] sudoku3;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Formdaki değişikliklerin geçişini hızlandırmak için
            SetStyle(
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            SudokuOlustur(tableLayoutPanel1, Color.LightBlue);
            SudokuOlustur(tableLayoutPanel2, Color.LightPink);
            SudokuOlustur(tableLayoutPanel3, Color.LightBlue);
        }

        //Verilen çözülmemiş sudokuyu alıp ekrana basan metot
        private void DosyadanSudokuOku()
        {
            sudoku1 = new int[9, 9];
            sudoku2 = new int[9, 9];
            sudoku3 = new int[9, 9];

            int satirNo = 0, sutunNo = 0;
            string yazi = File.ReadAllText(dosyaYolu);
            foreach (string satir in yazi.Split('\n'))//satır satır okuma
            {
                sutunNo = 0;
                foreach (char harf in satir.ToCharArray().Where(x => x != '\r'))//harf harf okuma
                {
                    if (harf == '*')//yıldızı 0 değeri ile değiştirme
                    {
                        sudoku1[satirNo, sutunNo] = 0;
                        sudoku2[satirNo, sutunNo] = 0;
                        sudoku3[satirNo, sutunNo] = 0;
                    }
                    else
                    {
                        //string değerleri int' e çevirme
                        sudoku1[satirNo, sutunNo] = Int32.Parse(harf.ToString()); 
                        sudoku2[satirNo, sutunNo] = Int32.Parse(harf.ToString());
                        sudoku3[satirNo, sutunNo] = Int32.Parse(harf.ToString());
                    }
                    sutunNo++;
                }
                satirNo++;
            }
        }

        //sudoku görselinin ekran boş olarak oluştuğu metot
        private void SudokuOlustur(TableLayoutPanel tableLayoutPanel, Color color)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    TextBox textBox = new TextBox();
                    textBox.Enabled = false;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.BackColor = color;
                    textBox.Font = new Font(textBox.Font.FontFamily, 25F, FontStyle.Regular);
                    textBox.MaxLength = 1;
                    textBox.TextAlign = HorizontalAlignment.Center;
                    textBox.Dock = DockStyle.Fill;
                    textBox.Height = textBox.Width;
                    tableLayoutPanel.Controls.Add(textBox, col, row);
                }
            }
        }

        //dosyadan yüklenen değerler ile sudokulların ekranda oluştuğu metot
        private void SudokuCiz(TableLayoutPanel tableLayoutPanel, int[,] sudoku, Color color)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    var textBox = (TextBox)tableLayoutPanel.GetControlFromPosition(col, row);
                    if (sudoku != null)
                    {
                        textBox.Text = sudoku[row, col].ToString();
                    }
                    else
                    {
                        textBox.Text = string.Empty;
                    }

                    textBox.BackColor = color;
                }
            }
        }

        //sudokuları cozme işlemi burda başlatılıyor
        private void cozum_Click(object sender, EventArgs e)
        {
            //logların birikiceği obje oluşturuluyor
            sb = new StringBuilder();
            //ilk thread bittiğinde diğer threadlere mesaj yollayan nesne oluşturuluyor
            var tokenSource = new CancellationTokenSource();

            //1. Thread başlatılıyor
            Task.Factory.StartNew(() =>
            {
                var start = DateTime.Now;
                //1.thread için sudokuyu çözen algoritmanın olduğu metot çağrılıyor
                var cozucu = new SudokuCozucu(sudoku1, SudokuDegerBulundu1, tokenSource.Token);
                cozucu.Coz1(0, 0);
                //kazanan thread 1 ise diğer threadleri durdurur
                tokenSource.Cancel();
                var stop = DateTime.Now;

                //kazanan threadi console ve dosyaya yazdırma işlemeleri yapılıyor
                var mesaj = $"Kazanan TreadId: {Thread.CurrentThread.ManagedThreadId} TotalTime: {(stop - start).TotalMilliseconds}";
                Console.WriteLine(mesaj);
                sb.AppendLine(mesaj);// biriktirip en son dosyaya yazmak için
                LoguDosyayaYazdir();
            }, tokenSource.Token);
            //2. Thread başlatılıyor
            Task.Factory.StartNew(() =>
            {
                var start = DateTime.Now;
                //2.thread için sudokuyu çözen algoritmanın olduğu metot çağrılıyor
                var cozucu = new SudokuCozucu(sudoku2, SudokuDegerBulundu2, tokenSource.Token);
                cozucu.Coz2(0, 0);
                //kazanan thread 2 ise diğer threadleri durdurur
                tokenSource.Cancel();
                var stop = DateTime.Now;

                //kazanan threadi console ve dosyaya yazdırma işlemeleri yapılıyor
                var mesaj = $"Kazanan TreadId: {Thread.CurrentThread.ManagedThreadId} TotalTime: {(stop - start).TotalMilliseconds}";
                Console.WriteLine(mesaj);
                sb.AppendLine(mesaj);// biriktirip en son dosyaya yazmak için
                LoguDosyayaYazdir();
            }, tokenSource.Token);
            //3. Thread başlatılıyor
            Task.Factory.StartNew(() =>
            {
                var start = DateTime.Now;
                //3.thread için sudokuyu çözen algoritmanın olduğu metot çağrılıyor
                var cozucu = new SudokuCozucu(sudoku3, SudokuDegerBulundu3, tokenSource.Token);
                cozucu.Coz3(0, 0);
                //kazanan thread 3 ise diğer threadleri durdurur
                tokenSource.Cancel();
                var stop = DateTime.Now;


                //kazanan threadi console ve dosyaya yazdırma işlemeleri yapılıyor
                var mesaj = $"Kazanan TreadId: {Thread.CurrentThread.ManagedThreadId} TotalTime: {(stop - start).TotalMilliseconds}";
                Console.WriteLine(mesaj);
                sb.AppendLine(mesaj);// biriktirip en son dosyaya yazmak için
                LoguDosyayaYazdir();
            }, tokenSource.Token);
        }

        //1. sudoku için thread her değer bulduğunda ekrana işleyen metot
        private void SudokuDegerBulundu1(int row, int col, int deger, CancellationToken token)
        {
            //akış hızlı olsun diye 5mili saniye threadi yavaşlatıyoruz
            Thread.Sleep(5);

            //Eğer diğer threadlerden biri bittiyse bu thread kendini sonlandırır
            if (token.IsCancellationRequested)
            {
                token.ThrowIfCancellationRequested();
            }

            //değerleri ekrana yazdırıyoruz
            var textBox = (TextBox)tableLayoutPanel1.GetControlFromPosition(col, row);
            textBox.BeginInvoke((MethodInvoker)delegate () //ana threade işi bırakması için böylece ana ekrana görseli çizdirebilir
            {
                textBox.BackColor = Color.LightGreen;
                textBox.Text = deger.ToString();
            });

            //console ve dosyaya thread bilgilerini yazdırıyoruz
            var mesaj = $"TreadId: {Thread.CurrentThread.ManagedThreadId} --> row:{row} col:{col} için deger: {deger} yaptı.";
            Console.WriteLine(mesaj);
            sb.AppendLine(mesaj);
        }

        //2. sudoku için thread her değer bulduğunda ekrana işleyen metot
        private void SudokuDegerBulundu2(int row, int col, int deger, CancellationToken token )
        {
            //akış hızlı olsun diye 5mili saniye threadi yavaşlatıyoruz
            Thread.Sleep(5);

            //Eğer diğer threadlerden biri bittiyse bu thread kendini sonlandırır
            if (token.IsCancellationRequested)
            {
                token.ThrowIfCancellationRequested();
            }

            //değerleri ekrana yazdırıyoruz
            var textBox = (TextBox)tableLayoutPanel2.GetControlFromPosition(col, row);
            textBox.BeginInvoke((MethodInvoker)delegate () //ana threade işi bırakması için böylece ana ekrana görseli çizdirebilir
            {
                textBox.BackColor = Color.LightGreen;
                textBox.Text = deger.ToString();
            });

            //console ve dosyaya thread bilgilerini yazdırıyoruz
            var mesaj = $"TreadId: {Thread.CurrentThread.ManagedThreadId} --> row:{row} col:{col} için deger: {deger} yaptı.";
            Console.WriteLine(mesaj);
            sb.AppendLine(mesaj);
        }

        //3. sudoku için thread her değer bulduğunda ekrana işleyen metot
        private void SudokuDegerBulundu3(int row, int col, int deger, CancellationToken token)
        {
            //1.thread ile 3. threadin hızlarını kıyaslayıp göstermek için
            Thread.Sleep(15);

            //Eğer diğer threadlerden biri bittiyse bu thread kendini sonlandırır
            if (token.IsCancellationRequested)
            {
                token.ThrowIfCancellationRequested();
            }

            var textBox = (TextBox)tableLayoutPanel3.GetControlFromPosition(col, row);
            textBox.BeginInvoke((MethodInvoker)delegate () //ana threade işi bırakması için böylece ana ekrana görseli çizdirebilir
            {
                textBox.BackColor = Color.LightGreen;
                textBox.Text = deger.ToString();
            });
            //console ve dosyaya thread bilgilerini yazdırıyoruz
            var mesaj = $"TreadId: {Thread.CurrentThread.ManagedThreadId} --> row:{row} col:{col} için deger: {deger} yaptı.";
            Console.WriteLine(mesaj);
            sb.AppendLine(mesaj);
        }
        
        //stringbuilder(sb) içinde biriken thread bilgilerinin toplu olarak dosyaya yazdırılıyor
        private void LoguDosyayaYazdir()
        {
            var fileName = Directory.GetCurrentDirectory() + @"\Thread_Log.txt";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            using (var file = File.CreateText(fileName))
            {
                file.Write(sb.ToString());
            }
        }

        //Dosyadan verileri ilk çektiğimiz hale getiriyor ekranı yani ekranı temizleme işlemi yapılıyor
        private void clear_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dosyaYolu))
            {
                DosyadanSudokuOku();
                SudokuCiz(tableLayoutPanel1, sudoku1, Color.LightBlue);
                SudokuCiz(tableLayoutPanel2, sudoku2, Color.LightPink);
                SudokuCiz(tableLayoutPanel3, sudoku3, Color.LightBlue);
            }
        }

        //bilgisayardan seçilen dosyayı bulup sudokuyu ekrana basıyor
        private void yenioyun_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Directory.GetCurrentDirectory();
            file.Filter = "Text Dosyası | *.txt";
            file.ShowDialog();
            dosyaYolu = file.FileName;

            DosyadanSudokuOku();
            SudokuCiz(tableLayoutPanel1, sudoku1, Color.LightBlue);
            SudokuCiz(tableLayoutPanel2, sudoku2, Color.LightPink);
            SudokuCiz(tableLayoutPanel3, sudoku3, Color.LightBlue);
        }

        //Yeni oyun
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Directory.GetCurrentDirectory();
            file.Filter = "Text Dosyası | *.txt";
            file.ShowDialog();
            dosyaYolu = file.FileName;

            DosyadanSudokuOku();
            SudokuCiz(tableLayoutPanel1, sudoku1, Color.LightBlue);
            SudokuCiz(tableLayoutPanel2, sudoku2, Color.LightPink);
            SudokuCiz(tableLayoutPanel3, sudoku3, Color.LightCyan);
        }

        //çıkış
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğine emin misin?", "Cıkıs",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }
        //sudoku nedır
        private void sudokuNedirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sudoku_nedir yeni = new sudoku_nedir();
            yeni.Show();
        }
        //hakkında
        private void hakkındaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            hakkında yeni2 = new hakkında();
            yeni2.Show();
        }
    }
}
