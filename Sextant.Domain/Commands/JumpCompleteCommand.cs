// Copyright (c) Stickymaddness All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Newtonsoft.Json.Linq;
using Sextant.Domain.Events;

namespace Sextant.Domain.Commands
{
    public class JumpCompleteCommand : ICommand
    {
        public string SupportedCommand => "FSDJump";
        public bool Handles(IEvent @event) => @event.Event == SupportedCommand;

        private readonly IPlayerStatus _playerStatus;

        public JumpCompleteCommand(IPlayerStatus playerStatus)
        {
            _playerStatus = playerStatus;
        }

        public void Handle(IEvent @event)
        {
            string location  = @event.Payload["StarSystem"].ToString();
            JArray position = (JArray)@event.Payload["StarPos"];
            double x = position[0].ToObject<double>();
            double y = position[1].ToObject<double>();
            double z = position[2].ToObject<double>();

            _playerStatus.Location = location;
            _playerStatus.X = x;
            _playerStatus.Y = y;
            _playerStatus.Z = z;
        }
    }
}
