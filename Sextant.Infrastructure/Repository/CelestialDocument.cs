// Copyright (c) Stickymaddness All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Sextant.Domain.Entities;

namespace Sextant.Infrastructure.Repository
{
    public class CelestialDocument
    {
        public string Name { get; set; }
        public string System { get; set; }
        public string Type { get; set; }
        public bool Scanned { get; set; }
        public bool Landable { get; set; }

        public CelestialDocument()
        { }

        public CelestialDocument(Celestial celetial)
        {
            Name          = celetial.Name;
            Type          = celetial.Type;
            Scanned       = celetial.Scanned;
        }

        public Celestial ToEntity()
        {
            return new Celestial(Name, Type, Scanned);
        }
    }
}
