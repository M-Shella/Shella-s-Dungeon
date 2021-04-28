using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    public void PlayGame(int indexSceny) {
        StartCoroutine(NacistAsynchrone(indexSceny));
        //SceneManager.LoadScene(indexSceny);
    }
    public void QuitGame(){
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    IEnumerator NacistAsynchrone(int indexSceny) {
        Time.timeScale = 1f;
        AsyncOperation oprace = SceneManager.LoadSceneAsync(indexSceny);
        loadingScreen.SetActive(true);
        while (!oprace.isDone) {
            float progress = Mathf.Clamp01(oprace.progress / .9f);
            slider.value = progress;
            progressText.text = (int)progress * 100 + "%";
            UIManager.pauznuto = false;
            yield return null;
        }
    }

    public void zpet(GameObject gameObjec) {
        gameObjec.SetActive(false);
    }
    public void nastaveni(GameObject gameObjec) {
        gameObjec.SetActive(true);
    }
}
