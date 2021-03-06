﻿using AspergillosisEPR.Lib.Search;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AspergillosisEPR.Models
{
    public class PatientDiagnosis : ISearchable
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int DiagnosisTypeId { get; set; }
        [Required]
        public int DiagnosisCategoryId { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        public Patient Patient { get; set; }
        public DiagnosisType DiagnosisType { get; set; }
        public DiagnosisCategory DiagnosisCategory { get; set; }

        public Dictionary<string, string> SearchableFields()
        {
            return new Dictionary<string, string>()
            {//klass.Field.Select (if select present than its a dropdown)
                { "Diagnosis Name", "PatientDiagnoses.DiagnosisTypeId.Select" },
                { "Diagnosis Category", "PatientDiagnoses.DiagnosisCategoryId.Select" }
            };
        }
    }
}