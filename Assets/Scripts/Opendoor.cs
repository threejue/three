using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opendoor : MonoBehaviour
{
    public GameObject player;
    Animation open;
    Animation close;
    bool isopen = false;
    public Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        open = GetComponent<Animation>();
        close = GetComponent<Animation>();
        text = text.GetComponent<Text>();
        
    }
    
    public void CloseText()
    {
        text.gameObject.SetActive(false);
        
        
    }
  
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 2&&!isopen)
        {
            
           
            open.Play("New Animation.anim01");
            isopen = true;
            
            text.gameObject.SetActive(true);
            
            ;
        }
        if (Vector3.Distance(player.transform.position, transform.position) > 3 && isopen)
        {
            close.Play("close01");
            text.gameObject.SetActive(false);
            isopen = false;
            
        }
    }
}
