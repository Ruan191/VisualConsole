using System;
using VisualConsole.General;
using System.Media;

namespace VisualConsole.Audio
{
    class SoundPlayer
    {
        /// <summary>
        /// loads and plays .wav audio file (Only supports Windows OS)
        /// </summary>
        /// <param name="soundName">Name of the audio file</param>
        /// <param name="loop">Sould the audio play in a loop?</param>
        public void PlaySound(string soundName, bool loop)
        {
            if (OperatingSystem.IsWindows())
            {
                System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer($"{FileManager.workingDir}\\_audio\\{soundName}.wav");

                if (loop)
                    soundPlayer.PlayLooping();
                else
                    soundPlayer.Play();
            }
        }
    }
}
