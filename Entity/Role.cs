﻿using Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
	public class Role
	{
		[Key]
		public int RoleId { get; set; }
		[Required,MaxLength(50)]
		public string RoleName { get; set; }
		public string? Description { get; set; }
		public RoleStatus Status { get; set; }	
	}
}
