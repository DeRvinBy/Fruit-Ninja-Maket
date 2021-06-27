using Project.Scripts.BlockFactory;
using Project.Scripts.Controllers.Blocks;
using Project.Scripts.Controllers.ModelToView;
using UnityEngine;

namespace Project.Scripts.Controllers
{
    public class ControllersManager : MonoBehaviour
    {
        [Header("Blocks Controllers")]
        [SerializeField] 
        private BlockController blockController = null;

        [SerializeField] 
        private PhysicalController physicalController = null;
        
        [SerializeField]
        private ObjectCreator objectCreator = null;

        [Header("GameToView Controllers")] 
        [SerializeField]
        private LifeController lifeController = null;

        [SerializeField] 
        private ScoreController scoreController = null;

        public BlockController GetBlockController()
        {
            return blockController;
        }
        
        public PhysicalController GetPhysicalController()
        {
            return physicalController;
        }
        
        public ObjectCreator GetObjectCreator()
        {
            return objectCreator;
        }
        
        public LifeController GetLifeController()
        {
            return lifeController;
        }
        
        public ScoreController GetScoreController()
        {
            return scoreController;
        }
    }
}