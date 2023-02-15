using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement {

	public void LookAround(LayerMask layerMask)
    {       
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;
        if (Physics.Raycast(raio, out impacto, 100, layerMask))
        {
            Vector3 playerAim = impacto.point - transform.position;
            playerAim.y = transform.position.y;

            this.LookRotation(playerAim);
        }
    }
}
