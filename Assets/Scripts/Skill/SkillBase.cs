using UnityEngine;

public class SkillBase:MonoBehaviour
{
    public Transform skillPool;
    public bool isPreparing;

    public void prepareCall1()
    {
        SkillManager.Instance.prepareCall("冰柱术");
    }


    public void prepareCall2()
    {
        SkillManager.Instance.prepareCall("大火球术");
    }


    private void Start()
    {
        SkillManager.Instance.bs = this;
        SkillManager.Instance.init();
    }
    private void Update()
    {
        if (!isPreparing) return;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            SkillManager.Instance.callSkill(mousePos,true);
        }
    }

    public GameObject generate(GameObject o, Vector3 pos, Transform parent)
    {
        Debug.Log("generate entity" + o + "at" + pos);
        GameObject r = Instantiate(o, pos, Quaternion.identity);
        r.transform.SetParent(parent);
        return r;
    }
}
