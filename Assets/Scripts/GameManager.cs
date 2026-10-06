using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    SaveSystem saveSystem;
    private void Start()
    {
       saveSystem = new SaveSystem();
    }
    public void SavePlayerData()
    {
        saveSystem.SavePlayerData(playerData);
    }

    public void LoadPlayerData()
    { 
        playerData = saveSystem.LoadPlayerData();
    }
}
