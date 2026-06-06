using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Spectre.Console;

class PindikAI
{
    static async Task Main(string[] args)
    {
        AnsiConsole.MarkupLine("[bold cyan]🤖 PINDIK AI - Hoşgeldiniz![/]");
        AnsiConsole.MarkupLine("[yellow]Jarvis benzeri AI Asistanı - .NET 8[/]\n");

        bool running = true;

        while (running)
        {
            AnsiConsole.MarkupLine("[green]➜[/] Bir komut yazın (yardım için 'help' yazın):");
            var input = Console.ReadLine()?.ToLower().Trim();

            if (string.IsNullOrEmpty(input))
                continue;

            switch (input)
            {
                case "help":
                    ShowHelp();
                    break;

                case "sohbet":
                    await ChatMode();
                    break;

                case "görev yöneticisi":
                case "task manager":
                case "taskmgr":
                    OpenTaskManager();
                    break;

                case "not defteri":
                case "notepad":
                    OpenApplication("notepad.exe");
                    break;

                case "hesap makinesi":
                case "calculator":
                    OpenApplication("calc.exe");
                    break;

                case "dosya yöneticisi":
                case "file explorer":
                    OpenApplication("explorer.exe");
                    break;

                case "komut istemi":
                case "cmd":
                    OpenApplication("cmd.exe");
                    break;

                case "çıkış":
                case "exit":
                case "quit":
                    running = false;
                    AnsiConsole.MarkupLine("[yellow]Hoşça kalın! 👋[/]");
                    break;

                default:
                    AnsiConsole.MarkupLine("[red]❌ Komut tanınmadı. 'help' yazarak komutları görebilirsiniz.[/]");
                    break;
            }
        }
    }

    static void ShowHelp()
    {
        AnsiConsole.MarkupLine("\n[bold cyan]📋 MEVCUT KOMUTLAR:[/]\n");
        AnsiConsole.MarkupLine("[yellow]sohbet[/]              - AI ile sohbet et");
        AnsiConsole.MarkupLine("[yellow]görev yöneticisi[/]    - Görev Yöneticisini aç");
        AnsiConsole.MarkupLine("[yellow]not defteri[/]         - Notepad'i aç");
        AnsiConsole.MarkupLine("[yellow]hesap makinesi[/]      - Hesap Makinesini aç");
        AnsiConsole.MarkupLine("[yellow]dosya yöneticisi[/]    - Dosya Yöneticisini aç");
        AnsiConsole.MarkupLine("[yellow]komut istemi[/]        - Komut İstemini aç");
        AnsiConsole.MarkupLine("[yellow]çıkış[/]               - Uygulamayı kapat\n");
    }

    static void OpenTaskManager()
    {
        try
        {
            Process.Start("taskmgr.exe");
            AnsiConsole.MarkupLine("[green]✓ Görev Yöneticisi açıldı[/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]✗ Hata: {ex.Message}[/]");
        }
    }

    static void OpenApplication(string appPath)
    {
        try
        {
            Process.Start(appPath);
            AnsiConsole.MarkupLine($"[green]✓ {appPath} açıldı[/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]✗ Hata: {ex.Message}[/]");
        }
    }

    static async Task ChatMode()
    {
        AnsiConsole.MarkupLine("[cyan]💬 Sohbet Moduna Girdiniz[/]");
        AnsiConsole.MarkupLine("[dim](çıkmak için 'exit' yazın)\n[/]");

        string[] responses = new[]
        {
            "Merhaba! Sana nasıl yardımcı olabilirim? 😊",
            "İlginç bir soru! Bunun hakkında daha fazla bilgi verebilir misin?",
            "Anladım, başka bir şey sorabilir misin?",
            "Harikasın! Başka bir şey istersen söyle! 🎯",
            "Bu konuda daha bilgi gerekirse bana sor 💡",
            "Çok güzel bir fikir! Bunun üzerinde çalışmayı istersen yardımcı olabilirim.",
            "Hmm, ilginç. Daha detaylı açıklayabilir misin?"
        };

        Random random = new Random();

        while (true)
        {
            AnsiConsole.MarkupLine("[green]Sen:[/] ");
            var userMessage = Console.ReadLine();

            if (string.IsNullOrEmpty(userMessage))
                continue;

            if (userMessage.ToLower() == "exit")
            {
                AnsiConsole.MarkupLine("[yellow]Sohbet modundan çıkıldı.[/]\n");
                break;
            }

            var aiResponse = responses[random.Next(responses.Length)];
            AnsiConsole.MarkupLine($"[cyan]Pındık:[/] {aiResponse}\n");
        }
    }
}
