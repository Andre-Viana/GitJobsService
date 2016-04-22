using GitJobsService.Core.Model;
using System.Collections.Generic;

namespace GitJobsService.Core.Service
{
    public interface ResponseListener
    {
        void OnResult(List<Position> positions);
    }
}
/* Interface. Determina um contrato. Para outras classes que vao herdar ResponseListner,
vaiterque ter esse metodo Onresult que vai receber uma lista. É uma interface da classe, contrato. 
Caracteristica obrigratoria da classe.*/
