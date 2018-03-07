﻿using AspergillosisEPR.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspergillosisEPR.Lib.CaseReportForms
{
    public class CaseReportFormsDropdownResolver
    {
        private AspergillosisContext _context;

        public CaseReportFormsDropdownResolver(AspergillosisContext context)
        {
            _context = context;
        }

        public SelectList PopulateCRFFieldTypesDropdownList(object selectedItem = null)
        {
            var statuses = from se in _context.CaseReportFormFieldTypes
                           orderby se.Name
                           select se;
            return new SelectList(statuses, "ID", "Name", selectedItem);
        }

        public SelectList PopulateCRFOptionGroupChoicesDropdownList(int id, object selectedItem = null)
        {
            var options = _context.CaseReportFormOptionChoices
                                  .Where(crfoc => crfoc.CaseReportFormOptionGroupId == id)
                                  .ToList();
            return new SelectList(options, "ID", "Name", selectedItem);
        }

        public SelectList PopulateCRFOptionGroupsDropdownList(object selectedItem = null)
        {
            var statuses = from se in _context.CaseReportFormOptionGroups
                           orderby se.Name
                           select se;
            return new SelectList(statuses, "ID", "Name", selectedItem);
        }
    }
}