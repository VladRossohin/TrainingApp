using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.BLL.DTO;

namespace TrainingApp.BLL.Interfaces
{
    public interface ITrainingService : IService<TrainingDTO>
    {
        IEnumerable<TrainingDTO> GetByUserId(long? id);
    }
}
