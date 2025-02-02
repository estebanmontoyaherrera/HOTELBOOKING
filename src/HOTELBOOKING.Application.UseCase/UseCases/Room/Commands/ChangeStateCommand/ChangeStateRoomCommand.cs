﻿using HOTELBOOKING.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.UseCase.UseCases.Room.Commands.ChangeStateCommand
{
    public class ChangeStateRoomCommand : IRequest<BaseResponse<bool>>
    {
        public int RoomId { get; set; }
        public int State { get; set; }
    }
}
