using System.Collections;
using UnityEngine;

public class SoundAndSpriteTrigger : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public AudioSource AudioSource;
    public float FadeTime = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        float elapsed = 0f;

        while (elapsed < FadeTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsed / FadeTime);
            SpriteRenderer.color = new Color(1, 1, 1, alpha);

            elapsed += Time.deltaTime;
            yield return null; // Wait until next frame
        }
        AudioSource.Play();
        SpriteRenderer.color = new Color(1, 1, 1, 1);
    }
}