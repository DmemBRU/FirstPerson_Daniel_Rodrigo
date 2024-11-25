using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class worldParameters : MonoBehaviour
{
    private Volume efecto;
    [SerializeField] private float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        efecto = GetComponent<Volume>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Mathf.Cos(Time.time));
        
        if(efecto.profile.TryGet(out LensDistortion distortion))
        {
            FloatParameter coseno = new FloatParameter(1 + Mathf.Cos(velocidad* Time.deltaTime) / 2);
            FloatParameter seno = new FloatParameter(1 + Mathf.Sin(velocidad* Time.deltaTime) / 2);
            distortion.xMultiplier.SetValue(coseno);
            distortion.yMultiplier.SetValue(seno);

        }
    }
}
