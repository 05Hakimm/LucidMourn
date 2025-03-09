using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public GameObject cam; // Référence à la caméra
    public float parallaxEffect; // Effet de parallax (plus faible = bouge lentement)

    private float length;
    private float startPosX;
    private float lenghtmap = 72; // taille de la map


    void Start()
    {
        startPosX = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x; // Largeur du sprite
    }

    void FixedUpdate()
    {
        // Appliquer l'effet de parallax en fonction de la caméra
        float distance = cam.transform.position.x * (parallaxEffect - 1);
        transform.position = new Vector3(startPosX + distance, transform.position.y, transform.position.z);

        // Vérification du repositionnement infini
        float repositionLimit = cam.transform.position.x * (1 - parallaxEffect);
        if (repositionLimit > startPosX + length)
        {
            startPosX += lenghtmap; // Se replace précisément sans accumulation
        }
        else if (repositionLimit < startPosX - length)
        {
            startPosX -= lenghtmap;
        }
    }
}
