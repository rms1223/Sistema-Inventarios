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
        }
}
