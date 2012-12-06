using System;
using System.Collections;
using System.Threading;
using Gadgeteer.Modules.GHIElectronics;
using Gadgeteer.Networking;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Touch;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using GHI.Premium.System;

namespace GadgeteerApp1
{
    public partial class Program
    {
        GT.Picture lastPicture;

        void ProgramStarted()
        {
            multicolorLed.RemoveBlue();
            multicolorLed.RemoveGreen();
            multicolorLed.RemoveRed();
            multicolorLed.TurnRed();
            button.ButtonPressed += new Button.ButtonEventHandler(button_ButtonPressed);
            camera.CameraConnected += new Camera.CameraConnectedEventHandler(camera_CameraConnected);
            camera.PictureCaptured +=new Camera.PictureCapturedEventHandler(camera_PictureCaptured);
            sdCard.SDCardMounted += new SDCard.SDCardMountedEventHandler(sdCard_SDCardMounted);
            Debug.Print("Programme started");
        }

        void sdCard_SDCardMounted(SDCard sender, GT.StorageDevice SDCard)
        {
            sdCard.MountSDCard();
            if (sdCard.IsCardMounted)
            {
                Debug.Print("SD card is mounted");
                Thread.Sleep(2000);
            }
            else {
                Debug.Print("Problem with sd card");
            }
        }

        void  camera_PictureCaptured(Camera sender, GT.Picture picture)
        {
            Debug.Print("camera_PictureCaptured method entered");
 	        camera.TakePicture();
            lastPicture = picture;
        }

        void camera_CameraConnected(Camera sender)
        {
            Debug.Print("camera_CameraConnected method entered");
            camera.TakePicture();
        }


        void button_ButtonPressed(Button sender, Button.ButtonState state)
        {
            if (lastPicture == null) { Debug.Print("error, there is no image."); }
            else
            {
                String filename = "Testing.bmp";
                GT.StorageDevice storage = sdCard.GetStorageDevice();
                Debug.Print("String name allocated");
                try
                {
                    Debug.Print("Entering try and catch block");
                    if (!sdCard.IsCardInserted) { Debug.Print("insert sd card"); }
                    else
                    {
                        Debug.Print("Found storage device");
                        storage.WriteFile(filename, lastPicture.PictureData);
                        Debug.Print("save successful!");
                    }
                }
                catch (Exception ex)
                {
                    Debug.Print("error saving");
                }
            
            }
        }
    }
}
