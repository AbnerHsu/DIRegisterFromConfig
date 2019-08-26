using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionHelper
{
    /// <summary>
    /// The Data object that Mircrosoft.Extensions.DependencyInjection Needs.
    /// </summary>
    public class DIService
    {
        /// <summary>
        /// Service Type 
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Implementation Type
        /// </summary>
        public string MapTo { get; set; }
        /// <summary>
        /// The lifetype of Service
        /// </summary>
        public ServiceLifetime LifeCycle { get; set; }
    }
}
