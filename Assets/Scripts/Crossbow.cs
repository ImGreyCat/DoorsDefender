using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    #region Variables
    public Arrow arrowPrefab;
    public float shootInterval = 0.75f;
    public float shootTimer = 0;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        #region Crossbow Rotation
        Vector2 mouseScreenPos = Input.mousePosition;

        Vector2 defaultDirection = Vector2.up;

        Vector2 mouseScenePos = Camera.main.ScreenToWorldPoint(mouseScreenPos); 
        // Vector2.Angle(Vector2)

        Vector2 bowPos = transform.position;
        Vector2 wantedDirection = mouseScenePos - bowPos;
        
        float angle = Vector2.SignedAngle(defaultDirection, wantedDirection);
        Vector3 newEuler = new Vector3(0, 0, angle);
        transform.localEulerAngles = newEuler;
        #endregion

        #region Shoot
        if (Input.GetMouseButtonDown(0))
        {
            
            if (shootTimer > 0)
            {
                shootTimer = -Time.deltaTime;
            }

            if (shootTimer <= 0)
            {
                Instantiate(arrowPrefab, transform.position, transform.rotation);
                shootTimer = shootInterval;
            }
        }
        #endregion
    }
}
