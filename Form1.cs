using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        // 사용자 데이터(여기에선 예시로 woongbak)와 Nonce 값을 입력받아 해시값을 출력




        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        // Calculate 버튼을 누를때마다 랜덤 Nonce 값을 무작위 변경
      



        private void button1_Click(object sender, EventArgs e)
        {
            var timer = new Stopwatch();
            timer.Start();
            // Stopwatch 코드를 통해 시간을 측정

            String a = this.textBox1.Text + this.textBox2.Text;
            String result = ComputeSha256Hash(a);
            this.textBox3.Text = result;

            this.textBox2.Text = RandomString(5);

            String match_string = @"^00";
            if (Regex.IsMatch(this.textBox2.Text, match_string))
            {
                this.textBox5.Text = "YES!!";
            }
            else
            {
                this.textBox5.Text = "NO!!";
            }
            // Nonce 값이 무작위로 바뀌어 해시값이 나오되 결과가 0이 되면 YES!!가 출력(그 외에는 NO!!가 출력)

            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.ffffff");
            this.textBox4.Text = foo;
        }




        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }




        private void a(object sender, EventArgs e)
        {

        }
    }
}
