using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using MatthewAzzopardiEpSolution.Helpers;


namespace MatthewAzzopardiEpSolution.Filters
{
    public class VoteOnceAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;
            var session = httpContext.Session;

            var pollId = context.ActionArguments.ContainsKey("pollId")
                ? context.ActionArguments["pollId"]?.ToString()
                : null;

            var username = session.GetString("Username");

            if (string.IsNullOrEmpty(pollId) || string.IsNullOrEmpty(username))
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
                return;
            }

            var votedPollsKey = $"VotedPolls_{username}";
            var votedPolls = session.GetObjectFromJson<List<string>>(votedPollsKey) ?? new List<string>();

            if (votedPolls.Contains(pollId))
            {
                context.Result = new ContentResult
                {
                    Content = "You have already voted on this poll."
                };
                return;
            }

            // Otherwise, store that this user is now voting on this poll
            votedPolls.Add(pollId);
            session.SetObjectAsJson(votedPollsKey, votedPolls);
        }
    }
}
