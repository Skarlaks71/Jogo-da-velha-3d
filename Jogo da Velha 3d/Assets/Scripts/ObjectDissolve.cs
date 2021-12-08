using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectDissolve : MonoBehaviour
{
    
    public float noiseStrength = 0.25f;
    public float maxHeight = 3;
    private float objectHeight = 0;
    public float speed = 0.25f;
    public Color objectColor;
    Material[] mats;

    private void Awake()
    {
        mats = GetComponent<Renderer>().materials;
        foreach(var m in mats)
        {
            m.SetColor("BaseColor", objectColor);
        }
        
    }

    private void Start()
    {
        StartCoroutine(animHeight(maxHeight));
    }

    IEnumerator animHeight(float max)
    {
        
        while(objectHeight < max)
        {
            
            float valueM = speed * Time.deltaTime;
            objectHeight += valueM;
            foreach (var m in mats)
            {
                m.SetFloat("CutOffHeight", objectHeight);
            }
            yield return null;
        }
        yield return null;
    }
    

    
}
