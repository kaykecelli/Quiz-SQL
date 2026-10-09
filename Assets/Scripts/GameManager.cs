using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private EnemyData enemyData;
    [SerializeField]private string playerSaveFileName = "Player_Save";
    [SerializeField] private string enemySaveFileName = "Enemy_Save";
    private void Awake()
    {
    }
    public void SavePlayerData()
    {
        SaveSystem.SaveData(playerData, playerSaveFileName);
    }

    public void LoadPlayerData()
    {
        playerData = SaveSystem.LoadData<PlayerData>(playerSaveFileName);
    }

    public void ExistPlayerData() 
    {         
        bool exists = SaveSystem.DataExists(playerSaveFileName);
        Debug.Log($"Player data exists: {exists}");
        bool enemyExists = SaveSystem.DataExists(enemySaveFileName); 
        Debug.Log($"Enemy data exists: {enemyExists}");
    }

    public void DeleteData()
    {
        SaveSystem.DeleteData(playerSaveFileName);
        SaveSystem.DeleteData(enemySaveFileName);
    }


    public void AddCoin()
    {
        playerData.coins++;
    }

    public void RemoveCoin()
    {
        if (playerData.coins > 0)
        {
            playerData.coins--;
        }
        else
        {
            Debug.LogWarning("No coins to remove!");
        }
    }

}

[Serializable]
public class EnemyData
{
    public string enemyName = "Hikaru";
    public int health = 2000;
    public int damage = 65;
}
