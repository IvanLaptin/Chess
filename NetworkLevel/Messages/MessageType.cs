using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLevel.Messages
{
    [Serializable]
    public enum MessageType
    {
        Registration,
        RegistrationAnswer,
        LogIn,
        LogInAnswer,
        LogOut,
        StartGameWithTheBot,
        StartGameOnline,
        StartGameOnlineAnswer,
        Move,
        FinishGame,
        YourMove,
        GetGameTables,
        ChangePasswordSettings,
        Disconnect
    }
}
