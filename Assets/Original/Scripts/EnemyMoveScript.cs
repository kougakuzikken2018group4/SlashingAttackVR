using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveScript : MonoBehaviour {

    Vector3 playerPosition;

    NavMeshAgent m_navMeshAgent; /// NavMeshAgent

    // Use this for initialization
    void Start()
    {
        // NavMeshAgentコンポーネントを取得
        m_navMeshAgent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.Find("FirstPersonCharacter").transform.position;

        // NavMeshが準備できているなら
        if (m_navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            // NavMeshAgentに目的地をセット
            m_navMeshAgent.SetDestination(playerPosition);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "FPSController")
        {
            Destroy(this.gameObject);
        }
    }
}
