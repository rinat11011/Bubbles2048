using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    public Sprite mutePNG;
    public Sprite unmutePNG;
    private Sprite srcImage;
    //private Image image; 
    public bool muted = false;

    public void start()
    {
        srcImage = gameObject.GetComponent<Image>().sprite;

        srcImage = unmutePNG;
        //GetComponent<Image>().sprite = unmutePNG;
    }

    public void MuteButton()
    {
        if (muted)
        {
            // TODO : mute music
            srcImage = unmutePNG;
            
        }
        else
        {
            srcImage = mutePNG;
            //image.sprite = mutePNG;
        }
        this.gameObject.GetComponent<Image>().sprite = srcImage; 
        muted = !muted;
    }
}
