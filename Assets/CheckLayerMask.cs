using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class CheckLayerMask : MonoBehaviour
{
    [SerializeField] LayerMask obstacleLayer;
    [SerializeField] float rayDistance;
    [SerializeField] Transform startPosition;
    
    public int mission;  // ==0 thu hep; ==1 mo rong
    [SerializeField] List<GameObject> Obstackle123;
    [SerializeField] bool daMoRong;
    [SerializeField] bool daThuHep;

    void Update()
    {
        LogicTriggerThuHep();
        LogicTriggerMoRong();

    }

    private void LogicTriggerThuHep()
    {
       

        RaycastHit2D[] hits = Physics2D.RaycastAll(startPosition.position,
                                        Vector2.down,
                                        rayDistance, obstacleLayer);
        foreach (var hit in hits)
        {

            if (hit.collider != null)
                if (hit.collider.GetComponentInParent<MaskController>() != null)
                {
                    if (mission == 0)
                        hit.collider.GetComponentInParent<MaskController>().setupMaskControllerThuHep();
                }
        }
    }

    void LogicTriggerMoRong()
    {
        foreach(var hit in Obstackle123)
        {
            
            float myX = transform.position.x;
            float targetX = hit.transform.position.x;

           
            float deltaX = myX - targetX;

           
            if (Mathf.Abs(deltaX) < 0.5f) 
            {
                MaskController mc = hit.GetComponentInChildren<MaskController>();
                if (mc != null)
                {
                    Debug.Log("Kích hoạt Mở Rộng cho: " + hit.name);
                    mc.setupMaskControllerMoRong();
                }
            }
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.DrawLine(startPosition.position,new Vector3(startPosition.position.x,
                        startPosition.position.y-rayDistance));
    }
}
