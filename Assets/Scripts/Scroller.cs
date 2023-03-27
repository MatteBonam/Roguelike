using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float x, y;
    void Update()
    {
        transform.Rotate(x, y, 0, Space.Self);
    }
}
