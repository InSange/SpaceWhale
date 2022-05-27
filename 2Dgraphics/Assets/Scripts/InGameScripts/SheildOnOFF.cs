using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheildOnOFF : MonoBehaviour
{
    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }
    void Update()
    {
        if(Player.p_instance.sheild == 1 || Player.p_instance.crystal == 0)
        {
            image.color = new Color32(85, 85, 85, 180);
        }
        else
        {
            image.color = new Color32(255, 255, 255, 180);
        }
    }
}
