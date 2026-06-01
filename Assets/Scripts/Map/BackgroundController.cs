using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float starPs;
    private float length;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        starPs = transform.position.z;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate(){
        float distance = cam.transform.position.x * parallaxEffect;
        float movement = cam.transform.position.x * (1 - parallaxEffect);
        transform.position = new Vector3(starPs + distance, transform.position.y, transform.position.z);

        if(movement > starPs + length) 
        {
            starPs += length;
        }
        else if(movement < starPs - length) 
        {
            starPs -= length;
        }
    }
}
