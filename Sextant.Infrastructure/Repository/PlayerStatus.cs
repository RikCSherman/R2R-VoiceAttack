// Copyright (c) Stickymaddness All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Sextant.Domain;

namespace Sextant.Infrastructure.Repository
{
    public class PlayerStatus : IPlayerStatus
    {
        private int playerStatusId;

        public PlayerStatus(int playerStatusId)
        {
            this.playerStatusId = playerStatusId;
        }

        public PlayerStatus() : this(1) { }

        public string Location { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public int Id { get; internal set; }
    }
}
