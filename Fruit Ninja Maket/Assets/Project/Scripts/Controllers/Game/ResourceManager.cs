using Project.Scripts.Controllers.Save;
using UnityEngine;

namespace Project.Scripts.Controllers.Game
{
    public class ResourceManager : MonoBehaviour
    {
        private ISaveController saveController = null;

        public void SetSaveController(ISaveController saveController)
        {
            this.saveController = saveController;
        }
        
        public ISaveController GetSaveController()
        {
            return saveController;
        }
    }
}