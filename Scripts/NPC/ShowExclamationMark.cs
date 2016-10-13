using UnityEngine;
using System.Collections;

public class ShowExclamationMark : MonoBehaviour
{

    [SerializeField]
    private GameObject _exclamationMark;

    [SerializeField]
    private NPCDetector _npcDetector;

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
