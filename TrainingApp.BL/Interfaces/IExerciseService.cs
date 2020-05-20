using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.BLL.DTO;

namespace TrainingApp.BLL.Interfaces
{
    public interface IExerciseService : IService<ExerciseDTO>
    {
        IEnumerable<ExerciseDTO> GetByTrainingId(long? id);
        IEnumerable<ExerciseDTO> GetBySensorId(long? id);
    }
}
