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
    //OOP basis
    //Have you heard of SOLID?

    #endregion

    #region Questions by example

    /// <summary>
    /// This class meant to fully control the house if enabled
    /// </summary>
    public class SmartHome_3
    {
        /// <summary>
        /// If the windows state is true, the window is open.
        /// </summary>
        public bool KitchenRoomWindowState { get; set; }
        public bool LivingRoomWindowState { get; set; }
        public bool BedRoomWindowState { get; set; }

        public Dictionary<int,string> favouriteMusic { get; } = new Dictionary<int, string>{  {1 , "Rihanna - Diamonds" },
                                                                                              {2,"Linkin Park - Numb" },
                                                                                              {3, "Zámbó Jimmy - Még nem veszíthetek" } };

        /// <summary>
        /// Light intensity scales 0 to 3. 3 is the most intense
        /// </summary>
        private int i_LightIntensity { get; set; }

        public ISecuritySystem SecuritySystem { get; set; }

        public bool AutomationEnabled { get; set; }


        public SmartHome_3(ISecuritySystem securitySystem)
        {
            SecuritySystem = securitySystem;
            SecuritySystem.SomeOneAtTheDoor += DoSmartThingsOnPersonArrival;
            AutomationEnabled  = true;
        }


        public void DoSmartThingsOnPersonArrival(object? obj, DoorVisitor args)
        {
            if(AutomationEnabled == true)
            {
                if (SecuritySystem.HasAccessToTheHouse(args.VisitorId))
                {
                    //Start music on arrival!
                    MagicMusicBox musicBox = new MagicMusicBox("asdas213%w3123+__SpeakerAuthToken__3(%16dsf7+563+35gfd");

                    string mName = favouriteMusic[args.VisitorId];
                    musicBox.PlayMusicByName(mName);
                    //

                    //This section opens the windows
                    KitchenRoomWindowState = true;
                    LivingRoomWindowState = true;
                    LivingRoomWindowState = true;
                    //

                    //Turn up the lights if necessary
                    if (DateTime.Now.Hour > 18 || DateTime.Now.Hour < 6)
                    {
                        //It's enough to set intensity to 2 when it's dark outside.
                        i_LightIntensity = 2;
                    }
                    else
                    {
                        i_LightIntensity = 0; //if it's not night, no needs for lamps
                    }
                }
                else
                {
                    SecuritySystem.LeaveMessageOnDoorBell("You are not allowed to entry! - (unauthorized)");
                }
            }
        }

    }

    #endregion
}
