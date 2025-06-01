using UnityEngine;

public class PadlockEffect : MonoBehaviour
{
    public Material dissolveMaterial;
    public float disappearDelay = 3.0f;

    private Renderer padlockRenderer;
    private Material originalMaterial;

    void Start()
    {
        padlockRenderer = GetComponent<Renderer>();
        originalMaterial = padlockRenderer.material;
    }

    public void UnlockPadlock()
    {
        if (dissolveMaterial != null && padlockRenderer != null)
        {
            padlockRenderer.material = dissolveMaterial;
        }

        StartCoroutine(DisappearAfterDelay());
    }

    private System.Collections.IEnumerator DisappearAfterDelay()
    {
        yield return new WaitForSeconds(disappearDelay);

        Destroy(gameObject);
    }
}
