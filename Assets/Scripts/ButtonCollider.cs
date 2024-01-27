using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ButtonCollider : MonoBehaviour
{
    public GameObject button;
    public AudioClip buttonPress;
    public UnityEvent onRelease;
    public Color targetColor = Color.white;
    public float pressDuration = 0.2f;
    private GameObject presser;
    private AudioSource audioSource;
    private bool isPressed;
    private float pressStartTime;

    private Color originalColor;
    private Renderer buttonRenderer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isPressed = false;
        // Ensure that the button has a renderer component
        buttonRenderer = button.GetComponent<Renderer>();
        if (buttonRenderer != null)
        {
            originalColor = buttonRenderer.material.color;
        }
        else
        {
            Debug.LogError("Button must have a Renderer component.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            // Pressed position
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            // Play sound
            audioSource.PlayOneShot(buttonPress);
            isPressed = true;
            pressStartTime = Time.time;
            // Start the color transition on the button object
            StartCoroutine(ChangeColorOverTime());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            // Original position
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            audioSource.Stop();
            // Reset the button to original color
            if (buttonRenderer != null)
            {
                buttonRenderer.material.color = originalColor;
            }
            // Collider is left after more than press duration
            if (Time.time - pressStartTime > pressDuration)
            {
                // Call onRelease functions
                onRelease.Invoke();
            }
            isPressed = false;
        }
    }

    // Coroutine to gradually change the color over time
    IEnumerator ChangeColorOverTime()
    {
        float elapsedTime = 0f;
        while (isPressed & elapsedTime < pressDuration)
        {
            buttonRenderer.material.color = Color.Lerp(originalColor, targetColor, elapsedTime / pressDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        if (isPressed)
        {
            buttonRenderer.material.color = targetColor;
        }
    }
}