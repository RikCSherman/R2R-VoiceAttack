// Copyright (c) Stickymaddness All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Sextant.Domain.Entities;
using System.Collections.Generic;

namespace Sextant.Infrastructure.Repository
{
    public class StarSystemDocument
    {
        public bool Scanned { get; set; }
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public List<CelestialDocument> Celestials { get; set; }

        public StarSystemDocument()
        { }

        public StarSystemDocument(StarSystem system)
        {
            Name       = system.Name;
            Scanned    = system.Scanned;
            X = system.X;
            Y = system.Y;
            Z = system.Z;
            Celestials = system.Celestials.Select(c => new CelestialDocument(c)).ToList();
        }

        public StarSystem ToEntity()
        {
            StarSystem starSystem = new StarSystem(Name, Celestials.Select(c => c.ToEntity()).ToList());
            starSystem.X = X;
            starSystem.Y = Y;
            starSystem.Z = Z;
            return starSystem;
        }
    }
}
