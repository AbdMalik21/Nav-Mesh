using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class checkTarget : MonoBehaviour
{
     public NavMeshAgent spawnPosition;
     Transform targetPosition;
 
     [HideInInspector]
     public bool pathAvailable;
     public NavMeshPath navMeshPath;
        
     private string sceneName = "Lucky - Lv 1";
 
     void Start() {
         navMeshPath = new NavMeshPath();
         targetPosition = GameObject.FindGameObjectWithTag("Finish").transform;
         PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
         PlayerPrefs.SetInt("lastIndexScene", SceneManager.GetActiveScene().buildIndex);
     }
 
     void Update() {
         //if (/*UI Button Press*/) {
             if (CalculateNewPath() == true) {
                 pathAvailable = true;
                 print("Path available");
             }
             else {
                 pathAvailable = false;
                 print("Path not available");
                 SceneManager.LoadScene(sceneName);
             }
         //}
     }
 
     bool CalculateNewPath() {
         spawnPosition.CalculatePath(targetPosition.position, navMeshPath);
         print("New path calculated");
         if (navMeshPath.status != NavMeshPathStatus.PathComplete) {
             return false;
         }
         else {
             return true;
         }
     }
}
