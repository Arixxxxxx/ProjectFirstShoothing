using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explsion : MonoBehaviour
{
    

    private void Delete()
    {
         Destroy(gameObject);
    }
    
    public void SetScale(float _Size)
    {
        Vector3 vec = transform.localScale;
        vec *= _Size / 24f;
        transform.localScale = vec;

    }
}
