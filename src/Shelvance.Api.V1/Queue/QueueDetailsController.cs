using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shelvance.Core.Datastore.Events;
using Shelvance.Core.Download.Pending;
using Shelvance.Core.Messaging.Events;
using Shelvance.Core.Queue;
using Shelvance.SignalR;
using Shelvance.Http;
using Shelvance.Http.REST;

namespace Shelvance.Api.V1.Queue
{
    [V1ApiController("queue/details")]
    public class QueueDetailsController : RestControllerWithSignalR<QueueResource, Shelvance.Core.Queue.Queue>,
                               IHandle<QueueUpdatedEvent>, IHandle<PendingReleasesUpdatedEvent>
    {
        private readonly IQueueService _queueService;
        private readonly IPendingReleaseService _pendingReleaseService;

        public QueueDetailsController(IBroadcastSignalRMessage broadcastSignalRMessage, IQueueService queueService, IPendingReleaseService pendingReleaseService)
            : base(broadcastSignalRMessage)
        {
            _queueService = queueService;
            _pendingReleaseService = pendingReleaseService;
        }

        [NonAction]
        public override ActionResult<QueueResource> GetResourceByIdWithErrorHandler(int id)
        {
            return base.GetResourceByIdWithErrorHandler(id);
        }

        protected override QueueResource GetResourceById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public List<QueueResource> GetQueue(int? authorId, [FromQuery]List<int> bookIds, bool includeAuthor = false, bool includeBook = true)
        {
            var queue = _queueService.GetQueue();
            var pending = _pendingReleaseService.GetPendingQueue();
            var fullQueue = queue.Concat(pending);

            if (authorId.HasValue)
            {
                return fullQueue.Where(q => q.Author?.Id == authorId.Value).ToResource(includeAuthor, includeBook);
            }

            if (bookIds.Any())
            {
                return fullQueue.Where(q => q.Book != null && bookIds.Contains(q.Book.Id)).ToResource(includeAuthor, includeBook);
            }

            return fullQueue.ToResource(includeAuthor, includeBook);
        }

        [NonAction]
        public void Handle(QueueUpdatedEvent message)
        {
            BroadcastResourceChange(ModelAction.Sync);
        }

        [NonAction]
        public void Handle(PendingReleasesUpdatedEvent message)
        {
            BroadcastResourceChange(ModelAction.Sync);
        }
    }
}
