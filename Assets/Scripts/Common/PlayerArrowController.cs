using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrowController : MonoBehaviour
{
    public GameObject player;
    private Transform _transform;
    
    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        var diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
 
        var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        var intRotZ = (int) (rotZ / 45) * 45;
        _transform.rotation = Quaternion.Euler(0f, 0f, intRotZ - 90);
    }
}
