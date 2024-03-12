//Joel Campos
//3/12/2024
//ImageServer Class

using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace YGO_Card_Collector_5
{
    public static class ImageServer
    {
        public static void SetImage(PictureBox box, ImageType type, string parameter)
        {
            //if the picture box already contains an image, dispose it to free memory
            if (box.Image != null) 
            { 
                box.Image.Dispose();
            }

            //Call the respective image type
            switch(type) 
            {
                case ImageType.CardImage: box.Image = CardImage(parameter); break;
                case ImageType.CardBack: box.Image = CardBack(); break;
                case ImageType.Rarity: box.Image = Rarity(parameter); break;
                case ImageType.CheckMark: box.Image = CheckMark(); break;
                case ImageType.StarIcon: box.Image = StarIcon(); break;
                case ImageType.ExclamationMark: box.Image = ExclamationMark(); break;
                case ImageType.TagIcon: box.Image = TagIcon(parameter); break;
                case ImageType.MuteButtonIcon: box.Image = MuteButttonIcon(parameter); break;
            }
        }

        public static void SetBackgroundImage(Form thisForm)
        {
            thisForm.BackgroundImage.Dispose();
            string folder = SettingsData.CurrentTheme.ToString();         
            thisForm.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + "\\Themes\\" + folder + "\\Background.jpg");
        }
        private static Image CardImage(string id)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "\\images\\Cards\\" + id + ".jpg"))
            {
                return Image.FromFile(Directory.GetCurrentDirectory() + "\\images\\Cards\\" + id + ".jpg");
            }
            else
            {
                return Image.FromFile(Directory.GetCurrentDirectory() + "\\images\\Cards\\MissingCard.png");
            }
        }
        private static Image CardBack()
        {
            return Image.FromFile(Directory.GetCurrentDirectory() + "\\images\\cards\\Card Back.png");
        }
        private static Image Rarity(string rarity)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "\\images\\Rarities\\" + rarity + ".jpg"))
            {
                return Image.FromFile(Directory.GetCurrentDirectory() + "\\images\\Rarities\\" + rarity + ".jpg");
            }
            else
            {
                return Image.FromFile(Directory.GetCurrentDirectory() + "\\images\\Rarities\\Unknown Rarity.png");
            }
        }
        private static Image CheckMark()
        {
            return Image.FromFile(Directory.GetCurrentDirectory() + "\\images\\Icons\\Checkmark.jpg");
        }
        private static Image StarIcon()
        {
            return Image.FromFile(Directory.GetCurrentDirectory() + "\\images\\Icons\\StarMark.png");
        }
        private static Image ExclamationMark()
        {
            return Image.FromFile(Directory.GetCurrentDirectory() + "\\Images\\Icons\\exlamimark.png");
        }
        private static Image TagIcon(string icon)
        {
            return Image.FromFile(Directory.GetCurrentDirectory() + "\\Images\\Icons\\"+ icon  +".png");
        }
        private static Image MuteButttonIcon(string ONOFF)
        {
            return Image.FromFile(Directory.GetCurrentDirectory() + "\\Images\\Icons\\Music" + ONOFF + ".png");
        }
    }

    public enum ImageType
    {
        CardImage,
        CardBack,
        Rarity,
        CheckMark,
        StarIcon,
        ExclamationMark,
        TagIcon,
        MuteButtonIcon,
    }
}
