using InventarioFod.Clases.Entidades;
using System;
using Telegram.Bot;

namespace InventarioFod.Clases.Notificaciones
{
        class TelegramNotifyEquipos
        {
            private TelegramBotClient _telegram_bot;
            private Telegram.Bot.Args.MessageEventArgs _messageEvent;
            private Telegram.Bot.Types.Chat _chat;
            public TelegramNotifyEquipos()
            {
                try
                {
                    _telegram_bot = new TelegramBotClient("");
                    if (_chat == null)
                    {
                        _chat = new Telegram.Bot.Types.Chat
                        {
                            Id = 505277626
                        };
                    }
                    _telegram_bot.StartReceiving();
                }
                catch (Exception)
                {


                }
            }
            public async void SendMessageSave(Equipos_Instalacion_Instituciones equipos, string institucion)
            {
                await _telegram_bot.SendTextMessageAsync(_chat.Id, $"\nCentro Educativo: {institucion}" +
                    $"\nCodigo: {equipos.Codigo}" +
                    $"\nModalidad: {equipos.Modalidad}" +
                    $"\nPortatil Docente: {equipos.Port_docente}" +
                    $"\nPortatil Preescolar: {equipos.Port_preescolar}" +
                    $"\nPortatil Estudiante: {equipos.Port_1_estudiante}" +
                    $"\nPortatil Tipo2-8GB: {equipos.Port_2_estudiante}" +
                    $"\nRouter: {equipos.Router}" +
                    $"\nSwitch: {equipos.Switch24}" +
                    $"\nAP Interno MR20: {equipos.Ap_interno}" +
                    $"\nAP Externo MR70: {equipos.Ap_externo}" +
                    $"\nFecha: {DateTime.Now.ToString("dd/MM/yyyy")}" +
                    $"\nHora de Registro: {DateTime.Now.ToString("hh:mm tt")}" +
                    $"\nUsuario: {Environment.UserName}");
            }
        }
}
