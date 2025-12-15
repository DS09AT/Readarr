using System;
using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Datastore
{
    public class ModelNotFoundException : ShelvanceException
    {
        public ModelNotFoundException(Type modelType, int modelId)
            : base("{0} with ID {1} does not exist", modelType.Name, modelId)
        {
        }
    }
}
