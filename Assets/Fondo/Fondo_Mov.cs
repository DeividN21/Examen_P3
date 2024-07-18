using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo_Mov : MonoBehaviour
{
    // Referencia al SpriteRenderer del título del juego
    public SpriteRenderer titleSprite;
    // Variables para el retraso y la aparición gradual
    public float delayBeforePulse = 2.0f; // Tiempo de espera antes de empezar a palpitar
    public float fadeInDuration = 1.0f; // Duración del desvanecimiento
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        // Inicializar el alfa del SpriteRenderer a 0 (invisible)
        Color color = titleSprite.color;
        color.a = 0f;
        titleSprite.color = color;

        // Registrar el tiempo de inicio
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = Time.time - startTime;
        // Realizar la aparición gradual
        if (elapsedTime < fadeInDuration)
        {
            Color color = titleSprite.color;
            color.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);
            titleSprite.color = color;
        }
    }
}
