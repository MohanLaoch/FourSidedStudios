
using UnityEngine;


  [CreateAssetMenu(fileName = "SceneInfo", menuName = "Persistence")]
public class SceneInfo : ScriptableObject {
    public bool isNextScene = true;
    public float money = 0;
    public int dayCount = 1;
    public float playerSpeed;
    public float playerRotSpeed;
    public float playerAcceleration;
    public float playerMaxThrowForce;
    public int ElectricityBills = 10;
    public int WaterBills = 10;
    public int TotalInjuryCounter;
    public bool DashUnlocked = false;
    public bool instaStockUnlocked = false;
    public bool gumballMachineUnlocked = false;
    public int storageMax = 5;
    public int SkinCounter = 1;


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
        storageMax = 5;
        ElectricityBills = 10;
        WaterBills = 10;

    }

    

}



