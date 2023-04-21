using UnityEngine;

public class ImageZoom : MonoBehaviour {

    public float zoomSpeed = 0.5f;
    public float maxScale = 2.0f;

    void Update () {
        // Get the current scale of the image
        Vector3 currentScale = transform.localScale;
       
        // Increase the scale by zoomSpeed percent per frame
        currentScale *= 1 + zoomSpeed * Time.deltaTime;

        // Check if the new scale is less than the maximum allowed scale
        if (currentScale.magnitude <= maxScale) {
            // Set the new scale of the image
            transform.localScale = currentScale;
        }
    }
}