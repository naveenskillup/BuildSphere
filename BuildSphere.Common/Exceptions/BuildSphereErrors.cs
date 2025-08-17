using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSphere.Common.Exceptions
{
    public static class BuildSphereErrors
    {
        public static BuildSphereHttpException ValidationFailed(List<string> errors)
        => new BuildSphereHttpException(400, string.Join(", ", errors));

        public static BuildSphereHttpException Unauthorized(string error)
        => new BuildSphereHttpException(401, error);

        public static BuildSphereHttpException Forbidden(string error)
        => new BuildSphereHttpException(403, error);

    }
}
