using Microsoft.AspNetCore.Mvc;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Application.Commands.CategoryEvent.Commands;
using Smart.Finances.Application.Queries.CategoryEvent.Queries;
using Smart.Finances.Application.ViewModels;

namespace Smart.Finances.Controllers.V1
{
    [Route("api/v1/categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAsync(
            [FromServices] IRequestHandler<GetAllCategoryQuery, List<CategoryViewModel>> handler,
            [FromQuery] GetAllCategoryQuery query)
        {
            return Ok(await handler.Handle(query));
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(
            [FromServices] IRequestHandler<AddCategoryCommand, CategoryViewModel> handler,
            [FromBody] AddCategoryCommand command
            )
        {
            return Ok(await handler.Handle(command));
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(
            [FromServices] IRequestHandler<EditCategoryCommand, CategoryViewModel> handler,
            [FromBody] EditCategoryCommand command
            )
        {
            return Ok(await handler.Handle(command));
        }
    }
}
