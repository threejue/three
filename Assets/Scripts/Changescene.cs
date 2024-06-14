using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;

public class Changescene : MonoBehaviour
{
    public InputField Name;
    string path;
    // Start is called before the first frame update
    void Start()
    {
        path = Application.dataPath + @"\IO\threejue.txt";
        
    }
    public void ClickButton()
    {
        File.WriteAllText(path, Name.text);
        SceneManager.LoadScene("SchoolSceneDay");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
