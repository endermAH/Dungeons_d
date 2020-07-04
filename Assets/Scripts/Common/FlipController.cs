using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipController : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        var mouseX = Input.mousePosition.x;
        var selfX = transform.position.x * 100;
        var cameraX = camera.transform.position.x * 100;
        float cameraWidth = camera.pixelWidth;
        var absoluteMouseX = cameraX - (cameraWidth / 2) + mouseX;
        if (absoluteMouseX < selfX){
            _renderer.flipX = true;
        }
        if (absoluteMouseX > selfX){
            _renderer.flipX = false;
        }
    }
}
