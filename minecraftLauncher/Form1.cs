using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace minecraftLauncher
{
    public partial class Form1 : Form
    {
        bool lang;
        string error = "Ops, faltou o nick";
        string errorTab = "Erro";
        string warning = "Lembre-se:";
        string warningFirst = "1- Você precisa da última versão do Minecraft instalada";
        string warningSecond = "2 - Se você logar no Multiplayer com nicks alterados, pode perder todos os itens";
        string warningHaveFun = "E BOA PIPIPITCHUZADA!";


        public Form1()
        {
            InitializeComponent();
            if (File.ReadLines("langs/settings.txt").First() == "en")
            {
                LanguageLoad("langs/lang_english.txt");
                languageButton.Text = "EN";
                lang = true;
            }
            else if (File.ReadLines("langs/settings.txt").First() == "pt")
            {
                LanguageLoad("langs/lang_portugese.txt");
                languageButton.Text = "PT";
                lang = false;
            }
        }

        private void bFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void LanguageLoad(string Path)
        {
            //string file = File.ReadLines(Path).ElementAtOrDefault(Line);
            bVai.Text = File.ReadLines(Path).ElementAtOrDefault(0);
            bFechar.Text = File.ReadLines(Path).ElementAtOrDefault(1);
            button1.Text = File.ReadLines(Path).ElementAtOrDefault(2);
            error = File.ReadLines(Path).ElementAtOrDefault(7);
            errorTab = File.ReadLines(Path).ElementAtOrDefault(8);
            warning = File.ReadLines(Path).ElementAtOrDefault(3);
            warningFirst = File.ReadLines(Path).ElementAtOrDefault(4);
            warningSecond = File.ReadLines(Path).ElementAtOrDefault(5);
            warningHaveFun = File.ReadLines(Path).ElementAtOrDefault(6);
        }

        private void bVai_Click(object sender, EventArgs e)
        {
            if (tbNick.Text == string.Empty)
            {
                MessageBox.Show(error, errorTab, MessageBoxButtons.OK);
                tbNick.Focus();
            }
            else
            {
                Process proc = new Process();
                proc.StartInfo.FileName = "java";
                string args = "-Xincgc -Xmx1024m -cp \"%APPDATA%\\.minecraft\\bin\\minecraft.jar;%APPDATA%\\.minecraft\\bin\\lwjgl.jar;%APPDATA%\\.minecraft\\bin\\lwjgl_util.jar;%APPDATA%\\.minecraft\\bin\\jinput.jar\" -Djava.library.path=\"%APPDATA%\\.minecraft\\bin\\natives\" net.minecraft.client.Minecraft \""+tbNick.Text.Trim()+"\"";
                proc.StartInfo.Arguments = Environment.ExpandEnvironmentVariables(args);
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = false;
                proc.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = @" ";
            msg = string.Concat(msg,Environment.NewLine, warning, Environment.NewLine, warningFirst);
            msg = string.Concat(msg, Environment.NewLine, warningSecond);
            msg = string.Concat(msg, Environment.NewLine,Environment.NewLine, warningHaveFun);

            MessageBox.Show(msg, "Disclaimer", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void languageButton_Click(object sender, EventArgs e)
        {
            if(lang.Equals(false))
            {
                languageButton.Text = "EN";
                LanguageLoad("langs/lang_english.txt");
                File.WriteAllText("langs/settings.txt", "en" + Environment.NewLine);
                lang = true;
            }
            else if(lang.Equals(true))
            {
                languageButton.Text = "PT";
                LanguageLoad("langs/lang_portugese.txt");
                File.WriteAllText("langs/settings.txt", "pt" + Environment.NewLine);
                lang = false;
            }
        }
    }
}
