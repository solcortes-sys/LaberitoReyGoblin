using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int targetIndex = currentIndex + 1;
        int totalScenes = SceneManager.sceneCountInBuildSettings;
        if (targetIndex >= totalScenes) targetIndex = 0;
        SceneManager.LoadScene(targetIndex);
        Debug.Log($"Cargando siguiente escena: índice {targetIndex}");
    }
}
