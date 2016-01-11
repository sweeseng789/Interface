using UnityEngine;
using System.Collections;

public class SSDLC : MonoBehaviour
{
    public bool intersect2D(Vector3 topleft, Vector3 bottomRight, Vector3 pos)
    {
        if(pos.x <= topleft.x && pos.x >= bottomRight.x)
        {
            if(pos.y <= topleft.y && pos.y >= bottomRight.y)
            {
                return true;
            }
        }
        return false;
    }
}
