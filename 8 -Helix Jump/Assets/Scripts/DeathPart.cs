using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPart : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Renderer>().material.color = Color.HSVToRGB(0.1f, 0.5f, 0.4f);
    }

    public void HitDeathPart()
    {
        GameManager.singleton.RestartLevel();
    }
}
