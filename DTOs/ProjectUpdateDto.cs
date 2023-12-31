﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tp.Integrador.Softtek.Entities
{
    public class ProjectUpdateDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Address { get; set; }
        public int ProjectStatusId { get; set; }
    }
}
