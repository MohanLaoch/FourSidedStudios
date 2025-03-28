
using UnityEngine;


  [CreateAssetMenu(fileName = "SceneInfo", menuName = "Persistence")]
public class SceneInfo : ScriptableObject 
{
    public bool isNextScene = true;
    public float money = 0;
    public int dayCount;
    public float playerSpeed;
    public float playerRotSpeed;
    public float playerAcceleration;
    public float playerMaxThrowForce;
    public int ElectricityBills = 5;
    public int WaterBills = 5;
    public int TotalInjuryCounter;
    public bool DashUnlocked = false;
    public bool instaStockUnlocked = false;
    public bool gumballMachineUnlocked = false;
    public bool roboMopUnlocked = false;
    public int storageMax = 5;
    public int SkinCounter = 1;

    public float masterVolume = 1;
    public float musicVolume = 1;
    public float ambienceVolume = 1;
    public float SFXVolume = 1;

    [Header("Coffee Unlocks")]
    public bool ChaiLatteUnlocked;
    public bool HotChocolateUnlocked;
    public bool IcedCoffeeUnlocked;
    public bool IcedLatteUnlocked;
    public bool MochaUnlocked;
    public bool TeaUnlocked;


    [Header("Skin Unlocks")]
    public int SpillsCleaned = 0;
    public int OrdersCompleted = 0;
    public bool GoodEndingAchieved = false;
    public bool BadEndingAchieved = false;
    public bool PrisonEndingAchieved = false;
    public bool AllAchievementsUnlocked = false;

    public bool hasRun1 = false;
    public bool hasRun2 = false;
    public bool hasRun3 = false;
    public bool hasRun4 = false;
    public bool hasRun5 = false;

    [Header("Controller")]
    public bool ControllerConnected = false;




    public void Reset()
    {
        money = 0;
        dayCount = 1;
        playerSpeed = 200;
        playerRotSpeed = 200;
        playerAcceleration = 10;
        playerMaxThrowForce = 10;
        DashUnlocked = false;
        instaStockUnlocked = false;
        gumballMachineUnlocked = false;
        roboMopUnlocked = false;
        storageMax = 5;
        ElectricityBills = 5;
        WaterBills = 5 ;

        ChaiLatteUnlocked = false;
        HotChocolateUnlocked = false;
        IcedCoffeeUnlocked = false;
        IcedLatteUnlocked = false;
        MochaUnlocked = false;
        TeaUnlocked = false;

        masterVolume = 1;
        musicVolume = 1;
        ambienceVolume = 1;
        SFXVolume = 1;

    }

    public void ResetAchievements()
    {
      SpillsCleaned = 0;
      OrdersCompleted = 0;
      GoodEndingAchieved = false;
      BadEndingAchieved = false;
      PrisonEndingAchieved = false;
      AllAchievementsUnlocked = false;

      hasRun1 = false;
      hasRun2 = false;
      hasRun3 = false;
      hasRun4 = false;
      hasRun5 = false;
    }
    

}



