﻿using System.Windows.Media;
using Un4seen.Bass;
using Un4seen.Bass.Misc;
using Un4seen.Bass.AddOn.Wma;
using System;
using Status = Common.Common.Status;

namespace Player
{
    public class Player : IPlayer
    {
        private int stream;

        public Player()
        {
            BassNet.Registration("xxxddr3@gmail.com", "2X441017152222");
            if(!(Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero)))
            {
                throw new Exception();
            }
        }
        public Status SetSource(Uri source, bool downloaded)
        {
            if (downloaded)
            {
                stream = Bass.BASS_StreamCreateFile(source.LocalPath, 0, 0, BASSFlag.BASS_DEFAULT);
            }
            else
            {
                stream = Bass.BASS_StreamCreateURL(source.ToString(), 0, 0, null, new IntPtr(0));
            }
            if (stream != 0)
            {
                return Status.OK;
            }
            else
            {
                return Status.Error;
            }
        }
        public Status Play()
        {
            if(Bass.BASS_ChannelPlay(stream, false))
            {
                return Status.OK;
            }
            else
            {
                return Status.Error;
            }
        }
        public Status Stop()
        {
            if (Bass.BASS_ChannelStop(stream))
            {
                return Status.OK;
            }
            else
            {
                return Status.Error;
            }
        }
        public Status Pause()
        {
            if (Bass.BASS_ChannelPause(stream))
            {
                return Status.OK;
            }
            else
            {
                return Status.Error;
            }
        }
        public Status AdjustSound()
        {
            return Status.OK;
        }
        ~Player()
        {
            Bass.BASS_StreamFree(stream);
            Bass.BASS_Free();
        }
    }
}