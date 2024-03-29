﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Gadgeteer Designer.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Gadgeteer;
using GTM = Gadgeteer.Modules;

namespace GadgeteerApp1
{
    public partial class Program : Gadgeteer.Program
    {
        // GTM.Module definitions
        Gadgeteer.Modules.GHIElectronics.Button button;
        Gadgeteer.Modules.GHIElectronics.MulticolorLed multicolorLed;
        Gadgeteer.Modules.GHIElectronics.Camera camera;
        Gadgeteer.Modules.GHIElectronics.SDCard sdCard;
        Gadgeteer.Modules.GHIElectronics.WiFi_RS21 wifi_RS21;

        public static void Main()
        {
            //Important to initialize the Mainboard first
            Mainboard = new GHIElectronics.Gadgeteer.FEZSpider();			

            Program program = new Program();
            program.InitializeModules();
            program.ProgramStarted();
            program.Run(); // Starts Dispatcher
        }

        private void InitializeModules()
        {   
            // Initialize GTM.Modules and event handlers here.		
            camera = new GTM.GHIElectronics.Camera(3);
		
            button = new GTM.GHIElectronics.Button(4);
		
            sdCard = new GTM.GHIElectronics.SDCard(5);
		
            multicolorLed = new GTM.GHIElectronics.MulticolorLed(6);
		
            wifi_RS21 = new GTM.GHIElectronics.WiFi_RS21(9);

        }
    }
}
