using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public int food;
    public int water;
    public int wood;
    public int experience;

    public Text foodText;
    public Text waterText;
    public Text woodText;
    public Text experienceText;

    [Header("Destinations")]

    public Transform MeditationArea;
    public Transform Forest;
    public Transform River;
    public Transform VegetablesPatch;

    private void Start()
    {
        UpdateUI();
    }

    public void AddFood(int amount)
    {
        food += amount;
        UpdateUI();
    }

    public void AddWater(int amount)
    {
        water += amount;
        UpdateUI();
    }

    public void AddWood(int amount)
    {
        wood += amount;
        UpdateUI();
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        foodText.text = "Food: " + food;
        waterText.text = "Water: " + water;
        woodText.text = "Wood: " + wood;
        experienceText.text = "Experience: " + experience;
    }
}