using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement {

    public GameObject gunBarrel;

    public Vector3 inPoint;
    public Vector3 inNormal;

    public void LookAround(LayerMask layerMask)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

        inPoint = gunBarrel.transform.position;
        inNormal = Vector3.up * 1;
        Plane plano = new Plane(inNormal, inPoint);        

        float distanceCollision;
        if (plano.Raycast(ray, out distanceCollision))
        {
            Vector3 localCollision = ray.GetPoint(distanceCollision);
            localCollision.y = 0;

            //direcao para onde vamos olhar baseado onde estamos
            Vector3 playerAim = localCollision - transform.position;

            this.LookRotation(playerAim);
        }
    }
}
