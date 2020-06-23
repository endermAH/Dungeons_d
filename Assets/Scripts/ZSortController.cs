using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZSortController : MonoBehaviour
{
    public GameObject player;

    private SpriteRenderer _renderer;
    private Transform _transform;
    private int _workXDistance;
    private int _workYDistance;
    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _transform = GetComponent<Transform>();
        var size = _renderer.bounds.size;
        _workXDistance = (int) (size.x * 100);
        _workYDistance = (int) (size.y * 100);
    }

    private void Update()
    {
        var positionSelf = _transform.position;
        var positionPlayer = player.transform.position;
        var distanceX = Mathf.Abs(positionPlayer.x - positionSelf.x);
        var distanceY = Mathf.Abs(f: positionPlayer.y - positionSelf.y);
        if (distanceX > _workXDistance || distanceY > _workYDistance) return;
        
        if (positionPlayer.y < positionSelf.y)
        {
            if (positionSelf.z == -1) return;
            _transform.Translate(0,0,2);
        }
        else
        {
            if (positionSelf.z == -3) return;
            _transform.Translate(0,0, -2);
        }
    }
}
