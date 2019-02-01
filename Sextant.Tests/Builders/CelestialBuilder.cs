// Copyright (c) Stickymaddness All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Sextant.Domain.Entities;
using System;

namespace Sextant.Tests.Builders
{
    public class CelestialBuilder
    {
        private bool Scanned;
        private string Name;
        private string Type;

        public static implicit operator Celestial(CelestialBuilder b) => new Celestial(b.Name, b.Type, b.Scanned);

        public CelestialBuilder()
        {
            Name           = Guid.NewGuid().ToString();
            Type = Guid.NewGuid().ToString();
        }

        public CelestialBuilder ThatHasBeenScanned()
        {
            Scanned = true;
            return this;
        }

        public CelestialBuilder ThatHasNotBeenScanned()
        {
            Scanned = false;
            return this;
        }
    }
}
