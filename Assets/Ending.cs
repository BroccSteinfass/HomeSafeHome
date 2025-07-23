using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public Image FadeImage;
    public float FadeTime = 3;
    public int LoadSceneAfterFade = 4;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered supi dupi");

        StartCoroutine(RunEveryFrameFor2Seconds());
    }

    private IEnumerator RunEveryFrameFor2Seconds()
    {
        float elapsed = 0f;

        while (elapsed < FadeTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsed / FadeTime);
            FadeImage.color = new Color(0, 0, 0, alpha);

            elapsed += Time.deltaTime;
            yield return null; // Wait until next frame
        }
        FadeImage.color = new Color(0, 0, 0, 1);
        SceneManager.LoadScene(LoadSceneAfterFade);
    }
}