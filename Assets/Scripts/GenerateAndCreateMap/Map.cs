﻿using System.Collections.Generic;
using GenerateAndCreateMap.Floors;
using GenerateAndCreateMap.Interfaces;
using UnityEngine;
using Zenject;

namespace GenerateAndCreateMap
{
    public class Map : MonoBehaviour
    {
        private IFloorFactory _factory;
        private List<IPoint> _points;
        private List<Floor> _floorsMap = new();

        [Inject]
       public void Construct(IFloorFactory factory, List<IPoint> points)
        {
            Debug.Log("Constructing Map");
            _factory = factory;
            _points = points;
            CreateMap();
        }

        private void CreateMap()
        {
            // var block = new MaterialPropertyBlock();

            foreach (var point in _points)
            {
                var floor = _factory.CreateFloor(point, transform);
                floor.Initialize(point);
                _floorsMap.Add(floor);

                // if (floor.TryGetComponent(out MeshRenderer renderer))
                // {
                //     // !!!надо поменять шейдер, с этим батчинга не будет
                //     block.SetColor("_BaseColor", color);
                //     renderer.SetPropertyBlock(block);
                // }
            }

            Debug.Log($"Map created {_floorsMap.Count}");
        }

        public List<Floor> GetFloorsMap() => _floorsMap;
    }
}