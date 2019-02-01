// Copyright (c) Stickymaddness All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Sextant.Domain.Entities
{
    public class StarSystem
    {
        public List<Celestial> Celestials { get; private set; }

        public bool Scanned => Celestials.All(c => c.Scanned);
        public string Name { get; private set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public StarSystem() : this(null) { }

        public StarSystem(string name) : this(name, new List<Celestial>()) { }

        public StarSystem(string name, List<Celestial> celestials)
        {
            Name       = name;
            Celestials = celestials;
        }

        public void AddCelestial(string name, string clasification)
        {
            Celestials.Add(new Celestial(name, clasification));
        }

        public double distance(IPlayerStatus player)
        {
            double xDiff = X - player.X;
            double ydiff = Y - player.Y;
            double zDiff = Z - player.Z;
            return Math.Sqrt((xDiff * xDiff) + (ydiff * ydiff) + (zDiff * zDiff));
        }
    }
}
