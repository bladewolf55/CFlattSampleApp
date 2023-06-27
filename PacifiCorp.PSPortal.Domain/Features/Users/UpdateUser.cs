using MediatR;
using PacifiCorp.PSPortal.Domain.Models;
using CommunityToolkit.Diagnostics;
using PacifiCorp.PSPortal.Data;
using PacifiCorp.PSPortal.Domain.Mapping;
using Microsoft.EntityFrameworkCore;

namespace PacifiCorp.PSPortal.Domain.Features.Users;

public static class UpdateUser
{
    public class Command : IRequest<User>
    {
        public User User { get; set; } = null!;
    }

    public class Handler : IRequestHandler<Command, User>
    {
        readonly IMediator mediator;

        public Handler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<User> Handle(Command request, CancellationToken cancellationToken)
        {
            var submittedModel = request.User;
            Guard.IsNotNull(submittedModel);
            var command = new Data.Features.Users.UpdateUser.Command { User = submittedModel.ToDataModel() };
            var dataUser = await mediator.Send(command, cancellationToken);
            return dataUser.ToDomainModel();
        }
    }


}
