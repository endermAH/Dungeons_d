using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class OpenChest : MonoBehaviour
{
    public GameObject player;
    private Transform _chestTransform;
    private Animator _chestAnimator;
    private static readonly int Open = Animator.StringToHash("Open");
    private string[] _things;
    private readonly string[] _thingsList = new string[] {"Coins", "Weapon", "Poition"};

    private void Start()
    {
        _chestTransform = GetComponent<Transform>();
        _chestAnimator = GetComponent<Animator>();
        _things = GenerateChestContains(5);
        print("OpenChest module initialized\nPlayer: " + player.transform.name);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            var playerPosition = player.transform.position;
            var chestPosition = _chestTransform.position;
            var distanceToChest = GetDistance(
                playerPosition.x,
                playerPosition.y,
                chestPosition.x,
                chestPosition.y);
            print("Distance to chest: " + distanceToChest);
            if (distanceToChest < 0.24)
            {
                _chestAnimator.SetBool(Open, true);
                print($"Opened! There is: {string.Join(", ", _things)}");
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        print("Collision");
    }

    private static double GetDistance(float x1,float y1, float x2, float y2)
    {
        var deltaX = x1 - x2;;
        var deltaY = y1 - y2;
        var dist = Mathf.Sqrt(Mathf.Pow(deltaX, 2) + Mathf.Pow(deltaY, 2));
        return dist;
    }

    private string[] GenerateChestContains(int maxThings)
    {
        var rng = new Random();
        var contains = new string[maxThings];
        for (var i = 0; i < maxThings; i++)
        {
            var item = _thingsList[rng.Next(0,_thingsList.Length)];
            contains[i] = item;
        }
        return contains;
    }
}
