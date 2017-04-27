using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;

namespace sample2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string path;
        string  t2;
        string t1;
        OpenFileDialog ofd = new OpenFileDialog();
     //   SaveFileDialog sfd = new SaveFileDialog();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
            panel6.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ofd.Filter = "WAV|*.wav";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
                textBox2.Text = ofd.SafeFileName;
            }

            step1();
            button7.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Text|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = ofd.FileName;
                textBox5.Text = ofd.SafeFileName;
            }
            textBox4.Visible = true;
            textBox5.Visible = true;
            label5.Visible = true;
            textBox6.Visible = true;
            


            step2();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label7.Visible = true;
            step3();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            step4();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            label10.Visible = true;
            textBox10.Visible = true;
            label13.Visible = true;
            step5();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel2.Visible = false;
            panel1.Visible = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel2.Visible = true;

        }

        private void button16_Click(object sender, EventArgs e)
        {
            ofd.Filter = "WAV|*.wav";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox11.Text = ofd.FileName;
                textBox12.Text = ofd.SafeFileName;
            }
            step6();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Text|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
                path = ofd.FileName;

            step7();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;

        }

        private void button19_Click(object sender, EventArgs e)
        {
            label19.Visible = true;
            textBox16.Visible = true;
            step8();
            step9();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel6.Visible = false;
            panel5.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel2.Visible = false;
            panel1.Visible = false;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel6.Visible = false;
            panel5.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel2.Visible = true;
        }


        public void step1()
        {
            Stopwatch stopwatch1 = Stopwatch.StartNew();
            string text;

            var fs1 = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read);
            StreamReader sr1 = new StreamReader(fs1);
            text = sr1.ReadToEnd();

            Byte[] arr1 = Encoding.ASCII.GetBytes(text);

            FileStream fs2 = new FileStream("E:\\op1.txt", FileMode.Create, FileAccess.Write);

            StreamWriter binfile = new StreamWriter(fs2);



            for (int i = 0; i < arr1.Length; i++)
            {
                binfile.WriteLine(Convert.ToString(arr1[i], 2).PadLeft(8, '0'));

            }
            System.Threading.Thread.Sleep(500);
            stopwatch1.Stop();
            string t1 = stopwatch1.ElapsedMilliseconds.ToString();
            textBox3.Text = t1;
            sr1.Close();
            fs1.Close();

            binfile.Close();
            fs2.Close();

        }


        public void step2()
        {
            Stopwatch stopwatch2 = Stopwatch.StartNew();
            string text;
            var fs = new FileStream(textBox4.Text, FileMode.Open, FileAccess.Read);


            StreamReader sr = new StreamReader(fs);
            text = sr.ReadToEnd();




            Byte[] arr1 = Encoding.ASCII.GetBytes(text);

            FileStream fs2 = new FileStream("E:\\op2.txt", FileMode.Create, FileAccess.Write);

            StreamWriter binfile = new StreamWriter(fs2);



            for (int i = 0; i < arr1.Length; i++)
            {
                binfile.WriteLine(Convert.ToString(arr1[i], 2).PadLeft(8, '0'));

            }

            System.Threading.Thread.Sleep(500);
            stopwatch2.Stop();
            string t2 = stopwatch2.ElapsedMilliseconds.ToString();
            textBox6.Text = t2;
            binfile.Close();
            fs2.Close();

            sr.Close();
            fs.Close();
        }

        public void step3()
        {
            Stopwatch stopwatch3 = Stopwatch.StartNew();
            int min = 0;
            int max = 100;
            int[] numbers = new int[max - min];

            for (int i = min; i < max; i++)
                numbers[i - min] = i;

            Shuffle(numbers);

            string display = "";
            for (int i = min; i < max; i++)
            {
                display += "" + numbers[i - min];
                Console.WriteLine("The random number generated is {0}", display);
                FileStream f1 = new FileStream("E:\\key1.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw1 = new StreamWriter(f1);
                sw1.Write(display);
                sw1.Close();
                f1.Close();
                break;
            }

            string plainText = numbers[0].ToString();
            string passPhrase = "Pas5pr@se";        // can be any string
            string saltValue = "s@1tValue";        // can be any string
            string hashAlgorithm = "SHA1";             // can be "MD5"
            int passwordIterations = 2;                // can be any number
            string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
            int keySize = 256;                // can be 192 or 128

            Console.WriteLine(String.Format("Plaintext : {0}", plainText));

            string cipherText = Encrypt
            (
                plainText,
                passPhrase,
                saltValue,
                hashAlgorithm,
                passwordIterations,
                initVector,
                keySize
            );

            Console.WriteLine(String.Format("Encrypted : {0}", cipherText));
            FileStream f = new FileStream("E:\\stegokey.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(f);
            sw.WriteLine(cipherText);
            System.Threading.Thread.Sleep(500);
            stopwatch3.Stop();
            textBox7.Text = stopwatch3.ElapsedMilliseconds.ToString();
            sw.Close();
            f.Close();
        }
        public static string Encrypt
   (
       string plainText,
       string passPhrase,
       string saltValue,
       string hashAlgorithm,
       int passwordIterations,
       string initVector,
       int keySize
   )
        {
            // Convert strings into byte arrays.
            // Let us assume that strings only contain ASCII codes.
            // If strings include Unicode characters, use Unicode, UTF7, or UTF8 
            // encoding.
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

            // Convert our plaintext into a byte array.
            // Let us assume that plaintext contains UTF8-encoded characters.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // First, we must create a password, from which the key will be derived.
            // This password will be generated from the specified passphrase and 
            // salt value. The password will be created using the specified hash 
            // algorithm. Password creation can be done in several iterations.
            PasswordDeriveBytes password = new PasswordDeriveBytes
            (
                passPhrase,
                saltValueBytes,
                hashAlgorithm,
                passwordIterations
            );

            // Use the password to generate pseudo-random bytes for the encryption
            // key. Specify the size of the key in bytes (instead of bits).
            byte[] keyBytes = password.GetBytes(keySize / 8);

            // Create uninitialized Rijndael encryption object.
            RijndaelManaged symmetricKey = new RijndaelManaged();

            // It is reasonable to set encryption mode to Cipher Block Chaining
            // (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC;

            // Generate encryptor from the existing key bytes and initialization 
            // vector. Key size will be defined based on the number of the key 
            // bytes.
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor
            (
                keyBytes,
                initVectorBytes
            );

            // Define memory stream which will be used to hold encrypted data.
            MemoryStream memoryStream = new MemoryStream();

            // Define cryptographic stream (always use Write mode for encryption).
            CryptoStream cryptoStream = new CryptoStream
            (
                memoryStream,
                encryptor,
                CryptoStreamMode.Write
            );

            // Start encrypting.
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

            // Finish encrypting.
            cryptoStream.FlushFinalBlock();

            // Convert our encrypted data from a memory stream into a byte array.
            byte[] cipherTextBytes = memoryStream.ToArray();

            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();

            // Convert encrypted data into a base64-encoded string.
            string cipherText = Convert.ToBase64String(cipherTextBytes);


            // Return encrypted string.
            return cipherText;
        }


        static void Shuffle(int[] list)
        {
            var rnd = new Random();
            int n = list.Count();
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                int value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public void step4()
        {
            Stopwatch stopwatch3 = Stopwatch.StartNew();
            int i = 1, a = 0;

            FileStream f1 = new FileStream("E:\\key1.txt", FileMode.Open, FileAccess.Read);
            StreamReader r1 = new StreamReader(f1);
            string t1 = r1.ReadToEnd();
            t1.ToCharArray();
            int x = Convert.ToInt32(t1);
            Console.WriteLine(x);

            FileStream f2 = new FileStream("E:\\op1.txt", FileMode.Open, FileAccess.Read);
            StreamReader r2 = new StreamReader(f2);
            string t2 = r2.ReadLine();

            FileStream f3 = new FileStream("E:\\op2.txt", FileMode.Open, FileAccess.Read);
            StreamReader r3 = new StreamReader(f3);
            String t3 = r3.ReadLine();

            FileStream f4 = new FileStream("E:\\op3.txt", FileMode.Create, FileAccess.Write);
            StreamWriter w4 = new StreamWriter(f4);

            while (t2 != null)
            {

                if (i == x)
                {
                    a = i;
                    while (t3 != null)
                    {
                        char[] z = t3.ToCharArray();

                        for (int j = z.Count() - 1; j >= 0; j--)
                        {
                            char[] y = t2.ToCharArray();
                            y[7] = z[j];
                            y.ToString();
                            w4.WriteLine(y);
                            t2 = r2.ReadLine();
                            ++a;
                        }

                        t3 = r3.ReadLine();
                    }

                }
                //byte[] arr1 = Encoding.ASCII.GetBytes(t2);
                //for (int k = 0; k < arr1.Count(); k++)
                w4.WriteLine(t2);
                t2 = r2.ReadLine();
                i++;
            }

            string plainText = a.ToString();
            string passPhrase = "Pas5pr@se";        // can be any string
            string saltValue = "s@1tValue";        // can be any string
            string hashAlgorithm = "SHA1";             // can be "MD5"
            int passwordIterations = 2;                // can be any number
            string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
            int keySize = 256;                // can be 192 or 128

            string cipherText = Encrypt
            (
                plainText,
                passPhrase,
                saltValue,
                hashAlgorithm,
                passwordIterations,
                initVector,
                keySize
            );

            FileStream f = new FileStream("E:\\stegokey.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(f);
            sw.WriteLine(cipherText);
            System.Threading.Thread.Sleep(500);
            stopwatch3.Stop();
            textBox8.Text = stopwatch3.ElapsedMilliseconds.ToString();
            sw.Close();
            f.Close();

            r1.Close();
            f1.Close();

            r2.Close();
            f2.Close();

            r3.Close();
            f3.Close();

            w4.Close();
            f4.Close();
        }

        public void step5()
        {
            Stopwatch stopwatch4 = Stopwatch.StartNew();
            double dec = 0;
            FileStream fs4 = new FileStream("E:\\op3.txt", FileMode.Open, FileAccess.Read);
            string r1;
            StreamReader s = new StreamReader(fs4);
            FileStream fs5 = new FileStream("E:\\str3.txt", FileMode.Create, FileAccess.ReadWrite);
            StreamWriter wr = new StreamWriter(fs5);
            r1 = s.ReadLine();
            while (r1 != null)
            {
                r1.ToCharArray();

                for (int i = 0; i < r1.Length; i++)
                {
                    // we start with the least significant digit, and work our way to the left
                    if (r1[r1.Length - i - 1] == '0') continue;
                    dec += (int)Math.Pow(2, i);
                }
                //Console.WriteLine(dec);
                char c = (char)(dec);
                String r2 = c.ToString();
                byte[] q = Encoding.ASCII.GetBytes(r2);

                //Console.WriteLine(r1);
                // for(int i=0; i<q.Count();i++)

                wr.Write(Encoding.ASCII.GetChars(q));


                dec = 0.0;
                r1 = s.ReadLine();
            }
            s.Close();
            wr.Close();
            fs4.Close();
            fs5.Close();

            byte[] arr2 = File.ReadAllBytes("E:\\str3.txt");
            File.WriteAllBytes("E:\\encrypt.wav", arr2);
            System.Threading.Thread.Sleep(500);
            stopwatch4.Stop();
            textBox9.Text = stopwatch4.ElapsedMilliseconds.ToString();
            int sum = Convert.ToInt32(textBox3.Text) + Convert.ToInt32(textBox6.Text) + Convert.ToInt32(textBox7.Text) + Convert.ToInt32(textBox8.Text) + Convert.ToInt32(textBox9.Text);
            textBox10.Text = sum.ToString() ;
        }


        public void step6()
        {
            Stopwatch stopwatch5 = Stopwatch.StartNew();
            string text;


            var fs1 = new FileStream(textBox11.Text, FileMode.Open, FileAccess.Read);
            StreamReader sr1 = new StreamReader(fs1);
            text = sr1.ReadToEnd();

            Byte[] arr1 = Encoding.ASCII.GetBytes(text);

            FileStream fs2 = new FileStream("E:\\op4.txt", FileMode.Create, FileAccess.Write);

            StreamWriter binfile = new StreamWriter(fs2);



            for (int i = 0; i < arr1.Length; i++)
            {
                binfile.WriteLine(Convert.ToString(arr1[i], 2).PadLeft(8, '0'));
                
            }
            System.Threading.Thread.Sleep(500);
            stopwatch5.Stop();
            textBox13.Text = stopwatch5.ElapsedMilliseconds.ToString();

            sr1.Close();
            fs1.Close();

            binfile.Close();
            fs2.Close();
        }
        public void step7()
        {
            Stopwatch stopwatch6 = Stopwatch.StartNew();
            FileStream f1 = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr1 = new StreamReader(f1);
            string cipherText = sr1.ReadLine();

            FileStream f2 = new FileStream("E:\\key2.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sr2 = new StreamWriter(f2);

            while (cipherText != null)
            {
                string plainText;    // original plaintext
                string passPhrase = "Pas5pr@se";        // can be any string
                string saltValue = "s@1tValue";        // can be any string
                string hashAlgorithm = "SHA1";             // can be "MD5"
                int passwordIterations = 2;                // can be any number
                string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
                int keySize = 256;                // can be 192 or 128
                plainText = Decrypt
           (
               cipherText,
               passPhrase,
               saltValue,
               hashAlgorithm,
               passwordIterations,
               initVector,
               keySize
           );

                sr2.WriteLine(plainText);
                //Console.WriteLine(String.Format("Decrypted : {0}", plainText));
                cipherText = sr1.ReadLine();
            }
            System.Threading.Thread.Sleep(500);
            stopwatch6.Stop();
            textBox14.Text = stopwatch6.ElapsedMilliseconds.ToString();

            sr2.Close();
            f2.Close();

            sr1.Close();
            f1.Close();
        }
        public static string Decrypt
    (
       string cipherText,
       string passPhrase,
       string saltValue,
       string hashAlgorithm,
       int passwordIterations,
       string initVector,
       int keySize
    )
        {
            // Convert strings defining encryption key characteristics into byte
            // arrays. Let us assume that strings only contain ASCII codes.
            // If strings include Unicode characters, use Unicode, UTF7, or UTF8
            // encoding.
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

            // Convert our ciphertext into a byte array.
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            // First, we must create a password, from which the key will be 
            // derived. This password will be generated from the specified 
            // passphrase and salt value. The password will be created using
            // the specified hash algorithm. Password creation can be done in
            // several iterations.
            PasswordDeriveBytes password = new PasswordDeriveBytes
            (
                passPhrase,
                saltValueBytes,
                hashAlgorithm,
                passwordIterations
            );

            // Use the password to generate pseudo-random bytes for the encryption
            // key. Specify the size of the key in bytes (instead of bits).
            byte[] keyBytes = password.GetBytes(keySize / 8);

            // Create uninitialized Rijndael encryption object.
            RijndaelManaged symmetricKey = new RijndaelManaged();

            // It is reasonable to set encryption mode to Cipher Block Chaining
            // (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC;

            // Generate decryptor from the existing key bytes and initialization 
            // vector. Key size will be defined based on the number of the key 
            // bytes.
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor
            (
                keyBytes,
                initVectorBytes
            );

            // Define memory stream which will be used to hold encrypted data.
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

            // Define cryptographic stream (always use Read mode for encryption).
            CryptoStream cryptoStream = new CryptoStream
            (
                memoryStream,
                decryptor,
                CryptoStreamMode.Read
            );

            // Since at this point we don't know what the size of decrypted data
            // will be, allocate the buffer long enough to hold ciphertext;
            // plaintext is never longer than ciphertext.
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            // Start decrypting.
            int decryptedByteCount = cryptoStream.Read
            (
                plainTextBytes,
                0,
                plainTextBytes.Length
            );

            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();

            // Convert decrypted data into a string. 
            // Let us assume that the original plaintext string was UTF8-encoded.
            string plainText = Encoding.UTF8.GetString
            (
                plainTextBytes,
                0,
                decryptedByteCount
            );

            // Return decrypted string.   
            return plainText;
        }

        public void step8()
        {
            Stopwatch stopwatch7 = Stopwatch.StartNew();
            int i = 1, x1, x2;

            FileStream f1 = new FileStream("E:\\key2.txt", FileMode.Open, FileAccess.Read);
            StreamReader r1 = new StreamReader(f1);
            string t1 = r1.ReadLine();
            t1.ToCharArray();
            x1 = Convert.ToInt32(t1);
            Console.WriteLine(x1);
            string t12 = r1.ReadLine();
            t12.ToCharArray();
            x2 = Convert.ToInt32(t12);
            Console.WriteLine(x2);

            FileStream f2 = new FileStream("E:\\op4.txt", FileMode.Open, FileAccess.Read);
            StreamReader r2 = new StreamReader(f2);
            string t2 = r2.ReadLine();

            /*FileStream f3 = new FileStream("C:\\Users\\admin\\Desktop\\op2.txt", FileMode.Open, FileAccess.Read);
            StreamReader r3 = new StreamReader(f3);
            String t3 = r3.ReadLine();
            */
            FileStream f4 = new FileStream("E:\\op5.txt", FileMode.Create, FileAccess.Write);
            StreamWriter w4 = new StreamWriter(f4);

            while (t2 != null)
            {

                if (i == x1)
                {

                    while (i <= x2)
                    {

                        char[] y = new char[8];
                        for (int j = 0; j < 8; j++)
                        {
                            char[] z = t2.ToCharArray();
                            y[j] = z[7];
                            t2 = r2.ReadLine();
                            i++;
                            //++a;
                        }
                        if (i > x2)
                            break;
                        for (int j = y.Count() - 1; j >= 0; j--)
                        {
                            string g = y[j].ToString();
                            w4.Write(g);
                        }
                        w4.WriteLine();
                        //t3 = r3.ReadLine();
                    }
                    Console.WriteLine(i);
                }
                //byte[] arr1 = Encoding.ASCII.GetBytes(t2);
                //for (int k = 0; k < arr1.Count(); k++)
                //w4.WriteLine(t2);
                t2 = r2.ReadLine();
                i++;
            }

            System.Threading.Thread.Sleep(500);
            stopwatch7.Stop();
            t1= stopwatch7.ElapsedMilliseconds.ToString();
            r1.Close();
            f1.Close();

            r2.Close();
            f2.Close();

            //r3.Close();
            //f3.Close();

            w4.Close();
            f4.Close();

        }


        public void step9()
        {
            Stopwatch stopwatch8 = Stopwatch.StartNew();
            double dec = 0;
            FileStream fs4 = new FileStream("E:\\op5.txt", FileMode.Open, FileAccess.Read);
            string r1;
            StreamReader s = new StreamReader(fs4);
            FileStream fs5 = new FileStream("E:\\decryptedtextfile.txt", FileMode.Create, FileAccess.Write);
            StreamWriter wr = new StreamWriter(fs5);
            r1 = s.ReadLine();
            while (r1 != null)
            {
                r1.ToCharArray();

                for (int i = 0; i < r1.Length; i++)
                {
                    // we start with the least significant digit, and work our way to the left
                    if (r1[r1.Length - i - 1] == '0') continue;
                    dec += (int)Math.Pow(2, i);
                }
                //Console.WriteLine(dec);
                char c = (char)(dec);
                String r2 = c.ToString();
                byte[] q = Encoding.ASCII.GetBytes(r2);

                //Console.WriteLine(r1);
                // for(int i=0; i<q.Count();i++)

                wr.Write(Encoding.ASCII.GetChars(q));


                dec = 0.0;
                r1 = s.ReadLine();
            }
            System.Threading.Thread.Sleep(500);
            stopwatch8.Stop();
            t2 = stopwatch8.ElapsedMilliseconds.ToString();
            textBox15.Text = t1 + t2;
            int t5=Convert.ToInt32 (textBox15.Text) + Convert.ToInt32 ( textBox13.Text) + Convert.ToInt32  (textBox14.Text);
            textBox16.Text = t5.ToString();
            s.Close();
            wr.Close();
            fs4.Close();
            fs5.Close();

            
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }

         }

