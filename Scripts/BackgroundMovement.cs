
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{

    [SerializeField] Vector2 moveSpeed;

    Vector2 offsett;

    Material material;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offsett += moveSpeed * Time.deltaTime;
        material.mainTextureOffset = offsett;
    }

    

}
