using GS1_128_Helper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GS1128Helper_TEST
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            InitCombobox();
        }

        private void InitCombobox()
        {
            comboBoxAI.Items.Clear();
            comboBoxDecode.Items.Clear();
            foreach (DataFieldContent Field in Enum.GetValues(typeof(DataFieldContent)))
            {
                string text = (int)Field + "|" + Field;
                comboBoxAI.Items.Add(text);
                comboBoxDecode.Items.Add(text);
            }
        }

        private static List<BuildItem> EncodeList = new List<BuildItem>();

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(comboBoxAI.SelectedIndex != -1)
            {
                int AI = Convert.ToInt32(comboBoxAI.Text.Split('|')[0]);
                EncodeList.Add(new BuildItem() { dataFieldConten = (DataFieldContent)AI, value = textBoxValue.Text });
                richTextBoxList.Text += $"({AI}){textBoxValue.Text}\r\n";
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            EncodeList = new List<BuildItem>();
            richTextBoxList.Text = "";
        }

        private void buttonEncode_Click(object sender, EventArgs e)
        {
            if(EncodeList != null && EncodeList.Count > 0)
            {
                GS1128Encoder code128 = new GS1128Encoder(EncodeList);
                code128.DataDisplay = true;
                textBoxEncode.Text = code128.ToString();
                System.Drawing.Image img = code128.GetBarCodeImage();
                pictureBox1.Image = img;
            }
        }

        private void buttonGetValue_Click(object sender, EventArgs e)
        {
            GS1128Decoder decoder = new GS1128Decoder(textBoxEncode.Text);
            if (decoder.IsValidBarcode)
            {
                int AI = Convert.ToInt32(comboBoxDecode.Text.Split('|')[0]);
                string text = decoder.GetFieldValue((DataFieldContent)AI);
                textBoxDecodeValue.Text = text;
            }
        }
    }
}
