﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Resources;

namespace HelloWorldWindows
{
    public partial class FormMain: Form
    {

        private static string OriginalText;
        private const string DEFAULT_FILE_NAME = "제목없음";
        private const string DEFAULT_FILE_FILTER = "텍스트 문서 (*.txt)|*.txt|csv 파일 (*.csv)|*.csv|모든 파일 (*.*)|*.*";

        public FormMain()
        {
            InitializeComponent();
            OriginalText = textBox1.Text;
            lblFileName.Text = DEFAULT_FILE_NAME;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "쾅!";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 끝내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 프로그램정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formAbout1 = new FormAbout();
            Form formAbout2 = new FormAbout();
            // 모달(Modal) 창
            formAbout1.Text = "모달창";
            formAbout1.ShowDialog();

            // 모달리스(Modeless) 창
            formAbout2.Text = "모달리스창";
            formAbout2.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = DEFAULT_FILE_FILTER;
            DialogResult result = openFileDialog.ShowDialog();

            switch(result)
            {
                case DialogResult.Cancel:
                    return;
                    break;
                case DialogResult.OK:
                    lblFileName.Text = openFileDialog.FileName;
                    using(StreamReader sr = new StreamReader(openFileDialog.FileName))
                    {
                        textBox1.Text = sr.ReadToEnd();
                        sr.Close();
                    }
                    break;
            }

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lblFileName_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void 새로만들기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblFileName.Text = DEFAULT_FILE_NAME;
            textBox1.Text = "글자를 입력해주세요.";
            OriginalText = textBox1.Text;
            lblTextChanged.Text = "";
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lblFileName.Text == DEFAULT_FILE_NAME)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = DEFAULT_FILE_FILTER;
                DialogResult result = saveFileDialog.ShowDialog();

                switch (result)
                {
                    case DialogResult.Cancel:
                        return;
                        break;
                    case DialogResult.OK:
                        lblFileName.Text = saveFileDialog.FileName;
                        break;
                }
            }
            using(StreamWriter sw =  new StreamWriter(lblFileName.Text))
            {
                sw.WriteLine(textBox1.Text);
                OriginalText = textBox1.Text;
                lblTextChanged.Text = "";
                sw.Close();
            }
        }

        private void 다른이름으로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = DEFAULT_FILE_FILTER;
                saveFileDialog.FileName = lblFileName.Text;
                DialogResult result = saveFileDialog.ShowDialog();

                switch (result)
                {
                    case DialogResult.Cancel:
                        return;
                        break;
                    case DialogResult.OK:
                        lblFileName.Text = saveFileDialog.FileName;
                        break;
                }
            using (StreamWriter sw = new StreamWriter(lblFileName.Text))
            {
                sw.WriteLine(textBox1.Text);
                OriginalText = textBox1.Text;
                lblTextChanged.Text = "";
                sw.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != OriginalText)
            {
                lblTextChanged.Text = "🌹";
            }
            else
            {
                lblTextChanged.Text = "";
            }
        }
    }
}
