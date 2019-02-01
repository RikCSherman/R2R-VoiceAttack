// Copyright (c) Stickymaddness All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using FluentAssertions;
using Sextant.Domain.Commands;
using Sextant.Infrastructure.Repository;
using Sextant.Tests.Builders;
using Xunit;
using Sextant.Domain.Phrases;
using System.Linq;

namespace Sextant.Tests.Commands
{
    public class GameLoadCommandTests : CommandTestBase
    {
        [Fact]
        public void GameLoad_Should_StoreFuelCapacity()
        {
            TestCommunicator communicator     = CreateCommunicator();
            PlayerStatusRepository repository = CreatePlayerStatusRepository();
            GameLoadPhrases phrases           = TestPhraseBuilder.Build<GameLoadPhrases>();
            GameLoadCommand sut               = new GameLoadCommand(communicator, repository, phrases);

            TestEvent loadEvent = Build.An.Event.WithEvent("LoadGame");

            sut.Handle(loadEvent);

            communicator.MessagesCommunicated.Single().Should().Be(phrases.Generic.Single());
        }
    }
}
