using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectDissolve : MonoBehaviour
{
    
    public float noiseStrength = 0.25f;
    public float objectHeight = 1;
    public float speed = 0.25f;

    Material mat;

    private void Awake()
    {
        mat = GetComponent<MeshRenderer>().material;

    }

    private void Start()
    {
        StartCoroutine(animHeight(2.5f, 0.2f));
    }

    IEnumerator animHeight(float maxHeight, float delay)
    {
        while(objectHeight < maxHeight)
        {
            mat.SetFloat("CutoffHeight",mat.GetFloat("CutofHeight")+0.1f);
            yield return new WaitForSeconds(delay);
        }
        
    }
    

    
}
