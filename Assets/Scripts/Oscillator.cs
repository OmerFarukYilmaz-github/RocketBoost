using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;

    Vector3 startingPosition;
    float movementFactor;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon) { return; } //period == 0 period float oldugu icin saglikli bir kiyaslama olmaz
                                                // o yuzden en kucuk float sayý Mathf.Epsilon ile kýyasla

        float cycles = Time.time / period; // zamanla surekli buyuyecek

        const float tau = Mathf.PI * 2; // pi * 2  6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // -1 ile 1 arasýnda olacak

        movementFactor = (rawSinWave + 1f) / 2f; //0 ile 1 arasýnda olsun diye

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
