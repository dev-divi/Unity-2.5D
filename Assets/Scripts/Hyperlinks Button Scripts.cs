using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperlinksButtonScripts : MonoBehaviour
{
    void OpenDimensions()
    {
        Application.OpenURL("https://www.figma.com/file/8ymi3ZR3yTO7az9pxrZNaz/Divi's-Life----In-the-21st-Century?type=design&node-id=0%3A1&mode=design&t=94yPLMIA3XCO6Hfm-1");
    }

    void OpenURL(string link)
    {
        Application.OpenURL(link);
    }
}
