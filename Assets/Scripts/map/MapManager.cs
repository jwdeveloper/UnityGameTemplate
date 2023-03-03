using System;
using System.Collections.Generic;
using api.injection;
using UnityEngine;

namespace DefaultNamespace.map
{
    public class MapManager : BaseGameObject
    {
        [Inject]
        private Camera _camera;

        public List<MapTile> TilesPool;


        private void Update()
        {
            
            
            
            
        }
    }
}