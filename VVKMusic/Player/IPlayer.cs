﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace Player
{
    interface IPlayer
    {
        int Play(string linkToSong);
        int AdjustSound(SoundSettings settings);
    }
}