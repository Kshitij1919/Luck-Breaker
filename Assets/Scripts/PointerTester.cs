using UnityEngine;
using UnityEngine.EventSystems;


public class PointerTester : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] public EDiceTag Tag; 
    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;
    public float swipeAngle = 0;
    //public GameObject dicerolleranim = null;




    //public GameObject gameObject;

    //public void SetTag(int DiceSide)
    //{
    //bgprvy
    //GameController.Instance.diceRollColorTag = (EDiceTag)DiceSide

    //if(DiceSide == 0)
    //{
    //    Tag = "Blue";
    //}
    //if (DiceSide == 1)
    //{
    //    Tag = "Green";
    //}
    //if (DiceSide == 2)
    //{
    //    Tag = "Pink";
    //}
    //if (DiceSide == 3)
    //{
    //    Tag = "Red";
    //}
    //if (DiceSide == 4)
    //{
    //    Tag = "Violet";
    //}
    //else
    //{
    //    Tag = "Yellow";
    //}
    //}

    private void Destroy()
    {
        if((GameController.Instance.diceRollColorTag.Equals(Tag)) && (GameController.Instance.breakCount < GameController.Instance.diceCount))
        {
            SoundManager.Instance.PlaySfxOneShot(EAudioSource.AUDIO_SOURCE_SFX, EGameSfx.SFX_SCORE);
            GameController.Instance.list.Remove(gameObject);
            Destroy(gameObject);
            ScoreManager.instance.IncreaseScore();
            GameController.Instance.breakCount++;
            if (GameController.Instance.breakCount == GameController.Instance.diceCount)
            {
                GameController.Instance.animRef.SetActive(true);
            }
        }
        //else if(GameController.Instance.breakCount == GameController.Instance.diceCount)
        //{
        //    GameController.Instance.animRef.SetActive(true);
        //}
        else
        {
            SoundManager.Instance.PlaySfxOneShot(EAudioSource.AUDIO_SOURCE_SFX, EGameSfx.SFX_DIE);
            //GameController.Instance.animref.Play("UI", 5, 0.2f);

            //GameObject.Find("RollIndicator").active = true;
            //Debug.Log("Selected Tile" + gameObject.tag + "Colour Dice: " + Tag);
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Pointer is Down");
        firstTouchPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //Debug.Log(firstTouchPosition);
        Destroy();
       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("Pointer is Up");
        finalTouchPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //Debug.Log(finalTouchPosition);
        CalculateAngle();
    }

    void CalculateAngle()
    {
        swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x) * 180/Mathf.PI;
        //Debug.Log("Swipe Angle: " + swipeAngle);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Cell c = eventData.pointerEnter.GetComponent<Cell>();
        //if (!c.selected)
        //{
        //    c.selected = true;
        //    //enbale highlight
        //    Debug.Log("Dragged!" + eventData.pointerEnter.name);
        //}
    }

    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    Debug.Log("Dragged!" + eventData.pointerEnter.name);
    //}

    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    Debug.Log("DraggedBBB!" + eventData.pointerDrag.name);
    //}

    //Checking distruction

    
}
