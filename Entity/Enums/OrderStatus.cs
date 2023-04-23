using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Enums
{
	public enum OrderStatus
	{
		deleted = -1,
		unconfirmed = 0,
		delivered = 1,
		canceled = 2
	}
}
