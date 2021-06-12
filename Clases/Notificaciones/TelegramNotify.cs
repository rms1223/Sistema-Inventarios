using System;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Types.InputFiles;

namespace InventarioFod.Clases.Notificaciones
{
    class TelegramNotify
    {
        private  TelegramBotClient _telegram_bot;

        private string _accionComando;
        private  Process_Notify _processNotify;
        private Telegram.Bot.Args.MessageEventArgs _messageEvent;
        private Telegram.Bot.Types.Chat _chat;


        public TelegramNotify()
        {
            try
            {
                _processNotify = new Process_Notify();
                _telegram_bot = new TelegramBotClient("");
                if (_chat == null)
                {
                    _chat = new Telegram.Bot.Types.Chat
                    {
                        Id = 505277626
                    };
                }
                SendMessageInit();
                _telegram_bot.OnMessage += SendTextAsync;
                _telegram_bot.StartReceiving();
            }
            catch (Exception)
            {

                
            }
            
        }

        private void SendTextAsync(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (_messageEvent == null)
            {
                _messageEvent = e;
            }
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                if (e.Message.Text.StartsWith("/") || String.IsNullOrEmpty(_accionComando))
                {
                    ProcessCmd(e);
                }
                else
                {
                    ProcessRequestVal(e);
                }

            }

        }
        private async void ProcessCmd(Telegram.Bot.Args.MessageEventArgs e)
        {
            switch (e.Message.Text)
            {
                case "/Acciones":
                    _accionComando = e.Message.Text;
                    await _telegram_bot.SendTextMessageAsync(e.Message.Chat.Id, $"{e.Message.Chat.Username} Por Favor Ingrese el Número de Acción: ");
                    break;
                case "/Reequipamientos":
                    _accionComando = e.Message.Text;
                    await _telegram_bot.SendTextMessageAsync(e.Message.Chat.Id, $"{e.Message.Chat.Username} Ingrese el Listado a Buscar: ");
                    break;
                case "/Tecnicos_Cant_Equipos":
                    _accionComando = e.Message.Text;
                    await _telegram_bot.SendTextMessageAsync(e.Message.Chat.Id,"Ingrese la fecha a Buscar\n'<Formato a ingresar es " +
                        "dd/MM/yyyy>'");
                    break;
                default:
                    await _telegram_bot.SendTextMessageAsync(e.Message.Chat.Id, @"Comandos A utilizar:
                        /Acciones
                        /Reequipamientos
                        /Tecnicos_Cant_Equipos
                   ");
                    
                    break;
            }
        }
        private void ProcessRequestVal(Telegram.Bot.Args.MessageEventArgs e)
        {
            switch (_accionComando)
            {
                case "/Acciones":
                    SendFileAction(e, Convert.ToInt32(e.Message.Text));
                    break;
                case "/Reequipamientos":
                    SendFileList(e, Convert.ToInt32(e.Message.Text));
                    break;
                default:
                    break;
            }
            _accionComando = String.Empty;
        }

        public async void SendMessageInit()
        {
            try
            {
                await _telegram_bot.SendTextMessageAsync(_chat.Id, $"Inicio en Sistema Inventario" +
                $"\nFecha: {DateTime.Now.ToString("dd/MM/yyyy")}" +
                $"\nHora de Registro: {DateTime.Now.ToString("hh:mm tt")}" +
                $"\nUsuario: {Environment.UserName}");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al conectar "+ex);
            }
            
        }
        public async void SendMessageSave(string message)
        {
            await _telegram_bot.SendTextMessageAsync(_chat.Id, $"{message}" +
                $"\nFecha: {DateTime.Now.ToString("dd/MM/yyyy")}" +
                $"\nHora de Registro: {DateTime.Now.ToString("hh:mm tt")}" +
                $"\nUsuario: {Environment.UserName}");
        }
        private async void Send_message_reequi(Telegram.Bot.Args.MessageEventArgs e)
        {
            await _telegram_bot.SendTextMessageAsync(e.Message.Chat, $"Lista ejecutada {e.Message.Text} " +
                $"\nFecha: {e.Message.Date.ToString("dd/MM/yyyy")}" +
                $"\nTotal de Registros: {6}");
        }
        private async void SendFileAction(Telegram.Bot.Args.MessageEventArgs e,int accion)
        {
            
            using (var file = File.Open(_processNotify.SelectByAction(accion), FileMode.Open))
            {
                InputOnlineFile fs = new InputOnlineFile(file, $"Accion{accion}.xlsx");
                await _telegram_bot.SendDocumentAsync(e.Message.Chat, fs, $"Accion Revisada #{accion}");
            }
        }
        private async void SendFileList(Telegram.Bot.Args.MessageEventArgs e, int list)
        {
            using (var file = File.Open(_processNotify.SelectByList(list), FileMode.Open))
            {
                InputOnlineFile fs = new InputOnlineFile(file, $"Lista{list}.xlsx");
                await _telegram_bot.SendDocumentAsync(e.Message.Chat, fs, $"Lista Asignada #{list}");
            }
        }
    }
}
