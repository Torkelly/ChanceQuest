using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
