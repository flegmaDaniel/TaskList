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
        public bool KitchenRoomWindowState { get; private set; }
        public bool LivingRoomWindowState { get; private set; }
        public bool BedRoomWindowState { get; private set; }

        /// <summary>
        /// Favorite musics
        /// </summary>
        public Dictionary<int,string> FavouriteMusic { get; } = 
            new Dictionary<int, string>{  
                {1 , "Rihanna - Diamonds" },
                {2,"Linkin Park - Numb" },
                {3, "Zámbó Jimmy - Még nem veszíthetek" } };

        /// <summary>
        /// Light intensity scales 0 to 3. 3 is the most intense
        /// </summary>
        private int LightIntensity { get; set; }

        /// <summary>
        /// Security system
        /// </summary>
        private ISecuritySystem SecuritySystem { get; set; }

        /// <summary>
        /// Is automation enabled
        /// </summary>
        private bool AutomationEnabled { get; set; }

        public SmartHome_3(ISecuritySystem securitySystem)
        {
            SecuritySystem = securitySystem;
            SecuritySystem.SomeOneAtTheDoor += DoSmartThingsOnPersonArrival;
            AutomationEnabled  = true;
        }

        /// <summary>
        /// Event handler method for the SomeOneAtTheDoor event
        /// </summary>
        /// <param name="obj">Object</param>
        /// <param name="args">Arguments</param>
        public void DoSmartThingsOnPersonArrival(object? obj, DoorVisitor args)
        {
            if (!AutomationEnabled)
            {
                return;
            }

            if (SecuritySystem.HasAccessToTheHouse(args.VisitorId))
            {
                try
                {
                    //Start music on arrival
                    // The client auth token should be retrieved from the appsettings.json file
                    MagicMusicBox musicBox = new MagicMusicBox("asdas213%w3123+__SpeakerAuthToken__3(%16dsf7+563+35gfd");

                    string name = FavouriteMusic[args.VisitorId];
                    musicBox.PlayMusicByName(name);
                }
                catch (Exception)
                {

                    throw;
                }

                //This section opens the windows
                OpenWindows();

                //Turn up the lights if necessary
                TurnUpLights();
            }
            else
            {
                SecuritySystem.LeaveMessageOnDoorBell("You are not allowed to entry! - (unauthorized)");
            }
        }

        /// <summary>
        /// Turns up the lights if necessary
        /// </summary>
        private void TurnUpLights()
        {
            if (DateTime.Now.Hour > 18 || DateTime.Now.Hour < 6)
            {
                //It's enough to set intensity to 2 when it's dark outside.
                LightIntensity = 2;
            }
            else
            {
                //if it's not night, no needs for lamps
                LightIntensity = 0;
            }
        }

        /// <summary>
        /// Opens the windows
        /// </summary>
        private void OpenWindows()
        {
            KitchenRoomWindowState = true;
            LivingRoomWindowState = true;
            LivingRoomWindowState = true;
        }
    }

    #endregion
}
