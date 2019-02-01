// Copyright (c) Stickymaddness All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using FluentAssertions;
using Newtonsoft.Json.Linq;
using Sextant.Domain.Commands;
using Sextant.Infrastructure.Repository;
using Sextant.Tests;
using Sextant.Tests.Builders;
using Xunit;

namespace Sextant.Tests.Commands
{
    public class LocationCommandTests : CommandTestBase
    {
        private LocationCommand CreateSut(PlayerStatusRepository playerStatusRepository) => new LocationCommand(playerStatusRepository);

        [Fact]
        public void LocationCommand_Should_UpdateLocation()
        {
            PlayerStatusRepository repository = CreatePlayerStatusRepository();
            LocationCommand sut               = CreateSut(repository);

            repository.Location = Build.A.StarSystem.Name;

            string expectedSystem = Build.A.StarSystem.Name;

            JArray position = new JArray();
            position.Add(22.844);
            position.Add(106.125);
            position.Add(199.281);
            TestEvent loadEvent = Build.An.Event.WithEvent("LoadGame")
                .WithPayload("StarSystem", expectedSystem)
                .WithPayload("StarPos", position);

            sut.Handle(loadEvent);

            repository.Location.Should().Be(expectedSystem);
        }
    }
}
