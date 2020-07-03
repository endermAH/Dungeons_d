using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private GameObject levelDisplay;
        [SerializeField] private Slider expDisplay;
        
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
            _levelDisplayText = levelDisplay.GetComponent<Text>();
            UpdateExpToNextLevel();
            UpdateExpDisplay();
            
            levelDisplay.GetComponent<Text>().text = level.ToString();
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                AddExp(10);
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
            float curLevelExp = ExpDistributionFunction(level - 1);
            var newDisplayWidth = ((exp - curLevelExp) / (_expToNextLevel - curLevelExp));
            expDisplay.value = newDisplayWidth;
            print($"{newDisplayWidth}: exp: {exp}, cur: {curLevelExp}, next: {_expToNextLevel} ++");
        }
    }
}
