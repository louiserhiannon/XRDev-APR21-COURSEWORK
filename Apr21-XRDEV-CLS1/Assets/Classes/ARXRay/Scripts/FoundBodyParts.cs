using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoundBodyParts : MonoBehaviour
{
    public Image brainImage;
    public Image leftLungImage;
    public Image rightLungImage;
    public Image heartImage;
    public Image stomageImage;
    public Image bladderImage;
    public Image leftKinneyImage;
    public Image rightKidneyImage;

    public void OnBrainFound()
    {
        brainImage.color = new Color(1, 1, 1, 1);
    }

    public void OnLeftLungFound()
    {
        leftLungImage.color = new Color(1, 1, 1, 1);
    }

    public void OnRightLungFound()
    {
        rightLungImage.color = new Color(1, 1, 1, 1);
    }

    public void OnHeartFound()
    {
        heartImage.color = new Color(1, 1, 1, 1);
    }

    public void OnStomachFound()
    {
        stomageImage.color = new Color(1, 1, 1, 1);
    }

    public void OnBladderFound()
    {
        bladderImage.color = new Color(1, 1, 1, 1);
    }

    public void OnLeftKidneyFound()
    {
        leftKinneyImage.color = new Color(1, 1, 1, 1);
    }
    public void OnRightKidneyFound()
    {
        rightKidneyImage.color = new Color(1, 1, 1, 1);
    }
}
