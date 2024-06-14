using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Opendoor03 : MonoBehaviour
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
        if (Vector3.Distance(player.transform.position, transform.position) < 2 && !isopen)
        {
            print(1);
            open.Play("New Animation.anim04");
            isopen = true;
            text.gameObject.SetActive(true);

        }
        if (Vector3.Distance(player.transform.position, transform.position) > 3 && isopen)
        {
            close.Play("close04");
            isopen = false;
            text.gameObject.SetActive(false);

        }
    }
}
