using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Transform levelHolder;

    private void Start()
    {
        LoadLevel(StaticData.CurrentLevel);
    }

    public void LoadLevel(int ID)
    {
        var l = levelHolder.childCount;
        for (int i = 0; i < l; i++)
        {
            levelHolder.GetChild(i).gameObject.SetActive(i == ID);
        }

        StaticData.CurrentLevel = ID;
    }
}