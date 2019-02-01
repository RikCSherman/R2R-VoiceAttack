// Copyright (c) Stickymaddness All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Sextant.Domain;
using System;

namespace Sextant.Infrastructure.Repository
{
    public class PlayerStatusRepository : IPlayerStatus, IDisposable
    {
        private const int playerStatusId = 1;

        private static readonly object sync = new object();

        private PlayerStatus _playerStatus;
        private readonly IDataStore<PlayerStatus> _dataStore;

        public string Location
        {
            get { return _playerStatus.Location; }
            set
            {
                if (string.Compare(_playerStatus.Location, value, true) != 0)
                {
                    _playerStatus.Location = value;
                    Store();
                }
            }
        }

        public double X
        {
            get { return _playerStatus.X; }
            set
            {
                if (value != _playerStatus.X)
                {
                    _playerStatus.X = value;
                    Store();
                }
            }
        }

        public double Y
        {
            get { return _playerStatus.Y; }
            set
            {
                if (value != _playerStatus.Y)
                {
                    _playerStatus.Y = value;
                    Store();
                }
            }
        }

        public double Z
        {
            get { return _playerStatus.Z; }
            set
            {
                if (value != _playerStatus.Z)
                {
                    _playerStatus.Z = value;
                    Store();
                }
            }
        }

        public void Dispose() => _dataStore.Dispose();

        public PlayerStatusRepository(IDataStore<PlayerStatus> dataStore)
        {
            _dataStore                      = dataStore;
            PlayerStatus storedPlayerStatus = _dataStore.FindOne(p => p.Id == playerStatusId);
            _playerStatus                   = storedPlayerStatus;

            if (_playerStatus == null)
            {
                _playerStatus = new PlayerStatus(playerStatusId);
                _dataStore.Insert(_playerStatus);
            }
        }

        private bool Store()
        {
            lock(sync)
                return _dataStore.Update(_playerStatus);
        }
    }
}
