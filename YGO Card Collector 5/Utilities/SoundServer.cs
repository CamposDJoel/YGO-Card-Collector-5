//Joel Campos
//2/19/2024
//Sound Server Class

using System;
using System.IO;
using System.Windows.Media;

namespace YGO_Card_Collector_5
{
    public static class SoundServer
    {
        public static void PlayBackgroundMusic(Song song, bool TurnOn)
        {
            if(SettingsData.MusicOn)
            {
                if (TurnOn)
                {
                    string filepath = "\\Music\\" + song + ".m4a";
                    CurrentBackGroundPlay.Open(new Uri(Directory.GetCurrentDirectory() + filepath));
                    //This event will loop the song... once the song ends it plays again
                    CurrentBackGroundPlay.MediaEnded += new EventHandler(Media_Ended);
                    CurrentBackGroundPlay.Play();
                    CurrentBackGroundPlay.Volume = 0.3;
                }
                else
                {
                    CurrentBackGroundPlay.Stop();
                }
            }           
        }
        public static void StopBackgroundMusic() 
        {
            CurrentBackGroundPlay.Stop();
        }
        public static void PlaySoundEffect(SoundEffect sound)
        {
            if(SettingsData.SFXOn)
            {
                string filepath = "\\Music\\" + sound + ".wav";
                Effect.Open(new Uri(Directory.GetCurrentDirectory() + filepath));
                Effect.Play();
                Effect.Volume = 0.8;
            }            
        }

        private static void Media_Ended(object sender, EventArgs e)
        {
            CurrentBackGroundPlay.Position = TimeSpan.Zero;
            CurrentBackGroundPlay.Play();
        }

        private static MediaPlayer CurrentBackGroundPlay = new MediaPlayer();
        private static MediaPlayer Effect = new MediaPlayer();
    }

    public enum Song
    {
        TitleScreen,
        MainMenu,
        FreeDuelMenu,
        DeckBuildMenu,
        FreeDuel,
        YouWin,
        YouLose,
    }
    public enum SoundEffect
    {
        Hover,
        Click,
        Click2,
        MoveCard,
        InvalidClick,
        RDSelection,
        DBLoaded
    }
}
