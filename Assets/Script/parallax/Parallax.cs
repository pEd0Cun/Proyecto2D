using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    public float parallaxMultiplier = 0.1f;
    private Material parallaxMaterial;
    private Transform player;
    private float lastPlayerX;

    // Start is called before the first frame update
    void Start()
    {
        parallaxMaterial = GetComponent<Renderer>().material;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastPlayerX = player.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
        float deltaX = player.position.x - lastPlayerX;
        parallaxMaterial.mainTextureOffset += new Vector2(deltaX * parallaxMultiplier,0);
        lastPlayerX = player.position.x;
    }
}
