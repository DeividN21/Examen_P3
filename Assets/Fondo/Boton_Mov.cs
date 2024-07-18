using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton_Mov : MonoBehaviour
{
    // Referencia al SpriteRenderer del botón
    public SpriteRenderer buttonSprite;

    // Variables para controlar el movimiento y pulso
    public Vector3 startPosition = new Vector3(-10, 0, 0); // Posición inicial fuera de la pantalla
    public Vector3 endPosition = new Vector3(0, 0, 0); // Posición final en el centro de la pantalla
    public float moveDuration = 2.0f; // Duración del deslizamiento
    public float pulseSpeed = 1.0f; // Velocidad del pulso
    public float minScale = 0.8f;
    public float maxScale = 1.2f;

    private bool isPulsing = false;
    private float moveStartTime;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializar la posición del botón
        buttonSprite.transform.position = startPosition;
        moveStartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Calcular cuánto tiempo ha pasado desde que comenzó el movimiento
        float t = (Time.time - moveStartTime) / moveDuration;

        if (t < 1.0f)
        {
            // Mover el botón desde la posición inicial a la posición final
            buttonSprite.transform.position = Vector3.Lerp(startPosition, endPosition, t);
        }
        else
        {
            // Una vez que el botón llega al centro, comienza a pulsar
            if (!isPulsing)
            {
                isPulsing = true;
            }

            if (isPulsing)
            {
                // Calcular la escala basada en Mathf.PingPong
                float scale = Mathf.Lerp(minScale, maxScale, Mathf.PingPong((Time.time - moveStartTime - moveDuration) * pulseSpeed, 1));

                // Aplicar la escala al botón
                buttonSprite.transform.localScale = new Vector3(scale, scale, 1);
            }
        }
    }
}
