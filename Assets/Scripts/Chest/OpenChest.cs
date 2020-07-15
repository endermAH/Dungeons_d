using UnityEngine;
using Random = System.Random;

public class OpenChest : MonoBehaviour
{
    public GameObject player;
    public GameObject highlighter;
    private GameObject _thisHighlighter;
    private Transform _chestTransform;
    private Animator _chestAnimator;
    private double _distanceToChest;
    private static readonly int Open = Animator.StringToHash("Open");
    [SerializeField]
    private float openDistance = 0.24f;
    private string[] _things;
    private readonly string[] _thingsList = {"Coins", "Weapon", "Poition"};

    private void Start()
    {
        _chestTransform = GetComponent<Transform>();
        _chestAnimator = GetComponent<Animator>();
        _things = GenerateChestContains(3);
        print("OpenChest module initialized\nPlayer: " + player.transform.name);
    }

    private void Update()
    {
        CheckOpen();
        HighlightChest();
        _distanceToChest = GetDistanceToChest();
    }

    private static double GetDistance(float x1,float y1, float x2, float y2)
    {
        var deltaX = x1 - x2;;
        var deltaY = y1 - y2;
        var dist = Mathf.Sqrt(Mathf.Pow(deltaX, 2) + Mathf.Pow(deltaY, 2));
        return dist;
    }

    private double GetDistanceToChest()
    {
        var playerPosition = player.transform.position;
        var chestPosition = _chestTransform.position;
        var distanceToChest = GetDistance(
            playerPosition.x,
            playerPosition.y,
            chestPosition.x,
            chestPosition.y);
        return distanceToChest;
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

    private void CheckOpen()
    {
        if (!Input.GetKeyUp(KeyCode.Return)) return;
        if (!(_distanceToChest < openDistance)) return;
        
        _chestAnimator.SetBool(Open, true);
        print($"Opened! There is: {string.Join(", ", _things)}");
    }

    private void HighlightChest()
    {
        var isOpen = _chestAnimator.GetBool(Open);
        if (isOpen)
        {
            if (_thisHighlighter)
                Destroy(_thisHighlighter);
            return;
        }
        
        if (_distanceToChest < openDistance)
        {
            var position = _chestTransform.position;
            var chestX = position.x;
            var chestY = position.y;
            if (!_thisHighlighter)
                _thisHighlighter = Instantiate(highlighter, new Vector3(chestX,chestY, 0), Quaternion.identity);
        }
        else
        {
            if (_thisHighlighter)
                Destroy(_thisHighlighter);
        }

    }
}
