using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] float aliveTime = 3.0f;

    private void Awake() => Destroy(gameObject, aliveTime);
}
