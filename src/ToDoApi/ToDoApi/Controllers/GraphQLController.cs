using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Database;
using ToDoApi.GraphQL;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphQLController : Controller
    {
        private readonly AppDbContext _db;

        public GraphQLController(AppDbContext db) => _db = db;

        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            AddTestData(_db);
            var inputs = query.Variables.ToInputs();

            var schema = new Schema
            {
                Query = new ToDoItemQuery(_db)
            };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }


        private void AddTestData(AppDbContext context)
        {
            context.ToDoItems.AddRange(
               new ToDoItem()
               {
                   Description = "Make GraphQL Demo",
                   Status = true
               },
               new ToDoItem()
               {
                   Description = "Make GraphQL Presentation",
                   Status = true
               },
               new ToDoItem()
               {
 
                   Description = "Make F# Demo",
                   Status = false
               }
               );
            context.SaveChanges();
        }
    }
}
