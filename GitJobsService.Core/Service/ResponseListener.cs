using GitJobsService.Core.Model;
using System.Collections.Generic;

namespace GitJobsService.Core.Service
{
    public interface ResponseListener
    {
        void OnResult(List<Position> positions);
    }
}
