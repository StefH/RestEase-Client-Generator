using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.TemplateComponent.App.Models;

namespace Blazor.TemplateComponent.App.Logic
{
    public interface ICakeLogic
    {
        Task<IList<Cake>> GetAll();
    }
}
