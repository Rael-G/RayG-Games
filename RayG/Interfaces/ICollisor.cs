using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayG.Interfaces
{
    public interface ICollisor
    {
        Collisor Collisor { get; set; }

        void OnCollisionEnter(Collisor collisor);
        void OnCollisionExit(Collisor collisor);
    }
}
