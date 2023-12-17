using System.Collections;
using UnityEngine;

public class Skill
{
    public string name;
    public ElementType element;
    public float damage;
    public int sp;
    public float time;
    public float distance;
    public string prefabFile;
    public string distanceFile;
    public GameObject distanceObject;

    public Skill(string name, ElementType element, float damage, int sp, float time, float distance, string prefabFile, string distanceFile)
    {
        this.name = name;
        this.element = element;
        this.damage = damage;
        this.sp = sp;
        this.time = time;
        this.distance = distance;
        this.prefabFile = prefabFile;
        this.distanceFile = distanceFile;
        this.prefab = Resources.Load<GameObject>(prefabFile);
        this.distancePrefab = Resources.Load<GameObject>(distanceFile);
    }

    public GameObject prefab;

    public GameObject distancePrefab;

    public void generate(Vector3 pos, bool byPlayer = false)
    {
        if (byPlayer) playerCallMagic.sp -= this.sp;
        Debug.Log("Generate Skill" + name + this + "at" + pos);
        Object.Destroy(this.distanceObject);
        GameObject s = Object.Instantiate(prefab, pos, Quaternion.identity);
        Object.Destroy(s, this.time);
        SkillManager.Instance.bs.StartCoroutine(takeDamage(pos));
    }

    public void generateDistance()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("Generate DistanceShow " + name + this + "at" + pos);
        GameObject s = Object.Instantiate(distancePrefab, pos, Quaternion.identity);
        distanceObject = s;
    }

    public IEnumerator takeDamage(Vector3 pos)
    {
        yield return new WaitForSeconds(this.time);
        foreach (var entity in EntityManager.Instance.entities)
        {
            if (EntityManager.Instance.deads.Contains(entity)) continue;
            if (Vector3.Distance(pos, entity.transform.position) <= this.distance)
            {
                entity.GetComponent<Character>()?.TakeDamage(damage);
            }
        }
    }
}