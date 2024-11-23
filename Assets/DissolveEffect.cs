using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    public Material dissolveMaterial;
    [Range(0.1f, 10.0f)] public float dissolveDuration = 5.0f;

    private float dissolveValue = 0.0f; 
    private bool isDissolving = false;

    private void Start()
    {
        StartDissolve();
    }

    private void Update()
    {
        if (isDissolving)
        {
            dissolveValue += Time.deltaTime / dissolveDuration;
            dissolveMaterial.SetFloat("_Dissolve", dissolveValue);

            if (dissolveValue >= 1f)
            {
                isDissolving = false; 
                ResetDissolveValue(); 
                Destroy(gameObject); 
            }
        }
    }

    private void StartDissolve()
    {
        isDissolving = true;
    }


    private void ResetDissolveValue()
    {
        dissolveValue = 0.0f;
        dissolveMaterial.SetFloat("_Dissolve", dissolveValue);

    }
}
