using System.Collections.Generic;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shelvance.Core.Datastore.Events;
using Shelvance.Core.Messaging.Events;
using Shelvance.Core.Tags;
using Shelvance.Http.REST.Attributes;
using Shelvance.SignalR;
using Shelvance.Http;
using Shelvance.Http.REST;

namespace Shelvance.Api.V1.Tags
{
    [V1ApiController]
    public class TagController : RestControllerWithSignalR<TagResource, Tag>, IHandle<TagsUpdatedEvent>
    {
        private readonly ITagService _tagService;

        public TagController(IBroadcastSignalRMessage signalRBroadcaster,
                         ITagService tagService)
            : base(signalRBroadcaster)
        {
            _tagService = tagService;

            SharedValidator.RuleFor(c => c.Label).NotEmpty();
        }

        protected override TagResource GetResourceById(int id)
        {
            return _tagService.GetTag(id).ToResource();
        }

        [HttpGet]
        public List<TagResource> GetAll()
        {
            return _tagService.All().ToResource();
        }

        [RestPostById]
        public ActionResult<TagResource> Create([FromBody] TagResource resource)
        {
            return Created(_tagService.Add(resource.ToModel()).Id);
        }

        [RestPutById]
        public ActionResult<TagResource> Update([FromBody] TagResource resource)
        {
            _tagService.Update(resource.ToModel());
            return Accepted(resource.Id);
        }

        [RestDeleteById]
        public void DeleteTag(int id)
        {
            _tagService.Delete(id);
        }

        [NonAction]
        public void Handle(TagsUpdatedEvent message)
        {
            BroadcastResourceChange(ModelAction.Sync);
        }
    }
}
