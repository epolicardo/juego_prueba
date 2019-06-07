using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    private Animator Animacion;
    void Start()
    {
        Animacion = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0))
        {
            updateState("PlayerJump");
        }
    }
    public void updateState(string state= null)
    {
        if (state != null)
        {
            Animacion.Play(state);
        }
    }
}
