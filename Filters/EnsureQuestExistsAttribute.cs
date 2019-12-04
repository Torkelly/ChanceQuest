using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ChanceQuest.Filters
{
    public class EnsureQuestExistsAttribute : ActionFilterAttribute
    {
        private readonly GameService _gameService;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var id = (int)context.ActionArguments["id"];

            if (!_gameService.DoesQuestExist(id))
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}
