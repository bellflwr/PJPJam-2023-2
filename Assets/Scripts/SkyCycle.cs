using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SkyCycle : MonoBehaviour
{
    [SerializeField] private Material skybox;

    private void Update()
    {
        skybox.SetVector(name = "_MainLightDirection", transform.forward);
    }
}
