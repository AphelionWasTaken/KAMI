﻿using KAMI.Games;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAMI
{
    public static class GameManager
    {
        public static IGame GetGame(IntPtr ipc, string id)
        {
            switch (id)
            {

                case "BCES00052": return new RatchetToD(ipc);
                case "BCES01503": return new Ratchet3PS3(ipc);
                case "BCES01743": return new Killzone1PS3(ipc);
                case "[SCUS-97353]": return new Ratchet3PS2(ipc);
                default:
                    throw new NotImplementedException($"Game with id {id} not implemented");
            }
        }
    }
}