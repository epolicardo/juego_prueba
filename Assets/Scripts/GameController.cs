using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    [Range(0f, 0.30f)] // este es un rango para la velocidad 
    public float parallaxspeed = 0.02f;
    public RawImage Background;
    public RawImage Platform;
    public enum GameState { Idle, Playing }; //parado oo jugando, un enum es una lista de opciones
    public GameState gamestate = GameState.Idle;
    public GameObject uiIdle;
    public GameObject player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // empezamos el juego
        // re hacer 2 condicionales If. prepguntamos si estamos quieto, y despues si aprieta una tecla
        if (gamestate == GameState.Idle)
        {
            if (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0))
            {
                //tecla flecha arriba / o el boton de el mouse posicion 0       {
                gamestate = GameState.Playing; // el stado de el juego cambio a playing.
                uiIdle.SetActive(false);
                player.SendMessage("updateState", "Playerrun");
                    //llamamos a la el otro script.
            }
        }
        else if (gamestate == GameState.Playing)
        {
            parallax();
        }
    }
    void parallax()
    { //si estamos jugando, empieza el efecto parallax.  el de movimiento
        float finalspeed;
        finalspeed = parallaxspeed * Time.deltaTime;
        //bakcground, en la propiedad uv rect. velocidad en cada eje, x,Y, Altura y ancho
        Background.uvRect = new Rect(Background.uvRect.x + finalspeed, 0f, 1f, 1f);
        // ahora para la plataforma 
        Platform.uvRect = new Rect(Platform.uvRect.x + finalspeed * 3, 0f, 1f, 1f);
    }
}
