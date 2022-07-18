using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryCollission : MonoBehaviour
{
    //[SerializeField] public EDiceTag BoundaryTag /*= EDiceTag.DEADZONE*/;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Game Over ++");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Game Over 2 ++");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Game Over ++");
    }


    //public void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.transform.tag.Equals("deadzone"))
    //    {
    //        Debug.Log("block collided with upper boundary");
    //        GameController.Instance.SwitchScreen(EGameScreens.GAMEOVER);

    //    }
    //    //else
    //    //{
    //    //    GameController.Instance.SwitchScreen(EGameScreens.GAMEOVER);
    //    //}
    //}



}
