// Copyright (c) Stickymaddness All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using System.Collections.Generic;
using Sextant.Domain.Entities;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;

namespace Sextant.Domain
{
    public class Navigator : INavigator
    {
        private readonly IVisitedRepository _navigationRepository;
        private List<StarSystem> _r2rSystems;
        private IPlayerStatus _playerStatus;

        public Navigator(IVisitedRepository navigationRepository, IPlayerStatus playerStatus)
        {
            _navigationRepository = navigationRepository;
            _playerStatus = playerStatus;
            LoadR2RFromResource();
        }

        public void LoadR2RFromResource()
        {
            using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Sextant.Domain.Resources.r2rsystems.json"))
            {
                using (StreamReader file = new StreamReader(resourceStream))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    _r2rSystems = (List<StarSystem>)serializer.Deserialize(file, typeof(List<StarSystem>));
                }
            }
        }

        public bool ExpeditionComplete => _navigationRepository.GetSystems().All(s => s.Scanned);
        public bool ExpeditionStarted  => !_navigationRepository.IsEmpty();

        public bool CancelExpedition() => _navigationRepository.Clear();

        public bool PlanExpedition(IEnumerable<StarSystem> systems) //TODO remove
        {
            if (ExpeditionStarted)
                return false;

            return ExtendExpedition(systems);
        }

        public bool ExtendExpedition(IEnumerable<StarSystem> systems) //TODO remove
        {
            if (systems == null || !systems.Any())
                return false;

            return _navigationRepository.Store(systems);
        }

        public StarSystem GetNextSystem()
        {
            double distance = double.MaxValue;
            StarSystem system = null;
            foreach(StarSystem sys in _r2rSystems)
            {
                if (sys.distance(_playerStatus) < distance)
                {
                    system = sys;
                }
            }
            return system;
        }

        public Celestial GetNextCelestial()
        {
            return null; // GetNextSystem()?.Celestials.FirstOrDefault(c => c.Scanned == false);
        }

        public bool ScanCelestial(string celestial)
        {
            return _navigationRepository.ScanCelestial(celestial);
        }

        public bool ScanSystem(string system)
        {
            return _navigationRepository.ScanSystem(system);
        }

        public bool UnscanSystem(string system)
        {
            return _navigationRepository.UnscanSystem(system);
        }

        public bool SystemScanned(string system)
        {
            return _navigationRepository.GetSystem(system).Scanned;
        }

        public int SystemsRemaining()
        {
            return _navigationRepository.GetUnscannedSystems().Count();
        }

        public int CelestialsRemaining()
        {
            return GetAllRemainingCelestials().Count();
        }

        public List<Celestial> GetAllRemainingCelestials()
        {
            return _navigationRepository.GetUnscannedSystems().SelectMany(s => s.Celestials.Where(c => c.Scanned == false)).ToList();
        }

        public StarSystem GetSystem(string systemName)
        {
            return _navigationRepository.GetSystem(systemName);
        }

        public List<Celestial> GetRemainingCelestials(string systemName)
        {
            return _navigationRepository.GetSystem(systemName).Celestials.Where(c => c.Scanned == false).ToList();
        }

        public bool SystemInExpedition(string system)
        {
            return _navigationRepository.GetSystem(system) != null;
        }
    }
}