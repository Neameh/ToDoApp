﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.DTOs.ToDoList;
using ToDoApp.Application.Mappers;
using ToDoApp.Domain.Models;
using ToDoApp.Infrastructure;

namespace ToDoApp.Application.Logic.Queries.ToDoListQuery
{
    public class ToDoListQueryHandler : IRequestHandler<GetToDoListQuery, List<ToDoListDTO>>
    {
        private readonly ApplicationDbContext _dbContext;
        public ToDoListQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ToDoListDTO>> Handle(GetToDoListQuery query, CancellationToken cancellationToken)
        {

            var toDoList = await _dbContext.ToDoLists.ToListAsync(cancellationToken);
            var result = toDoList.Select(x => x.ToToDoListDTO()).ToList();
            return result;

        }
    }
}
