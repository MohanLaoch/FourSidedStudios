
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

    [Header("Coffee Unlocks")]
    public bool ChaiLatteUnlocked;
    public bool HotChocolateUnlocked;
    public bool IcedCoffeeUnlocked;
    public bool IcedLatteUnlocked;
    public bool MochaUnlocked;
    public bool TeaUnlocked;




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

    }

    

}



