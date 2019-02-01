// Copyright (c) Stickymaddness All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Sextant.Domain
{
    public interface IPlayerStatus
    {
        string Location { get; set; }
        double X { get; set; }
        double Y { get; set; }
        double Z { get; set; }
    }
}
