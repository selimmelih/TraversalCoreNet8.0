using MediatR;
using TraversalCoreProje.CQRS.Results.GuideResults;

namespace TraversalCoreProje.CQRS.Commands.GuideCommands
{
    public class CreateGuideCommand:IRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
