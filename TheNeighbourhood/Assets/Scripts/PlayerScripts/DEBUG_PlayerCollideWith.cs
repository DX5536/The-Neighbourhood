using UnityEngine;


public class DEBUG_PlayerCollideWith: MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player collide with" + collision.gameObject.name);
    }
}