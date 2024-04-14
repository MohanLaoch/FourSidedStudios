using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savetesting : MonoBehaviour, IDataPersistence
{
    public int testing;

    public void LoadData(GameData data)
    {
        this.testing = data.testing;

    }
    public void SaveData(ref GameData data)
    {
        data.testing = this.testing;
    }




}
