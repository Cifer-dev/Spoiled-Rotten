using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    float ThrowForce = 600;
    Vector3 ObjectPos;
    float Distance;

    public bool CanHold = true;
    public GameObject Item;
    public GameObject TempParent;
    public bool IsHolding = false;

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(Item.transform.position, TempParent.transform.position);
        if (Distance >= 1.5f)
        {
            IsHolding = false;
        }

        if (IsHolding == true)
        {
            Item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            Item.transform.SetParent(TempParent.transform);

            if (Input.GetKeyUp (KeyCode.Space))
            {
                Item.GetComponent<Rigidbody>().AddForce(TempParent.transform.forward * ThrowForce);
                IsHolding = false;
            }
        }
        else
        {
            ObjectPos = Item.transform.position;
            Item.transform.SetParent(null);
            Item.GetComponent<Rigidbody>().useGravity = true;
            Item.transform.position = ObjectPos;
        }

        if (Input.GetKey (KeyCode.Space))
        {
            IsHolding = true;
            Item.GetComponent<Rigidbody>().useGravity = false;
            Item.GetComponent<Rigidbody>().detectCollisions = true;
        }
        else
        {
            IsHolding = false;
        }
    }
}
