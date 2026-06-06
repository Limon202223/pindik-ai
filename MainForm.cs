using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PindikAI
{
    public partial class MainForm : Form
    {
        private TextBox inputTextBox;
        private TextBox outputTextBox;
        private Button sendButton;
        private Button helpButton;
        private Button taskmgrButton;
        private Button notepadButton;
        private Button calcButton;
        private Button explorerButton;
        private Label titleLabel;

        public MainForm()
        {
            InitializeComponent();
            SetupUI();
        }

        private void InitializeComponent()
        {
            this.Text = "🤖 Pındık AI - Asistan";
            this.Width = 700;
            this.Height = 600;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.ForeColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 10);
        }

        private void SetupUI()
        {
            // Başlık
            titleLabel = new Label();
            titleLabel.Text = "🤖 PINDIK AI - Hoşgeldiniz!";
            titleLabel.ForeColor = System.Drawing.Color.Cyan;
            titleLabel.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold);
            titleLabel.AutoSize = true;
            titleLabel.Location = new System.Drawing.Point(20, 15);
            this.Controls.Add(titleLabel);

            // Çıkış Paneli
            Panel outputPanel = new Panel();
            outputPanel.BorderStyle = BorderStyle.FixedSingle;
            outputPanel.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            outputPanel.Location = new System.Drawing.Point(20, 50);
            outputPanel.Width = 640;
            outputPanel.Height = 250;
            this.Controls.Add(outputPanel);

            // Çıkış TextBox
            outputTextBox = new TextBox();
            outputTextBox.Multiline = true;
            outputTextBox.ReadOnly = true;
            outputTextBox.ScrollBars = ScrollBars.Vertical;
            outputTextBox.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            outputTextBox.ForeColor = System.Drawing.Color.LimeGreen;
            outputTextBox.Font = new System.Drawing.Font("Consolas", 9);
            outputTextBox.Dock = DockStyle.Fill;
            outputTextBox.Text = "Pındık AI Başlatıldı...\nYardım için 'help' yazın.\n";
            outputPanel.Controls.Add(outputTextBox);

            // Giriş TextBox
            inputTextBox = new TextBox();
            inputTextBox.Location = new System.Drawing.Point(20, 310);
            inputTextBox.Width = 640;
            inputTextBox.Height = 35;
            inputTextBox.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
            inputTextBox.ForeColor = System.Drawing.Color.Yellow;
            inputTextBox.Font = new System.Drawing.Font("Segoe UI", 11);
            inputTextBox.Text = "Komut yazınız...";
            inputTextBox.KeyDown += InputTextBox_KeyDown;
            inputTextBox.Enter += (s, e) => { if (inputTextBox.Text == "Komut yazınız...") inputTextBox.Text = ""; };
            inputTextBox.Leave += (s, e) => { if (inputTextBox.Text == "") inputTextBox.Text = "Komut yazınız..."; };
            this.Controls.Add(inputTextBox);

            // Gönder Butonu
            sendButton = new Button();
            sendButton.Text = "Gönder";
            sendButton.Location = new System.Drawing.Point(20, 355);
            sendButton.Width = 100;
            sendButton.Height = 35;
            sendButton.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            sendButton.ForeColor = System.Drawing.Color.White;
            sendButton.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            sendButton.Click += SendButton_Click;
            this.Controls.Add(sendButton);

            // Komut Butonları
            int buttonY = 405;
            int buttonWidth = 150;
            int buttonHeight = 30;

            helpButton = CreateButton("Yardım", 20, buttonY, buttonWidth, buttonHeight, HelpButton_Click);
            taskmgrButton = CreateButton("Görev Yöneticisi", 180, buttonY, buttonWidth, buttonHeight, TaskmgrButton_Click);
            notepadButton = CreateButton("Not Defteri", 340, buttonY, buttonWidth, buttonHeight, NotepadButton_Click);
            calcButton = CreateButton("Hesap Makinesi", 500, buttonY, buttonWidth, buttonHeight, CalcButton_Click);

            buttonY += 40;
            explorerButton = CreateButton("Dosya Yöneticisi", 20, buttonY, buttonWidth, buttonHeight, ExplorerButton_Click);
        }

        private Button CreateButton(string text, int x, int y, int width, int height, EventHandler clickHandler)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Location = new System.Drawing.Point(x, y);
            btn.Width = width;
            btn.Height = height;
            btn.BackColor = System.Drawing.Color.FromArgb(80, 80, 80);
            btn.ForeColor = System.Drawing.Color.White;
            btn.Font = new System.Drawing.Font("Segoe UI", 9);
            btn.Click += clickHandler;
            this.Controls.Add(btn);
            return btn;
        }

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SendButton_Click(null, null);
                e.Handled = true;
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string input = inputTextBox.Text.ToLower().Trim();

            if (input == "komut yazınız..." || string.IsNullOrEmpty(input))
                return;

            AddOutput($"Sen: {input}\n");

            switch (input)
            {
                case "help":
                    ShowHelp();
                    break;
                case "sohbet":
                    AddOutput("Pındık: Merhaba! Sana nasıl yardımcı olabilirim? 😊\n");
                    break;
                case "görev yöneticisi":
                case "taskmgr":
                    OpenApplication("taskmgr.exe");
                    break;
                case "not defteri":
                case "notepad":
                    OpenApplication("notepad.exe");
                    break;
                case "hesap makinesi":
                case "calc":
                    OpenApplication("calc.exe");
                    break;
                case "dosya yöneticisi":
                case "explorer":
                    OpenApplication("explorer.exe");
                    break;
                default:
                    AddOutput("Pındık: Komut tanınmadı. 'help' yazarak komutları görebilirsiniz.\n");
                    break;
            }

            inputTextBox.Clear();
            inputTextBox.Text = "Komut yazınız...";
        }

        private void ShowHelp()
        {
            string help = @"
📋 MEVCUT KOMUTLAR:
- sohbet: AI ile sohbet et
- görev yöneticisi: Görev Yöneticisini aç
- not defteri: Notepad'i aç
- hesap makinesi: Hesap Makinesini aç
- dosya yöneticisi: Dosya Yöneticisini aç
- help: Bu yardım mesajını göster
";
            AddOutput(help);
        }

        private void OpenApplication(string appPath)
        {
            try
            {
                Process.Start(appPath);
                AddOutput($"Pındık: ✓ {appPath} açıldı\n");
            }
            catch (Exception ex)
            {
                AddOutput($"Pındık: ✗ Hata: {ex.Message}\n");
            }
        }

        private void AddOutput(string text)
        {
            outputTextBox.AppendText(text);
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            ShowHelp();
        }

        private void TaskmgrButton_Click(object sender, EventArgs e)
        {
            OpenApplication("taskmgr.exe");
        }

        private void NotepadButton_Click(object sender, EventArgs e)
        {
            OpenApplication("notepad.exe");
        }

        private void CalcButton_Click(object sender, EventArgs e)
        {
            OpenApplication("calc.exe");
        }

        private void ExplorerButton_Click(object sender, EventArgs e)
        {
            OpenApplication("explorer.exe");
        }
    }
}
