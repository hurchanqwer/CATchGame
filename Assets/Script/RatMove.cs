using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.GraphicsBuffer;

public class RatMove : MonoBehaviour
{
    [SerializeField]
    float speed = 4f;
    
    public Score Score;
    public float rotationSpeed = 2f;
    
    
    // Start is called before the first frame update

    private void Awake()
    {
        
    }
    void Start()
    {
        StartCoroutine(Rand());

    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

    }
    IEnumerator Rand()
    {

        while (true)
        {
            float changeDirectionInterval = Random.Range(2f,6f);
            // ������ ���� ���� ����
            Vector3 randomDirection = Random.insideUnitSphere;
            randomDirection.y = 0f; // y�� ȸ�� ����

            // �ش� ������ �ٶ󺸵��� ȸ��
            Quaternion lookRotation = Quaternion.LookRotation(randomDirection);
            transform.rotation = lookRotation;
            yield return new WaitForSeconds(changeDirectionInterval);

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Score.score++;
            AudioManager.instance.PlaySound();
            AudioManager.instance.minDis = 0;
            Destroy(gameObject);
        }
        
    }
    
}
