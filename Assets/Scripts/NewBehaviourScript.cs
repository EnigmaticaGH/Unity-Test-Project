using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        foreach (Ability a in GetComponents<Ability>())
        {
            Debug.Log(a.Name);
        }
    }
}
