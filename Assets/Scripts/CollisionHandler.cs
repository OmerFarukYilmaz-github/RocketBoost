using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("friendly");
                // do staff
                break;

            case "Finish":
                Debug.Log("finish");
                // do staff
                break;

            case "Fuel":
                Debug.Log("fuel");
                // do staff
                break;

            default:
                Debug.Log("blow up!!");
                break;
        }
    }
}
