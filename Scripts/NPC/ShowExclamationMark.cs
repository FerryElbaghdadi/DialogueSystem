using UnityEngine;
using System.Collections;

public class ShowExclamationMark : MonoBehaviour
{
    
    /*
     * RESPONSIBILITY: Show an exclamation mark above the NPC whenever the player gets in range.
     */

    [SerializeField] private GameObject _exclamationMark;

    void Start()
    {
        _exclamationMark.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            _exclamationMark.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            _exclamationMark.SetActive(false);
        }
    }

}
