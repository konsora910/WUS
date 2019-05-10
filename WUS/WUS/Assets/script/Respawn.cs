using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float power;
    private Transform respawnpoint;

    // Start is called before the first frame update
    void Start()
    {
        respawnpoint = transform.Find("Respawn");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("ReturnCharacter", other.gameObject);
        }
    }

    private IEnumerator ReturnCharactor(GameObject charactor)
    {
        yield return new WaitForSeconds(1f);
        charactor.transform.position = respawnpoint.position;
    }
}
