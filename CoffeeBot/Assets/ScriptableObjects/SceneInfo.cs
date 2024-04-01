
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

    public int SkinCounter = 1;


    public void Reset()
    {
        money = 0;
        dayCount = 1;
        playerSpeed = 200;
        playerRotSpeed = 200;
        playerAcceleration = 10;
        playerMaxThrowForce = 10;
        ElectricityBills = 10;
        WaterBills = 10;

    }

    

}



