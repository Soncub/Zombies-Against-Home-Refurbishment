using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightiningScript : MonoBehaviour
{
    public GameObject lightningOne;
    public GameObject lightningTwo;
    public GameObject lightningThree;
    public GameObject audioOne;


    private void start()
    {
        lightningOne.SetActive(false);
        lightningTwo.SetActive(false);
        lightningThree.SetActive(false);

        audioOne.SetActive(false);

        Invoke("CallLightning", 1.75f);
    }

    void CallLightning()
    {
        int r = Random.Range(0, 3);
        if(r==0)
        {
            lightningOne.SetActive(true);
            Invoke("EndLightning", .125f);
            Invoke("CallThunder", .395f);
        }
        else if (r==1)
        {
            lightningTwo.SetActive(true);
            Invoke("EndLightning", .105f);
            Invoke("CallThunder", .195f);
        }
        else
        {
            lightningThree.SetActive(true);
            Invoke("EndLightning", .75f);
            CallThunder();
        }
 
    }

    void EndLightning()
    {
        lightningOne.SetActive(false);
        lightningTwo.SetActive(false);
        lightningThree.SetActive(false);

        float rand = Random.Range(30f, 40f);
        Invoke("CallLightning", rand);
    }

    void CallThunder()
    {
        audioOne.SetActive(true);
        Invoke("EndThunder", 29f);
    }

    void EndThunder()
    {
        audioOne.SetActive(false);
    }
}
