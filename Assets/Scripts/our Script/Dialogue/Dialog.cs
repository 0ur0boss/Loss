using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public List<DialogPage> m_dialogWithPlayer;
   
    public List<DialogPage> GetDialog()
    {
        Debug.Log("1");
        return m_dialogWithPlayer;
    }
}
