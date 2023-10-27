using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    Vector3 ItemMove = new Vector3(-2, -2);

    [SerializeField] public AudioClip Item;
    [SerializeField] public AudioClip coin;
    AudioSource Audio;
    
    bool isok;

    public enum Itemtype
    {
        Power,
        Boom,
        Coin
    }

    [SerializeField] public Itemtype type;

    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        MoveItem();
        CheckPos();
    }

    private void MoveItem()
    {
        transform.position += ItemMove * 1 * Time.deltaTime;
    }

 
    private void CheckPos()
    {
        Vector3 CurrentPos = Camera.main.WorldToViewportPoint(transform.position);

        if (CurrentPos.x < 0.08f && ItemMove.x < 0)
        {
            ItemMove = Vector3.Reflect(ItemMove, Vector3.left);
           
        }
        else if (CurrentPos.x > 0.9f && ItemMove.x > 0)
        {
            ItemMove = Vector3.Reflect(ItemMove, Vector3.right);
           
        }

        else if (CurrentPos.y < 0.08f && ItemMove.y < 0)
        {
            ItemMove = Vector3.Reflect(ItemMove, Vector3.down);
           
        }
        else if (CurrentPos.y > 0.9f && ItemMove.y > 1)
        {
            ItemMove = Vector3.Reflect(ItemMove, Vector3.up);
        }

    }
     

    public Itemtype Returntype()
    {
        return type;
    }

}
