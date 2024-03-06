//Joel Campos
//2/19/2024
//Sound Server Class

using Medallion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;

namespace YGO_Card_Collector_5
{
    public static class SoundServer
    {
        public static void PlayBackgroundMusic(Song song)
        {
            if(SettingsData.MusicOn)
            {
                string filepath = "\\Music\\" + song + ".m4a";
                CurrentBackGroundPlay.Open(new Uri(Directory.GetCurrentDirectory() + filepath));
                //This event will loop the song... once the song ends it plays again
                CurrentBackGroundPlay.MediaEnded += new EventHandler(Media_Ended);
                CurrentBackGroundPlay.Play();
                CurrentBackGroundPlay.Volume = 0.3;
            }           
        }
        public static void PlayRNDBackgroundMusic()
        {
            if (SettingsData.MusicOn)
            {
                //Shuffle the playlist if this is the very first time running this function
                if(CollectorPaylistIndex == -1)
                {
                    SongsPlaylist.Shuffle();
                }

                //Move the playlist iterator 1 up or ressetit back to the beginning
                if(CollectorPaylistIndex == SongsPlaylist.Length -1)
                {
                    CollectorPaylistIndex = 0;
                    //Shuffle the playlist
                    SongsPlaylist.Shuffle();
                }
                else
                {
                    CollectorPaylistIndex++;
                }

                //Set the song to play
                string song = SongsPlaylist[CollectorPaylistIndex].ToString();               
                string filepath = "\\Music\\" + song + ".m4a";
                CurrentBackGroundPlay.Open(new Uri(Directory.GetCurrentDirectory() + filepath));

                //This event will loop the song... once the song ends it plays again
                CurrentBackGroundPlay.MediaEnded += new EventHandler(CollectorMedia_Ended);
                CurrentBackGroundPlay.Play();
                CurrentBackGroundPlay.Volume = 0.3;
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
        private static void CollectorMedia_Ended(object sender, EventArgs e)
        {
            PlayRNDBackgroundMusic();
        }

        private static MediaPlayer CurrentBackGroundPlay = new MediaPlayer();
        private static MediaPlayer Effect = new MediaPlayer();
        private static int CollectorPaylistIndex = -1;
        private static CollectorSong[] SongsPlaylist = new CollectorSong[]
        {
            CollectorSong.DeckBuildMenu,
            CollectorSong.FreeDuel,
            CollectorSong.FreeDuelMenu,
            CollectorSong.LibraryMenu
        };
    }

    public enum Song
    {
        TitleScreen,
        MainMenu,
        FreeDuelMenu,
        DeckBuildMenu,
        FreeDuel,
    }
    public enum CollectorSong
    {
        DeckBuildMenu,
        FreeDuel,
        FreeDuelMenu,
        LibraryMenu
    }
    public enum SoundEffect
    {
        Hover,
        Click,
        Click2,
        MoveCard,
        InvalidClick,
        RDSelection,
        DBLoaded,
        MarkCard,
        MarkAll
    }
}
