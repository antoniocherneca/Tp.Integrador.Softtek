﻿namespace Tp.Integrador.Softtek.Entities
{
    public class ProjectDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Address { get; set; }
        public int ProjectStatusId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
