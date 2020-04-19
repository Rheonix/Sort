using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWebPage : MonoBehaviour {

    public void OpenAfroDuckWebPage ()
    {
        Application.OpenURL("https://www.afroduckstudios.com");
        GameControl.control.hasVisitedAfroduck = true;
        GameControl.control.Save();
    }

    public void OpenAPP_InstagramPage ()
    {
        Application.OpenURL("instagram://user?username=afroduckstudios");
        GameControl.control.hasVisitedInstagram = true;
        GameControl.control.Save();
    }

    public void OpenAPP_TwitterPage()
    {
        Application.OpenURL("twitter:///user?screen_name=AfroDuckStudios");
        //GameControl.control.hasVisitedInstagram = true;
        //GameControl.control.Save();
    }

    public void OpenFBpage ()
    {
        Application.OpenURL("https://www.facebook.com/afroduckstudios/");
        GameControl.control.hasVisitedFacebook = true;
        GameControl.control.Save();
    }
    
}
