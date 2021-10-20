using System;
using System.Collections.Generic;
using VisualConsole.General;
using System.Media;

namespace VisualConsole.Audio
{
    class SoundPlayer
    {
        Dictionary<string, System.Media.SoundPlayer> sounds = new Dictionary<string, System.Media.SoundPlayer>();

        /// <summary>
        /// loads and plays .wav audio file (Only supports Windows OS)
        /// </summary>
        /// <param name="soundName">Name of the audio file</param>
        /// <param name="loop">Sould the audio play in a loop?</param>
        public void PlaySound(string soundName, bool loop)
        {
            if (OperatingSystem.IsWindows())
            {
                System.Media.SoundPlayer soundPlayer;

                if (!sounds.ContainsKey(soundName))
                {
                    Debug.Error($"Error: Make sure to load the sound called '{soundName}' before you play it or that is exists");
                    return;
                }
                soundPlayer = sounds[soundName];

                if (loop)
                    soundPlayer.PlayLooping();
                else
                    soundPlayer.Play();
            }
        }

        public void LoadSound(string soundName)
        {
            if (OperatingSystem.IsWindows())
            {
                System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer($"{FileManager.workingDir}\\_audio\\{soundName}.wav");
                soundPlayer.Load();
                sounds.Add(soundName, soundPlayer);
            }
        }
    }
}
