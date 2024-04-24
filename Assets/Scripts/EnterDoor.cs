using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EnterDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Entered by: " + other.gameObject.name);
        if (!other.CompareTag("Player")) return;
        
        PlayerPrefs.SetFloat($"Level{StaticData.CurrentLevel}", LevelLoader.timer);
        StaticData.CurrentLevel++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
