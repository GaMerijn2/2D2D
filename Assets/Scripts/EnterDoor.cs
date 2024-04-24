using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Entered by: " + other.gameObject.name);
        if (!other.CompareTag("Player")) return;

        var savedTime = PlayerPrefs.GetFloat($"Level{StaticData.CurrentLevel}") == 0
            ? 6942069420
            : PlayerPrefs.GetFloat($"Level{StaticData.CurrentLevel}");
        
        if (LevelLoader.timer < savedTime)
        {
            PlayerPrefs.SetFloat($"Level{StaticData.CurrentLevel}", LevelLoader.timer);
        }

        StaticData.CurrentLevel++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}