using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Decrypter
{
    public partial class Form1 : Form
    {
        public char[] Crypt =
        {
            'E',
            'G',
            'Q',
            'S',
            'O',
            'P',
            'B',
            'X',
            'V',
            'K',
            'Y',
            'U',
            'Z',
            'J',
            'M',
            'H',
            'N',
            'C',
            'W',
            'F',
            'L',
            'A',
            'R',
            'D',
            'T',
            'I'
        };

        public Form1()
        {
            InitializeComponent();

            CryptTypeBox.SelectedIndex = 0;
        }

        private void InputBox_TextChanged(object sender, EventArgs e)
        {
            if (!(CryptTypeBox.SelectedIndex < 0))
            {
                if (CryptTypeBox.SelectedIndex == 0)
                {
                    Encrypt();
                }
                else if (CryptTypeBox.SelectedIndex == 1)
                {
                    Decrypt();
                }
            }
            else
            {
                return;
            }
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(OutputBox.Text);
        }

        private void Decrypt()
        {
            string[] input = InputBox.Text.Split();
            string output = "";

            foreach (string s in input)
            {
                if (s == "-")
                {
                    output += " ";
                    continue;
                }

                if (int.TryParse(s, out int index))
                {
                    output += GetCharFromIndex(--index);
                }
            }

            OutputBox.Text = output;
        }

        private void Encrypt()
        {
            if (string.IsNullOrWhiteSpace(InputBox.Text))
            {
                InputBox.Clear();
                return;
            }

            string[] input = InputBox.Text.Split();
            string output = "";

            foreach (string s in input)
            {
                char[] chars = s.ToCharArray();
                int charLength = chars.Length;
                int iteration = 1;

                foreach (char c in chars)
                {
                    int index = GetIndexFromChar(c);

                    if (index != -1)
                    {
                        output += index + " ";
                    }

                    if (iteration == charLength)
                    {
                        output += "- ";
                    }

                    iteration++;
                }
            }

            OutputBox.Text = output.Remove(output.Length - 2);
        }

        private string GetCharFromIndex(int index)
        {
            foreach (char cryptchar in Crypt)
            {
                if (index == Array.IndexOf(Crypt, cryptchar))
                {
                    return cryptchar.ToString();
                }
            }

            return null;
        }

        private int GetIndexFromChar(char c)
        {
            foreach (char cryptchar in Crypt)
            {
                if (c == cryptchar)
                {
                    return Array.IndexOf(Crypt, cryptchar) + 1;
                }
            }

            return -1;
        }
    }
}
