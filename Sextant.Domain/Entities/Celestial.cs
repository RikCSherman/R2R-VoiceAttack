// Copyright (c) Stickymaddness All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Sextant.Domain.Entities
{
    public class Celestial
    {
        public bool Scanned { get; }

        public string Name { get; set; }
        public int Dls { get; set; }
        public string Type { get; set; }

        public string ShortName => Name.Replace("System", string.Empty);

        public Celestial() : this(null, null) { }

        public Celestial(string name, string type, bool scanned = false)
        {
            Name          = name;
            Type          = type;
            Scanned       = scanned;
        }
    }
}
