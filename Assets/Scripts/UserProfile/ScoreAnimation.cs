using UnityEngine;
using UnityEngine.UI;

public class ScoreAnimation : MonoBehaviour
{
    public float moveUpDistance = 50f;      // How far the text moves up
    public float animationDuration = 1f;    // Duration of the animation
    public Text scoreText;                  // Reference to the Text component
    private Color originalColor;

    private void Start()
    {
        // Check if scoreText has already been assigned in the Inspector
        if (scoreText == null)
        {
            // Attempt to find the Text component on this GameObject
            scoreText = GetComponent<Text>();

            // If the Text component is still not found, log an error to help with debugging
            if (scoreText == null)
            {
                Debug.LogError("Text component not found on this GameObject! Please ensure that a Text component is assigned to the ScoreAnimation script.");
                return;
            }
        }

        // Save the original color if the Text component is found
        originalColor = scoreText.color;
    }

    public void PlayAnimation()
    {
        // Check again to ensure scoreText is assigned before attempting animation
        if (scoreText == null)
        {
            Debug.LogError("Cannot play animation. Text component is not assigned.");
            return;
        }

        // Reset position and color when the animation starts
        transform.localPosition = Vector3.zero;
        scoreText.color = originalColor;

        // Start the fade and move animations
        StartCoroutine(FadeAndFlyUp());
    }

    private System.Collections.IEnumerator FadeAndFlyUp()
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = transform.localPosition;
        Vector3 targetPosition = startingPosition + new Vector3(0, moveUpDistance, 0);

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / animationDuration;

            // Interpolate the position
            transform.localPosition = Vector3.Lerp(startingPosition, targetPosition, progress);

            // Fade out the text
            scoreText.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1 - progress);

            yield return null;
        }

        // Ensure the text is fully transparent and in the correct position at the end
        scoreText.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
        transform.localPosition = targetPosition;
    }
}
