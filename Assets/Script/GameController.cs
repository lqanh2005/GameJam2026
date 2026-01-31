
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] float disTance=18.85f;
    [SerializeField] Transform parent;
    [SerializeField] List<GameObject> masks;

    [SerializeField] List<int> listStt;
    [SerializeField] bool activeMove;
    public float Speed=5f;
    [SerializeField] int idx=0;
    [SerializeField] float disTanceToMove=18.85f;
    
    [Header("Timer")]
    [SerializeField] float timer=10f;
    [SerializeField] List<int>timeList;
    [SerializeField] float startPosition=9f;

    [Header("Nhap nhay")]
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] Image image;
    [SerializeField] bool nhapnhay=false;
    int idxList=0;
    float positionBase=0;
    void Start()
    {
        idx=0;
        idxList=0;
        timeText.text=timer.ToString();
        if (timer <= 10f&&!nhapnhay)
        {
            nhapnhay=true;
            InvokeRepeating("NhapNhay",0f,.2f);
        }

        for(int i = 0; i < listStt.Count; i++)
        {
            GameObject tmp=Instantiate(masks[listStt[i]],
            new Vector3(startPosition,0,0),Quaternion.identity,parent);
            startPosition-=disTance;
        }
        // parent.transform.position= new Vector2(parent.transform.position.x-18.9f,parent.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        timer-=Time.deltaTime;
        if(timer<=0)    timer=0;
        timeText.text=((int)timer).ToString();

        

        if (timer < timeList[idxList])
        {
            if(idxList>=timeList.Count-1)
                return;

            idxList++;
            activeMove=true; // mỗi time khác nhau sẽ cộng vào khác nhau
        }

        if(activeMove)
        {
            float tmp=parent.position.x+Speed*Time.deltaTime;
            parent.position= new Vector2(tmp,parent.position.y);
            if (parent.position.x >= positionBase + disTanceToMove)
            {
                parent.position=new Vector2(positionBase+disTanceToMove,parent.position.y);
                positionBase=parent.position.x; // gán lại cho parent
                idx++;
                activeMove=false;
            }
            
        } 

    }

    void NhapNhay()
    {
        Color _color=timeText.color;
        if (!_color.Equals(Color.white))
        {
            timeText.color=Color.white;
            image.color=Color.white;
        }
        else if (!_color.Equals(Color.red))
        {
            timeText.color=Color.red;
            image.color=Color.red;
        }
    }
}
