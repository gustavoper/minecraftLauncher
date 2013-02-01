using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


namespace minecraftLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bVai_Click(object sender, EventArgs e)
        {
            if (tbNick.Text == string.Empty)
            {
                MessageBox.Show("Ops, faltou o nick", "Erro", MessageBoxButtons.OK);
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
            string msg = @"Este pequeno MOD serve para iniciar seu Minecraft com o nick que você usa no servidor online";
            msg = string.Concat(msg,Environment.NewLine, "Lembre-se:", Environment.NewLine, "1- Você precisa da última versão do Minecraft instalada");
            msg = string.Concat(msg, Environment.NewLine, "2 - Se você logar no Multiplayer com nicks alterados, pode perder todos os itens");
            msg = string.Concat(msg, Environment.NewLine,Environment.NewLine,"E BOA PIPIPITCHUZADA!");

            MessageBox.Show(msg, "Disclaimer", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
