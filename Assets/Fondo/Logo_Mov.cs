using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo_Mov : MonoBehaviour
{
    // Referencia al SpriteRenderer del título del juego
    public SpriteRenderer titleSprite;

    // Variables para controlar el pulso
    public float pulseSpeed = 1.0f;
    public float minScale = 0.8f;
    public float maxScale = 1.2f;

    // Variables para el retraso y la aparición gradual
    public float delayBeforePulse = 2.0f; // Tiempo de espera antes de empezar a palpitar
    public float fadeInDuration = 1.0f; // Duración del desvanecimiento

    private bool isPulsing = false;
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
        else if (!isPulsing && elapsedTime >= delayBeforePulse)
        {
            // Empezar a palpitar después del retraso
            isPulsing = true;
        }

        if (isPulsing)
        {
            // Calcular la escala basada en Mathf.PingPong
            float scale = Mathf.Lerp(minScale, maxScale, Mathf.PingPong((elapsedTime - delayBeforePulse) * pulseSpeed, 1));

            // Aplicar la escala al título del juego
            titleSprite.transform.localScale = new Vector3(scale, scale, 1);
        }
    }
}
