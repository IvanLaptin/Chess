﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLevel.Messages
{
    [Serializable]
    class ChangePasswordSettings : Message
    {
        public override MessageType Type
        {
            get { return MessageType.ChangePasswordSettings; }
        }

        public string Settings { get; set; }
        //TODO ALL Settings

    }
}
