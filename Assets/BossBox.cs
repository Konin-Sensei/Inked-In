using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBox : MonoBehaviour
{
    public Material[] materials = new Material[9];
    // Start is called before the first frame update
    void Start(){
        RenderSettings.skybox = materials[BossProgress.getLevel()];
    }
    void Update(){
        RenderSettings.skybox = materials[BossProgress.getLevel()];
    }
}
