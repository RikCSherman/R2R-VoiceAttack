// Copyright (c) Stickymaddness All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Sextant.Domain.Commands;
using Sextant.Infrastructure.Repository;
using Sextant.Tests.Builders;
using Xunit;
using FluentAssertions;
using Newtonsoft.Json.Linq;

namespace Sextant.Tests.Commands
{
    public class JumpCompleteTests : CommandTestBase
    {
        [Fact]
        public void JumpComplete_Updates_Location_And_Coordinates()
        {
            PlayerStatusRepository playerRepository = CreatePlayerStatusRepository();
            JumpCompleteCommand sut                 = new JumpCompleteCommand(playerRepository);

            JArray position = new JArray();
            position.Add(22.844);
            position.Add(106.125);
            position.Add(199.281);
            TestEvent testEvent = Build.An.Event.WithEvent(sut.SupportedCommand)
                                                .WithPayload("StarSystem", "Test")
                                                .WithPayload("StarPos", position);

            sut.Handle(testEvent);

            playerRepository.Location.Should().Be("Test");
        }
    }
}
