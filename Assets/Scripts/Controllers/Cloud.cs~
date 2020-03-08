using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] int layerMask;
    [SerializeField] float humaditySpeed = 0.1f;
    public BasicHexEngine attachedHex;
    public float humidity  = 0;
    private List <Cloud> neibours;
    private MeshRenderer cloudRenderer;
    [SerializeField] float moveSpeed = 0.5f;

    private void Start()
    {
        if (this.gameObject.CompareTag("Cloud"))
        {
            neibours = new List<Cloud>();
            //gameObject.GetComponent<BasicHexEngine>().grass.SetActive(false);
            //gameObject.GetComponent<BasicHexEngine>().cloud.SetActive(true);
            gameObject.GetComponent<StandartHexEngine>().enabled = !gameObject.GetComponent<StandartHexEngine>().enabled;

            GameObject cloudMesh = transform.FindDeepChild("HexTop_Cloud").gameObject;
            transform.FindDeepChild("HexTop_River").gameObject.SetActive(false);

            cloudMesh.SetActive(true);
            cloudRenderer = cloudMesh.GetComponent<MeshRenderer>();
            if (cloudRenderer)
            {
                Color color = cloudRenderer.material.color;
                cloudRenderer.material.color = new Color(color.r, color.g, color.b, 0);
            }
            getNeibours();
        }
        else
        {
            gameObject.GetComponent<Cloud>().enabled = !gameObject.GetComponent<Cloud>().enabled;
        }
    }

    public GameObject castRay()
    {
        int layer = 1 << layerMask;
        RaycastHit hit;
        //Debug.DrawRay(this.transform.position, -this.transform.up, Color.red);
        if (Physics.Raycast(this.transform.position, -this.transform.up, out hit, 10, layer))
        {
            return (hit.collider.gameObject);
        }
        return null;
    }

    public void changeView()
    {
        cloudRenderer.material.color = new Color(1, 1, 1, humidity / 200);
    }

    public void rain()
    {
        GameObject obj = this.castRay();
        if (obj)
        {
            StandartHexEngine objEngine = obj.GetComponent<StandartHexEngine>();
            if (objEngine)
            {
                objEngine.SetWaterEffect(this.humidity * Time.deltaTime * humaditySpeed); // change value
                this.humidity -= this.humidity * Time.deltaTime * humaditySpeed * 0.1f;
                if (this.humidity < 0)
                    this.humidity = 0;
            }
        }
    }
    public  void move()
    {
        if (neibours.Count > 0)
        {
            Random.InitState((int)Time.time);
            int r = Random.Range(0, neibours.Count - 1);
            neibours[r].setHumidity(neibours[r].getHumidity() + this.getHumidity() * Time.deltaTime * moveSpeed);
            this.setHumidity(this.getHumidity() - this.getHumidity() * Time.deltaTime * moveSpeed);
        }
    }

    private void getNeibours()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 0.5f);
        foreach (var gobject in hitColliders)
        {
            Cloud temp;
            if (temp = gobject.GetComponent<Cloud>())
            {
                if (temp && temp != this)
                {
                    neibours.Add(temp);
                }
            }
        }
    }

   public void setHumidity(float newHumidity)
    {
        this.humidity = newHumidity;
    }

    public void addHumidity(float newHumidity)
    {
        this.humidity += newHumidity;
        if (humidity > 100)
            humidity = 100;
    }

    public  float getHumidity()
    {
        return this.humidity;
    }
}