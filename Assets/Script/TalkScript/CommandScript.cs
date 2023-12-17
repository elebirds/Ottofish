using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandScript : MonoBehaviour
{
    public static CommandScript Instance;
    public Image Panel;
    public GameObject prefab;
    private void Awake()
    {
        Instance = this;
    }

    public void ShowImage(string target,float x=0.5f,float y=0.5f)
    {
        Texture2D tex=Resources.Load("Images/"+target) as Texture2D;
        if (!tex)
        {
            Debug.LogError("没能找到图片..." + target);
        }
        else
        { Debug.Log("找到图片..."); }
        if (target.StartsWith("role_"))
        {
            var role =GameObject.Find(target);
            if (role == null)
            {
                GameObject imgobj = Instantiate(prefab);
                imgobj.GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
                imgobj.GetComponent<RectTransform>().anchoredPosition = new Vector2(1920 * x, 1920 * y);
                imgobj.GetComponent<Image>().SetNativeSize();
                imgobj.GetComponent<RectTransform>().SetParent(Panel.rectTransform);
                imgobj.gameObject.name = target;
            }
            else
            {
                role.GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            }
        }
        else
        {
            GameObject imgobj = Instantiate(prefab);
            imgobj.GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            imgobj.GetComponent<RectTransform>().anchoredPosition = new Vector2(1920 * x, 1920 * y);
            imgobj.GetComponent<Image>().SetNativeSize();
            imgobj.GetComponent<RectTransform>().SetParent(Panel.rectTransform);

        }

    }
}
