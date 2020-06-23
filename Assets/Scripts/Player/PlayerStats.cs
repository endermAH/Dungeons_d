using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public GameObject levelDisplay;
    public GameObject expDisplay;
    public int maxHealth;
    public int mass;
    public int maxEnergy;
    public int level;
    public int exp;
    public int coins;

    private int _expToNextLevel;
    private Text _levelDisplayText;
    private RectTransform _rectTransform;
    private const float LevelUpFactor = 1.5f;

    private void Start()
    {
        _rectTransform = expDisplay.GetComponent<RectTransform>();
        _levelDisplayText = levelDisplay.GetComponent<UnityEngine.UI.Text>();
        UpdateExpToNextLevel();
        UpdateExpDisplay();
        levelDisplay.GetComponent<UnityEngine.UI.Text>().text = level.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            AddExp(100);
        }
    }

    public void LevelUp()
    {
        level += 1;
        _levelDisplayText.text = level.ToString();
        UpdateExpToNextLevel();
    }

    public void AddExp(int count)
    {
        exp += count;
        if (exp >= _expToNextLevel)
        {
            LevelUp();
        }

        UpdateExpDisplay();
    }

    private static int ExpDistributionFunction(int calcLevel)
    {
        return (int) Mathf.Pow(calcLevel, LevelUpFactor) * 100;
    }
    private void UpdateExpToNextLevel()
    {
        _expToNextLevel = ExpDistributionFunction(level);
    }

    private void UpdateExpDisplay()
    {
        const int expDisplayMaxWidth = 82;
        float curLevelExp = ExpDistributionFunction(level - 1);
        var newDisplayWidth = (( exp - curLevelExp) / (_expToNextLevel - curLevelExp)) * expDisplayMaxWidth;
        _rectTransform.sizeDelta = new Vector2(newDisplayWidth, 8);
        print($"{newDisplayWidth}: exp: {exp}, cur: {curLevelExp}, next: {_expToNextLevel} ++");
    }
}
