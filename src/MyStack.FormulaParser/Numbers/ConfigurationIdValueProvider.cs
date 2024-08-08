﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStack.FormulaParser.Numbers
{
    public class ConfigurationIdValueProvider : IIdValueProvider
    {
        private readonly IConfiguration _configuration;
        public ConfigurationIdValueProvider(IConfiguration configuration,
            IOptionsMonitor<FormulaParserOptions> options)
        {
            _configuration = configuration;
            IdValues = options.CurrentValue.IdValues;
        }
        protected List<IdValue>? IdValues { get; }
        public Task<double> GetValueAsync(string id)
        {
            var value = IdValues?.Find(x => x.Id == id)?.Value ?? 0;
            return Task.FromResult(value);
        }
    }
}
