using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManager.Runtime
{
    public class GameManager : MonoBehaviour
    {
        #region Publics
	
        #endregion

        #region Unity API
	
        #endregion

        #region Main methods

        public void GoToGameScene()
        {
            SceneManager.LoadScene(1);
        }


        #endregion

        #region Utils
	
        #endregion

        #region Privates & Protected
	
        #endregion
    }

}
