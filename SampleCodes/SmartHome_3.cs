using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    #region Questions

    //What do we call code smells?
    //What properties a "good" code have?

    #endregion

    #region Questions by example


    #endregion

    public class SmartHome_3
    {
        /// <summary>
        /// If the windows state is true, the window is open.
        /// </summary>
        public bool KitchenRoomWindowState { get; set; }
        public bool LivingRoomWindowState { get; set; }
        public bool BedRoomWindowState { get; set; }

        private List<string> music { get; } = new List<string>{ "", "", "" };

        /// <summary>
        /// Light intensity scales 0 to 3. 3 is the most intense
        /// </summary>
        public int i_LightIntensity { get; set; }


        public void DoSmartThings(int music)
        {
            //This section opens the windows
            KitchenRoomWindowState = true;
            LivingRoomWindowState = true;
            LivingRoomWindowState = true;
            //
            

            if (DateTime.Now.Hour > 18 || DateTime.Now.Hour < 6)
            {
                //It's enough to set intensity to 2 when it's dark outside.
                i_LightIntensity = 2;
            }
            else
            {
                i_LightIntensity = 0; //if it's not night, no needs for lamps
            }

            MagicMusicBox musicBox = new MagicMusicBox();

            string mName = this.music[music];
            musicBox.PlayMusicByName(mName);




        }


        public class MagicMusicBox
        {
            public void PlayMusicByName(string musicName)
            {
                //.. left for imagination
            }
        }
    }
}
