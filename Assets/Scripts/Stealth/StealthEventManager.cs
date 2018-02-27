using UnityEngine;
using System.Collections;

public class StealthEventManager : MonoBehaviour
{
    public delegate IEnumerator StealthEventMessageTemplate(/*StealthEvent event*/);
    public static event StealthEventMessageTemplate OnGenerateStealthEvent;


    //StealthEvent is declared as a nested type so that it has access to call OnStealthEvent
    public struct StealthEvent
    {
        public float loudness;
        public Vector3 location;

        //StealthEvent's constructor calls OnGenerateStealthEvent
        public StealthEvent(float loudness, Vector3 location)
        {
            this.loudness = loudness;
            this.location = location;
            if (OnGenerateStealthEvent != null)
            {
                OnGenerateStealthEvent();
            }
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "Click"))
        {
            if (OnGenerateStealthEvent != null)
                OnGenerateStealthEvent();
        }
    }
}
