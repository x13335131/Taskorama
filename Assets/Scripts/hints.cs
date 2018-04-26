using UnityEngine;
using System.Collections;

public class hints : MonoBehaviour {
    //hints when player picks up objects and enters certain zones

    public string text;                                     //hint text
    public Texture image;                                   //correct, incorrect 
    public bool display = false;                            //set true / false
    public Font font;
    public FontStyle style;                                 //style eg, italics/bold etc
    public Color colour;
    public int fontSize = 28;
    public static Color backgroundColor; 
    public GameObject hint;                                 //the hint trigger
   
    void OnTriggerEnter2D(Collider2D iCollide)         //entering zones
    {
        if (iCollide.name == "player")
        {
            display = true;
            
        }
    }
    void OnTriggerExit2D(Collider2D uCollide)          //leaving zones
    {
        if (uCollide.name == "player")
        {
            display = false;
            Destroy(hint);                             //destroy the hint text so its no longer visible
          
        }
    }
    
   
    private GUIStyle currentStyle = null;               //setting GUISTYLE to null
    void OnGUI()
    {
        if (display == true)                            //if display is true, do the following;
        {
            InitStyles();                               //calling method further down script
            GUI.skin.label.font = GUI.skin.button.font = GUI.skin.box.font = font;      //font on gui
            GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = fontSize; //size of font on gui
           // GUI.contentColor = Color.black;                         //setting content colour to black
            
           // GUI.backgroundColor = Color.white;                  //setting background colour to white
            GUI.Box(new Rect(100, 0, Screen.width-200, Screen.height - 520), text, currentStyle); //creating hint box with text
            GUIStyle style = GUI.skin.GetStyle("label");    
            
            GUIStyle myStyle = new GUIStyle(); //creating instance
            
            new GUIStyle(GUI.skin.box).normal.background = MakeTex(2, 7, new Color(1f, 1f, 1f, 0.3f));  //background colour 
            
        }
        if ((display == true) && (gameObject.name!="spawnPoint")&& (gameObject.name != "level") && (gameObject.name != "smashHint")) // new GUIContent(image);
        {
            
            GUIStyle myStyle = new GUIStyle();
            new GUIStyle (GUI.skin.box).normal.background = MakeTex(2, 7, new Color(1f, 7f, 1f, 1f)); //background colour
            GUI.Box(new Rect(620, 120, 100, 98), new GUIContent(image)); //box dimentions
            
        }
       
    }

    public RectOffset bdr; //border 
    //CODE FROM: http://forum.unity3d.com/threads/change-gui-box-color.174609/
    private void InitStyles()
    {
        if (currentStyle == null)
        {
            currentStyle = new GUIStyle(GUI.skin.box);
            currentStyle.normal.background = MakeTex(2, 7, new Color(0f, 0f, 0f, 0.5f));
            bdr =currentStyle.border;

            bdr = GUI.skin.button.border;
            
        }
    }

    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;

    }
    
}
