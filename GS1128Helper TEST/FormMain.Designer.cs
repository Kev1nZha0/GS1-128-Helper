
namespace GS1128Helper_TEST
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxAI = new System.Windows.Forms.ComboBox();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.richTextBoxList = new System.Windows.Forms.RichTextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEncode = new System.Windows.Forms.Button();
            this.textBoxEncode = new System.Windows.Forms.TextBox();
            this.buttonGetValue = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBoxDecode = new System.Windows.Forms.ComboBox();
            this.textBoxDecodeValue = new System.Windows.Forms.TextBox();
            this.groupBoxEncode = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxEncode.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxAI
            // 
            this.comboBoxAI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAI.FormattingEnabled = true;
            this.comboBoxAI.Location = new System.Drawing.Point(6, 19);
            this.comboBoxAI.Name = "comboBoxAI";
            this.comboBoxAI.Size = new System.Drawing.Size(404, 21);
            this.comboBoxAI.TabIndex = 0;
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(6, 47);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(404, 20);
            this.textBoxValue.TabIndex = 1;
            // 
            // richTextBoxList
            // 
            this.richTextBoxList.Location = new System.Drawing.Point(497, 19);
            this.richTextBoxList.Name = "richTextBoxList";
            this.richTextBoxList.ReadOnly = true;
            this.richTextBoxList.Size = new System.Drawing.Size(273, 197);
            this.richTextBoxList.TabIndex = 2;
            this.richTextBoxList.Text = "";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(416, 45);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "添加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEncode
            // 
            this.buttonEncode.Location = new System.Drawing.Point(6, 73);
            this.buttonEncode.Name = "buttonEncode";
            this.buttonEncode.Size = new System.Drawing.Size(75, 23);
            this.buttonEncode.TabIndex = 4;
            this.buttonEncode.Text = "生成条码";
            this.buttonEncode.UseVisualStyleBackColor = true;
            this.buttonEncode.Click += new System.EventHandler(this.buttonEncode_Click);
            // 
            // textBoxEncode
            // 
            this.textBoxEncode.Location = new System.Drawing.Point(6, 19);
            this.textBoxEncode.Name = "textBoxEncode";
            this.textBoxEncode.Size = new System.Drawing.Size(485, 20);
            this.textBoxEncode.TabIndex = 5;
            // 
            // buttonGetValue
            // 
            this.buttonGetValue.Location = new System.Drawing.Point(410, 43);
            this.buttonGetValue.Name = "buttonGetValue";
            this.buttonGetValue.Size = new System.Drawing.Size(75, 23);
            this.buttonGetValue.TabIndex = 6;
            this.buttonGetValue.Text = "读取";
            this.buttonGetValue.UseVisualStyleBackColor = true;
            this.buttonGetValue.Click += new System.EventHandler(this.buttonGetValue_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 222);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(764, 82);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // comboBoxDecode
            // 
            this.comboBoxDecode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDecode.FormattingEnabled = true;
            this.comboBoxDecode.Location = new System.Drawing.Point(6, 45);
            this.comboBoxDecode.Name = "comboBoxDecode";
            this.comboBoxDecode.Size = new System.Drawing.Size(398, 21);
            this.comboBoxDecode.TabIndex = 8;
            // 
            // textBoxDecodeValue
            // 
            this.textBoxDecodeValue.Location = new System.Drawing.Point(6, 72);
            this.textBoxDecodeValue.Name = "textBoxDecodeValue";
            this.textBoxDecodeValue.Size = new System.Drawing.Size(485, 20);
            this.textBoxDecodeValue.TabIndex = 9;
            // 
            // groupBoxEncode
            // 
            this.groupBoxEncode.Controls.Add(this.buttonClear);
            this.groupBoxEncode.Controls.Add(this.comboBoxAI);
            this.groupBoxEncode.Controls.Add(this.richTextBoxList);
            this.groupBoxEncode.Controls.Add(this.textBoxValue);
            this.groupBoxEncode.Controls.Add(this.buttonAdd);
            this.groupBoxEncode.Controls.Add(this.pictureBox1);
            this.groupBoxEncode.Controls.Add(this.buttonEncode);
            this.groupBoxEncode.Location = new System.Drawing.Point(12, 12);
            this.groupBoxEncode.Name = "groupBoxEncode";
            this.groupBoxEncode.Size = new System.Drawing.Size(776, 310);
            this.groupBoxEncode.TabIndex = 10;
            this.groupBoxEncode.TabStop = false;
            this.groupBoxEncode.Text = "生成";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(87, 73);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 8;
            this.buttonClear.Text = "清空";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxEncode);
            this.groupBox1.Controls.Add(this.comboBoxDecode);
            this.groupBox1.Controls.Add(this.buttonGetValue);
            this.groupBox1.Controls.Add(this.textBoxDecodeValue);
            this.groupBox1.Location = new System.Drawing.Point(18, 328);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(770, 110);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "解码";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxEncode);
            this.Name = "FormMain";
            this.Text = "测试";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxEncode.ResumeLayout(false);
            this.groupBoxEncode.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAI;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.RichTextBox richTextBoxList;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEncode;
        private System.Windows.Forms.TextBox textBoxEncode;
        private System.Windows.Forms.Button buttonGetValue;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBoxDecode;
        private System.Windows.Forms.TextBox textBoxDecodeValue;
        private System.Windows.Forms.GroupBox groupBoxEncode;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

