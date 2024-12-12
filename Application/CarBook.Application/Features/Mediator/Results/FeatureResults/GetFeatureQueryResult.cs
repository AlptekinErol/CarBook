using CarBook.Application.Features.Mediator.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.FeatureResults
{
    public class GetFeatureQueryResult
    {
        public int FeatureId { get; set; }
        public string Name { get; set; }
    }
}
