using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBanners
    {
        IEnumerable<Banner> GetAll();
        Banner GetById(int id);
        Task CreateAsSync(Banner banner);
        Task DeleteAsSync(int id);
        Task UpdateAsSync(Banner banner);
    }
}
