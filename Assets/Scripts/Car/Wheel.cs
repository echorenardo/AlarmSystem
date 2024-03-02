using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public void Rotate(float speed) => transform.Rotate(Vector3.right * speed * Time.deltaTime);
}
