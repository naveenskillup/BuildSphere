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

    }
}
